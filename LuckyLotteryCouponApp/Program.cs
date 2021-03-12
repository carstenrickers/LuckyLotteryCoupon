using System;
using System.Diagnostics;

namespace LuckyLotteryCouponApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfThreads = Environment.ProcessorCount;
            var config = LuckyLotteryCouponConfigReader.Read();
            var stopwatch = new Stopwatch();

            do {
                PrintStartMessage(config);

                stopwatch.Start();

                using (var luckyLotteryCouponGeneratorFactory = new LuckyLotteryCouponGeneratorFactory(config))
                {
                    var luckyLotteryCouponGenerator = luckyLotteryCouponGeneratorFactory.Create();

                    (var lotteryCoupon, long numberOfAttempts) = luckyLotteryCouponGenerator.Generate(numberOfThreads);

                    stopwatch.Stop();

                    PrintResult(lotteryCoupon, stopwatch, numberOfAttempts, numberOfThreads, config.LuckyNumber);
                }

                numberOfThreads = AskUserForNumberOfTghreads(numberOfThreads);
            }
            while (numberOfThreads > 0);

            Console.WriteLine("Finished!");
        }

        private static void PrintStartMessage(LuckyLotteryCouponConfiguration config)
        {
            ConsoleColor oldForegroundConsoleColour = Console.ForegroundColor;
            Console.WriteLine(String.Format("Starting to generate Coupon with {0} rows of {1} number with a max number of {2}",
                config.NumberOfRows, config.NumberOfColumns, config.MaxNumber));
            Console.Write("Lucky Number: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(config.LuckyNumber);
            Console.ForegroundColor = oldForegroundConsoleColour;

        }

        private static void PrintResult(LotteryCoupon lotteryCoupon, Stopwatch stopwatch, long numberOfAttempts, int numberOfThreads, int luckyNumber)
        {
            LotteryCouponPrinter.Print(lotteryCoupon, luckyNumber);

            PrintExecutionInfo(stopwatch, numberOfAttempts, numberOfThreads);
        }

        private static void PrintExecutionInfo( Stopwatch stopwatch, long numberOfAttempts, int numberOfThreads)
        {
            long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;

            TimeSpan ts = stopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                                               ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);

            double averageTimeInNanoseconds = elapsedMilliseconds * 1000.0 / numberOfAttempts;

            Console.WriteLine(String.Format("{0} Threads - Done in {1} tries, took {2}", numberOfThreads, numberOfAttempts, elapsedTime));
            Console.WriteLine(String.Format("Average coupon time {0:F2} nanoseconds", averageTimeInNanoseconds));
        }

        private static int AskUserForNumberOfTghreads(int oldNumberOfThreads)
        {
            Console.WriteLine("Type new degree of parallelism (eg. '24') or 'new' to restart. Enter to exit.");
            string input = Console.ReadLine();
            if (input.Length == 0)
            {
                return -1;
            }

            if (input.ToLower().Equals("new"))
            {
                return oldNumberOfThreads;
            }

            try
            {
                int numberOfThreads = Int32.Parse(input);
                return numberOfThreads;
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
