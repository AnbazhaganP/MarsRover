namespace MarsRover.MarsRover_BLL.Command
{
    /// <summary>
    /// Rover Command Abstract Class
    /// </summary>
    public abstract class RoverCommand : ICommand
    {
        protected IRover rover;

        /// <summary>
        /// Assign the Reciver Rover Object to used by subclass
        /// </summary>
        /// <param name="rover"></param>
        public RoverCommand(IRover rover)
        {
            this.rover = rover;
        }

        /// <summary>
        /// Specify whether the given command is last command in the set
        /// </summary>
        public bool IsLastBatchCommand { get; set; }

        /// <summary>
        /// Actuall execution which will be implemented by Concrete Command Class
        /// </summary>
        /// <returns></returns>
        public abstract bool Execute();
    }
}