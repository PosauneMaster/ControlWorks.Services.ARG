using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace ControlWorks.Services
{
    class Program
    {
        static void Main(string[] args)
        {
            const string name = "ControlWorksCoilDataServiceArg";
            const string description = "Control Works communication service for ARG";

            try
            {
                var host = HostFactory.New(configuration =>
                {
                    configuration.Service<Host>(callback =>
                    {
                        callback.ConstructUsing(s => new Host());
                        callback.WhenStarted(service => service.Start());
                        callback.WhenStopped(service => service.Stop());
                    });
                    configuration.SetDisplayName(name);
                    configuration.SetServiceName(name);
                    configuration.SetDescription(description);
                    configuration.RunAsLocalService();
                });
                host.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine("WcfCommunicationService Service fatal exception. " + ex.Message);
            }
        }
    }
}
