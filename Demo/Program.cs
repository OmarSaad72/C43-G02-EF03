using Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //FT_Employee emp01 = new FT_Employee()
            //{
            //    Name = "Omar",
            //    Age = 21,
            //    Salary = 900,
            //    StartDate = DateTime.Now
            //};

            //PT_Employee emp02 = new PT_Employee()
            //{
            //    Name = "Ali",
            //    Age = 22,
            //    CountOfHour = 50,
            //    HourRate = 300,
            //};

            using CompanyInhiretanceDBContext dBContext = new CompanyInhiretanceDBContext();
            //dBContext.FullTimeEmployee.Add(emp01);  //TPCC
            //dBContext.PartTimeEmployee.Add(emp02);  //TPCC
            //dBContext.Employees.Add(emp01);  //TPH
            //dBContext.Employees.Add(emp02);  //TPH
            //Console.WriteLine(dBContext.PartTimeEmployee.Entry(emp02).State);
            //Console.WriteLine(dBContext.FullTimeEmployee.Entry(emp01).State);
            //dBContext.SaveChanges();
            //var fT_Employee = (from FTE in dBContext.FullTimeEmployee
            //                   where FTE.Id == 1
            //                   select FTE).FirstOrDefault();
            //if (fT_Employee != null)
            //{
            //    fT_Employee.Name = "Omar";
            //    fT_Employee.Salary = 25000;
            //}
            //dBContext.SaveChanges();
            //Console.WriteLine(dBContext.Entry(fT_Employee).State);
            //foreach (var item in fT_Employee)
            //{
            //    Console.WriteLine(item.Salary);
            //}
            var employee = from e in dBContext.Employees
                           select e;
            foreach (var item in employee.OfType<PT_Employee>())
            {
                Console.WriteLine(item.CountOfHour);
            }
            
            foreach (var item in employee.OfType<FT_Employee>())
            {
                Console.WriteLine(item.Salary);
            }
        }
    }
}
