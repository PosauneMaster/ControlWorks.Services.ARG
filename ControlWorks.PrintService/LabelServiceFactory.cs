using ControlWorks.Utils.Logging;

namespace ControlWorks.PrintService
{

    public static class LabelServiceFactory
    {
        public static ZplLabelService Get(int labelType, ZplLabelData data, ILogger logger)
        {
            if (labelType == 0)
            {
                return new ZplLabelAmericanService(data, logger);
            }
            if (labelType == 1)
            {
                return new ZplLabelEuropeanService(data, logger);
            }

            return null;
        }
    }
}
