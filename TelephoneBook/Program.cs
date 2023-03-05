using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Text.RegularExpressions;

namespace TelephoneBook
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Created a list for the inputs (name, surname, phone number) that receive from the user.
            List<User> userList = new List<User>();

            //Main Menu Options
            while (true)
            {
                Console.WriteLine("  Telefon Rehberine Hoşgeldiniz!\n" +
                    "Lütfen Yapacağınız İşlemi Seçiniz:\n" +
                    "(1)Yeni Bir Kişi Ekleme\n" +
                    "(2)Kişi Silme\n" +
                    "(3)Kişi Bilgisi Güncelleme\n" +
                    "(4)Kişileri Listeleme\n" +
                    "(5)Kişileri Arama");
                
                string userInput = Console.ReadLine();

                UserManager userManager = new UserManager();

                User user = new User();

                
                switch (userInput)
                {
                    
                    case "1":

                        //Adding starts here. Firstly, The function GetValidName() checks whether the name and surname consists of letters or not.
                        string name = userManager.GetValidName("Lütfen rehbere ekleyeceğiniz kişinin adını giriniz: ");
                        string surname = userManager.GetValidName("Soyadını giriniz: ");
                        string phoneNumber;
                        while (true)
                        {
                            Console.WriteLine("Telefon Numarasını Giriniz:");
                            phoneNumber = Console.ReadLine();

                            //The function IsPhoneNumberValid checks whether the phone number consists of numbers or not.
                            //If both conditions are met, the adding operation is done.
                            if (userManager.IsPhoneNumberValid(phoneNumber))
                            {
                                user = new User() { Name = name, Surname = surname, PhoneNumber = phoneNumber };
                                userManager.Add(user, userList);
                                break;
                            }
                        }
                        break;

                    case "2":

                        //Call the function CheckListNotEmpty that checks if the list is empty or not.
                        if (!userManager.CheckListNotEmpty(userList))
                        {
                            break;
                        }

                        //After checking the name, surname and phone number, call the Delete function.
                        name = userManager.GetValidName("Lütfen rehberden sileceğiniz kişinin adını giriniz: ");
                        surname = userManager.GetValidName("Soyadını giriniz: ");
                        while (true)
                        {
                            Console.WriteLine("Telefon Numarasını Giriniz:");
                            phoneNumber = Console.ReadLine();
                            if (userManager.IsPhoneNumberValid(phoneNumber))
                            {
                                userManager.Delete(name, surname, phoneNumber, userList);
                                break;
                            }
                        }
                        break;

                    case "3":

                        //Call the function CheckListNotEmpty that checks if the list is empty or not.
                        if (!userManager.CheckListNotEmpty(userList))
                        {
                            break;
                        }

                        //After checking the name, surname and phone number, call the Update function.
                        name = userManager.GetValidName("Güncellemek istediğiniz kişinin adını giriniz: ");
                        surname = userManager.GetValidName("Soyadını giriniz: ");
                        while (true)
                        {
                            Console.WriteLine("Telefon Numarasını Giriniz:");
                            phoneNumber = Console.ReadLine();
                            if (userManager.IsPhoneNumberValid(phoneNumber))
                            {
                                userManager.Update(name, surname, phoneNumber, userList);
                                break;
                            }
                        }
                        break;                       

                    case "4":

                        //Call the function CheckListNotEmpty that checks if the list is empty or not.
                        if (!userManager.CheckListNotEmpty(userList))
                        {
                            break;
                        }

                        //Got the list of users with the GetAll function in the Listmanager class and sorted them all with foreach method.
                        ListManager listManager = new ListManager();             
                        var sortedList = listManager.GetAll(userList);
                        Console.WriteLine("Rehberde kayıtlı kişiler:");

                        foreach (var y in sortedList)
                        {

                            Console.WriteLine(y.Name + " " + y.Surname + " " + y.PhoneNumber);
                        }
                        break;

                    case "5":

                        //Call the function CheckListNotEmpty that checks if the list is empty or not.
                        if (!userManager.CheckListNotEmpty(userList))
                        {
                            break;
                        }

                        //Asked what property the search would be with.
                        SearchManager searchManager = new SearchManager();                                                                    

                            Console.WriteLine("Ad ile arama yapmak için 1");
                            Console.WriteLine("Soyad ile arama yapmak için 2'yi");
                            Console.WriteLine("Telefon numarası ile arama yapmak için 3'ü tuşlayınız.");
                            string choose = Console.ReadLine();                                                                                                            
                        
                        switch (choose)
                        { 
                            case "1":

                                // Checking the name with GetValidName function, found the person with the GetByName function and printed it.
                                name = userManager.GetValidName("Aramak istediğiniz kişinin adını giriniz: ");                                
                                foreach (var kullanici in searchManager.GetByName(name, userList))
                                {
                                    Console.WriteLine(kullanici.Name + " " + kullanici.Surname + " " + kullanici.PhoneNumber);
                                }

                                break;

                            case "2":

                                // Checking the surname with GetValidName function, found the person with the GetByName function and printed it.
                                surname = userManager.GetValidName("Aramak istediğiniz kişinin soyadını giriniz: ");
                          
                                foreach (var kullanici in searchManager.GetBySurname(surname, userList))
                                {
                                    Console.WriteLine(kullanici.Name + " " + kullanici.Surname + " " + kullanici.PhoneNumber);
                                }

                                break;

                            case "3":

                                // Checking the phone number with IsPhoneNumberValid function, found the person with the GetByPhoneNumber function and printed it.
                                while (true)
                                {                                
                                Console.WriteLine("Aramak istediğiniz kişinin telefon numarasını giriniz: ");
                                phoneNumber = Console.ReadLine();

                                    if (userManager.IsPhoneNumberValid(phoneNumber))
                                    {
                                        Console.WriteLine("Kayıtlı telefon numarası bulunamamıştır!");
                                        break;
                                    }
                                }

                                foreach (var kullanici in searchManager.GetByPhoneNumber(phoneNumber, userList))
                                    {
                                        Console.WriteLine(kullanici.Name + " " + kullanici.Surname + " " + kullanici.PhoneNumber);
                                    }
                                
                                break;  

                                default:
                                Console.WriteLine("Lütfen 1'den 3'e kadar bir rakam tuşlayınız.");
                                    break;
                        }
                       
                        break;

                    default:
                        Console.WriteLine("Lütfen 1'den 5'e kadar bir rakam tuşlayınız.");
                        break;


                }
            }

        }

      
    }
}