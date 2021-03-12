using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyLotteryCouponApp
{
    public interface ILotteryCouponGenerator
    {
        public LotteryCoupon CreateLotteryCoupon();
    }
}
