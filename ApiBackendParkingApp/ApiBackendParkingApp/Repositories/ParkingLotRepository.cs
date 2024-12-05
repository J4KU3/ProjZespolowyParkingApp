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

        private bool _disposed;
        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }
            _db = null;
            _disposed = true;
        }
        public async Task<IEnumerable<PlaceModelDao>> GetAllPlacesAsync()
        {
            string sql = @"Select * 
                            From Places";

            var result = await _db.QueryAsync<PlaceModelDao>(sql, null);
            return result;
        }
    }
}
