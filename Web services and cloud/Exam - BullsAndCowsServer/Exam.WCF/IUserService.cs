using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Exam.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserService" in both code and config file together.
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        [WebGet(UriTemplate = "services/Users.svc")]
        IEnumerable GetUSers();

        //[OperationContract]
        //[WebGet(UriTemplate = "services/users.svc?page={page}")]
        //IEnumerable GetUSers(int page);
    }
}
