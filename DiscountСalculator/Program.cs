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

        private static string MakeDiscount(Product product)
        {
            Discount discountCard = null;
            DiscountPercent discountPercent = null;
            DiscountAmount discountAmount = null;

            Console.WriteLine("Выберите тип скидки:");
            Console.WriteLine("1 - Подарочная карта");
            Console.WriteLine("2 - % от стоимости");
            Console.WriteLine("3 - сумма от стоимости");

            int.TryParse(Console.ReadLine(), out var answer);

            switch (answer)
            {
                case 1:
                    discountCard = new Discount();
                    discountCard.ProductPrice = product.Price;
                    discountCard.StartSellDate = discountCard.CalculateDateStart();
                    discountCard.EndSellDate = discountCard.CalculateDateEnd();
                    discountCard.CalculateDiscountPrice();
                    return discountCard.GetSellInformation();
                case 2:
                    discountPercent = new DiscountPercent();
                    discountPercent.ProductPrice = product.Price;
                    discountPercent.StartSellDate = discountPercent.CalculateDateStart();
                    discountPercent.EndSellDate = discountPercent.CalculateDateEnd();
                    discountPercent.CalculateDiscountPrice();
                    return discountPercent.GetSellInformation();
                case 3:
                    discountAmount = new DiscountAmount();
                    discountAmount.ProductPrice = product.Price;
                    discountAmount.CalculateDiscountPrice();
                    return discountAmount.GetSellInformation();
                default:
                    Console.WriteLine("Кажется вы ошиблись. Попробуйте еще.");
                    break;
            }

            //discount.ProductPrice = product.Price;
            //discount.StartSellDate = discount.CalculateDateStart();
            //discount.EndSellDate = discount.CalculateDateEnd();
            //discount.CalculateDiscountPrice();

            //return discount;
            return "";
        }


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

            var sellInformation = MakeDiscount(product);

            Console.WriteLine($"Вы успешно добавили новый продукт: {product.Name}, стоимость - {product.Price}р. {sellInformation}");
        }
    }
}
