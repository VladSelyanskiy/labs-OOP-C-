public class Person
{
    // Закрытые поля класса Person
    private readonly string FirstName;
    private readonly string LastName;
    private DateTime Date;

    // Конструктор класс с параметрами
    public Person(string FirstName, string LastName, DateTime Date)
    {
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.Date = Date;
    }

    // Конструктор класса без параметров
    public Person()
    {
        FirstName = "Unknown firstname";
        LastName = "Unknown lastname";
        Date = DateTime.MinValue;
    }

    // Свойства для доступа к полям
    public string StdFirstName { get; }

    public string StdLastName
    {
        get
        {
            return this.LastName;
        }
    }

    public string StdDate { get; set; }

    // Свойство для доступа  изменения даты
    public int IntStdDate
    {
        get
        {
            return Convert.ToInt32(Date);
        }
        set
        {
            Date = Convert.ToDateTime(value);
        }
    }

    // Перезапись метода ToString для вывода информации
    public override string ToString()
    {
        return $"Имя-{FirstName}, Фамилия-{LastName}, Год рождения-{Date}";
    }

    // Метод для выводы имени и фамилии
    public string ToShortString()
    {
        return FirstName + LastName;
    }

}