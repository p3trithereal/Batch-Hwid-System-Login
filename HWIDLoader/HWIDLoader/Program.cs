using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HWIDLoader
{
    class Program
    {
        public static string HWID;
        public static string HWID2;
        public static string IP;
        public static string IP2;

        static void Main(string[] args)
        {
            string ip = Program.GetIP();

            HWID2 = "your HWID is :" + System.Security.Principal.WindowsIdentity.GetCurrent().User.Value;
            HWID = "set YoursHWID=" + System.Security.Principal.WindowsIdentity.GetCurrent().User.Value;
            IP2 = "your IP is :" + ip;
            IP = "set YoursIP=" + ip;


            StreamWriter yours = new StreamWriter("YourHWID.bat");
            yours.Write(HWID);
            yours.Close();

            StreamWriter display = new StreamWriter("YourHWIDx.txt");
            display.Write(HWID2);
            display.Close();

            WebClient hwid = new WebClient();
            string text = ("C:\\Windows\\debug\\HWID.bat");                 
            hwid.DownloadFile("", text);//here your HWID allowed list
            Process Download = new Process();
            Download.Close();

            WebClient ipcheck = new WebClient();
            string ipfile = ("C:\\Windows\\debug\\IP.bat");
            ipcheck.DownloadFile("", ipfile);//here your IP allowed list
            Process ipDownload = new Process();
            ipDownload.Close();

            
            StreamWriter displayip = new StreamWriter("YourIPx.txt");
            displayip.Write(IP2);
            displayip.Close();

            
            StreamWriter yoursip = new StreamWriter("YourIP.bat");
            yoursip.Write(IP);
            yoursip.Close();



        }

        private static string GetIP()
        {
            string result = string.Empty;
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    Task<HttpResponseMessage> async = httpClient.GetAsync("https://ip4.seeip.org");//takes your ip
                    Task<string> task = async.Result.Content.ReadAsStringAsync();
                    result = task.Result;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return result;
        }
    }
}