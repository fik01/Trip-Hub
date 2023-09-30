using eBooking.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBooking.Model
{
    public enum USER_TYPE
    {
        Owner,
        Customer
    }
    public class User : ISerializable
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public USER_TYPE userType { get; set; }

        public User() { }   

        public User(string username, string password, USER_TYPE userType)
        {
            this.username = username;
            this.password = password;
            this.userType = userType;
        }

        public string[] ToCSV()
        {
            string[] csvValues = {
                id.ToString(),
                username,
                password,
                userType.ToString()
            };
            return csvValues;
        }

        public void FromCSV (string[] values)
        {
            id = Convert.ToInt32(values[0]);
            username = values[1];
            password = values[2];
            userType = (USER_TYPE)Enum.Parse(typeof(USER_TYPE), values[3]); //konkretno kastovanje

        }
    }   
}
