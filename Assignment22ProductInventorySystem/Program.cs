using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Assignment22ProductInventorySystem
{
    // Represents a product in the inventory
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"{Id}, {Name}, Qty: {Quantity}, Price: ${Price}";
        }
    }

    // Handles inventory operations with JSON persistence and CSV/JSON conversion
    public class InventoryManager
    {
        private readonly string jsonFilePath;

        public InventoryManager(string filePath)
        {
            jsonFilePath = filePath;

            // Initialize file if missing
            if (!File.Exists(jsonFilePath))
            {
                File.WriteAllText(jsonFilePath, "[]");
            }
        }

        public List<Product> LoadInventory()
        {
            string json = File.ReadAllText(jsonFilePath);
            return JsonSerializer.Deserialize<List<Product>>(json) ?? new List<Product>();
        }

        public void SaveInventory(List<Product> products)
        {
            string json = JsonSerializer.Serialize(products, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(jsonFilePath, json);
        }

        public void AddProduct(Product product)
        {
            var products = LoadInventory();
            products.Add(product);
            SaveInventory(products);
        }

        public void DisplayInventory()
        {
            var products = LoadInventory();
            Console.WriteLine("\n=== Product Inventory ===");
            foreach (var p in products)
                Console.WriteLine(p);
        }

        // Converts current inventory JSON to CSV
        public void ConvertJsonToCsv(string csvFilePath)
        {
            var products = LoadInventory();
            using (var writer = new StreamWriter(csvFilePath))
            {
                writer.WriteLine("Id,Name,Quantity,Price");
                foreach (var p in products)
                {
                    writer.WriteLine($"{p.Id},{p.Name},{p.Quantity},{p.Price}");
                }
            }
        }

        // Converts CSV back to JSON format
        public void ConvertCsvToJson(string csvFilePath)
        {
            var products = new List<Product>();
            foreach (var line in File.ReadAllLines(csvFilePath).Skip(1))
            {
                var parts = line.Split(',');
                if (parts.Length == 4)
                {
                    products.Add(new Product
                    {
                        Id = int.Parse(parts[0]),
                        Name = parts[1],
                        Quantity = int.Parse(parts[2]),
                        Price = decimal.Parse(parts[3])
                    });
                }
            }
            SaveInventory(products);
        }
    }

    // Demonstration
    class Program
    {
        static void Main()
        {
            string jsonPath = "inventory.json";
            string csvPath = "inventory.csv";

            var manager = new InventoryManager(jsonPath);

            Console.WriteLine("Adding sample products...");
            manager.AddProduct(new Product { Id = 1, Name = "Laptop", Quantity = 10, Price = 950.50M });
            manager.AddProduct(new Product { Id = 2, Name = "Mouse", Quantity = 25, Price = 15.99M });
            manager.AddProduct(new Product { Id = 3, Name = "Keyboard", Quantity = 12, Price = 35.75M });

            manager.DisplayInventory();

            Console.WriteLine("\nConverting JSON to CSV...");
            manager.ConvertJsonToCsv(csvPath);
            Console.WriteLine("CSV file created successfully.");

            Console.WriteLine("\nConverting CSV back to JSON...");
            manager.ConvertCsvToJson(csvPath);
            manager.DisplayInventory();

            Console.WriteLine("\nAll operations completed successfully.");
        }
    }
}
