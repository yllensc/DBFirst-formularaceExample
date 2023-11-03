using Core.Entities;

namespace API.Dtos;
public class DriverDto : BaseEntity
{
    public string Name { get; set; }
    public string Age { get; set; }
}
