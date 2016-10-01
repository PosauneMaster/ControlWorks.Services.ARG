using log4net;
using log4net.Appender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "Log4Net.config", Watch = true)]

namespace ControlWorks.Utils.Logging
{
    public class Log4NetLogger : ILogger
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Log4NetLogger() { }
        public Log4NetLogger(string fileTarget)
        {
            log4net.Repository.Hierarchy.Hierarchy h = (log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository();
            foreach (IAppender a in h.Root.Appenders)
            {
                if (a is RollingFileAppender)
                {
                    RollingFileAppender rfa = a as RollingFileAppender;
                    rfa.File = fileTarget;
                    rfa.ActivateOptions();
                }
            }
        }


        public void Log(LogEntry entry)
        {
            try
            {
                switch (entry.Severity)
                {
                    case LoggingEventType.Debug:
                        log.Debug(entry.Message, entry.Exception);
                        break;
                    case LoggingEventType.Warning:
                        log.Info(entry.Message, entry.Exception);
                        break;
                    case LoggingEventType.Information:
                        log.Warn(entry.Message, entry.Exception);
                        break;
                    case LoggingEventType.Error:
                        log.Error(entry.Message, entry.Exception);
                        break;
                    case LoggingEventType.Fatal:
                        log.Fatal(entry.Message, entry.Exception);
                        break;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
