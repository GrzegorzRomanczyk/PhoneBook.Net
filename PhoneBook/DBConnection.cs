using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneBook
{
    class DBConnection
    {
        public string ConnectionString { get; set; } = @"Data Source =.\SQLEXPRESS; Initial Catalog = PhoneBook; Integrated Security=true;";


        public void ConnectToDBAndFillData(string connectionString, DataGridView dgvContacts)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString)) 
            {
                try
                {
                    sqlCon.Open();
                    
                }
                catch (Exception)
                {

                    MessageBox.Show("Błąd połączenia z bazą danych");
                    return;
                }

                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Contacts  ", sqlCon);
                DataTable dtContacts = new DataTable();
                sqlDa.Fill(dtContacts);
                dgvContacts.AutoGenerateColumns = false;
                dgvContacts.DataSource = dtContacts;
                sqlCon.Close();
            }  
        }
        public void UpdateContact(string connectionString, TextBox name, TextBox number, int id)
        {
            SqlConnection sqlCon = new SqlConnection(connectionString);
            try
            {
                sqlCon.Open();
                
            }
            catch (Exception)
            {

                MessageBox.Show("Błąd połączenia z bazą danych");
                return;
            }
            string command = "update Contacts set name=@name, number=@number Where id=@index";
            SqlCommand cmdEditData = new SqlCommand(command, sqlCon);
            cmdEditData.Parameters.AddWithValue("@name", name.Text);
            cmdEditData.Parameters.AddWithValue("@number", number.Text);
            cmdEditData.Parameters.AddWithValue("@index", id);

            cmdEditData.ExecuteNonQuery();
            sqlCon.Close();
        }
        public void AddContact( string connectionString, TextBox name, TextBox number)
        {
            SqlConnection sqlCon = new SqlConnection(connectionString);
            try
            {
                sqlCon.Open();
                
            }
            catch (Exception)
            {

                MessageBox.Show("Błąd połączenia z bazą danych");
                return;
            }

            string command = "Insert Into Contacts(name, number) Values (@name, @number) ";
            SqlCommand cmdAdd = new SqlCommand(command, sqlCon);
            cmdAdd.Parameters.AddWithValue("@name",name.Text);
            cmdAdd.Parameters.AddWithValue("@number",number.Text);

            cmdAdd.ExecuteNonQuery();
            sqlCon.Close();

        }

        public void DeleteContact(string connectionString, int id)
        {
            SqlConnection sqlCon = new SqlConnection(connectionString);
            try
            {
                sqlCon.Open();

            }
            catch (Exception)
            {

                MessageBox.Show("Błąd połączenia z bazą danych");
                return;
            }

            string command = "Delete From Contacts where id=@index";
            SqlCommand cmdAdd = new SqlCommand(command, sqlCon);
            cmdAdd.Parameters.AddWithValue("@index", id);
            cmdAdd.ExecuteNonQuery();
            sqlCon.Close();
        }

        public void Serach(string connectionString, DataGridView dgvContacts,TextBox serach)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();

                }
                catch (Exception)
                {

                    MessageBox.Show("Błąd połączenia z bazą danych");
                    return;
                }

                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Contacts where concat(name , number) like '%" + serach.Text + "%'", sqlCon);
                DataTable dtContacts = new DataTable();
                sqlDa.Fill(dtContacts);
                dgvContacts.AutoGenerateColumns = false;
                dgvContacts.DataSource = dtContacts;
                sqlCon.Close();
            }
        }
    }
}
