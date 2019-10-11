using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sandbox;

namespace CustomListTests
{
    [TestClass]
    public class CustomListTestsAdd
    {
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
    }

    [TestClass]
    public class CustomListTestsRemove
    {
        [TestMethod]
        public void Delete_CheckCount_Test()
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

        [TestMethod]
        public void Delete_CapacityRemains_Test()
        {
            CustomList<int> testCustomList = new CustomList<int>();
            for (int i = 0; i < 8; i++)
            {
                testCustomList.Add(i);
            }
            int preTestCapacity = testCustomList.Capacity;
            testCustomList.Delete(0);
            int postTestCapacity = testCustomList.Capacity;
            Assert.AreEqual(preTestCapacity, postTestCapacity);
        }

        [TestMethod]
        public void Delete_ValueRemoved_Test()
        {
            //delete, value removed
            CustomList<int> testCustomList = new CustomList<int>();
            testCustomList.Add(7);
            testCustomList.Add(7);
            testCustomList.Add(7);
            testCustomList.Add(7);
            testCustomList.Add(0);
            testCustomList.Add(7);

            testCustomList.Delete(0);

            for (int i = 0; i < testCustomList.Count; i++)
            {
                Assert.IsFalse(testCustomList[i].Equals(0));
            }            
        }

        [TestMethod]
        public void Delete_IndexFilledByNext_Test()
        {
            //delete, index filled in
            CustomList<int> testCustomList = new CustomList<int>();
            for (int i = 0; i < 8; i++)
            {
                testCustomList.Add(i);
            }
            int preDeleteValue = testCustomList[3];
            int expected = 4;
            testCustomList.Delete(3);
            
            Assert.AreEqual(expected, testCustomList[3]);
        }        

    }

    [TestClass]
    public class CustomListTestsZipper
    {
        [TestMethod]
        public void Zipper_FirstIndicesMatch_Test()
        {
            CustomList<int> testCustomListOdd = new CustomList<int>() {1,3,5};
            CustomList<int> testCustomListEven = new CustomList<int>() {2,4,6};
            CustomList<int> testCustomListZippered = new CustomList<int>();

            for (int i = 0; i<testCustomListOdd.Count; i++)
            {
                testCustomListZippered.Add(testCustomListOdd[i]);
                testCustomListZippered.Add(testCustomListEven[i]);
            }

            Assert.AreEqual(testCustomListOdd[0], testCustomListZippered[0]);

        }

        [TestMethod]
        public void Zipper_LastIndicesMatch_Test()
        {
            CustomList<int> testCustomListOdd = new CustomList<int>() { 1, 3, 5 };
            CustomList<int> testCustomListEven = new CustomList<int>() { 2, 4, 6 };
            CustomList<int> testCustomListZippered = new CustomList<int>();

            testCustomListZippered = testCustomListZippered.Zip(testCustomListOdd, testCustomListEven);

            Assert.AreEqual(testCustomListEven[2], testCustomListZippered[5]);
        }

        [TestMethod]
        public void Zipper_Method_Test()
        {
            CustomList<int> testCustomListOdd = new CustomList<int>() { 1, 3, 5 };
            CustomList<int> testCustomListEven = new CustomList<int>() { 2, 4, 6 };
            CustomList<int> testCustomListZipperedExpected = new CustomList<int>() {1,2,3,4,5,6};
            CustomList<int> testCustomListZipperedActual = new CustomList<int>();

            testCustomListZipperedActual = testCustomListZipperedActual.Zip(testCustomListOdd, testCustomListEven);

            string tempExpected = testCustomListZipperedExpected.ToString();
            string tempActual = testCustomListZipperedActual.ToString();
            Assert.AreEqual(tempExpected, tempActual);

        }

        [TestMethod]
        public void Zipper_ListsDifferentLength_Test()
        {
            CustomList<int> testCustomListOdd = new CustomList<int>() { 1, 3, 5 };
            CustomList<int> testCustomListEven = new CustomList<int>() { 2, 4, 6, 8 };
            CustomList<int> testCustomListZipperedExpected = new CustomList<int>() { 1, 2, 3, 4, 5, 6 };
            CustomList<int> testCustomListZipperedActual = new CustomList<int>();

            testCustomListZipperedActual = testCustomListZipperedActual.Zip(testCustomListOdd, testCustomListEven);

            string tempExpected = testCustomListZipperedExpected.ToString();
            string tempActual = testCustomListZipperedActual.ToString();
            Assert.AreEqual(tempExpected, tempActual);
        }

        public void Zipper_5_Test()
        {
            //test    
        }
    }

    [TestClass]
    public class CustomListTestPlusOperatorOverload
    {
        [TestMethod]
        public void PlusOperator_SameType_Test()
        {
            //add two, same type
            CustomList<int> one = new CustomList<int>() { 1, 3, 5 };
            CustomList<int> two = new CustomList<int>() { 2, 4, 6 };
            CustomList<int> expected = new CustomList<int>() { 1, 3, 5, 2, 4, 6 };
            CustomList<int> actual = one + two;

            string expectedResults = expected.ToString();
            string actualResults = actual.ToString();

            Assert.AreEqual(expectedResults, actualResults);
        }

        [TestMethod]
        public void PlusOperator_2_Test()
        {
            //test 2/2
        }

    }

    [TestClass]
    public class CustomListTestMinusOperatorOverload
    {
        [TestMethod]
        public void MinusOperator_SameType_Test()
        {
            //'subtract' two, same type
            CustomList<int> one = new CustomList<int>() { 1, 3, 5 };
            CustomList<int> two = new CustomList<int>() { 2, 1, 6 };
            CustomList<int> expected = new CustomList<int>() { 1, 3, 5, 2, 4, 6 };

            CList<int> expected = one - two;
            //result has 3,5


            string expectedResults = expected.ToString();
            string actualResults = actual.ToString();

            Assert.AreEqual(expectedResults, actualResults);


        }

        [TestMethod]
        public void MinusOperator_DifferentType_Test()
        {
            //add two, diff type
        }

    }

    [TestClass]
    public class CustomListTestToStringOverload
    {
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

}
