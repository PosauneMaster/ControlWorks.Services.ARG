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

                var labelSettings = new ZplLabelAmericanService(data, logger);

                labelSettings.LabelSettings = GetSettings<LabelSettingsAmerican>();

                return labelSettings;
            }
            if (labelType == 1)
            {
                var labelSettings = new ZplLabelEuropeanService(data, logger);

                labelSettings.LabelSettings = GetSettings<LabelSettingsEuropean>();

                return labelSettings;
            }

            return null;
        }

        private static T GetSettings<T>()
        {
            var serializer = new XmlSerializer(typeof(T));
            var reader = new StreamReader(ConfigurationProvider.AmericanLabelSettings);

            var settings = (T)serializer.Deserialize(reader);

            return settings;
        }
    }
}
