using System;

namespace PP2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //вводим и конвертируем число в интеджер
            int num;
            num = Convert.ToInt32(Console.ReadLine());

            //создаем двумерный чар массив
            char[,] array = new char[num, num];
            //заполняем массив и выводим
            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < num; j++)
                {
                    if (i >= j)
                    {
                        Console.Write("[*]");
                    }
                    else
                    {
                        continue;
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
