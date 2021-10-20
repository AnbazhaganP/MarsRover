using MarsRover.MarsRover_BLL.Models;

namespace MarsRover.MarsRover_BLL.Control
{
    /// <summary>
    /// East Direction state
    /// </summary>
    internal class EastDirection : RoverControl
    {
        /// <summary>
        /// East Direction
        /// </summary>
        /// <param name="vehicle">Rover</param>
        public EastDirection(IRover vehicle) : base(vehicle)
        {
            this.moventIncrementValue = 1;
            this.direction = EnumDirection.East;
        }

        /// <summary>
        /// Move the Rover based on the East Direction and return the new postion
        /// </summary>
        /// <param name="meters">Number of meter to move</param>
        /// <returns>New position</returns>
        public override Position MoveForward(int meters)
        {
            Position newpos = this.rover.GetPosition().Clone();
            newpos.y = this.rover.GetPosition().y + (meters * this.moventIncrementValue);
            return newpos;
        }
    }
}