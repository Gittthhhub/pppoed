using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PPPoEd
{
    class Logger
    {
        public static void Write(string message, bool newline = true)
        {
            string Filename = Path.Combine(
                    AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
                    $"log_{DateTime.Now.ToString("yyyy-MM-dd")}.log");

            string newMessage = message;
            if (newline)
            {
                string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                newMessage = $"[{now}] {message}";
            }

            using (StreamWriter fs = new StreamWriter(Filename, true))
            {
                foreach (char c in newMessage)
                {
                    fs.Write(c);
                }
                if (newline)
                {
                    Console.WriteLine(newMessage);
                    fs.Write("\r\n");
                }
                else
                {
                    Console.Write(newMessage);
                }
            }
        }
    }
}
