﻿namespace VendingMachine
{
    public class VendingMachine
    {
        private readonly CoinValidator coinValidator;
        private string displayValue = "INSERT COIN";
        private double currencyTotal;

        public VendingMachine(CoinValidator coinValidator)
        {
            this.coinValidator = coinValidator;
        }

        public string GetDisplay()
        {
            if (currencyTotal > 0)
                return "$" + currencyTotal.ToString();

            displayValue = "INSERT COIN";
            return displayValue;
        }

        public void InsertCoin(Coin coin)
        {
            var validatedCoin = coinValidator.DetermineCoinValue(coin);

            UpdateCurrencyTotal(validatedCoin.Value);
        }

        private void UpdateCurrencyTotal(double val)
        {
            if (val > 0)
                currencyTotal += val;
            else
                currencyTotal = 0;
        }
    }
}
