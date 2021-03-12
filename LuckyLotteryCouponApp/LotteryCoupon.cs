﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyLotteryCouponApp
{
    public class LotteryCoupon
    {
        public LotteryCoupon(List<List<int>> rows)
        {
            Rows = rows; // It will be more safe to use a copy of the rows parameter
        }

        public LotteryCoupon(int numberOfRows, int numberOfColumns)
        {
            Rows = new List<List<int>>(numberOfRows);
            for (int r = 0; r < numberOfRows; r++)
            {
                var row = new List<int>(numberOfColumns);
                for (int c = 0; c < numberOfColumns; c++)
                {
                    row.Add(0);
                }
                Rows.Add(row);
            }
        }

        public List<List<int>> Rows { get; }
    }
}
