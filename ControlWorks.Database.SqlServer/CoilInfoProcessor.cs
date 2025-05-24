using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using ControlWorks.Common;
using ControlWorks.Database.SqlServer.Repositories;

namespace ControlWorks.Database.SqlServer
{
    public class CoilInfoProcessor
    {
        public void ProcessAsync(CoilInfo coilInfo)
        {
            Task.Run(() => SaveToFile(coilInfo));
            Task.Run(() => SaveToDb(coilInfo));

        }

        private Task SaveToFile(CoilInfo coilInfo)
        {
            Task.Run(() =>   
            {
                try
                {
                    var directoryPath = GetFileDirectory();

                    var fileName =
                        $"CoilData.{coilInfo.CoilData.BatchNumber}.{DateTime.Now.ToString("yyyyMMddHHmmss")}.xml";
                    var filePath = Path.Combine(directoryPath, fileName);
                    Trace.TraceInformation($"Saving coilInfo to file {filePath}");
                    File.WriteAllText(filePath, coilInfo.Serialize());
                }
                catch (Exception ex)
                {
                    Trace.TraceError(ex.ToString());
                    ;
                }
            });

            return Task.CompletedTask;
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

        private async Task SaveToDb(CoilInfo coilInfo)
        {
            try
            {
                Trace.TraceInformation($"Saving coilInfo to Db. BatchNumber={coilInfo.CoilData.BatchNumber}");

                var coilDataRepository = new CoilDataRepository();
                var lengthRepository = new LengthDataRepository();
                var sensorDataRepository = new SensorDataRepository();

                var coilDataId = await coilDataRepository.Insert(coilInfo.CoilData, coilInfo.IPAddress, coilInfo.CpuName);
                var lengthDataId =  await lengthRepository.Insert(coilInfo.LengthData, coilDataId);
                await sensorDataRepository.Insert(coilDataId, coilInfo.SensorData);

                Trace.TraceInformation($"Data save to Db. CoilDataId: {coilDataId}, LengthDataId: {lengthDataId}");

            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }
        }
    }
}
