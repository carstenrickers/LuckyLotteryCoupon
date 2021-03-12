using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyLotteryCouponApp
{
    public class LuckyLotteryCouponConfiguration
    {
        public int LuckyNumber { get; set; }
        public int MaxNumber { get; set; }
        public int NumberOfRows { get; set; }
        public int NumberOfColumns { get; set; }
        public RandomNumberGeneratorTypeEnum RandomGenerator { set; get;  }
    }
}
