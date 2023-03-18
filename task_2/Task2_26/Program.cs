using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_26
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> words = new List<string>();
            string input = @"C:\Users\Admin\Documents\c#\Task2_26\input.txt";
            using (StreamReader reader = new StreamReader(input))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] line_words = line.Split(' ');
                    for (int i = 0; i < line_words.Length; i++)
                    {
                        words.Add(line_words[i]);
                    }
                }
            }
            string key = "дратути";
            string encode = "";
            string decode = "";
            string output = @"C:\Users\Admin\Documents\c#\Task2_26\output.txt";
            using (StreamWriter sw = new StreamWriter(output))
            {
              
                for (int j = 0; j < words.Count; j++)
                {
                      encode += Encode(words[j], key) + " ";
                        decode += Decode(Encode(words[j], key), key) + " ";
                }
                sw.WriteLine(encode);
                sw.WriteLine(decode);
            }

        }

        static string Encode(string input, string keyword)
        {
            char[] alfavit = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };
            

            input = input.ToLower();
            keyword = keyword.ToLower();

            string result = "";

            int keyword_index = 0;

            foreach (char symbol in input)
            {
                int c = (Array.IndexOf(alfavit, symbol) +
                    Array.IndexOf(alfavit, keyword[keyword_index])) % alfavit.Length;

                result += alfavit[c];

                keyword_index++;

                if ((keyword_index + 1) == keyword.Length)
                    keyword_index = 0;
            }

            return result;
        }

        static string Decode(string input, string keyword)
        {
            char[] alfavit = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };

            input = input.ToLower();
            keyword = keyword.ToLower();

            string result = "";

            int keyword_index = 0;

            foreach (char symbol in input)
            {
                int p = (Array.IndexOf(alfavit, symbol) + alfavit.Length -
                    Array.IndexOf(alfavit, keyword[keyword_index])) % alfavit.Length;

                result += alfavit[p];

                keyword_index++;

                if ((keyword_index + 1) == keyword.Length)
                    keyword_index = 0;
            }

            return result;
        }


    }
}
