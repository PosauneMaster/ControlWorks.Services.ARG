using ControlWorks.Utils.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Logger.TestHarness
{
   class Program
    {
        static void Main(string[] args)
        {
            ILogger log = new Log4NetLogger();
            log.LogDebug("A DEBUG Message...");
            log.LogError("AN ERROR Message...");
            log.LogInfo("AN INFO Message...");

            try
            {
                var x = 0;
                var y = 0;

                var z = x / y;
            }
            catch (Exception ex)
            {
                log.LogError(ex);
            }

        }
    }
}
