using System;
using System.ComponentModel.DataAnnotations;
using static System.Console;



public class Human

{
    internal string firstName;
    internal string lastName;
    internal string ptrName;
    internal DateTime birthDate;

    public Human()
    {
        Write("Введите фамилию: ");
        lastName = ReadLine();
        Write("Введите имя: ");
        firstName = ReadLine();
        Write("Введите отчество: ");
        ptrName = ReadLine();
        Write("Введите дату рождения (гггг.мм.дд): ");
        birthDate = Convert.ToDateTime(ReadLine());
    }

    public Human(string lName, string fName)
    {
        firstName = fName;
        lastName = lName;
    }

    public Human(string lName, string fName, string pName)
    {
        firstName = fName;
        lastName = lName;
        ptrName = pName;
    }
    public Human(string lName, string fName, string pName, DateTime datetime)
    {
        firstName = fName;
        lastName = lName;
        ptrName = pName;
        birthDate = datetime;
    }

    public void OutputHumanInfo(bool onlyFIO)
    {
        if (onlyFIO == true)
        {
            WriteLine($"ФИО: {lastName} {firstName} {ptrName}");
        }
        else
        {
            WriteLine($"ФИО: {lastName} {firstName} {ptrName} \n Дата рождения: {birthDate} \n");
        }

    }
}

public class Employee : Human
{
    internal string _educated;
    internal double _salary;
    //int age = DateTime.Now.Year - birthDate.Year;

    public Employee()
    {
        this.lastName = lastName;
        this.firstName = firstName;
        this.ptrName = ptrName;
        this.birthDate = birthDate;
        Write("Введите образование: ");
        _educated = ReadLine();
        Write("Введите зарплату: ");
        _salary = Convert.ToDouble(ReadLine());
    }
    public Employee(string lName, string fName) : base(fName, lName)
    {

    }
    public Employee(string lName, string fName, string pName) : base(fName, lName, pName)
    {

    }
    public Employee(string lName, string fName, string pName, DateTime datetime) : base(fName, lName, pName, datetime)
    {

    }
    public Employee(string lName, string fName, string pName, DateTime datetime, double salary) : base(fName, lName, pName, datetime)
    {

        _salary = salary;
    }
    public Employee(string lName, string fName, string pName, DateTime datetime, string educat, double salary) : base(lName, fName, pName, datetime)
    {

        _salary = salary;
        _educated = educat;
    }

    public void OutputEmployeeInfo(bool onlyFIO)
    {
        if (onlyFIO == true)
        {
            WriteLine($"ФИО: {lastName} {firstName} {ptrName}");
        }
        else
        {
            WriteLine($"ФИО: {lastName} {firstName} {ptrName} \n Дата рождения: {birthDate}" +
                      $"\n Образование: {_educated} \n Зарплата: {_salary} \n");
        }

    }
}

public class Manager : Employee
{
    string departament;
    double salaryBonus;
    public Manager()
    {
        this.lastName = lastName;
        this.firstName = firstName;
        this.ptrName = ptrName;
        this.birthDate = birthDate;
        this._educated = _educated;
        this._salary = _salary;
        WriteLine("Введите название отдела: ");
        this.departament = ReadLine();
        WriteLine("Введите размер премии: ");
        this.salaryBonus = Convert.ToDouble(ReadLine());

    }

    public Manager(string depart, double bonus)
    {
        this.lastName = lastName;
        this.firstName = firstName;
        this.ptrName = ptrName;
        this.birthDate = birthDate;
        this._educated = _educated;
        this._salary = _salary;
        departament = depart;
        salaryBonus = bonus;

    }
    public Manager(string lName, string fName, string pName, DateTime datetime, string educat, double salary)
    {
        this.lastName = lastName;
        this.firstName = firstName;
        this.ptrName = ptrName;
        this.birthDate = birthDate;
        this._educated = _educated;
        this._salary = _salary;


    }
    public void OutputManagerInfo(bool onlyFIO)
    {
        if (onlyFIO == true)
        {
            WriteLine($"ФИО: {lastName} {firstName} {ptrName}");
        }
        else
        {
            WriteLine($"ФИО: {lastName} {firstName} {ptrName} \n Дата рождения: {birthDate}" +
                      $"\n Образование: {_educated} \n Зарплата: {_salary} \n Отдел: {departament} \n Премия: {salaryBonus} \n");
        }

    }
}

class Program
{
    static void Main()
    {

        List<Human> humanList = new List<Human>();
        List<Employee> employeeList = new List<Employee>();
        List<Manager> managerList = new List<Manager>();
        Employee employee1 = new Employee("Шобанов", "Константин", "Александрович", Convert.ToDateTime("2006.10.05"), "Общее среднее", 65000);
        Employee employee2 = new Employee("Иванов", "Пётр", "Алексеевич", Convert.ToDateTime("1970.01.01"));
        employeeList.Add(employee1);
        employeeList.Add(employee2);
        byte choise = 0;
        while (choise != 5)
        {
            Write($"\n\n1 - Добавить человека \n2 - Добавить сотрудника " +
                $"\n3 - Добавить менеджера \n4 - База данных \n5 - Завершить работу \n Выберете действие: ");
            choise = Convert.ToByte(ReadLine());
            switch (choise)
            {
                case 1:
                    WriteLine("\t Добавление человека ");
                    humanList.Add(new Human());
                    Write("Человек успешно добавлен: ");
                    humanList[humanList.Count - 1].OutputHumanInfo(true);
                    break;

                case 2:
                    WriteLine("\t Добавление сотрудника ");
                    employeeList.Add(new Employee());
                    Write("Сотрудник успешно добавлен: ");
                    employeeList[employeeList.Count - 1].OutputEmployeeInfo(true);
                    break;

                case 3:
                    WriteLine("\t Добавление менеджера ");
                    managerList.Add(new Manager());
                    Write("Менеджер успешно добавлен: ");
                    managerList[managerList.Count - 1].OutputEmployeeInfo(true);
                    break;

                case 4:
                    WriteLine("\n\tСписок людей:");
                    for (int i = 0; i < humanList.Count(); i++)
                    {
                        WriteLine($"  {i + 1} - ");
                        humanList[i].OutputHumanInfo(false);

                    }
                    WriteLine("\n\tСписок сотрудников:");
                    for (int i = 0; i < employeeList.Count(); i++)
                    {
                        Write($"  {i + 1} - ");
                        employeeList[i].OutputEmployeeInfo(false);

                    }
                    WriteLine("\n\tСписок менеджеров:");
                    for (int i = 0; i < managerList.Count(); i++)
                    {
                        Write($"  {i + 1} - ");
                        managerList[i].OutputManagerInfo(false);

                    }
                    break;
            }
        }

    }
}
