using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ControlWorks.Services.WcfServices
{
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IWcfCommunicationServiceCallback))]
    public interface IWcfCommunicationService
    {
        [OperationContract]
        void RegisterForService(string id);

        [OperationContract]
        void DisconnectFromService(string id);

        [OperationContract]
        void SaveMachineConfiguration(int machineId, VariableRepository repository);

        [OperationContract]
        void RecieveBatchDetailsRaw(string batchDetails);

        [OperationContract]
        bool IsPviConnected();

        [OperationContract]
        bool IsCpuConnected();
    }
}
