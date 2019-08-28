using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataLogic
{
    public class Encriptado
    {
        public static string Encriptar(string cadena)
        {
            try
            {
                MD5 md5Hash = MD5.Create();
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(cadena));

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
                cadena=sBuilder.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return cadena;
        }


        public static string Desencriptar(string cadena)
        {
            try
            {
                string hashOfInput = Encriptar(cadena);

                // Create a StringComparer an compare the hashes.
                StringComparer comparer = StringComparer.OrdinalIgnoreCase;

                    return cadena;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }





    }
}
