using System;

namespace parole
{
    class Program
    {
        static void Main(string[] args)
        {
            int id = 1;//id 1-den baslayir 
            while (true)
            {
                bool checkedPass = false;  
                User us = new User();
                us.Id = id;
                Console.WriteLine("Yeni hesab yarat");
                Console.Write("Tam adi daxil edin: ");
                us.fullname = Console.ReadLine();
                Console.Write("E-pocht unvanini daxil edin: ");
                us.email = Console.ReadLine();
                
                while (!checkedPass)
                {
                    Console.Write("Shifre daxil edin: ");
                    us.password = Console.ReadLine();
                    string result = us.PasswordChecker(us.password);
                    if (result == "") checkedPass = true; //paroldan xeta gelmese true olsun
                    else Console.WriteLine(result);
                }
                us.ShowInfo();
                id++; // her userin id-si beraber olmamasi uchun id artiririq

            }
        }
        
    }
    public interface IAccount
    {
        string PasswordChecker(string password);
        public void ShowInfo();
    }
    class User: IAccount
    {
        public int Id { get; set; }
        public string fullname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string PasswordChecker(string password)
        {            
                string description = "";
                string lowerPass = password.ToLower();
                if (password.Length < 8) description = "Parolun uzunlugu 8den boyuk olmalidir";

                if (password == lowerPass) description = "Parolda bir boyuk herf olmalidir";

                int numCount = 0;
                for (int i = 0; i < 10; i++) 
                {
                    if (password.Contains($"{i}")) numCount++; // Contains- psswordda 1-9dek her hansi reqemin olub olmamasini yoxluyur.
                }

                if (numCount == 0) description = "Parolda bir reqem olmalidir";// numCount 0 olsa demeli paswordda reqem yoxdur.

                return description;
        }
        public void ShowInfo()
        { 
            Console.WriteLine($"Sizin id kodunuz:  {Id}\nAdiniz: {fullname}\nE-poct unvaniniz: {email}\n" );            
        }
    }
}
