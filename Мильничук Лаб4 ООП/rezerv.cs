using System;

public enum Season
{
    Autumn = 1,
    Spring = 2,
    Winter = 3,
    Summer = 4
}

public enum DiscountType
{
    None = 0,
    SecondVisit = 10,
    VIP = 20
}

public class PriceCalculator
{
    public static decimal CalculateTotalPrice(decimal pricePerDay, int numberOfDays, Season season, DiscountType discountType)
    {
        decimal basePrice = pricePerDay * numberOfDays * (int)season;
        decimal discount = (decimal)discountType / 100;
        decimal totalPrice = basePrice * (1 - discount);
        return totalPrice;
    }
}

class Program
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();
        decimal pricePerDay = decimal.Parse(input[0]);
        int numberOfDays = int.Parse(input[1]);
        Season season = Enum.Parse<Season>(input[2]);
        DiscountType discountType = input.Length == 4 ? Enum.Parse<DiscountType>(input[3]) : DiscountType.None;

        decimal totalPrice = PriceCalculator.CalculateTotalPrice(pricePerDay, numberOfDays, season, discountType);
        Console.WriteLine($"{totalPrice:F2}");
    }
}
