using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("C:/Users/User/Pictures/names/names/TextFile1.txt");
            string line, file;
            StringBuilder sb = new StringBuilder("");
            while ((line = reader.ReadLine()) != null)
            {
                sb.Append(line).Append(" ");
            }
            file = sb.ToString().Replace("Names:", "");
            int x = file.IndexOf("Synonyms:");
            string synonymsStr = file.Substring(x, file.Length - x).Replace("Synonyms: ", "").Replace("(", "").Replace(")", "").Trim();
            string namesStr = file.Substring(0, x - 2).Replace("(", "").Replace(")", "").Trim();
            Dictionary<string, int> names = InputNames(namesStr);
            Dictionary<string, string> nicknames = InputNickNames(synonymsStr);
            reader.Close();
            Dictionary<string, int> code = FindCode(names, nicknames);
            Frequency(names, code);
            Console.Read();
        }

        private static Dictionary<string, string> InputNickNames(string synonymsStr)
        {
            Dictionary<string, string> nicknames = new Dictionary<string, string>();
            string[] synonymsArr = synonymsStr.Trim().Split(',');
            for (int i = 0; i < synonymsArr.Length; i+=2)
            {
                nicknames.Add(synonymsArr[i].Trim(), synonymsArr[i+1].Trim());
            }
            return nicknames;
        }

        private static Dictionary<string, int> InputNames(string namesStr)
        {
            Dictionary<string, int> names = new Dictionary<string, int>();
            string[] namesArr = namesStr.Split(',');
            string[] keyAndVal;
            foreach (var item in namesArr)
            {
                keyAndVal = item.Trim().Split(' ');
                names.Add(keyAndVal[0], int.Parse(keyAndVal[1]));
            }
            return names;
        }

        private static void Frequency(Dictionary<string, int> names, Dictionary<string, int> code)
        {
            Dictionary<int, int> end = new Dictionary<int, int>();
            foreach (var item in names)
            {
                if (!end.ContainsKey(code.First(q => q.Key == item.Key).Value))
                    end.Add(code.First(q => q.Key == item.Key).Value, item.Value);
                else
                    end[code.First(q => q.Key == item.Key).Value] += item.Value;
            }
            foreach (var item in end)
            {
                Console.WriteLine(code.First(q => q.Value == item.Key).Key + " " + item.Value);
            }

        }

        private static Dictionary<string, int> FindCode(Dictionary<string, int> names, Dictionary<string, string> nicknames)
        {
            int num = 0;
            Dictionary<string, int> code = new Dictionary<string, int>();
            foreach (var item in nicknames)
            {
                foreach (var i in nicknames)
                {
                    if (item.Key == i.Value)
                    {
                        num++;
                        if (!code.ContainsKey(item.Key))
                        {
                            if (code.ContainsKey(item.Value))
                                num = code[item.Value];
                            code.Add(item.Key, num);
                        }
                        else
                            num = code[item.Key];
                        if (!code.ContainsKey(item.Value))
                            code.Add(item.Value, num);
                        else
                            num = code[item.Value];
                        if (!code.ContainsKey(i.Key))
                            code.Add(i.Key, num);
                        else
                            num = code[i.Key];
                    }
                    else if (item.Value == i.Key)
                    {
                        num++;
                        if (!code.ContainsKey(item.Key))
                        {
                            if (code.ContainsKey(item.Value))
                                num = code[item.Value];
                            else if (code.ContainsKey(i.Value))
                                num = code[i.Value];
                            code.Add(item.Key, num);
                        }
                        else
                            num = code[item.Key];
                        if (!code.ContainsKey(item.Value))
                            code.Add(item.Value, num);
                        else
                            num = code[item.Value];
                        if (!code.ContainsKey(i.Value))
                            code.Add(i.Value, num);
                        else
                            num = code[i.Value];
                    }
                }
            }
            num++;
            foreach (var item in nicknames)
            {
                if (!code.ContainsKey(item.Key))
                {
                    num++;
                    if (!code.ContainsKey(item.Value))
                    {
                        code.Add(item.Value, num);
                        code.Add(item.Key, num);
                    }
                    else
                    {
                        num = code[item.Value];
                        code.Add(item.Key, num);
                    }
                }
            }
            return code;
        }
    }
}
