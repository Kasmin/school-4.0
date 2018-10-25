using System;

namespace DiscountСalculator
{
    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }

        //public int DiscountValue { get; set; }
        //public DateTime? StartSellDate { get; set; }
        //public DateTime? EndSellDate { get; set; }

        //public int CalculateDiscountPrice()
        //{
        //    return DiscountValue != 0 &&
        //            StartSellDate.HasValue &&
        //            EndSellDate.HasValue &&
        //            StartSellDate <= DateTime.UtcNow &&
        //            EndSellDate >= DateTime.UtcNow
        //        ? Price - (Price * DiscountValue / 100)
        //        : Price;
        //}

        //public string GetSellInformation()
        //{
        //    return DiscountValue != 0 && StartSellDate.HasValue && EndSellDate.HasValue
        //        ? $"На данный товар действует скидка {DiscountValue}% в период с {StartSellDate.Value.ToShortDateString()} по {EndSellDate.Value.ToShortDateString()}. " +
        //            $"Сумма с учётом скидки - {CalculateDiscountPrice()}р."
        //        : "В настоящий момент на данный товар нет скидок.";
        //}
    }        
}
