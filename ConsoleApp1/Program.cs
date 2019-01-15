using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace ConsoleApp1
{
    class Program
    {
        const string ServiceBusConnectionString = "Endpoint=sb://vinh-service-bus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=lNPoL/5aB3x2vs1XpZhzo4mmTQXT+o3m78j6bK7SoLc=";
        const string QueueName = "Vinh";
        static IQueueClient queueClient;
        static void Main(string[] args)
        {
            //get 
            MainAsync().GetAwaiter().GetResult();
        }

        private static async Task MainAsync()
        {
            const int numberOfMessages = 10;
            queueClient = new QueueClient(ServiceBusConnectionString, QueueName);

            Console.WriteLine("======================================================");
            Console.WriteLine("Press ENTER key to exit after sending all the messages.");
            Console.WriteLine("======================================================");

            // Send messages.
            await SendMessagesAsync(numberOfMessages);

            Console.ReadKey();

            await queueClient.CloseAsync();
        }

        private static async Task SendMessagesAsync(int numberOfMessages)
        {
            try
            {
                for (int i = 0; i < numberOfMessages; i++) {
                    string messageBody = $"Message {i}";
                    var message = new Message(Encoding.UTF8.GetBytes(messageBody));
                    Console.WriteLine($"Sending message : {messageBody}");
                   await queueClient.SendAsync(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{DateTime.Now} :: Exception: {ex.Message}");
            }

        }

        private static void sortData(int[] data, int low, int high)
        {
            if (low < high)
            {
                int pi = partition(data, low, high);
                sortData(data, low, pi - 1);
                sortData(data, pi + 1, high);
            }
        }

        private static int partition(int[] data, int low, int high)
        {
            int pivot = data[high];
            int smaller = low - 1;

            for (int i = low; i < high; i++)
            {
                if (data[i] < pivot)
                {
                    smaller++;
                    swap(data, smaller, i);
                }
            }
            swap(data, smaller + 1, high);
            return smaller + 1;
        }

        private static void swap(int[] data, int smaller, int i)
        {
            int temp = data[i];
            data[i] = data[smaller];
            data[smaller] = temp;
        }
    }
}
