using System.Linq;
using System.Web.Mvc;
using AjaxTestApplication.Business.Entities;
using AjaxTestApplication.Business.Services;
using AjaxTestApplication.Models;

namespace AjaxTestApplication.Controllers
{
    public class CommentsController : Controller
    {
        private readonly CommentServices _commentService = new CommentServices();
        
        public ActionResult Index(int? sessionId)
        {
            if (!sessionId.HasValue)
                sessionId = 1;
            return View(new Session{SessionId = sessionId.Value});
        }

        public PartialViewResult _GetForSession(int sessionId)
        {
            var comments = _commentService.GetComments(sessionId);
            
            ViewBag.SessionId = sessionId;

            return PartialView("_CommentList", new CommentsViewModel{Items = comments.ToList()});
        }

        public PartialViewResult _AddComment(Comment comment)
        {
            _commentService.AddComment(comment);
            var comments = _commentService.GetComments(comment.SessionId);

            ViewBag.SessionId = comment.SessionId;

            return PartialView("_CommentList", new CommentsViewModel { Items = comments.ToList() });
        }

        [ChildActionOnly]
        public PartialViewResult _CommentForm(int sessionId)
        {
            var comment = new Comment {SessionId = sessionId};
            return PartialView("_CommentForm", comment);
        }
    }
}
