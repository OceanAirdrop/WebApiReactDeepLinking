using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebAPIReactDeepLinking.WebServer;

namespace WebAPIReactDeepLinking
{
    class Program
    {
        static IDisposable m_webServer = null;

        static string scheme = "http";
        static string hostName = "127.0.0.1"; // Environment.MachineName;
        static int portNum = 9100;

        static string url = $"{scheme}://{hostName}:{portNum}";

        static void Main(string[] args)
        {
            SetupWebServer();

            // This works
            Process.Start($"{url}/www");

            // linking to this page does not work!
            Process.Start($"{url}/www/page1");


            Console.ReadLine();
        }

        private static void SetupWebServer()
        {
            try
            {
                m_webServer = WebApp.Start<Startup>(url);

                Console.WriteLine($"Web Server Started on: {url}", MethodBase.GetCurrentMethod().Name);
                Console.WriteLine($"Web Interface on: {url}/www", MethodBase.GetCurrentMethod().Name);
                Console.WriteLine($"API Interface on: {url}/api", MethodBase.GetCurrentMethod().Name);
                Console.WriteLine($"Swagger Web Interface on: {url}/swagger/ui/index", MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    if (ex.InnerException.Message.Contains("Failed to listen on prefix") && ex.InnerException.Message.Contains("because it conflicts with an existing registration on the machine."))
                    {
                        var msg = new StringBuilder();
                        msg.AppendLine("");
                        msg.AppendLine("If you are running as HTTPS then check to make sure you have registered the CORRECT http scheme.  So it should be:");
                        msg.AppendLine("");
                        msg.AppendLine($"netsh http add urlacl url=https://+:{portNum}/ user=everyone (notice the s) and not netsh http add urlacl url=http://+:{portNum}/ user=everyone");
                        msg.AppendLine("");
                        msg.AppendLine("In this instance the correct command is:");
                        msg.AppendLine("");
                        msg.AppendLine($"netsh http add urlacl url = {scheme}://+:{portNum}/ user=everyone");
                        msg.AppendLine("");
                        msg.AppendLine("You can check the registartion for that port buy running this command: 'netsh http show urlacl'.");
                        msg.AppendLine("");
                        msg.AppendLine("If its not the scheme that is the problem (http versus https), check to make sure app is not already running on that port.  open cmd and type: 'netstat - aon'");

                        Console.WriteLine(msg.ToString());
                    }

                    if (ex.InnerException.Message == "Access is denied")
                    {
                        var msg = new StringBuilder();
                        msg.AppendLine("");
                        msg.AppendLine("If you are getting an access denied error, make sure you are running Visual Studion in ADMINISTRATOR mode.");
                        msg.AppendLine("Also, if you want to access this service from another machine you need to open a port on the firewall. ");
                        msg.AppendLine("To do that, you need to run the following cmds:");
                        msg.AppendLine($"netsh advfirewall firewall add rule name='SVC_NAME_HERE_{portNum}' dir=in action=allow protocol=TCP localport = {portNum}");
                        msg.AppendLine($"netsh advfirewall firewall add rule name='SVC_NAME_HERE_{portNum}' dir =out action = allow protocol = TCP localport = {portNum}");

                        Console.WriteLine(ex.InnerException.ToString(), MethodBase.GetCurrentMethod().Name);
                    }

                    if (ex.InnerException.Message == "The parameter is incorrect")
                    {
                        var msg = new StringBuilder();
                        msg.AppendLine("");
                        msg.AppendLine("Open command prompt as admin and enter below line:");
                        msg.AppendLine("");
                        msg.AppendLine($"netsh http add urlacl url = {scheme}://+:{portNum}/ user=everyone");

                        Console.WriteLine(ex.InnerException.ToString(), MethodBase.GetCurrentMethod().Name);
                    }
                }

                return;
            }

        }
    }
}
