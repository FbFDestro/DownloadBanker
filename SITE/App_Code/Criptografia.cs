using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

// namespace Cripto_C_Java SAI EM SITE, TEM NO PROG
//{ SAI EM SITE, TEM NO PROG

public class Criptografia
    {
              
        private readonly ICryptoTransform _decryptor;

        private readonly ICryptoTransform _encryptor;

        private static readonly byte[] IV = Encoding.UTF8.GetBytes("ThisIsUrPassword");

        private readonly byte[] _password;

        private readonly RijndaelManaged _cipher;

        private ICryptoTransform Decryptor { get { return _decryptor; } }
        private ICryptoTransform Encryptor { get { return _encryptor; } }


        public Criptografia(string password)
        {
            //Definindo o método de codificação para compilar a criptografia
            var md5 = new MD5CryptoServiceProvider();
            _password = md5.ComputeHash(Encoding.UTF8.GetBytes(password));

            //Inicializando os objetos
            _cipher = new RijndaelManaged();
            _cipher.Padding = PaddingMode.PKCS7;
            _decryptor = _cipher.CreateDecryptor(_password, IV);
            _encryptor = _cipher.CreateEncryptor(_password, IV);

        }

      
        public string Decrypt(string text)
        {
            try
            {
                byte[] input = Convert.FromBase64String(text);

                var newClearData = Decryptor.TransformFinalBlock(input, 0, input.Length);
                return Encoding.UTF8.GetString(newClearData);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine("Valor de entrada inválido." + ae);
                return null;
            }
            catch (ObjectDisposedException oe)
            {
                Console.WriteLine("Objeto já foi excluído." + oe);
                return null;
            }
        }

 
        public string Encrypt(string text)
        {
            try
            {
                var buffer = Encoding.UTF8.GetBytes(text);
                return Convert.ToBase64String(Encryptor.TransformFinalBlock(buffer, 0, buffer.Length));
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine("Valor de entrada inválido." + ae);
                return null;
            }
            catch (ObjectDisposedException oe)
            {
                Console.WriteLine("Objeto já foi excluído." + oe);
                return null;
            }
        }

    }
// } SAI EM SITE, TEM NO PROG 

