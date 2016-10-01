using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ControlWorks.Services.WcfServices
{
    public interface IWcfCommunicationServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void HeartbeatSent(Heartbeat heartbeat);

        [OperationContract(IsOneWay = true)]
        void SendConfiguration(int machineId, VariableRepository repository);

    }
}
