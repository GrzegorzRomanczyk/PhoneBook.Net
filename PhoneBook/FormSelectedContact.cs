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
    public partial class FormSelectedContact : Form
    {
        string name;
        string number;
        int index;
        public FormSelectedContact(string name, string number,int index)
        {
            InitializeComponent();
           this.name= txtName.Text = name;
           this.number= txtNumber.Text = number;
           this.index = index;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtName.ReadOnly = false;
            txtNumber.ReadOnly = false;
            btnEdit.Visible = false;
            btnSave.Visible = true;
            btnCancel.Visible = true;
                
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SetEditModeOff();
 
            DBConnection dBConnection = new DBConnection();
            dBConnection.UpdateContact(dBConnection.ConnectionString, txtName,txtNumber,index);  
        }

        public void btnCancel_Click(object sender, EventArgs e)
        {
            SetEditModeOff();

            txtName.Text = name;
            txtNumber.Text = number;
        }

        public void SetEditModeOff()
        {
            txtName.ReadOnly = true;
            txtNumber.ReadOnly = true;
            btnEdit.Visible = true;
            btnSave.Visible = false;
            btnCancel.Visible = false;
        }
    }
}
