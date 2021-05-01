using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainComposition
{
    public class TrainComposition
    {
        Wagon leftMost = null;
        Wagon rightMost = null;
        private class Wagon
        {
            public Wagon left { get; set; }
            public Wagon right { get; set; }
            public int id { get; set; }
            public Wagon(int id)
            {
                this.id = id;
                this.left = null;
                this.right = null;
            }
        }
        public void AttachWagonFromLeft(int wagonId)
        {
            Wagon newWagon = new Wagon(wagonId);
            if (leftMost == null)
            {
                leftMost = rightMost = newWagon;
            }
            else
            {
                newWagon.right = leftMost;
                leftMost.left = newWagon;
                leftMost = newWagon;
            }
        }

        public void AttachWagonFromRight(int wagonId)
        {
            Wagon newWagon = new Wagon(wagonId);
            if (rightMost == null)
            {
                leftMost = rightMost = newWagon;
            }
            else
            {
                newWagon.left = rightMost;
                rightMost.right = newWagon;
                rightMost = newWagon;
            }
        }
        
        public int DetachWagonFromLeft()
        {
            Wagon toReturn = leftMost;
            
            if (toReturn == null)
                return -1;
            else
            {
                leftMost = leftMost.right;
                return toReturn.id;
            }
        
        }

        public int DetachWagonFromRight()
        {
            Wagon toReturn = rightMost;
            if (toReturn == null)
                return -1;
            else
            {
                rightMost = rightMost.left;
                return toReturn.id;
            }
        }


    }
    class Program
    {
        public static void Main(string[] args)
        {
            TrainComposition train = new TrainComposition();

            Console.WriteLine(train.DetachWagonFromRight()); // 2
            Console.WriteLine(train.DetachWagonFromLeft()); // 11
            Console.Read();
        }
    }
}
