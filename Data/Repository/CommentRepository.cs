using Models.Entities;

namespace Data.Repository;

public class CommentRepository : ICommentRepository
{
    private readonly CoffeeContext _context;

    public CommentRepository(CoffeeContext context)
    {
        _context = context;
    }

    public IList<Comment> GetCommentByPredefinedCoffeeId(Guid id)
    {
        return _context.Comments.Where(c => c.PredefinedCoffeeId == id).ToList();
    }

    public IList<Comment> GetCommentByUserId(Guid id)
    {
        return _context.Comments.Where(c => c.UserId == id).ToList();
    }

    public Comment GetComment(Guid id)
    {
        return _context.Comments.FirstOrDefault(c => c.Id == id);
    }

    public bool CommentExists(Guid id)
    {
        return _context.Comments.Any(c => c.Id == id);
    }

    public void DeleteComment(Guid id)
    {
        var comment = GetComment(id);
        _context.Comments.Remove(comment);
        _context.SaveChanges();
    }

    public Comment CreateComment(Comment comment)
    {
        _context.Comments.Add(comment);
        _context.SaveChanges();
        return comment;
    }
}