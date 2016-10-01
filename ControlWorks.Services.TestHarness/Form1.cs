using ControlWorks.Database.SqlServer;
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

namespace ControlWorks.Services.TestHarness
{
    public partial class Form1 : Form
    {
        private string coilData = "0.003;0.003;6/29/2016;37;6.58;21;19:28;06-13-16;6/29/2016;X80;1606133021;;1947;B175.082.6.21.6.21;B175.082;0;0.082;21;21;21;21;21;21;21;21;21;21;21;21;0;0;0;0;0;0;0;8.69095;0.04145327;0.04246908;0.04334816;0.04352398;0.04362166;8.69095;0.04145327;0.04246908;0.04334816;0.04352398;0.04362166;13.26593;0.04135559;0.04237141;0.04325049;0.04340677;0.04352398;16.85991;0.04145327;0.04246908;0.04334816;0.04352398;0.04364119;21.04788;0.04133606;0.04235187;0.04323095;0.04340677;0.04352398;26.24685;0.04131652;0.04235187;0.04323095;0.04340677;0.04352398;28.39784;0.04151188;0.04254723;0.04342631;0.04360212;0.04371934;32.63982;0.04129699;0.0423128;0.04319188;0.0433677;0.04348491;37.08279;0.04137513;0.04239094;0.04327002;0.04344584;0.04356305;41.19277;0.04135559;0.04237141;0.04327002;0.04342631;0.04354352;45.67775;0.04137513;0.04239094;0.04328956;0.04346538;0.04358259;48.12873;0.04135559;0.04237141;0.04327002;0.04344584;0.04356305;52.9197;0.04135559;0.04239094;0.04328956;0.04346538;0.04358259;57.63567;0.04149234;0.04252769;0.04342631;0.04362166;0.04373887;62.33364;0.04151188;0.04254723;0.04344584;0.04364119;0.04373887;64.64963;0.04139467;0.04243001;0.04332863;0.04348491;0.04362166;69.4706;0.04137513;0.04241048;0.04330909;0.04346538;0.04360212;74.25858;0.04135559;0.04239094;0.04328956;0.04346538;0.04358259;76.59856;0.04147281;0.04250816;0.04340677;0.04358259;0.0436998;81.38953;0.04143374;0.04246908;0.0433677;0.04356305;0.04366073;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //BatchDetailsMapper map = new BatchDetailsMapper();
            //map.MapFromCsv(Properties.Resources.TMSdata);
        }

        private void btnTestSetProperty_Click(object sender, EventArgs e)
        {
            var coilData = new CoilDataInternal();
            coilData.SetProperty(nameof(coilData.MaterialThickness), txtTestSetProperty.Text);
            coilData.SetProperty(nameof(coilData.BatchNumber), "ABCD-001");
            coilData.SetProperty(nameof(coilData.RollSnNumber), null);
            coilData.SetProperty(nameof(coilData.BatchRunTimestamp), "2016-07-11");
            coilData.SetProperty(nameof(coilData.CoilNumber), null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();

            string[] coilDataArray = coilData.Split(new char[] { ';' });
            foreach (var s in coilDataArray)
            {
                sb.AppendLine(s);
            }

            File.WriteAllText(@"D:\Control Works\Testing\CoilData.txt", sb.ToString());

        }
    }
}
