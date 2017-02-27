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

                var labelService = new ZplLabelAmericanService(data, logger);

                labelService.LabelSettings = GetSettings<LabelSettingsAmerican>(ConfigurationProvider.AmericanLabelSettings);

                return labelService;
            }
            if (labelType == 1)
            {
                var labelService = new ZplLabelEuropeanService(data, logger);

                labelService.LabelSettings = GetSettings<LabelSettingsEuropean>(ConfigurationProvider.EuropeanLabelSettings);

                return labelService;
            }

            return null;
        }

        private static T GetSettings<T>(string path)
        {
            var serializer = new XmlSerializer(typeof(T));
            var reader = new StreamReader(path);

            var settings = (T)serializer.Deserialize(reader);

            return settings;
        }
    }
}
