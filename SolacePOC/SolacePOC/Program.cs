// See https://aka.ms/new-console-template for more information

using System;
using static MessagingClient.Publisher;

// using SolacePOC;
namespace SolacePOC{
    class Program
    {
        static void Main(string[] args)
        {
            Random rdn = new Random();
            string[] countries = { "singapore", "australia" };
            for (int i = 0; i < 100; i++)
            {
                string message = rdn.Next(100000, 1000000).ToString();
                string country = countries[rdn.Next(2)%2];
                string carplate = String.Format("{0}{1}{2}{3}",
                    Convert.ToChar('A'+rdn.Next(25)), 
                    Convert.ToChar('A'+rdn.Next(25)), 
                    rdn.Next(1000,10000), 
                    Convert.ToChar('A'+rdn.Next(25)));
                string userid = rdn.Next(100000, 1000000).ToString();
                string topic = String.Format("getgo/{0}/booking/{1}/{2}",
                    country, carplate, userid);
                // Console.WriteLine(topic + message);
                Publish(topic, message);
            }
            
        }
    }

}
