namespace localapi.Controllers.Models
{
    public class PostCodeRepositoryEventApiIn
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string[] FileUrls { get; set; }
    }
}