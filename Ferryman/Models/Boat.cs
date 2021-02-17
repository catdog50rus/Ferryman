namespace Ferryman.Models
{
    public interface IBoat
    {
        /// <summary>
        /// Если значение true - лодка на правом берегу.
        /// Если значение false - лодка на левом берегу.
        /// </summary>
        public bool BoatPlace { get; set; }
    }
    
    
    public class Boat : IBoat
    {
        /// <summary>
        /// Если значение true - лодка на правом берегу
        /// Если значение false - лодка на левом берегу
        /// </summary>
        public bool BoatPlace { get; set; } = true;

        public override string ToString()
        {
            if (BoatPlace) return "Лодка на Правом берегу";
            else return "Лодка на Левом берегу";
        }
    }
}
