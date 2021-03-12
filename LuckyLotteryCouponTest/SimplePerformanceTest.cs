using LuckyLotteryCouponApp;
using System.Diagnostics;
using Xunit;

namespace LuckyLotteryCouponTest
{
    /**
     * Simple performance test.
     * The test is not very good as the execution time depends on the machine used to run the test.
     * Most often, the test should therefore be ignored.
     * But it may be used to get some idea of how the solution performs.
    **/
    public class SimplePerformanceTest
    {
        [Fact]
        public void TestPerformanceSingleThread()
        {
            var config = CreateDefaultConfiguration();
            
            var stopwatch = new Stopwatch();
            int numberOfThreads = 1;
            long totalElapsedMilliseconds = 0;
            long totalNumberOfAttempts = 0;
            int numberOfTestRuns = 10;

            for (int i = 0; i < numberOfTestRuns; i++)
            {
                stopwatch.Start();

                using (var luckyLotteryCouponGeneratorFactory = new LuckyLotteryCouponGeneratorFactory(config))
                {
                    var luckyLotteryCouponGenerator = luckyLotteryCouponGeneratorFactory.Create();

                    (var lotteryCoupon, long numberOfAttempts) = luckyLotteryCouponGenerator.Generate(numberOfThreads);

                    stopwatch.Stop();

                    long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
                    double averageTimeInNanoseconds = elapsedMilliseconds * 1000.0 / numberOfAttempts;
                    // Console.Error.WriteLine(String.Format("Test run {0}, attempts: {1}, average time {2} ns", i, numberOfAttempts, averageTimeInNanoseconds));
                    totalElapsedMilliseconds += elapsedMilliseconds;
                    totalNumberOfAttempts += numberOfAttempts;
                }
            }
            double totalAverageTimeInNanoseconds = totalElapsedMilliseconds * 1000.0 / totalNumberOfAttempts;
            Assert.True(totalAverageTimeInNanoseconds < 500.0);
            // Console.WriteLine(String.Format("{0} Test runs, attempts: {1}, average time {2} ns", numberOfTestRuns, totalNumberOfAttempts, totalAverageTimeInNanoseconds));
        }

        private static LuckyLotteryCouponConfiguration CreateDefaultConfiguration()
        {
            var config = new LuckyLotteryCouponConfiguration();
            config.LuckyNumber = 13;
            config.MaxNumber = 48;
            config.NumberOfRows = 10;
            config.NumberOfColumns = 17;
            return config;
        }
    }
}
