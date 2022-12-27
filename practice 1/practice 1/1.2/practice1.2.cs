using System.Security.Cryptography;

class Random_Crypt_Generator
{
    public static void Main()
    {
        Console.Write("Enter lenght: ");
        int length = Convert.ToInt32(Console.ReadLine());

        var rndNumberGenerator = new RNGCryptoServiceProvider();
        var rndNum = new byte[length];

        rndNumberGenerator.GetBytes(rndNum);
        string cryptoKey = Convert.ToBase64String(rndNum);

        Console.Write("\nBytes: ");
        for (int i = 0; i < length; i++)
        {
            Console.Write(rndNum[i]);
        };

        Console.Write("\n\nText: ");
        Console.WriteLine(cryptoKey);
    }
}