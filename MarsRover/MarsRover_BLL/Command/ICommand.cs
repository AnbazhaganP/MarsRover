namespace MarsRover.MarsRover_BLL.Command
{
    /// <summary>
    /// Command Interfance for Rover
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Specify whether it's an last batch of command in the Give Set
        /// </summary>
        bool IsLastBatchCommand { get; set; }

        /// <summary>
        /// Invoke the Rover Operation
        /// </summary>
        /// <returns></returns>
        bool Execute();
    }
}