namespace Models.Entities.DTOs;

public partial class GetUserDto
{
    public Guid Id { get; set; }

    public string Username { get; set; } = null!;

    public bool IsAdmin { get; set; }

    public string FirstName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

}