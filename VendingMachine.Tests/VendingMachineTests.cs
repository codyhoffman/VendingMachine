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
            var productSelector = new ProductSelector();
            var vendingMachine = new VendingMachine(coinValidator, productSelector);
            var display = vendingMachine.GetDisplay();

            Assert.AreEqual("INSERT COIN", display);
        }

        [Test]
        public void whenAQuarterIsInsertedtheMachineDisplaysTwentyFiveCents()
        {
            var coinValidator = new CoinValidator();
            var productSelector = new ProductSelector();
            var vendingMachine = new VendingMachine(coinValidator, productSelector);

            vendingMachine.InsertCoin(Quarter());

            var display = vendingMachine.GetDisplay();

            Assert.AreEqual("$0.25", display);
        }

        [Test]
        public void whenAQuarterDimeAndNickelAreInsertedtheMachineDisplays40Cents()
        {
            var coinValidator = new CoinValidator();
            var productSelector = new ProductSelector();
            var vendingMachine = new VendingMachine(coinValidator, productSelector);

            vendingMachine.InsertCoin(Quarter());
            vendingMachine.InsertCoin(Dime());
            vendingMachine.InsertCoin(Nickel());

            var display = vendingMachine.GetDisplay();

            Assert.AreEqual("$0.40", display);
        }

        [Test]
        public void givenAPennyAndQuarterItShouldDisplay25Cents()
        {
            var coinValidator = new CoinValidator();
            var productSelector = new ProductSelector();
            var vendingMachine = new VendingMachine(coinValidator, productSelector);

            vendingMachine.InsertCoin(Quarter());
            vendingMachine.InsertCoin(Penny());

            var display = vendingMachine.GetDisplay();

            Assert.AreEqual("$0.25", display);
        }

        [Test]
        public void givenAUnRecognizedCointItShouldDisplayInsertCoin()
        {
            var coinValidator = new CoinValidator();
            var productSelector = new ProductSelector();
            var vendingMachine = new VendingMachine(coinValidator, productSelector);
            var fakeCoin = new Coin
            {
                Weight = 1.00,
                Width = .1,
                Diameter = 10
            };

            vendingMachine.InsertCoin(fakeCoin);

            var display = vendingMachine.GetDisplay();

            Assert.AreEqual("INSERT COIN", display);
        }

        [Test]
        public void whenTheColaButtonIsPressedPRICEIsDisplayedThenInsertCoin()
        {
            var coinValidator = new CoinValidator();
            var productSelector = new ProductSelector();
            var vendingMachine = new VendingMachine(coinValidator, productSelector);
            var colaButton = new Button
            {
                IsPressed = true,
                Type = ButtonType.ColaButton
            };

            var product = vendingMachine.SelectProduct(colaButton);

            var display = vendingMachine.GetDisplayAfterSelection(product.Price);
            Assert.AreEqual("PRICE $1.00", display);

            display = vendingMachine.GetDisplay();
            Assert.AreEqual("INSERT COIN", display);
        }

        [Test]
        public void withSufficientFundsInsertedAndCandyIsSelectedTHANKYOUIsDisplayed()
        {
            var coinValidator = new CoinValidator();
            var productSelector = new ProductSelector();
            var vendingMachine = new VendingMachine(coinValidator, productSelector);
            var candyButton = new Button
            {
                IsPressed = true,
                Type = ButtonType.CandyButton
            };

            vendingMachine.InsertCoin(Quarter());
            vendingMachine.InsertCoin(Quarter());
            vendingMachine.InsertCoin(Dime());
            vendingMachine.InsertCoin(Nickel());

            var product = vendingMachine.SelectProduct(candyButton);

            var display = vendingMachine.GetDisplayAfterSelection(product.Price);
            Assert.AreEqual("THANK YOU", display);
        }

        [Test]
        public void withSufficientFundsInsertedAndChipsAreSelectedProductIsDispensed()
        {
            var coinValidator = new CoinValidator();
            var productSelector = new ProductSelector();
            var vendingMachine = new VendingMachine(coinValidator, productSelector);
            var chipsButton = new Button { IsPressed = true, Type = ButtonType.ChipsButton };
            var expectedProduct = new Product { Name = "Chips", Price = .50, IsDispensed = true };

            vendingMachine.InsertCoin(Quarter());
            vendingMachine.InsertCoin(Quarter());

            var product = vendingMachine.SelectProduct(chipsButton);

            Assert.AreEqual(expectedProduct.IsDispensed, product.IsDispensed);
            Assert.AreEqual(expectedProduct.Name, product.Name);
            Assert.AreEqual(expectedProduct.Price, product.Price);
        }

        [Test]
        public void withInsufficientFundsInsertedAndChipsAreSelectedProductIsNotDispensed()
        {
            var coinValidator = new CoinValidator();
            var productSelector = new ProductSelector();
            var vendingMachine = new VendingMachine(coinValidator, productSelector);
            var chipsButton = new Button { IsPressed = true, Type = ButtonType.ChipsButton };
            var expectedProduct = new Product { Name = "Chips", Price = .50, IsDispensed = false};

            vendingMachine.InsertCoin(Quarter());

            var product = vendingMachine.SelectProduct(chipsButton);

            Assert.AreEqual(expectedProduct.IsDispensed, product.IsDispensed);
            Assert.AreEqual(expectedProduct.Name, product.Name);
            Assert.AreEqual(expectedProduct.Price, product.Price);
        }
    }
}
