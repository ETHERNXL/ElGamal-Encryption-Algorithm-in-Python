namespace Namespace
{

    using random;

    using System;

    public static class Module
    {

        public static object fopen = open("read.txt", "r");

        public static object p = Convert.ToInt32(fopen.readline());

        public static object a = Convert.ToInt32(fopen.readline(2));

        public static object x = Convert.ToInt32(fopen.readline(3));

        static Module()
        {
            fopen.close;
            wf.write("Зашифроване повідомлення: " + e.ToString() + " " + k.ToString());
            wf.write("\nРозшифроване повідомлення: " + decript.ToString());
            wf.close;
            input();
        }

        public static object m = Convert.ToInt32(input("Введіть число m (Дата народження ММД): "));

        public static object b = Math.Pow(a, x) % p;

        public static object y = random.randint(1, p - 1);

        public static object e = Math.Pow(a, y) % p;

        public static object k = m * Math.Pow(b, y) % p;

        public static object wf = open("out.txt", "w", encoding: "utf-8");

        public static object decript = Convert.ToInt32(k) * pow(Convert.ToInt32(e), p - 1 - x) % p;
    }
}
