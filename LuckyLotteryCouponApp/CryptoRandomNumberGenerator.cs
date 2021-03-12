using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace LuckyLotteryCouponApp
{
    class CryptoRandomNumberGenerator : IRandomNumberGenerator
    {
        private static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
        private int MaxNumber;

        public CryptoRandomNumberGenerator(int maxNumber)
        {
            if (maxNumber > 255)
            {
                Console.Out.WriteLine("Max number from CryptoRandomNumberGenerator is 255");
            }
            this.MaxNumber = maxNumber;
        }

        public void Dispose()
        {
            rngCsp.Dispose();
        }

        public int Next()
        {
            /* Microsoft documentation says that the RNGCryptoServiceProvider class is thread safe */

            // Create a byte array to hold the random value.
            byte[] bytes = new byte[1];
            int randomNumber;
            do
            {
                // Fill the array with a random value.
                rngCsp.GetBytes(bytes);
                randomNumber = (int) bytes[0];
            }
            while (randomNumber < 1 || randomNumber > MaxNumber);
            return randomNumber;
        }    
    }
}
