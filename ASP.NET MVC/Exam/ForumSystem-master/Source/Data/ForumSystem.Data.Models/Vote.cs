namespace ForumSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using ForumSystem.Data.Common.Models;

    public class Vote : AuditInfo, IDeletableEntity
    {
        [Key]
        public int Id { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }

        public Post Post { get; set; }

        public int PostId { get; set; }

        public int Value { get; set; }

        public bool IsDeleted { get; set; }

        public System.DateTime? DeletedOn { get; set; }
    }
}