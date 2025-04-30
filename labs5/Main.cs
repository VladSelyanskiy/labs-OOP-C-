using lab3;
using System;
using System.IO;

namespace lab4
{
    class Program
    {
        static void Main()
        {
            Person person1 = new("Patrick", "B.", new DateTime(2024, 01, 01));
            Person person2 = new("Patrick", "V.", new DateTime(2001, 01, 01));
            Person person3 = new("Patrick", "A.", new DateTime(2000, 01, 01));

            Student student1 = new(
                Education.Specialist,
                101,
                [],
                [new Exam("Math", DateTime.Now, 50)],
                person1
                );

            Student student2 = new(
                Education.Вachelor,
                202,
                [],
                [new Exam("Rus", new DateTime(), 89)],
                person2
                );

            Student student3 = new(
                Education.SecondEducation,
                202,
                [new Test()],
                [new Exam("Eng", new DateTime(), 52)],
                person3
                );

            // 1 ------------------------------------------------------------------
            Console.WriteLine("1 ----------------------------------------------");

            Student copiedStudent = student1.SerializedDeepCopy()!;
            copiedStudent.Group = 189;
            copiedStudent.FirstName = "Cristian";
            Console.WriteLine(student1.ToShortString());
            Console.WriteLine(copiedStudent.ToShortString());

            // 2 ------------------------------------------------------------------
            Console.WriteLine("2 -----------------------------------------------");

            Student newStudent = new();
            Console.WriteLine("Введит путь к файлу:");
            string filePath = Console.ReadLine()!;
            if (File.Exists(filePath))
            {
                newStudent.Load(filePath);
                Console.WriteLine("Загружен новый экземпляр класса");
                
            }
            else
            {
                Console.WriteLine("Файла с указанным именем нет");
                newStudent.Save(filePath);
                Console.WriteLine("Создан файл с указанным именем" +
                    " содержащий новый экземпляр класса");
            }

            // 3 -----------------------------------------------------------------
            Console.WriteLine("3 -----------------------------------------------");

            Console.WriteLine(newStudent);

            // 4 -----------------------------------------------------------------
            Console.WriteLine("4 -----------------------------------------------");

            newStudent.AddFromConsole();
            newStudent.Save(filePath);
            Console.WriteLine(newStudent);

            // 5 -----------------------------------------------------------------
            Console.WriteLine("5 -----------------------------------------------");

            Student.Load(filePath, newStudent);
            newStudent.AddFromConsole();
            Student.Save(filePath, newStudent);

            // 6 -----------------------------------------------------------------
            Console.WriteLine("6 -----------------------------------------------");
            Console.WriteLine(newStudent);

            // C:\\С#files\\log1.json
        }
    }
}