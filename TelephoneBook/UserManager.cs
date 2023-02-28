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
       
        public void Add(User user, List<User> userList)
        {
           var isUserContain = userList.SingleOrDefault(x=>x.Name == user.Name && x.Surname == user.Surname && x.PhoneNumber != user.PhoneNumber );
            if(isUserContain != null)
            {
                Console.WriteLine($"Kişi {isUserContain.Name} {isUserContain.Surname} farklı numara ile rehberde mevcut. Değiştirmeyi onaylıyor musunuz?");
                Console.WriteLine("Evet ise 0'i tuşlayınız. Ana menüye dönmek için 1'i tuşlayınız.");
                int firstChoice = Convert.ToInt32(Console.ReadLine());
                if (firstChoice==0)
                {
                    userList.Remove(isUserContain);
                    isUserContain.PhoneNumber = user.PhoneNumber;               
                    userList.Add(isUserContain);
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

       

        public void Delete(string name, string surname,string phoneNumber, List<User> userList)
        {
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
        public void Update(string name, string surname, string phoneNumber, List<User> userList)
        {
            User userToRemove = userList.Find(user => user.Name == name && user.Surname == surname && user.PhoneNumber == phoneNumber);
            if (userToRemove != null)
            {
                User newUser = new User();
                Console.WriteLine("Lütfen kullanıcının yeni adını giriniz.");
                name = Console.ReadLine();
                newUser.Name = name;
                Console.WriteLine("Lütfen kullanıcının yeni soyadını giriniz.");
                surname = Console.ReadLine();
                newUser.Surname = surname;
                Console.WriteLine("Lütfen kullanıcının yeni telefon numarasını giriniz.");
                phoneNumber = Console.ReadLine();
                newUser.PhoneNumber = phoneNumber;

                userList.Remove(userToRemove);
                userList.Add(newUser);

                Console.WriteLine($"Kişi adı {newUser.Name}, soyadı {newUser.Surname} ve telefon numarası {newUser.PhoneNumber} olarak başarıyla güncellenmiştir.");
               
            }
            else
            {
                Console.WriteLine("Kişi bulunamadı.");
            }
            
        }
    }
}
