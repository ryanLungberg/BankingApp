using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.BankLogic
{
    /// <summary>
    /// Represents a bank customer
    /// </summary>
    public class Customer
    { 
        /// <summary>
        /// Represents a bank customers Unique ID
        /// </summary>
        public int CustomerID { get; set; }

        /// <summary>
        /// A Customer's first and last name
        /// </summary>
        public string CustomerName { get; set; }

    }
    
    namespace BankDB
    {
        public static class BankDBHelper
        {
            public static SqlConnection GetConnection()
            {
                return new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=Bank;Integrated Security=True");
            }
        }

        /// <summary>
        /// Contains database functionality for the Customer class
        /// </summary>
        public static class CustomerDB
        {
            public static List<Customer> GetCustomers()
            {
                using (SqlConnection dbConn = BankDBHelper.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = dbConn;
                    cmd.CommandText = "SELECT CustomerID, Name FROM Customer";

                    dbConn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    List<Customer> customerList = new List<Customer>();
                    while(rdr.Read())
                    {
                        Customer c = new Customer();
                        c.CustomerID = (int)rdr["CustomerID"];
                        c.CustomerName = (string)rdr["Name"];
                        customerList.Add(c);
                    }
                    return customerList;
                }
            }
        }
    }
}
