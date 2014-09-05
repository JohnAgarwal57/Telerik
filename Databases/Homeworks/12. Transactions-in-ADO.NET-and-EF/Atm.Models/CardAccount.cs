namespace Atm.Models
{
   using System.ComponentModel.DataAnnotations;

    public class CardAccount
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string CardNumber { get; set; }

        [MaxLength(4)]
        public string CardPin { get; set; }

        public decimal CardCash { get; set; }
    }
}
