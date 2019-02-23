using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W2T3
{
    class MainClass
    {
        private static void Main(string[] args)
        {
            DirectoryInfo directory = new DirectoryInfo(@"/Users/elnarak/Labs");
            PrintInfo(directory, 0);
        }

        private static void PrintInfo(FileSystemInfo info, int v)
        {
            string s = new string(' ', v);
            Console.WriteLine(s + info.Name);

            if (info is DirectoryInfo)
            {
                FileSystemInfo [] arr = ((DirectoryInfo)info).GetFileSystemInfos();
                for(int i=0; i<arr.Length; ++i)
                {
                    PrintInfo(arr[i], v + 3);
                }
            }
        }
    }
}
