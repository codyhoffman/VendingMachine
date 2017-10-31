using System;
using System.Collections.Generic;

namespace VendingMachine
{
    public class VendingMachine
    {
        private readonly CoinValidator coinValidator;
        private readonly ProductSelector productSelector;
        public List<Product> products;
        private string displayValue = "INSERT COIN";
        private double currencyTotal;

        public VendingMachine(CoinValidator coinValidator, ProductSelector productSelector)
        {
            this.coinValidator = coinValidator;
            this.productSelector = productSelector;
        }

        public string GetDisplayAfterSelection(double price)
        {
            if (currencyTotal >= price)
                return AdjustCurrencyTotal();

            return "PRICE $" + String.Format("{0:0.00}", price);
        }
        public string GetDisplay()
        {
            if (currencyTotal > 0)
                return "$" + String.Format("{0:0.00}", currencyTotal);

            displayValue = "INSERT COIN";
            return displayValue;
        }

        private string AdjustCurrencyTotal()
        {
            UpdateCurrencyTotal(0);
            return "THANK YOU";
        }

        public void InsertCoin(Coin coin)
        {
            var validatedCoin = coinValidator.DetermineCoinValue(coin);

            UpdateCurrencyTotal(validatedCoin.Value);
        }
   
        public Product SelectProduct(Button button)
        {
            var product = productSelector.DispenseProduct(button);
            return DispenseProductIfSufficientFunds(product);
        }

        private Product DispenseProductIfSufficientFunds(Product product)
        {
            if (currencyTotal < product.Price)
            {
                var productNotDispensed = productSelector.NoProduct();
                productNotDispensed.Price = product.Price;
                return productNotDispensed;
            }
            return product;
        }

        private void UpdateCurrencyTotal(double val)
        {
            if (val > 0 || currencyTotal > 0)
                currencyTotal += val;
            else
                currencyTotal = 0;
        }
    }
}
