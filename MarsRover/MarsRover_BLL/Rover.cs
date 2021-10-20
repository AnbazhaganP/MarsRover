using MarsRover.MarsRover_BLL.Control;
using MarsRover.MarsRover_BLL.Helper;
using MarsRover.MarsRover_BLL.Models;
using MarsRover.MarsRover_BLL.Notification;
using System;
using System.Collections.Generic;

namespace MarsRover.MarsRover_BLL
{
    /// <summary>
    /// Receiver - Rover
    /// </summary>
    public class Rover : IRover
    {
        /// <summary>
        /// Current Position
        /// </summary>
        private Position Position;

        /// <summary>
        /// Reserach are of the Rover
        /// </summary>
        private Position ResearchArea;

        /// <summary>
        /// Rover Control
        /// </summary>
        private RoverControl RoverControl;

        /// <summary>
        /// Observer List
        /// </summary>
        private List<IObserver> _observers = new List<IObserver>();

        /// <summary>
        /// Initalise the Rover with Default parameter
        /// </summary>
        public Rover()
        {
            this.ResearchArea = new Position { x = 100, y = 100 };
            this.RoverControl = DirectionFactory.getRoverDirection(this, EnumDirection.South);
            this.Position = new Position { x = 1, y = 1 };
        }

        /// <summary>
        /// Initalise the Rover with Research area and Starting Direction
        /// </summary>
        /// <param name="researchArea">Serach Area for the Rover</param>
        /// <param name="startingDirection">Starting Direction of the Rover</param>
        public Rover(Position researchArea, EnumDirection startingDirection)
        {
            this.ResearchArea = researchArea;
            this.RoverControl = DirectionFactory.getRoverDirection(this, startingDirection);
            this.Position = new Position { x = 1, y = 1 };
        }

        /// <summary>
        /// Attache the Observer to the List so that we can Notify
        /// </summary>
        /// <param name="observer"></param>
        public void Attach(IObserver observer)
        {
            this._observers.Add(observer);
        }

        /// <summary>
        /// Delete the Observers
        /// </summary>
        /// <param name="observer"></param>
        public void Deatach(IObserver observer)
        {
            this._observers.Remove(observer);
        }

        /// <summary>
        /// Get the Rover Current Position
        /// </summary>
        /// <returns></returns>
        public int GetCurrentPosition()
        {
            return Utility.CovertCurrentPositionToNumber(this.ResearchArea, this.Position);
        }

        /// <summary>
        /// Get the Position of the Rover
        /// </summary>
        /// <returns></returns>
        public Position GetPosition()
        {
            return this.Position;
        }

        /// <summary>
        /// Notify all the observers
        /// </summary>
        /// <param name="message">Message to be notified</param>
        private void Notify(String message)
        {
            foreach (var observer in this._observers)
            {
                observer.UpdateCurrentPosition(message);
            }
        }

        /// <summary>
        /// Notifiy the Current Postion
        /// </summary>
        public void NotifyCurrentPosition()
        {
            string message = $"Rover Current Position :- Direction: {this.RoverControl.direction.ToString()}, Position: {GetCurrentPosition()}";

            Notify(message);
        }

        /// <summary>
        /// Turn the Rover to Left side
        /// </summary>
        public void TurnLeft()
        {
            this.RoverControl = this.RoverControl.TurnLeft();
        }

        /// <summary>
        /// Turn the Rover to Right side
        /// </summary>
        public void TurnRight()
        {
            this.RoverControl = this.RoverControl.TrunRight();
        }

        /// <summary>
        /// Move the Rover to given meters
        /// </summary>
        /// <param name="meter">meters</param>
        public void MoveForward(int meter)
        {
            this.Position = this.RoverControl.MoveForward(meter);
        }

        /// <summary>
        /// Check whether the Rover can move forward
        /// </summary>
        /// <param name="meter"></param>
        /// <returns></returns>
        public bool CanForward(int meter)
        {
            var newRoverPosition = this.RoverControl.MoveForward(meter);

            // Check whether the Rover can move based on the given reasrch area and given meters
            if (newRoverPosition.x > 0
                && newRoverPosition.x <= this.ResearchArea.x
                && newRoverPosition.y > 0
                && newRoverPosition.y <= this.ResearchArea.y)
            {
                return true;
            }
            else
            {
                Notify("Rover halted and it can't venuture outside of exploration area");
                return false;
            };
        }
    }
}