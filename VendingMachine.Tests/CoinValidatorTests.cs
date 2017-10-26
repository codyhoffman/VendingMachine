using NUnit.Framework;
using System.Collections.Generic;

namespace VendingMachine.Tests
{
    [TestFixture]
    public class CoinValidatorTests
    {
        private Coin Quarter()
        {
            return new Coin
            {
                Diameter = 24.26,
                Width = 1.75,
                Weight = 5.67
            };
        }
        private Coin Dime()
        {
            return new Coin
            {
                Diameter = 17.91,
                Width = 1.35,
                Weight = 2.268
            };
        }
        private Coin Nickel()
        {
            return new Coin
            {
                Diameter = 21.21,
                Width = 1.95,
                Weight = 5.00
            };
        }
        private Coin Penny()
        {
            return new Coin
            {
                Diameter = 15.00,
                Width = 1.55,
                Weight = 3.35
            };
        }

        [Test]
        public void givenValidQuarterItReturnsTheValueOfDecimal25()
        {
            var coinValidator = new CoinValidator();
            
            var validatedCoin = coinValidator.DetermineCoinValue(Quarter());

            Assert.AreEqual(.25, validatedCoin.Value);
        }
        [Test]
        public void givenNickelDimeAndQuarterRespectiveValuesAreSet()
        {
            var coinValidator = new CoinValidator();

            var validatedQuarter = coinValidator.DetermineCoinValue(Quarter());
            var validatedDime = coinValidator.DetermineCoinValue(Dime());
            var validatedNickel = coinValidator.DetermineCoinValue(Nickel());

            Assert.AreEqual(.25, validatedQuarter.Value);
            Assert.AreEqual(.10, validatedDime.Value);
            Assert.AreEqual(.05, validatedNickel.Value);
        }
        [Test]
        public void givenPennyTheValueIsSetToZeroAndShouldReturnFlagIsTrue()
        {
            var coinValidator = new CoinValidator();

            var validatedCoin = coinValidator.DetermineCoinValue(Penny());

            Assert.AreEqual(0.0, validatedCoin.Value);
            Assert.AreEqual(true, validatedCoin.ShouldBeReturned);
        }
        [Test]
        public void whenAValidCoinsValueIsSetItShouldNotBeReturned()
        {
            var coinValidator = new CoinValidator();

            var validatedCoin = coinValidator.DetermineCoinValue(Quarter());

            Assert.AreEqual(false, validatedCoin.ShouldBeReturned);
        }
    }
}
