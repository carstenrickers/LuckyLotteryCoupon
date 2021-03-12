
namespace LuckyLotteryCouponApp
{
    public interface ILuckyLotteryCouponGenerator
    {
        public (LotteryCoupon, long) Generate(int numberOfThreads);
    }
}
