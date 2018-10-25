using System;

namespace DiscountСalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вы хотите добавить новый продукт? 1 - да, 2 - нет");

            int.TryParse(Console.ReadLine(), out var answer);

            if (answer != 1)
                return;

            CreateProduct();

            Console.ReadLine();
        }

        private static void ChooseDiscount(Product product)
        {
            Console.WriteLine("Выберите тип скидки:");
            Console.WriteLine("1 - Подарочная карта");
            Console.WriteLine("2 - % от стоимости");
            Console.WriteLine("3 - сумма от стоимости");

            var discount = new Discount();

            int.TryParse(Console.ReadLine(), out var answer);
            //            Console.WriteLine(CreateDiscount(answer));

            
            
            product.Price = discount.CalculateDiscountPrice(product.Price);

            product.StartSellDate = discount.CalculateDateStart();

            product.EndSellDate = discount.CalculateDateEnd();
        }
/*
        private static void CreateDiscount(int typeOfDiscount)
        {
            if(typeOfDiscount == 1)
            {
                var discountCard = new DiscountCard();
                discount.Name = discountCard.Name;
            }
           
        }
*/
        private static void CreateProduct()
        {
            var product = new Product();

            Console.WriteLine("Введите название продукта");

            product.Name = Console.ReadLine();

            Console.WriteLine("Введите стоимость продукта");

            int.TryParse(Console.ReadLine(), out var price);

            while (price == 0)
            {
                Console.WriteLine("Стоимость продукта не была введена или она была введена с ошибкой. Пожалуйста, введите стоимость продукта ещё раз");

                int.TryParse(Console.ReadLine(), out price);
            }

            product.Price = price;

            ChooseDiscount(product);

            

            Console.WriteLine($"Вы успешно добавили новый продукт: {product.Name}, стоимость - {product.Price}р. {product.GetSellInformation()}");
        }
    }
}
