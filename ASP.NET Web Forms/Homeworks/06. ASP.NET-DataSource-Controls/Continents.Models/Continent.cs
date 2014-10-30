namespace Continents.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Continent
    {
        private ICollection<Country> countries;

        public Continent()
        {
            this.countries = new HashSet<Country>();
        }
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Country> Countries
        {
            get
            {
                return this.countries;
            }

            set
            {
                this.countries = value;
            }
        }
    }
}
