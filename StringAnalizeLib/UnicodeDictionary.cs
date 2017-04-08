using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringAnalizeLib
{
    public class UnicodeDictionary
    {
        public UnicodeDictionary() { }

        private Dictionary<string, string> bags = new Dictionary<string, string>();

        public Dictionary<string, string> fillDictionary()
        {
            bags.Add("~nl", "\u000A"); // перенос строки
            bags.Add("~kross", "\uD83D\uDC5F"); // кроссовок
            bags.Add("~phone", "\u260E"); // стационарный телефон
            bags.Add("~mobilephone", "\uD83D\uDCF2"); // сотовый телефон
            bags.Add("~office", "\uD83C\uDFE4"); // дом (офис)
            bags.Add("~airplane", "\u2708"); // самолёт (1 вариант)
            bags.Add("~airplane2", "\uD83D\uDEEB"); // самолёт (2 вариант)
            bags.Add("~airplane3", "\uD83D\uDEEC"); // самолёт (3 вариант)
            bags.Add("~airplane4", "\uD83D\uDEE9"); // самолёт (4 вариант)
            bags.Add("~rocket", "\uD83D\uDE80"); // ракета
            bags.Add("~euro", "\uD83D\uDCB6"); // купюра евро
            bags.Add("~thumbsup", "\uD83D\uDC4D"); // палец вверх (лайк)
            bags.Add("~fingertolink", "\uD83D\uDC47"); // указательный палец вниз
            bags.Add("~smile", "\uD83D\uDE0A"); // улыбка
            bags.Add("~heart", "\u2665"); // сердечко
            bags.Add("~valentineheart", "\uD83D\uDC9D"); // сердечко в виде подарка
            bags.Add("~kiss", "\uD83D\uDE17"); // поцелуй

            return bags;
        }

        public string getValue(string key)
        {
            return (bags.ContainsKey(key)) ? bags[key] : " ";
        }
    }
}