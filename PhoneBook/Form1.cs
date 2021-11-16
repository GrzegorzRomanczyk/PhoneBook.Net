using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneBook
{
    public partial class Form1 : Form
    {
        public int IndexToDelete { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DBConnection dBConnection = new DBConnection();
            dBConnection.ConnectToDBAndFillData(dBConnection.ConnectionString,dgvContacts);
        }

        private void btnNowy_Click(object sender, EventArgs e)
        {
            FormAddContact formAddContact = new FormAddContact();
            formAddContact.ShowDialog();

            DBConnection dBConnection = new DBConnection();
            dBConnection.ConnectToDBAndFillData(dBConnection.ConnectionString, dgvContacts);

        }

        private void dgvContacts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            int index;
            index = dgvContacts.CurrentCell.RowIndex;
            if (index >= 0)
            { 
                FormSelectedContact formSelectedContact = new FormSelectedContact(dgvContacts.Rows[index].Cells[0].Value.ToString(), dgvContacts.Rows[index].Cells[1].Value.ToString(),Convert.ToInt32(dgvContacts.Rows[index].Cells[2].Value),index);
                formSelectedContact.ShowDialog();

                DBConnection dBConnection = new DBConnection();
                dBConnection.ConnectToDBAndFillData(dBConnection.ConnectionString, dgvContacts);
            }
        }

        private void btnUsun_Click(object sender, EventArgs e)
        {
            if (dgvContacts.RowCount > 0)
            {
                int index;
                index = dgvContacts.CurrentCell.RowIndex;
            
                DBConnection connection = new DBConnection();

                IndexToDelete = Convert.ToInt32(dgvContacts.Rows[index].Cells[2].Value);
                connection.DeleteContact(connection.ConnectionString, IndexToDelete);
                connection.ConnectToDBAndFillData(connection.ConnectionString, dgvContacts);
            }
            else
            {
                MessageBox.Show("Brak kontaktów do usuniecia");
            }
         }

        private void txtSzukaj_TextChanged(object sender, EventArgs e)
        {
            DBConnection db = new DBConnection();
            db.Serach(db.ConnectionString, dgvContacts, txtSzukaj);
        }
    }
}
