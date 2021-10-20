using MarsRover.MarsRover_BLL.Models;

namespace MarsRover.MarsRover_BLL.Control
{
    /// <summary>
    /// South Direction of Rover
    /// </summary>
    internal class SouthDirection : RoverControl
    {
        /// <summary>
        /// Contrctor the Initalise the Value
        /// </summary>
        /// <param name="vehicle">Rover</param>
        public SouthDirection(IRover vehicle) : base(vehicle)
        {
            this.moventIncrementValue = 1;
            this.direction = EnumDirection.South;
        }

        /// <summary>
        /// Move the Rover by given meters based on the South direction of the rover
        /// </summary>
        /// <param name="meters">Given meters to move</param>
        /// <returns>new positon of the rover</returns>
        public override Position MoveForward(int meters)
        {
            Position newpos = this.rover.GetPosition().Clone();
            newpos.x = this.rover.GetPosition().x + (meters * this.moventIncrementValue);
            return newpos;
        }
    }
}