namespace AjaxTestApplication.Business.Entities
{
    public class Session
    {
        public int SessionId { set; get; }
        public string SessionName {  get { return string.Format("Session {0}", SessionId); } }
    }
}