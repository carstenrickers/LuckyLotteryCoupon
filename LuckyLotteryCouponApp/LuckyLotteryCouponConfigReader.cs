using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;


namespace LuckyLotteryCouponApp
{
    public static class LuckyLotteryCouponConfigReader
    {
        public static LuckyLotteryCouponConfiguration Read()
        {
            var config = new LuckyLotteryCouponConfiguration();

            /* We may later add config options in the config file for selecting the type of the random number generator.
               Now we just use a hard coded value. */
            config.RandomGenerator = RandomNumberGeneratorTypeEnum.CRYPTO;

            try
            {
                string luckyNumberStr = ConfigurationManager.AppSettings["LuckyNumber"];
                string maxNumberStr = ConfigurationManager.AppSettings["MaxNumber"];
                string numberOfRowsStr = ConfigurationManager.AppSettings["Rows"];
                string numberOfColumnsStr = ConfigurationManager.AppSettings["Columns"];

                config.LuckyNumber = Int32.Parse(luckyNumberStr);
                config.MaxNumber = Int32.Parse(maxNumberStr);
                config.NumberOfRows = Int32.Parse(numberOfRowsStr);
                config.NumberOfColumns = Int32.Parse(numberOfColumnsStr);

                return config;
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Illegal configulation found. Return default configurattion", e);

                config.LuckyNumber = 13;
                config.MaxNumber = 48;
                config.NumberOfRows = 10;
                config.NumberOfColumns = 7;
            }
            return config;
        }
    }
}
