using System;

class Person
{
    private string name;
    private DateTime birthYear;

    // Властивості для доступу до полів
    public string Name
    {
        get { return name; }
    }

    public DateTime BirthYear
    {
        get { return birthYear; }
    }

    // Дефолтний конструктор
    public Person()
    {
        name = "Unknown";
        birthYear = DateTime.Now;
    }

    // Конструктор з параметрами
    public Person(string name, DateTime birthYear)
    {
        this.name = name;
        this.birthYear = birthYear;
    }

    // Метод для обчислення віку
    public int Age()
    {
        return DateTime.Now.Year - birthYear.Year;
    }

    // Метод для введення даних про особу
    public void Input()
    {
        Console.Write("Введіть ім'я: ");
        name = Console.ReadLine();
        Console.Write("Введіть рік народження (yyyy): ");
        birthYear = new DateTime(int.Parse(Console.ReadLine()), 1, 1);
    }

    // Метод для зміни ім'я
    public void ChangeName(string newName)
    {
        name = newName;
    }

    // Метод ToString
    public override string ToString()
    {
        return $"Ім'я: {name}, Рік народження: {birthYear.Year}, Вік: {Age()}";
    }

    // Метод для виведення інформації про особу
    public void Output()
    {
        Console.WriteLine(ToString());
    }

    // Оператор порівняння
    public static bool operator ==(Person p1, Person p2)
    {
        return p1.name.Equals(p2.name, StringComparison.OrdinalIgnoreCase);
    }

    public static bool operator !=(Person p1, Person p2)
    {
        return !(p1 == p2);
    }

    public override bool Equals(object obj)
    {
        if (obj is Person person)
        {
            return this == person;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return name.GetHashCode();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Person[] persons = new Person[6];

        // Введення інформації про 6 осіб
        for (int i = 0; i < persons.Length; i++)
        {
            persons[i] = new Person();
            persons[i].Input();
        }

        // Обчислення та виведення імені та віку кожної особи
        Console.WriteLine("\nІмена та віки осіб:");
        foreach (var person in persons)
        {
            Console.WriteLine($"{person.Name} - {person.Age()} років");
        }

        // Зміна імені на "Very Young" для осіб, віком менше 16 років
        foreach (var person in persons)
        {
            if (person.Age() < 16)
            {
                person.ChangeName("Very Young");
            }
        }

        // Виведення інформації про всіх осіб
        Console.WriteLine("\nІнформація про всіх осіб:");
        foreach (var person in persons)
        {
            person.Output();
        }

        // Знаходження осіб з однаковими іменами
        Console.WriteLine("\nОсоби з однаковими іменами:");
        for (int i = 0; i < persons.Length; i++)
        {
            for (int j = i + 1; j < persons.Length; j++)
            {
                if (persons[i] == persons[j])
                {
                    Console.WriteLine($"Знайдено однакові імена: {persons[i].Name}");
                    persons[i].Output();
                    persons[j].Output();
                }
            }
        }
    }
}