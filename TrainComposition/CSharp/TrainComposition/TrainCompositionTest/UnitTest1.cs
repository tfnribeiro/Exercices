﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainComposition;

namespace TrainComposition
{
    [TestClass]
    public class TrainCompositionTest
    {
        [TestMethod]
        public void Base_Case()
        {
            TrainComposition train = new TrainComposition();
            train.AttachWagonFromLeft(7);
            train.AttachWagonFromLeft(13);

            Assert.AreEqual(7, train.DetachWagonFromRight());
            Assert.AreEqual(13, train.DetachWagonFromLeft());
        }
        [TestMethod]
        public void Empty_Case()
        {
            // If train empty -1 is return;
            TrainComposition train = new TrainComposition();
            Assert.AreEqual(-1, train.DetachWagonFromRight());
        }
        [TestMethod]
        public void Multiple_Wagons()
        {
            // If train empty -1 is return;
            TrainComposition train = new TrainComposition();
            train.AttachWagonFromLeft(1);
            train.AttachWagonFromLeft(2);
            train.AttachWagonFromLeft(3);
            train.AttachWagonFromLeft(4);
            train.AttachWagonFromLeft(5);
            train.AttachWagonFromLeft(6);
            train.AttachWagonFromLeft(7);
            train.AttachWagonFromLeft(8);
            Assert.AreEqual(1, train.DetachWagonFromRight());
            Assert.AreEqual(8, train.DetachWagonFromLeft());
        }
        [TestMethod]
        public void Alternate_Wagons()
        {
            // If train empty -1 is return;
            TrainComposition train = new TrainComposition();
            train.AttachWagonFromLeft(1);
            train.AttachWagonFromRight(2);
            train.AttachWagonFromLeft(3);
            train.AttachWagonFromRight(4);
            train.AttachWagonFromLeft(5);
            train.AttachWagonFromRight(6);
            train.AttachWagonFromLeft(7);
            train.AttachWagonFromRight(8);
            Assert.AreEqual(8, train.DetachWagonFromRight());
            Assert.AreEqual(7, train.DetachWagonFromLeft());
            Assert.AreEqual(6, train.DetachWagonFromRight());
            Assert.AreEqual(5, train.DetachWagonFromLeft());
        }
        [TestMethod]
        public void Train_Becomes_Empty_When_All_Wagons_Removed()
        {
            // If train empty -1 is return;
            TrainComposition train = new TrainComposition();
            train.AttachWagonFromLeft(1);
            train.AttachWagonFromLeft(2);
            train.AttachWagonFromLeft(3);
            train.AttachWagonFromLeft(4);
            train.AttachWagonFromLeft(5);
            train.AttachWagonFromLeft(6);
            train.AttachWagonFromLeft(7);
            train.AttachWagonFromLeft(8);
            int count = 0;
            int wagon = -1;
            do
            {
                wagon = train.DetachWagonFromLeft();
                if (wagon != -1)
                    count++;
            } while (wagon != -1);
            Assert.AreEqual(-1, train.DetachWagonFromLeft());
            Assert.AreEqual(8, count);
        }
    }
}