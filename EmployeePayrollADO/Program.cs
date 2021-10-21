using System;

namespace EmployeePayrollADO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome Employee payroll database connection");
            EmployeeRepository repo = new EmployeeRepository();
            //repo.GetAllEmployees();
            repo.UpdateSalary();
        }
    }
}
