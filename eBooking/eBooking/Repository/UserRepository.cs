using eBooking.Interfaces;
using eBooking.Model;
using eBooking.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBooking.Repository
{
    public class UserRepository : IUserRepository
    {
        private const string filePath = "../../Data/users.csv";
        private readonly Serializer<User> serializer;
        private List<User> users;

        public UserRepository()
        {
            serializer = new Serializer<User>();
            users = serializer.FromCSV(filePath);
        }

        public User GetUserByUsername(string username)
        {
            users = serializer.FromCSV(filePath);
            return users.FirstOrDefault(u => u.username == username);
        }

        public User GetUserById(int id)
        {
            users = serializer.FromCSV(filePath);
            return users.FirstOrDefault(u => u.id == id);
        }

        public List<User> GetAll()
        {
            return serializer.FromCSV(filePath);
        }

        public User Save(User user)
        {
            user.id = NextId();
            users = serializer.FromCSV(filePath);
            users.Add(user);
            serializer.ToCSV(filePath, users);
            return user;
        }

        private int NextId()
        {
            users = serializer.FromCSV(filePath);
            if (users.Count() < 1) 
            {
                return 1;
            }

            return users.Max(c => c.id) + 1;    
        }
    }
}
