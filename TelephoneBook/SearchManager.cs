using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneBook
{
    public class SearchManager
    {
        //Contact search function by name
        public List<User> GetByName(string name, List<User> userList) 
        {
            //List<User> getUserByName = userList.Where(x=>x.Name.Contains(name)).ToList(); <--- Note :I can use this code instead of "List<User> getUserByName = new List<User>();"           
            List<User> getUserByName = new List<User>();
            foreach (var user in userList)
            {
                if (user.Name.Contains(name))
                {
                    getUserByName.Add(user);
                }
            }

            return  getUserByName;
        }
        //Contact search function by surname
        public List<User> GetBySurname(string surname, List<User> userList)
        {
            List<User> getUserBySurname = new List<User>();
            foreach (var user in userList)
            {
                if (user.Surname.Contains(surname))
                {
                     getUserBySurname.Add(user);
                }

            }

            return getUserBySurname;
        }
        //Contact search function by phone number
        public List<User> GetByPhoneNumber(string phoneNumber, List<User> userList)
        {
            List<User> getUserByPhoneNumber = new List<User>();
            foreach(var user in userList)
            {
                if (user.PhoneNumber.Contains(phoneNumber))
                { getUserByPhoneNumber.Add(user); }
            }
            return getUserByPhoneNumber;
        }

    }
}
