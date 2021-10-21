using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayrollADO
{
    public class EmployeeRepository
    {
        //Database path
        public static string connectionString = @"Data Source=(LocalDb)\localdb; Initial Catalog=payroll_service2;Integrated Security=true";
        //passing databse path to sqlconnection to make connection 
        SqlConnection sqlconnection = new SqlConnection(connectionString);
        EmployeeModal modal = new EmployeeModal();
        //uc-2 retrieve all data 
        public void GetAllEmployees()
        {

            String query = @"select *from Employee_Payroll2";
            //command object to executing query against database
            SqlCommand command = new SqlCommand(query, sqlconnection);
            //its open the sqlconnection to execute query 
            sqlconnection.Open();
            //Execute reader returning data of databse table
            SqlDataReader reader = command.ExecuteReader();
            //checking if data is available
            try
            {
                if (reader.HasRows)
                {
                    //read() fetch data present in each row of table
                    while (reader.Read())
                    {
                        modal.ID = reader.GetInt32(0);
                        modal.Name = reader["Name"].ToString();
                        modal.BasicPay = float.Parse(reader["BasicPay"].ToString());
                        modal.StartDate = (DateTime)(reader["StartDate"] == DBNull.Value ? default(DateTime) : reader["StartDate"]);
                        modal.Gender = reader["Gender"].ToString();
                        modal.Phone = Convert.ToInt64(reader["Phone"] == DBNull.Value ? default : reader["Phone"]);
                        modal.Address = reader["Address"].ToString();
                        modal.Department = reader["Department"].ToString();
                        modal.TaxablePay = float.Parse(reader["TaxablePay"].ToString());
                        modal.Deduction = float.Parse(reader["Deduction"].ToString());
                        modal.IncomeTax = float.Parse(reader["IncomeTax"].ToString());
                        modal.NetPay = float.Parse(reader["NetPay"].ToString());

                        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11}",
                            modal.ID, modal.Name, modal.BasicPay, modal.StartDate, modal.Gender, modal.Phone,
                            modal.Address, modal.Department, modal.TaxablePay, modal.Deduction,
                            modal.IncomeTax, modal.NetPay);
                        Console.WriteLine("\n");
                    }
                }
                else
                {
                    Console.WriteLine("no data found");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //close the connection for smooth query execution
            finally
            {
                this.sqlconnection.Close();
            }

        }
        //uc2 update salary
        public void UpdateSalary()
        {
            try
            {
                String query = @"update Employee_Payroll2 set BasicPay=300000 where Name='Rohit'";
                //command object to executing query against database
                SqlCommand command = new SqlCommand(query, sqlconnection);
                //its open the sqlconnection to execute query 
                sqlconnection.Open();
                int result = command.ExecuteNonQuery();
                if (result != 0)
                {
                    Console.WriteLine("Salary is Updated Successfully ");
                }
                else
                {
                    Console.WriteLine("updation failed");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlconnection.Close();

            }
        }

    }
}
