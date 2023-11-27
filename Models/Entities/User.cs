using System;
using System.Collections.Generic;

namespace Models.Entities;

public partial class User
{
    public Guid Id { get; set; }

    public string Username { get; set; } = null!;

    public byte[] Password { get; set; } = null!;

    public bool IsAdmin { get; set; }

    public string FirstName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Like> Likes { get; set; } = new List<Like>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
