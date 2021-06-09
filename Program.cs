using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace random
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = "0";
            int count = 0;
            int total = 0;
            int currentNumber = 0;
            
            while(input != "-1")
            {
                Console.WriteLine("Last number was {0}", currentNumber);
                Console.WriteLine("Please enter the next score");
                Console.WriteLine("Current amount of entries {0}", count);
                Console.WriteLine("Please enter -1 once you are ready to calculate the average.");

                input = Console.ReadLine();
                if(input.Equals("-1"))
                {
                    Console.WriteLine(".........................");
                // Calculate average
                    double average = (double)total / (double)count;
                    Console.WriteLine("The average score of your students is {0}", average);
                }
                if(int.TryParse(input, out currentNumber) && currentNumber > 0 && currentNumber < 21)
                {
                    // total = total + currentNumber
                    total += currentNumber;
                }
                else
                {
                    if(!(input.Equals(-1)))
                    {
                        Console.WriteLine("Please enter a value between 1 and 20");
                    }
                    continue;
                }
                count++;
            }
            
            
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
