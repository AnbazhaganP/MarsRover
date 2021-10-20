using MarsRover.MarsRover_BLL.Control;
using MarsRover.MarsRover_BLL.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRover.Test
{
    /// <summary>
    /// Test the Utility Logic of direction change
    /// </summary>
    [TestClass]
    public class UtilityLogicTest
    {
        [DataTestMethod]
        [DataRow(EnumDirection.South, EnumDirection.East)]
        [DataRow(EnumDirection.East, EnumDirection.North)]
        [DataRow(EnumDirection.North, EnumDirection.West)]
        [DataRow(EnumDirection.West, EnumDirection.South)]
        public void DirectionTurnLeftTest(EnumDirection direction, EnumDirection expecteddirection)
        {
            var actualValue = Utility.TurnLeft(direction);
            Assert.AreEqual(expecteddirection, actualValue);
        }

        [DataTestMethod]
        [DataRow(EnumDirection.South, EnumDirection.West)]
        [DataRow(EnumDirection.East, EnumDirection.South)]
        [DataRow(EnumDirection.North, EnumDirection.East)]
        [DataRow(EnumDirection.West, EnumDirection.North)]
        public void DirectionTurnRightTest(EnumDirection direction, EnumDirection expecteddirection)
        {
            var actualValue = Utility.TurnRight(direction);
            Assert.AreEqual(expecteddirection, actualValue);
        }
    }
}