﻿using ApiBackendParkingApp.Models.DAO;
using ApiBackendParkingApp.Models.DTO;

namespace ApiBackendParkingApp.Services.Interfaces
{
    public interface IParkingLotService:IDisposable
    {
        public Task<IEnumerable<PlaceModelDTO>> GetAllPlacesAsync();
    }
}
