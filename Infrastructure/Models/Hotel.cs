using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models;

public class Hotel
{
    [Required]
    public Guid Id { get; set; } = Guid.NewGuid();
    [Required]
    public string Name { get; set; }
    [Required]
    public int Stars { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    public double  PhoneNumber { get; set; }

    public List<Room> rooms { get; set; } = new List<Room>();
}
