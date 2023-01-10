using System;

namespace SolacePOC{
    class Program
    {
        private static string usage =
            "Usage: SolacePOC {type} \n" +
            "type: \n\t" +
                "singlesubscriber\n\t" +
                "sharedsubscriber\n\t" +
                "queuesubscriber {queueName}\n\t" +
                "publisher {numMessages}";
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine(usage);
                Environment.Exit(1);
            }
            switch(args[0].ToLower()) 
            {
                case "singlesubscriber":
                    new Subscriber("getgo/*/booking/>").Subscribe();
                    break;
                case "sharedsubscriber":
                    new Subscriber("#share/backend/getgo/*/booking/>").Subscribe();
                    break;
                case "queuesubscriber":
                    if (args.Length < 2)
                    {
                        Console.WriteLine(usage);
                        Environment.Exit(1);
                        break;
                    }
                    new QueueSubscriber(args[1]).Subscribe();
                    break;
                case "publisher":
                    if (args.Length < 2)
                    {
                        Console.WriteLine(usage);
                        Environment.Exit(1);
                        break;
                    }
                    if (Int32.TryParse(args[1], out int j))
                    {
                        Publisher.Publish(j);
                    }
                    else
                    {
                        Console.WriteLine(usage);
                    }
                    break;
                default:
                    Console.WriteLine(usage);
                    Environment.Exit(1);
                    break;
            }
        }
    }

}
