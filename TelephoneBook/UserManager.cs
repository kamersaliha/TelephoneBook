using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TelephoneBook
{
    public class UserManager : IUserService
    {
       //Add a new contact function
        public void Add(User user, List<User> userList)
        {
            //Variable isUserExist checks whether the data entered by the user and the data of the user in the list are the same.
            var isUserExist = userList.FirstOrDefault(x => x.Name == user.Name && x.Surname == user.Surname && x.PhoneNumber == user.PhoneNumber);

            //Variable isUserContain checks if the same person is registered with a different number
            var isUserContain = userList.SingleOrDefault(x => x.Name == user.Name && x.Surname == user.Surname && x.PhoneNumber != user.PhoneNumber );

            //Returns error message if user with same data
            if (isUserExist != null)
            {
                Console.WriteLine($"Kişi {isUserExist.Name} {isUserExist.Surname} ismi ve {isUserExist.PhoneNumber} numarasıyla zaten rehberde mevcut!");
            }

            //Updates the number if the person with the same name is trying to register with a different number
            else if (isUserContain != null)
            {
                Console.WriteLine($"Kişi {isUserContain.Name} {isUserContain.Surname} farklı numara ile rehberde mevcut. Değiştirmeyi onaylıyor musunuz?");
                Console.WriteLine("Evet ise 0'i tuşlayınız. Ana menüye dönmek için 1'i tuşlayınız.");
                int firstChoice = Convert.ToInt32(Console.ReadLine());

                if (firstChoice==0)
                {                  
                    isUserContain.PhoneNumber = user.PhoneNumber;               
                    
                    Console.WriteLine($"Kişi {isUserContain.Name} {isUserContain.Surname} adlı kişinin numarası {isUserContain.PhoneNumber} olarak başarıyla güncellendi.");
                }
            }

            else 
            {
                userList.Add(user);
                foreach (var x in userList)
                {
                    Console.WriteLine(x.Name + " " + x.Surname + " isimli, " + x.PhoneNumber + " telefon numaralı kişi rehbere başarıyla kaydedildi.");
                }
            }
            
        }


        //Contact delete function
        public void Delete(string name, string surname,string phoneNumber, List<User> userList)
        {
            //Finds the person with the Find method and deletes them with the Remove method
            User userToRemove = userList.Find(user =>  user.Name == name && user.Surname == surname && user.PhoneNumber == phoneNumber);
            if (userToRemove != null)
            {
                userList.Remove(userToRemove);
                Console.WriteLine($"Kişi {userToRemove.Name} {userToRemove.Surname} silindi.");                               
            }
            else
            {
                Console.WriteLine("Kişi bulunamadı.");
            }
        }


        //Contact update function
        public void Update(string name, string surname, string phoneNumber, List<User> userList)
        {
            //Finds the person with Find method and replaces the data in the list with the data from the user
            User userToUpdate = userList.Find(user => user.Name == name && user.Surname == surname && user.PhoneNumber == phoneNumber);
            if (userToUpdate != null)
            {
                Console.WriteLine("Lütfen kullanıcının yeni adını giriniz.");
                userToUpdate.Name = Console.ReadLine();
                Console.WriteLine("Lütfen kullanıcının yeni soyadını giriniz.");
                userToUpdate.Surname = Console.ReadLine();
                Console.WriteLine("Lütfen kullanıcının yeni telefon numarasını giriniz.");
                userToUpdate.PhoneNumber = Console.ReadLine();

                
                Console.WriteLine($"Kişi adı {userToUpdate.Name}, soyadı {userToUpdate.Surname} ve telefon numarası {userToUpdate.PhoneNumber} olarak başarıyla güncellenmiştir.");
               
            }
            else
            {
                Console.WriteLine("Kişi bulunamadı.");
            }
            
        }

        //isNameValid function checks whether the entered data consists of letters.
        public bool isNameValid(string input)
        {
            return !string.IsNullOrWhiteSpace(input) && input.All(c => Char.IsLetter(c) || c == ' ');
        }

        // GetValidName function takes the name entered by the user and has it checked by isNameValid function.
        public string GetValidName(string prompt)
        {
            string name;
            do
            {
                Console.WriteLine(prompt);
                name = Console.ReadLine();
                if (!isNameValid(name))
                {
                    Console.WriteLine("Hata: İsim sadece harflerden oluşmalıdır!");
                }
            } while (!isNameValid(name));
            return name;
        }

        //IsPhoneNumberValid function checks if the number consists of digits.
        public bool IsPhoneNumberValid(string phoneNumber)
        {
            if (!long.TryParse(phoneNumber, out long number) || phoneNumber.Length != 11)
            {
                Console.WriteLine("Telefon numarası 11 haneli sayısal bir değer olmalıdır!");
                return false;
            }
            return true;
        }
        //CheckListNotEmpty function checks if the list is empty or not.
        public bool CheckListNotEmpty<T>(List<T> list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Hata: Liste boş!");
                return false;
            }

            return true;
        }
    }
}
