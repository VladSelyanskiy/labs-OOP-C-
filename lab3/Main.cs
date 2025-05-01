using System;

namespace lab3
{
    class Programm
    {
        static void Main()
        {
            // Создание StudentCollection
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

            StudentCollection list = new();
            list.AddDefaults(student1);
            list.AddStudents([student2, student3]);

            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Коллекция студентов\n" + list);
            list.SortByLastName();
            Console.WriteLine("Отсортирована по фамилии\n" + list);
            list.SortByDate();
            Console.WriteLine("Отсортирована по дате\n" + list);
            list.SortByMean();
            Console.WriteLine("Отсортирована по значениям экзаменов\n" + list);
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Максимальное значение среднего баллов\n" 
                + list.MaxMean);
            Console.WriteLine("Все студенты с обучением Specialist\n" 
                + String.Join(' ', list.Specialists));
            Console.WriteLine("Все студенты с баллом 50\n" + 
                String.Join(' ', list.AverageMarkGroup(50)));
            Console.WriteLine("Все группы элементов\n" +
                String.Join(' ', list.AllAverageMarkGroups()));
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine("--------------------------------------------");
            TestsCollection tests = new(101);
            for (int i = 0; i < 151; i += 50)
            {
                string stringI = "S" + i.ToString();
                // Создание объекта Person
                Person person = new(
                    stringI,
                    i + " " + i,
                    new DateTime(i % 10000 + 1, i % 12 + 1, i % 28 + 1)
                    );
                tests.MeasureSearchTimes(person, stringI);
            }
            Console.WriteLine("--------------------------------------------");

        }
    }
}