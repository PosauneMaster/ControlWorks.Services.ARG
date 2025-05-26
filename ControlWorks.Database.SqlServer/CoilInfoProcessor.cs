using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

using ControlWorks.Common;
using ControlWorks.Database.SqlServer.Repositories;

namespace ControlWorks.Database.SqlServer
{
    public class CoilInfoProcessor
    {
        public void ProcessAsync(CoilInfo coilInfo)
        {
            //SaveToFile(coilInfo);
            SaveToDb(coilInfo);

            //Task.Run(() => SaveToFile(coilInfo));
            //Task.Run(() => SaveToDb(coilInfo));
        }

        private void SaveToFile(CoilInfo coilInfo)
        {
            try
            {
                var directoryPath = GetFileDirectory();

                var fileName =
                    $"CoilData.{coilInfo.CoilData.BatchNumber}.{DateTime.Now:yyyyMMddHHmmss}.xml";
                var filePath = Path.Combine(directoryPath, fileName);
                Trace.TraceInformation($"Saving coilInfo to file {filePath}");
                File.WriteAllText(filePath, coilInfo.Serialize());

                Trace.TraceInformation($"Created file for BatchNumber {coilInfo.CoilData.BatchNumber}: {fileName}");
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }

        }

        private string GetFileDirectory()
        {
            var info = new DateTimeFormatInfo();
            string monthName = info.GetMonthName(DateTime.Now.Month);

            var directoryPath = ConfigurationProvider.CoilInfoFileDirectory;

            var currentPath = Path.Combine(directoryPath, $"{DateTime.Now.Year} {monthName}");
            if (!Directory.Exists(currentPath))
            {
                Directory.CreateDirectory(currentPath);
            }

            return currentPath;
        }

        private void SaveToDb(CoilInfo coilInfo)
        {
            try
            {
                Trace.TraceInformation($"Saving coilInfo to Db. BatchNumber={coilInfo.CoilData.BatchNumber}");

                var coilDataRepository = new CoilDataRepository();
                var lengthRepository = new LengthDataRepository();
                var sensorDataRepository = new SensorDataRepository();

                var coilDataId = coilDataRepository.Insert(coilInfo.CoilData, coilInfo.IPAddress, coilInfo.CpuName);
                var lengthDataId =  lengthRepository.Insert(coilInfo.LengthData, coilDataId);
                sensorDataRepository.Insert(coilDataId, coilInfo.SensorData);

                Trace.TraceInformation($"Data save to Db. CoilDataId: {coilDataId}, LengthDataId: {lengthDataId}");

            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }
        }
    }
}
