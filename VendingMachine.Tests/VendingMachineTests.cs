using NUnit.Framework;

namespace VendingMachine.Tests
{
    [TestFixture]
    public class VendingMachineTests
    {
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

            vendingMachine.InsertCoin(24.260, .069, 5.670);

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
