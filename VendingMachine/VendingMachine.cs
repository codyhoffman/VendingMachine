namespace VendingMachine
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

        public void InsertCoin(double diameter, double width, double weight)
        {
            var coinValue = coinValidator.DetermineCoinValue(diameter, width, weight);

            UpdateCurrencyTotal(coinValue);
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
