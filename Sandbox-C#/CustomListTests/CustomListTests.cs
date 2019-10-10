using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sandbox;

namespace CustomListTests
{
    [TestClass]
    public class CustomListTestsInteger
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
            CustomList<int> testCustomList = new CustomList<int>();
            int expected = 1;
            int actual;

            // act
            testCustomList.Add(234);
            actual = testCustomList.Count;

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
            for (int i = 0; i < 10; i++)
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
            int expected = 7;
            int actual;

            //act
            for (int i = 0; i < 10; i++)
            {
                testCustomList.Add(i);
            }

            actual = testCustomList[7];

            //assert
            Assert.AreEqual(expected, actual);


        }

        [TestMethod]
        public void Int_ToStringOverride_Test()
        {
            string expected = "777";
            CustomList<int> testCustomList = new CustomList<int>();
            for (int i = 0; i < 3; i++)
            {
                testCustomList.Add(7);
            }

            string testResult = testCustomList.ToString();

            Assert.AreEqual(expected, testResult);
        }

        [TestMethod]
        public void Delete_Test()
        {
            CustomList<int> testCustomList = new CustomList<int>();

            for (int i = 0; i < 6; i++)
            {
                testCustomList.Add(i);
            }

            int preTestCount = testCustomList.Count;

            testCustomList.Delete(3);

            int postTestCount = testCustomList.Count;

            Assert.IsTrue(preTestCount > postTestCount);
        }
    }

    [TestClass]
    public class CustomListTestsString
    {
        [TestMethod]
        public void String_Add_Method_Test()
        {
            //arrange
            CustomList<string> testCustomList = new CustomList<string>();
            int tempCount = testCustomList.Count;
            string tempString = "zero";

            //act
            testCustomList.Add(tempString);

            //assert
            Assert.IsTrue(tempString == testCustomList[0]);
        }
        [TestMethod]
        public void String_AddMultiple_Method_Test()
        {
            //arrange
            CustomList<string> testCustomList = new CustomList<string>();
            int tempCount = testCustomList.Count;
            string tempString1 = "one";
            string tempString2 = "two";

            //act
            testCustomList.Add(tempString1);
            testCustomList.Add(tempString2);

            //assert
            Assert.IsTrue(tempString2 == testCustomList[1]);
        }

        [TestMethod]
        public void String_ToStringOverride_Test()
        {
            string expected = "xxx";
            CustomList<string> testCustomList = new CustomList<string>();
            for (int i = 0; i < 3; i++)
            {
                testCustomList.Add("x");
            }

            string testResult = testCustomList.ToString();

            Assert.AreEqual(expected, testResult);
        }
    }

    [TestClass]
    public class CustomListTestsZipper
    {
        [TestMethod]
        public void Zipper_Test()
        {
            CustomList<int> testCustomListOdd = new CustomList<int>() {1,3,5};
            CustomList<int> testCustomListEven = new CustomList<int>() {2,4,6};
            CustomList<int> testCustomListZippered = new CustomList<int>();

            //testCustomListOdd.Add(1);
            //testCustomListOdd.Add(3);
            //testCustomListOdd.Add(5);

            //testCustomListEven.Add(2);
            //testCustomListEven.Add(4);
            //testCustomListEven.Add(6);



            for (int i = 0; i<testCustomListOdd.Count; i++)
            {
                testCustomListZippered.Add(testCustomListOdd[i]);
                testCustomListZippered.Add(testCustomListEven[i]);
            }

            Assert.AreEqual(testCustomListOdd[0], testCustomListZippered[0]);
            Assert.AreEqual(testCustomListEven[2], testCustomListZippered[5]);

        }
    }

   
}
