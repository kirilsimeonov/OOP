using System;
using System.Linq;
using System.Collections.Generic;


namespace GreedyTimes
{
    public class GreedyTimes
    {
        static void Main(string[] args)
        {
            long bagCapacity = long.Parse(Console.ReadLine());
            string[] safeItems = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var bag = new Dictionary<string, Dictionary<string, long>>();
            long gold = 0;
            long gems = 0;
            long cash = 0;

            for (int i = 0; i < safeItems.Length; i += 2)
            {
                string itemName = safeItems[i];
                long itemQuantity = long.Parse(safeItems[i + 1]);

                string treasureType = string.Empty;


                if (itemName.Length == 3)
                {
                    treasureType = "Cash";
                }
                else if (itemName.ToLower().EndsWith("gem"))
                {
                    treasureType = "Gem";
                }
                else if (itemName.ToLower() == "gold")
                {
                    treasureType = "Gold";
                }

              
                if (treasureType == "")
                {
                    continue;
                }
                else if (bagCapacity < (gold + gems + cash + itemQuantity))
                {
                    continue;
                }




               
                switch (treasureType)
                {
                    case "Gem":
                        if (!bag.ContainsKey("Gem"))
                        {
                            if (bag.ContainsKey("Gold"))
                            {
                                if (itemQuantity > gold)
                                {

                                    continue;
                                }
                                
                            }
                            else
                            {

                                continue;
                            }
                        }
                        else if (gems + itemQuantity > gold)
                        {

                            continue;
                        }
                        break;

                  
                    case "Cash":
                        if (!bag.ContainsKey("Cash"))
                        {
                            if (bag.ContainsKey("Gem"))
                            {
                                if (itemQuantity > gems)
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (cash + itemQuantity > gems)
                        {
                            continue;
                        }
                        break;

                }


                if (!bag.ContainsKey(treasureType))
                {
                    bag[treasureType] = new Dictionary<string, long>();
                }

                if (!bag[treasureType].ContainsKey(itemName))
                {
                    bag[treasureType][itemName] = 0;
                }




               
                bag[treasureType][itemName] += itemQuantity;


                if (treasureType == "Gold")
                {
                    gold += itemQuantity;
                }
                else if (treasureType == "Gem")
                {
                    gems += itemQuantity;
                }
                else if (treasureType == "Cash")
                {
                    cash += itemQuantity;
                }
            }







            foreach (var treasureType in bag)
            {
                Console.WriteLine($"<{treasureType.Key}> ${treasureType.Value.Values.Sum()}");

                foreach (var treasureItem in treasureType.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{treasureItem.Key} - {treasureItem.Value}");
                }
            }
        }
    }
}