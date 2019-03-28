using System;

namespace Codding
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "";

            Console.WriteLine("Enter your string: ");
            str = Console.ReadLine();

            int count = GetCountOfString(str);

            int[] strCount = new int[count];

            Clear();

            str = Mcode(str, strCount);
            Console.WriteLine(str);

            str = DoEnCodding(str, strCount);
            Console.WriteLine(str);

            Console.ReadKey();
        }



        public static string Mcode(string str, int[] list)
        {
            char ch;

            int[] arr = new int[26];

            int index, value;

            const string alfabet = "abcdefghijklmnopqrstuvwxyz";
            string otr = "";

            str = str.ToLower();

            for (int i = 0; i < str.Length; i++)
            {
                ch = str[i];

                if (ch == ' ' || ch == '!' || ch == '?' ||
                ch == '.' || ch == ',' || ch == ':' ||
                ch == ';')
                {
                    continue;
                }

                index = alfabet.IndexOf(ch);

                arr[index] += 1;
            }

            symbolCount(str, arr, list);

            for (int i = 0; i < str.Length; i++)
            {
                ch = str[i];
                if (ch == ' ' || ch == '!' || ch == '?' ||
                ch == '.' || ch == ',' || ch == ':' ||
                ch == ';')
                {
                    otr += ch;
                    continue;
                }

                index = alfabet.IndexOf(ch);
                value = arr[index];

                index += value;

                if (index + 1 > alfabet.Length) { index = index % alfabet.Length; }
                otr += alfabet[index];
            }

            return otr;
        }

        public static string DoEnCodding(string str, int[] list)
        {
            char ch;

            const string alfabet = "abcdefghijklmnopqrstuvwxyz";

            int index, value, indexof = 0;

            string otr = "";

            for (int i = 0; i < str.Length; i++)
            {
                ch = str[i];
                if (ch == ' ' || ch == '!' || ch == '?' ||
                ch == '.' || ch == ',' || ch == ':' ||
                ch == ';')
                {
                    otr += ch;
                    continue;
                }

                index = alfabet.IndexOf(ch);
                value = list[indexof];
                indexof++;

                if (index - value > 0)
                {
                    index = Math.Abs(index - value);
                }
                else
                {
                    index = alfabet.Length - Math.Abs(index - value);
                }

                if (index + 1 > alfabet.Length) { index = index % alfabet.Length; }

                otr += alfabet[index];
            }

            return otr;

        }

        public static int GetCountOfString(string str)
        {
            int scount = 0;
            char symbol;

            for (int i = 0; i < str.Length; i++)
            {
                symbol = str[i];

                if (symbol == ' ' || symbol == '!' || symbol == '?' ||
                symbol == '.' || symbol == ',' || symbol == ':' ||
                symbol == ';')
                {
                    continue;
                }
                else
                {
                    scount++;
                }
            }
            return scount;
        }

        public static void symbolCount(string str, int[] array, int[] list)
        {
            char symbol;
            int index, outindex = 0;
            const string alfabet = "abcdefghijklmnopqrstuvwxyz";

            for (int i = 0; i < str.Length; i++)
            {
                symbol = str[i];

                if (symbol == ' ' || symbol == '!' || symbol == '?' ||
                symbol == '.' || symbol == ',' || symbol == ':' ||
                symbol == ';')
                {
                    continue;
                }
                else
                {
                    index = alfabet.IndexOf(symbol);
                    list[outindex] = array[index];
                    outindex++;
                }
            }
        }

        public static void Clear()
        {
            Console.Clear();
        }
    }
}
