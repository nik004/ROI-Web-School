namespace AjaxTestApplication.Business.Entities
{
    public class Book
    {
        public int Id { set; get; }
        public string Title { set; get; }
        public string Description { set; get; }
        public string Img { set; get; }
        public string Author { get; set; }
    }
}