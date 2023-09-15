using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class HotelRepository
    {
        private readonly HotelDbContext _dbContext;

        public HotelRepository(HotelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Hotel>> ListAsync()
        {
            return await _dbContext.Hotel
                .Include(h => h.rooms)
                .ToListAsync();
        }

        public async Task<Hotel> GetByIdAsync(Guid id)
        {
            return await _dbContext.Hotel
                .Include(h => h.rooms)
                .FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task CreateAsync(Hotel hotel)
        {
            _dbContext.Hotel.Add(hotel);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Hotel updatedHotel)
        {
            var existingHotel = await _dbContext.Hotel
                .Include(h => h.rooms)
                .FirstOrDefaultAsync(h => h.Id == updatedHotel.Id);

            if (existingHotel == null)
            {
                throw new Exception("Hotel no encontrado");
            }

            existingHotel.Name = updatedHotel.Name;
            existingHotel.Stars = updatedHotel.Stars;
            existingHotel.Address = updatedHotel.Address;
            existingHotel.PhoneNumber = updatedHotel.PhoneNumber;

            _dbContext.Room.RemoveRange(existingHotel.rooms); 
            existingHotel.rooms = updatedHotel.rooms.ToList(); 
            _dbContext.Room.AddRange(existingHotel.rooms);
            _dbContext.Update(existingHotel).CurrentValues.SetValues(updatedHotel);

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var hotel = await _dbContext.Hotel
                .Include(h => h.rooms)
                .FirstOrDefaultAsync(h => h.Id == id);

            if (hotel != null)
            {
                _dbContext.Room.RemoveRange(hotel.rooms);

                _dbContext.Hotel.Remove(hotel);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}