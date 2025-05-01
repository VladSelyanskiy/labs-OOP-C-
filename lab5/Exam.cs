namespace lab5
{
    public class Exam : IDateAndCopy
    {

        public string Title { get; set; } 

        public DateTime Date { get; set; } 

        public int Score { get; set; }

        public Exam(string title, DateTime date, int score)
        {
            Title = title;
            Date = date;
            Score = score;
        }
        public Exam()
        {
            Title = "title";
            Date = new DateTime();
            Score = 0;
        }

        public override string ToString()
        {
            return $"Title: {Title}, Date: {Date}, Score: {Score}";
        }
        
        public object DeepCopy()
        {
            return new Exam(Title, Date, Score);
        }

    }
}
