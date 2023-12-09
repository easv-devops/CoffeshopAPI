using Data.Repository;
using Models.Entities;

namespace Business.Service;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;

    public CommentService(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public IList<Comment> GetCommentByPredefinedCoffeeId(Guid id)
    {
        return _commentRepository.GetCommentByPredefinedCoffeeId(id);
    }

    public IList<Comment> GetCommentByUserId(Guid id)
    {
        return _commentRepository.GetCommentByUserId(id);
    }

    public Comment GetComment(Guid id)
    {
        return _commentRepository.GetComment(id);
    }

    public bool CommentExists(Guid id)
    {
        return _commentRepository.CommentExists(id);
    }

    public void DeleteComment(Guid id)
    {
        _commentRepository.DeleteComment(id);
    }

    public Comment CreateComment(Comment comment)
    {
        return _commentRepository.CreateComment(comment);
    }
}