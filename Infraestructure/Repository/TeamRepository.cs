using Core.Entities;
using Core.Interfaces;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repository;
public class TeamRepository : GenericRepository<Team>, ITeam
{
    private readonly DbFirstContext _context;
    public TeamRepository(DbFirstContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Team>> GetAllAsync()
    {
        return await _context.Teams
            .Include(p => p.Drivers)
            .ToListAsync();
    }

    public override async Task<Team> GetByIdAsync(int id)
    {
        return await _context.Teams
            .Include(p => p.Drivers)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<string> AddDriver(int idTeam, int idDriver)
    {
        var existDriver = await _context.Teams.Where(s=> s.Id == idTeam).FirstAsync();
        var existTeam =await _context.Drivers.Where(s=> s.Id == idDriver).FirstAsync();

        if(existDriver != null && existTeam != null)
        {
            _context.Teamdrivers.Add(new Teamdriver{
                Idteam = idTeam,
                IdDriver = idDriver
            });

            await _context.SaveChangesAsync();  
            return $"Success. Driver into Team, check";
        }
        return "Hey, hey, the driver doesn´t exist";

    }
}