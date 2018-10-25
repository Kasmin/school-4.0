using System;

namespace DiscountСalculator
{
    class DiscountPercent : Discount, IDiscount
    {
        new public void CalculateDiscountPrice()
        {
            Console.WriteLine("Введите процент скидки");
            bool isInt = int.TryParse(Console.ReadLine(), out var discountValue);

            while (!isInt)
            {
                Console.WriteLine("Значение должно быть числом");
                isInt = int.TryParse(Console.ReadLine(), out discountValue);
            }

            DiscountValue = discountValue;
            ProductPriceAction = NonSubZeroPrice(ProductPrice - ProductPrice * discountValue / 100);

            Discountable = discountValue != 0 &&
                    StartSellDate.HasValue &&
                    EndSellDate.HasValue &&
                    StartSellDate <= DateTime.Now &&
                    EndSellDate >= DateTime.Now
                ? true
                : false;
        }
        new public string GetSellInformation()
        {
            return Discountable
                ? $"На данный товар действует скидка {DiscountValue} % в период с {StartSellDate.Value.ToShortDateString()} по {EndSellDate.Value.ToShortDateString()}. " +
                    $"Сумма с учётом скидки - {ProductPriceAction}р."
                : "В настоящий момент на данный товар нет скидок.";
        }
    }
}
