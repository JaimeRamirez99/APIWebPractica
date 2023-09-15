using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace Infrastructure;

public class HotelDbContext : DbContext
{
    public HotelDbContext() : base()
    {
    }


    //public HotelDbContext(DbContextOptions<DbContext> option) : base(option) { }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlServer("Data Source=LATAM-6QWBLG3;Initial Catalog=HotelApiTest;Integrated Security=True; TrustServerCertificate=True");


    public DbSet<Hotel> Hotel { get; set; }
    public DbSet<Room> Room { get; set; }
}