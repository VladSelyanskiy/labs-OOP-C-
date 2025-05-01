namespace lab1
{
    public class Exam
    {
        // Автоматическое свойство для названия экзамена
        public string Title { get; set; } 
        // Автоматическое свойство для даты экзамена
        public DateTime Date { get; set; } 

        // Автоматическое свойство для оценки
        public int Score { get; set; }

        // 
        public Exam(string title, DateTime date, int score)
        {
            Title = title;
            Date = date;
            Score = score;
        }

        // 
        public Exam()
        {
            Title = "title";
            Date = new DateTime();
            Score = 0;
        }

        public override string ToString()
        {
            return $"Title:{Title}, Date:{Date}, Score:{Score}";
        }


    }
}
