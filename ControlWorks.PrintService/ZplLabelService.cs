using ControlWorks.Utils;
using ControlWorks.Utils.Logging;
using System;
using ZplLabels.ZPL;

namespace ControlWorks.PrintService
{
    public abstract class ZplLabelService
    {
        private const string DEFAULT_PRINTER_NAME = "ZDesigner GC420d (EPL)";

        public ZplLabelData LabelData { get; set; }
        public string PrinterName { get; set; }
        protected ILogger Logger { get; set; }

        protected virtual void Initialize(ZplLabelData data, ILogger logger)
        {
            Logger = logger;
            LabelData = data;
            SetPrinterName();

        }

        private void SetPrinterName()
        {
            PrinterName = String.IsNullOrEmpty(ConfigurationProvider.ZplPrinterName) ? DEFAULT_PRINTER_NAME : ConfigurationProvider.ZplPrinterName;
        }

        public virtual void SendToPrinter()
        {
            try
            {
                if (ConfigurationProvider.LogZplCodes)
                {
                    Logger.LogDebug(GetLabel());
                }

                PrintNativeMethods.SendStringToPrinter(PrinterName, GetLabel());
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public abstract string GetLabel();
    }
}
