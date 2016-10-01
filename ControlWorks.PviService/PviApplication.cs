using ControlWorks.Utils.Logging;
using System;
using System.Windows.Forms;

namespace ControlWorks.PviService
{
    public class PviApplication
    {
        private PviContext _context;
        private ILogger _logger = new Log4NetLogger();
        private bool _isStopping;

        public event EventHandler<EventArgs> ApplicationDisconnected;

        public bool IsPviConnected { get { return _context.IsPviConnected; } }
        public bool IsCpuConnected { get { return _context.IsCpuConnected; } }

        private Timer t = new Timer();

        public void StartPvi()
        {
            _isStopping = false;
            _context = new PviContext();
            Application.Run(_context);

            Application.ApplicationExit += Application_ApplicationExit;
            Application.ThreadException += Application_ThreadException;

        }

        public void StopPvi()
        {
            _logger.LogError("Stopping PVI");
            _isStopping = true;
            Exit();
        }

        private void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            _logger.LogError("Application_ThreadException");
            _logger.LogError(e.Exception);
            Exit();
        }

        private void Exit()
        {
            _context.Dispose();
        }

        private void Application_ApplicationExit(object sender, System.EventArgs e)
        {
            if (_context != null)
            {
                _context.Dispose();
            }

            _logger.LogError("Application_ApplicationExit");
            OnApplicationExit();
        }

        protected void OnApplicationExit()
        {
            if (!_isStopping)
            {
                var temp = ApplicationDisconnected;
                if (temp != null)
                {
                    temp(this, new EventArgs());
                }
            }
        }
    }
}
