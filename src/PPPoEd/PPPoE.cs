using System;
using System.IO;
using System.Net;
using System.Threading;
using DotRas;

namespace PPPoEd
{
    class PPPoE
    {
        private RasDialer dialer = new RasDialer();
        private RasConnectionWatcher watcher = new RasConnectionWatcher();
        private RasConnection connection = null;
        private bool AlwaysDial = true;

        public string Username { get; set; }
        public string Password { get; set; }
        public int ReDialTimeout { get; set; }
        

        
        public PPPoE()
        {
            //__init__
            dialer.StateChanged += OnDialerStateChanged;
            watcher.Disconnected += OnConnectionDisconnected;
            ReDialTimeout = ReDialTimeout == 0 ? 5 : ReDialTimeout;
        }

        private void OnDialerStateChanged(object sender, StateChangedEventArgs e)
        {
            Logger.Write($"State: {e.State}");
        }

        private void OnConnectionDisconnected(object sender, RasConnectionEventArgs e)
        {
            Logger.Write($"Disconnected: [{e.ConnectionInformation.EntryName}] @ {e.ConnectionInformation.Handle}");
            ReDial();
        }

        public void ReDial()
        {
            //__if_alwaysdial_set__
            //__try_redial__
            if (AlwaysDial == true)
            {
                Logger.Write($"--- ALWAYSDIAL-ACTIVED ---");
                Logger.Write("Wait: ", false);
                for (int i = ReDialTimeout; i > 0; i--)
                {
                    Logger.Write($"{i}...", false);
                    Thread.Sleep(1000);
                }
                Logger.Write("\r\n", false);
                DialUp();
            }
        }

        public void DialUp()
        {
            try
            {
                dialer.PhoneBookPath = Path.Combine(
                    AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
                    @"PPPoEd.pbk");
                dialer.EntryName = "PPPoEd";
                dialer.Credentials = new NetworkCredential(Username, Password);

                //__establish_connection__
                Logger.Write("Connecting...");
                connection = dialer.Connect();
                Logger.Write($"Connected: [{connection.EntryName}] @ {connection.Handle}");

                //__connection_watch__
                watcher.Connection = connection;
                watcher.Start();
            }

            //__dial_failed__
            catch (RasException e)
            {
                Logger.Write($"Error {e.NativeErrorCode}: {e.Message}");
                ReDial();
            }
        }

        public void Disconnect()
        {
            //__disable_alwaysdial__
            AlwaysDial = false;

            //__disconnect__
            if (connection != null)
            {
                connection.Disconnect();
            }
        }
    }
}
