using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyLotteryCouponApp
{
    public class LuckyLotteryCouponGeneratorFactory : IDisposable
    {
        private IRandomNumberGenerator randomNumberGenerator;
        private ILotteryCouponGenerator lotteryCouponGenerator;
        private ILotteryCouponChecker lotteryCouponChecker;

        public LuckyLotteryCouponGeneratorFactory(LuckyLotteryCouponConfiguration config)
        {
            // randomNumberGenerator = new CryptoRandomNumberGenerator(config.MaxNumber);
            randomNumberGenerator = new StandardRandomNumberGenerator(config.MaxNumber);
            lotteryCouponGenerator = new LotteryCouponGenerator(config.NumberOfRows, config.NumberOfColumns, randomNumberGenerator);
            lotteryCouponChecker = new LuckyLotteryCouponChecker(config.LuckyNumber);
        }

        public ILuckyLotteryCouponGenerator Create()
        {
            return new LuckyLotteryCouponGenerator(lotteryCouponGenerator, lotteryCouponChecker);
        }

        public void Dispose()
        {
            randomNumberGenerator.Dispose();
        }
    }
}
