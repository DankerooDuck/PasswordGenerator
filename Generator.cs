using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace PasswordGenerator
{
    internal class Generator
    {
        public Generator(int length, bool uppercaseAZ, bool lowercaseAZ, bool numbers, bool specChars)
        {
            string password;

            StringBuilder allowedChars = new StringBuilder();
            if(uppercaseAZ == true)
            {
                allowedChars.Append("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
            }
            if(lowercaseAZ == true)
            {
                allowedChars.Append("abcdefghijklmnopqrstuvwxyz");
            }
            if(numbers == true)
            {
                allowedChars.Append("0123456789");
            }
            if(specChars == true)
            {
                allowedChars.Append("!@#$%^&*");
            }
            string chars = allowedChars.ToString();
            //Console.WriteLine(chars);
            //Console.WriteLine(allowedChars.ToString());

            //gen
            password = GeneratePassword(length, chars);
            Console.WriteLine("\n" + password);
        }



        public string GeneratePassword(int length, IEnumerable<char> chars)
        {
            if(length <= 0)
            {
                throw new ArgumentException("Length must be greater than 0.", "length");
            }
            if(length > int.MaxValue / 8)
            {
                throw new ArgumentException("Length exceeds maximum length.", "length");
            }
            if(chars == null)
            {
                throw new ArgumentNullException("Character Set Error.");
            }

            var charArray = chars.Distinct().ToArray();
            if(charArray.Length == 0)
            {
                throw new ArgumentException("chars must not be empty", "chars");
            }

            var bytes = new byte[length * 8];
            new RNGCryptoServiceProvider().GetBytes(bytes);
            var result = new char[length];
            for(int i = 0; i < length; i++)
            {
                ulong value = BitConverter.ToUInt64(bytes, i * 8);
                result[i] = charArray[value % (uint)charArray.Length];
            }

            return new string(result);
        }
    }
}
