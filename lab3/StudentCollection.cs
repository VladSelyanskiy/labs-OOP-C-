using System;

namespace lab3
{
	class StudentCollection
	{
		private List<Student> students = [];

		public List<Student> Students
		{  
			get 
			{ 
				return students; 
			}
			set 
			{  
				students = value; 
			}
		}

		public void AddDefaults(Student student)
		{
			students = [student];
		}

        public void AddStudents(params Student[] newstudents)
		{
			foreach (Student student in newstudents)
			{
				students.Add(student);
			}
		}

        public override string ToString()
        {
			string str = "";
			foreach (Student student in students)
			{
				str += student.ToString();
				str += "\n\n";
			}
			return str;
        }

		public string ToShortString()
		{
			string str = "";
			foreach (Student student in students)
			{
				str += student.ToShortString();
				str += "Number of exams " + student.Exams.Count;
				str += "Number of tests " + student.Tests.Count;
				str += "\n\n";
			}
			return str;
		}

		public void SortByLastName()
		{
			students.Sort();
		}

		public void SortByDate()
		{
			students.Sort(new PersonsComparerAge());
		}

		public void SortByMean()
		{
			students.Sort(new StudentComparerMean());
		}

		public double MaxMean
		{
			get
			{
				if (students.Count == 0)
				{
					return -1;
				}
				else
					return students.Max(new StudentComparerMean())!.Mean;
			}
		}

        public IEnumerable<Student> Specialists
		{
			get
			{
				return students.Where(x => x.Educat == Education.Specialist);
			}
		}

        public List<Student> AverageMarkGroup(double value)
		{
			List<Student> list = new();
			foreach (var group in students.GroupBy(x => x.Mean))
			{
				if (group.Key == value)
				{
					foreach (var st in group)
					{
						list.Add(st);
					}
				}
			}
			return list;
		}

        public List<double> AllAverageMarkGroups()
        {
            List<double> groups = new();
			foreach (var group in students.GroupBy(x => x.Mean))
			{
				groups.Add(group.Key);
			}
			return groups;
        }
    }
}
