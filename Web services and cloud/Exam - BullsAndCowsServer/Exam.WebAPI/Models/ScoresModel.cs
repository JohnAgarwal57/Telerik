namespace Exam.WebAPI.Models
{
    using System;
    using System.Linq.Expressions;
    using Exam.Models;

    public class ScoresModel
    {
        public static Expression<Func<Score, ScoresModel>> FromScore
        {
            get
            {
                return s => new ScoresModel
                {
                    Rank = s.Rank,
                    UserName = s.UserName
                };
            }
        }

        public int Rank { get; set; }

        public string UserName { get; set; }
    }
}