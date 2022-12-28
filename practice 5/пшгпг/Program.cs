using System;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main()
    {
        var des = new DesEncryption();
        var key = des.GenerateRandomNumber();
        var iv = des.GenerateRandomNumber();
        const string original = "Message for encryption";
        var encrypted = des.Encrypt(Encoding.UTF8.GetBytes(original), key, iv);
        var decrypted = des.Decrypt(encrypted, key, iv);
        var decryptedMessage = Encoding.UTF8.GetString(decrypted);
        Console.WriteLine("DES");
        Console.WriteLine("-------------------------");
        Console.WriteLine();
        Console.WriteLine("Original Text = " + original);
        Console.WriteLine("Encrypted Text = " + Convert.ToBase64String(encrypted));
        Console.WriteLine("Decrypted Text = " + decryptedMessage);

        var triple_des = new TripleDesEncryption();
        var tkey = triple_des.GenerateRandomNumber(16);
        var tiv = triple_des.GenerateRandomNumber(8);
        var tencrypted = triple_des.Encrypt(Encoding.UTF8.GetBytes(original), tkey, tiv);
        var tdecrypted = triple_des.Decrypt(tencrypted, tkey, tiv);
        var tdecryptedMessage = Encoding.UTF8.GetString(tdecrypted);
        Console.WriteLine("Triple DES");
        Console.WriteLine("-------------------------");
        Console.WriteLine();
        Console.WriteLine("Original Text = " + original);
        Console.WriteLine("Encrypted Text = " + Convert.ToBase64String(tencrypted));
        Console.WriteLine("Decrypted Text = " + tdecryptedMessage);

        var aes = new AesEncryption();
        var akey = aes.GenerateRandomNumber(32);
        var aiv = aes.GenerateRandomNumber(16);
        var aencrypted = aes.Encrypt(Encoding.UTF8.GetBytes(original), akey, aiv);
        var adecrypted = aes.Decrypt(aencrypted, akey, aiv);
        var adecryptedMessage = Encoding.UTF8.GetString(adecrypted);
        Console.WriteLine("AES");
        Console.WriteLine("-------------------------");
        Console.WriteLine();
        Console.WriteLine("Original Text = " + original);
        Console.WriteLine("Encrypted Text = " + Convert.ToBase64String(aencrypted));
        Console.WriteLine("Decrypted Text = " + adecryptedMessage);
    }

    class DesEncryption
    {
        public byte[] GenerateRandomNumber()
        {
            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[8];
                randomNumberGenerator.GetBytes(randomNumber);
                return randomNumber;
            }
        }

        public byte[] Encrypt(byte[] dataToEncrypt, byte[] key, byte[] iv)
        {
            using (var des = new DESCryptoServiceProvider())
            {
                des.Mode = CipherMode.CBC;
                des.Padding = PaddingMode.PKCS7;
                des.Key = key;
                des.IV = iv;
                using (var memoryStream = new MemoryStream())
                {
                    var cryptoStream = new CryptoStream(memoryStream, des.CreateEncryptor(), CryptoStreamMode.Write);
                    cryptoStream.Write(dataToEncrypt, 0, dataToEncrypt.Length);
                    cryptoStream.FlushFinalBlock();
                    return memoryStream.ToArray();
                }
            }
        }



        public byte[] Decrypt(byte[] dataToDecrypt, byte[] key, byte[] iv)
        {
            using (var des = new DESCryptoServiceProvider())
            {
                des.Mode = CipherMode.CBC;
                des.Padding = PaddingMode.PKCS7;
                des.Key = key;
                des.IV = iv;
                using (var memoryStream = new MemoryStream())
                {
                    var cryptoStream = new CryptoStream(memoryStream, des.CreateDecryptor(), CryptoStreamMode.Write);
                    cryptoStream.Write(dataToDecrypt, 0, dataToDecrypt.Length);
                    cryptoStream.FlushFinalBlock();
                    return memoryStream.ToArray();
                }
            }
        }
    }

    class TripleDesEncryption
    {
        public byte[] GenerateRandomNumber(int length)
        {
            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[length];
                randomNumberGenerator.GetBytes(randomNumber);
                return randomNumber;
            }
        }
        public byte[] Encrypt(byte[] dataToEncrypt, byte[] key, byte[] iv)
        {
            using (var des = new TripleDESCryptoServiceProvider())
            {
                des.Mode = CipherMode.CBC;
                des.Padding = PaddingMode.PKCS7;
                des.Key = key;
                des.IV = iv;
                using (var memoryStream = new MemoryStream())
                {
                    var cryptoStream = new CryptoStream(memoryStream, des.CreateEncryptor(), CryptoStreamMode.Write);
                    cryptoStream.Write(dataToEncrypt, 0, dataToEncrypt.Length);
                    cryptoStream.FlushFinalBlock();
                    return memoryStream.ToArray();
                }
            }
        }
        public byte[] Decrypt(byte[] dataToDecrypt, byte[] key, byte[] iv)
        {
            using (var des = new TripleDESCryptoServiceProvider())
            {
                des.Mode = CipherMode.CBC;
                des.Padding = PaddingMode.PKCS7;
                des.Key = key;
                des.IV = iv;
                using (var memoryStream = new MemoryStream())
                {
                    var cryptoStream = new CryptoStream(memoryStream, des.CreateDecryptor(), CryptoStreamMode.Write);
                    cryptoStream.Write(dataToDecrypt, 0, dataToDecrypt.Length);
                    cryptoStream.FlushFinalBlock();
                    return memoryStream.ToArray();
                }
            }
        }
    }

    class AesEncryption
    {
        public byte[] GenerateRandomNumber(int length)
        {
            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[length];
                randomNumberGenerator.GetBytes(randomNumber);
                return randomNumber;
            }
        }
        public byte[] Encrypt(byte[] dataToEncrypt, byte[] key, byte[] iv)
        {
            using (var aes = new AesCryptoServiceProvider())
            {
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                aes.Key = key;
                aes.IV = iv;
                using (var memoryStream = new MemoryStream())
                {
                    var cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write);
                    cryptoStream.Write(dataToEncrypt, 0, dataToEncrypt.Length);
                    cryptoStream.FlushFinalBlock();
                    return memoryStream.ToArray();
                }
            }
        }

        public byte[] Decrypt(byte[] dataToDecrypt, byte[] key, byte[] iv)
        {
            using (var des = new AesCryptoServiceProvider())
            {
                des.Mode = CipherMode.CBC;
                des.Padding = PaddingMode.PKCS7;
                des.Key = key;
                des.IV = iv;
                using (var memoryStream = new MemoryStream())
                {
                    var cryptoStream = new CryptoStream(memoryStream, des.CreateDecryptor(), CryptoStreamMode.Write);
                    cryptoStream.Write(dataToDecrypt, 0, dataToDecrypt.Length);
                    cryptoStream.FlushFinalBlock();
                    return memoryStream.ToArray();
                }
            }
        }

    }
}
