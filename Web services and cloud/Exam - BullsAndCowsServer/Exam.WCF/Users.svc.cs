using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Exam.Data;

namespace Exam.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserService.svc or UserService.svc.cs at the Solution Explorer and start debugging.
    public class UserService : IUserService
    {
        IApplicationData data = new ApplicationData();

        public System.Collections.IEnumerable GetUSers()
        {
            var users = this.data.Users.All().OrderBy(u => u.UserName).Select(UserModel.FromUser).Take(10).ToList();

            return users;
        }

        //public System.Collections.IEnumerable GetUSers(int page)
        //{
        //    var users = this.data.Users.All().OrderBy(u => u.UserName).Skip(page * 10).Select(UserModel.FromUser).Take(10).ToList();

        //    return users;
        //}
    }
}
