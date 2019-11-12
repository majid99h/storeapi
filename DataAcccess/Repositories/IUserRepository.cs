using Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories
{
    public interface IUserRepository :  IRepository<User>
    {
         User IsValidUser(User user);
       
    }
}
