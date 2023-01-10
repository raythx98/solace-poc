using System;
using System.Text;
using MessagingClient;

namespace SolacePOC
{
    class Subscriber
    {
        string topic { get; }

        public Subscriber(string topic)
        {
            this.topic = topic;
        }
        public void Subscribe()
        {
            Consumer consumer = new Consumer();
            // For demo purposes only, DO NOT push connection details to repo
            consumer.createConnection("tcps://mr-connection-x7dzv7fkvnf.messaging.solace.cloud:55443", "solace-poc", "solace-cloud-client", "avo7hoqan629ojc60esj6jehvv");
            consumer.subscribe(topic);
            // int messagesReceived = 0;
            while (true)
            {
                // messagesReceived += 1;
                byte[][] binaryMessages = consumer.Consume(); // insert topic here
                foreach (byte[] binaryMessage in binaryMessages)
                {
                    Console.WriteLine("Consumed message content: {0}", Encoding.ASCII.GetString(binaryMessage));
                }
            }
            
            // TODO: intercept SIGINT, cleanup and exit
        }
    }
}