using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.WriteLine("Şifre Uzunluğunu Girin (8-15):");
        int length = int.Parse(Console.ReadLine());

        if (length < 8 || length > 15)
        {
            Console.WriteLine("Geçerli bir uzunluk girin! (8 ile 15 arasından bir uzunluk giriniz.)");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Büyük Harf Kullanılsın mı? (E/H):");
        bool useUppercase = Console.ReadLine().ToUpper() == "E";

        Console.WriteLine("Küçük Harf Kullanılsın mı? (E/H):");
        bool useLowercase = Console.ReadLine().ToUpper() == "E";

        Console.WriteLine("Rakam Kullanılsın mı? (E/H):");
        bool useNumbers = Console.ReadLine().ToUpper() == "E";

        Console.WriteLine("Özel Karakter Kullanılsın mı? (E/H):");
        bool useSpecialChars = Console.ReadLine().ToUpper() == "E";

        
        string password = GeneratePassword(length, useUppercase, useLowercase, useNumbers, useSpecialChars);

        Console.WriteLine($"Oluşturulan Şifre: {password}");

        Console.ReadKey();
    }

    static string GeneratePassword(int length, bool useUppercase, bool useLowercase, bool useNumbers, bool useSpecialChars)
    {
        string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string lowercase = "abcdefghijklmnopqrstuvwxyz";
        string numbers = "0123456789";
        string specialChars = "!@#$%^&*()_+";

        StringBuilder characterPool = new StringBuilder();
        if (useUppercase) characterPool.Append(uppercase);
        if (useLowercase) characterPool.Append(lowercase);
        if (useNumbers) characterPool.Append(numbers);
        if (useSpecialChars) characterPool.Append(specialChars);

        if (characterPool.Length == 0)
        {
            return "Geçerli bir karakter türü seçmediniz!";
        }

        Random random = new Random();
        StringBuilder password = new StringBuilder();

        
        for (int i = 0; i < length; i++)
        {
            int index = random.Next(characterPool.Length);  
            password.Append(characterPool[index]);  
        }

        return password.ToString();  
    }
}