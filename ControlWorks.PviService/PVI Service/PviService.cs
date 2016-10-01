using BR.AN.PviServices;
using ControlWorks.Utils.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWorks.PviService
{
    public class PviService : IPviService, IDisposable
    {
        private Service _service;

        private bool _shouldRetry = true;

        public event EventHandler<PviEventArgs> ServiceConnected;
        public event EventHandler<PviEventArgs> ServiceDisconnected;
        public event EventHandler<PviEventArgs> ServiceError;

        public ILogger Log { get; set; }

        public PviService(ILogger logger)
        {
            Log = logger;
        }

        public bool IsConnected
        {
            get
            { 
                if (Service == null)
                {
                    return false;
                }
                return Service.IsConnected;
            }
        }

        public Service Service
        {
            get
            {
                return _service;
            }

            set
            {
                _service = value;
            }
        }

        public void ConnectPVIService()
        {
            Log.LogInfo("Connecting PVI Service");
            _service = new Service(Guid.NewGuid().ToString());
            var serviceCollection = new ServiceCollection();
            _service.Connected += new PviEventHandler(_service_Connected);
            _service.Disconnected += new PviEventHandler(_service_Disconnected);
            _service.Error += new PviEventHandler(_service_Error);
            _service.Disposing += _service_Disposing;
            _service.Connect();
        }

        private void _service_Disposing(object sender, DisposeEventArgs e)
        {
            Log.LogInfo("PviService: Service is disposing");
        }

        public void ConnectPVIService(bool mock)
        {
            if (mock)
            {
                Log.LogInfo("Mock Service is true. Connecting Mock");
                Service = new Service("Test Service");
                OnServiceConnected(Service, new PviEventArgs(String.Empty, String.Empty, 0, String.Empty, BR.AN.PviServices.Action.ErrorEvent));
                return;
            }
            ConnectPVIService();
        }

        private void _service_Error(object sender, PviEventArgs e)
        {
            var pviEventMsg = FormatPviEventMessage("PviService._service_Error", e);
            Log.LogError(pviEventMsg);

            OnServiceError(sender, e);
        }

        private void OnServiceError(object sender, PviEventArgs e)
        {
            _service.Error -= _service_Error;

            EventHandler<PviEventArgs> temp = this.ServiceError;
            if (temp != null)
            {
                temp(_service, e);
            }
        }

        private void _service_Disconnected(object sender, PviEventArgs e)
        {
            var pviEventMsg = FormatPviEventMessage("PviService._service_Disconnected", e);
            Log.LogInfo(pviEventMsg);

            OnServiceDisconnected(sender, e);
        }

        private void OnServiceDisconnected(object sender, PviEventArgs e)
        {
            _service.Disconnected -= _service_Disconnected;

            EventHandler<PviEventArgs> temp = ServiceDisconnected;
            if (temp != null)
            {
                temp(sender, e);
            }
        }

        private void _service_Connected(object sender, PviEventArgs e)
        {
            var pviEventMsg = FormatPviEventMessage("PviService._service_Connected", e);
            Log.LogInfo(pviEventMsg);

            OnServiceConnected(sender, e);
        }

        private void OnServiceConnected(object sender, PviEventArgs e)
        {
            Service service = sender as Service;
            if (service != null)
            {
                EventHandler<PviEventArgs> temp = ServiceConnected;
                if (temp != null)
                {
                    temp(sender, e);
                }
            }

            _shouldRetry = true;
        }

        private void CpuManager_CpuConnected(object sender, PviEventArgs e)
        {
        }

        private void UnregisterEvents(Service service)
        {
            service.Connected -= _service_Connected;
            service.Error -= _service_Error;
            service.Disconnected -= _service_Disconnected;
        }

        public void DisconnectPVIService()
        {
            Service.Disconnect();
        }

        public void DisconnectPVIService(bool mock)
        {
            if (mock)
            {
                OnServiceDisconnected(this, new PviEventArgs(String.Empty, String.Empty, 0, String.Empty, BR.AN.PviServices.Action.Cancel));
            }
            else
            {
                DisconnectPVIService();
            }
        }


        private string FormatPviEventMessage(string message, PviEventArgs e)
        {
            return String.Format("{0}; Action={1}, Address={2}, Error Code={3}, Error Text={4}, Name={5} ",
                message, e.Action, e.Address, e.ErrorCode, e.ErrorText, e.Name);
        }


        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (Service != null)
                    {
                        UnregisterEvents(Service);
                        Service.Disconnect();
                        Service.Dispose();
                    }
                }
            }
            disposed = true;
        }
    }
}
