using System;

namespace VendingMachine
{
    public class CoinValidator
    {
        public double DetermineCoinValue(double diameter, double width, double weight)
        {
            //isQuarter(diameter, width, weight);
            //isDime(diameter, width, weight);
            //isNickel(diameter, width, weight);
            return .25;
        }

        private void isQuarter(double diameter, double width, double weight)
        {
            throw new NotImplementedException();
        }

        private void isDime(double diameter, double width, double weight)
        {
            throw new NotImplementedException();
        }

        private void isNickel(double diameter, double width, double weight)
        {
            throw new NotImplementedException();
        }
    }
}
