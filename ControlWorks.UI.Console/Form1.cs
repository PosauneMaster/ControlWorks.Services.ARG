using ControlWorks.Services.WcfServices;
using ControlWorks.Utils.Logging;
using System;
using System.Drawing;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlWorks.UI.Console
{
    public partial class Form1 : Form
    {
        private const int CONTROL_WORKS_SERVICE_ROW = 0;
        private const int HEARTBEAT_ROW = 1;
        private const int PVI_CONNECTION = 2;
        private const int CPU_CONNECTION = 3;
        private const int SQL_SERVER_SERVICE = 4;


        private ClientController _controller;
        private string _guidId;
        private ILogger _logger;
        private bool _heartbeat;
        private DateTime _heartbeatTime;

        private Bitmap _greenlight;
        private Bitmap _redlight;
        private Bitmap _blank;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            var repository = new VariableRepository() { MachineId = 1 };
            repository.Add("part1", "part1_1");
            repository.Add("part2", "part2_2");
            repository.Add("part3", "part3_3");

            Action<int, VariableRepository> action = (machine, repo) => _controller.SendConfiguration(machine, repo);
            Task.Run(() => _controller.SendConfiguration(1, repository));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Tick += Timer_Tick;
            timer.Interval = 2000;
            timer.Start();

            _heartbeat = false;
            _greenlight = new Bitmap(Properties.Resources.greenlight2, 13, 13);
            _redlight = new Bitmap(Properties.Resources.trafficlight_red, 13, 13);
            _blank = new Bitmap(1, 1);
            using (Graphics graph = Graphics.FromImage(_blank))
            {
                Rectangle ImageSize = new Rectangle(0, 0, 1, 1);
                graph.FillRectangle(Brushes.White, ImageSize);
            }

            pbControlWorksService.Image = _redlight;
            btnControlWorksService.ForeColor = Color.White;

            _logger = new Log4NetLogger(ConsoleConfiguration.LogFile);

            ConnectToService();

        }

        private void ConnectToService()
        {
            if (_controller == null)
            {
                _controller = new ClientController();
                _controller.Heartbeat += _controller_Heartbeat;
            }
            _guidId = Guid.NewGuid().ToString();

            _logger.LogInfo(String.Format("Initializing Console, Id = {0}", _guidId));

            Task.Run(() => _controller.Connect(_guidId));
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            CheckControlWorksCoilDataService();
            CheckPviStatus();
            CheckSqlServer();
            CheckHeartbeat();
        }

        private void CheckPviStatus()
        {
            if (InvokeRequired)
            {
                Action a = new Action(CheckPviStatus);
                Invoke(a);
            }
            else
            {
                if (_controller.IsOpen && _controller.IsPviConnected())
                {
                    pbPviStatus.Image = _greenlight;
                    lblPviStatus.Text = "Connected";
                    lblPviStatus.ForeColor = Color.White;
                    lblPviStatus.BackColor = Color.Green;
                }
                else
                {
                    pbPviStatus.Image = _redlight;
                    lblPviStatus.Text = "Disconnected";
                    lblPviStatus.ForeColor = Color.White;
                    lblPviStatus.BackColor = Color.Red;

                }

                if (_controller.IsOpen && _controller.IsCpuConnected())
                {
                    pbCpuStatus.Image = _greenlight;
                    lblCpuStatus.Text = "Connected";
                    lblCpuStatus.ForeColor = Color.White;
                    lblCpuStatus.BackColor = Color.Green;

                }
                else
                {
                    pbCpuStatus.Image = _redlight;
                    lblCpuStatus.Text = "Disconnected";
                    lblCpuStatus.ForeColor = Color.White;
                    lblCpuStatus.BackColor = Color.Red;
                }
            }
        }

        private void CheckHeartbeat()
        {
            if (InvokeRequired)
            {
                Action a = new Action(CheckHeartbeat);
                Invoke(a);
            }
            else
            {
                if (_heartbeatTime < DateTime.Now.AddSeconds(-5))
                {

                    txtHeartbeat.Text = "Disconnected";
                    txtHeartbeat.BackColor = Color.Red;
                    txtHeartbeat.ForeColor = Color.White;
                    pbHeartbeat.Image = _blank;

                }
                else
                {
                    txtHeartbeat.Text = "Connected";
                    txtHeartbeat.BackColor = Color.Green;
                    txtHeartbeat.ForeColor = Color.White;
                }
            }
        }

        private void CheckControlWorksCoilDataService()
        {
            if (InvokeRequired)
            {
                Action a = new Action(CheckControlWorksCoilDataService);
                Invoke(a);
            }
            else
            {
                var svc = ServiceController.GetServices().FirstOrDefault(s => s.ServiceName == "ControlWorksCoilDataService");
                if (svc == null)
                {
                    _logger.LogError(string.Format("Service with name [{0}] was not found", "ControlWorksCoilDataService"));
                }
                else if (svc.Status == ServiceControllerStatus.Running)
                {
                    pbControlWorksService.Image = _greenlight;
                    btnControlWorksService.BackColor = Color.Green;
                    btnControlWorksService.ForeColor = Color.White;
                    btnControlWorksService.Text = "Service is Running";
                }
                else
                {
                    pbControlWorksService.Image = _redlight;

                    btnControlWorksService.BackColor = Color.Red;
                    btnControlWorksService.ForeColor = Color.White;
                    btnControlWorksService.Text = "Start Service";

                }
            }
        }

        private void CheckSqlServer()
        {
            if (InvokeRequired)
            {
                Action a = new Action(CheckSqlServer);
                Invoke(a);
            }
            else
            {
                var svc = ServiceController.GetServices().FirstOrDefault(s => s.ServiceName == ConsoleConfiguration.SqlServerServiceName);
                if (svc == null)
                {
                    _logger.LogError(string.Format("Service with name [{0}] was not found", ConsoleConfiguration.SqlServerServiceName));
                }
                else if (svc.Status == ServiceControllerStatus.Running)
                {
                    pbSqlServerStatus.Image = _greenlight;
                    txtSqlServerStatus.Text = "Connected";
                    txtSqlServerStatus.ForeColor = Color.White;
                    txtSqlServerStatus.BackColor = Color.Green;
                }
                else
                {
                    pbSqlServerStatus.Image = _redlight;
                    txtSqlServerStatus.Text = "Disconnected";
                    txtSqlServerStatus.ForeColor = Color.White;
                    txtSqlServerStatus.BackColor = Color.Red;

                }
            }
        }


        private void _controller_Heartbeat(object sender, HeartbeatEventArgs e)
        {
            _heartbeatTime = e.HeartbeatTime;
            HeartbeatReceived();
        }

        private void HeartbeatReceived()
        {

            if (InvokeRequired)
            {
                Action a = new Action(HeartbeatReceived);
                Invoke(a);
            }
            else
            {
                if (_heartbeat)
                {
                    pbHeartbeat.Image = _greenlight;
                }
                else
                {
                    pbHeartbeat.Image = _blank;
                }

                _heartbeat = !_heartbeat;
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _controller.Disconnect(_guidId);
        }

        private bool StartService(string serviceName)
        {
            var svc = ServiceController.GetServices().FirstOrDefault(s => s.ServiceName == serviceName);
            if (svc == null)
            {
                _logger.LogError(string.Format("Service with name [{0}] was not found", serviceName));
            }
            else
            {
                if (svc.Status != ServiceControllerStatus.Running)
                {
                    svc.Start();
                    svc.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(10.00d));
                }
            }

            return svc.Status == ServiceControllerStatus.Running;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var gridview = sender as DataGridView;
            if (gridview != null)
            {
                if (gridview.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex == HEARTBEAT_ROW)
                {
                    ConnectToService();
                }

                if (gridview.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex == CONTROL_WORKS_SERVICE_ROW)
                {
                    StartService("ControlWorksCoilDataService");
                }

                if (gridview.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex == SQL_SERVER_SERVICE)
                {
                    StartService(ConsoleConfiguration.SqlServerServiceName);
                }
            }
        }

        private void btnControlWorksService_Click(object sender, EventArgs e)
        {
            if (StartService("ControlWorksCoilDataService"))
            {
                ConnectToService();
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tab = sender as TabControl;
            if (tab != null)
            {
                if (tab.SelectedTab.Name == "tpCoilInfo")
                {
                    dtpStartDate.Value = DateTime.Now.AddMonths(-1);
                    dtpEndDate.Value = DateTime.Now.AddDays(1);

                    SetCoilInfoGrid();
                }

                if (tab.SelectedTab.Name == "tpRmR")
                {
                    var repo = new RmRRepository();
                    dgRmR.DataSource = repo.GetRmrData();
                }
            }
        }

        private void SetCoilInfoGrid()
        {
            var repo = new CoilInfoRepository();
            var entities = repo.GetCoilInfo(dtpStartDate.Value, dtpEndDate.Value);
            dgCoilInfo.DataSource = entities;
        }

        private void btnGetCoilData_Click(object sender, EventArgs e)
        {
            SetCoilInfoGrid();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SetSensorData();
        }

        private void SetSensorData()
        {
            int id;
            if (Int32.TryParse(txtCoilId.Text, out id))
            {
                var repo = new SensorInfoRepository();
                var list = repo.GetSensorData(id);
                dgSensorInfo.DataSource = list;
            }
        }

        private void dgCoilInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var coil = dgCoilInfo.Rows[e.RowIndex].DataBoundItem as CoilInfo;

            if (coil != null)
            {
                txtCoilId.Text = coil.CoilDataId.ToString();
                tabControl1.SelectedIndex = 2;
                SetSensorData();
            }
        }
    }
}

