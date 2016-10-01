using ControlWorks.Database.SqlServer;
using ControlWorks.PviService;
using ControlWorks.Utils.Logging;
using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace PviTestHarness
{
    public partial class Form1 : Form
    {
        private ILogger _logger;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var pviService = new PviService(_logger);
            pviService.ConnectPVIService();
        }

        private void btnTestCoilInfo_Click(object sender, EventArgs e)
        {
            CoilInfo coildata;

            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    _logger.LogInfo(String.Format("Loading file {0}", openFileDialog1.FileName));
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(CoilInfo));
                    using (var fs = new FileStream(openFileDialog1.FileName, FileMode.Open))
                    {
                        using (var reader = XmlReader.Create(fs))
                        {
                            coildata = xmlSerializer.Deserialize(reader) as CoilInfo;
                        }
                    }

                    if (coildata != null)
                    {
                        var processor = new CoilInfoProcessor(_logger);
                        processor.ProcessAsync(coildata);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _logger = new Log4NetLogger();
        }
    }
}
