using Core.Entities;
using Core.Interfaces;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repository;
public class DriverRepository : GenericRepository<Driver>, IDriver
{
    private readonly DbFirstContext _context;
    public DriverRepository(DbFirstContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Driver>> GetAllAsync()
    {
        return await _context.Drivers
            .Include(p => p.Teams)
            .ToListAsync();
    }

    public override async Task<Driver> GetByIdAsync(int id)
    {
        return await _context.Drivers
            .FirstOrDefaultAsync(p => p.Id == id);
    }
}