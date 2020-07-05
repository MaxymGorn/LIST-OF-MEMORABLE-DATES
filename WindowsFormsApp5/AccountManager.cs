using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Runtime.Serialization.Formatters.Binary;
namespace WindowsFormsApp5
{
    class AccountManager
    {
        string path = @"..\..\Access\data.dat";
        string path2 = @"..\..\Access\INTIT_TMP.txt";
        BinaryFormatter BinaryFormatter = new BinaryFormatter();
        private Account account = new Account();
        public void InitAccount()
        {
            string login, password;
            using (FileStream fs = new FileStream(path2, FileMode.OpenOrCreate))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    login = sr.ReadLine();
                    password = sr.ReadLine();
                }
            }
            string loginHas = GetMd5Hash(login), passwordHash = GetMd5Hash(password);
            account.log = loginHas;
            account.pas = passwordHash;
            SaveData();
        }
        string GetMd5Hash(string input)
        {
            MD5 md5Hash = MD5.Create();
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
        void SaveData()
        {

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                BinaryFormatter.Serialize(fs, account);
            }

        }
        public void LoadAccount()
        {    
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
               account=(Account) BinaryFormatter.Deserialize(fs);
            }
        }
        public bool CheckAccount(string loginn, string parol)
        {
            if(GetMd5Hash(loginn)==account.log && GetMd5Hash(parol)==account.pas)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
