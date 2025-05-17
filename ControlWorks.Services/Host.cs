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

        }

        public void Stop()
        {
        }

    }
}