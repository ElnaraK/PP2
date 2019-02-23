using System;
using System.IO;
using System.Text;

class Test
{
    public static void Main()
    {
        string Src = @"/Users/elnarak/Desktop/PP2/1.txt";
        string Dst = @"/Users/elnarak/Desktop/Elka/2.txt";
        // Создаем тхт файл (внутри текст "Source file")
        using (FileStream fs = File.Create(Src))
        {
            Byte[] info = new UTF8Encoding(true).GetBytes("Source file");
            fs.Write(info, 0, info.Length);
        }
        //копируем
        File.Copy(Src, Dst, true);

        File.Delete(Src);
    }
}