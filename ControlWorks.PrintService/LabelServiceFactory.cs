using ControlWorks.Utils;
using ControlWorks.Utils.Logging;
using System.IO;
using System.Xml.Serialization;

namespace ControlWorks.PrintService
{

    public static class LabelServiceFactory
    {
        public static ZplLabelService Get(int labelType, ZplLabelData data, ILogger logger)
        {
            if (labelType == 0)
            {
                var serializer = new XmlSerializer(typeof(LabelSettingsAmerican));
                var reader = new StreamReader(ConfigurationProvider.AmericanLabelSettings);

                var settings = (LabelSettingsAmerican)serializer.Deserialize(reader);

                var labelSettings = new ZplLabelAmericanService(data, logger);

                labelSettings.LabelSettings = settings;

                return labelSettings;
            }
            if (labelType == 1)
            {
                return new ZplLabelEuropeanService(data, logger);
            }

            return null;
        }
    }
}
