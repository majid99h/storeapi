using Core.Domain;
using Core.Repositories;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Persistence.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(StoreDBContext context)
            : base(context)
        {

        }
        public User IsValidUser(User user)
        {
            var dbUser = this._dbContext.User.Where(x => x.UserName == user.UserName && x.Password == user.Password).FirstOrDefault();
            if (dbUser !=null)
            {
                return dbUser;
            }
            else
            {
                return null;
            }
        }
        public StoreDBContext _dbContext
        {
            get { return Context as StoreDBContext; }
        }
    }
}
