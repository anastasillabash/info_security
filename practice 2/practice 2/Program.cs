using System.Text;

class xor
{
        public static void Main(string[] args)
    {
        byte[] inform = File.ReadAllBytes(@"C:\Users\ferhe\Desktop\універ\основи безпеки 2_1\info_security\practice 2\text.txt").ToArray(); //зчитування файлу
        Console.WriteLine(Encoding.UTF8.GetString(inform));
        Console.WriteLine("1. encrypt file");
        Console.WriteLine("2. decrypt file");
        int option = Convert.ToInt32(Console.ReadLine());
        string path = @"C:\Users\ferhe\Desktop\універ\основи безпеки 2_1\info_security\practice 2\text.txt";

        switch (option)
        {
            case 1:
                {
                    var exor = new XOR_Program();
                    Console.WriteLine("Write password");//ввід ключа
                    string keyword = Console.ReadLine();
                    byte[] password = Encoding.UTF8.GetBytes(keyword); //перетворення текстових символів у послідовність байтів
                    var encr = exor.XoR(inform, password); //шифрквання повідомлення
                    Console.WriteLine("Done");
                    File.WriteAllBytes(path + "file.dat", encr); //зберігання до файлу
                    break;
                }
            case 2:
                {
                    byte[] encryptContent = File.ReadAllBytes(path + "file.dat").ToArray(); //зчитування зашифрованого повідомлення
                    var dxor = new XOR_Program();
                    Console.WriteLine("Write password"); //ввід ключа
                    string keyword = Console.ReadLine(); 
                    byte[] password = Encoding.UTF8.GetBytes(keyword); //перетворення текстових символів у послідовність байтів
                    var decr = dxor.XoR(encryptContent, password); //дешифруання повідомлення
                    Console.WriteLine("Done");
                    File.WriteAllBytes(path + "file.txt", decr); //зберігання до файлу
                    break;
                }
        }
    }

    public class XOR_Program //функція виключного або
    {
        private byte[] GetKey(byte[] key, byte[] array)
        {
            byte[] secret = new byte[array.Length];
            for (int i = 0; i < secret.Length; i++)
            {
                secret[i] = key[i % key.Length];
            }
            return secret;
        }
        public byte[] XoR(byte[] text, byte[] key)
        {
            for (int i = 0; i < text.Length; i++)
            {
                text[i] = (byte)(text[i] ^ GetKey(key, text)[i]);
            }
            return text;
        }
    }
}

