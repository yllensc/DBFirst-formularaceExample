using System;
using System.Collections.Generic;

namespace Core.Entities;

public partial class Driver : BaseEntity
{
    public string Name { get; set; }
    public int? Age { get; set; }
    public virtual ICollection<Teamdriver> Teamdrivers { get; set; } = new List<Teamdriver>();
    public ICollection<Team> Teams { get; set; }  = new HashSet<Team>();
}
