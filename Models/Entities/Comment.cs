using System;
using System.Collections.Generic;

namespace Models.Entities;

public partial class Comment
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid PredefinedCoffeeId { get; set; }

    public DateTime CommentTime { get; set; }

    public string Content { get; set; } = null!;

    public virtual PredefinedCoffee PredefinedCoffee { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
