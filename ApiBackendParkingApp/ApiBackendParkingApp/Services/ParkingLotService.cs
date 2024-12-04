using ApiBackendParkingApp.Models.DAO;
using ApiBackendParkingApp.Repositories.Interfaces;
using ApiBackendParkingApp.Services.Interfaces;

namespace ApiBackendParkingApp.Services
{
    public class ParkingLotService : IParkingLotService
    {
        private readonly IParkingLotRepository _parkingLotRepository;

        public ParkingLotService(IParkingLotRepository parkingLotRepository)
        {
            _parkingLotRepository = parkingLotRepository;
        }
    }
}
