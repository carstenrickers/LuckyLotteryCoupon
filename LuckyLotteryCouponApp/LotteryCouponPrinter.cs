using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyLotteryCouponApp
{
    public static class LotteryCouponPrinter
    {
        static public void Print(LotteryCoupon lotteryCoupon, int luckyNumber)
        {
            var sb = new StringBuilder();
            var oldConsoleForegroundColour = Console.ForegroundColor;
            foreach (var row in lotteryCoupon.Rows)
            {
                foreach (int n in row)
                {
                    Console.Write(" ");
                    if (n == luckyNumber)
                        Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(n);
                    if (n == luckyNumber)
                        Console.ForegroundColor = oldConsoleForegroundColour;
                    Console.Write(ExtraPadding(n));
                    Console.Write("|");
                }
                Console.Out.WriteLine("");
            }
        }

        private static string ExtraPadding(int lotteryNumber)
        {
            if (lotteryNumber <= 9)
                return "  ";
            else if (lotteryNumber <= 99)
                return " ";
            else
                return "";
        }
    }
}
