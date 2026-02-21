namespace Services
{
    public class InventoryService
    {
        private string[,] products;
        private int[] initialStock;

        public InventoryService()
        {
            products = new string[2, 3];
            products[0, 0] = "Apples";
            products[0, 1] = "Milk";
            products[0, 2] = "Bread";

            products[1, 0] = "10";
            products[1, 1] = "5";
            products[1, 2] = "20";

            initialStock = new int[] { 10, 5, 20 };
        }

        public string[] GetProductNames()
        {
            int cols = products.GetLength(1);
            string[] names = new string[cols];
            for (int i = 0; i < cols; i++)
            {
                names[i] = products[0, i];
            }
            return names;
        }

        public int[] GetStock()
        {
            int cols = products.GetLength(1);
            int[] stock = new int[cols];
            for (int i = 0; i < cols; i++)
            {
                stock[i] = int.Parse(products[1, i]);
            }
            return stock;
        }
        public bool UpdateStock(string productName, int quantity)
        {
            int cols = products.GetLength(1);
            for (int i = 0; i < cols; i++)
            {
                if (products[0, i] == productName)
                {
                    int currentStock = int.Parse(products[1, i]);
                    products[1, i] = (currentStock + quantity).ToString();
                    return true;
                }
            }
            return false;
        }

        public void ResetInventory()
        {
            int cols = products.GetLength(1);
            for (int i = 0; i < cols; i++)
            {
                products[1, i] = initialStock[i].ToString();
            }
        }
    }
}