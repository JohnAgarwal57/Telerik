namespace Exam.WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Exam.Models;

    public class GameModel
    {
        public static Expression<Func<Game, GameModel>> FromGame
        {
            get
            {
                return a => new GameModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    Blue = a.Blue,
                    Red = a.Red,
                    GameState = a.GameState.ToString(),
                    DateCreated = a.DateCreated.ToString()
                };
            }
        }

        public static Expression<Func<Game, GameModel>> FromGameWithDetails
        {
            get
            {
                return a => new GameModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    DateCreated = a.DateCreated.ToString(),
                    Red = a.Red,
                    Blue = a.Blue,
                    Guesses = a.Guesses.Select(g => new GuessResponceModel
                    {
                        Id = g.Id,
                        UserId = g.UserId,
                        UserName = g.UserName,
                        GameId = g.GameId,
                        Number = g.Number,
                        DateMade = g.DateMade.ToString(),
                        CowsCount = g.CowsCount,
                        BullsCount = g.BullsCount
                    }),
                    GameState = a.GameState.ToString(),
                };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }
  
        public string Blue { get; set; }

        public string Red { get; set; }

        public string GameState { get; set; }

        public string DateCreated { get; set; }

        public IEnumerable<GuessResponceModel> Guesses { get; set; }
    }
}