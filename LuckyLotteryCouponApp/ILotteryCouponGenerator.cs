namespace LuckyLotteryCouponApp
{
    public interface ILotteryCouponGenerator
    {
        public LotteryCoupon CreateEmptyLotteryCoupon();
        public LotteryCoupon CreateLotteryCoupon();
        public void RefillLotteryCoupon(LotteryCoupon lotteryCoupon);
    }
}
