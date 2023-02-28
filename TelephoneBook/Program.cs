using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text.RegularExpressions;

namespace TelephoneBook
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Eklediklerimin listesini burada oluşturdum.
            List<User> userList = new List<User>();

            while (true)
            {


                Console.WriteLine("  Telefon Rehberine Hoşgeldiniz!\n" +
                    "Lütfen Yapacağınız İşlemi Seçiniz:\n" +
                    "(1)Yeni Bir Kişi Ekleme\n" +
                    "(2)Kişi Silme\n" +
                    "(3)Kişi Bilgisi Güncelleme\n" +
                    "(4)Kişileri Listeleme\n" +
                    "(5)Kişileri Arama");
                int userInput = Convert.ToInt32(Console.ReadLine());

                UserManager userManager = new UserManager();
                static bool isNameValid(string input)
                {

                    foreach (var item in input)
                    {
                        int i = Convert.ToInt32(item);
                        if(i>=48 && i<=57) 
                        {
                            return false;
                        }
                    }
                    return Regex.IsMatch(input, @"^[a-zA-Z0-9ğüşöçİĞÜŞÖÇ]+$");
                }


                switch (userInput)
                {
                    case 1:
                        Console.WriteLine("Lütfen rehbere ekleyeceğiniz kişinin adını giriniz: ");
                        string name = Console.ReadLine();
                        while (!isNameValid(name))
                        {
                            Console.WriteLine("Hata: İsim sadece harflerden oluşmalıdır!");
                            Console.WriteLine("Lütfen tekrar isim giriniz: ");
                            name = Console.ReadLine();
                        }



                        Console.WriteLine("Soyadını giriniz: ");
                        string surname = Console.ReadLine();
                        while (!isNameValid(surname))
                        {
                            Console.WriteLine("Hata: Soyisim sadece harflerden oluşmalıdır!");
                            Console.WriteLine("Lütfen tekrar soyisim giriniz: ");
                            surname = Console.ReadLine();
                        }
                        long phone = 0;
                        string phoneNumber = "";
                        User user = new User();
                        while (true)
                        {
                            Console.WriteLine("Telefon numarasını giriniz: ");
                        
                        
                            try
                            {
                                phone = long.Parse(Console.ReadLine());
                                phoneNumber = phone.ToString();
                                user = new User() { Name = name, Surname = surname, PhoneNumber = phoneNumber };
                                userManager.Add(user, userList);
                                break;
                                
                            }
                            catch (Exception)
                            {

                                Console.WriteLine("Hata: Telefon numarası sadece rakamlardan oluşmalıdır! Lütfen tekrar deneyiniz.");
                            }
                        }
                        break;
                    case 2:
                        if(userList.Count == 0)
                        {
                            Console.WriteLine("Hata: Liste boş!");
                            break;
                        }
                       
                        Console.WriteLine("Lütfen rehberden sileceğiniz kişinin adını giriniz: ");
                        name = Console.ReadLine();
                        while (!isNameValid(name))
                        {
                            Console.WriteLine("Hata: İsim sadece harflerden oluşmalıdır!");
                            Console.WriteLine("Lütfen tekrar isim giriniz: ");
                            name = Console.ReadLine();
                        }

                        Console.WriteLine("Soyadını giriniz: ");
                        surname = Console.ReadLine();
                        while (!isNameValid(surname))
                        {
                            Console.WriteLine("Hata: Soyisim sadece harflerden oluşmalıdır!");
                            Console.WriteLine("Lütfen tekrar soyisim giriniz: ");
                            surname = Console.ReadLine();
                        }
                        while(true) { 
                        Console.WriteLine("Telefon numarasını giriniz: ");
                        
                            try
                            {
                                phone = long.Parse(Console.ReadLine());
                                phoneNumber = phone.ToString();
                                user = new User() { Name = name, Surname = surname, PhoneNumber = phoneNumber };
                                userManager.Delete(name, surname, phoneNumber, userList);
                                break;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Hata: Telefon numarası sadece rakamlardan oluşmalıdır! Lütfen tekrar deneyiniz.");
                            }
                        }
                

                break;
                        
                

                    case 3:
                        if (userList.Count == 0)
                        {
                            Console.WriteLine("Hata: Liste boş!");
                            break;
                        }
                        Console.WriteLine("Güncellemek istediğiniz kişinin adını giriniz: ");
                        name = Console.ReadLine();
                        while (!isNameValid(name))
                        {
                            Console.WriteLine("Hata: İsim sadece harflerden oluşmalıdır!");
                            Console.WriteLine("Lütfen tekrar isim giriniz: ");
                            name = Console.ReadLine();
                        }



                        Console.WriteLine("Soyadını giriniz: ");
                        surname = Console.ReadLine();
                        while (!isNameValid(surname))
                        {
                            Console.WriteLine("Hata: Soyisim sadece harflerden oluşmalıdır!");
                            Console.WriteLine("Lütfen tekrar soyisim giriniz: ");
                            surname = Console.ReadLine();
                        }
                        while (true)
                        {
                            Console.WriteLine("Güncellemek istediğiniz kişinin telefon numarasını giriniz: ");


                            try
                            {
                                phone = long.Parse(Console.ReadLine());
                                phoneNumber = phone.ToString();
                                user = new User() { Name = name, Surname = surname, PhoneNumber = phoneNumber };
                                userManager.Update(name, surname, phoneNumber, userList);
                                break;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Hata: Telefon numarası sadece rakamlardan oluşmalıdır! Lütfen tekrar deneyiniz.");
                            }
                        }
                        
                        break;

                    case 4:
                        if (userList.Count == 0)
                        {
                            Console.WriteLine("Hata: Liste boş!");
                            break;
                        }
                        ListManager listManager = new ListManager();
              
                        var sortedList = listManager.GetAll(userList);
                        Console.WriteLine("Rehberde kayıtlı kişiler:");
                        foreach (var y in sortedList)
                        {
                           
                            Console.WriteLine(y.Name + " " + y.Surname + " " + y.PhoneNumber);
                        }
                   
                        break;

                    case 5:
                        if (userList.Count == 0)
                        {
                            Console.WriteLine("Hata: Liste boş!");
                            break;
                        }

                        SearchManager searchManager = new SearchManager();

                        bool isNumeric(string choose)
                        {
                            bool numeric;

                            foreach (char item in choose)
                            {       

                                if(!Char.IsDigit(item))
                                {
                                    numeric = false;
                                    return numeric;
                                }
                            }
                            numeric = true;

                            return numeric;
                        }

                        int intChoose = 0;
                        while (true)
                        {

                            Console.WriteLine("Ad ile arama yapmak için 1");
                            Console.WriteLine("Soyad ile arama yapmak için 2'yi");
                            Console.WriteLine("Telefon numarası ile arama yapmak için 3'ü tuşlayınız.");
                            string choose = Console.ReadLine(); 
                           

                            if (!isNumeric(choose))
                            {
                                
                                Console.WriteLine("Lütfen sayı giriniz!");

                            }
                            
                                
                                
                                else
                                {
                                    intChoose = Convert.ToInt32(choose);
                                break;
                                }
                                

                            
                        }
                        switch (intChoose)
                        { 
                            case 1:
                                Console.WriteLine("Aramak istediğiniz kişinin adını giriniz: ");
                                name = Console.ReadLine();
                                while (!isNameValid(name))
                                {
                                    Console.WriteLine("Hata: İsim sadece harflerden oluşmalıdır!");
                                    Console.WriteLine("Lütfen tekrar isim giriniz: ");
                                    name = Console.ReadLine();
                                }

                                foreach (var kullanici in searchManager.GetByName(name, userList))
                                {
                                    Console.WriteLine(kullanici.Name + " " + kullanici.Surname + " " + kullanici.PhoneNumber);
                                }

                                break;

                            case 2:
                                Console.WriteLine("Aramak istediğiniz kişinin soyadını giriniz: ");
                                surname = Console.ReadLine();
                                while (!isNameValid(surname))
                                {
                                    Console.WriteLine("Hata: İsim sadece harflerden oluşmalıdır!");
                                    Console.WriteLine("Lütfen tekrar isim giriniz: ");
                                    surname = Console.ReadLine();
                                }

                                foreach (var kullanici in searchManager.GetBySurname(surname, userList))
                                {
                                    Console.WriteLine(kullanici.Name + " " + kullanici.Surname + " " + kullanici.PhoneNumber);
                                }

                                break;

                            case 3:
                                while (true)
                                {

                                
                                Console.WriteLine("Aramak istediğiniz kişinin telefon numarasını giriniz: ");
                                phoneNumber = Console.ReadLine();
                              

                                    try
                                    {
                                        phone = long.Parse(Console.ReadLine());
                                        phoneNumber = phone.ToString();
                                        break;
                                    }
                                    
                                    catch (Exception)
                                    {
                                        Console.WriteLine("Hata: Telefon numarası sadece rakamlardan oluşmalıdır! Lütfen tekrar deneyiniz.");
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