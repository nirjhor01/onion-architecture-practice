using DomainlayerClassLibrary1.Model;
using RepositoryLayerClassLibrary2;
using ServiceLayerClassLibrary3.Service.Contract_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayerClassLibrary3.Service.Implementation
{

    public class UserService : IUserService
    {
        private readonly AppDbContext _appDbContext;

        public UserService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public string AddUserRepo(User user)
        {
            try
            {
                this._appDbContext.tblUser.Add(user);
                this._appDbContext.SaveChanges();
                throw new NotImplementedException();
            }
            catch(Exception ex) {
                return ex.Message;
            }
        }
        public async Task AddAsync(T entity)
        {
            await _appDbContext.Set<T>().AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }


        public List<User> GetAllUser()
        {
            return this._appDbContext.tblUser.ToList();
        }

        public User GetSingleUser(long id)
        {
            return this._appDbContext.tblUser.Where(x => x.UserId == id).FirstOrDefault();
        }

        public string RemoveUser(long id)
        {
            try
            {
                var user = this._appDbContext.tblUser.Find(id);
                this._appDbContext.Remove(user);
                this._appDbContext.SaveChanges();
                return "Successfully Removed";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public string UpdateUserRepo(User user)
        {
            var use = this._appDbContext.tblUser.Find(user.UserId);
            return "Success updation";
        }
    }
}
