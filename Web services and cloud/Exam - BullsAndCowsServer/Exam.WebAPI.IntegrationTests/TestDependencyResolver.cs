namespace Exam.WebAPI.IntegrationTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http.Dependencies;
    using Exam.Data;
    using Exam.WebAPI.Controllers;

    internal class TestDependencyResolver : IDependencyResolver
    {
        public IApplicationData Data { get; set; }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(BaseController))
            {
                return new BaseController(this.Data);
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