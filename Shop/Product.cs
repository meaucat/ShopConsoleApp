namespace Shop
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Manufacturer { get; set; }

        public Product(string name, double price, int quantity, string manufacturer)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            Manufacturer = manufacturer;
        }
    }
}
