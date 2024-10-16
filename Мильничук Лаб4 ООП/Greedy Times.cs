using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        long capacity = long.Parse(Console.ReadLine());
        string[] treasureData = Console.ReadLine().Split();

        var bag = new Dictionary<string, Dictionary<string, long>>();
        long gold = 0;
        long gems = 0;
        long cash = 0;

        for (int i = 0; i < treasureData.Length; i += 2)
        {
            string item = treasureData[i];
            long quantity = long.Parse(treasureData[i + 1]);

            string itemType = GetItemType(item);

            if (itemType == "" || !CanAddToBag(bag, itemType, quantity, gold, gems, cash, capacity))
            {
                continue;
            }

            if (!bag.ContainsKey(itemType))
            {
                bag[itemType] = new Dictionary<string, long>();
            }

            if (!bag[itemType].ContainsKey(item))
            {
                bag[itemType][item] = 0;
            }

            bag[itemType][item] += quantity;

            if (itemType == "Gold")
            {
                gold += quantity;
            }
            else if (itemType == "Gem")
            {
                gems += quantity;
            }
            else if (itemType == "Cash")
            {
                cash += quantity;
            }
        }

        foreach (var type in bag.OrderByDescending(b => b.Value.Values.Sum()))
        {
            Console.WriteLine($"<{type.Key}> ${type.Value.Values.Sum()}");
            foreach (var item in type.Value.OrderByDescending(i => i.Key).ThenBy(i => i.Value))
            {
                Console.WriteLine($"##{item.Key} - {item.Value}");
            }
        }
    }

    static string GetItemType(string item)
    {
        if (item.Length == 3)
        {
            return "Cash";
        }
        else if (item.ToLower().EndsWith("gem") && item.Length >= 4)
        {
            return "Gem";
        }
        else if (item.ToLower() == "gold")
        {
            return "Gold";
        }

        return "";
    }

    static bool CanAddToBag(Dictionary<string, Dictionary<string, long>> bag, string itemType, long quantity, long gold, long gems, long cash, long capacity)
    {
        if (bag.Values.SelectMany(d => d.Values).Sum() + quantity > capacity)
        {
            return false;
        }

        switch (itemType)
        {
            case "Gem":
                return gems + quantity <= gold;
            case "Cash":
                return cash + quantity <= gems;
            default:
                return true;
        }
    }
}
