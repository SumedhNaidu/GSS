using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RealTimeExample_of_ConcurrentTasks
{
    internal class Program
    {
        static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(3);
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            Console.WriteLine($"Main Thread Started");
            List<CreditCard> creditCards = CreditCard.GenerateCreditCards(15);
            Console.WriteLine($"Credit Card Generated : {creditCards.Count}");
            ProcessCreditCards(creditCards);
            Console.WriteLine($"Main Thread Completed");
            Console.ReadKey();
        }
        public static async void ProcessCreditCards(List<CreditCard> creditCards)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var tasks = new List<Task<string>>();
            tasks = creditCards.Select(async card =>
            {
                await semaphoreSlim.WaitAsync();
                try
                {
                    return await ProcessCard(card);
                }
                finally
                {
                    semaphoreSlim.Release();
                }
            }).ToList();
            var Responses = await Task.WhenAll(tasks);
            List<CreditCardResponse> creditCardResponses = new List<CreditCardResponse>();
            foreach (var response in Responses)
            {
                CreditCardResponse creditCardResponse = JsonConvert.DeserializeObject<CreditCardResponse>(response);
                creditCardResponses.Add(creditCardResponse);
            }
            Console.WriteLine("\n Approved Credit Cards");
            foreach(var item in creditCardResponses.Where(card => card.IsProcessed == true))
            {
                Console.WriteLine($"Card Number: {item.CardNumber}, Name: {item.Name}");
            }
            Console.WriteLine("\nRejected Credit Cards");
            foreach (var item in creditCardResponses.Where(card => card.IsProcessed == false))
            {
                Console.WriteLine($"Card Number: {item.CardNumber}, Name: {item.Name}");
            }
        }
        public static async Task<string>ProcessCard(CreditCard creditCard)
        {
            await Task.Delay(1000);
            var creditCardResponse = new CreditCardResponse
            {
                CardNumber = creditCard.CardNumber,
                Name = creditCard.Name,
                IsProcessed = creditCard.CardNumber % 2 == 0 ? true : false

            };
            string jsonString = JsonConvert.SerializeObject(creditCardResponse);
            return jsonString;
        }
    }
    public class CreditCard
    {
        public long CardNumber { get; set; }
        public string Name { get; set; }

        public static List<CreditCard> GenerateCreditCards(int number)
        {
            List<CreditCard> creditCards = new List<CreditCard>();
            for (int i = 0; i < number; i++)
            {
                CreditCard card = new CreditCard()
                {
                    CardNumber = 10000000 + i,
                    Name = "CreditCard-" + i
                };
                creditCards.Add(card);
            }
            return creditCards;
        }
    }
        public class CreditCardResponse
        {
            public long CardNumber { get; set; }
            public string Name { get; set; }
            public bool IsProcessed { get; set; }
        }
    }

