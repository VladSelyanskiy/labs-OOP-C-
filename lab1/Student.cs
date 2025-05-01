namespace lab1
{
    class Student
    {
        private readonly Person person;
        private readonly Education education;
        private readonly List<Exam> exams;
        private int group;

        public Student()
        {
            person = new();
            education = new();
            exams = [];
            group = 0;
        }
        public Student(Person newperson, Education neweducation, List<Exam> newexams, int newgroup)
        {
            person = newperson;
            education = neweducation;
            exams = newexams;
            group = newgroup;
        }

        public Person StdPerson { get; set; }
        public Education StdEducation { get; set; }
        public Exam[] StdExam { get; set; }
        public int StdGroup
        {
            get
            {
                return group;
            }
            set
            {
                group = value;
            }
        }

        public double Mean
        {
            get
            {
                int all_scores = 0;
                int count_scores = 0;
                foreach (var exams in exams)
                {
                    all_scores += exams.Score;
                    count_scores++;
                }
                return all_scores / count_scores;
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
            foreach (var exam in extra_exams)
            {
                exams.Add(exam);
            }
        }

        public override string ToString()
        {
            string str = $"person: {person}\n" +
                $"education: {education}\n" +
                $"group: {group}\n" +
                $"exams:";
            foreach (var exam in exams)
            {
                str += " ";
                str += exam.ToString();
            }
            return str;
        }

        public string ToShortString()
        {
            return $"{person} {education}, {group}, {Mean}";
        }
    }
}
