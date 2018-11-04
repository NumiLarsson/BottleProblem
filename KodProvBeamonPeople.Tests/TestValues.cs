using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KodProvBeamonPeople.Tests
{
    [TestClass]
    public class TestValues
    {
        [DataTestMethod]
        [DataRow("0", 0)]
        [DataRow("1", 4)]
        [DataRow("2", 2)]
        [DataRow("3", 1)]
        [DataRow("4", 6)]
        [DataRow("5", 1)]
        [DataRow("6", 3)]
        [DataRow("7", 5)]
        [DataRow("8", 2)]
        public void TestEverythingPassing(string input, int minActionsRequired)
        {
            string[] makeItArray = {input};
            int result = BottleProblem.Run(false, makeItArray);
            Assert.IsTrue(result == minActionsRequired);
        }

        [DataTestMethod]
        [DataRow("-1")]
        [DataRow("9")]
        public void TestFailingOutsideTargetNumbers(string input)
        {
            string[] makeItArray = {input};
            try
            {
                BottleProblem.Run(false, makeItArray);
            }
            catch (ArgumentException e)
            {
                return;
            }
            Assert.Fail();
        }

        [DataTestMethod]
        [DataRow(int.MaxValue)]
        public void TestMinAndMaxInt(int input)
        {
            TestFailingOutsideTargetNumbers(input.ToString());
        } 
    }

    //TODO: Write tests for the classes and static methods.
}
