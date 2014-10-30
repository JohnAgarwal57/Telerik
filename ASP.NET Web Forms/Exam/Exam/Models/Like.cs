namespace NewsSite.Models
{
    public class Like
    {
        public int Id { get; set; }

        public int Value { get; set; }

        public string UserId { get; set; }

        public virtual AppUser User { get; set; }

        public int ArticleId { get; set; }

        public virtual Article Article {get;set;}
    }
}