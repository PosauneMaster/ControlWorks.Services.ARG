//using BR.AN.PviServices;
//using ControlWorks.Utils.Logging;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ControlWorks.PviService
//{
//    public class PviEngine
//    {
//        public ILogger Logger { get; set; }
//        private IPviService _pviService;
//        private CpuManager _cpuManager;
//        private VariableManager _variableManager;

//        public PviEngine(ILogger logger)
//        {
//            Logger = logger;
//        }
            

//        public void ConnectSystem()
//        {
//            _pviService = new PviService(Logger);
//            _pviService.ServiceConnected += _pviService_ServiceConnected;
//            _pviService.ServiceDisconnected += _pviService_ServiceDisconnected;
//            _pviService.ServiceError += _pviService_ServiceError;


//            _pviService.ConnectPVIService(false);
//        }

//        private void ConnectCpu()
//        {
//            _cpuManager = new CpuManager(_pviService, Logger);
//            _cpuManager.CpuConnected += _cpuManager_CpuConnected;
//            _cpuManager.CpuDisconnected += _cpuManager_CpuDisconnected;
//            _cpuManager.CpuError += _cpuManager_CpuError;

//            _cpuManager.ConnectCpu("Source Station 1", 2);
//        }

//        private void _cpuManager_CpuConnected(object sender, BR.AN.PviServices.PviEventArgs e)
//        {
//            ConnectVariables(sender as Cpu);
//        }


//        private void _cpuManager_CpuError(object sender, BR.AN.PviServices.PviEventArgs e)
//        {
//            throw new NotImplementedException();
//        }

//        private void ConnectVariables(Cpu cpu)
//        {
//            _variableManager = new VariableManager();
//            _variableManager.VariableChanged += _variableManager_VariableChanged;
//            _variableManager.LoadVariables(cpu);
//        }

//        private void _variableManager_VariableChanged(object sender, PviEventArgs e)
//        {
//            //TODO Read variables from PVI
//            throw new NotImplementedException();
//        }

//        private void _cpuManager_CpuDisconnected(object sender, BR.AN.PviServices.PviEventArgs e)
//        {
//            throw new NotImplementedException();
//        }

//        private void _pviService_ServiceError(object sender, BR.AN.PviServices.PviEventArgs e)
//        {
//            throw new NotImplementedException();
//        }

//        private void _pviService_ServiceDisconnected(object sender, BR.AN.PviServices.PviEventArgs e)
//        {
//            throw new NotImplementedException();
//        }

//        private void _pviService_ServiceConnected(object sender, BR.AN.PviServices.PviEventArgs e)
//        {
//            ConnectCpu();
//        }
//    }
//}
