namespace lab1
{
    class Program
    {
        static void Main()
        {
            // create Person
            string name1 = "Brok";
            string lastname1 = "Black";
            DateTime date = new(2000, 12, 12);
            Person person1 = new(name1, lastname1, date);

            // create Student
            Student student = new Student(person1, 
                Education.SecondEducation, 
                [new Exam("Math", new DateTime(2010, 10, 10), 89), new Exam()],
                42);

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Данные студента");
            Console.WriteLine(student);

            // add Exam to Student
            student.AddExams(new Exam("Rus", new DateTime(2010, 10, 10), 89));

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Данные студента с добавленными экзаменами");
            Console.WriteLine(student);

            // indexes in Education
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Значения индексатора и индексы");
            foreach (Education ed in Enum.GetValues<Education>())
            {
                Console.WriteLine($"{ed} - {(int)ed}");
            }

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Время обработки массивов");
            Console.WriteLine("Необходимо ввести количество строк и столбцов" +
                " в отдельных строках");

            int nrows = int.Parse(Console.ReadLine());
            int ncolumns = int.Parse(Console.ReadLine());
            int n = nrows * ncolumns;

            Exam[] array = new Exam[nrows * ncolumns];
            Exam[,] rectArray = new Exam[nrows, ncolumns];

            Exam[][] jaggedArray = [new Exam[nrows], 
                new Exam[ncolumns], 
                new Exam[n - nrows - ncolumns]];

            int a = Environment.TickCount;
            for (int i = 0; i < n; i++)
            {
                array[i] = new Exam();
            }
            Console.WriteLine($"array: {Environment.TickCount - a}");

            int b = Environment.TickCount;
            for (int i = 0; i < nrows; i++)
            {
                for (int j = 0; j < ncolumns; j++)
                {
                    rectArray[i, j] = new Exam();
                }
            }
            Console.WriteLine($"rectArray: {Environment.TickCount - b}");

            int c = Environment.TickCount;
            for (int i = 0; i < nrows; i++)
            {
                jaggedArray[0][i] = new Exam();
            }
            for (int i = 0; i < ncolumns; i++)
            {
                jaggedArray[1][i] = new Exam();
            }
            for (int i = 0; i < n - nrows - ncolumns; i++)
            {
                jaggedArray[2][i] = new Exam();
            }
            Console.WriteLine($"jaggedArray: {Environment.TickCount - c}");

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Размеры массивов");
            Console.WriteLine($"array: {array.Length}");
            Console.WriteLine($"rectArray: {rectArray.Length}");
            Console.WriteLine($"jaggedArray: {jaggedArray.Length}: " +
                $"{jaggedArray[0].Length}" +
                $" + {jaggedArray[1].Length}" +
                $" + {jaggedArray[2].Length}");


            Console.WriteLine(student.StdGroup);
            student.StdGroup = 2;
            Console.WriteLine(student.StdGroup);
            Console.WriteLine(student);
        }
    }
}
