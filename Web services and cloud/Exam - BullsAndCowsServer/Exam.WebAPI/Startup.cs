using System;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using Exam.Data;
using Microsoft.Owin;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;

[assembly: OwinStartup(typeof(Exam.WebAPI.Startup))]

namespace Exam.WebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);   
           // app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(GlobalConfiguration.Configuration);                    
        }

        private static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            return kernel;
        }

        private static void RegisterMapping(StandardKernel kernel)
        {
            kernel.Bind<IApplicationData>().To<ApplicationData>().WithConstructorArgument("context", c => new ApplicationDbContext());
        }
    }
}