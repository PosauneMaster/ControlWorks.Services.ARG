using ControlWorks.PviService;
using ControlWorks.Services.WcfServices;
using ControlWorks.Utils.Logging;
using System;
using System.Threading.Tasks;

namespace ControlWorks.Services
{
    public partial class Host : IHostApplication
    {
        private ILogger _logger;
        private PviApplication _pviApplication;
        private bool _isStopping;
        private System.Threading.Timer _healthCheckTimer;
        private DateTime _lastHeartbeat;

        public event EventHandler<EventArgs<Heartbeat>> HeartbeatSent;

        public bool IsPviConnected { get { return _pviApplication.IsPviConnected; } }
        public bool IsCpuConnected { get { return _pviApplication.IsCpuConnected; } }

        public void Start()
        {
            _isStopping = false;

            _logger = new Log4NetLogger();

            var executionState = NativeMethods.SetExecutionStateToAwake();

            _logger.LogInfo(String.Format("SetExecutionStateToAwake return {0}", executionState));


            //var group = ServiceModelSectionGroup.GetSectionGroup(ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None));

            //if (group != null)
            //{
            //    var service = group.Services.Services[0];
            //    var baseAddress = service.Endpoints[0].Address.AbsoluteUri.Replace(service.Endpoints[0].Address.AbsolutePath, String.Empty);
            //    var wcfService = new WcfCommunicationService(this);
            //    var host = new ServiceHost(wcfService, new[] { new Uri(baseAddress) });
            //    host.AddServiceEndpoint(typeof(IWcfCommunicationService), new NetNamedPipeBinding(), service.Endpoints[0].Address.AbsolutePath);
            //    host.Open();
            //}

            StartPvi();

            System.Threading.TimerCallback timerDelegate = new System.Threading.TimerCallback(HealthCheck);
            _healthCheckTimer = new System.Threading.Timer(timerDelegate, new object(), 30000, 15000);
        }

        private void StartPvi()
        {
            _pviApplication = new PviApplication();
            _pviApplication.ApplicationDisconnected += _pviApplication_ApplicationDisconnected;
            Task.Run(() => _pviApplication.StartPvi());
        }

        private void _pviApplication_ApplicationDisconnected(object sender, EventArgs e)
        {
            if (!_isStopping)
            {
                StartPvi();
            }
        }

        public void Stop()
        {
            _isStopping = true;
            NativeMethods.RestoreExecutionState();
        }

        public void OnHeartbeat(Heartbeat heartbeat)
        {
            _lastHeartbeat = heartbeat.Timestamp;
            var hb = HeartbeatSent;
            if (hb != null)
            {
                hb(this, new EventArgs<Heartbeat>(heartbeat));
            }
        }

        public async Task BatchDetailsCsvReceived(string csvData)
        {

            var processor = new CoilTypeProcessor(_logger);
            await processor.ProcessCsv(csvData);
        }

        private void HealthCheck(object stateInfo)
        {
            if (!IsPviConnected)
            {
                _logger.LogError("Health Check indicates that IsPviConnected=false.  Attempting restart.");
                if (_pviApplication != null)
                {
                    _pviApplication.StopPvi();
                }
                StartPvi();
            }
        }


}
}
