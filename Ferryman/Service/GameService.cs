using Ferryman.Models;
using System.Collections.Generic;

namespace Ferryman.Service
{

    public interface IGameService
    {
        public List<IPassenger> LeftCoast { get; }
        public List<IPassenger> RightCoast { get; }

        public int Count { get; set; }

        public IPassenger Wolf { get; }
        public IPassenger Goat { get; }
        public IPassenger Cabbage { get; }

        public IBoat Boat { get; set; }

        void ActionAddToArea(List<IPassenger> area,IPassenger passenger);
        void ActionRemoveFromArea(List<IPassenger> area, IPassenger passenger);
        bool CheckResult(List<IPassenger> area);
    }

    public class GameService : IGameService
    {
        public List<IPassenger> LeftCoast { get; }

        public List<IPassenger> RightCoast { get; }

        public int Count { get; set; }

        public IPassenger Wolf { get; }
        public IPassenger Goat { get; }
        public IPassenger Cabbage { get; }

        public IBoat Boat { get; set; }

        public GameService()
        {
            LeftCoast = new List<IPassenger>();
            RightCoast = new List<IPassenger>();
            Wolf = new Passenger(PassengerRoles.Wolf);
            Goat = new Passenger(PassengerRoles.Goat);
            Cabbage = new Passenger(PassengerRoles.Cabbage);
            Boat = new Boat();
            Count = 0;

            ActionAddToArea(RightCoast, Wolf);
            ActionAddToArea(RightCoast, Goat);
            ActionAddToArea(RightCoast, Cabbage);
        }

        public void ActionAddToArea(List<IPassenger> area, IPassenger passenger)
        {
            if (!area.Contains(passenger))
                area.Add(passenger);
        }

        public void ActionRemoveFromArea(List<IPassenger> area, IPassenger passenger)
        {
            if (area.Contains(passenger))
                area.Remove(passenger);
        }

        public bool CheckResult(List<IPassenger> area)
        {
            if (area.Count < 2)
                return true;

            var areaPassanger1 = area[0].Role;
            var areaPassanger2 = area[1].Role;

            if (((areaPassanger1.Equals(PassengerRoles.Wolf) && areaPassanger2.Equals(PassengerRoles.Cabbage))
                || (areaPassanger1.Equals(PassengerRoles.Cabbage) && areaPassanger2.Equals(PassengerRoles.Wolf))))
                return true;
            if (((areaPassanger1.Equals(PassengerRoles.Wolf) && areaPassanger2.Equals(PassengerRoles.Goat))||
                (areaPassanger1.Equals(PassengerRoles.Goat) && areaPassanger2.Equals(PassengerRoles.Wolf))))
                return false;
            
            return false;
        }

    }
}
