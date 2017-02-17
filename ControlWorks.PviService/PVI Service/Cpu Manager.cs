using BR.AN.PviServices;
using ControlWorks.Services.Pvi;
using ControlWorks.Utils.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControlWorks.PviService
{
    public class CpuManager : IDisposable
    {
        private static AutoResetEvent _resetEvent = new AutoResetEvent(false);


        private readonly byte m_SourceStationId = 100;

        public event EventHandler<PviEventArgs> CpuConnected;
        public event EventHandler<PviEventArgs> CpuDisconnected;
        public event EventHandler<PviEventArgs> CpuError;

        private Service _service;

        public Cpu Cpu { get; set; }

        public ILogger Logger { get; set; }


        public CpuManager(Service service, ILogger logger)
        {
            _service = service;
            Logger = logger;
        }

        public void LoadCpuCollection(IList<CpuInfo> cpuCollection)
        {
            foreach (var cpu in cpuCollection)
            {
                _resetEvent.WaitOne(5000);
                ConnectCpu(cpu.Name, cpu.IpAddress);
            }
        }

        public void ConnectCpu(string cpuName, string ipAddress)
        {
            try
            {
                Logger.LogInfo(String.Format("CpuManager.ConnectCpu cpuName:{0}, ipAddress:{1}", cpuName, ipAddress));
                Cpu cpu = null;
                if (_service.Cpus.ContainsKey(cpuName))
                {
                    cpu = _service.Cpus[cpuName];
                }
                else
                {
                    cpu = new Cpu(_service, cpuName);
                }

                cpu.Connection.DeviceType = DeviceType.TcpIp;
                cpu.Connection.TcpIp.SourceStation = this.m_SourceStationId;
                cpu.Connection.TcpIp.DestinationIpAddress = ipAddress;

                cpu.Connected += cpu_Connected;
                cpu.Error += cpu_Error;
                cpu.Disconnected += cpu_Disconnected;
                cpu.UserData = $"IpAddress:{ipAddress},CpuName:{cpuName}";


                cpu.Connect();
            }
            catch (System.Exception ex)
            {

                Logger.LogError(ex);
            }
        }

        public void DisconnectCpu(Cpu cpu)
        {
            Logger.LogInfo(String.Format("Disconnecting Cpu {0}", cpu.Name));
            _service.Cpus[cpu.Name].Disconnect();
        }

        private void cpu_Connected(object sender, PviEventArgs e)
        {
            LogPviEvent.LogInfo("CpuManager.OnCpuConnected", e);
            OnCpuConnected(sender, e);
        }
        private void OnCpuConnected(object sender, PviEventArgs e)
        {
            Cpu cpu = sender as Cpu;
            Cpu = cpu;
            if (cpu != null)
            {
                var variableManager = new VariableManager(Logger);
                variableManager.LoadVariables(cpu);

                EventHandler<PviEventArgs> temp = CpuConnected;
                if (temp != null)
                {
                    temp(this, e);
                }
            }

            _resetEvent.Set();
        }

        private void cpu_Disconnected(object sender, PviEventArgs e)
        {
            LogPviEvent.LogInfo("CpuManager.cpu_Disconnected", e);
            OnCpuDisconnected(sender, e);
        }

        private void OnCpuDisconnected(object sender, PviEventArgs e)
        {
            Cpu cpu = sender as Cpu;
            if (cpu != null)
            {

                cpu.Connected -= cpu_Connected;
                cpu.Error -= cpu_Error;
                cpu.Disconnected -= cpu_Disconnected;

                EventHandler<PviEventArgs> temp = CpuDisconnected;
                if (temp != null)
                {
                    temp(sender, e);
                }
            }

            _resetEvent.Set();
        }

        private void cpu_Error(object sender, PviEventArgs e)
        {
            LogPviEvent.LogInfo("CpuManager.cpu_Error", e);
            OnCpuError(sender, e);
        }

        private void OnCpuError(object sender, PviEventArgs e)
        {

            Cpu cpu = sender as Cpu;
            cpu.Error -= cpu_Error;

            if (cpu != null)
            {
                cpu.Disconnect();
                EventHandler<PviEventArgs> temp = CpuError;
                if (temp != null)
                {
                    temp(sender, e);
                }
            }

            _resetEvent.Set();
        }

        #region Mock Events
        private void cpu_MockConnected(object sender, PviEventArgs e)
        {
            OnMockCpuConnected(sender, e);
        }

        private void OnMockCpuConnected(object sender, PviEventArgs e)
        {
            //PviEventArgs eventArgs = new PviEventArgs(e.Name, e.Address, 0, "en-US", e.Action);

            //Cpu cpu = sender as Cpu;
            //if (cpu != null)
            //{
            //    EventHandler<PviEventArgs> temp = CpuConnected;
            //    if (temp != null)
            //    {
            //        temp(sender, eventArgs);
            //    }
            //}
        }

        private void cpu_MockError(object sender, PviEventArgs e)
        {
            OnMockCpuConnected(sender, e);
        }

        private void OnMockCpuError(object sender, PviEventArgs e)
        {
            //Cpu cpu = sender as Cpu;
            //PviEventArgs eventArgs = new PviEventArgs(e.Name, e.Address, 0, "en-US", e.Action);
            //if (cpu != null)
            //{
            //    UnregisterEvents(cpu);
            //    cpu.Disconnect();
            //    EventHandler<PviEventArgs> temp = m_CpuError;
            //    if (temp != null)
            //    {
            //        temp(sender, eventArgs);
            //    }
            //}
        }

        #endregion

        #region IDisposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_service != null)
                {
                    foreach (Cpu cpu in _service.Cpus)
                    {
                        cpu.Dispose();
                    }
                }
            }
        }

        ~CpuManager()
        {
            Dispose(false);
        }
        #endregion
    }
}
