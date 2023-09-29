using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EM4.App.Repository
{
    public class Utils
    {
        private static string SaltString = "Fastwork092";

        public static string GetHash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Mengkonversi salt dari string menjadi byte array
                byte[] salt = Encoding.UTF8.GetBytes(SaltString);

                // Ubah input menjadi byte array
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);

                // Gabungkan salt dengan data masukan
                byte[] saltedInput = new byte[inputBytes.Length + salt.Length];
                Buffer.BlockCopy(inputBytes, 0, saltedInput, 0, inputBytes.Length);
                Buffer.BlockCopy(salt, 0, saltedInput, inputBytes.Length, salt.Length);

                // Hitung hash
                byte[] hashBytes = sha256.ComputeHash(saltedInput);

                // Konversi byte array ke dalam bentuk string heksadesimal
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
