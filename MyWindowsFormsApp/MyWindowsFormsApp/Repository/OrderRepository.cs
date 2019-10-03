using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using MyWindowsFormsApp.Model;
namespace MyWindowsFormsApp.Repository
{
    class OrderRepository
    {
        public bool Add(Order order)
        {
            bool isAdded = false;
            try
            {
                //Connection
                string connectionString = @"Server=SABBIR; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //INSERT INTO Items (Name, Price) Values ('Black', 120)
                string commandString = @"INSERT INTO Orders (CustomerId, ItemId, Quantity, TotalPrice) Values (" + order.CustomerId + ", " + order.ItemId + ", " + order.Quantity+ ", " + order.TotalPrice+")";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();
                //Insert
                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    isAdded = true;
                }

                //Close
                sqlConnection.Close();

            }
            catch (Exception exeption)
            {
                //MessageBox.Show(exeption.Message);
                throw new Exception(exeption.Message);
            }

            return isAdded;

        }
        public DataTable Display()
        {

            //Connection
            string connectionString = @"Server=SABBIR; Database=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //INSERT INTO Items (Name, Price) Values ('Black', 120)
            string commandString = @"SELECT o.Id, c.Name As Customer, i.Name AS Item, Quantity,i.Price, o.TotalPrice FROM Orders AS o
LEFT JOIN Customers AS c ON c.Id = o.CustomerId
LEFT JOIN Items AS i ON i.Id = o.ItemId  ";

            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //Show
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

   
            sqlConnection.Close();

            return dataTable;

        }
        public DataTable ItemCombo()
        {

            //Connection
            string connectionString = @"Server=SABBIR; Database=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //INSERT INTO Items (Name, Price) Values ('Black', 120)

            string commandString = @"SELECT Id, Name FROM Items";



            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //Show
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            //if (dataTable.Rows.Count > 0)
            //{
            //    //showDataGridView.DataSource = dataTable;
            //}
            //else
            //{
            //    //MessageBox.Show("No Data Found");
            //}

            //Close
            sqlConnection.Close();

            return dataTable;

        }
        public DataTable CustomerCombo()
        {

            //Connection
            string connectionString = @"Server=SABBIR; Database=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //INSERT INTO Items (Name, Price) Values ('Black', 120)
            string commandString = @"SELECT Id, Name FROM Customers";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //Show
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);


            //Close
            sqlConnection.Close();

            return dataTable;

        }

        public double TotalPrice(string item)
        {
            //Connection
            string connectionString = @"Server=SABBIR; Database=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            double itemPrice=0;
            //Command 
            //INSERT INTO Items (Name, Price) Values ('Black', 120)
            string commandString = @"SELECT Price FROM Items WHERE Name='" + item + "'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            

            //Open
            sqlConnection.Open();
            
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    itemPrice = reader.GetDouble(0);
                    if (itemPrice == null)
                    {
                        break;
                    }
                }
            }


            //Close
            sqlConnection.Close();
            return itemPrice;
        }

    }
}
