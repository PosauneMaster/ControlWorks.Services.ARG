using System;
using System.Diagnostics;
using System.Threading.Tasks;


namespace ControlWorks.Services
{
    public interface IHost
    {
        void Start();
        void Stop();
    }

    public class Host : IHost
    {
        public void Start()
        {
            var pviApp = new ControlWorks.Services.PVI.Pvi.PviAplication();
            var factory = new TaskFactory();
            factory.StartNew(() => pviApp.Connect(), TaskCreationOptions.LongRunning);
        }

        public void Stop()
        {
        }

    }
}