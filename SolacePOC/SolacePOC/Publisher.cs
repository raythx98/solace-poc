using System;
using MessagingClient;
using static MessagingClient.Producer;

namespace SolacePOC
{
    class Publisher
    {
        public static void Publish(int numMessages)
        {
            Producer producer = new Producer();
            producer.createConnection("tcps://mr-connection-x7dzv7fkvnf.messaging.solace.cloud:55443", "solace-poc", "solace-cloud-client", "avo7hoqan629ojc60esj6jehvv");
            
            Random rdn = new Random();
            string[] countries = { "singapore", "australia" };
            for (int i = 0; i < numMessages; i++)
            {
                string message = rdn.Next(100000, 1000000).ToString();
                string country = countries[rdn.Next(2) % 2];
                string carplate = String.Format("{0}{1}{2}{3}",
                    Convert.ToChar('A' + rdn.Next(25)),
                    Convert.ToChar('A' + rdn.Next(25)),
                    rdn.Next(1000, 10000),
                    Convert.ToChar('A' + rdn.Next(25)));
                string userid = rdn.Next(100000, 1000000).ToString();
                string topic = String.Format("getgo/{0}/booking/{1}/{2}",
                    country, carplate, userid);
                // Console.WriteLine(topic + message);
                // Produce(topic, message);
                producer.Produce(topic, i.ToString());
            }
            producer.closeConnection();
        }
    }
}