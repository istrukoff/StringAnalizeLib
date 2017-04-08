using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringAnalizeLib
{
    public class StringAnalize
    {
        public StringAnalize() { }

        public StringAnalize(string p_input)
        {
            input = p_input;
        }

        private string input;
        public string Input { get { return input; } set { input = value; } }

        // функция обработки { | }
        private string parseBrace(string s)
        {
            Random rnd = new Random();
            if (s.Contains('{'))
            {
                int clspos = s.IndexOf('}'); // ищем первую закрывающуюся скобку
                int opnpos = clspos;
                while (!s[opnpos].Equals('{')) // ищем соответствующую ей открывающуюся скобку
                    opnpos--;
                string block = s.Substring(opnpos, clspos - opnpos + 1); // берём подстроку между ними
                string[] items = block.Substring(1, block.Length - 2).Split('|'); // разбиваем подстроку указанным символом на массив строк
                s = s.Replace(block, items[rnd.Next(items.Length)]); // берём из полученного массива случайную строку и передаём её в результирующую строку
                return parseBrace(s); // рекурсивно вызываем функцию
            }
            else
                return s.Trim();
        }

        // перемешивание массива строк
        private string randomizeString(string[] items)
        {
            string result = "";
            Random rnd = new Random();
            int c = items.Length;

            for (int i = 0; i < c; i++)
            {
                int k = rnd.Next(c);
                string m = items[k];
                items[k] = items[i];
                items[i] = m;
            }

            foreach (string t in items)
                result += t + " ";

            return result.Trim();
        }

        // функция обработки [ | ]
        private string parseSquare(string s)
        {
            if (s.Contains('['))
            {
                int clspos = s.IndexOf(']'); // ищем первую закрывающуюся скобку
                int opnpos = clspos;
                while (!s[opnpos].Equals('[')) // ищем соответствующую ей открывающуюся скобку
                    opnpos--;
                string block = s.Substring(opnpos, clspos - opnpos + 1); // берём подстроку между ними
                string[] items = block.Substring(1, block.Length - 2).Split('|'); // разбиваем подстроку указанным символом на массив строк
                s = s.Replace(block, randomizeString(items)); // перемешиваем строки в полученном массиве и передаём их в результирующую строку
                return parseSquare(s); // рекурсивно вызываем функцию
            }
            else
                return s.Trim();
        }

        // функция обработки символов Unicode
        private string parseUnicode(string s)
        {
            StringBuilder result = new StringBuilder();
            UnicodeDictionary dictionary = new UnicodeDictionary();
            dictionary.fillDictionary();
            string[] bag = s.Split(' ');

            foreach (string t in bag)
                if (t.Contains("~"))
                    result.Append(dictionary.getValue(t));
                else
                    result.Append((Array.IndexOf(bag, t) == 0) ? t : " " + t);

            return result.ToString();
        }

        public string getParsedString()
        {
            string parse_brace = parseBrace(input);
            string parse_square = parseSquare(parse_brace);
            return parseUnicode(parse_square);
        }
    }
}