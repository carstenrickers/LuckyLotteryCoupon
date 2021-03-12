using LuckyLotteryCouponApp;
using System.Collections.Generic;
using Xunit;

namespace LuckyLotteryCouponTest
{
    public class LuckyLottertCouponCheckerTest
    {
        [Fact]
        public void TestLuckyLotteryCouponCheckerReturnsTrueOnLuckyCoupon()
        {
            var luckyLotteryCouponChecker = new LuckyLotteryCouponChecker(13);
            var lotteryCoupon = CreateLuckyCoupon();

            bool result = luckyLotteryCouponChecker.Check(lotteryCoupon);

            Assert.True(result);
        }

        [Fact]
        public void TestLuckyLotteryCouponCheckerReturnsFalseOnUnluckyCoupon()
        {
            var luckyLotteryCouponChecker = new LuckyLotteryCouponChecker(13);
            var lotteryCoupon = CreateUnluckyCoupon();

            bool result = luckyLotteryCouponChecker.Check(lotteryCoupon);

            Assert.False(result);
        }

        private static LotteryCoupon CreateLuckyCoupon()
        {
            var rows = new List<List<int>> {
                new List<int> { 5, 12, 13, 25, 27, 32, 37 },
                new List<int> { 4, 5, 8, 10, 13, 22, 23 },
                new List<int> { 2, 12, 13, 24, 33, 35, 39 },
                new List<int> { 1, 13, 14, 16, 18, 24, 26 },
                new List<int> { 2, 5, 7, 12, 13, 15, 18 },
                new List<int> { 13, 21, 22, 24, 27, 38, 39 },
                new List<int> { 10, 12, 13, 14, 16, 33, 36 },
                new List<int> { 11, 12, 13, 18, 20, 22, 40 },
                new List<int> { 13, 19, 20, 21, 30, 33, 35 },
                new List<int> { 3, 13, 14, 22, 24, 28, 33 },
             };

            return new LotteryCoupon(rows);
        }

        private static LotteryCoupon CreateUnluckyCoupon()
        {
            var rows = new List<List<int>> {
                new List<int> { 1, 1, 1, 1, 1, 1, 1},
                new List<int> { 1, 1, 1, 1, 1, 1, 1},
                new List<int> { 1, 1, 1, 1, 1, 1, 1},
                new List<int> { 1, 1, 1, 1, 1, 1, 1},
                new List<int> { 1, 1, 1, 1, 1, 1, 1},
                new List<int> { 1, 1, 1, 1, 1, 1, 1},
                new List<int> { 1, 1, 1, 1, 1, 1, 1},
                new List<int> { 1, 1, 1, 1, 1, 1, 1},
                new List<int> { 1, 1, 1, 1, 1, 1, 1},
                new List<int> { 1, 1, 1, 1, 1, 1, 1},
                new List<int> { 1, 1, 1, 1, 1, 1, 1},
            };

            return new LotteryCoupon(rows);
        }
    }
}
