using eBooking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBooking.Interfaces
{
    public interface IUserRepository
    {
        User GetUserByUsername(string username);
        User GetUserById(int id);
        List<User> GetAll();
        User Save(User user);

    }
}
