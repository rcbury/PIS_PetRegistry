﻿using System;
using System.Collections.Generic;

namespace PIS_PetRegistry.Models;

public partial class PhysicalPerson
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string? Email { get; set; }

    public int FkLocality { get; set; }

    public int FkCountry { get; set; }

    public virtual ICollection<Contract> Contracts { get; } = new List<Contract>();

    public virtual Country FkCountryNavigation { get; set; } = null!;

    public virtual Location FkLocalityNavigation { get; set; } = null!;
}
