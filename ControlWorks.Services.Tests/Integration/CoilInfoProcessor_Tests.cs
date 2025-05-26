using System;

using ControlWorks.Database.SqlServer;
using ControlWorks.Database.SqlServer.InternalEntities;
using NUnit.Framework;

namespace ControlWorks.Services.Tests.Integration
{
    public class CoilInfoProcessor_Tests
    {
        private DateTime _dt = DateTime.Now;
        private int _index = 1;

        private string GetDecimalString()
        {
            _index++;
            return $"{_dt.Hour + _dt.Minute + _dt.Second}.{_index}";
        }

        private string GetIntString()
        {
            return $"{_dt.Hour + _dt.Minute + _dt.Second + _index}";
        }

        [Test]
        public void CoilInfoProcessor_Test()
        {
            CreateCoilInfoData();
        }

        private CoilInfo CreateCoilInfoData()
        {
            var dt = DateTime.Now;
            var coilInfo = new CoilInfo
            {
                IPAddress = $"IP_Address_Test_{dt:yyyyMMddHHmmss}",
                CpuName = $"Cpu_Name_Test_{dt:yyyyMMddHHmmss}"
            };
            var coilData = new CoilDataInternal();
            var lengthData = new LengthDataInternal();

            coilData.SetProperty(nameof(coilData.MaterialType), $"MaterialType_Test_{dt:yyyyMMddHHmmss}");
            coilData.SetProperty(nameof(coilData.MaterialThickness), GetDecimalString());
            coilData.SetProperty(nameof(coilData.OriginalSqYards), GetIntString());
            coilData.SetProperty(nameof(coilData.BatchNumber), $"BatchNumber_Test_{dt:yyyyMMddHHmmss}");
            coilData.SetProperty(nameof(coilData.ChangeNumber), $"ChangeNumber_Test_{dt:yyyyMMddHHmmss}");
            coilData.SetProperty(nameof(coilData.ExtrusionDate), $"{dt:g}");
            coilData.SetProperty(nameof(coilData.RollSnNumber), $"RollSnNumber_Test_{dt:yyyyMMddHHmmss}");
            coilData.SetProperty(nameof(coilData.CoilNumber), GetIntString());
            coilData.SetProperty(nameof(coilData.CoilWidth), GetDecimalString());
            coilData.SetProperty(nameof(coilData.TolerancePlus), GetDecimalString());
            coilData.SetProperty(nameof(coilData.ToleranceMinus), GetDecimalString());
            coilData.SetProperty(nameof(coilData.Inspector), $"Inspector_Test_{dt:yyyyMMddHHmmss}");
            coilData.SetInspectionDateTime($"{dt:g}", $"{dt:g}");
            coilData.SetProperty(nameof(coilData.CalibrationDate), $"{dt:g}");
            coilData.SetProperty(nameof(coilData.GeneratedMaterialType), $"GeneratedMaterialType_Test_{dt:yyyyMMddHHmmss}");
            coilData.SetProperty(nameof(coilData.OvenPos), GetIntString());
            coilData.BatchRunTimestamp = dt;
            coilData.SetProperty(nameof(coilData.MachineNumber), GetIntString());
            coilData.SetProperty(nameof(coilData.Coil_SN_Number), $"Coil_SN_Number_Test_{dt:yyyyMMddHHmmss}");
            coilData.SetProperty(nameof(coilData.LabInspector), $"LabInspector_{dt:yyyyMMddHHmmss}");
            coilData.SetProperty(nameof(coilData.RollNumber), GetIntString());
            coilData.SetLabInspectDate($"{dt:g}");
            
            coilInfo.CoilData = coilData;

            lengthData.SetProperty(nameof(lengthData.Good), GetDecimalString());
            lengthData.SetProperty(nameof(lengthData.ThicknessScrap), GetDecimalString());
            lengthData.SetProperty(nameof(lengthData.ThicknessReclass), GetDecimalString());
            lengthData.SetProperty(nameof(lengthData.Blisters), GetDecimalString());
            lengthData.SetProperty(nameof(lengthData.Contamination), GetDecimalString());
            lengthData.SetProperty(nameof(lengthData.Gas), GetDecimalString());
            lengthData.SetProperty(nameof(lengthData.Holes), GetDecimalString());
            lengthData.SetProperty(nameof(lengthData.Lumps), GetDecimalString());
            lengthData.SetProperty(nameof(lengthData.PaperBreaks), GetDecimalString());
            lengthData.SetProperty(nameof(lengthData.PaperSplice), GetDecimalString());
            lengthData.SetProperty(nameof(lengthData.Shiny), GetDecimalString());
            lengthData.SetProperty(nameof(lengthData.SlitterDefect), GetDecimalString());
            lengthData.SetProperty(nameof(lengthData.TapeInCoil), GetDecimalString());
            lengthData.SetProperty(nameof(lengthData.Wrinkles), GetDecimalString());
            lengthData.SetProperty(nameof(lengthData.Width), GetDecimalString());
            lengthData.SetProperty(nameof(lengthData.Other), GetDecimalString());
            lengthData.SetProperty(nameof(lengthData.Salvage), GetDecimalString());
            lengthData.SetProperty(nameof(lengthData.LinearMeters), GetDecimalString());

            coilInfo.LengthData = lengthData;


            for (short i = 0; i < 2; i++)
            {
                var sensor = new SensorDataInternal();
                sensor.SensorNumber = Convert.ToInt16(i + 10000);
                sensor.SetProperty(nameof(sensor.Position), GetDecimalString());
                sensor.SetProperty(nameof(sensor.SensorData0), GetDecimalString());
                sensor.SetProperty(nameof(sensor.SensorData1), GetDecimalString());
                sensor.SetProperty(nameof(sensor.SensorData2), GetDecimalString());
                sensor.SetProperty(nameof(sensor.SensorData3), GetDecimalString());
                sensor.SetProperty(nameof(sensor.SensorData4), GetDecimalString());

                coilInfo.AddSensorData(sensor);
            }

            var processor = new CoilInfoProcessor();
            processor.ProcessAsync(coilInfo);

            return coilInfo;

        }
    }
}
