using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyLotteryCouponApp
{
    class LuckyLotteryCouponChecker : ILotteryCouponChecker
    {
        private int LuckyNumber;
        public LuckyLotteryCouponChecker(int luckyNumber)
        {
            LuckyNumber = luckyNumber;
        }
        public bool Check(LotteryCoupon lotteryCoupon)
        {
            if (lotteryCoupon.Rows.Count < 1)
                return false;  // We choose to consider an empty lottery coupon as unlucky

            foreach (var row in lotteryCoupon.Rows)
            {
                if (!row.Contains(LuckyNumber))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
