using BR.AN.PviServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWorks.PviService
{
    public interface IPviService
    {
        event EventHandler<PviEventArgs> ServiceConnected;
        event EventHandler<PviEventArgs> ServiceDisconnected;
        event EventHandler<PviEventArgs> ServiceError;

        bool IsConnected { get; }
        Service Service { get; set; }

        void ConnectPVIService();
        void ConnectPVIService(bool mock);
        void DisconnectPVIService();



    }
}
