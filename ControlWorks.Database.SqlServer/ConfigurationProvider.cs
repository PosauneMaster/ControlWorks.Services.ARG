using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWorks.Database.SqlServer
{
    public static class ConfigurationProvider
    {

        public static string FileDirectoryPath
        {
            get
            {
                const string defaultPath = @"D:\ControlWorks\Data\Files";

                var path = ConfigurationManager.AppSettings.Get("CoilInfoFileDirectory");

                if (String.IsNullOrEmpty(path))
                {
                    var root = Path.GetPathRoot(defaultPath);

                    if (!Directory.Exists(root))
                    {
                        return defaultPath;
                    }
                    else
                    {
                        return @"D:\ControlWorks\Data\Files";
                    }
                }

                return path;
            }
        }
    }
}
