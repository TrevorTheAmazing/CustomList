using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sandbox;

namespace CustomListTests
{
    [TestClass]
    public class CustomListTests
    {
        // unit test for adding multiple items to check position of last item
        // unit test for adding multiple items to check Count property
        // unit test for adding number of items beyond 'Capacity' but it still adds

        [TestMethod]
        public void Add_Method_Test()
        {
            //arrange
            CustomList<int> testCustomList = new CustomList<int>();
            int tempCount = testCustomList.Count;

            //act
            testCustomList.Add(7);

            //assert
            Assert.IsTrue(tempCount < testCustomList.Count);
        }

        [TestMethod]
        public void Add_Method_Increase_Capacity_Test()
        {
            //arrange
            CustomList<int> testCustomList = new CustomList<int>();
            int preTestCapacity = testCustomList.Capacity;

            //act
            testCustomList.Add(7);

            int postTestCapacity = testCustomList.Capacity;

            //assert
            Assert.IsTrue(postTestCapacity > preTestCapacity);

        }

        [TestMethod]
        public void Add_AddToEmptyList_ItemGoesToIndexZero()
        {
            //arrange
            CustomList<int> testCustomList = new CustomList<int>();
            int expected = 12;
            int actual;

            //act
            testCustomList.Add(12);
            actual = testCustomList[0];

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add_AddItemToList_CountIncrements()
        {
            // arrange
            CustomList<int> testList = new CustomList<int>();
            int expected = 1;
            int actual;

            // act
            testList.Add(234);
            actual = testList.Count;

            // assert
            Assert.AreEqual(expected, actual);
        }

        //Test adding 10 items check count
        [TestMethod]
        public void Add_AddMultipleItems_CheckCount()
        {
            //arrange
            CustomList<int> testCustomList = new CustomList<int>();
            int expected = 10;
            int actual;

            //act
            for (int i = 0; i<10; i++)
            {
                testCustomList.Add(i);
            }

            actual = testCustomList.Count;

            //assert
            Assert.AreEqual(expected, actual);
        }

        //Test adding 10 items check index value of 7
        [TestMethod]
        public void Add_AddMultipleItems_CheckSpecificIndex()
        {
            //arrange
            CustomList<int> testCustomList = new CustomList<int>();
            int expected = 6;
            int actual;

            //act
            for (int i=0; i<10; i++)
            {
                testCustomList.Add(i);
            }

            actual = testCustomList[7];

            //assert
            Assert.AreEqual(expected, actual);


        }
        
    }
}
