using System;

namespace W1T2
{
    class Student
    {
        string name;
        int id;
        int year;
        int idIncr = 0;
        public Student (string name, int year)
        {
            this.id = idIncr++;
            this.name = name;
            this.year = year;
        }

        public string GetName()
        {
            return this.name;
        }
        public int GetId()
        {
            return this.id;
        }
        public int GetYear()
        {
            return this.year;
        }
        public void IncrYear()
        {
            year++;
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            Student F = new Student("Almas", 1);
            Student S = new Student("Dinara", 2);
            Console.WriteLine(F.GetName() + " " + F.GetId() + " " + F.GetYear());
            Console.WriteLine(S.GetName() + " " + S.GetId() + " " + S.GetYear());

            F.IncrYear();
            Console.WriteLine(F.GetName() + " " + F.GetId() + " " + F.GetYear());
        }
    }
}
