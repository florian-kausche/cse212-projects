using System;
using System.Collections.Generic;

class Program
{
    /// <summary>
    /// Finds the common elements between two sets (intersection)
    /// Time Complexity: O(n*m) where n and m are the sizes of the input lists
    /// Space Complexity: O(min(n,m)) for the result list
    /// </summary>
    /// <param name="set1">First input set</param>
    /// <param name="set2">Second input set</param>
    /// <returns>List containing elements present in both sets</returns>
    public static List<int> Intersection(List<int> set1, List<int> set2)
    {
        List<int> result = new List<int>();
        
        // Check each element from first set
        foreach (int item in set1)
        {
            // Only add item if it exists in set2 and hasn't been added yet
            // Contains() is O(n) for List, would be O(1) for HashSet
            if (set2.Contains(item) && !result.Contains(item))
            {
                result.Add(item);
            }
        }
        return result;
    }

    /// <summary>
    /// Combines two sets while removing duplicates (union)
    /// Time Complexity: O(n*m) due to Contains() checks
    /// Space Complexity: O(n+m) in worst case when sets are disjoint
    /// </summary>
    /// <param name="set1">First input set</param>
    /// <param name="set2">Second input set</param>
    /// <returns>List containing all unique elements from both sets</returns>
    public static List<int> Union(List<int> set1, List<int> set2)
    {
        List<int> result = new List<int>();

        // First phase: Add all unique elements from set1
        foreach (int item in set1)
        {
            // Check for duplicates before adding
            if (!result.Contains(item))
            {
                result.Add(item);
            }
        }

        // Second phase: Add all unique elements from set2
        foreach (int item in set2)
        {
            // Only add items from set2 that aren't already in result
            if (!result.Contains(item))
            {
                result.Add(item);
            }
        }

        return result;
    }

    static void Main(string[] args)
    {
        // Test case demonstration
        List<int> set1 = new List<int> { 1, 2, 3, 4, 5 };
        List<int> set2 = new List<int> { 4, 5, 6, 7, 8 };

        // Test intersection operation
        List<int> intersection = Intersection(set1, set2);
        Console.WriteLine("Intersection: " + string.Join(", ", intersection));  // Expected: 4, 5

        // Test union operation
        List<int> union = Union(set1, set2);
        Console.WriteLine("Union: " + string.Join(", ", union));  // Expected: 1, 2, 3, 4, 5, 6, 7, 8
    }
}