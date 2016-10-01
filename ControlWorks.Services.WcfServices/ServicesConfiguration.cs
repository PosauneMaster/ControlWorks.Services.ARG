using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWorks.Services.WcfServices
{
    public static class ServicesConfiguration
    {
        public static string BaseConfigurationDirectory
        {
            get
            {
                if (ConfigurationManager.AppSettings["BaseConfigurationDirectory"] == null)
                {
                    return Environment.CurrentDirectory;
                }

                return ConfigurationManager.AppSettings["BaseConfigurationDirectory"];
            }
        }
    }
}
