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
            if (numberOfThreads != 1)
                throw new ArgumentException("We unly support one thread");

            LotteryCoupon lotteryCoupon;
            long numberOfAttempts = 0;
            do
            {
                lotteryCoupon = LotteryCouponGenerator.CreateLotteryCoupon();
                numberOfAttempts += 1;
            }
            while (!LotteryCouponChecker.Check(lotteryCoupon));
            return (lotteryCoupon, numberOfAttempts);
        }
    }
}
