using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// C# [,] multi-dimensional arrays
// [row,col]

namespace RoutePlanner
{
    public class RoutePlanner
    {
        private static Tuple<int, int> GetNextExplore(ref List<Tuple<int, int>> toExploreList)
        {
            Tuple<int, int> curExplore = null;
            if (toExploreList.Count > 0)
            {
                curExplore = toExploreList[0];
                toExploreList.RemoveAt(0);
                return curExplore;
            }
            else
                return null;
        }
        private static List<Tuple<int, int>> GetMoves(int curRow, int curCol, bool[,] mapMatrix)
        {
            List<Tuple<int, int>> nextMoves = new List<Tuple<int, int>>();
            // Generate possible paths
            // Going Right
            if (curRow + 1 < mapMatrix.GetLength(0))
            {
                Tuple<int, int> nodeToExplore = new Tuple<int, int>(curRow + 1, curCol);
                if (mapMatrix[nodeToExplore.Item1, nodeToExplore.Item2])
                    nextMoves.Add(nodeToExplore);
            }
            // Going down
            if (curCol + 1 < mapMatrix.GetLength(1))
            {
                Tuple<int, int> nodeToExplore = new Tuple<int, int>(curRow, curCol + 1);
                if (mapMatrix[nodeToExplore.Item1, nodeToExplore.Item2])
                    nextMoves.Add(nodeToExplore);
            }
            // Going Left
            if (curRow - 1 >= 0)
            {
                Tuple<int, int> nodeToExplore = new Tuple<int, int>(curRow - 1, curCol);
                if (mapMatrix[nodeToExplore.Item1, nodeToExplore.Item2])
                    nextMoves.Add(nodeToExplore);
            }
            // Going Up
            if (curCol - 1 >= 0)
            {
                Tuple<int, int> nodeToExplore = new Tuple<int, int>(curRow, curCol - 1);
                if (mapMatrix[nodeToExplore.Item1, nodeToExplore.Item2])
                    nextMoves.Add(nodeToExplore);
            }
            return nextMoves;
        }
        public static bool RouteExists(int fromRow, int fromColumn, int toRow, int toColumn,
                                          bool[,] mapMatrix)
        {
            List<Tuple<int, int>> toExplore = new List<Tuple<int, int>> { new Tuple<int, int>(fromRow, fromColumn) };
            HashSet<Tuple<int, int>> exploredNodes = new HashSet<Tuple<int, int>>();
            var curExplore = GetNextExplore(ref toExplore);
            while(curExplore != null)
            {
                if (exploredNodes.Contains(curExplore))
                {
                    curExplore = GetNextExplore(ref toExplore);
                    continue;
                }
                if (curExplore.Item1 == toRow && curExplore.Item2 == toColumn)
                    return true;
                foreach(var move in GetMoves(curExplore.Item1, curExplore.Item2, mapMatrix))
                {
                    toExplore.Add(move);
                }
                exploredNodes.Add(curExplore);
                curExplore = GetNextExplore(ref toExplore);
            }
            return false;
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            bool[,] mapMatrix = {
                {true,  true,  true,  true,  true,  true},
                {false, false, false, false, false, true },
                {true,  true, false, true, true, true },
                {false, true, false, true, true, true },
                {true,  true,  true,  true,  true,  true},
                {true,  true,  true,  true,  true,  true}
            };
            System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
            timer.Start();
            Console.WriteLine(RoutePlanner.RouteExists(0, 0, 0, 2, mapMatrix));
            timer.Stop();
            Console.WriteLine(timer.Elapsed);
            Console.ReadKey();
        }
    }
}
