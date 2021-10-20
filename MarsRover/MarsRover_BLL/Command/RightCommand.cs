namespace MarsRover.MarsRover_BLL.Command
{
    /// <summary>
    /// Change the direction of the Rover to Right side
    /// </summary>
    internal class RightCommand : RoverCommand
    {
        /// <summary>
        /// Constractor - pass the argument to base class
        /// </summary>
        /// <param name="rover">Receiver Object</param>
        public RightCommand(IRover rover) :
        base(rover)
        {
        }

        /// <summary>
        /// Change the directon of the rover to Right and Notify the position if the command reach the last command
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            this.rover.TurnRight();
            if (this.IsLastBatchCommand) this.rover.NotifyCurrentPosition();
            return true;
        }
    }
}