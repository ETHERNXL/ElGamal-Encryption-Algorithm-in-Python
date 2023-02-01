// See https://aka.ms/new-console-template for more information

using System.Numerics;
using System.Diagnostics;

ElGamala.InitializeValues();
ElGamala.Encrypt();
ElGamala.Decrypt();
static class ElGamala
{
    private static BigInteger p;
    private static BigInteger a;
    private static BigInteger x;
    private static BigInteger m;
    private static BigInteger y;
    private static BigInteger b;
    private static BigInteger e;
    private static BigInteger k;
    private static BigInteger md;

    public static void InitializeValues()
    {
        Console.Write("Input p: ");
        if (!BigInteger.TryParse(Console.ReadLine(), out p)) 
        { 
            Console.WriteLine("Value is null or not a number");
            return;
        }
        Console.Write("Input a: ");
        if (!BigInteger.TryParse(Console.ReadLine(), out a))
        {
            Console.WriteLine("Value is null or not a number");
            return;
        }
        Console.Write("Input x: ");
        if (!BigInteger.TryParse(Console.ReadLine(), out x))
        {
            Console.WriteLine("Value is null or not a number");
            return;
        }

        //Повідомлення з файлу в форматті ДДММ(день та місяць народження) 
        m = FileHandler.ReadLine();

        //розрахунок функції Ейлера від p
        BigInteger phi = EulerFunction(p);
        Console.WriteLine($"phi = {phi}");
        //Підбирає взаємно просте число y для phi 
        Random r = new Random();
        while (true)
        {
            BigInteger i = (BigInteger)r.Next(2, (int)phi);
            if (BigInteger.GreatestCommonDivisor(phi, i) == 1)
            {
                y = i;
                break;
            }
        }
        //Розраховую параметр b
        b = BigInteger.ModPow(a, x, p);
    }
    //Шифрую повідомлення
    public static void Encrypt()
    {
        e = BigInteger.ModPow(a, y, p);
        k = (BigInteger.Pow(b, (int)y) * m) % p;
    }
    //Розшифровую повідомлення 
    public static void Decrypt()
    {
        md = k * BigInteger.Pow(e, (int)(p-1-x)) % p;
        string[] strs = { $"Plain Text: {m}", $"Session key: {y}", $"Encrypted Text e,k: {e}, {k}", $"Decrypted Text: {md}" };
        foreach (string str in strs)
        {
            Console.WriteLine(str);
        }
        FileHandler.WriteLine(strs);
    }
    //Функція Ейлера(формулу можно спростити до p-1, якщо p просте)
    static BigInteger EulerFunction(BigInteger num)
    {
        BigInteger result = 0;
        for (BigInteger i = 2; i < num; i++)
        {
            if (BigInteger.GreatestCommonDivisor(num, i) == 1)
            {
                result++;
            }
            
        }
        return result;
    }
}




static class FileHandler
{
    public static BigInteger ReadLine()
    {
        return BigInteger.Parse(File.ReadLines("Input.txt").Last());
    }

    public static void WriteLine(string[] text)
    {
        File.WriteAllLines("output.txt", text);
        Process.Start(new ProcessStartInfo("output.txt") { UseShellExecute = true });
    }
}
