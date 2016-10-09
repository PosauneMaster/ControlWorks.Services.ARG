using ControlWorks.PrintService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace LabelSettings
{
    public enum LabelType
    {
        American,
        European
    }


    public partial class Form1 : Form
    {

        private LabelType _labelType;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
        }

        private void LoadFile(string filename, LabelType lableType)
        {
            if (lableType == LabelType.American)
            {
                LoadFile<LabelSettingsAmerican>(filename);
            }

            if (lableType == LabelType.European)
            {

                LoadFile<LabelSettingsEuropean>(filename);
            }
        }

        private void LoadFile<T>(string filename)
        {
            var list = new BindingList<Setting>();

            var serializer = new XmlSerializer(typeof(T));
            var reader = new StreamReader(filename);

            var settings = (T)serializer.Deserialize(reader);

            foreach (var pi in settings.GetType().GetProperties())
            {

                var point = (Point)pi.GetValue(settings);

                list.Add(new Setting() { PropertyName = pi.Name, HorizontalOffset = point.X, VerticalOffset = point.Y });
            }

            this.dataGridView1.DataSource = list;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var settingList = dataGridView1.DataSource as BindingList<Setting>;

                if (_labelType == LabelType.American)
                {
                    var setting = new LabelSettingsAmerican();

                    foreach (var item in settingList)
                    {
                        var p = new Point(item.HorizontalOffset, item.VerticalOffset);
                        setting.SetProperty(item.PropertyName, $"{p.X}, {p.Y}");
                    }

                    File.WriteAllText(saveFileDialog1.FileName, setting.ToXml());
                }

                if (_labelType == LabelType.European)
                {
                    var setting = new LabelSettingsEuropean();

                    foreach (var item in settingList)
                    {
                        var p = new Point(item.HorizontalOffset, item.VerticalOffset);
                        setting.SetProperty(item.PropertyName, $"{p.X}, {p.Y}");
                    }

                    File.WriteAllText(saveFileDialog1.FileName, setting.ToXml());
                }


            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                panel1.BackgroundImage = null;
                txtZplCode.Clear();
                txtZplCode.Visible = false;

                XmlDocument doc = new XmlDocument();

                doc.Load(openFileDialog1.FileName);
                lblFilename.Text = openFileDialog1.FileName;

                if (doc.ChildNodes[1] != null)
                {
                    var name = doc.ChildNodes[1].Name;
                    LabelType labelType;
                    if (name == "LabelSettingsAmerican")
                    {
                        labelType = LabelType.American;
                    }
                    else if (name == "LabelSettingsEuropean")
                    {
                        labelType = LabelType.European;
                    }
                    else
                    {
                        return;
                    }
                    _labelType = labelType;

                    LoadFile(openFileDialog1.FileName, labelType);
                }
                
            }

        }

        private void btnNewEuropean_Click(object sender, EventArgs e)
        {
            _labelType = LabelType.European;

            var list = new BindingList<Setting>();

            var settings = new LabelSettingsEuropean();

            foreach (var pi in settings.GetType().GetProperties())
            {

                var point = (Point)pi.GetValue(settings);

                list.Add(new Setting() { PropertyName = pi.Name, HorizontalOffset = point.X, VerticalOffset = point.Y });
            }

            this.dataGridView1.DataSource = list;
        }

        private string GetAmericanZpl()
        {
            var settingList = dataGridView1.DataSource as BindingList<Setting>;

            var data = new ZplLabelData();

            data.SqYards = "12.34";
            data.LinearMeters = "23.45";
            data.GeneratedMaterialType = "B175.045.6";
            data.MaterialType = "B175.045";
            data.TolerancePlus = "0.003";
            data.ToleranceMinus = "0.002";
            data.ChangeNumber = "X80";
            data.CoilSerialNumber = "160825304801";
            data.LabInspector = "JP";
            data.Inspector = "TK";
            data.Batch = "2952";
            data.CalibrationDate = DateTime.Parse("2016-09-01T00:00:00");
            data.InspectionDate = DateTime.Parse("2016-08-31T00:00:00");
            data.LabInspectionDate = DateTime.Parse("2016-08-30T00:00:00");

            var settings = new LabelSettingsAmerican();

            foreach (var item in settingList)
            {
                var p = new Point(item.HorizontalOffset, item.VerticalOffset);
                settings.SetProperty(item.PropertyName, $"{p.X}, {p.Y}");
            }

            var service = new ZplLabelAmericanService(data, null);
            service.LabelSettings = settings;

            var label = service.GetLabel();

            return label;
        }

        private string GetEuropeanZpl()
        {
            var settingList = dataGridView1.DataSource as BindingList<Setting>;

            var data = new ZplLabelData();

            data.LinearMeters = "98.7";
            data.RmR = "RMR 2152 02";
            data.SqYards = "12.34";
            data.LinearMeters = "23.45";
            data.GeneratedMaterialType = "B175.045.6";
            data.MaterialType = "B175.045";
            data.TolerancePlus = "0.003";
            data.ToleranceMinus = "0.002";
            data.ChangeNumber = "X80";
            data.CoilSerialNumber = "160825304801";
            data.LabInspector = "JP";
            data.Inspector = "TK";
            data.Batch = "2952";
            data.CalibrationDate = DateTime.Parse("2016-09-01T00:00:00");
            data.InspectionDate = DateTime.Parse("2016-08-31T00:00:00");
            data.LabInspectionDate = DateTime.Parse("2016-08-30T00:00:00");

            var settings = new LabelSettingsEuropean();

            foreach (var item in settingList)
            {
                var p = new Point(item.HorizontalOffset, item.VerticalOffset);
                settings.SetProperty(item.PropertyName, $"{p.X}, {p.Y}");
            }

            var service = new ZplLabelEuropeanService(data, null);
            service.LabelSettings = settings;

            var label = service.GetLabel();

            return label;
        }

        private void ViewAmerican()
        {
            var label = GetAmericanZpl();
            var client = new LabelaryClient();
            var img = client.GetPng(label);

            panel1.BackgroundImage = img;
        }

        private void ViewEuropean()
        {
            var label = GetEuropeanZpl();
            var client = new LabelaryClient();
            var img = client.GetPng(label);

            panel1.BackgroundImage = img;
        }

        private void btnViewSample_Click(object sender, EventArgs e)
        {
            txtZplCode.Visible = false;
            try
            {
                if (_labelType == LabelType.American)
                {
                    ViewAmerican();
                }
                else if (_labelType == LabelType.European)
                {
                    ViewEuropean();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            txtZplCode.Visible = true;

            if (_labelType == LabelType.American)
            {
                txtZplCode.Text = GetAmericanZpl();
            }
            if (_labelType == LabelType.European)
            {
                txtZplCode.Text = GetEuropeanZpl();
            }
        }
    }

    public class Setting
    {
        public string PropertyName { get; set; }
        public int HorizontalOffset { get; set; }
        public int VerticalOffset { get; set; }
    }
}
