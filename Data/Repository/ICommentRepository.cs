using Models.Entities;

namespace Data.Repository;

public interface ICommentRepository
{
    IList<Comment> GetCommentByPredefinedCoffeeId(Guid id);
    IList<Comment> GetCommentByUserId(Guid id);
    Comment GetComment(Guid id);
    bool CommentExists(Guid id);
    void DeleteComment(Guid id);
    Comment CreateComment(Comment comment);
}