using System;
using System.IO;

namespace Task2_26
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            var encoding = System.Text.Encoding.GetEncoding("windows-1251");
            Console.WriteLine("Write file path");
            string pathIn_1 = @"C:\Users\User\source\repos\Task2_26\";
            pathIn_1 += Console.ReadLine() + ".txt";
            Console.WriteLine(pathIn_1);
            Console.WriteLine("Write file path for encoding text");
            string pathOutEncode = @"C:\Users\User\source\repos\Task2_26\";
            pathOutEncode += Console.ReadLine() + ".txt";
            Console.WriteLine("Write file path for decoding text");
            string pathOutDecode = @"C:\Users\User\source\repos\Task2_26\";
            pathOutDecode += Console.ReadLine() + ".txt";
            char[] characters = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K',
                                                'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V',
                                                'W', 'X', 'Y', 'Z',
                                                'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И',
                                                'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С',
                                                'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь', 'Ы', 'Ъ',
                                                'Э', 'Ю', 'Я',
                                                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k',
                                                'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v',
                                                'w', 'x', 'y', 'z',
                                                'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и',
                                                'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с',
                                                'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ь', 'ы', 'ъ',
                                                'э', 'ю', 'я', ' ', '1', '2', '3', '4', '5', '6', '7',
                                                '8', '9', '0', '(', ')', ']', '[', '{', '}', ',', ':', ';', '.', '-', '\n'};
            Console.WriteLine("Write a key");
            string key = Console.ReadLine();
            string res = encode(characters, readFromFile_1(pathIn_1), key);
            Console.WriteLine("Начальный текст:");
            Console.WriteLine(readFromFile_1(pathIn_1));
            Console.WriteLine("Закодированный текст:");
            Console.WriteLine(res);
            Console.WriteLine("Декодированный текст:");
            Console.WriteLine(decode(characters, res, key));
            writeToFile(pathOutEncode, res);
            writeToFile(pathOutDecode, decode(characters, res, key));
        }

        static string encode(char[] characters, string input, string keyword)
        {
            int N = characters.Length;

            string result = "";

            int keyword_index = 0;

            foreach (char symbol in input)
            {
                int c = (Array.IndexOf(characters, symbol) +
                    Array.IndexOf(characters, keyword[keyword_index])) % N;

                result += characters[c];
                keyword_index++;

                if ((keyword_index + 1) == keyword.Length)
                    keyword_index = 0;
            }
            return result;
        }

        static string decode(char[] characters, string input, string keyword)
        {

            int N = characters.Length;

            string result = "";

            int keyword_index = 0;

            foreach (char symbol in input)
            {
                int p = (Array.IndexOf(characters, symbol) + N -
                    Array.IndexOf(characters, keyword[keyword_index])) % N;

                result += characters[p];
                keyword_index++;

                if ((keyword_index + 1) == keyword.Length)
                    keyword_index = 0;
            }
            return result;
        }

        static void writeToFile(string path, string text)
        {
            try
            {
                StreamWriter sw = new StreamWriter(path);
                sw.WriteLine(text);
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        static string readFromFile_1(string path)
        {
            string text = System.IO.File.ReadAllText(path);
            return text;
        }
    }
}
