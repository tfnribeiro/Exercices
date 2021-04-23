using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadraticEquation
{
    public class QuadraticEquation
    {
        public static Tuple<double, double> FindRoots(double a, double b, double c)
        {
            if (a == 0) 
                return new Tuple<double, double>(double.NaN, double.NaN);
            double x1 = (-b + Math.Sqrt(Math.Pow(b, 2) - (4 * a * c))) / (2 * a);
            double x2 = (-b - Math.Sqrt(Math.Pow(b, 2) - (4 * a * c))) / (2 * a);

            var result = new Tuple<double, double>(x1, x2);
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Tuple<double, double> roots = QuadraticEquation.FindRoots(1, 2, 3);
            Console.WriteLine("Roots: " + roots.Item1 + ", " + roots.Item2);
            Console.ReadLine();
        }
    }
}
