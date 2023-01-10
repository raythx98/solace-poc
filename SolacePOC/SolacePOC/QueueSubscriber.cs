using System;
using System.Text;
using MessagingClient;

namespace SolacePOC
{
    class QueueSubscriber
    {
        string queue { get; }

        public QueueSubscriber(string queue)
        {
            this.queue = queue;
        }
        public void Subscribe()
        {
            QueueConsumer consumer = new QueueConsumer();
            consumer.createConnection("tcps://mr-connection-x7dzv7fkvnf.messaging.solace.cloud:55443", "solace-poc", "solace-cloud-client", "avo7hoqan629ojc60esj6jehvv");
            consumer.subscribe(queue);
            consumer.startListening();
            // int messagesReceived = 0;
            while (true)
            {
                // messagesReceived += 1;
                byte[][] binaryMessages = consumer.Consume(); // insert queue here
                foreach (byte[] binaryMessage in binaryMessages) 
                {
                    Console.WriteLine("Consumed message content: {0}", Encoding.ASCII.GetString(binaryMessage));
                }
            }
            // TODO: intercept SIGINT, cleanup and exit
        }
    }
}