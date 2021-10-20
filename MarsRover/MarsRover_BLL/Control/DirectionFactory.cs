namespace MarsRover.MarsRover_BLL.Control
{
    /// <summary>
    /// Direction State Factor
    /// </summary>
    public class DirectionFactory
    {
        /// <summary>
        /// Create the Rover Direction
        /// </summary>
        /// <param name="rover">Rover Object</param>
        /// <param name="enumDirection">Direction</param>
        /// <returns>Return Rover control object</returns>
        public static RoverControl getRoverDirection(IRover rover, EnumDirection enumDirection)
        {
            RoverControl roverDirection = null;
            switch (enumDirection)
            {
                case EnumDirection.East:
                    roverDirection = new EastDirection(rover);
                    break;

                case EnumDirection.North:
                    roverDirection = new NorthDirection(rover);
                    break;

                case EnumDirection.West:
                    roverDirection = new WestDirection(rover);
                    break;

                case EnumDirection.South:
                    roverDirection = new SouthDirection(rover);
                    break;
            }

            return roverDirection;
        }
    }
}