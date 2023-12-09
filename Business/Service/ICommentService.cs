using Models.Entities;

namespace Business.Service;

public interface ICommentService
{
    IList<Comment> GetCommentByPredefinedCoffeeId(Guid id);
    IList<Comment> GetCommentByUserId(Guid id);
    Comment GetComment(Guid id);
    bool CommentExists(Guid id);
    void DeleteComment(Guid id);
    Comment CreateComment(Comment comment);
}