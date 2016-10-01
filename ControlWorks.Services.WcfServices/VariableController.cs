using ControlWorks.Utils.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ControlWorks.Services.WcfServices
{
    public class VariableController
    {
        private ILogger _logger;

        public VariableController(ILogger logger)
        {
            _logger = logger;
        }

        public void CreateVariableConfiguration(int machineId, VariableRepository repository)
        {
            string baseFileName = String.Format("Variable_Machine_{0}.xml", machineId);
            string fullPath = Path.Combine(ServicesConfiguration.BaseConfigurationDirectory, baseFileName);

            _logger.LogDebug(String.Format("VariableController:CreateVariableConfiguration; machineId={0}; fileName={1}", machineId, baseFileName));

            using (var stream = File.Create(fullPath))
            {
                XmlSerializer serilaizer = new XmlSerializer(typeof(VariableRepository));
                serilaizer.Serialize(stream, repository);
            }
        }
    }
}
