namespace MarsRover.MarsRover_BLL.Models
{
    /// <summary>
    /// Prototype Interface
    /// </summary>
    /// <typeparam name="T">Return the genric class</typeparam>
    public interface IPrototype<T>
    {
        T Clone();
    }
}