using BR.AN.PviServices;
using ControlWorks.Services.Configuration;
using ControlWorks.Services.Pvi;
using ControlWorks.Utils.Logging;
using System;
using System.Windows.Forms;

namespace ControlWorks.PviService
{
    public class PviContext : ApplicationContext 
    {
        private ILogger _logger;

        private Service _service;
        private Cpu _cpu;

        private bool _shouldReconnectCpu = true;
        private bool _disposed = false;

        public CpuManager CpuService { get; private set; }

        public bool IsPviConnected
        {
            get
            {
                if (_service == null)
                {
                    return false;
                }
                return _service.IsConnected;
            }
        }

        public bool IsCpuConnected
        {
            get
            {
                if (_cpu == null)
                {
                    return false;
                }
                return _cpu.IsConnected;
            }
        }

        public PviContext()
        {
            _disposed = false;
            _logger = new Log4NetLogger();
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            ConnectPvi();
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = e.ExceptionObject as System.Exception;
            _logger.LogError("PviContext: Unhandled AppDomain Error");
            _logger.LogError(ex.Message);
            _logger.LogError(ex);
            _service.Disconnect();
        }

        private void ConnectPvi()
        {
            var pviService = new PviService(_logger);
            pviService.ServiceConnected += PviService_ServiceConnected;
            pviService.ServiceDisconnected += PviService_ServiceDisconnected;
            pviService.ServiceError += PviService_ServiceError;
            pviService.ConnectPVIService();
        }

        //private void ConnectCpu(Service service)
        //{
        //    var cpuManager = new CpuManager(service, _logger);
        //    cpuManager.CpuConnected += CpuManager_CpuConnected;
        //    cpuManager.CpuDisconnected += CpuManager_CpuDisconnected;
        //    cpuManager.CpuError += CpuManager_CpuError;
        //    cpuManager.ConnectCpu(Utils.ConfigurationProvider.CpuName, Utils.ConfigurationProvider.CpuStationId);
        //}

        public void ConnectVariables(Cpu cpu)
        {
            var variableManager = new VariableManager(_logger);
            variableManager.LoadVariables(cpu);
        }


        private void CpuManager_CpuError(object sender, PviEventArgs e)
        {
            _logger.LogError(String.Format("PviContext: CpuManager_CpuError: {0}", e.ErrorText));
            Cpu cpu = sender as Cpu;
            if (cpu != null)
            {
                cpu.Dispose();
                if (IsPviConnected)
                {
                    if (_shouldReconnectCpu)
                    {
                        _shouldReconnectCpu = false;
                    }
                }
            }
        }

        private void CpuManager_CpuDisconnected(object sender, PviEventArgs e)
        {
            _logger.LogInfo("PviContext:CpuManager_CpuDisconnected");
            _logger.LogError(String.Format("IsPviConnected={0}", IsPviConnected));
            _logger.LogError(String.Format("IsCpuConnected={0}", IsCpuConnected));
            _logger.LogError(String.Format("Attempting cpu reconnect"));

            if (IsPviConnected)
            {
                if (_shouldReconnectCpu)
                {
                    _shouldReconnectCpu = false;
                }
            }
        }

        private void CpuManager_CpuConnected(object sender, PviEventArgs e)
        {
            _shouldReconnectCpu = true;
            _logger.LogInfo("CpuManager_CpuConnected");

            CpuManager cpuManager = sender as CpuManager;
            _cpu = cpuManager.Cpu;
            ConnectVariables(_cpu);
        }

        private void PviService_ServiceError(object sender, PviEventArgs e)
        {
            _logger.LogError(String.Format("PviService_ServiceError: {0}", e.ErrorText));
            _service.Disconnect();
        }

        private void PviService_ServiceDisconnected(object sender, PviEventArgs e)
        {
            _logger.LogInfo("PviService_ServiceDisconnected");
        }

        private void PviService_ServiceConnected(object sender, BR.AN.PviServices.PviEventArgs e)
        {
            _service = sender as Service;
            var settingFile = ConfigurationProvider.CpuSettingsFile;
            var collection = new CpuInfoCollection();

            try
            {
                collection.Open(settingFile);
                CpuService = new CpuManager(_service, _logger);
                //CpuService.CpusLoaded += CpuService_CpusLoaded;
                CpuService.LoadCpuCollection(collection.GetAll());


            }
            catch (System.Exception ex)
            {
                _logger.Log(new LogEntry(LoggingEventType.Error, "Error Loading Cpu Settings", ex));
            }


            CpuService = new CpuManager(_service, _logger);

            _logger.LogInfo("PviService_ServiceConnected");
            _service = sender as Service;
            ConnectCpu(_service);
        }

        protected override void Dispose(bool disposing)
        {
            _disposed = true;
            if (!_disposed)
            {
                if (_service != null)
                {
                    _service.Dispose();
                }
                base.Dispose(disposing);
            }
        }
    }
}
