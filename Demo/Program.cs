using Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FT_Employee emp01 = new FT_Employee()
            {
                Age = 21,
                Name = "Omar",
                Salary = 900,
                StartDate = DateTime.Now
            };

            PT_Employee emp02 = new PT_Employee()
            {
                Age = 22,
                Name = "Ali",
                CountOfHour = 50,
                HourRate = 300,
            };

            using CompanyInhiretanceDBContext dBContext = new CompanyInhiretanceDBContext();
            //dBContext.FullTimeEmployee.Add(emp01);
            //dBContext.PartTimeEmployee.Add(emp02);
            //Console.WriteLine(dBContext.PartTimeEmployee.Entry(emp02).State);
            //Console.WriteLine(dBContext.FullTimeEmployee.Entry(emp01).State);
            //dBContext.SaveChanges();
            var fT_Employee = (from FTE in dBContext.FullTimeEmployee
                               where FTE.Id == 1
                               select FTE).FirstOrDefault();
            if (fT_Employee != null)
            {
                fT_Employee.Name = "Omar";
                fT_Employee.Salary = 25000;
            }
            dBContext.SaveChanges();
            Console.WriteLine(dBContext.Entry(fT_Employee).State);
            //foreach (var item in fT_Employee)
            //{
            //    Console.WriteLine(item.Salary);
            //}
        }
    }
}
