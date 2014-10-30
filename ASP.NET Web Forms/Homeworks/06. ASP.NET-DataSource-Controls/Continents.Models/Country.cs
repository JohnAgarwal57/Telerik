namespace Continents.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Country
    {
        private ICollection<Town> towns;

        public Country()
        {
            this.towns = new HashSet<Town>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Population { get; set; }

        public int LanguageId { get; set; }

        public virtual Language Language { get; set; }

        public int ContinentId { get; set; }

        public virtual Continent Continent { get; set; }

        public virtual ICollection<Town> Towns
        {
            get
            {
                return this.towns;
            }

            set
            {
                this.towns = value;
            }
        }
    }
}
