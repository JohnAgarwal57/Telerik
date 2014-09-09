namespace Cars.Data
{
    using Cars.Data.Repositories;
    using Cars.Models;

    public interface ICarsData
    {
        IGenericRepository<Manufacturer> Manufacturers { get; }

        IGenericRepository<Car> Cars { get; }

        IGenericRepository<Dealer> Dealers { get; }

        IGenericRepository<City> Cities { get; }

        void SaveChanges();

        void Dispose();

        void AutoDetectChanges(bool set);
    }
}
