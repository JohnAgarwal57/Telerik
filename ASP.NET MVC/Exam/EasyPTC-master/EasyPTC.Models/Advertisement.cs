namespace EasyPTC.Models
{
    using EasyPTC.Data.Contracts;
    using System.ComponentModel.DataAnnotations;

    public class Advertisement : DeletableEntity, IEntity
    {
        [Key]
        public int Id { get; set; }

        public AdType Type { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public int AvailableClicks { get; set; }

        public string Target { get; set; }
    }
}
