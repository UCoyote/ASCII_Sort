using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCII_Sort
{
    class Program
    {
        private static void ShowHelp()
        {
            Console.Title = "ASCll码快捷升序/降序排序小工具  Author: wubinluo  Email:501202461@qq.com";
            Console.WriteLine("请输入需要排序的字符/字符串，字符串与字符串之间用空格分隔开");
            Console.WriteLine("命令：exit(退出)，clear(清空日志输出)");
        }
        static void Main(string[] args)
        {
            ShowHelp();
            while (true)
            {
                string readStr = Console.ReadLine();
                if (readStr == "exit")
                {
                    Environment.Exit(0);
                    return;
                }
                else if (readStr == "clear")
                {
                    Console.Clear();
                    ShowHelp();
                }
                else {
                    string[] strs = readStr.Split(' ');
                    List<string> sortList = new List<string>();
                    for (int i = 0; i < strs.Length; i++)
                    {
                        if (string.IsNullOrEmpty(strs[i])) continue;
                        sortList.Add(strs[i]);
                    }
                    if (sortList.Count == 1)
                    {
                        List<char> sortResultList = StortAscllCodeBySingleStr(sortList[0]);

                        string res = string.Empty;
                        for (int i = 0; i < sortResultList.Count; i++)
                        {
                            res += sortResultList[i] + " ";
                        }
                        Console.WriteLine("ASCll码升序排序结果:" + res);
                        res = string.Empty;
                        for (int i = sortResultList.Count - 1; i >= 0; i--)
                        {
                            res += sortResultList[i] + " ";
                        }
                        Console.WriteLine("ASCll码降序排序结果:" + res);
                    }
                    else
                    {
                        for (int i = 0; i < sortList.Count; i++)
                        {

                            for (int j = 0; j < sortList.Count - 1; j++)
                            {
                                if (CheckAscllCodeByStrs(sortList[j], sortList[j + 1]) == false)
                                {
                                    string bStr = sortList[j + 1];
                                    sortList[j + 1] = sortList[j];
                                    sortList[j] = bStr;
                                }
                            }
                        }
                        string res = string.Empty;
                        for (int i = 0; i < sortList.Count; i++)
                        {
                            res +=sortList[i]+" ";
                        }
                        Console.WriteLine("ASCll码升序排序结果:" + res);
                        res = string.Empty;
                        for (int i = sortList.Count - 1; i >= 0; i--)
                        {
                            res += sortList[i] + " ";
                        }
                        Console.WriteLine("ASCll码降序排序结果:" + res);
                    }
                }
                
            }
            
            Console.ReadKey();
        }

        private static bool CheckAscllCodeByStrs(string str_1,string str_2)
        {
            for (int i = 0; i < str_2.Length; i++)
            {
                int b_code = (int)(str_2[i]);
                if (i < str_1.Length)
                {
                    int a_code = (int)str_1[i];
                    if (a_code < b_code)
                        return true;
                    else if (a_code > b_code)
                        return false;
                }
            }
            return true;
        }
        private static List<char> StortAscllCodeBySingleStr(string str_1)
        {
            List<char> sortList = new List<char>();
            for (int i = 0; i < str_1.Length; i++)
            {
                if (str_1[i] == ' ') continue;
                sortList.Add(str_1[i]);
            }
            for (int i = 0; i < sortList.Count; i++)
            {
                
                for (int j = 0; j < sortList.Count-1; j++)
                {
                    int a_code = (int)(sortList[j]);
                    int b_code = (int)sortList[j+1];
                    if (b_code < a_code)
                    {
                        char b_char = sortList[j+1];
                        sortList[j+1] = sortList[j];
                        sortList[j] =b_char;
                    }
                }
               
            }
            return sortList;
        }
    }
}
