using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWorks.UI.Console
{
    public static class ConsoleConfiguration
    {
        public static string LogFile
        {
            get { return ConfigurationManager.AppSettings.Get("LogFile"); }
        }

        public static string SqlServerServiceName
        {
            get { return ConfigurationManager.AppSettings.Get("SqlServerServiceName"); }
        }

    }
}
