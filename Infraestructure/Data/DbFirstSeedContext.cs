using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infraestructure.Data
{
    public class DBfirstSeedContext
    {
        public static async Task SeedAsync(DbFirstContext context, ILoggerFactory loggerFactory)
        {
           try
            {
                if (!context.Drivers.Any())
                {
                    var drivers = new List<Driver>
                    {
                        new Driver { Name = "Driver1", Age = 30 },
                        new Driver { Name = "Driver2", Age = 25 }
                    };
                    context.Drivers.AddRange(drivers);
                }

                if (!context.Teams.Any())
                {
                    var teams = new List<Team>
                    {
                        new Team { Name = "Team1" },
                        new Team { Name = "Team2" }
                    };
                    context.Teams.AddRange(teams);
                }

                if (!context.Teamdrivers.Any())
                {
                    var teamDrivers = new List<Teamdriver>
                    {
                        new Teamdriver { Idteam = 1, IdDriver = 1 },
                        new Teamdriver { Idteam = 2, IdDriver = 2 }
                    };
                    context.Teamdrivers.AddRange(teamDrivers);
                }

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<DBfirstSeedContext>();
                logger.LogError(ex, "Error al insertar datos en las tablas Driver, Team y Teamdriver.");
            }
        }
    }
}