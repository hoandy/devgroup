using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace BattleShips
{

    [TestFixture()]
    public class ShipSizeTest
    {
        /*
        None = 0,
        Tug = 1,
        Submarine = 2,
        Destroyer = 3,
        Battleship = 4,
        AircraftCarrier = 5
        */

        [Test()]
        public void TestTug()
        {
            var s0 = new Ship(ShipName.Tug);
            int expected = 1;

            int actual = s0.Size;

            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void TestSubmarine()
        {
            var s0 = new Ship(ShipName.Submarine);
            int expected = 2;

            int actual = s0.Size;

            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void TestDestroyer()
        {
            var s0 = new Ship(ShipName.Destroyer);
            int expected = 3;

            int actual = s0.Size;

            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void TestBattleship()
        {
            var s0 = new Ship(ShipName.Battleship);
            int expected = 4;

            int actual = s0.Size;

            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void TestAircraftCarrier()
        {
            var s0 = new Ship(ShipName.AircraftCarrier);
            int expected = 5;

            int actual = s0.Size;

            Assert.AreEqual(expected, actual);
        }
    }
}
