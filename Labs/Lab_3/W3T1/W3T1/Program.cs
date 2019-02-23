using System;
using System.Collections.Generic;
using System.IO;

namespace Task1
{
    class Layer
    {
        int selectedItemIndex;//индекс выбранного файла  
        public FileSystemInfo[] Items
        {
            get;
            set;
        }
        public int SelectedItemIndex
        {
            get
            {
                return selectedItemIndex;
            }
            set
            {
                if (value >= Items.Length)
                {
                    selectedItemIndex = 0;
                }
                else if (value < 0)
                {
                    selectedItemIndex = Items.Length - 1;
                }
                else
                {
                    selectedItemIndex = value;
                }
            }
        }
        public Layer(FileSystemInfo[] items)
        {
            selectedItemIndex = 0;
            this.Items = items;
        }
        public void Draw()//функция для фона
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            int i = 0;
            foreach (var t in Items)
            {
                if (t is DirectoryInfo)//для папок
                {
                    Console.ForegroundColor = ConsoleColor.White;//цвет надписи белый
                    if (i == selectedItemIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;//цвет фона выбранной папки красный
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;//остальные черные
                    }
                    Console.WriteLine(i + 1 + ". " + t.Name);
                    i++;
                }
                else if (t is FileInfo)//для файлов
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;//цвет надписи желтый
                    if (i == selectedItemIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;//цвет фона выбранного файла красный
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;//остальные черные
                    }
                    Console.WriteLine(i + 1 + ". " + t.Name);
                    i++;
                }
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"/Users/elnarak/Desktop/Elka");//путь к папке
            Stack<Layer> history = new Stack<Layer>();
            history.Push(new Layer(dir.GetFileSystemInfos()));//делаем пуш 
            bool quit = false;
            while (!quit)
            {
                history.Peek().Draw();//добавляем функцию Draw
                ConsoleKeyInfo pressedKey = Console.ReadKey();//управляем клавиатурой
                if (pressedKey.Key == ConsoleKey.UpArrow)//если нажали стрелку вверх
                {
                    history.Peek().SelectedItemIndex--;//индекс -1 
                }
                else if (pressedKey.Key == ConsoleKey.DownArrow)//стрелка вниз
                {
                    history.Peek().SelectedItemIndex++;//индекс +1
                }
                else if (pressedKey.Key == ConsoleKey.Enter)//enter новый layer (открываем папку или файл)
                {
                    int x = history.Peek().SelectedItemIndex;
                    if (history.Peek().Items[x] is DirectoryInfo)//если это папка открываем ее и выводим на экран контент
                    {
                        DirectoryInfo y = history.Peek().Items[x] as DirectoryInfo;
                        history.Push(new Layer(y.GetFileSystemInfos()));
                    }
                    else
                    {
                        FileInfo fi = history.Peek().Items[x] as FileInfo;//если файл то считываем
                        //string fn = history.Peek().Items[x].FullName;
                        StreamReader sr = fi.OpenText();
                        string file = sr.ReadToEnd();
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;//черный на белом 
                        Console.Clear();
                        Console.Write(file);
                        Console.ReadKey();//не закрывать консоль
                    }
                }
                else if (pressedKey.Key == ConsoleKey.Backspace)//клавиша backspace
                {
                    history.Pop();//предыдущий layer
                }
                else if (pressedKey.Key == ConsoleKey.Q)//клавиша delete
                {
                    int x = history.Peek().SelectedItemIndex;
                    FileSystemInfo fsi = history.Peek().Items[x];
                    string fn = fsi.FullName;
                    if (history.Peek().Items[x] is DirectoryInfo)//если это папка удаляем и контент
                    {
                        Directory.Delete(fn, true);
                    }
                    else
                    {
                        File.Delete(fn);
                    }
                    fsi.Refresh();
                   
                }
                else if (pressedKey.Key == ConsoleKey.R)//Rename
                {
                    int x = history.Peek().SelectedItemIndex;
                    FileSystemInfo fsi = history.Peek().Items[x];
                    string fn = fsi.FullName;
                    if (history.Peek().Items[x] is FileInfo)
                    {
                        Console.WriteLine("Enter new file name:");
                        string FileName = Console.ReadLine();
                        string Dest = fn + "/" + FileName;
                        File.Move(fn, Dest);
                        fsi.Refresh();
                    }
                    else
                    {
                        Console.WriteLine("Enter new folder name:");
                        string FolderName = Console.ReadLine();
                        string Dest = fn + "/" + FolderName;
                        Directory.Move(fn, Dest);
                        fsi.Refresh();
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
