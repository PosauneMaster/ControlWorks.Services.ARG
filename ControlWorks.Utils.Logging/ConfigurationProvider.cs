using System;
using System.Configuration;

namespace ControlWorks.Utils
{
    public static class ConfigurationProvider
    {
        public static string CpuName
        {
            get { return ConfigurationManager.AppSettings["CpuName"]; }
        }

        public static int CpuStationId
        {
            get { return Int32.Parse(ConfigurationManager.AppSettings["CpuStationId"]); }
        }

        public static int MaxSensorData
        {
            get { return Int32.Parse(ConfigurationManager.AppSettings["MaxSensorData"]); }
        }

        public static string ZplPrinterName
        {
            get { return ConfigurationManager.AppSettings["ZplPrinterName"]; }
        }

        public static bool LogZplCodes
        {
            get { return ConfigurationManager.AppSettings["LogZplCodes"].ToUpper().StartsWith("T", StringComparison.CurrentCulture); }
        }

        public static string AmericanLabelSettings
        {
            get { return ConfigurationManager.AppSettings["AmericanLabelSettings"]; }
        }

        public static string EuropeanLabelSettings
        {
            get { return ConfigurationManager.AppSettings["EuropeanLabelSettings"]; }
        }
    }
}
