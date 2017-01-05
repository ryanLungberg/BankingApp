using MyBank.BankLogic;
using MyBank.BankLogic.BankDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankingApp
{
    public partial class frmBankWelcome : Form
    {
        public frmBankWelcome()
        {
            InitializeComponent();
        }

        private void frmBankWelcome_Load(object sender, EventArgs e)
        {
            GetAndDisplayAllCustomers();
        }

        /// <summary>
        /// Gets all the bank customers from the database
        /// Displays all customers in a listbox
        /// </summary>
        private void GetAndDisplayAllCustomers()
        {
            try
            {
                List<Customer> customers = CustomerDB.GetCustomers();

                lstboxCustomers.DataSource = customers;
                lstboxCustomers.DisplayMember = "CustomerName";
                lstboxCustomers.ValueMember = "CustomerID";
            }
            catch(SqlException sqle)
            {
                //log the error for tech support
                MessageBox.Show("There was a server issue. Please try again later.");
            }
        }

        private void lstboxCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstboxCustomers.SelectedIndex < 0)
            {
                return;
            }
            Customer c = (Customer)lstboxCustomers.SelectedItem;

            MessageBox.Show(c.CustomerID.ToString());
        }
    }
}
