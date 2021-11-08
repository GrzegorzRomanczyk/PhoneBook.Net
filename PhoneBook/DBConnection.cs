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


        public void ConnectToDB(string connectionString, DataGridView dgvContacts)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    MessageBox.Show("połączenie działa");
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
    }
}
