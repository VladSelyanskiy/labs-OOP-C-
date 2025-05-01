namespace lab5
{
    class Test
    {
        private string title;
        private bool isPassed;

        public string Title
            { get { return title; } set { title = value; } }

        public bool IsPassed
            { get { return isPassed; } set { isPassed = value; } }

        public Test(string newtitle, bool newisPassed)
        {
            title = newtitle;
            isPassed = newisPassed;
        }

        public Test()
        {
            title = "?Test?";
            isPassed = false;
        }

        public override string ToString()
        {
            return $"title: {title}, " +
                $"result: {(isPassed ? "passed" : "not passed")}";
        }
    }
}
