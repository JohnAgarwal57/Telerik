namespace EasyPTC.Models
{
    using System.ComponentModel.DataAnnotations;
    using EasyPTC.Data.Contracts;
using System.Collections.Generic;

    public class PricingPlan : DeletableEntity, IEntity
    {
        public PricingPlan()
        {
            this.Users = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int NumberOfTextAdsClicks { get; set; }

        public decimal PriceForTextAdsClicks { get; set; }

        public int NumberOfBannerClicks { get; set; }

        public decimal PriceForBannerClicks { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}