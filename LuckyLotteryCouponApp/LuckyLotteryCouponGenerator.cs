using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LuckyLotteryCouponApp
{
    public class LuckyLotteryCouponGenerator : ILuckyLotteryCouponGenerator
    {

        ILotteryCouponGenerator LotteryCouponGenerator;
        ILotteryCouponChecker LotteryCouponChecker;

        public LuckyLotteryCouponGenerator(ILotteryCouponGenerator lotteryCouponGenerator,
            ILotteryCouponChecker lotteryCouponChecker)
        {
            LotteryCouponGenerator = lotteryCouponGenerator;
            LotteryCouponChecker = lotteryCouponChecker;
        }

        public (LotteryCoupon, long) Generate(int numberOfThreads)
        {
            if (numberOfThreads < 1)
                throw new ArgumentException("Illegal number of thread");

            if (numberOfThreads == 1)
                return GenerateUsingSingleThread();
            else
                return GenerateUsingMultipleThread(numberOfThreads);
        }

        private (LotteryCoupon, long) GenerateUsingSingleThread()
        {
            /* Just use the current thread to generate a lucky lottery coupon */
            var lotteryCoupon = LotteryCouponGenerator.CreateEmptyLotteryCoupon();
            long numberOfAttempts = 0;
            do
            {
                LotteryCouponGenerator.RefillLotteryCoupon(lotteryCoupon);
                numberOfAttempts += 1;
            }
            while (!LotteryCouponChecker.Check(lotteryCoupon));
            return (lotteryCoupon, numberOfAttempts);
        }

        private (LotteryCoupon, long) GenerateUsingMultipleThread(int numberOfThreads)
        {
            /* Create some threads and let each thread look for a lucky lottery coupon.
               Share a collector helper object between the threads. The collector object is used to collect
               the first found lucky lottery coupon and the total number of attempts.
               Each thread will use the collector to check if another thread already have found a
               lucky lottery coupon. This is used to stop the threads in a nice way.
               We may loose some work if a thread have just started generating a new lottery coupon when
               another thread find a lucky one. The number of attempts is assumed to be so high that this
               extra works doesn't matter.
            */
            var collector = new CollectLotteryCoupon();
            var threads = new Thread[numberOfThreads];
            for (int i = 0; i < numberOfThreads; i++)
            {
                // var singleThreadGenerator = new SingleThreadLuckyLotteryCouponGenerator(LotteryCouponGenerator, LotteryCouponChecker, collectWork);
                // var thread = new Thread(new ThreadStart(singleThreadGenerator.Generate));
                var th = new Thread(() =>
                {
                    var lotteryCoupon = LotteryCouponGenerator.CreateEmptyLotteryCoupon();
                    long numberOfAttempts = 0;
                    do
                    {
                        if (collector.GetLuckyLotteryCoupon() != null)
                        {
                            // Someone else have found a lucky lottery coupon.
                            collector.IncrementNumberOfAttempts(numberOfAttempts);
                            return;
                        }
                        LotteryCouponGenerator.RefillLotteryCoupon(lotteryCoupon);
                        numberOfAttempts += 1;
                    }
                    while (!LotteryCouponChecker.Check(lotteryCoupon));
                    collector.SetLuckyLotteryCouponIfNull(lotteryCoupon);
                    collector.IncrementNumberOfAttempts(numberOfAttempts);
                });
                threads[i] = th;
                th.Start();
            }
            for (int i = 0; i < numberOfThreads; i++)
            {
                threads[i].Join();
            }
            return (collector.GetLuckyLotteryCoupon(), collector.GetNumberOfAttempts());
        }

        private class CollectLotteryCoupon
        {
            private long NumberOfAttempts = 0;
            private LotteryCoupon LuckyLotteryCoupon = null;

            public LotteryCoupon GetLuckyLotteryCoupon()
            {
                lock (this)
                {
                    return LuckyLotteryCoupon;
                }
            }

            public void SetLuckyLotteryCouponIfNull(LotteryCoupon lotteryCoupon)
            {
                lock (this)
                {
                    if (LuckyLotteryCoupon == null)
                        LuckyLotteryCoupon = lotteryCoupon;
                }
            }

            public long GetNumberOfAttempts()
            {
                lock (this)
                {
                    return NumberOfAttempts;
                }
            }

            public void IncrementNumberOfAttempts(long value)
            {
                lock (this)
                {
                    NumberOfAttempts += value;
                }
            }
        }
    }
}
