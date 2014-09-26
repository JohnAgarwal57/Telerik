namespace Exam.Data
{
    using Exam.Data.Repositories;
    using Exam.Models;

    public interface IApplicationData
    {
        IGenericRepository<ApplicationUser> Users { get; }

        IGenericRepository<Game> Games { get; }

        IGenericRepository<Guess> Guesses { get; }

        IGenericRepository<Notification> Notifications { get; }

        IGenericRepository<Score> Score { get; }

        void SaveChanges();

        void Dispose();
    }
}