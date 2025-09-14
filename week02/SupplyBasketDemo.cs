using System;
using System.Collections.Generic;

namespace GardenSimulator
{
    public class SupplyBasket
    {
        // The SupplyBasket class models the behavior of a supply basket in the Garden Simulator game.
        // It uses a Stack data structure to store piles of seeds, ensuring Last-In-First-Out (LIFO) behavior.
        // This is because the player can only plant seeds from the most recently added pile.

        // The time complexity of adding new seeds to the supply basket is O(1),
        // because pushing an item onto a stack is a constant-time operation.

        // The time complexity of removing seeds from the supply basket is O(1),
        // because popping an item from a stack is also a constant-time operation.

        // The time complexity of checking if the supply basket is empty is O(1),
        // because checking the count of a stack is a constant-time operation.

        private Stack<SeedPile> basket;

        public SupplyBasket()
        {
            basket = new Stack<SeedPile>();
        }

        // Add a new pile of seeds to the basket
        public void AddSeeds(string seedType, int quantity)
        {
            basket.Push(new SeedPile(seedType, quantity));
        }

        // Remove seeds from the basket (planting)
        public SeedPile RemoveSeeds()
        {
            if (basket.Count == 0)
            {
                throw new InvalidOperationException("The supply basket is empty.");
            }

            return basket.Pop();
        }

        // Check if the basket is empty
        public bool IsEmpty()
        {
            return basket.Count == 0;
        }

        // Peek at the top pile of seeds without removing it
        public SeedPile PeekSeeds()
        {
            if (basket.Count == 0)
            {
                throw new InvalidOperationException("The supply basket is empty.");
            }

            return basket.Peek();
        }
    }

    public class SeedPile
    {
        public string SeedType { get; }
        public int Quantity { get; set; }

        public SeedPile(string seedType, int quantity)
        {
            SeedType = seedType;
            Quantity = quantity;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SupplyBasket basket = new SupplyBasket();

            // Add seeds to the basket
            basket.AddSeeds("Pumpkin", 10);
            basket.AddSeeds("Tomato", 25);

            // Check if the basket is empty
            Console.WriteLine("Is the basket empty? " + basket.IsEmpty());

            // Peek at the top pile of seeds
            SeedPile topPile = basket.PeekSeeds();
            Console.WriteLine($"Top pile: {topPile.SeedType} with {topPile.Quantity} seeds");

            // Remove seeds (planting)
            SeedPile removedPile = basket.RemoveSeeds();
            Console.WriteLine($"Planted {removedPile.SeedType} seeds, quantity: {removedPile.Quantity}");

            // Check if the basket is empty after removing
            Console.WriteLine("Is the basket empty? " + basket.IsEmpty());
        }
    }
}