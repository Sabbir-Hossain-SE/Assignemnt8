using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyWindowsFormsApp.BLL;
using MyWindowsFormsApp.Model;


namespace MyWindowsFormsApp
{
    public partial class OrderUi : Form
    {
        OrderManager _orderManager = new OrderManager();
        public OrderUi()
        {
            InitializeComponent();
        }

        private void OrderUi_Load(object sender, EventArgs e)
        {
            itemComboBox.DataSource = _orderManager.ItemCombo();
            customerComboBox.DataSource = _orderManager.CustomerCombo();
            showDataGridView.DataSource = _orderManager.Display();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Order order = new Order();

            //Mandatory
            if (String.IsNullOrEmpty(quantityTextBox.Text))
            {
                MessageBox.Show("Quantity can not be Empty!!");
                return;
            }
            if (String.IsNullOrEmpty(customerComboBox.Text))
            {
                MessageBox.Show("Customer combobox can not be Empty!!");
                return;
            }
            if (String.IsNullOrEmpty(itemComboBox.Text))
            {
                MessageBox.Show("Item combobox can not be Empty!!");
                return;
            }
            order.TotalPrice = Convert.ToDouble(totalPriceTextBox.Text);
            order.CustomerId = Convert.ToInt32(customerComboBox.SelectedValue);
            order.ItemId = Convert.ToInt32(itemComboBox.SelectedValue);
            order.Quantity = Convert.ToInt32(quantityTextBox.Text);

            //Add/Insert
            if (_orderManager.Add(order))
            {
                MessageBox.Show("Saved");
            }
            else
            {
                MessageBox.Show("Not Saved");
            }

            //showDataGridView.DataSource = dataTable;
            showDataGridView.DataSource = _orderManager.Display();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void quantityTextBox_TextChanged(object sender, EventArgs e)
        {

            double totalPrice = 0;
            if (quantityTextBox.Text != null&& customerComboBox.Text!=null&&itemComboBox!=null)
            {
                totalPrice = _orderManager.TotalPrice(Convert.ToInt32(quantityTextBox.Text), itemComboBox.Text);
                
                totalPriceTextBox.Text = Convert.ToString(totalPrice);
            }
        }

        public void itemComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                double totalPrice = 0;
                if (quantityTextBox.Text != null && customerComboBox.Text != null && itemComboBox != null)
                {
                    totalPrice = _orderManager.TotalPrice(Convert.ToInt32(quantityTextBox.Text), itemComboBox.Text);

                    totalPriceTextBox.Text = Convert.ToString(totalPrice);
                }
            }
            catch (Exception ex)
            {
               
            }

        }

       
    }
}
