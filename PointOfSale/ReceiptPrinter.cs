/*
 * Author: Chris Schultz
 * Class name: ReciptPrinter.cs
 * Purpose: Defines a class for interacting with the receipt printer.
 */
using BleakwindBuffet.Data;
using System;

namespace BleakwindBuffet.PointOfSale
{
    /// <summary>
    /// Wraps <see cref="RoundRegister.RecieptPrinter"/>
    /// </summary>
    public static class ReceiptPrinter
    {
        /// <summary>
        /// Prints the receipt for <paramref name="order"/>
        /// </summary>
        /// <param name="order">an order</param>
        /// <param name="paymentMethod">the method of payment</param>
        /// <param name="cashGiven">
        /// How much cash was given to us by the customer (e.g., $20 for a $18 order).
        /// This is used to calculate the change owed.
        /// This parameter is ignored if <paramref name="paymentMethod"/> is not <see cref="PaymentMethod.Cash"/>.
        /// </param>
        public static void PrintReceipt(Order order, PaymentMethod paymentMethod, double cashGiven = 0)
        {
            const int maxLength = 40;
            const string gap = "  ";

            RoundRegister.RecieptPrinter.PrintLine(FormatLine($"Order #{order.Number}", maxLength));
            RoundRegister.RecieptPrinter.PrintLine(FormatLine($"Date: {DateTime.Today:d}", maxLength));
            RoundRegister.RecieptPrinter.PrintLine("");

            foreach (var item in order)
            {
                var price = string.Format("{0:C2}", item.Price);
                var name = FormatLine(item.ToString(), maxLength - gap.Length - price.Length);
                RoundRegister.RecieptPrinter.PrintLine(name + gap + price);

                foreach (var instruction in item.SpecialInstructions)
                {
                    RoundRegister.RecieptPrinter.PrintLine(FormatLine(gap + instruction, maxLength));
                }
                RoundRegister.RecieptPrinter.PrintLine("");
            }

            RoundRegister.RecieptPrinter.PrintLine($"Subtotal: {order.Subtotal,maxLength - 10:C2}");
            RoundRegister.RecieptPrinter.PrintLine($"Tax: {order.Tax,maxLength - 5:C2}");
            RoundRegister.RecieptPrinter.PrintLine($"Total: {order.Total,maxLength - 7:C2}");
            RoundRegister.RecieptPrinter.PrintLine("");

            switch (paymentMethod)
            {
                case PaymentMethod.Cash:
                    RoundRegister.RecieptPrinter.PrintLine("Payment method: cash");
                    RoundRegister.RecieptPrinter.PrintLine($"Cash received: {cashGiven,maxLength:C2}");
                    RoundRegister.RecieptPrinter.PrintLine($"Change owed: {cashGiven - order.Total,maxLength:C2}");
                    break;
                case PaymentMethod.CreditDebit:
                    RoundRegister.RecieptPrinter.PrintLine("Payment method: card");
                    break;
            }

            RoundRegister.RecieptPrinter.CutTape();
        }

        /// <summary>
        /// Truncate and pad a string so it will fit on the receipt.
        /// </summary>
        /// <param name="s">the string to truncate and pad</param>
        /// <returns>the truncated and padded string</returns>
        private static string FormatLine(string s, int length)
        {
            if (s.Length <= length) return s.PadRight(length);
            else return s.Substring(0, length - 3) + "...";
        }
    }
}
