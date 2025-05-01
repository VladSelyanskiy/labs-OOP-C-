namespace lab5
{
	class StudentCollection
	{
		private List<Student> students = [];

		public string Title { get; set; }

		public event StudentListHandler StudentsCountChanged;
		public event StudentListHandler StudentReferenceChanged;

		public bool Remove(int j)
		{
			if (j >= 0 && j < students.Count)
			{
				StudentListHandlerEventArgs args = new
					(this.Title,
					"del",
					students[j]);

				students.RemoveAt(j);

				StudentsCountChanged?.Invoke(this, args);

				return true;
			}
			else
			{
				return false;
			}
		}

		public Student this[int index]
		{
			get => students[index];
			set
			{
				students[index] = value;

				StudentListHandlerEventArgs args = new
					(this.Title,
					"changed",
					value);

				StudentReferenceChanged?.Invoke(this, args);
			}


		}

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

            StudentListHandlerEventArgs args = new
                    (this.Title,
                    "add",
                    student);

            StudentsCountChanged?.Invoke(this, args);
        }

        public void AddStudents(params Student[] newstudents)
		{
			foreach (Student student in newstudents)
			{
                StudentListHandlerEventArgs args = new
                    (this.Title,
                    "add",
                    student);

                students.Add(student);

                StudentsCountChanged?.Invoke(this, args);
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

	delegate void StudentListHandler
		(object source, StudentListHandlerEventArgs args);

    class StudentListHandlerEventArgs: EventArgs
	{
		public string TitleOfCollection { get; set; }
        public string TypeOfChanges { get; set; }

		public Student ChangedStudent { get; set; }

		public StudentListHandlerEventArgs()
		{
			TitleOfCollection = "TitleOfCollection";
            TypeOfChanges = "TypeOfChanges";
			ChangedStudent = new Student();
        }

        public StudentListHandlerEventArgs
			(string title, string type, Student student)
        {
            TitleOfCollection = title;
            TypeOfChanges = type;
            ChangedStudent = student;
        }

        public override string ToString()
        {
			string str;
			str = $"TitleOfCollection: {TitleOfCollection}" +
				$"TypeOfChanges: {TypeOfChanges}" + 
				$"ChangedStudent: {ChangedStudent}";
			return str;
        }
    }
}
