using Core.Entities;

namespace Core.Interfaces;
public interface ITeam : IGenericRepo<Team>
{
     Task<string> AddDriver(int teamId, int driverId);
}
