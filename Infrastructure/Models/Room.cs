using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models;

public class Room
{
    [Required]
    public Guid Id { get;set; } = Guid.NewGuid();
    [Required]
    public string Name { get; set; }
    [Required]
    public int MaxGuests { get; set; }
}
