using System;
using System.Collections;
using System.Linq;

namespace lab2
{
    class Student : Person, IDateAndCopy
    {
        private Education education;
        private int group;
        private ArrayList tests;
        private ArrayList exams;

        public Student() : base()
        {
            education = new Education();
            group = 0;
            tests = [];
            exams = [];
        }

        public Student(Education neweducation, 
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

    }
}
