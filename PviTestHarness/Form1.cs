using ControlWorks.Database.SqlServer;
using ControlWorks.PrintService;
using ControlWorks.PviService;
using ControlWorks.Utils.Logging;
using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace PviTestHarness
{
    public partial class Form1 : Form
    {
        private ILogger _logger;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var pviService = new PviService(_logger);
            pviService.ConnectPVIService();
        }

        private void btnTestCoilInfo_Click(object sender, EventArgs e)
        {
            CoilInfo coildata;

            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    _logger.LogInfo(String.Format("Loading file {0}", openFileDialog1.FileName));
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(CoilInfo));
                    using (var fs = new FileStream(openFileDialog1.FileName, FileMode.Open))
                    {
                        using (var reader = XmlReader.Create(fs))
                        {
                            coildata = xmlSerializer.Deserialize(reader) as CoilInfo;
                        }
                    }

                    if (coildata != null)
                    {
                        var processor = new CoilInfoProcessor(_logger);
                        processor.ProcessAsync(coildata);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _logger = new Log4NetLogger();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var data = new ZplLabelData();

            data.SqYards = "12.34";
            data.LinearMeters = "23.45";
            data.GeneratedMaterialType = "B175.045.6";
            data.MaterialType = "B175.045";
            data.TolerancePlus = "0.003";
            data.ToleranceMinus = "0.002";
            data.ChangeNumber = "X80";
            data.CoilSerialNumber = "160825304801";
            data.LabInspector = "JP";
            data.Inspector = "TK";
            data.Batch = "2952";
            data.CalibrationDate = DateTime.Parse("2016-09-01T00:00:00");
            data.InspectionDate = DateTime.Parse("2016-08-31T00:00:00");
            data.LabInspectionDate = DateTime.Parse("2016-08-30T00:00:00");


            var service = new ZplLabelAmericanService(data, null);

            var label = service.GetLabel();


            //data.SetSqYards(Variables["CoilData.Length.Length[0]"].Value);
            //data.SetLinearMeters(Variables["CoilData.Length.Length[18]"].Value);
            //data.SetProperty(nameof(data.GeneratedMaterialType), Variables["CoilData.GeneratedMaterialType"].Value);
            //data.SetProperty(nameof(data.MaterialType), Variables["CoilData.MaterialType"].Value);
            //data.SetProperty(nameof(data.TolerancePlus), Variables["CoilData.TolerancePlus"].Value);
            //data.SetProperty(nameof(data.ToleranceMinus), Variables["CoilData.ToleranceMinus"].Value);
            //data.SetProperty(nameof(data.ChangeNumber), Variables["CoilData.ChangeNumber"].Value);
            //data.SetProperty(nameof(data.CoilSerialNumber), Variables["CoilData.Coil_SN_Number"].Value);
            //data.SetProperty(nameof(data.LabInspector), Variables["CoilData.LabInspector"].Value);
            //data.SetProperty(nameof(data.Inspector), Variables["CoilData.Inspector"].Value);
            //data.SetProperty(nameof(data.Batch), Variables["CoilData.BatchNumber"].Value);
            //data.SetProperty(nameof(data.CalibrationDate), Variables["CoilData.BatchNumber"].Value);

            //data.SetInspectionDate(Variables["CoilData.InspectionDate"].Value, Variables["CoilData.InspectionTime"].Value);
            //data.SetLabInspectionDate(Variables["CoilData.LabInspectDate"].Value);





        }

        private void btnTestEuropean_Click(object sender, EventArgs e)
        {
            var data = new ZplLabelData();

            data.LinearMeters = "98.7";
            data.RmR = "RMR 2152 02";
            data.SqYards = "12.34";
            data.LinearMeters = "23.45";
            data.GeneratedMaterialType = "B175.045.6";
            data.MaterialType = "B175.045";
            data.TolerancePlus = "0.003";
            data.ToleranceMinus = "0.002";
            data.ChangeNumber = "X80";
            data.CoilSerialNumber = "160825304801";
            data.LabInspector = "JP";
            data.Inspector = "TK";
            data.Batch = "2952";
            data.CalibrationDate = DateTime.Parse("2016-09-01T00:00:00");
            data.InspectionDate = DateTime.Parse("2016-08-31T00:00:00");
            data.LabInspectionDate = DateTime.Parse("2016-08-30T00:00:00");


            var service = new ZplLabelEuropeanService(data, null);

            var label = service.GetLabel();
        }
    }
}
