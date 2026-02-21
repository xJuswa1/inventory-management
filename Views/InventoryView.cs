using System;
using Services;

namespace Views
{
    public class InventoryView
    {
        private InventoryService inventoryService;

        public InventoryView()
        {
            inventoryService = new InventoryService();
        }

        public void Run()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("==== Inventory Menu ====");
                Console.WriteLine("1. View Inventory");
                Console.WriteLine("2. Update Stock");
                Console.WriteLine("3. Reset Inventory");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option: ");

                string input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case "1":
                        ViewInventory();
                        break;

                    case "2":
                        UpdateStock();
                        break;

                    case "3":
                        inventoryService.ResetInventory();
                        Console.WriteLine("Inventory has been reset to initial stock.\n");
                        break;

                    case "4":
                        exit = true;
                        Console.WriteLine("Exiting program...");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.\n");
                        break;
                }
            }
        }

        private void ViewInventory()
        {
            string[] products = inventoryService.GetProductNames();
            int[] stock = inventoryService.GetStock();

            Console.WriteLine("==== Current Inventory ====");
            for (int i = 0; i < products.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {products[i]}: {stock[i]} in stock");
            }
            Console.WriteLine();
        }

        private void UpdateStock()
        {
            string[] products = inventoryService.GetProductNames();
            int[] stock = inventoryService.GetStock();

            Console.WriteLine("Select a product to update stock:");
            for (int i = 0; i < products.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {products[i]} (Current stock: {stock[i]})");
            }
            Console.Write("Enter product number: ");

            if (int.TryParse(Console.ReadLine(), out int productNumber) &&
                productNumber >= 1 && productNumber <= products.Length)
            {
                Console.Write("Enter new stock quantity: ");
                if (int.TryParse(Console.ReadLine(), out int newStock) && newStock >= 0)
                {
                    int currentStock = stock[productNumber - 1];
                    int difference = newStock - currentStock;

                    inventoryService.UpdateStock(products[productNumber - 1], difference);
                    Console.WriteLine($"{products[productNumber - 1]} stock updated to {newStock}.\n");
                }
                else
                {
                    Console.WriteLine("Invalid stock quantity.\n");
                }
            }
            else
            {
                Console.WriteLine("Invalid product selection.\n");
            }
        }
    }
}