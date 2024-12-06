using ApiBackendParkingApp.Models.DTO;
using ApiBackendParkingApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiBackendParkingApp.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class ParkingLotController:ControllerBase
    {
        private IParkingLotService _parkingLotService;

        public ParkingLotController(IParkingLotService parkingLotService)
        {
            _parkingLotService = parkingLotService;
        }
        private void Dispose()
        {
            _parkingLotService.Dispose();
            _parkingLotService = null;
        }
        [HttpGet("AllParkingSpaces")]
        public async Task<IActionResult> GetAllParkingSpaces()
        {
            try
            {
                var ParkingSpaces = await _parkingLotService.GetAllPlacesAsync();
                return Ok(ParkingSpaces);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
             
            }
            finally
            {
                Dispose();
            }

        }
        [HttpGet("AllSectors")]
        public async Task<IActionResult> GetSectors()
        {
            try
            {
                var Sectors = await _parkingLotService.GetAllSectorsAsync();
                return Ok(Sectors);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            finally
            {
                Dispose();
            }
        }

        [HttpPost("AddNewReservation")]
        public async Task<IActionResult> AddReservation([FromBody] ParkingLotModelDTO newReservation) 
        {
            throw new NotImplementedException();
        }

    }
}
