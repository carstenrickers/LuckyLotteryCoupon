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
            if (config.RandomGenerator == RandomNumberGeneratorTypeEnum.STANDARD)
                randomNumberGenerator = new StandardRandomNumberGenerator(config.MaxNumber);
            else
                randomNumberGenerator = new CryptoRandomNumberGenerator(config.MaxNumber);
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
