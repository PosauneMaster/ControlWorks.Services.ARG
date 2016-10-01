using ControlWorks.Utils.Logging;
using System;
using System.Collections.Concurrent;
using System.ServiceModel;
using System.Threading.Tasks;

namespace ControlWorks.Services.WcfServices
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class WcfCommunicationService : IWcfCommunicationService
    {

        private System.Threading.Timer _timer;
        private ILogger _logger;

        protected ILogger Logger
        {
            get
            {
                if (_logger == null)
                {
                    _logger = new Log4NetLogger();
                }

                return _logger;
            }
        }

        private readonly ConcurrentDictionary<string, IWcfCommunicationServiceCallback> sentHeartbeatCallbackList;

        private readonly IHostApplication _hostApplication;

        public WcfCommunicationService()
        {
        }

        public bool IsPviConnected()
        {
            return _hostApplication.IsPviConnected;
        }

        public bool IsCpuConnected()
        {
            return _hostApplication.IsCpuConnected;
        }

        public void SaveMachineConfiguration(int machineId, VariableRepository repository)
        {
            var controller = new VariableController(Logger);
            controller.CreateVariableConfiguration(machineId, repository);
        }


        public WcfCommunicationService(IHostApplication hostApplication)
        {
            sentHeartbeatCallbackList = new ConcurrentDictionary<string, IWcfCommunicationServiceCallback>();
            _hostApplication = hostApplication;
            _hostApplication.HeartbeatSent += HostApplicationHeartbeatSent;
            StartHeartbeat();
        }
        public void RegisterForService(string id)
        {
            var callback = OperationContext.Current.GetCallbackChannel<IWcfCommunicationServiceCallback>();
            if (callback != null)
            {
                sentHeartbeatCallbackList.TryAdd(id, callback);
            }
        }

        public void DisconnectFromService(string id)
        {
            IWcfCommunicationServiceCallback callback;
            sentHeartbeatCallbackList.TryRemove(id, out callback);
        }


        private void HostApplicationHeartbeatSent(object sender, EventArgs<Heartbeat> e)
        {
            foreach (var heartbeatCallback in sentHeartbeatCallbackList.Values)
            {
                if (heartbeatCallback != null)
                {
                    heartbeatCallback.HeartbeatSent(e.Data);
                }
            }
        }

        private void StartHeartbeat()
        {
            System.Threading.TimerCallback timerDelegate = new System.Threading.TimerCallback(Heartbeat);
            _timer = new System.Threading.Timer(timerDelegate, sentHeartbeatCallbackList, 500, 1000);
        }

        private void Heartbeat(object stateInfo)
        {
            var callbackList = stateInfo as ConcurrentDictionary<string, IWcfCommunicationServiceCallback>;
            if (callbackList != null)
            {
                foreach (var heartbeatCallback in callbackList.Values)
                {
                    try
                    {
                        heartbeatCallback.HeartbeatSent(new Heartbeat());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
            }
        }

        public void RecieveBatchDetailsRaw(string batchDetails)
        {
            Task.Run(() => _hostApplication.BatchDetailsCsvReceived(batchDetails));
        }

    }


}
