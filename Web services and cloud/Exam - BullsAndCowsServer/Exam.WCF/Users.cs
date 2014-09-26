using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Exam.Models;
using Microsoft.VisualBasic.ApplicationServices;

namespace Exam.WCF
{
    public class UserModel
    {
        public static Expression<Func<ApplicationUser, UserModel>> FromUser
        {
            get
            {
                return u => new UserModel
                {
                    Id = u.Id,
                    UserName = u.UserName
                };
            }
        }

        string Id { get; set; }
        string UserName { get; set; }
    }
}