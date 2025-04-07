using lab3;
using System;

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
                [new Exam("M", new DateTime(), 50)],
                person1
                );

            Student student2 = new(
                Education.Вachelor,
                202,
                [],
                [new Exam("M", new DateTime(), 89)],
                person2
                );

            Student student3 = new(
                Education.SecondEducation,
                202,
                [new Test()],
                [new Exam()],
                person3
                );

            // ----------------------------------------------------------------

            StudentCollection list1 = new();
            StudentCollection list2 = new();

            list1.Title = "list1";
            list2.Title = "list2";

            Journal journal1 = new("All", list1);
            Journal journal2 = new("Reference", list1, list2);

            Console.WriteLine("--------------------------------------------");

            list1.AddDefaults(student1);
            list1.AddStudents(student2, student3);
            list1.Remove(1);
            list1[0] = student2;

            list2.AddStudents(student3);
            list2[0] = student1;

            Console.WriteLine("Journal 1 \n");
            Console.WriteLine(journal1);
            Console.WriteLine("Journal 2 \n");
            Console.WriteLine(journal2);
            
        }
    }
}