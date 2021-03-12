using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyLotteryCouponApp
{
    class StandardRandomNumberGenerator : IRandomNumberGenerator
    {
        private int MaxNumber;
        private Random random;
        public StandardRandomNumberGenerator(int maxNumber)
        {
            MaxNumber = maxNumber;
            random = new Random();
        }

        public void Dispose()
        {
            // Do nothing
        }

        public int Next()
        {
            /* Microsoft documentation says that the Ramdom class is NOT thread safe */
            lock (this)
            {
                return random.Next(1, MaxNumber);
            }
        }
    }
}
