using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyLotteryCouponApp
{
    public interface IRandomNumberGenerator : IDisposable
    {
        int Next();
    }
}
