namespace MarsRover.MarsRover_BLL.Command
{
    /// <summary>
    /// Create the Rover Command Object based on the given command
    /// </summary>
    public static class RoverCommandsFactory
    {
        /// <summary>
        /// Create a Rover Command Object
        /// </summary>
        /// <param name="rover">Rover object</param>
        /// <param name="enumCommand">Specif command to create</param>
        /// <param name="meter">Number of meter to move</param>
        /// <returns></returns>
        public static ICommand getCommand(IRover rover, EnumCommand enumCommand, int meter = 0)
        {
            ICommand roverCommand = null;
            switch (enumCommand)
            {
                case EnumCommand.Left:
                    roverCommand = new LeftCommand(rover);
                    break;

                case EnumCommand.Right:
                    roverCommand = new RightCommand(rover);
                    break;

                case EnumCommand.Forward:
                    roverCommand = new MoveForwardCommand(rover, meter);
                    break;
            }

            return roverCommand;
        }
    }
}