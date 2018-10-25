using System;

namespace DiscountСalculator
{
    class Discount : IDiscount
    {
        public DateTime? StartSellDate { get; set; }
        public DateTime? EndSellDate { get; set; }

        public DateTime? CalculateDateStart()
        {
            Console.WriteLine("Введите дату начала действия скидки");

            DateTime.TryParse(Console.ReadLine(), out var startSellDate);

            return (startSellDate != DateTime.MinValue) ? startSellDate : DateTime.Now;
        }
        public DateTime? CalculateDateEnd()
        {
            Console.WriteLine("Введите дату окончания действия скидки");

            DateTime.TryParse(Console.ReadLine(), out var endSellDate);

            return (endSellDate != DateTime.MinValue) ? EndSellDate : DateTime.Now;
        }
        public int CalculateDiscountPrice(int price)
        {
            Console.WriteLine("Введите сумму карты");
            bool isInt = int.TryParse(Console.ReadLine(), out var discountValue);

            while (!isInt)
            {
                Console.WriteLine("Значение должно быть числом");
                isInt = int.TryParse(Console.ReadLine(), out discountValue);
            }

            return discountValue != 0 &&
                    StartSellDate.HasValue &&
                    EndSellDate.HasValue &&
                    StartSellDate <= DateTime.UtcNow &&
                    EndSellDate >= DateTime.UtcNow
                ? price - discountValue
                : price;
        }

        public string GetSellInformation()
        {
            return "Скидка";
        }
    }
}
