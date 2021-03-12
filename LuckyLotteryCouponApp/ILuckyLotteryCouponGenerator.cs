using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyLotteryCouponApp
{
    public interface ILuckyLotteryCouponGenerator
    {
        public (LotteryCoupon, long) Generate(int numberOfThreads);
    }
}
