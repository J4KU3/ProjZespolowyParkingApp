
using ApiBackendParkingApp.Models.DAO;
using ApiBackendParkingApp.Models.DTO;
using ApiBackendParkingApp.Repositories.Interfaces;
using ApiBackendParkingApp.Services.Interfaces;
using AutoMapper;

namespace ApiBackendParkingApp.Services
{
    public class ParkingLotService : IParkingLotService
    {
        private IParkingLotRepository _parkingLotRepository;
        private IMapper _mapper;

        public ParkingLotService(IParkingLotRepository parkingLotRepository, IMapper mapper)
        {
            _parkingLotRepository = parkingLotRepository;
            _mapper = mapper;
        }

        private bool _isDisposed;

        public void Dispose()
        {
            if (_isDisposed)
                return;

            _parkingLotRepository.Dispose();
            _parkingLotRepository = null;
            _mapper = null;
            _isDisposed = true;
        }

        public async Task<IEnumerable<PlaceModelDTO>> GetAllPlacesAsync()
        {
            try
            {
                var dao = await _parkingLotRepository.GetAllPlacesAsync();

                var result = new List<PlaceModelDTO>();

                foreach (var place in dao) 
                {
                    result.Add(_mapper.Map<PlaceModelDTO>(place));
                }
                return result;

            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public async Task<IEnumerable<SectorModelDTO>> GetAllSectorsAsync()
        {
            try
            {
                var dao = await _parkingLotRepository.GetAllSectorsAsync();

                var result = new List<SectorModelDTO>();

                foreach (var sectors in dao)
                {
                    Console.WriteLine(sectors);
                    result.Add(_mapper.Map<SectorModelDTO>(sectors));
                }

                return result;

            }
            catch (Exception ex)
            {
                 Console.WriteLine(ex.Message);
                throw ex;

            }
        }

        public async Task<int> AddReservationAsync(ParkingLotModelDTO parkingLotModelDTO)
        {
            try
            {
                var dao = _mapper.Map<ParkingLotModelDao>(parkingLotModelDTO);
                    return await _parkingLotRepository.AddReservationAsync(dao);
            }
            catch (Exception)
            {

                throw;
            }
        }

       
    }
}
