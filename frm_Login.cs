using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agancy
{
    public partial class frm_Login : Form
    {
        public frm_Login()
        {
            InitializeComponent();
        }

        //************************************************************************
        //***********************************      Button LOGIN         **********
        //************************************************************************

        private void btnlogin_Click(object sender, EventArgs e)
        {
            cls_Login lgn = new cls_Login();
            lgn.Username_sg = txtUsername.Text;
            lgn.Password_sg = txtPassword.Text;

            DataTable dt = lgn.Login();

            if (dt.Rows.Count == 0)
                MessageBox.Show("نام کاربری یا کلمه عبور اشتباه است");

            else if (dt.Rows[0]["UserType"].ToString() == "reception")
            {
               
                frm_Reception frm = new frm_Reception(txtUsername.Text );
                frm.Show();
            }
            else if (dt.Rows[0]["UserType"].ToString() == "Cashier")
            {
                frm_Cashier frm = new frm_Cashier(txtUsername.Text);
                frm.Show();
            }
            else if (dt.Rows[0]["UserType"].ToString() == "Manager")
            {
                frm_Manager frm = new frm_Manager(txtUsername.Text);
                frm.Show();
            }
           
        }

    }
}
