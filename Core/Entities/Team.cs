using System;
using System.Collections.Generic;

namespace Core.Entities;

public partial class Team
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Teamdriver> Teamdrivers { get; set; } = new List<Teamdriver>();
    public ICollection<Driver> Drivers { get; set; } = new HashSet<Driver>();
}
