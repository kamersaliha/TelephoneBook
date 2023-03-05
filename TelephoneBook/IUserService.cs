using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneBook
{
    public interface IUserService
    {
        public void Add(User user, List<User> userList);
        public void Delete(string Name, string Surname,string PhoneNumber, List<User> userList);
        public void Update(string name, string surname, string phoneNumber, List<User> userList);
        public string GetValidName(string prompt);
        public bool isNameValid(string input);
        public bool IsPhoneNumberValid(string phoneNumber);
        public bool CheckListNotEmpty<T>(List<T> list);
    }
}
