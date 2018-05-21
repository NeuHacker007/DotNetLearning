using CustomerMembership.Context;
using CustomerMembership.Models;
using System.Collections.Generic;
using System.Linq;

namespace CustomerMembership.Repositories
{
    public class UserRepository
    {
        private CustomerDbContext _dbContext;

        public UserRepository()
        {
            _dbContext = new CustomerDbContext();
        }

        public tblUser GetUserByUserNameAndPwd(string username, string password)
        {
            tblUser user = _dbContext.TblUsers.SingleOrDefault(
                u => u.UserName == username && u.Password == password
            );

            return user;
        }

        public tblUser GetUserObjByUserName(string username)
        {
            tblUser user = _dbContext.TblUsers.SingleOrDefault(
                u => u.UserName == username);
            return user;
        }

        public IEnumerable<tblUser> GetAllUsers()
        {
            return _dbContext.TblUsers.AsEnumerable();
        }

        public int RegisterUser(tblUser user)
        {
            tblUser userObjTblUser = new tblUser();
            userObjTblUser.UserName = user.UserName;
            userObjTblUser.Password = user.Password;
            user.UserEmailAddress = user.UserEmailAddress;

            _dbContext.TblUsers.Add(userObjTblUser);
            _dbContext.SaveChanges();

            return user.UserID;
        }
    }
}