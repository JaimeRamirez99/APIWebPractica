using Infrastructure;
using Infrastructure.Models;

namespace Business
{
    public class AdminHotel : IAdminHotel
    {
        private HotelRepository _hotelRepository;
        public AdminHotel(HotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<List<Hotel>> GetHotels()
        {
            return await _hotelRepository.ListAsync();
        }

        public async Task<Hotel> GetHotelById(Guid id)
        {
            return await _hotelRepository.GetByIdAsync(id);
        }

        public async Task CreateHotel(Hotel hotel)
        {
            await _hotelRepository.CreateAsync(hotel);
        }
        public async Task ModifyHotel(Hotel hotel)
        {
            await _hotelRepository.UpdateAsync(hotel);
        }
        public async Task DeleteHotel(Guid id)
        {
            await _hotelRepository.DeleteAsync(id);
        }
    }
}
