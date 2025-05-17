using System;

namespace ControlWorks.Services.PVI
{
    public class ServiceDetail
    {
        public string Name { get; set; }
        public bool IsConnected { get; set; }
        public int Cpus { get; set; }
        public DateTime ConnectTime { get; set; }
        public string License { get; set; }
    }
}