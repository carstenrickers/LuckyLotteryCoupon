using LuckyLotteryCouponApp;
using NSubstitute;
using Xunit;

namespace LuckyLotteryCouponTest
{
    public class LuckyLotteryCouponGeneratorTest
    {
        [Fact]
        public void TestLuckyLotteryCouponGeneratorWithOneThread()
        {
            // Arrange:
            var expectedLotteryCoupon = new LotteryCoupon(10, 7);
            var lotteryCouponGenerator = CreateLotteryCouponGeneratorMock(expectedLotteryCoupon);
            var lotteryCouponChecker = CreateLotteryCouponCheckerMock();
            var luckyLotteryCouponGenerator = new LuckyLotteryCouponGenerator(lotteryCouponGenerator, lotteryCouponChecker);

            // Act:
            (var result, long numberOfAttempts) = luckyLotteryCouponGenerator.Generate(1);

            // Assert:
            Assert.Same(expectedLotteryCoupon, result);
            Assert.Equal(1, numberOfAttempts);
        }

        [Fact]
        public void TestLuckyLotteryCouponGeneratorWithFourThreads()
        {
            // Arrange:
            var expectedLotteryCoupon = new LotteryCoupon(10, 7);
            var lotteryCouponGenerator = CreateLotteryCouponGeneratorMock(expectedLotteryCoupon);
            var lotteryCouponChecker = CreateLotteryCouponCheckerMock();
            var luckyLotteryCouponGenerator = new LuckyLotteryCouponGenerator(lotteryCouponGenerator, lotteryCouponChecker);

            // Act:
            (var result, long numberOfAttempts) = luckyLotteryCouponGenerator.Generate(4);

            // Assert:
            Assert.Same(expectedLotteryCoupon, result);
            Assert.Equal(4, numberOfAttempts);
        }

        private ILotteryCouponGenerator CreateLotteryCouponGeneratorMock(LotteryCoupon expectedLotteryCoupon)
        {
            var lotteryCouponGenerator = Substitute.For<ILotteryCouponGenerator>();
            lotteryCouponGenerator.CreateEmptyLotteryCoupon().Returns(expectedLotteryCoupon);
            return lotteryCouponGenerator;
        }

        private ILotteryCouponChecker CreateLotteryCouponCheckerMock()
        {
            var lotteryCouponChecker = Substitute.For<ILotteryCouponChecker>();
            lotteryCouponChecker.Check(Arg.Any<LotteryCoupon>()).Returns(true);
            return lotteryCouponChecker;
        }
    }
}
