using System;
using System.Collections.Generic;

namespace Models.Entities;

public partial class CreatePredefinedCoffeeDTO
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public string Description { get; set; } = null!;
}