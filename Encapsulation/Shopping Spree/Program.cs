using System;
using System.Linq;
using System.Collections.Generic;

namespace ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] peopleInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            string[] productsInput = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries);

            var people = new Dictionary<string, Person>();
            var products = new Dictionary<string, Product>();

            try
            {

            
            foreach (var item in peopleInput)
            {
                var currentPerson = item.Split('=', StringSplitOptions.RemoveEmptyEntries).ToArray();
                people.Add(currentPerson[0], new Person(currentPerson[0], decimal.Parse(currentPerson[1])));



            }
            foreach (var item in productsInput)
            {
                var currentProduct = item.Split('=', StringSplitOptions.RemoveEmptyEntries).ToArray();
                products.Add(currentProduct[0],new Product(currentProduct[0], decimal.Parse(currentProduct[1])));

            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command=="END")
                {
                    break;
                }
                var input = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string person = input[0];
                string product = input[1];

                people[person].Buy(products[product]);
                }
            foreach (var person in people)
            {
                if (person.Value.Products.Count>0)
                {
                    Console.WriteLine($"{person.Value.Name} - {string.Join(", ",person.Value.Products)}");
                        
                }
                else
                {
                    Console.WriteLine($"{person.Value.Name} - Nothing bought");
                }
            }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
