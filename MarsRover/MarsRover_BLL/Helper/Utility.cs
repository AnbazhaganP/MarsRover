using MarsRover.MarsRover_BLL.Control;
using MarsRover.MarsRover_BLL.Models;
using System.Collections.Generic;

namespace MarsRover.MarsRover_BLL.Helper
{
    /// <summary>
    /// Help the Rover object
    /// </summary>
    public static class Utility
    {
        /// <summary>
        /// List of Direction
        /// </summary>
        public static List<EnumDirection> items = new List<EnumDirection> { EnumDirection.North, EnumDirection.East, EnumDirection.South, EnumDirection.West };

        /// <summary>
        /// Get the Direction based on the Turn Left - Anit Clockwise Movement
        /// </summary>
        /// <param name="enumDirection">Given Direction</param>
        /// <returns>Desired direction based on the Rover direction</returns>
        public static EnumDirection TurnLeft(EnumDirection enumDirection)
        {
            var index = items.FindIndex(x => x == enumDirection);
            index--;
            if (index < 0)
                index = items.Count - 1;

            return items[index];
        }

        /// <summary>
        /// Get the Direction based on the Turn Right - Clockwise Movement
        /// </summary>
        /// <param name="enumDirection">Given Direction</param>
        /// <returns>Desired direction based on the Rover direction</returns>
        public static EnumDirection TurnRight(EnumDirection enumDirection)
        {
            var index = items.FindIndex(x => x == enumDirection);
            index++;

            if (index == 4)
                index = 0;

            return items[index];
        }

        /// <summary>
        /// Covert the Curret Postion of X,Y coordinate to number
        /// </summary>
        /// <param name="researchArea">Research Area</param>
        /// <param name="currentPosition">Current Postion</param>
        /// <returns>Number Position</returns>
        public static int CovertCurrentPositionToNumber(Position researchArea, Position currentPosition)
        {
            return ((currentPosition.x - 1) * researchArea.y) + currentPosition.y;
        }
    }
}