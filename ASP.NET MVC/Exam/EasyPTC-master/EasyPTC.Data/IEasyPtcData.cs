namespace EasyPTC.Data
{
    using EasyPTC.Data.Contracts;
    using EasyPTC.Models;

    public interface IEasyPtcData
    {
        IEasyPtcDbContext Context { get; }

        IDeletableEntityRepository<Advertisement> Advertisements { get; }

        IDeletableEntityRepository<Category> Categories { get; }

        IDeletableEntityRepository<PricingPlan> PricingPlans { get; }

        IRepository<User> Users { get; }

        int SaveChanges();
    }
}
