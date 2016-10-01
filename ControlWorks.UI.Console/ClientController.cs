using ControlWorks.Services.WcfServices;
using ControlWorks.Utils.Logging;
using System;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.Threading.Tasks;

namespace ControlWorks.UI.Console
{
    public class ClientController : IWcfCommunicationServiceCallback
    {
        private ILogger _logger;

        private IWcfCommunicationService _pipeProxy;
        private ChannelFactory<IWcfCommunicationService> _pipeFactory;

        private bool _isOpen;
        public bool IsOpen { get { return _isOpen; } }



        public event EventHandler<HeartbeatEventArgs> Heartbeat;

        protected void OnHeartbeat(DateTime dt)
        {
            var temp = Heartbeat;
            if (temp != null)
            {
                Heartbeat(this, new HeartbeatEventArgs() { HeartbeatTime = dt });
            }
        }

        public ClientController()
        {
            _logger = new Log4NetLogger(ConsoleConfiguration.LogFile);
            _isOpen = false;
        }

        public void HeartbeatSent(Heartbeat heartbeat)
        {
            System.Console.WriteLine(heartbeat.Timestamp);
            OnHeartbeat(heartbeat.Timestamp);
        }

        public void SendConfiguration(int machineId, VariableRepository repository)
        {
            _pipeProxy.SaveMachineConfiguration(machineId, repository);
        }

        public bool IsPviConnected()
        {
            if (!IsOpen)
            {
                return false;
            }
            return _pipeProxy.IsPviConnected();
        }

        public bool IsCpuConnected()
        {
            if (!IsOpen)
            {
                return false;
            }
            return _pipeProxy.IsCpuConnected();
        }
        
        public void Connect(object stateInfo)
        {
            if (_isOpen)
            {
                return;
            }

            var id = stateInfo as string;

            var group =
                ServiceModelSectionGroup.GetSectionGroup(
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None));

            if (group != null)
            {
                _pipeFactory = new DuplexChannelFactory<IWcfCommunicationService>(this, group.Client.Endpoints[0].Name);

                _pipeProxy = _pipeFactory.CreateChannel();
                ((IClientChannel)_pipeProxy).Faulted += PipeProxyFaulted;
                ((IClientChannel)_pipeProxy).Opened += PipeProxyOpened;
                ((IClientChannel)_pipeProxy).Closed += PipeProxyClosed;
                try
                {
                    ((IClientChannel)_pipeProxy).Open();

                    _pipeProxy.RegisterForService(id);

                }
                catch(Exception ex)
                {
                    _logger.LogError("Unable to connect to ControlWorksCoilDataService");
                    _logger.LogError(ex);
                }
            }
        }

        public void Disconnect(object stateInfo)
        {
            var id = stateInfo as string;

            if (IsOpen)
            {
                _pipeProxy.DisconnectFromService(id);
            }
        }

        public void SendBatchDetails(string details)
        {
            Task.Run(() => _pipeProxy.RecieveBatchDetailsRaw(details));
        }

        void PipeProxyClosed(object sender, EventArgs e)
        {
            _isOpen = false;
        }


        void PipeProxyOpened(object sender, EventArgs e)
        {
            _isOpen = true;
        }

        void PipeProxyFaulted(object sender, EventArgs e)
        {

            _logger.LogError("PipeProxyFaulted");
            var proxy = sender as IClientChannel;
            if (proxy != null)
            {
                proxy.Faulted -= PipeProxyFaulted;
                proxy.Opened -= PipeProxyOpened;
                proxy = null;
            }

            this._pipeFactory = null;
            _isOpen = false;
        }

    }

    public class HeartbeatEventArgs : EventArgs
    {
        public DateTime HeartbeatTime { get; set; }
    }
}
