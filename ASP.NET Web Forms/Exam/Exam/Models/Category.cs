namespace NewsSite.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Category
    {
        public Category()
        {
            this.Articles = new HashSet<Article>();
        }

        public int Id { get; set; }

        [Index(IsUnique = true)] 
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Name { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}