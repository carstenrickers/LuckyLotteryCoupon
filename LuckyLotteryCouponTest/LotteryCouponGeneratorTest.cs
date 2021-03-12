using LuckyLotteryCouponApp;
using NSubstitute;
using Xunit;

namespace LuckyLotteryCouponTest
{
    public class LotteryCouponGeneratorTest
    {
        [Fact]
        public void TestGenerateSimpleCoupon()
        {
            // Arrange:
            int expectedValue = 1;
            var randomGenerator = CreateRandomNumberGeneratorMock(expectedValue);
            var lotteryCouponGenerator = new LotteryCouponGenerator(10, 7, randomGenerator);

            // Act:
            var lotteryCoupon = lotteryCouponGenerator.CreateEmptyLotteryCoupon();
            lotteryCouponGenerator.RefillLotteryCoupon(lotteryCoupon);

            // Assert:
            CheckAllRowsAndColumnValues(lotteryCoupon, expectedValue);
        }

        private static void CheckAllRowsAndColumnValues(LotteryCoupon lotteryCoupon, int expectedValue)
        {
            foreach (var row in lotteryCoupon.Rows)
            {
                foreach (var n in row)
                {
                    Assert.Equal(expectedValue, n);
                }
            }
        }

        private static IRandomNumberGenerator CreateRandomNumberGeneratorMock(int value)
        {
            var randomGenerator = Substitute.For<IRandomNumberGenerator>();
            randomGenerator.Next().Returns(value);
            return randomGenerator;
        }
    }
}
