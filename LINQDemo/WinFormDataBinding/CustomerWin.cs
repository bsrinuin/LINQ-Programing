using LINQ.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormDataBinding
{
    public partial class CustomerWin : Form
    {
        CustomerRepository customerrepository = new CustomerRepository();

        public CustomerWin()
        {
                InitializeComponent();
        }

     
        private void getcustomers_Click(object sender, EventArgs e)
        {
           // customergrid.DataSource = customerrepository.Retrieve();

            var customerlist = customerrepository.Retrieve();

            //1 Get all the customer list 
            // customergrid.DataSource = customerrepository.SortByName(customerlist).ToList();

            //2 Get overdue customer list 
            //            customergrid.DataSource = customerrepository.GetOverDueCustomers_SM(customerlist).ToList();

            //3 Get overdue customers with sort 
            //var unpaidcustomer = customerrepository.GetOverDueCustomers_SM(customerlist);
            //customergrid.DataSource = customerrepository.SortByName(unpaidcustomer).ToList();

            //4 customer
            CustomerTypeRepository customerTypeRepository = new CustomerTypeRepository();
            var customerTypeList = customerTypeRepository.Retrieve();
            customergrid.DataSource = customerrepository.GetNameAndType(customerlist, customerTypeList);

        }

        private void CustomerWin_Load_1(object sender, EventArgs e)
        {
            var customerlist = customerrepository.Retrieve();

            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "CustomerId";
            comboBox1.DataSource = customerrepository.GetNameAndId(customerlist);

        }


        //when combo box selected a value, grid should reflect the same customer value..
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedValue!=null)
            {
                int customerid;

                if(int.TryParse(comboBox1.SelectedValue.ToString(), out customerid))
                {
                    var customerlist = customerrepository.Retrieve();

                    customergrid.DataSource = new List<Customer>()
                        { customerrepository.Find(customerlist, customerid) };
                }
            }
        }





        //private void button1_Click(object sender, EventArgs e)
        //{
        //    CustomerGridView.DataSource = customerrepository.Retrieve();
        //}


    }
}
