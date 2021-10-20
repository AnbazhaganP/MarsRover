namespace MarsRover.MarsRover_BLL.Command
{
    /// <summary>
    /// Move the Rover to specified meters
    /// </summary>
    internal class MoveForwardCommand : RoverCommand
    {
        /// <summary>
        /// Number of Meter to move the Rover
        /// </summary>
        private int moveMeter;

        /// <summary>
        /// Initalise the meter we wanted to move the rover
        /// </summary>
        /// <param name="rover">Receiver</param>
        /// <param name="meter">Numbver of meter to Move</param>
        public MoveForwardCommand(IRover rover, int meter) :
        base(rover)
        {
            this.moveMeter = meter;
        }

        /// <summary>
        /// Move the Rover to the specifed meter and check whether rover can execute
        /// </summary>
        /// <returns>Moment</returns>
        public override bool Execute()
        {
            if (CanExecute())
            {
                this.rover.MoveForward(this.moveMeter);
                if (this.IsLastBatchCommand) this.rover.NotifyCurrentPosition();
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Check whether the rover can move given meter, if not don't execute the command
        /// </summary>
        /// <returns>Movement status</returns>
        public bool CanExecute()
        {
            return this.rover.CanForward(this.moveMeter);
        }
    }
}