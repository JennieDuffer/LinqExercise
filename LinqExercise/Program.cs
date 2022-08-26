using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            var sum = numbers.Sum();
            Console.WriteLine("Sum");
            Console.WriteLine(sum);

            //TODO: Print the Average of numbers
            var avg = numbers.Average();
            Console.WriteLine("---------------");
            Console.WriteLine("Average");
            Console.WriteLine(avg);

            //TODO: Order numbers in ascending order and print to the console
            var asc = numbers.OrderBy(x => x);
            Console.WriteLine("---------------");
            Console.WriteLine("Asc");
            foreach (var x in asc)
            {
                Console.WriteLine(x);
            }


            //TODO: Order numbers in decsending order adn print to the console
            var desc = numbers.OrderByDescending(x => x);
            Console.WriteLine("---------------");
            Console.WriteLine("Desc");
            foreach (var x in desc)
            {
                Console.WriteLine(x);
            }


            //TODO: Print to the console only the numbers greater than 6
            IEnumerable<int> greater = numbers.Where(x => x > 6);
            Console.WriteLine("-------------------");
            Console.WriteLine("Print numbers Greater than 6");
            foreach (var x in greater)
            {
                Console.WriteLine(x);
            }
            

            //TODO: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            var descending = numbers.OrderByDescending(x => x );
            Console.WriteLine("-------------------");
            Console.WriteLine("Print only four numbers in descending order:    ");
            foreach (var x in desc.Take(4))
            {
                Console.WriteLine(x); 
            }

            //TODO: Change the value at index 4 to your age, then print the numbers in decsending order
            numbers[4] = 30;
            Console.WriteLine("-------------------");
            Console.WriteLine("Replace with age and print descending");
            foreach (var x in numbers.OrderByDescending(x => x))
            {
                Console.WriteLine(x);
            }

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in acesnding order by FirstName.
            Console.WriteLine("-----------------");
            Console.WriteLine("Print the full name of those starting with a C or S: ");
            Console.WriteLine();
            employees.Where(x => x.FirstName[0] == 'C' || x.FirstName[0] == 'S').OrderBy(x => x.FirstName).ToList().ForEach(x => Console.WriteLine(x.FullName));



            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            Console.WriteLine("-----------------");
            Console.WriteLine("Print the full name and age over 26:  ");
            Console.WriteLine();
            employees.Where(x => x.Age >= 26).OrderBy(x => x.Age).ThenBy(x => x.FirstName[0]).ToList().ForEach(x => Console.WriteLine($" Age: {x.Age} Full Name: {x.FirstName}{x.LastName}"));

            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35
            Console.WriteLine("-----------------");
            Console.WriteLine("Print the Sum then average of the employees YOE if less or equal to 10 and is greater than 35:  ");
            Console.WriteLine();
            var years = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);
            Console.WriteLine($" Sum: {years.Sum( x => x.YearsOfExperience)} Average: {years.Average(x => x.YearsOfExperience)}");

            //TODO: Add an employee to the end of the list without using employees.Add()

            Console.WriteLine("-----------------");
            Console.WriteLine("Add employee to the end of the list:  ");
            Console.WriteLine();
            employees = employees.Append(new Employee("John", "Smith", 25, 3)).ToList();
            foreach (var emp in employees)
            {
                Console.WriteLine($" {emp.FirstName} {emp.LastName},{emp.Age},{emp.YearsOfExperience}");
            }

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
