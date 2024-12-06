using ApiBackendParkingApp.Models.DAO;

namespace ApiBackendParkingApp.Repositories.Interfaces
{
    public interface IParkingLotRepository:IDisposable
    {
        public Task<IEnumerable<PlaceModelDao>> GetAllPlacesAsync();
        public Task<IEnumerable<SectorModelDAO>> GetAllSectorsAsync();
        public Task<int> AddReservationAsync(ParkingLotModelDao modelDao);
    }
}
