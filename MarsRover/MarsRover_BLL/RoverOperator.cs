using MarsRover.MarsRover_BLL.Command;
using System;
using System.Collections.Generic;

namespace MarsRover.MarsRover_BLL
{
    /// <summary>
    /// Rover Operator - Invoker of Commands
    /// </summary>
    public class RoverOperator
    {
        /// <summary>
        /// List of Command to be executed
        /// </summary>
        private List<ICommand> command;

        /// <summary>
        /// Max Command batch Size
        /// </summary>
        private int MaxBatchmandHandle;

        /// <summary>
        /// Initialise the Command batch size to 5
        /// </summary>
        public RoverOperator()
        {
            this.MaxBatchmandHandle = 5;
        }

        /// <summary>
        /// Set the Command to be executed
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public string SetCommand(List<ICommand> command)
        {
            if (command != null && command.Count > this.MaxBatchmandHandle)
            {
                throw new Exception("Can't Take more than 5 Command");
            }
            else
            {
                this.command = command;
            }

            return String.Empty;
        }

        /// <summary>
        /// Execute the Rover command
        /// </summary>
        public void Execute()
        {
            if (this.command != null && this.command.Count > 0)
            {
                int i = 0;
                foreach (var item in this.command)
                {
                    // Set the Last command in the set to True
                    if (i == this.command.Count - 1)
                    {
                        item.IsLastBatchCommand = true;
                    }

                    // Eacute the command
                    var isExecuted = item.Execute();

                    // Skip the remaining command if the Rover can't excute
                    if (!isExecuted)
                    {
                        return;
                    }

                    i++;
                }

                // Clear the executed command list
                this.command.Clear();
            }
            else
            {
                throw new Exception("No Command to execute");
            }
        }

        /// <summary>
        /// Assign the Max Batch command
        /// </summary>
        /// <param name="maxBatchmandHandle">max batch command</param>
        public void SetRoverMaxBatchCommand(int maxBatchmandHandle)
        {
            this.MaxBatchmandHandle = maxBatchmandHandle;
        }
    }
}