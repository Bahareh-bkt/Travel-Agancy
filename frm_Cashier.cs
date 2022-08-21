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
    public partial class frm_Cashier : Form
    {
        string Global_Username = "";
        public frm_Cashier()
        {
            InitializeComponent();
        }

        public frm_Cashier(string received_Username)
        {
            InitializeComponent();
            Global_Username = received_Username;
        }

        private void frm_Cashier_Load(object sender, EventArgs e)
        {
            cls_User_Info usr = new cls_User_Info();
            usr.Username_sg = Global_Username;
            DataTable dt = usr.Search_User_Info();

            if (dt.Rows[0]["Sex"].ToString() == "زن")
                this.Text = "خانم" + " " + dt.Rows[0]["Name"].ToString() + " " + dt.Rows[0]["Family"].ToString() + " " + "خوش آمدید";

            else if (dt.Rows[0]["Sex"].ToString() == "مرد")
                this.Text = "آقای" + " " +  dt.Rows[0]["Name"].ToString() + " " + dt.Rows[0]["Family"].ToString()+ " " + "خوش آمدید";
        
        }
    }
}
