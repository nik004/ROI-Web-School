using System;

namespace AjaxTestApplication.Business.Entities
{
    public class Comment
    {
        public Comment(int sessionId, string message)
        {
            SessionId = sessionId;
            DateTime = DateTime.Now;
            Message = message;

        }

        public Comment()
        {
        }

        public int SessionId { set; get; }
        public string Message { set; get; }
        public DateTime DateTime { set; get; }
    }
}