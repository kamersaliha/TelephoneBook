using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneBook
{
    public class ListManager
    {
        //Contact list function
        public List<User> GetAll(List<User> userList)
        {
          
            var sortedList = userList.OrderBy(user => user.Name)
                                      .ThenBy(user => user.Surname)
                                      .ThenBy(user => user.PhoneNumber)
                                      .ToList();

            return sortedList;
        }

    }
}
