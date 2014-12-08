using System.Collections.Generic;
using System.Linq;
using AjaxTestApplication.Business.Entities;
using AjaxTestApplication.Models;

namespace AjaxTestApplication.Business.Services
{
    public class CommentServices
    {
        private static readonly CommentsViewModel CommentsViewModel = new CommentsViewModel
        {
            Items = new List<Comment>
            {
                new Comment(1, "AJAX is Asynchronous JavaScript And XML"),
                new Comment(1, "AJAX is not a language"),
                new Comment(1, "AJAX is not a technology"),
                new Comment(1, "AJAX is coined by Jesse James Garret"),
                new Comment(1, "AJAX is cool"),
                new Comment(2, "AJAX is cool")
            }
        };

        public IEnumerable<Comment> GetComments(int sessionId)
        {
            return CommentsViewModel.Items.Where(c => c.SessionId == sessionId).ToList();
        }

        public void AddComment(Comment comment)
        {
            CommentsViewModel.Items.Add(comment);
        }

    }
}