﻿using BR.AN.PviServices;
using ControlWorks.Utils.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWorks.PviService
{
    public static class LogPviEvent
    {
        private static ILogger _logger;
        public static ILogger Log
        {
            get
            {
                if (_logger == null)
                {
                    _logger = new Log4NetLogger();
                }
                return _logger;
            }
            set
            {
                _logger = value;
            }
        }

        public static void LogError(string message, PviEventArgs e)
        {
            try
            {
                Log.LogError(FormatMessage(message, e));
            }
            catch { }

        }
        public static void LogDebug(string message, PviEventArgs e)
        {
            try
            {
                Log.LogDebug(FormatMessage(message, e));
            }
            catch { }
        }

        public static void LogInfo(string message, PviEventArgs e)
        {
            try
            {
                Log.LogInfo(FormatMessage(message, e));
            }
            catch { }
        }

        private static string FormatMessage(string message, PviEventArgs e)
        {
            return String.Format("{0}; Action={1}, Address={2}, Error Code={3}, Error Text={4}, Name={5} ",
                message, e.Action, e.Address, e.ErrorCode, e.ErrorText, e.Name);
        }
    }
}
