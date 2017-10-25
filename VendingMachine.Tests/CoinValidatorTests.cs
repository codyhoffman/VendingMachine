using NUnit.Framework;

namespace VendingMachine.Tests
{
    [TestFixture]
    public class CoinValidatorTests
    {
        [Test]
        public void givenCorrectDiameterWidthAndWeightOfAQuarterReturnsDecimal25()
        {
            var coinValidator = new CoinValidator();

            var currencyValue = coinValidator.DetermineCoinValue(24.260, .069, 5.670);

            Assert.AreEqual(.25, currencyValue);
        }
    }
}
