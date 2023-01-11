// See https://aka.ms/new-console-template for more information
using System;
using IncomeExercise.Entities.Enums;
using IncomeExercise.Entities;
using System.Globalization;

namespace Course
{
    class Program {

        static void Main(string[] args)
        {
            Console.WriteLine("Enter deparment's name: ");
            string deptName = Console.ReadLine();
            Console.WriteLine("Enter worker data: ");
  
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine() );
            Console.WriteLine("Base Salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Department dept = new Department(deptName);
            Worker worker = new Worker(name, level, baseSalary, dept);
            Console.WriteLine("How many contracts for this worker? ");
            int contractsQuantities = int.Parse(Console.ReadLine());
            for (int i = 0;i< contractsQuantities; i += 1)
            {
                Console.WriteLine("Enter contract data for #" + i + ":");
                Console.Write("Date DD-MM-YYYY : ");
                DateTime date = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy", CultureInfo.InvariantCulture);               
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration(Hours): ");
                int hours = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date, valuePerHour, hours);
                foreach(HourContract obj in  worker.Contracts)
                {
                    Console.WriteLine(obj.TotalValue());

                }

                worker.AddContract(contract);
            }
         
            Console.WriteLine("Enter thg  e month and year to calculate the income(MM/YYYY");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));
            double income = worker.Income(year, month);
            Console.WriteLine("Income: " + income );


        }
    }
}
    


