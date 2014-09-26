namespace Exam.WebAPI.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using Exam.Data;

    public class BaseController : ApiController
    {
        protected readonly IApplicationData data;

        public BaseController()
            : this(new ApplicationData())
        {
        }

        public BaseController(IApplicationData data)
        {
            this.data = data;
        }
    }
}