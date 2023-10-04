using System;

namespace Shop
{
    internal class Program
    {

        static void Main(string[] args)
        {

            Customer customer = new Customer();

            Order order = new Order();

            Product[] products = new Product[10];
            products[0] = new Product("Шампунь", 120, 100, "Россия");
            products[1] = new Product("Чипсы", 60, 200, "США");
            products[2] = new Product("Крем", 90, 50, "Канада");
            products[3] = new Product("Колбаса халяль", 150, 200, "Россия");
            products[4] = new Product("Кока кола", 100, 330, "США");
            products[5] = new Product("Холодный чай", 110, 300, "США");
            products[6] = new Product("Жвачка", 25, 500, "Индия");
            products[7] = new Product("Печенье", 50, 120, "Россия");
            products[8] = new Product("Конфеты", 120, 200, "ОАЭ");
            products[9] = new Product("Кетчуп", 90, 200, "Швейцария");

            int select;
            int number = 1;
            int balance = 1000;
            string welcome = "Главное меню \nВыберите, что вы хотите сделать: \n1.Просмотреть список товаров \n2.Просмотреть корзину \n3.Посмотреть остаток на счете \n4.Выход\n";

            Console.WriteLine("Здравствуйте, как вас зовут?");
            customer.Name = Console.ReadLine();
            Console.WriteLine("Добро пожаловать, " + customer.Name);
            Console.WriteLine("Ваш баланс: " + balance + "\n\n");

            Console.WriteLine(welcome);

            while (true)
            {
                select = int.Parse(Console.ReadLine());

                switch (select)
                {
                    case 1:
                        while (true)
                        {
                            foreach (Product product in products)
                            {
                                Console.WriteLine(number++ + " " + product.Name + " || Цена: " + product.Price + " || Количество товара: " + product.Quantity);
                            }
                            number = 1;
                            Console.WriteLine();
                            Console.WriteLine("Выберите, что вы хотите сделать: \n1.Посмотреть информацию о конкретном товаре \n2.Вернуться на главное меню \n");
                                int selectOne = int.Parse(Console.ReadLine());
                                if (selectOne == 1)
                                {
                                    int userSelectProducts;
                                    Console.WriteLine("Выберите товар: \n");
                                        userSelectProducts = int.Parse(Console.ReadLine()) - 1;
                                        if (userSelectProducts >= 0 && userSelectProducts < products.Length)
                                        {
                                            Product selectedProduct = products[userSelectProducts];
                                            Console.WriteLine(selectedProduct.Name + " || Цена: " + selectedProduct.Price + " || Количество товара: " + selectedProduct.Quantity + " || Производитель: " + selectedProduct.Manufacturer + "\n");
                                            Console.WriteLine("Хотите добавить этот товар в корзину? \n1.Да \n2.Нет ");
                                            int selectCart;
                                            bool exitCartLoop = false;
                                            while (!exitCartLoop)
                                            {
                                                selectCart = int.Parse(Console.ReadLine());
                                                if (selectCart == 1)
                                                {
                                                    selectedProduct.Quantity -= 1;
                                                    order.AddProduct(selectedProduct);
                                                    Console.WriteLine("Выбирайте продукты из списка дальше: ");
                                                    exitCartLoop = true;
                                                }
                                                else if (selectCart == 2)
                                                {
                                                    exitCartLoop = true; // Выйти из вложенного цикла и вернуться к меню продуктов
                                                    Console.WriteLine("Выбирайте продукты из списка дальше: ");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Вы ввели что-то неверно, попробуйте еще раз\n");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Недопустимый выбор товара, попробуй еще раз \n");
                                        }
                                    
                                }
                                else if (selectOne == 2)
                                {
                                    Console.WriteLine(welcome);
                                    break; // Выйти из вложенного цикла и вернуться к главному меню
                                }
                                else
                                {
                                    Console.WriteLine("Вы ввели что-то неверно, попробуйте еще раз\n");
                                }
                            
                        }
                        break;


                    case 2:
                        Console.WriteLine("Ваша корзина: ");
                        order.viewCart();
                        Console.WriteLine("Введите 0, чтобы вернуться на главное меню\n");
                        int selectTwo = int.Parse(Console.ReadLine());
                        if (selectTwo == 0)
                        {
                            Console.WriteLine(welcome);
                            break; 
                        }
                        else
                        {
                            Console.WriteLine("Вы ввели что-то неверно, попробуйте еще раз\n");
                            Console.WriteLine(welcome);
                        }
                        break;

                    case 3:
                        order.viewBalance();
                        Console.WriteLine("Введите 0, чтобы вернуться на главное меню\n");
                        int selectThree = int.Parse(Console.ReadLine());
                        if (selectThree == 0)
                        {
                            Console.WriteLine(welcome);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Вы ввели что-то неверно, попробуйте еще раз\n");
                            Console.WriteLine(welcome);
                        }
                        break;

                    case 4:
                        Console.WriteLine("Выход из системы...");
                        break;

                    default:
                        Console.WriteLine("Некорректная цифра, попробуйте снова.");
                        break;
                }

                if (select == 4)
                {
                    break;
                }
            }


        }

    }
}
