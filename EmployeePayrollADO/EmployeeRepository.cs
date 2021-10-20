using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayrollADO
{
    class EmployeeRepository
    {
        //Database path
        public static string connectionString = @"Data Source=(LocalDb)\localdb; Initial Catalog=payroll_service2;Integrated Security=true";
        //passing databse path to sqlconnection to make connection 
        SqlConnection sqlconnection = new SqlConnection(connectionString);
    }
}
