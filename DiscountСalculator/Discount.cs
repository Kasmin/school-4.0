using System;

namespace DiscountСalculator
{
    class Discount : IDiscount
    {
        public int ProductPrice { get; set; }
        public DateTime? StartSellDate { get; set; }
        public DateTime? EndSellDate { get; set; }
        protected int ProductPriceAction;
        protected bool Discountable;
        protected int DiscountValue;

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
            return (endSellDate != DateTime.MinValue) ? endSellDate : DateTime.Now;
        }
        public void CalculateDiscountPrice()
        {
            Console.WriteLine("Введите сумму карты");
            bool isInt = int.TryParse(Console.ReadLine(), out var discountValue);

            while (!isInt)
            {
                Console.WriteLine("Значение должно быть числом");
                isInt = int.TryParse(Console.ReadLine(), out discountValue);
            }

            DiscountValue = discountValue;
            ProductPriceAction = NonSubZeroPrice(ProductPrice - discountValue);

            Discountable = discountValue != 0 &&
                    StartSellDate.HasValue &&
                    EndSellDate.HasValue &&
                    StartSellDate <= DateTime.Now &&
                    EndSellDate >= DateTime.Now
                ? true
                : false;
        }
        protected int NonSubZeroPrice(int testPrice)
        {
            return testPrice < 0 ? 0 : testPrice;
        }
        public string GetSellInformation()
        {
            return Discountable
                ? $"На данный товар действует скидка {DiscountValue} р. в период с {StartSellDate.Value.ToShortDateString()} по {EndSellDate.Value.ToShortDateString()}. " +
                    $"Сумма с учётом скидки - {ProductPriceAction}р."
                : "В настоящий момент на данный товар нет скидок.";
        }
    }
}
