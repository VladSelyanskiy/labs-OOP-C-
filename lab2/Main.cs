using System;
using System.Collections;
using System.Linq.Expressions;
using System.Reflection;

namespace lab2
{
    class Programm
    {
        static void Main()
        {
            Console.WriteLine("------------------------------------------");
            Person person1 = new("Patrick", "Bateman", new DateTime(2000, 01, 01));
            Person person2 = new("Patrick", "Bateman", new DateTime(2000, 01, 01));

            Console.WriteLine("Сравнение классов " + (person1 == person2));
            Console.WriteLine("Сравнение ссылок " + ReferenceEquals(person1, person2));
            Console.WriteLine("Хешкод первого класса " + person1.GetHashCode());
            Console.WriteLine("Хешкод второго класса " + person2.GetHashCode());
            Console.WriteLine("------------------------------------------");

            Console.WriteLine("------------------------------------------");
            Student student1 = new(Education.Вachelor, 
                240,
                [new Test("Germany Philosophy", true), new Test("Rus Philosophy", false)],
                [new Exam("Math", new DateTime(2020, 02, 02), 89)],
                person1);

            student1.AddExams(new Exam("Germany", new DateTime(2020, 02, 02), 42));

            Console.WriteLine(student1);
            Console.WriteLine("------------------------------------------");

            Console.WriteLine("------------------------------------------");
            Console.WriteLine(student1.PersonData);
            Console.WriteLine("------------------------------------------");

            Console.WriteLine("------------------------------------------");
            Student student2 = (Student)student1.DeepCopy();
            student2.FirstName = "Christian";
            student2.LastName = "Bale";
            student2.Group = 420;
            student2.Educat = Education.SecondEducation;
            Console.WriteLine(student1.ToShortString());
            Console.WriteLine(student2.ToShortString());
            Console.WriteLine("------------------------------------------");

            Console.WriteLine("------------------------------------------");
            try
            {
                student2.Group = 69420;
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception);
                Console.WriteLine(exception.Message);
            }
            Console.WriteLine("------------------------------------------");

            Console.WriteLine("------------------------------------------");
            foreach (object item in student1.GetEnumeratorAll())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Вывод экзаменов с количеством баллов выше указанного");
            foreach (object item in student2.GetEnumeratorExams(50))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("------------------------------------------");

        }
    }
}