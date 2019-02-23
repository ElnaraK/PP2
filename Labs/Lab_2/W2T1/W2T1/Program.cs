using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_2
{
    class MainClass
    {
        private static void Main(string[] args)
        {
            //открываем файл для чтения
            using (FileStream fs = new FileStream(@"/Users/elnarak/Desktop/PP2/pal.txt", FileMode.Open, FileAccess.Read))
            {
                //читаем
                using (StreamReader sr = new StreamReader(fs))
                {
                    // преобразуем слово из файла в чар массив
                    string text = sr.ReadLine();
                    text.ToCharArray();
                    // проверяем на палиндромность и выводим ответ
                    for (int i = 0; i <= (text.Length / 2); ++i)
                    {
                        if (text[i] != text[text.Length - 1 - i])
                        {
                            Console.WriteLine("No");
                            break;
                        }
                        else if (i == text.Length / 2)
                        {
                            Console.WriteLine("Yes");
                        }
                    }
                }
            }
        }
    }
}
