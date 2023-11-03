using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace API.Dtos;
public class DriverDto
{
     public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public int Age { get; set; }
}
