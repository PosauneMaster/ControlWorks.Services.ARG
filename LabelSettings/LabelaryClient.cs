using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LabelSettings
{
    public class LabelaryClient
    {
        public Bitmap GetPng(string label)
        {
            byte[] zpl = Encoding.UTF8.GetBytes(label);

            // adjust print density (8dpmm), label width (4 inches), label height (6 inches), and label index (0) as necessary
            var request = (HttpWebRequest)WebRequest.Create("http://api.labelary.com/v1/printers/12dpmm/labels/4x6/0/");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = zpl.Length;

            var requestStream = request.GetRequestStream();
            requestStream.Write(zpl, 0, zpl.Length);
            requestStream.Close();

            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                var responseStream = response.GetResponseStream();

                var img = new Bitmap(responseStream);

                responseStream.Close();
                return img;

            }
            catch (WebException e)
            {
                Console.WriteLine("Error: {0}", e.Status);
            }

            return null;
        }
    }
}
