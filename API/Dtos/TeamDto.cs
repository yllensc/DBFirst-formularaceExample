using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace API.Dtos;
public class TeamDto
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
}

public class AddDriverDto{
    public int IdDriver { get; set; }
    public int IdTeam { get; set; }
}
