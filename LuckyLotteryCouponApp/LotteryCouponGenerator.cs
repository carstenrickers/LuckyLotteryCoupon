using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyLotteryCouponApp
{
    public class LotteryCouponGenerator : ILotteryCouponGenerator
    {
        IRandomNumberGenerator RandomNumberGenerator;
        int NumberOfRows;
        int NumberOfColumns;

        public LotteryCouponGenerator(int numberOfRows, int numberOfColumns, IRandomNumberGenerator randomNumberGenerator)

        {
            NumberOfRows = numberOfRows;
            NumberOfColumns = numberOfColumns;
            RandomNumberGenerator = randomNumberGenerator;
        }

        public LotteryCoupon CreateEmptyLotteryCoupon()
        {
            return new LotteryCoupon(NumberOfRows, NumberOfColumns);
        }

        public LotteryCoupon CreateLotteryCoupon()
        {
            var rows = new List<List<int>>(NumberOfRows);
            for (int r = 0; r < NumberOfRows; r++)
            {
                var row = new List<int>(NumberOfColumns);
                for (int c = 0; c < NumberOfColumns; c++)
                {
                    row.Add(RandomNumberGenerator.Next());
                }
                rows.Add(row);
            }
            return new LotteryCoupon(rows);
        }

        public void RefillLotteryCoupon(LotteryCoupon lotteryCoupon)
        {
            for (int r = 0; r < lotteryCoupon.Rows.Count; r++)
            {
                var row = lotteryCoupon.Rows[r];
                for (int c = 0; c < row.Count; c++)
                {
                    row[c] = RandomNumberGenerator.Next();
                }
            }
        }
    }
}