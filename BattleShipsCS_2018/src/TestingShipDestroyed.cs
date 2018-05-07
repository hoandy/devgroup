using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

    [TestFixture]
    class TestingShipDestroyed
    {
        [TestCase()]
        public void IsDestroyedTest()
        {
          Ship testShip = new Ship(ShipName.AircraftCarrier);
           for (int i = 0; i < 5; i++) { testShip.Hit(); }
           bool expected = true;
           bool actual = testShip.IsDestroyed;
          Assert.AreEqual(expected, actual);
          }
    }

