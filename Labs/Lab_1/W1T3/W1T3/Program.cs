using System;
namespace PP2
{
    class Task_3
    {
        public static void Main (string[] args)
        {
            // вводим число и конвертируем его в интеджер
            int num;
            num = Convert.ToInt32(Console.ReadLine());

            // вводим числа (добавляя их в одномерный массив) и конвертируем их в интеджер
            int[] array = new int[num];

            for (int i = 0; i < num; i++)
            {
                array[i] = Convert.ToInt32(Console.ReadLine());
            }
            //и выводим их дублируя каждый элемент массива
            for (int i = 0; i < num; i++)
            {
                Console.Write(array[i] + " " + array[i] + " ");
            }
            Console.ReadKey();
        }
    }
}
