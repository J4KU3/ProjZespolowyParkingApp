namespace ApiBackendParkingApp.Models.DTO
{
    public class ParkingLotModelDTO
    {
        public int Parking_Lot_ID { get; set; }
        public string License_Plate { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Place_Number { get; set; }
    }
}
