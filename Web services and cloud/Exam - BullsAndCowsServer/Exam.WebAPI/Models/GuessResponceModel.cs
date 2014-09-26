namespace Exam.WebAPI.Models
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Exam.Models;

    public class GuessResponceModel
    {
        public static Expression<Func<Guess, GuessResponceModel>> FromGuess
        {
            get
            {
                return g => new GuessResponceModel
                {
                    Id = g.Id,
                    UserId = g.UserId,
                    UserName = g.UserName,
                    GameId = g.GameId,
                    Number = g.Number,
                    DateMade = g.DateMade.ToString(),
                    CowsCount = g.CowsCount,
                    BullsCount = g.BullsCount
                };
            }
        }

        public int Id { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public int GameId { get; set; }

        public string Number { get; set; }

        public string DateMade { get; set; }

        public int CowsCount { get; set; }

        public int BullsCount { get; set; }
    }
}