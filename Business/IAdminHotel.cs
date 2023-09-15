using Infrastructure.Models;

namespace Business
{
    public interface IAdminHotel
    {
        Task CreateHotel(Hotel hotel);
        Task DeleteHotel(Guid id);
        Task<Hotel> GetHotelById(Guid id);
        Task<List<Hotel>> GetHotels();
        Task ModifyHotel(Hotel hotel);
    }
}