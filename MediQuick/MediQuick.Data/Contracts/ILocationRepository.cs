using MediQuick.Data.Models;

namespace MediQuick.Data.Contracts
{
    public interface ILocationRepository
    {
        void AddLocation(Location location);
    }
}