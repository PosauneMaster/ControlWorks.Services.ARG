using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWorks.Utils.Logging
{
    public interface ILogger
    {
        void Log(LogEntry entry);
    }
}
