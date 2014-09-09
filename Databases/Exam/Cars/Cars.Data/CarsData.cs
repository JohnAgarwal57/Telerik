namespace Cars.Data
{
    using System;
    using System.Collections.Generic;

    using Cars.Data.Repositories;
    using Cars.Models;

    public class CarsData : ICarsData
    {
        private ICarsDBContext context;
        private IDictionary<Type, object> repositories;

        public CarsData(ICarsDBContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public CarsData(string connection)
            : this(new CarsDBContext(connection))
        {
        }

        public IGenericRepository<Manufacturer> Manufacturers
        {
            get 
            {
                return this.GetRepository<Manufacturer>();
            }
        }

        public IGenericRepository<Car> Cars
        {
            get
            {
                return this.GetRepository<Car>();
            }
        }

        public IGenericRepository<Dealer> Dealers
        {
            get
            {
                return this.GetRepository<Dealer>();
            }
        }

        public IGenericRepository<City> Cities
        {
            get
            {
                return this.GetRepository<City>();
            }
        }

        public void AutoDetectChanges(bool set)
        {
            this.context.AutoDetectChanges(set);
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IGenericRepository<T>)this.repositories[typeOfModel];
        }
    }
}
