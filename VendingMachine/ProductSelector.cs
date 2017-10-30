namespace VendingMachine
{
    public class ProductSelector
    {
        public Product DispenseProduct(Button button)
        {
            return GetProduct(button.Type);
        }

        private Product GetProduct(string type)
        {
            if (type == ButtonType.ColaButton)
                return DispenseCola();
            if (type == ButtonType.ChipsButton)
                return DispenseChips();
            if (type == ButtonType.CandyButton)
                return DispenseCandy();
            else
                return null;
        }

        private Product DispenseCola() =>
            new Product
            {
                Name = "Cola",
                Price = 1.00
            };

        private Product DispenseChips() =>
            new Product
            {
                Name = "Chips",
                Price = .50
            };


        private Product DispenseCandy() =>
            new Product
            {
                Name = "Candy",
                Price = .65
            };
    }
}