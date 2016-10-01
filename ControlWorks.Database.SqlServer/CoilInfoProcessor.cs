using ControlWorks.Utils.Logging;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Validation;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWorks.Database.SqlServer
{
    public class CoilInfoProcessor
    {
        private ILogger Log { get; set; }
        public CoilInfoProcessor(ILogger logger)
        {
            Log = logger;
        }

        private void Process(CoilInfo coilInfo)
        {
            SaveToFile(coilInfo);
            SaveToDb(coilInfo);
        }

        public void ProcessAsync(CoilInfo coilInfo)
        {
            Task.Run(() => Process(coilInfo));
        }

        private bool SaveToFile(CoilInfo coilInfo)
        {
            try
            {
                var directoryPath = GetFileDirectory();

                var fileName = String.Format("CoilData.{0}.{1}.xml", coilInfo.CoilData.BatchNumber, DateTime.Now.ToString("yyyyMMddHHmmss"));
                var filePath = Path.Combine(directoryPath, fileName);
                Log.LogInfo(String.Format("Saving coilInfo to file {0}", filePath));
                File.WriteAllText(filePath, coilInfo.Serialize());

                return true;
            }
            catch(Exception ex)
            {
                Log.LogError(ex);
                return false;
            }
        }

        private string GetFileDirectory()
        {
            var info = new DateTimeFormatInfo();
            string monthName = info.GetMonthName(DateTime.Now.Month);

            var directoryPath = ConfigurationManager.AppSettings.Get("CoilInfoFileDirectory");
            var currentPath = Path.Combine(directoryPath, String.Format("{0} {1}", DateTime.Now.Year, monthName));
            if (!Directory.Exists(currentPath))
            {
                Directory.CreateDirectory(currentPath);
            }

            return currentPath;
        }

        private bool SaveToDb(CoilInfo coilInfo)
        {
            try
            {
                Log.LogInfo(String.Format("Saving coilInfo to Db. BatchNumber={0}", coilInfo.CoilData.BatchNumber));

                using (var context = new CoilInfoContext())
                {
                    var coilDataRepository = new CoilDataRepository(context);
                    var lengthRepository = new LengthDataRepository(context);
                    var sensorDataRepository = new SensorDataRepository(context);
                    var sensorReportRepository = new SensorReportRepository(context);

                    var id = coilDataRepository.Insert(coilInfo.CoilData);
                    lengthRepository.Insert(id, coilInfo.LengthData);
                    sensorDataRepository.Insert(id, coilInfo.SensorData);

                    var sensorReport = CreateSensorRepotData(coilInfo);
                    sensorReportRepository.Insert(id, sensorReport);
                }
            }
            catch (DbEntityValidationException e)
            {
                string rs = "";
                foreach (var eve in e.EntityValidationErrors)
                {
                    rs = string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State);

                    foreach (var ve in eve.ValidationErrors)
                    {
                        rs += "<br />" + string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                    }
                }
                Log.LogError("EntityValidationErrors");
                Log.LogError(e);

                throw new Exception(rs);
            }
            catch (Exception ex)
            {
                Log.LogError(ex);
            }

            return true;
        }

        private List<SensorReportInternal> CreateSensorRepotData(CoilInfo coilInfo)
        {
            var reportList = new List<SensorReportInternal>();

            var map = new Dictionary<decimal, short>();

            foreach (var data in coilInfo.SensorData)
            {
                StoreReportData(data.SensorData0, map);
                StoreReportData(data.SensorData1, map);
                StoreReportData(data.SensorData2, map);
                StoreReportData(data.SensorData4, map);
                StoreReportData(data.SensorData4, map);
            }

            foreach (var key in map.Keys)
            {
                reportList.Add(new SensorReportInternal { SensorMeasurement = key, MeasurementCount = map[key] });
            }

            return reportList;
        }

        private void StoreReportData(decimal? data, Dictionary<decimal, short> map)
        {
            if (data.HasValue)
            {
                var dataPoint = Math.Round(data.Value, 3);
                if (!map.ContainsKey(dataPoint))
                {
                    map.Add(dataPoint, 0);
                }
                map[dataPoint] += 1;
            }
        }
    }
}
