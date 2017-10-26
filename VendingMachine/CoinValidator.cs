using System;

namespace VendingMachine
{
    public class CoinValidator
    {
        public Coin DetermineCoinValue(Coin coin)
        {
            coin.Value = 0.0;

            if (IsQuarter(coin))
                coin.Value = .25;
            else if (IsDime(coin))
                coin.Value = .10;
            else if (IsNickel(coin))
                coin.Value = .05;
            else
                coin.ShouldBeReturned = true;

            return coin;
        }
        private bool IsQuarter(Coin coin)
        {
            if (coin.Diameter.Equals(24.26) && coin.Width.Equals(1.75) && coin.Weight.Equals(5.67))
                return true;

            return false;
        }

        private bool IsDime(Coin coin)
        {
            if (coin.Diameter.Equals(17.91) && coin.Width.Equals(1.35) && coin.Weight.Equals(2.268))
                return true;

            return false;
        }

        private bool IsNickel(Coin coin)
        {
            if (coin.Diameter.Equals(21.21) && coin.Width.Equals(1.95) && coin.Weight.Equals(5.00))
                return true;

            return false;
        }
    }
}
