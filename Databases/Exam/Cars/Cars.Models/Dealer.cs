namespace Cars.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Dealer
    {
        private ICollection<City> cities;

        public Dealer()
        {
            this.cities = new HashSet<City>();
        }

        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<City> Cities
        {
            get
            {
                return this.cities;
            }

            set
            {
                this.cities = value;
            }
        }
    }
}
