using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MD5
{
    internal class Program
    {


        static byte[] GenerateSalt()
        {
            const int SaltLength = 64;
            byte[] salt = new byte[SaltLength];

            var rngRand = new RNGCryptoServiceProvider();
            rngRand.GetBytes(salt);

            return salt;
        }

        static byte[] GenerateMD5Hash(string password, byte[] salt)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] saltedPassword = new byte[salt.Length + passwordBytes.Length];

            using var hash = new MD5CryptoServiceProvider();

            return hash.ComputeHash(saltedPassword);
        }


        static byte[] GenerateSha256Hash(string password, byte[] salt)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] saltedPassword = new byte[salt.Length + passwordBytes.Length];

            using var hash = new SHA256CryptoServiceProvider();

            return hash.ComputeHash(saltedPassword);
        }

        static void Main(string[] args)
        {
            Console.Write("Введите пароль?");

            string password = Console.ReadLine();

            // создаем соль
            byte[] salt = GenerateSalt();

            // создаем MD5-хеш
            byte[] md5Hash = GenerateMD5Hash(password, salt);
            string md5HashString = Convert.ToBase64String(md5Hash);
            Console.WriteLine($"\nMD5-хеш: {md5HashString}");

            // создаем Sha256-хеш
            byte[] sha256Hash = GenerateSha256Hash(password, salt);
            string sha256HashString = Convert.ToBase64String(sha256Hash);
            Console.WriteLine($"\nSHA256: {sha256HashString}");
        }




    }
}
