using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sandbox;

namespace SandboxTests
{
    [TestClass]
    public class WeatherTests
    {
        [TestMethod]
        public void SetCondition_RandomNumberIsZero_ConditionIsSunny()
        {
            // arrange
            Weather weather = new Weather();
            string expected = "Sunny";
            string actual;

            // act
            weather.SetCondition(0);
            actual = weather.condition;

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetCondition_RandomNumberIsOne_ConditionIsCloudy()
        {
            // arrange
            Weather weather = new Weather();
            string expected = "Cloudy";
            string actual;

            // act
            weather.SetCondition(1);
            actual = weather.condition;

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
