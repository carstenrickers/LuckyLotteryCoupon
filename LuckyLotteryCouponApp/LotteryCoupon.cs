using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyLotteryCouponApp
{
    public class LotteryCoupon
    {
        public LotteryCoupon(List<List<int>> rows)
        {
            Rows = rows; // It will be more safe to use a copy of the rows parameter
        }

        public List<List<int>> Rows { get; }
    }
}
