namespace MarsRover.MarsRover_BLL.Command
{
    /// <summary>
    /// Left Command - Trun the Rover to Left Side
    /// </summary>
    internal class LeftCommand : RoverCommand
    {
        /// <summary>
        /// Constractor to pass rover parameter to Rover abstract
        /// </summary>
        /// <param name="rover"></param>
        public LeftCommand(IRover rover) : base(rover)
        {
        }

        /// <summary>
        /// Execute the Left command by Receiver
        /// </summary>
        /// <returns>Execution successfull or not</returns>
        public override bool Execute()
        {
            this.rover.TurnLeft();
            if (this.IsLastBatchCommand) this.rover.NotifyCurrentPosition();
            return true;
        }
    }
}