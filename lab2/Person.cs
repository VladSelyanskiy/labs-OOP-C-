using System;

namespace lab2
{
    public class Person : IDateAndCopy
    {
        // Закрытые поля класса Person
        protected string firstName;
        protected string lastName;
        protected DateTime date;

        // Конструктор класс с параметрами
        public Person(string firstName, string lastName, DateTime date)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.date = date;
        }

        // Конструктор класса без параметров
        public Person()
        {
            firstName = "Unknown firstname";
            lastName = "Unknown lastname";
            date = DateTime.MinValue;
        }

        // Свойства для доступа к полям
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
            }
        }

        public int IntDate
        {
            get
            {
                return Convert.ToInt32(date);
            }
            set
            {
                date = Convert.ToDateTime(value);
            }
        }

        // Перезапись метода ToString для вывода информации
        public override string ToString()
        {
            return $"Имя-{firstName}, Фамилия-{lastName}, Год рождения-{date}";
        }

        // Метод для выводы имени и фамилии
        public string ToShortString()
        {
            return firstName + lastName;
        }

        // Переопределяем метод Equals
        public override bool Equals(object? obj)
        {
            // Проверяем, является ли объект null
            if (obj == null)
            { 
                return false; 
            }

            // Приводим объект к типу Person
            Person other = (Person)obj;

            // Сравниваем свойства
            if (firstName == other.FirstName &&
                lastName == other.LastName &&
                date == other.Date
                )
            {
                return true;
            }

            return false;
        }

        // Переопределяем метод GetHashCode
        public override int GetHashCode()
        {
            int hash = firstName.GetHashCode() + 
                lastName.GetHashCode() + 
                date.GetHashCode();

            return hash;
        }

        // Переопределяем оператор ==
        public static bool operator ==(Person left, Person right)
        {

            // Проверяем, является ли один из объектов null
            if (left is null || right is null)
            {
                return false;
            }

            // Используем переопределенный метод Equals
            return left.Equals(right);
        }

        // Переопределяем оператор !=
        public static bool operator !=(Person left, Person right)
        {
            return !(left == right);
        }

        public virtual object DeepCopy()
        {
            return new Person(firstName, lastName, date);
        }
    }
}