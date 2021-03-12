using System;

namespace LuckyLotteryCouponApp
{
    public interface IRandomNumberGenerator : IDisposable
    {
        int Next();
    }
}
