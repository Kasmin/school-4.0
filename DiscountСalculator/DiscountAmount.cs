using System;

namespace DiscountСalculator
{
    class DiscountAmount : Discount, IDiscount
    {
        new public void CalculateDiscountPrice()
        {
            Console.WriteLine("Введите сумму скидки");
            bool isInt = int.TryParse(Console.ReadLine(), out var discountValue);

            while (!isInt)
            {
                Console.WriteLine("Значение должно быть числом");
                isInt = int.TryParse(Console.ReadLine(), out discountValue);
            }

            DiscountValue = discountValue;
            ProductPriceAction = NonSubZeroPrice(ProductPrice - discountValue);

            Discountable = discountValue != 0 ? true: false;
        }
        new public string GetSellInformation()
        {
            return Discountable
                ? $"На данный товар действует скидка {DiscountValue}р. " +
                    $"Сумма с учётом скидки - {ProductPriceAction}р."
                : "В настоящий момент на данный товар нет скидок.";
        }
    }
}
