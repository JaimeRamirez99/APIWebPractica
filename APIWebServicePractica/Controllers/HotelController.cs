using Business;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIWebServicePractica.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelController : ControllerBase
    {
        private IAdminHotel _adminHotel;
        private readonly ILogger<HotelController> _logger;

        public HotelController(ILogger<HotelController> logger, IAdminHotel adminHotel)
        {
            _adminHotel = adminHotel;
            _logger = logger;
        }

        [HttpGet(Name = "GetHotels")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<List<Hotel>> GetHotelList()
        {
            return await _adminHotel.GetHotels();
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet("getById{id}")]
        public async Task<Hotel> GetHotelById(Guid id)
        {
            return await _adminHotel.GetHotelById(id);
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpPut(Name = "ModifyHotel")]
        public async Task ModifyHotel(Hotel hotel)
        {
            await _adminHotel.ModifyHotel(hotel);
        }

        [HttpPost(Name = "CreateHotels")]
        public async Task CreateHotel(Hotel hotel)
        {
            await _adminHotel.CreateHotel(hotel);
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpDelete(Name = "DeleteHotel")]
        public async Task DeleteHotel(Guid id)
        {
            await _adminHotel.DeleteHotel(id);
        }
        
    }
}