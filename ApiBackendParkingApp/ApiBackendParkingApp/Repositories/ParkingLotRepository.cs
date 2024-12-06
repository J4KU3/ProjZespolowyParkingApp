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

        public async Task<IEnumerable<SectorModelDAO>> GetAllSectorsAsync()
        {
            string sql = @"Select *
                                From Sectors";
            var result = await _db.QueryAsync<SectorModelDAO>(sql, null);
            return result;
        }

        public async Task<int> AddReservationAsync(ParkingLotModelDao modelDao)
        {
            string checkAvailabilitySql = @"
                                             SELECT COUNT(1) 
                                             FROM Parking_Lot
                                             WHERE Place_Number = @Place_Number 
                                                 AND ((Start_Time <= @End_Time AND End_Time >= @Start_Time))";

            string sql = @"INSERT INTO Parking_Lot (License_Plate,Start_Time,End_Time,Place_Number) 
                                                    VALUES (@License_Plate,@Start_Time,@End_Time,@Place_Number)";

            try
            {

                // Sprawdzamy, czy miejsce parkingowe jest dostępne w podanym czasie
                var isAvailable = await _db.QueryFirstOrDefaultAsync<int>(checkAvailabilitySql, new
                {
                    Place_Number = modelDao.Place_Number,
                    Start_Time = modelDao.Start_Time,
                    End_Time = modelDao.End_Time
                });

                if (isAvailable > 0)
                {
                    // Miejsce jest już zajęte w tym czasie, rzucamy wyjątek
                    throw new InvalidOperationException($"Place number {modelDao.Place_Number} is already reserved during the specified time.");
                }

                // Jeśli miejsce jest dostępne, zapisujemy rezerwację
                

                var result = await _db.ExecuteAsync(sql, new
                {
                    License_Plate = modelDao.License_Plate,
                    Start_Time = modelDao.Start_Time,
                    End_Time = modelDao.End_Time,
                    Place_Number = modelDao.Place_Number,
                });

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
                

            throw new NotImplementedException();
        }

        
    }
}
