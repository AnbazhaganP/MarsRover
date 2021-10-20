namespace MarsRover.MarsRover_BLL.Models
{
    /// <summary>
    /// Position - Matrix X and Y Co-ordinate
    /// </summary>
    public class Position : IPrototype<Position>
    {
        public int x;
        public int y;

        /// <summary>
        /// Clone the object
        /// </summary>
        /// <returns></returns>
        public Position Clone()
        {
            return (Position)this.MemberwiseClone();
        }
    }
}