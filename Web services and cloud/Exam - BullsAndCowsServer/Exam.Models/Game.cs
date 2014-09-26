namespace Exam.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Game
    {
        private ICollection<Guess> guesses;

        public Game()
        {
             this.guesses = new HashSet<Guess>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Red { get; set; }

        public string RedNumber { get; set; }
  
        public string Blue { get; set; }

        public string BlueNumber { get; set; }

        public GameState GameState { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual ICollection<Guess> Guesses
        {
            get
            {
                return this.guesses;
            }

            set
            {
                this.guesses = value;
            }
        } 
    }
}
