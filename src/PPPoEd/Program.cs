using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using PPPoEd;
using Topshelf;

namespace PPPoEDaemon
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                HostFactory.Run(x =>
                {
                    x.Service<Service>(s =>
                    {
                        s.ConstructUsing(name => new Service());
                        s.WhenStarted(tc => tc.Start());
                        s.WhenStopped(tc => tc.Stop());
                    });

                    x.RunAsLocalSystem();
                    x.SetDescription("Manage PPPoE session dial-up, re-dial, session daemon etc.");
                    x.SetDisplayName("PPPoE Daemon");
                    x.SetServiceName("pppoed");
                });
            }
            catch (Exception ex)
            {
                Logger.Write(ex.ToString());
                Environment.Exit(255);
            }
        }
    }

    public class Service
    {
        private PPPoE pppoe = new PPPoE();
        private string jsonfile = Path.Combine(
                    AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
                    @"config.json");

        public void Start()
        {
            try
            {
                var conf = new ConfigurationBuilder()
                    .AddJsonFile(jsonfile, false, true)
                    .Build();

                pppoe.Username = conf.GetSection("Username").Value;
                pppoe.Password = conf.GetSection("Password").Value;
                pppoe.ReDialTimeout = int.Parse(conf.GetSection("ReDialTimeout").Value);
                pppoe.DialUp();
            }
            catch (Exception ex)
            {
                Logger.Write(ex.ToString());
                Environment.Exit(255);
            }
        }

        public void Stop()
        {
            pppoe.Disconnect();
        }
    }
}
