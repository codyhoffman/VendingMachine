using NUnit.Framework;

namespace VendingMachine.Tests
{
    [TestFixture]
    public class VendingMachineTests
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
        public void beforeThereAreCoinsInsertedTheMachineDisplaysInsertCoin()
        {
            var coinValidator = new CoinValidator();
            var vendingMachine = new VendingMachine(coinValidator);
            var display = vendingMachine.GetDisplay();

            Assert.AreEqual("INSERT COIN", display);
        }

        [Test]
        public void whenAQuarterIsInsertedtheMachineDisplaysTwentyFiveCents()
        {
            var coinValidator = new CoinValidator();
            var vendingMachine = new VendingMachine(coinValidator);

            vendingMachine.InsertCoin(Quarter());

            var display = vendingMachine.GetDisplay();

            Assert.AreEqual("$0.25", display);
        }

        //[Test]
        //public void whenAQuarterDimeAndNickelAreInsertedtheMachineDisplays40Cents()
        //{
        //    var vendingMachine = new VendingMachine();

        //    vendingMachine.InsertCoin(24.26, 1.75, 5.67);
        //    vendingMachine.InsertCoin(17.91, 1.35, 2.268);
        //    vendingMachine.InsertCoin(21.21, 1.95, 5.00);

        //    var display = vendingMachine.GetDisplay();

        //    Assert.AreEqual("$.40", display);
        //}
    }
}
