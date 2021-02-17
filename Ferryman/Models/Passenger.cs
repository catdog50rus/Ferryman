namespace Ferryman.Models
{

    public interface IPassenger
    {
        public PassengerRoles Role { get; }

    }

    public class Passenger : IPassenger
    {
        public PassengerRoles Role { get; }

        public Passenger(PassengerRoles role)
        {
            Role = role;
        }

        public override string ToString()
        {
            if (Role.Equals(PassengerRoles.Cabbage))
                return "Капуста";
            if (Role.Equals(PassengerRoles.Wolf))
                return "Волк";
            return "Коза";
        }
       
        
    }

    public enum PassengerRoles
    {
        None,
        Wolf,
        Goat,
        Cabbage
    }
}
