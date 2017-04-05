using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlWorks.Services
{
    public static class NativeMethods
    {
        private static uint executionState;

        // Import SetThreadExecutionState Win32 API and necessary flags
        [DllImport("kernel32.dll")]
        private static extern uint SetThreadExecutionState(uint esFlags);
        private const uint ES_CONTINUOUS = 0x80000000;
        private const uint ES_SYSTEM_REQUIRED = 0x00000001;

        public static uint SetExecutionStateToAwake()
        {
            executionState = SetThreadExecutionState(ES_CONTINUOUS | ES_SYSTEM_REQUIRED);
            return executionState;
        }

        public static void RestoreExecutionState()
        {
            SetThreadExecutionState(executionState);
        }


    }
}
