using System;

namespace Shop
{
    internal class Order
    {
        public Product[] OrderedProducts { get; set; }
        private double totalSum = 0;

        public Order()
        {
            OrderedProducts = new Product[0]; // Инициализируем пустой массив продуктов
        }

        public void AddProduct(Product product)
        {
            // Создаем новый массив на один элемент больше текущего
            Product[] newOrderedProducts = new Product[OrderedProducts.Length + 1];

            // Копируем существующие продукты в новый массив
            for (int i = 0; i < OrderedProducts.Length; i++)
            {
                newOrderedProducts[i] = OrderedProducts[i];
            }

            // Добавляем новый продукт в конец нового массива
            newOrderedProducts[newOrderedProducts.Length - 1] = product;

            // Обновляем ссылку на массив OrderedProducts
            OrderedProducts = newOrderedProducts;
        }

        public void viewCart()
        {
            totalSum = 0;
            foreach (var item in OrderedProducts)
            {
                Console.WriteLine(item.Name + " || Цена: " + item.Price);
                totalSum = totalSum + item.Price;
            }
            Console.WriteLine("Ваша итоговая сумма: " + totalSum + "\n");
        }

        public void viewBalance()
        {
            double balance = 1000;
            double remainingBalance = balance - totalSum;
            Console.WriteLine("Ваш текущий баланс: " + remainingBalance);
            if(remainingBalance < 0)
            {
                Console.WriteLine("У вас недостаточно кредитов");
            }
        }
    }
}

