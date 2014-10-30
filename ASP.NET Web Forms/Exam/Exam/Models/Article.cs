namespace NewsSite.Models
{
    using System;
    using System.Collections.Generic;

    public class Article
    {
        public Article()
        {
            this.Likes = new HashSet<Like>();
        }
        
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public string AuthorId { get; set; }

        public virtual AppUser Author { get; set; }

        public virtual ICollection<Like> Likes { get; set; }

        public int LikesPower { get; set; }

        public int LikesCount { get; set; }
    }
}