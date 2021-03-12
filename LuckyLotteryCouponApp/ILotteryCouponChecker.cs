using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyLotteryCouponApp
{
    public interface ILotteryCouponChecker
    {
        public bool Check(LotteryCoupon lotteryCoupon);
    }
}
