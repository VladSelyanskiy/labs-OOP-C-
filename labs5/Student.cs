using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;

namespace lab3
{
    [Serializable]
    class Student : Person, IDateAndCopy
    {
        private Education education;
        private int group;
        private List<Test> tests;
        private List<Exam> exams;

        public Student() : base()
        {
            education = new Education();
            group = 0;
            tests = [];
            exams = [];
        }

        public Student(Education neweducation,
            int newgroup,
            List<Test> newtests,
            List<Exam> newexams,
            Person newperson)
        {
            education = neweducation;
            group = newgroup;
            tests = newtests;
            exams = newexams;
            firstName = newperson.FirstName;
            lastName = newperson.LastName;
            date = newperson.Date;
        }

        public Education Educat
        { get { return education; } set { education = value; } }

        public int Group
        {
            get
            {
                return group;
            }
            set
            {
                int input = value;
                if (input <= 100 || input > 599)
                {
                    throw new ArgumentException("Номер группы должен быть" +
                        " в диапозоне от 100 до 600");
                }
                else
                {
                    group = input;
                }
            }
        }

        public List<Test> Tests
        { get { return tests; } set { tests = value; } }

        public List<Exam> Exams
        { get { return exams; } set { exams = value; } }

        public Person PersonData
        {
            get
            {
                return new Person(firstName, lastName, date);
            }
            set
            {
                firstName = value.FirstName;
                lastName = value.LastName;
                date = value.Date;
            }
        }

        public double Mean
        {
            get
            {
                int all_scores = 0;
                foreach (Exam exams in exams)
                {
                    all_scores += exams.Score;
                }
                if (exams.Count > 0)
                {
                    return all_scores / exams.Count;
                }
                return 0;
            }
        }

        public bool this[int index]
        {
            get
            {
                if ((int)education == index) { return true; }
                else { return false; }
            }
        }

        public void AddExams(params Exam[] extra_exams)
        {
            foreach (Exam exam in extra_exams)
            {
                Exam newExam = new(exam.Title, exam.Date, exam.Score);
                exams.Add(newExam);
            }
        }

        public override string ToString()
        {
            string str = $"education: {education}\n" +
                $"group: {group}\n" +
                $"firstname: {firstName}\n" +
                $"lastname: {lastName}\n" +
                $"date: {date}\n";

            str += "exams:";
            foreach (Exam exam in exams)
            {
                str += " ";
                str += "(";
                str += exam.ToString();
                str += ")";
            }

            str += "\ntests:";
            foreach (Test test in tests)
            {
                str += " ";
                str += "(";
                str += test.ToString();
                str += ")";
            }

            return str;
        }

        public new string ToShortString()
        {
            return $"firstname: {firstName}, " +
                $"lastname: {lastName}, " +
                $"date: {date}, " +
                $"education: {education}, " +
                $"group: {group}, " +
                $"mean: {Mean}";
        }

        public override object DeepCopy()
        {
            List<Exam> CloneExams = [];
            foreach (Exam exam in exams)
            {
                Exam newExam = new(exam.Title, exam.Date, exam.Score);
                CloneExams.Add(newExam);
            }

            List<Test> CloneTests = [];
            foreach (Test test in tests)
            {
                Test newTest = new(test.Title, test.IsPassed);
                CloneTests.Add(newTest);
            }

            return new Student(education,
                group,
                CloneTests,
                CloneExams,
                new Person(firstName, lastName, date)
                );
        }

        public IEnumerable GetEnumeratorAll()
        {
            foreach (object exam in exams)
            {
                yield return exam;
            }
            foreach (object test in tests)
            {
                yield return test;
            }
        }

        public IEnumerable GetEnumeratorExams(int threshold = -1)
        {
            foreach (object exam in exams)
            {
                if (((Exam)exam).Score > threshold)
                {
                    yield return exam;
                }
            }
        }

        public Student? SerializedDeepCopy()
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Запись в поток
                JsonSerializer.Serialize(memoryStream, this);
               
                // Установка позиции потока для чтения
                memoryStream.Position = 0;

                // Чтение с потока
                Student? copiedStudent = JsonSerializer.Deserialize<Student>(memoryStream);
                return copiedStudent;
            }
        }

        // Метод для сериализации текущего объекта в файл
        public bool Save(string filename)
        {
            try
            {
                // Сериализация текущего объекта в JSON
                string jsonString = JsonSerializer.Serialize(this);

                // Запись JSON в файл
                File.WriteAllText(filename, jsonString);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Метод для десериализации объекта из файла
        public bool Load(string filename)
        {
            try
            {
                // Чтение JSON из файла
                string jsonString = File.ReadAllText(filename);

                // Десериализация JSON в объект Person
                Student desStudent = JsonSerializer.Deserialize<Student>(jsonString);

                education = desStudent.Educat;
                group = desStudent.Group;
                tests = desStudent.Tests;
                exams = desStudent.Exams;
                firstName = desStudent.FirstName;
                lastName = desStudent.LastName;
                date = desStudent.Date;

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static bool Save(string filename, Student obj)
        {
            try
            {
                // Сериализация текущего объекта в JSON
                string jsonString = JsonSerializer.Serialize(obj);

                // Запись JSON в файл
                File.WriteAllText(filename, jsonString);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool Load(string filename, Student obj)
        {
            try
            {
                // Чтение JSON из файла
                string jsonString = File.ReadAllText(filename);

                // Десериализация JSON в объект Person
                Student desStudent = JsonSerializer.Deserialize<Student>(jsonString);

                obj.Educat = desStudent.Educat;
                obj.Group = desStudent.Group;
                obj.Tests = desStudent.Tests;
                obj.Exams = desStudent.Exams;

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AddFromConsole()
        {
            Console.WriteLine("Введите экзамен " +
                "который хотите добавить в следующем формате:\n" +
                "Название предмета" +
                "*Оценка в виде числа от 0 до 100" +
                "*Дата экзамена в виде dd/mm/yy");

            string stringData = Console.ReadLine()!;

            try
            {
                string[] arrayData = stringData.Split('*');
                Exam addedExam = new()
                {
                    Title = arrayData[0],
                    Score = int.Parse(arrayData[1]),
                    Date = DateTime.Parse(arrayData[2])
                };

                this.AddExams(addedExam);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }

    class StudentComparerMean : IComparer<Student>
    {
        public int Compare(Student? s1, Student? s2)
        {
            if (s1 is null || s2 is null)
                throw new ArgumentException("Некорректное значение параметра");

            if (s1.Mean > s2.Mean) { return 1; }
            if (s1.Mean < s2.Mean) { return -1; }
            return 0;
        }
    }
}
