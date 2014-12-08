using System.Collections.Generic;
using System.Linq;
using AjaxTestApplication.Models;

namespace AjaxTestApplication.Business
{
    public class CommentServices
    {
        private static readonly Comments Comments = new Comments
        {
            Items = new List<Comment>
            {
                new Comment(1, "AJAX is cool"),
                new Comment(1, "AJAX is cool"),
                new Comment(1, "AJAX is cool"),
                new Comment(1, "AJAX is cool"),
                new Comment(2, "AJAX is cool")
            }
        };

        public Comments GetComments(int sessionId)
        {
            return new Comments
            {
                Items = Comments.Items.Where(c => c.SessionId == sessionId).ToList()
            };
        }

        public void AddComment(Comment comment)
        {
            Comments.Items.Add(comment);
        }

    }
}