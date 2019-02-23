using System;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //вводим данные
            int n = Convert.ToInt32(Console.ReadLine());
            int[] Array = new int[n];
            for (int i = 0; i < n; ++i)
            {
                Array[i] = Convert.ToInt32(Console.ReadLine());
            }
            //стринг для записи ответа
            string ans = "";
            //каунтер 
            int k = 0;

            //основываясь на данных функции выводим ответ
            for (int i = 0; i < n; ++i)
            {
                if (IsPrime(Array[i]))
                {
                    k++;
                    ans += Array[i] + " ";
                }
            }
            Console.WriteLine(k);
            Console.WriteLine(ans);
        }
        //функция для проверки числа на простоту
        public static bool IsPrime(int a)
        {
            if (a == 1 || a == 0) return false;
            for (int i = 2; i <= Math.Sqrt(a); ++i)
            {
                if (a % i == 0)
                    return false;
            }
            return true;
        }
    }
}
