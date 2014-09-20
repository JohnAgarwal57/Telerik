using BugLogger.Data;
using BugLogger.Data.Repositories;
using BugLogger.Models;
using BugLogger.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;

namespace BugLogger.RestApi.IntegrationTests
{
    class TestBugsDependencyResolver : IDependencyResolver
    {
        private IBugLoggerData data;

        public IBugLoggerData Data
        {
            get
            {
                return this.data;
            }
            set
            {
                this.data = value;
            }
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            //add all controllers
            if (serviceType == typeof(BugsController))
            {
                return new BugsController(this.data);
            }
            return null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {

        }
    }
}
