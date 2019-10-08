using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sandbox;

namespace SandboxTests
{
    [TestClass]
    public class StoreTests
    {
        [TestMethod]
        public void SellLemons_PlayerHasMoney_LemonCountIncreases()
        {
            // arrange
            Store store = new Store();
            Player player = new Player();
            int expected = 5;
            int actual;

            // act
            store.SellLemons(5, player);
            actual = player.inventory.lemonCount;

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SellLemons_PlayerDoesNotHaveMoney_LemonCountDoesNotIncrease()
        {
            // arrange
            Store store = new Store();
            Player player = new Player();
            player.inventory.wallet = 0;

            int expected = 0;
            int actual;

            // act
            store.SellLemons(5, player);
            actual = player.inventory.lemonCount;

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
