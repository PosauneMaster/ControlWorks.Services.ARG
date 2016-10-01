using ControlWorks.Utils.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWorks.PviService
{
    public class Machine
    {

        public string  MachineName { get; set; }
        public string Destination { get; set; }
        public bool IsConnected { get; set; }

        public IPviService Service { get; private set; }
        public ILogger Logger { get; private set; }

        public Machine(IPviService pviService, ILogger logger)
        {
            Service = pviService;
            Logger = logger;
        }

    }
}
