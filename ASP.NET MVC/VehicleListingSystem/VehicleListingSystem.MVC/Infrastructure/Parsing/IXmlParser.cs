namespace VehicleListingSystem.MVC.Infrastructure
{
    using System.Linq;
    using VehicleListingSystem.Data;

    public interface IXmlParser
    {
        IQueryable<Vehicle> Parse(string file);
    }
}
