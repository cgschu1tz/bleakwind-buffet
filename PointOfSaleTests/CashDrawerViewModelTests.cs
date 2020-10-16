/*
 * Author: Chris Schultz
 * Class: CashDrawerViewModelTests.cs
 * Purpose: Test the CashDrawerViewModelTests.cs class in the PointOfSale library
 */
using BleakwindBuffet.PointOfSale;
using System;
using System.ComponentModel;
using Xunit;

namespace PointOfSaleTests
{
    /// <summary>
    /// Unit tests for <see cref="CashDrawerViewModel"/>
    /// </summary>
    public class CashDrawerViewModelTests
    {
        [Theory]
        [InlineData(0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            1,  // $10 from customer
            0,
            0,
            0,
            12.15,
            2.15,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0
            )]
        public void ShouldMakeCorrectChange(int penniesInDrawer,
            int nickelsInDrawer,
            int dimesInDrawer,
            int quartersInDrawer,
            int onesInDrawer,
            int twosInDrawer,
            int fivesInDrawer,
            int tensInDrawer,
            int twentiesInDrawer,
            int fiftiesInDrawer,
            int hundredsInDrawer,
            int penniesFromCustomer,
            int nickelsFromCustomer,
            int dimesFromCustomer,
            int quartersFromCustomer,
            int onesFromCustomer,
            int twosFromCustomer,
            int fivesFromCustomer,
            int tensFromCustomer,
            int twentiesFromCustomer,
            int fiftiesFromCustomer,
            int hundredsFromCustomer,
            double saleAmount,
            double expectedAmountStillOwed,
            double expectedChangeDue,
            int expectedPenniesAsChange,
            int expectedNickelsAsChange,
            int expectedDimesAsChange,
            int expectedQuartersAsChange,
            int expectedOnesAsChange,
            int expectedTwosAsChange,
            int expectedFivesAsChange,
            int expectedTensAsChange,
            int expectedTwentiesAsChange,
            int expectedFiftiesAsChange,
            int expectedHundredsAsChange
            )
        {
            var c = new CashDrawerViewModel();
            RoundRegister.CashDrawer.ResetDrawer();

            RoundRegister.CashDrawer.Pennies = penniesInDrawer;
            RoundRegister.CashDrawer.Nickels = nickelsInDrawer;
            RoundRegister.CashDrawer.Dimes = dimesInDrawer;
            RoundRegister.CashDrawer.Quarters = quartersInDrawer;
            RoundRegister.CashDrawer.Ones = onesInDrawer;
            RoundRegister.CashDrawer.Twos = twosInDrawer;
            RoundRegister.CashDrawer.Fives = fivesInDrawer;
            RoundRegister.CashDrawer.Tens = tensInDrawer;
            RoundRegister.CashDrawer.Twenties = twentiesInDrawer;
            RoundRegister.CashDrawer.Fifties = fiftiesInDrawer;
            RoundRegister.CashDrawer.Hundreds = hundredsInDrawer;

            c.PenniesFromCustomer = penniesFromCustomer;
            c.NickelsFromCustomer = nickelsFromCustomer;
            c.DimesFromCustomer = dimesFromCustomer;
            c.QuartersFromCustomer = quartersFromCustomer;
            c.OnesFromCustomer = onesFromCustomer;
            c.TwosFromCustomer = twosFromCustomer;
            c.FivesFromCustomer = fivesFromCustomer;
            c.TensFromCustomer = tensFromCustomer;
            c.TwentiesFromCustomer = twentiesFromCustomer;
            c.FiftiesFromCustomer = fiftiesFromCustomer;
            c.HundredsFromCustomer = hundredsFromCustomer;

            c.SaleAmount = saleAmount;

            Assert.Equal(expectedAmountStillOwed, c.AmountStillOwed, 2);
            Assert.Equal(expectedChangeDue, c.ChangeDue, 2);

            Assert.Equal(expectedPenniesAsChange, c.PenniesAsChange);
            Assert.Equal(expectedNickelsAsChange, c.NickelsAsChange);
            Assert.Equal(expectedDimesAsChange, c.DimesAsChange);
            Assert.Equal(expectedQuartersAsChange, c.QuartersAsChange);
            Assert.Equal(expectedOnesAsChange, c.OnesAsChange);
            Assert.Equal(expectedTwosAsChange, c.TwosAsChange);
            Assert.Equal(expectedFivesAsChange, c.FivesAsChange);
            Assert.Equal(expectedTensAsChange, c.TensAsChange);
            Assert.Equal(expectedTwentiesAsChange, c.TwentiesAsChange);
            Assert.Equal(expectedFiftiesAsChange, c.FiftiesAsChange);
            Assert.Equal(expectedHundredsAsChange, c.HundredsAsChange);
        }

        [Fact]
        public void ShouldImplementINotifyPropertyChanged()
        {
            Assert.IsAssignableFrom<INotifyPropertyChanged>(new CashDrawerViewModel());
        }

        [Fact]
        public void ShouldNotifyPropertyChanged()
        {
            var c = new CashDrawerViewModel();

            Assert.PropertyChanged(c, "PenniesFromCustomer", () => c.PenniesFromCustomer = 0);
            Assert.PropertyChanged(c, "ChangeDue", () => c.PenniesFromCustomer = 0);
            Assert.PropertyChanged(c, "PenniesAsChange", () => c.PenniesFromCustomer = 0);
            Assert.PropertyChanged(c, "NickelsAsChange", () => c.PenniesFromCustomer = 0);
            Assert.PropertyChanged(c, "DimesAsChange", () => c.PenniesFromCustomer = 0);
            Assert.PropertyChanged(c, "QuartersAsChange", () => c.PenniesFromCustomer = 0);
            Assert.PropertyChanged(c, "OnesAsChange", () => c.PenniesFromCustomer = 0);
            Assert.PropertyChanged(c, "TwosAsChange", () => c.PenniesFromCustomer = 0);
            Assert.PropertyChanged(c, "FivesAsChange", () => c.PenniesFromCustomer = 0);
            Assert.PropertyChanged(c, "TensAsChange", () => c.PenniesFromCustomer = 0);
            Assert.PropertyChanged(c, "TwentiesAsChange", () => c.PenniesFromCustomer = 0);
            Assert.PropertyChanged(c, "FiftiesAsChange", () => c.PenniesFromCustomer = 0);
            Assert.PropertyChanged(c, "HundredsAsChange", () => c.PenniesFromCustomer = 0);

            Assert.PropertyChanged(c, "NickelsFromCustomer", () => c.NickelsFromCustomer = 0);
            Assert.PropertyChanged(c, "ChangeDue", () => c.NickelsFromCustomer = 0);
            Assert.PropertyChanged(c, "PenniesAsChange", () => c.NickelsFromCustomer = 0);
            Assert.PropertyChanged(c, "NickelsAsChange", () => c.NickelsFromCustomer = 0);
            Assert.PropertyChanged(c, "DimesAsChange", () => c.NickelsFromCustomer = 0);
            Assert.PropertyChanged(c, "QuartersAsChange", () => c.NickelsFromCustomer = 0);
            Assert.PropertyChanged(c, "OnesAsChange", () => c.NickelsFromCustomer = 0);
            Assert.PropertyChanged(c, "TwosAsChange", () => c.NickelsFromCustomer = 0);
            Assert.PropertyChanged(c, "FivesAsChange", () => c.NickelsFromCustomer = 0);
            Assert.PropertyChanged(c, "TensAsChange", () => c.NickelsFromCustomer = 0);
            Assert.PropertyChanged(c, "TwentiesAsChange", () => c.NickelsFromCustomer = 0);
            Assert.PropertyChanged(c, "FiftiesAsChange", () => c.NickelsFromCustomer = 0);
            Assert.PropertyChanged(c, "HundredsAsChange", () => c.NickelsFromCustomer = 0);

            Assert.PropertyChanged(c, "DimesFromCustomer", () => c.DimesFromCustomer = 0);
            Assert.PropertyChanged(c, "ChangeDue", () => c.DimesFromCustomer = 0);
            Assert.PropertyChanged(c, "PenniesAsChange", () => c.DimesFromCustomer = 0);
            Assert.PropertyChanged(c, "NickelsAsChange", () => c.DimesFromCustomer = 0);
            Assert.PropertyChanged(c, "DimesAsChange", () => c.DimesFromCustomer = 0);
            Assert.PropertyChanged(c, "QuartersAsChange", () => c.DimesFromCustomer = 0);
            Assert.PropertyChanged(c, "OnesAsChange", () => c.DimesFromCustomer = 0);
            Assert.PropertyChanged(c, "TwosAsChange", () => c.DimesFromCustomer = 0);
            Assert.PropertyChanged(c, "FivesAsChange", () => c.DimesFromCustomer = 0);
            Assert.PropertyChanged(c, "TensAsChange", () => c.DimesFromCustomer = 0);
            Assert.PropertyChanged(c, "TwentiesAsChange", () => c.DimesFromCustomer = 0);
            Assert.PropertyChanged(c, "FiftiesAsChange", () => c.DimesFromCustomer = 0);
            Assert.PropertyChanged(c, "HundredsAsChange", () => c.DimesFromCustomer = 0);

            Assert.PropertyChanged(c, "QuartersFromCustomer", () => c.QuartersFromCustomer = 0);
            Assert.PropertyChanged(c, "ChangeDue", () => c.QuartersFromCustomer = 0);
            Assert.PropertyChanged(c, "PenniesAsChange", () => c.QuartersFromCustomer = 0);
            Assert.PropertyChanged(c, "NickelsAsChange", () => c.QuartersFromCustomer = 0);
            Assert.PropertyChanged(c, "DimesAsChange", () => c.QuartersFromCustomer = 0);
            Assert.PropertyChanged(c, "QuartersAsChange", () => c.QuartersFromCustomer = 0);
            Assert.PropertyChanged(c, "OnesAsChange", () => c.QuartersFromCustomer = 0);
            Assert.PropertyChanged(c, "TwosAsChange", () => c.QuartersFromCustomer = 0);
            Assert.PropertyChanged(c, "FivesAsChange", () => c.QuartersFromCustomer = 0);
            Assert.PropertyChanged(c, "TensAsChange", () => c.QuartersFromCustomer = 0);
            Assert.PropertyChanged(c, "TwentiesAsChange", () => c.QuartersFromCustomer = 0);
            Assert.PropertyChanged(c, "FiftiesAsChange", () => c.QuartersFromCustomer = 0);
            Assert.PropertyChanged(c, "HundredsAsChange", () => c.QuartersFromCustomer = 0);

            Assert.PropertyChanged(c, "OnesFromCustomer", () => c.OnesFromCustomer = 0);
            Assert.PropertyChanged(c, "ChangeDue", () => c.OnesFromCustomer = 0);
            Assert.PropertyChanged(c, "PenniesAsChange", () => c.OnesFromCustomer = 0);
            Assert.PropertyChanged(c, "NickelsAsChange", () => c.OnesFromCustomer = 0);
            Assert.PropertyChanged(c, "DimesAsChange", () => c.OnesFromCustomer = 0);
            Assert.PropertyChanged(c, "QuartersAsChange", () => c.OnesFromCustomer = 0);
            Assert.PropertyChanged(c, "OnesAsChange", () => c.OnesFromCustomer = 0);
            Assert.PropertyChanged(c, "TwosAsChange", () => c.OnesFromCustomer = 0);
            Assert.PropertyChanged(c, "FivesAsChange", () => c.OnesFromCustomer = 0);
            Assert.PropertyChanged(c, "TensAsChange", () => c.OnesFromCustomer = 0);
            Assert.PropertyChanged(c, "TwentiesAsChange", () => c.OnesFromCustomer = 0);
            Assert.PropertyChanged(c, "FiftiesAsChange", () => c.OnesFromCustomer = 0);
            Assert.PropertyChanged(c, "HundredsAsChange", () => c.OnesFromCustomer = 0);

            Assert.PropertyChanged(c, "TwosFromCustomer", () => c.TwosFromCustomer = 0);
            Assert.PropertyChanged(c, "ChangeDue", () => c.TwosFromCustomer = 0);
            Assert.PropertyChanged(c, "PenniesAsChange", () => c.TwosFromCustomer = 0);
            Assert.PropertyChanged(c, "NickelsAsChange", () => c.TwosFromCustomer = 0);
            Assert.PropertyChanged(c, "DimesAsChange", () => c.TwosFromCustomer = 0);
            Assert.PropertyChanged(c, "QuartersAsChange", () => c.TwosFromCustomer = 0);
            Assert.PropertyChanged(c, "OnesAsChange", () => c.TwosFromCustomer = 0);
            Assert.PropertyChanged(c, "TwosAsChange", () => c.TwosFromCustomer = 0);
            Assert.PropertyChanged(c, "FivesAsChange", () => c.TwosFromCustomer = 0);
            Assert.PropertyChanged(c, "TensAsChange", () => c.TwosFromCustomer = 0);
            Assert.PropertyChanged(c, "TwentiesAsChange", () => c.TwosFromCustomer = 0);
            Assert.PropertyChanged(c, "FiftiesAsChange", () => c.TwosFromCustomer = 0);
            Assert.PropertyChanged(c, "HundredsAsChange", () => c.TwosFromCustomer = 0);

            Assert.PropertyChanged(c, "FivesFromCustomer", () => c.FivesFromCustomer = 0);
            Assert.PropertyChanged(c, "ChangeDue", () => c.FivesFromCustomer = 0);
            Assert.PropertyChanged(c, "PenniesAsChange", () => c.FivesFromCustomer = 0);
            Assert.PropertyChanged(c, "NickelsAsChange", () => c.FivesFromCustomer = 0);
            Assert.PropertyChanged(c, "DimesAsChange", () => c.FivesFromCustomer = 0);
            Assert.PropertyChanged(c, "QuartersAsChange", () => c.FivesFromCustomer = 0);
            Assert.PropertyChanged(c, "OnesAsChange", () => c.FivesFromCustomer = 0);
            Assert.PropertyChanged(c, "TwosAsChange", () => c.FivesFromCustomer = 0);
            Assert.PropertyChanged(c, "FivesAsChange", () => c.FivesFromCustomer = 0);
            Assert.PropertyChanged(c, "TensAsChange", () => c.FivesFromCustomer = 0);
            Assert.PropertyChanged(c, "TwentiesAsChange", () => c.FivesFromCustomer = 0);
            Assert.PropertyChanged(c, "FiftiesAsChange", () => c.FivesFromCustomer = 0);
            Assert.PropertyChanged(c, "HundredsAsChange", () => c.FivesFromCustomer = 0);

            Assert.PropertyChanged(c, "TensFromCustomer", () => c.TensFromCustomer = 0);
            Assert.PropertyChanged(c, "ChangeDue", () => c.TensFromCustomer = 0);
            Assert.PropertyChanged(c, "PenniesAsChange", () => c.TensFromCustomer = 0);
            Assert.PropertyChanged(c, "NickelsAsChange", () => c.TensFromCustomer = 0);
            Assert.PropertyChanged(c, "DimesAsChange", () => c.TensFromCustomer = 0);
            Assert.PropertyChanged(c, "QuartersAsChange", () => c.TensFromCustomer = 0);
            Assert.PropertyChanged(c, "OnesAsChange", () => c.TensFromCustomer = 0);
            Assert.PropertyChanged(c, "TwosAsChange", () => c.TensFromCustomer = 0);
            Assert.PropertyChanged(c, "FivesAsChange", () => c.TensFromCustomer = 0);
            Assert.PropertyChanged(c, "TensAsChange", () => c.TensFromCustomer = 0);
            Assert.PropertyChanged(c, "TwentiesAsChange", () => c.TensFromCustomer = 0);
            Assert.PropertyChanged(c, "FiftiesAsChange", () => c.TensFromCustomer = 0);
            Assert.PropertyChanged(c, "HundredsAsChange", () => c.TensFromCustomer = 0);

            Assert.PropertyChanged(c, "TwentiesFromCustomer", () => c.TwentiesFromCustomer = 0);
            Assert.PropertyChanged(c, "ChangeDue", () => c.TwentiesFromCustomer = 0);
            Assert.PropertyChanged(c, "PenniesAsChange", () => c.TwentiesFromCustomer = 0);
            Assert.PropertyChanged(c, "NickelsAsChange", () => c.TwentiesFromCustomer = 0);
            Assert.PropertyChanged(c, "DimesAsChange", () => c.TwentiesFromCustomer = 0);
            Assert.PropertyChanged(c, "QuartersAsChange", () => c.TwentiesFromCustomer = 0);
            Assert.PropertyChanged(c, "OnesAsChange", () => c.TwentiesFromCustomer = 0);
            Assert.PropertyChanged(c, "TwosAsChange", () => c.TwentiesFromCustomer = 0);
            Assert.PropertyChanged(c, "FivesAsChange", () => c.TwentiesFromCustomer = 0);
            Assert.PropertyChanged(c, "TensAsChange", () => c.TwentiesFromCustomer = 0);
            Assert.PropertyChanged(c, "TwentiesAsChange", () => c.TwentiesFromCustomer = 0);
            Assert.PropertyChanged(c, "FiftiesAsChange", () => c.TwentiesFromCustomer = 0);
            Assert.PropertyChanged(c, "HundredsAsChange", () => c.TwentiesFromCustomer = 0);

            Assert.PropertyChanged(c, "FiftiesFromCustomer", () => c.FiftiesFromCustomer = 0);
            Assert.PropertyChanged(c, "ChangeDue", () => c.FiftiesFromCustomer = 0);
            Assert.PropertyChanged(c, "PenniesAsChange", () => c.FiftiesFromCustomer = 0);
            Assert.PropertyChanged(c, "NickelsAsChange", () => c.FiftiesFromCustomer = 0);
            Assert.PropertyChanged(c, "DimesAsChange", () => c.FiftiesFromCustomer = 0);
            Assert.PropertyChanged(c, "QuartersAsChange", () => c.FiftiesFromCustomer = 0);
            Assert.PropertyChanged(c, "OnesAsChange", () => c.FiftiesFromCustomer = 0);
            Assert.PropertyChanged(c, "TwosAsChange", () => c.FiftiesFromCustomer = 0);
            Assert.PropertyChanged(c, "FivesAsChange", () => c.FiftiesFromCustomer = 0);
            Assert.PropertyChanged(c, "TensAsChange", () => c.FiftiesFromCustomer = 0);
            Assert.PropertyChanged(c, "TwentiesAsChange", () => c.FiftiesFromCustomer = 0);
            Assert.PropertyChanged(c, "FiftiesAsChange", () => c.FiftiesFromCustomer = 0);
            Assert.PropertyChanged(c, "HundredsAsChange", () => c.FiftiesFromCustomer = 0);

            Assert.PropertyChanged(c, "HundredsFromCustomer", () => c.HundredsFromCustomer = 0);
            Assert.PropertyChanged(c, "ChangeDue", () => c.HundredsFromCustomer = 0);
            Assert.PropertyChanged(c, "PenniesAsChange", () => c.HundredsFromCustomer = 0);
            Assert.PropertyChanged(c, "NickelsAsChange", () => c.HundredsFromCustomer = 0);
            Assert.PropertyChanged(c, "DimesAsChange", () => c.HundredsFromCustomer = 0);
            Assert.PropertyChanged(c, "QuartersAsChange", () => c.HundredsFromCustomer = 0);
            Assert.PropertyChanged(c, "OnesAsChange", () => c.HundredsFromCustomer = 0);
            Assert.PropertyChanged(c, "TwosAsChange", () => c.HundredsFromCustomer = 0);
            Assert.PropertyChanged(c, "FivesAsChange", () => c.HundredsFromCustomer = 0);
            Assert.PropertyChanged(c, "TensAsChange", () => c.HundredsFromCustomer = 0);
            Assert.PropertyChanged(c, "TwentiesAsChange", () => c.HundredsFromCustomer = 0);
            Assert.PropertyChanged(c, "FiftiesAsChange", () => c.HundredsFromCustomer = 0);
            Assert.PropertyChanged(c, "HundredsAsChange", () => c.HundredsFromCustomer = 0);

            Assert.PropertyChanged(c, "SaleAmount", () => c.SaleAmount = 0);
            Assert.PropertyChanged(c, "AmountStillOwed", () => c.SaleAmount = 0);
            Assert.PropertyChanged(c, "ChangeDue", () => c.SaleAmount = 0);
            Assert.PropertyChanged(c, "PenniesAsChange", () => c.SaleAmount = 0);
            Assert.PropertyChanged(c, "NickelsAsChange", () => c.SaleAmount = 0);
            Assert.PropertyChanged(c, "DimesAsChange", () => c.SaleAmount = 0);
            Assert.PropertyChanged(c, "QuartersAsChange", () => c.SaleAmount = 0);
            Assert.PropertyChanged(c, "OnesAsChange", () => c.SaleAmount = 0);
            Assert.PropertyChanged(c, "TwosAsChange", () => c.SaleAmount = 0);
            Assert.PropertyChanged(c, "FivesAsChange", () => c.SaleAmount = 0);
            Assert.PropertyChanged(c, "TensAsChange", () => c.SaleAmount = 0);
            Assert.PropertyChanged(c, "TwentiesAsChange", () => c.SaleAmount = 0);
            Assert.PropertyChanged(c, "FiftiesAsChange", () => c.SaleAmount = 0);
            Assert.PropertyChanged(c, "HundredsAsChange", () => c.SaleAmount = 0);
        }
    }
}
