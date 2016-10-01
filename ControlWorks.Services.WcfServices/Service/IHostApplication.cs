using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWorks.Services.WcfServices
{
    public interface IHostApplication
    {
        event EventHandler<EventArgs<Heartbeat>> HeartbeatSent;
        Task BatchDetailsCsvReceived(string csvData);
        bool IsPviConnected { get; }
        bool IsCpuConnected { get; }
    }

    public class EventArgs<T> : EventArgs
    {
        public EventArgs(T t)
        {
            Data = t;
        }

        public T Data { get; private set; }
    }

}
