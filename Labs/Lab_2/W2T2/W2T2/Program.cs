using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W2T2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string ans = "";
            using (FileStream fs = new FileStream(@"/Users/elnarak/Desktop/PP2/input.txt", FileMode.Open, FileAccess.ReadWrite))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string str = sr.ReadLine();
                    string[] nums = str.Split();
                    int[] text = new int[nums.Length];
                    for (int i = 0; i < nums.Length; ++i)
                    {
                        text[i] = Convert.ToInt32(nums[i]);
                    }
                    for (int i = 0; i < nums.Length; ++i)
                    {
                        if (IsPrime(text[i]))
                            ans += text[i] + " ";
                    }
                }
            }
            using (FileStream fs2 = new FileStream(@"/Users/elnarak/Desktop/PP2/output.txt", FileMode.CreateNew, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs2))
                {
                    sw.Write(ans);
                }
            }
        }
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
