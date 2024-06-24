using DomainlayerClassLibrary1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayerClassLibrary3.Service.Contract_Interface
{
    public interface IUserService<T> where T : class
    {
        List<User> GetAllUser();
        User GetSingleUser(long id);
        String AddUserRepo(User user);
        String UpdateUserRepo(User user);
        String RemoveUser(long id);
    }
}
