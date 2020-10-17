/*
 * Author: Chris Schultz
 * Class name: CashDrawerViewModel.cs
 * Purpose: Defines a class to wrap the cash drawer logic for GUI binding
 */
using RoundRegister;
using System.ComponentModel;

namespace BleakwindBuffet.PointOfSale
{
    /// <summary>
    /// Wraps <see cref="CashDrawer"/> logic for GUI binding.
    /// </summary>
    public class CashDrawerViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Invoked when a property of this item changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Puts the proper amounts back in the cash drawer.
        /// </summary>
        public void FinalizeSale()
        {
            CashDrawer.Pennies = PenniesFromCustomer - PenniesAsChange;
            CashDrawer.Nickels = NickelsFromCustomer - NickelsAsChange;
            CashDrawer.Dimes = DimesFromCustomer - DimesAsChange;
            CashDrawer.Quarters = QuartersFromCustomer - QuartersAsChange;
            CashDrawer.Ones = OnesFromCustomer - OnesAsChange;
            CashDrawer.Twos = TwosFromCustomer - TwosAsChange;
            CashDrawer.Fives = FivesFromCustomer - FivesAsChange;
            CashDrawer.Tens = TensFromCustomer - TensAsChange;
            CashDrawer.Twenties = TwentiesFromCustomer - TwentiesAsChange;
            CashDrawer.Fifties = FiftiesFromCustomer - FiftiesAsChange;
            CashDrawer.Hundreds = HundredsFromCustomer - HundredsAsChange;
        }

        /// <summary>
        /// Backing variable for <see cref="SaleAmount"/>
        /// </summary>
        private double saleAmount;

        /// <summary>
        /// The total amount that the customer owes.
        /// </summary>
        public double SaleAmount
        {
            get => saleAmount;
            set {
                saleAmount = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The total amount that the customer owes, excluding the money they have already given us.
        /// </summary>
        public double AmountStillOwed => saleAmount
                - 0.01 * PenniesFromCustomer
                - 0.05 * NickelsFromCustomer
                - 0.10 * DimesFromCustomer
                - 0.25 * QuartersFromCustomer
                - 1.00 * OnesFromCustomer
                - 2.00 * TwosFromCustomer
                - 5.00 * FivesFromCustomer
                - 10.00 * TensFromCustomer
                - 20.00 * TwentiesFromCustomer
                - 50.00 * FiftiesFromCustomer
                - 100.00 * HundredsFromCustomer;

        /// <summary>
        /// The amount we owe the customer in change.
        /// </summary>
        public double ChangeDue => (AmountStillOwed < 0) ? -AmountStillOwed : 0;

        /// <summary>
        /// Updates the AsChange properties so they reflect the correct amounts.
        /// </summary>
        private void MakeChange()
        {
            // Lord forgive me for what I'm about to write...
            var changeDue = ChangeDue;

            HundredsAsChange = 0;
            while (changeDue - 100 > 0 && CashDrawer.Hundreds + HundredsFromCustomer > 0)
            {
                changeDue -= 100;
                HundredsAsChange++;
            }

            FiftiesAsChange = 0;
            while (changeDue - 50 > 0 && CashDrawer.Fifties + FiftiesFromCustomer > 0)
            {
                changeDue -= 50;
                FiftiesAsChange++;
            }

            TwentiesAsChange = 0;
            while (changeDue - 20 > 0 && CashDrawer.Twenties + TwentiesFromCustomer > 0)
            {
                changeDue -= 20;
                TwentiesAsChange++;
            }

            TensAsChange = 0;
            while (changeDue - 10 > 0 && CashDrawer.Tens + TensFromCustomer > 0)
            {
                changeDue -= 10;
                TensAsChange++;
            }

            FivesAsChange = 0;
            while (changeDue - 5 > 0 && CashDrawer.Fives + FivesFromCustomer > 0)
            {
                changeDue -= 5;
                FivesAsChange++;
            }

            TwosAsChange = 0;
            while (changeDue - 2 > 0 && CashDrawer.Twos + TwosFromCustomer > 0)
            {
                changeDue -= 2;
                TwosAsChange++;
            }

            OnesAsChange = 0;
            while (changeDue - 1 > 0 && CashDrawer.Ones + OnesFromCustomer > 0)
            {
                changeDue -= 1;
                OnesAsChange++;
            }

            QuartersAsChange = 0;
            while (changeDue - 0.25 > 0 && CashDrawer.Quarters + QuartersFromCustomer > 0)
            {
                changeDue -= 0.25;
                QuartersAsChange++;
            }

            DimesAsChange = 0;
            while (changeDue - 0.10 > 0 && CashDrawer.Dimes + DimesFromCustomer > 0)
            {
                changeDue -= 0.10;
                DimesAsChange++;
            }

            NickelsAsChange = 0;
            while (changeDue - 0.05 > 0 && CashDrawer.Nickels + NickelsFromCustomer > 0)
            {
                changeDue -= 0.05;
                NickelsAsChange++;
            }

            PenniesAsChange = 0;
            while (changeDue - 0.01 > 0 && CashDrawer.Pennies + PenniesFromCustomer > 0)
            {
                changeDue -= 0.01;
                PenniesAsChange++;
            }
        }

        /// <summary>
        /// Raises the <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <param name="propertyName">the name of the property that changed</param>
        protected void OnPropertyChanged()
        {
            MakeChange();

            // Better safe than sorry.
            // The performance cost can't be that bad, right?
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PenniesFromCustomer)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NickelsFromCustomer)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DimesFromCustomer)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(QuartersFromCustomer)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(OnesFromCustomer)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TwosFromCustomer)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FivesFromCustomer)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TensFromCustomer)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TwentiesFromCustomer)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FiftiesFromCustomer)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HundredsFromCustomer)));

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PenniesAsChange)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NickelsAsChange)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DimesAsChange)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(QuartersAsChange)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(OnesAsChange)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TwosAsChange)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FivesAsChange)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TensAsChange)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TwentiesAsChange)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FiftiesAsChange)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HundredsAsChange)));

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AmountStillOwed)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ChangeDue)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SaleAmount)));
        }

        /// <summary>
        /// Backing variable for <see cref="PenniesFromCustomer"/>
        /// </summary>
        private int penniesFromCustomer = 0;

        /// <summary>
        /// The number of pennies that the customer has given us.
        /// </summary>
        public int PenniesFromCustomer
        {
            get => penniesFromCustomer;
            set {
                penniesFromCustomer = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Backing variable for <see cref="NickelsFromCustomer"/>
        /// </summary>
        private int nickelsFromCustomer = 0;

        /// <summary>
        /// The number of nickels that the customer has given us.
        /// </summary>
        public int NickelsFromCustomer
        {
            get => nickelsFromCustomer;
            set {
                nickelsFromCustomer = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Backing variable for <see cref="DimesFromCustomer"/>
        /// </summary>
        private int dimesFromCustomer = 0;

        /// <summary>
        /// The number of dimes that the customer has given us.
        /// </summary>
        public int DimesFromCustomer
        {
            get => dimesFromCustomer;
            set {
                dimesFromCustomer = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Backing variable for <see cref="QuartersFromCustomer"/>
        /// </summary>
        private int quartersFromCustomer = 0;

        /// <summary>
        /// The number of quarters that the customer has given us.
        /// </summary>
        public int QuartersFromCustomer
        {
            get => quartersFromCustomer;
            set {
                quartersFromCustomer = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Backing variable for <see cref="OnesFromCustomer"/>
        /// </summary>
        private int onesFromCustomer = 0;

        /// <summary>
        /// The number of one dollar bills that the customer has given us.
        /// </summary>
        public int OnesFromCustomer
        {
            get => onesFromCustomer;
            set {
                onesFromCustomer = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Backing variable for <see cref="TwosFromCustomer"/>
        /// </summary>
        private int twosFromCustomer = 0;

        /// <summary>
        /// The number of two dollar bills that the customer has given us.
        /// </summary>
        public int TwosFromCustomer
        {
            get => twosFromCustomer;
            set {
                twosFromCustomer = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Backing variable for <see cref="FivesFromCustomer"/>
        /// </summary>
        private int fivesFromCustomer = 0;

        /// <summary>
        /// The number of five dollar bills that the customer has given us.
        /// </summary>
        public int FivesFromCustomer
        {
            get => fivesFromCustomer;
            set {
                fivesFromCustomer = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Backing variable for <see cref="TensFromCustomer"/>
        /// </summary>
        private int tensFromCustomer = 0;

        /// <summary>
        /// The number of ten dollar bills that the customer has given us.
        /// </summary>
        public int TensFromCustomer
        {
            get => tensFromCustomer;
            set {
                tensFromCustomer = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Backing variable for <see cref="TwentiesFromCustomer"/>
        /// </summary>
        private int twentiesFromCustomer = 0;

        /// <summary>
        /// The number of twenty dollar bills that the customer has given us.
        /// </summary>
        public int TwentiesFromCustomer
        {
            get => twentiesFromCustomer;
            set {
                twentiesFromCustomer = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Backing variable for <see cref="FiftiesFromCustomer"/>
        /// </summary>
        private int fiftiesFromCustomer = 0;

        /// <summary>
        /// The number of fifty dollar bills that the customer has given us.
        /// </summary>
        public int FiftiesFromCustomer
        {
            get => fiftiesFromCustomer;
            set {
                fiftiesFromCustomer = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Backing variable for <see cref="HundredsFromCustomer"/>
        /// </summary>
        private int hundredsFromCustomer = 0;

        /// <summary>
        /// The number of hundred dollar bills that the customer has given us.
        /// </summary>
        public int HundredsFromCustomer
        {
            get => hundredsFromCustomer;
            set {
                hundredsFromCustomer = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The number of pennies that we owe the customer as change.
        /// </summary>
        public int PenniesAsChange { get; private set; } = 0;

        /// <summary>
        /// The number of nickels that we owe the customer as change.
        /// </summary>
        public int NickelsAsChange { get; private set; } = 0;

        /// <summary>
        /// The number of dimes that we owe the customer as change.
        /// </summary>
        public int DimesAsChange { get; private set; } = 0;

        /// <summary>
        /// The number of quarters that we owe the customer as change.
        /// </summary>
        public int QuartersAsChange { get; private set; } = 0;

        /// <summary>
        /// The number of one dollar bills that we owe the customer as change.
        /// </summary>
        public int OnesAsChange { get; private set; } = 0;

        /// <summary>
        /// The number of two dollar bills that we owe the customer as change.
        /// </summary>
        public int TwosAsChange { get; private set; } = 0;

        /// <summary>
        /// The number of five dollar bills that we owe the customer as change.
        /// </summary>
        public int FivesAsChange { get; private set; } = 0;

        /// <summary>
        /// The number of ten dollar bills that we owe the customer as change.
        /// </summary>
        public int TensAsChange { get; private set; } = 0;

        /// <summary>
        /// The number of twenty dollar bills that we owe the customer as change.
        /// </summary>
        public int TwentiesAsChange { get; private set; } = 0;

        /// <summary>
        /// The number of fifty dollar bills that we owe the customer as change.
        /// </summary>
        public int FiftiesAsChange { get; private set; } = 0;

        /// <summary>
        /// The number of hundred dollar bills that we owe the customer as change.
        /// </summary>
        public int HundredsAsChange { get; private set; } = 0;
    }
}
