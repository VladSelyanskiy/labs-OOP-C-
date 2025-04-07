using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class TestsCollection
    {
        public static List<Person> persons = [];
        public static List<string> ids = [];
        public static Dictionary<Person, Student> personsDictionary = [];
        public static Dictionary<string, Student> idsDictionary = [];

        public static Student GenerateStudent(int id)
        {
            // Генерация уникального идентификатора студента
            string studentId = "S" + id.ToString();

            // Создание объекта Person
            Person person = new(
                studentId,
                studentId + " " + studentId,
                new DateTime(id % 10000, id % 12, id % 28)
                );

            // Создание объекта Student
            Student student = new(
                Education.Specialist,
                id % 100 + 100,
                [],
                [],
                person);

            // Добавление в коллекции
            persons.Add(person);
            ids.Add(studentId);
            personsDictionary[person] = student;
            idsDictionary[studentId] = student;

            return student;
        }

        public TestsCollection(int numberOfElements)
        {
            persons = new List<Person>(numberOfElements);
            ids = new List<string>(numberOfElements);
            personsDictionary = new Dictionary<Person, Student>(numberOfElements);
            idsDictionary = new Dictionary<string, Student>(numberOfElements);

            for (int i = 0; i < numberOfElements; i++)
            {
                string stringI = "S" + i.ToString();
                // Создание объекта Person
                Person person = new(
                    stringI,
                    i + " " + i,
                    new DateTime(i % 10000 + 1, i % 12 + 1, i % 28 + 1)
                    );

                // Создание объекта Student
                Student student = new(
                    Education.Specialist,
                    i % 100 + 100,
                    [],
                    [],
                    person);

                // Добавление в коллекции
                persons.Add(person);
                ids.Add(stringI);
                personsDictionary[person] = student;
                idsDictionary[stringI] = student;
            }
        }

        public void MeasureSearchTimes(Person searchPerson, string searchId)
        {
            Stopwatch stopwatch = new();

            // Поиск в List<Person>
            stopwatch.Start();
            var personFound = persons.Find(p => p == searchPerson);
            stopwatch.Stop();
            Console.WriteLine($"Время поиска в List<Person>: " +
                $"{stopwatch.Elapsed.TotalMilliseconds} мс. " +
                $"Найден: {(personFound is null ? "no" : personFound.FirstName)}");

            // Поиск в List<string>
            stopwatch.Restart();
            var stringFound = ids.Find(s => s == searchId);
            stopwatch.Stop();
            Console.WriteLine($"Время поиска в List<string>: " +
                $"{stopwatch.Elapsed.TotalMilliseconds} мс. " +
                $"Найден: {(stringFound is null ? "no" : stringFound)}");

            // Поиск в Dictionary<Person, Student> по ключу
            stopwatch.Restart();
            var studentByPersonKey = personsDictionary.TryGetValue(searchPerson, out var studentByPerson) ? studentByPerson : null;
            stopwatch.Stop();
            Console.WriteLine($"Время поиска в Dictionary<Person, Student> по ключу: " +
                $"{stopwatch.Elapsed.TotalMilliseconds} мс. " +
                $"Найден: {(studentByPersonKey is null ? "no" : studentByPersonKey.FirstName)}");

            // Поиск в Dictionary<string, Student> по ключу
            stopwatch.Restart();
            var studentByStringKey = personsDictionary.TryGetValue(searchPerson, out var studentByString) ? studentByString : null; ;
            stopwatch.Stop();
            Console.WriteLine($"Время поиска в Dictionary<string, Student> по ключу: " +
                $"{stopwatch.Elapsed.TotalMilliseconds} мс. " +
                $"Найден: {(studentByStringKey is null ? "no" : studentByStringKey.FirstName)}");

            // Поиск в Dictionary<Person, Student> по значению
            stopwatch.Restart();
            var studentByValue = personsDictionary.Values.FirstOrDefault(s => s == searchPerson);
            stopwatch.Stop();
            Console.WriteLine($"Время поиска в Dictionary<Person, Student> по значению: " +
                $"{stopwatch.Elapsed.TotalMilliseconds} мс. " +
                $"Найден: {(studentByValue is null ? "no" : studentByValue.FirstName)}");

            // Поиск в Dictionary<string, Student> по значению
            stopwatch.Restart();
            var studentByValueString = idsDictionary.Values.FirstOrDefault(s => s.FirstName == searchId);
            stopwatch.Stop();
            Console.WriteLine($"Время поиска в Dictionary<string, Student> по значению: " +
                $"{stopwatch.Elapsed.TotalMilliseconds} мс. " +
                $"Найден: {(studentByValueString is null ? "no" : studentByValueString.FirstName)}");
        }
    }
}
