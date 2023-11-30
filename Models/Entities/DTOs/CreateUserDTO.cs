namespace Models.Entities;

public partial class CreateUserDTO
{
    public Guid Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool IsAdmin { get; set; }

    public string FirstName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

}