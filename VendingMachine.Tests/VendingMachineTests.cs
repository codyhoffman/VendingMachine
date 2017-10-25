using NUnit.Framework;

namespace VendingMachine.Tests
{
    [TestFixture]
    public class VendingMachineTests
    {
        [Test]
        public void whenThereAreNoCoinsInsertedTheMachineDisplaysInsertCoin()
        {
            var vendingMachine = new VendingMachine();
            var display = vendingMachine.GetDisplay();

            Assert.AreEqual("INSERT COIN", display);
        }
    }
}
