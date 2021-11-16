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
    public partial class FormAddContact : Form
    {
        public FormAddContact()
        {
            InitializeComponent();
        }

        private void FormAddContact_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DBConnection dBConnection = new DBConnection();
            dBConnection.AddContact(dBConnection.ConnectionString,txtAddName, txtAddNumber);
            MessageBox.Show("Kontakt dodano");
            this.Close();
                
        }
    }
}
