namespace Models.Entities;

public class CreateCommentDto
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid PredefinedCoffeeId { get; set; }

    public DateTime CommentTime { get; set; }

    public string Content { get; set; } = null!;
}