using BR.AN.PviServices;
using ControlWorks.Database.SqlServer;
using ControlWorks.PrintService;
using ControlWorks.Utils.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ControlWorks.PviService
{
    public class VariableManager
    {

        private ILogger _logger;

        private int _currentState = 0;
        private readonly int _totalState = 0;
        private PviEventArgs _eventArgs;
        private readonly int MAX_SENSOR_DATA;

        private CultureInfo _provider = CultureInfo.CreateSpecificCulture("en-US");

        public VariableCollection Variables { get; private set; }

        public bool AllVariablesConnected { get { return _totalState == _currentState; }}


        private Dictionary<string, int> _variableStateLookup = new Dictionary<string, int>();

        public VariableManager(ILogger logger)
        {
            _logger = logger;

            MAX_SENSOR_DATA = Utils.ConfigurationProvider.MaxSensorData;

            _variableStateLookup.Add("CoilData.ToleranceMinus", 0x01);
            _variableStateLookup.Add("CoilData.TolerancePlus", 0x02);
            _variableStateLookup.Add("CoilData.CalibrationDate", 0x04);
            _variableStateLookup.Add("CoilData.OrgionalSQYards", 0x08);
            _variableStateLookup.Add("CoilData.CoilWidth", 0x0A);
            _variableStateLookup.Add("CoilData.CoilNumber", 0x20);
            _variableStateLookup.Add("CoilData.Date", 0x40);
            _variableStateLookup.Add("CoilData.ChangeNumber", 0x80);
            _variableStateLookup.Add("CoilData.RollNumber", 0x100);
            _variableStateLookup.Add("CoilData.Inspector", 0x200);
            _variableStateLookup.Add("CoilData.BatchNumber", 0x400);
            _variableStateLookup.Add("CoilData.MaterialType", 0x800);
            _variableStateLookup.Add("CoilData.OvenPos", 0x1000);
            _variableStateLookup.Add("CoilData.MaterialThk", 0x2000);
            _variableStateLookup.Add("CoilData.Length", 0x4000);
            _variableStateLookup.Add("CoilData.Data", 0x8000);

            _totalState = _variableStateLookup.Values.Sum();
        }

        public void LoadVariables(Cpu cpu)
        {
            cpu.Variables.Clear();

            CreateVariable(cpu, "heartbeat");
            CreateVariable(cpu, "CoilData");
            CreateVariable(cpu, "btnSendProductionData");
            CreateVariable(cpu, "btnPrintZplLabel");
            CreateVariable(cpu, "labelType");

            CreateVariable(cpu, "CoilData.ToleranceMinus");
            CreateVariable(cpu, "CoilData.TolerancePlus");
            CreateVariable(cpu, "CoilData.CalibrationDate");
            CreateVariable(cpu, "CoilData.OriginalSQYards");
            CreateVariable(cpu, "CoilData.CoilWidth");
            CreateVariable(cpu, "CoilData.CoilNumber");
            CreateVariable(cpu, "CoilData.InspectionTime");
            CreateVariable(cpu, "CoilData.ExtrusionDate");
            CreateVariable(cpu, "CoilData.InspectionDate");
            CreateVariable(cpu, "CoilData.ChangeNumber");
            CreateVariable(cpu, "CoilData.Roll_SN_Number");
            CreateVariable(cpu, "CoilData.Inspector");
            CreateVariable(cpu, "CoilData.BatchNumber");
            CreateVariable(cpu, "CoilData.GeneratedMaterialType");
            CreateVariable(cpu, "CoilData.MaterialType");
            CreateVariable(cpu, "CoilData.OvenPos");
            CreateVariable(cpu, "CoilData.MaterialThk");

            CreateVariable(cpu, "CoilData.MachineNumber");
            CreateVariable(cpu, "CoilData.Coil_SN_Number");
            CreateVariable(cpu, "CoilData.LabInspector");
            CreateVariable(cpu, "CoilData.LabInspectDate");
            CreateVariable(cpu, "CoilData.RollNumber");

            CreateVariable(cpu, "CoilData.Length.Length[0]");
            CreateVariable(cpu, "CoilData.Length.Length[1]");
            CreateVariable(cpu, "CoilData.Length.Length[2]");
            CreateVariable(cpu, "CoilData.Length.Length[3]");
            CreateVariable(cpu, "CoilData.Length.Length[4]");
            CreateVariable(cpu, "CoilData.Length.Length[5]");
            CreateVariable(cpu, "CoilData.Length.Length[6]");
            CreateVariable(cpu, "CoilData.Length.Length[7]");
            CreateVariable(cpu, "CoilData.Length.Length[8]");
            CreateVariable(cpu, "CoilData.Length.Length[9]");
            CreateVariable(cpu, "CoilData.Length.Length[10]");
            CreateVariable(cpu, "CoilData.Length.Length[11]");
            CreateVariable(cpu, "CoilData.Length.Length[12]");
            CreateVariable(cpu, "CoilData.Length.Length[13]");
            CreateVariable(cpu, "CoilData.Length.Length[14]");
            CreateVariable(cpu, "CoilData.Length.Length[15]");
            CreateVariable(cpu, "CoilData.Length.Length[16]");
            CreateVariable(cpu, "CoilData.Length.Length[17]");
            CreateVariable(cpu, "CoilData.Length.Length[18]");

            for (int i = 0; i < MAX_SENSOR_DATA; i++)
            {
                CreateVariable(cpu, String.Format("CoilData.Data[{0}].Position", i));
                CreateVariable(cpu, String.Format("CoilData.Data[{0}].SensorData[0]", i));
                CreateVariable(cpu, String.Format("CoilData.Data[{0}].SensorData[1]", i));
                CreateVariable(cpu, String.Format("CoilData.Data[{0}].SensorData[2]", i));
                CreateVariable(cpu, String.Format("CoilData.Data[{0}].SensorData[3]", i));
                CreateVariable(cpu, String.Format("CoilData.Data[{0}].SensorData[4]", i));
            }

            Variables = cpu.Variables;

        }

        private Variable CreateVariable(Cpu cpu, string name)
        {
            Variable variable = new Variable(cpu, name);
            variable.UserTag = name;
            variable.UserData = cpu.UserData;
            variable.ValueChanged += new VariableEventHandler(this.v_ValueChanged);
            variable.Connected += new PviEventHandler(this.v_Connected);
            variable.Error += Variable_Error;
            variable.Active = true;
            variable.Connect();
            return variable;
        }

        private void Variable_Error(object sender, PviEventArgs e)
        {
            //LogPviEvent.LogError("CreateGetData", e);
        }

        private void v_ValueChanged(object sender, VariableEventArgs e)
        {
            Variable variable = sender as Variable;
            OnVariableChanged(variable);
        }

        private void ProcessVariables()
        {
            var coilInfo = new CoilInfo();
            var coilData = new CoilDataInternal();
            var lengthData = new LengthDataInternal();

            coilData.SetProperty(nameof(coilData.ToleranceMinus), Variables["CoilData.ToleranceMinus"].Value);
            coilData.SetProperty(nameof(coilData.TolerancePlus), Variables["CoilData.TolerancePlus"].Value);
            coilData.SetProperty(nameof(coilData.CalibrationDate), Variables["CoilData.CalibrationDate"].Value);
            coilData.SetProperty(nameof(coilData.OriginalSqYards), Variables["CoilData.OriginalSQYards"].Value);
            coilData.SetProperty(nameof(coilData.CoilWidth), Variables["CoilData.CoilWidth"].Value);
            coilData.SetProperty(nameof(coilData.CoilNumber), Variables["CoilData.CoilNumber"].Value);
            coilData.SetProperty(nameof(coilData.ExtrusionDate), Variables["CoilData.ExtrusionDate"].Value);
            coilData.SetProperty(nameof(coilData.ChangeNumber), Variables["CoilData.ChangeNumber"].Value);
            coilData.SetProperty(nameof(coilData.RollSnNumber), Variables["CoilData.Roll_SN_Number"].Value);
            coilData.SetProperty(nameof(coilData.Inspector), Variables["CoilData.Inspector"].Value);
            coilData.SetProperty(nameof(coilData.BatchNumber), Variables["CoilData.BatchNumber"].Value);
            coilData.SetProperty(nameof(coilData.GeneratedMaterialType), Variables["CoilData.GeneratedMaterialType"].Value);
            coilData.SetProperty(nameof(coilData.MaterialType), Variables["CoilData.MaterialType"].Value);
            coilData.SetProperty(nameof(coilData.OvenPos), Variables["CoilData.OvenPos"].Value);
            coilData.SetProperty(nameof(coilData.MaterialThickness), Variables["CoilData.MaterialThk"].Value);

            coilData.SetProperty(nameof(coilData.MachineNumber), Variables["CoilData.MachineNumber"].Value);
            coilData.SetProperty(nameof(coilData.Coil_SN_Number), Variables["CoilData.Coil_SN_Number"].Value);
            coilData.SetProperty(nameof(coilData.LabInspector), Variables["CoilData.LabInspector"].Value);
            coilData.SetProperty(nameof(coilData.RollNumber), Variables["CoilData.RollNumber"].Value);

            coilData.SetLabInspectDate(Variables["CoilData.LabInspectDate"].Value);
            coilData.BatchRunTimestamp = DateTime.Now;

            coilData.SetInspectionDateTime(Variables["CoilData.InspectionDate"].Value, Variables["CoilData.InspectionTime"].Value);

            coilInfo.CoilData = coilData;

            lengthData.SetProperty(nameof(lengthData.Good), Variables["CoilData.Length.Length[0]"].Value);
            lengthData.SetProperty(nameof(lengthData.ThicknessScrap), Variables["CoilData.Length.Length[1]"].Value);
            lengthData.SetProperty(nameof(lengthData.ThicknessReclass), Variables["CoilData.Length.Length[2]"].Value);
            lengthData.SetProperty(nameof(lengthData.Blisters), Variables["CoilData.Length.Length[3]"].Value);
            lengthData.SetProperty(nameof(lengthData.Contamination), Variables["CoilData.Length.Length[4]"].Value);
            lengthData.SetProperty(nameof(lengthData.Gas), Variables["CoilData.Length.Length[5]"].Value);
            lengthData.SetProperty(nameof(lengthData.Holes), Variables["CoilData.Length.Length[6]"].Value);
            lengthData.SetProperty(nameof(lengthData.Lumps), Variables["CoilData.Length.Length[7]"].Value);
            lengthData.SetProperty(nameof(lengthData.PaperBreaks), Variables["CoilData.Length.Length[8]"].Value);
            lengthData.SetProperty(nameof(lengthData.PaperSplice), Variables["CoilData.Length.Length[9]"].Value);
            lengthData.SetProperty(nameof(lengthData.Shiny), Variables["CoilData.Length.Length[10]"].Value);
            lengthData.SetProperty(nameof(lengthData.SlitterDefect), Variables["CoilData.Length.Length[11]"].Value);
            lengthData.SetProperty(nameof(lengthData.TapeInCoil), Variables["CoilData.Length.Length[12]"].Value);
            lengthData.SetProperty(nameof(lengthData.Wrinkles), Variables["CoilData.Length.Length[13]"].Value);
            lengthData.SetProperty(nameof(lengthData.Width), Variables["CoilData.Length.Length[14]"].Value); 
            lengthData.SetProperty(nameof(lengthData.Other), Variables["CoilData.Length.Length[15]"].Value);
            lengthData.SetProperty(nameof(lengthData.Salvage), Variables["CoilData.Length.Length[16]"].Value);
            lengthData.SetProperty(nameof(lengthData.LinearMeters), Variables["CoilData.Length.Length[18]"].Value);

            coilInfo.LengthData = lengthData;

            for (short i = 0; i < MAX_SENSOR_DATA; i++)
            {
                var sensor = new SensorDataInternal();
                sensor.SensorNumber = (i);
                sensor.SetProperty(nameof(sensor.Position), Variables[String.Format("CoilData.Data[{0}].Position", i)].Value);
                sensor.SetProperty(nameof(sensor.SensorData0), Variables[String.Format("CoilData.Data[{0}].SensorData[0]", i)].Value);
                sensor.SetProperty(nameof(sensor.SensorData1), Variables[String.Format("CoilData.Data[{0}].SensorData[1]", i)].Value);
                sensor.SetProperty(nameof(sensor.SensorData2), Variables[String.Format("CoilData.Data[{0}].SensorData[2]", i)].Value);
                sensor.SetProperty(nameof(sensor.SensorData3), Variables[String.Format("CoilData.Data[{0}].SensorData[3]", i)].Value);
                sensor.SetProperty(nameof(sensor.SensorData4), Variables[String.Format("CoilData.Data[{0}].SensorData[4]", i)].Value);

                coilInfo.AddSensorData(sensor);
            }

            if (coilInfo != null)
            {
                var processor = new CoilInfoProcessor(_logger);
                processor.ProcessAsync(coilInfo);
            }
        }

        private void ProcessZplVariables()
        {
            var data = new ZplLabelData();

            data.SetSqYards(Variables["CoilData.Length.Length[0]"].Value);
            data.SetLinearMeters(Variables["CoilData.Length.Length[18]"].Value);
            data.SetProperty(nameof(data.GeneratedMaterialType), Variables["CoilData.GeneratedMaterialType"].Value);
            data.SetProperty(nameof(data.MaterialType), Variables["CoilData.MaterialType"].Value);
            data.SetProperty(nameof(data.TolerancePlus), Variables["CoilData.TolerancePlus"].Value);
            data.SetProperty(nameof(data.ToleranceMinus), Variables["CoilData.ToleranceMinus"].Value);
            data.SetProperty(nameof(data.ChangeNumber), Variables["CoilData.ChangeNumber"].Value);
            data.SetProperty(nameof(data.CoilSerialNumber), Variables["CoilData.Coil_SN_Number"].Value);
            data.SetProperty(nameof(data.LabInspector), Variables["CoilData.LabInspector"].Value);
            data.SetProperty(nameof(data.Inspector), Variables["CoilData.Inspector"].Value);
            data.SetProperty(nameof(data.Batch), Variables["CoilData.BatchNumber"].Value);
            data.SetProperty(nameof(data.CalibrationDate), Variables["CoilData.CalibrationDate"].Value);

            data.SetInspectionDate(Variables["CoilData.InspectionDate"].Value, Variables["CoilData.InspectionTime"].Value);
            data.SetLabInspectionDate(Variables["CoilData.LabInspectDate"].Value);

            try
            {
                var repo = new RmrDataRepository(new CoilInfoContext());
                data.RmR = repo.GetRmR(data.MaterialType);

                int labelType = 0;

                if(Variables["labelType"].Value != null)
                {
                    labelType = Variables["labelType"].Value.ToInt32(CultureInfo.CurrentCulture);
                }

                var labelService = LabelServiceFactory.Get(labelType, data, _logger);
                labelService.SendToPrinter();
            }
            catch(System.Exception ex)
            {
                _logger.LogError("Error sending data to Zpl Printer");
                _logger.LogError(ex);
            }
        }

        private void OnVariableChanged(Variable variable)
        {
            if (variable == null)
            {
                return;
            }

            if (variable.Name == "btnPrintZplLabel")
            {
                var btnSendProductionData = Variables["btnPrintZplLabel"].Value;
                if (btnSendProductionData)
                {
                    _logger.LogInfo("Recieved btnPrintZplLabel=true.  Begin Printing Label");

                    ProcessZplVariables();

                    Variables["btnPrintZplLabel"].WriteValueAutomatic = false;
                    Variables["btnPrintZplLabel"].Value.Assign((object)false);
                    Variables["btnPrintZplLabel"].WriteValue();

                    _logger.LogInfo("Set btnPrintZplLabel to false  Printing Label complete");

                }
            }

            if (variable.Name == "btnSendProductionData")
            {
                var btnSendProductionData = Variables["btnSendProductionData"].Value;

                if (btnSendProductionData)
                {
                    _logger.LogInfo("Recieved btnSendProductionData=true.  Begin Processing data");
                    ProcessVariables();

                    Variables["btnSendProductionData"].WriteValueAutomatic = false;
                    Variables["btnSendProductionData"].Value.Assign((object)false);
                    Variables["btnSendProductionData"].WriteValue();

                    _logger.LogInfo("Set btnSendProductionData to false  Processing data complete");
                }
            }
        }

        private void v_Connected(object sender, PviEventArgs e)
        {
            Variable variable = sender as Variable;

            if (_variableStateLookup.ContainsKey(variable.Name))
            {
                _currentState = _currentState | _variableStateLookup[variable.Name];
            }

            IsHearbeat(variable);

            System.Diagnostics.Debug.WriteLine(variable.Address);

            this._eventArgs = e;
        }

        private Timer t;
        private bool IsHearbeat(Variable v)
        {
            if (v.UserTag.Equals("heartbeat"))
            {
                _heartbeatVariable = v;
                t = new Timer(new TimerCallback(SendHeartbeat), null, 0, 1000);
                return true;
            }

            return false;
        }

        private Variable _heartbeatVariable;
        private bool _lastHeartbeat = false;
        private void SendHeartbeat(object o)
        {
            if (_heartbeatVariable != null && _heartbeatVariable.Value != null)
            {
                _lastHeartbeat = !_lastHeartbeat;
                _heartbeatVariable.WriteValueAutomatic = false;
                _heartbeatVariable.Value.Assign((object)_lastHeartbeat);
                _heartbeatVariable.WriteValue();
            }
        }

        private void SerializeVariableCollection()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(VariableCollection));
            using (var textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, Variables);
                var result = textWriter.ToString();
            }
        }

        private void SerializeVariable(Variable v)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Variable));
            using (var textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, v);
                var result = textWriter.ToString();
            }
        }

    }
}
