using ApiBackendParkingApp.Interfaces;
using ApiBackendParkingApp.Models.DAO;
using ApiBackendParkingApp.Repositories.Interfaces;

namespace ApiBackendParkingApp.Repositories
{
    public class ParkingLotRepository : IParkingLotRepository
    {
        private IDbInteractions _db;

        public ParkingLotRepository(IDbInteractions db)
        {
            _db = db;
        }
    }
}
