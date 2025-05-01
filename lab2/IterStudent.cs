using System;
using System.Collections;
using System.Linq;

namespace lab2
{
    class IterStudent : Person, IDateAndCopy, IEnumerable<object>
    {
        private Education education;
        private int group;
        private ArrayList tests;
        private ArrayList exams;

        public IterStudent() : base()
        {
            education = new Education();
            group = 0;
            tests = [];
            exams = [];
        }

        public IterStudent(Education neweducation,
            int newgroup,
            ArrayList newtests,
            ArrayList newexams,
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

        public ArrayList Tests
        { get { return tests; } set { tests = value; } }

        public ArrayList Exams
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
                return all_scores / exams.Count;
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
            ArrayList CloneExams = [];
            foreach (Exam exam in exams)
            {
                Exam newExam = new(exam.Title, exam.Date, exam.Score);
                CloneExams.Add(newExam);
            }

            ArrayList CloneTests = [];
            foreach (Test test in tests)
            {
                Test newTest = new(test.Title, test.IsPassed);
                CloneTests.Add(newTest);
            }

            return new IterStudent(education,
                group,
                CloneTests,
                CloneExams,
                new Person(firstName, lastName, date)
                );
        }

        public ArrayList GetEnumeratorAll()
        {
            ArrayList common = new(exams);
            common.AddRange(tests);
            return common;
        }

        public ArrayList GetEnumeratorExams(int aboveRate = -1)
        {
            ArrayList certainExams = [];
            foreach (Exam exam in exams)
            {
                if (exam.Score > aboveRate)
                {
                    certainExams.Add(exam);
                }
            }
            return certainExams;
        }

        
        // Реализация метода GetEnumerator для IEnumerable
        public IEnumerator<object> GetEnumerator()
        {
            return new NumberEnumerator(this);
        }

        // Реализация метода GetEnumerator для IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // Вложенный класс для реализации IEnumerator
        public class NumberEnumerator : IEnumerator<object>
        {
            private IterStudent _collection;
            private int _currentIndex = -1;
            private int _threshold; // Параметр фильтрации

            public NumberEnumerator(IterStudent collection, int threshold = -1)
            {
                _collection = collection;
                _threshold = threshold;
            }

            public object Current => _collection.exams[_currentIndex];

            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                while (++_currentIndex < _collection.exams.Count)
                {
                    // Проверяем, превышает ли текущий элемент порог
                    Exam ex = (Exam)_collection.exams[_currentIndex];
                    if (ex.Score > _threshold)
                    {
                        return true;
                    }
                }
                return false;
            }

            public void Reset()
            {
                _currentIndex = -1;
            }

            public void Dispose()
            {
                // Освобождение ресурсов, если это необходимо
            }
        }


    }
}
