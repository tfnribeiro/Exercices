using System;

namespace SortedSearch
{
    public class SortedSearch
    {
        public static int CountNumbers(int[] sortedArray, int lessThan)
        {
            int max = sortedArray.Length - 1;
            int min = 0;
            while (true)
            {
                if (max < 0)
                    // No elements are bigger than less than (max == -1)
                    return 0;
                else if (sortedArray[max] < lessThan)
                    return max+1;
                else
                {
                    int mid = (max + min) / 2;
                    // Rounds down so 5 + 2 / 2= 3
                    if (sortedArray[mid] == lessThan)
                    {
                        if (mid > 0 && mid+1 < sortedArray.Length &&
                            (sortedArray[mid + 1] == sortedArray[mid] ||
                            sortedArray[mid - 1] == sortedArray[mid]))
                        {
                            // Handle duplicates 
                            // (if one of the immediate next ones is the same as mid)
                            // Treat it as if > lessThan
                            max = mid - 1;
                            continue;
                        }
                        return mid;
                    }
                    else if (sortedArray[mid] > lessThan)
                        max = mid - 1;
                    else
                        min = mid + 1;

                }
            }
        }

    }
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(SortedSearch.CountNumbers(new int[] { 1, 1, 2, 2, 2, 3, 5, 8, 13, }, 3));
            Console.ReadKey();
        }
    }
}
