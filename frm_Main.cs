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
    public partial class frm_Reception : Form
    {
        //**************************** برای نمایش نام کاربری در بالای فرم ****************
        string Global_Username = "";

        public frm_Reception()
        {
            InitializeComponent();
        }
        public frm_Reception(string received_Username)
        {
            InitializeComponent();
            Global_Username = received_Username;
        }


        private void frm_Reception_Load(object sender, EventArgs e)
        {
            cls_User_Info usr = new cls_User_Info();
            usr.Username_sg = Global_Username;
            DataTable dt = usr.Search_User_Info();

            if (dt.Rows[0]["Sex"].ToString() == "زن")
                this.Text = "خانم" + " " + dt.Rows[0]["Name"].ToString() + " " + dt.Rows[0]["Family"].ToString() + " " + "خوش آمدید";

            else if (dt.Rows[0]["Sex"].ToString() == "مرد")
                this.Text = "آقای" + " " +  dt.Rows[0]["Name"].ToString() + " " + dt.Rows[0]["Family"].ToString()+ " " + "خوش آمدید";
        }

        //-----------------------------------------------------------------------------------
        //                        *****   Codes of INSERT CUSTOMER DATA TAB 1    *****
        //----------------------------------------------------------------------------------------
        private void btnSave_Click(object sender, EventArgs e)
        {
            cls_Customer Cus = new cls_Customer();
            Cus.Id_sg = txtId.Text;
            Cus.Name_sg = txtName.Text;
            Cus.FamilyName_sg = txtFName.Text;
            if (rdFemale.Checked == true)
                Cus.Sex_sg = "Female";
            else if (rdMale.Checked == true)
                Cus.Sex_sg = "Male";
            if (rdSingle.Checked == true)
                Cus.Marriage_sg = "Single";
            else if (rdMarried.Checked == true)
                Cus.Marriage_sg = "Married";
            Cus.DateOfBirth_sg = txtYearBirth.Text + "/" + txtMonthBirth.Text + "/" + txtDayBirth.Text;
            Cus.Address_sg = txtAddress.Text;
            Cus.Tell_sg = txtTell.Text;
            Cus.Email_sg = txtEmail.Text;

            DataTable dt = Cus.Search_Id();
            if (dt.Rows.Count == 0)
                Cus.Insert();
            else
                MessageBox.Show("این کد ملی تکراری است");

            txtName.Text = "" ;
            txtFName.Text  = "" ;
            txtEmail.Text = "";
            txtDayBirth.Text = "";
            txtId.Text = "";
            txtMonthBirth.Text = "";
            txtTell.Text = "";
            txtYearBirth.Text = "";
            txtAddress.Text = "";
            rdFemale.Checked = false;
            rdMale.Checked = false;
            rdMarried.Checked = false;
            rdSingle.Checked = false;


        }
        //-----------------------------------------------------------------------------------
        //                   *****   Codes of SEARCH button by ID Tab 2  *****
        //----------------------------------------------------------------------------------------
        private void btnSearchTb2_Click(object sender, EventArgs e)
        {
            cls_Customer cus = new cls_Customer ();
            cus.Id_sg = txtIdtb2.Text ;
            DataTable dt = cus.Search_Id();
            if (dt.Rows.Count==0)
                MessageBox.Show ("این کد ملی ثبت نشده است");
            else 
            {
                pnlEdit.Enabled = true;
                txtNametb2.Text=dt.Rows[0]["Name"].ToString();
                txtFamilytb2.Text = dt.Rows [0]["FamilyName"].ToString();
                txtAddb2.Text = dt.Rows [0]["Address"].ToString();
                txtTelltb2.Text = dt.Rows [0]["Tell"].ToString();
                txtEmailtb2.Text = dt.Rows [0]["Email"].ToString();
                if (dt.Rows [0]["Sex"].ToString()== "Female")
                    rbfemaletb2.Checked= true ;
                else if (dt.Rows [0]["Sex"].ToString()== "Male")
                    rbMaleTb2.Checked = true ;
                string[] DB = dt.Rows [0]["DateOfBirth"].ToString().Split ('/');
                txtYearBirthtb2.Text = DB[0];
                txtMonthBirthtb2.Text=DB[1];
                txtDayBirthtb2.Text = DB[2];


            }
            

        }
        //-----------------------------------------------------------------------------------
        //                  *****   Codes of EDIT button  Tab 2  *****
        //----------------------------------------------------------------------------------------
        private void btnEditTb2_Click(object sender, EventArgs e)
        {
            cls_Customer cus = new cls_Customer();
            cus.Id_sg = txtIdtb2.Text;
            cus.Name_sg = txtNametb2.Text;
            cus.FamilyName_sg = txtFamilytb2.Text;
            if (rdFemale.Checked == true)
                cus.Sex_sg = "Female";
            else if (rdMale.Checked == true)
                cus.Sex_sg = "Male";
            if (rdSingle.Checked == true)
                cus.Marriage_sg = "Single";
            else if (rdMarried.Checked == true)
                cus.Marriage_sg = "Married";
            cus.DateOfBirth_sg = txtYearBirthtb2.Text + "/" + txtMonthBirthtb2.Text + "/" + txtDayBirthtb2.Text;
            cus.Address_sg = txtAddb2.Text;
            cus.Tell_sg = txtTelltb2.Text;
            cus.Email_sg = txtEmailtb2.Text;

            cus.Edit();
            Empty_Filds_Tab2();            

        }

        // ------------------- Empty the Filds after Editting   Tab 2--------------------
        public void Empty_Filds_Tab2()
        {
            pnlEdit.Enabled = false;
            txtNametb2.Text = "";
            txtFamilytb2.Text = "";
            txtDayBirthtb2.Text = "";
            txtMonthBirthtb2.Text = "";
            txtYearBirthtb2.Text = "";
            txtTelltb2.Text = "";
            txtEmailtb2.Text = "";
            txtAddb2.Text = "";
            rbfemaletb2.Checked = false;
            rbfemaletb2.Checked = false;
            rbMarriedTb2.Checked = false;
            rbSingleTb2.Checked  = false;
        }

        //-----------------------------------------------------------------------------------
        //                  *****   Codes of DELETE button  TAB 2  *****
        //----------------------------------------------------------------------------------------
        private void btnDeleteTb2_Click(object sender, EventArgs e)
        {
            cls_Customer cus = new cls_Customer();
            cus.Id_sg = txtIdtb2.Text;
            cus.Delete();
            Empty_Filds_Tab2();
        }
        //-----------------------------------------------------------------------------------
        //                  *****   Codes of SEARCH button  by NAME  Tab 3   *****
        //----------------------------------------------------------------------------------------
        private void btnSearchT3_Click(object sender, EventArgs e)
        {
            cls_Customer cus = new cls_Customer();

            cus.Name_sg = txtNameT3.Text;
            cus.FamilyName_sg = txtFamilyT3.Text;
            DataSet ds = cus.Search_by_Name();

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = ds.Tables["tbl_Customer"];
        }

        //-----------------------------------------------------------------------------------------------
        //-------------------------- *  Entering Correct Filds Like Digit or Letter  *-------------------------
        //------------------------------------------------------------------------------------------------------
        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) 
            e.Handled = true;
            //MessageBox.Show ("فقط رقم وارد کنید")
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back))
                e.Handled = true;
        }

        private void txtFName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) || e.KeyChar == (char)Keys.Back)
                e.Handled = true;
        }

        private void txtDayBirth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtMonthBirth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtYearBirth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtTell_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        //-----------------------------------------------------------------------------------------------
        //------------------------با کلیک بر روی هر سطر جدول اطلاعات آن سطر در زیر آن آورده شود
        //---------------------------------------------------------------------------------------------
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            txtName2T3.Text = dataGridView1.Rows[i].Cells["DG_Name"].Value.ToString();
            txtFamily2T3.Text = dataGridView1.Rows[i].Cells["DG_FamilyName"].Value.ToString();
            txtIdT3.Text = dataGridView1.Rows[i].Cells["DG_Id"].Value.ToString();
            txtAddressT3.Text = dataGridView1.Rows[i].Cells["DG_Address"].Value.ToString();
            txtDOFT3.Text = dataGridView1.Rows[i].Cells["DG_DateOfBirth"].Value.ToString();
            txtTellT3.Text = dataGridView1.Rows[i].Cells["DG_Tell"].Value.ToString();
            txtEmailT3.Text = dataGridView1.Rows[i].Cells["DG_Email"].Value.ToString();
            if (dataGridView1.Rows[i].Cells["DG_Sex"].Value.ToString() == "Female")
                rdbtnFemaleT3.Checked = true;
            else if (dataGridView1.Rows[i].Cells["DG_Sex"].Value.ToString() == "Male")
                rdbtnMaleT3.Checked = true;
            if (dataGridView1.Rows[i].Cells["DG_Marriage"].Value.ToString() == "Single")
                rdbtnSingleT3.Checked = true;
            else if (dataGridView1.Rows[i].Cells["DG_Marriage"].Value.ToString() == "Married")
                rdbtnMarriedT3.Checked = true;

        }
        //  اگر برای ویرایش از داحل دیتاگرید تغییرات را دادیم می توانیم با دکمه ویرایش تغییرات را در همانجا سیو کنیم                                                           **********************  
        ////**************************** EDIT Button*******************
        //private void btnEdit_Click(object sender, EventArgs e)
        //{
        //    cls_Customer cs = new cls_Customer();
        //    int i = dataGridView1.CurrentRow.Index;

        //    cs.Id_sg = dataGridView1.Rows[i].Cells["DG_Id"].Value.ToString();
        //    cs.Name_sg = dataGridView1.Rows[i].Cells["DG_Source"].Value.ToString();
        //    cs.FamilyName_sg = dataGridView1.Rows[i].Cells["DG_Desti"].Value.ToString();
        //    cs.Email_sg = dataGridView1.Rows[i].Cells["DG_Cap"].Value.ToString();

        //    cs.Edit();
        //    //Empty_Filds_Tab();  
        //}


      //------------------------------------------------------------------------------------------------
        //--------------------------   INSERT FLIGHT INFO -------------------------------------
        //---------------------------------------------------------------------------------
        private void btnInsertFlightT4_Click(object sender, EventArgs e)
        {
            cls_Flights flt = new cls_Flights() ;
            flt.FlightNum_sg = txtFlightNumT4.Text;
            flt.Airline_sg = cbAirlineT4.Text;
            flt.Source_sg = txtSourceT4.Text;
            flt.Destination_sg = txtDestinationT4.Text;
            flt.Capacity_sg = txtCapacityT4.Text;
            flt.DateOfFlight_sg = txtYearT4.Text  + "/" + txtMonthT4.Text  + "/" + txtDayT4.Text ;
            flt.HourOfFlight_sg = cbHourT4.Text + ":" + cbMinuteT4.Text;
            flt.TravelClass_sg = cbTravelClassT4.Text;

            DataTable dt = flt.Search_Flight_by_Num();
            if (dt.Rows.Count == 0)
                flt.Insert_Flight();
            else
                MessageBox.Show("کد پرواز تکراری است");

            txtFlightNumT4.Text = "";
            cbAirlineT4.Text = "";
            txtSourceT4.Text = "";
            txtDestinationT4.Text = "";
            txtCapacityT4.Text = "";
            txtDayT4.Text = "";
            txtMonthT4.Text = "";
            txtYearT4.Text = "";
            cbHourT4.Text = "";
            cbMinuteT4.Text = "";
            cbTravelClassT4.Text = "";


           // flt.Insert_Flight();
        }

        //-----------------------------------------------------------------------------------------------
        //-------------------------- *  Entering Correct Filds Like Digit or Letter  *-------------------------
        //------------------------------------------------------------------------------------------------------
      
        private void txtFlightNumT5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
           // MessageBox.Show("فقط رقم وارد کنید");
        }
        private void txtFlightNumT4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
            //MessageBox.Show("فقط رقم وارد کنید");
        }
        private void txtSourceT4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) || e.KeyChar == (char)Keys.Back)
                e.Handled = true;
           // MessageBox.Show("فقط حروف وارد کنید");
        }
        private void txtDestinationT4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) || e.KeyChar == (char)Keys.Back)
                e.Handled = true;
            //MessageBox.Show("فقط حروف وارد کنید");
        }


        //---------------------------------------------------------------------------------------------
        //-------------------------------     SEARCH  Button BY FLIGHT NUMBER TAB 5   ------------------------------------
        //----------------------------------------------------------------------------------------------
        private void btnSearchT5_Click(object sender, EventArgs e)
        {
            cls_Flights flt = new cls_Flights();
            flt.FlightNum_sg = txtFlightNumT5.Text;
            DataTable dt = flt.Search_Flight_by_Num();
            if (dt.Rows.Count == 0)
                MessageBox.Show("این کد پرواز وجود ندارد");
            else
            {
                pnlFlightSearch.Enabled = true;
                txtFlightNumT5.Text = dt.Rows[0]["FlightNum"].ToString();
                cbAirlineT5.Text = dt.Rows[0]["Airline"].ToString();
                txtSourceT5.Text = dt.Rows[0]["Source"].ToString();
                txtDestinationT5.Text = dt.Rows[0]["Destination"].ToString();
                txtCapacityT5.Text = dt.Rows[0]["Capacity"].ToString();
                string[] DOF = dt.Rows[0]["DateOfFlight"].ToString().Split('/');
                txtYearT5.Text = DOF[0];
                txtMonthT5.Text = DOF[1];
                txtDayT5.Text = DOF[2];
                string[] HOF = dt.Rows[0]["HourOfFlight"].ToString().Split(':');
                cbHourT5.Text = HOF [0];
                cbMinuteT5.Text = HOF [1];
                cbTravelClassT5.Text = dt.Rows[0]["TravelClass"].ToString();

            }

        }

        //---------------------------------------------------------------------------------------------
        //-------------------------------     EDIT  Button FLIGHT DATA TAB 5   ------------------------------------
        //----------------------------------------------------------------------------------------------
        private void btnEditFlightT5_Click(object sender, EventArgs e)
        {
            cls_Flights flt = new cls_Flights();
            flt.FlightNum_sg = txtFlightNumT5.Text;
            flt.Airline_sg = cbAirlineT5.Text;
            flt.Source_sg = txtSourceT5.Text;
            flt.DateOfFlight_sg = txtYearT5.Text + "/" + txtMonthT5.Text + "/" + txtDayT5.Text;
            flt.HourOfFlight_sg = cbHourT5.Text + ":" + cbMinuteT5.Text ;
            flt.TravelClass_sg = cbTravelClassT5.Text;


            flt.Edit_Flight_Data();
            Empty_Filds_Tab5();
        }
        //--------------------------------------------------------------------------------
        // ------------------- Empty the Filds after Editting   TAB 5--------------------
        //----------------------------------------------------------------------------------
        public void Empty_Filds_Tab5()
        {
            pnlFlightSearch.Enabled = false;
            txtFlightNumT5.Text = "";
            cbAirlineT5.Text = "";
            txtSourceT5.Text = "";
            txtDestinationT5.Text = "";
            txtYearT5.Text = "";
            txtMonthT5.Text = "";
            txtDayT5.Text = "";
            cbHourT5.Text = "";
            cbMinuteT5.Text = "";
            cbTravelClassT5.Text = "";
        }


        //--------------------------------------------------------------------------------
        // ---------------------------------- DELETE FLIGHT DATA   TAB 5--------------------
        //----------------------------------------------------------------------------------
        private void button3_Click(object sender, EventArgs e)
        {
            cls_Flights flt = new cls_Flights();
            flt.FlightNum_sg = txtFlightNumT5.Text;
            flt.Delete_Flight_Data();
            Empty_Filds_Tab5();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
       // ******************************************************************
        //*************************  Button Buy Ticket  ***************************   
        //************************************************************************
        private void btnBuyTb6_Click(object sender, EventArgs e)
        {
            cls_Ticket tk = new cls_Ticket();
            tk.FlightNum_sg = txtFlyNumTb6.Text;
            tk.Capacity_sg = txtcapTb6.Text;
            tk.Id_sg = txtIdTb6.Text;

            int Needed_Ticket = Convert.ToInt32(txtcapTb6.Text);
            
            DataTable dt = tk.Search_Capacity();                   

            int Rest_Ticket = Convert.ToInt32(dt.Rows[0]["Capacity"]) ;

            if ((Needed_Ticket) > (Rest_Ticket))
                MessageBox.Show ("مقدار ظرفیت کافی نمی باشد") ;

            else
            {
                tk.Buy_Ticket();
                tk.Capacity_sg = ((Rest_Ticket) - (Needed_Ticket)).ToString (); 
                tk.Update_Ticket_Number ();           
            }


        }
        //**************************************************************************
        //*****************************  Button Cancel Ticket ************************
        //************************************************************************
        private void btnCanselTb6_Click(object sender, EventArgs e)
        {
            cls_Ticket tk = new cls_Ticket();

            tk.FlightNum_sg = txtFlyNum2Tb6.Text;
            tk.Capacity_sg = txtNum2Tb6.Text;
            tk.Id_sg = txtId2Tb6.Text;

            int Cancel_Ticket = Convert.ToInt32(txtNum2Tb6.Text);

            DataTable dt = tk.Search_buy_Capacity();

            int Bought_Ticket = Convert.ToInt32(dt.Rows[0]["Capacity"]);

            if ((Cancel_Ticket) > (Bought_Ticket))
                MessageBox.Show("مقدار بلیط خریداری شده کمتر می باشد");

            else
            {
             
                tk.Capacity_sg = ((Bought_Ticket) - (Cancel_Ticket)).ToString();
                tk.Update_Bought_Ticket();
                MessageBox.Show("تعداد بلیط خریداری شده، با موفقیت ویرایش شد ");

                DataTable dt2 = tk.Search_Capacity();
                int Main_Ticket = Convert.ToInt32(dt2.Rows[0]["Capacity"]);
                tk.Capacity_sg = ((Main_Ticket ) + (Cancel_Ticket)).ToString();
                tk.Update_Ticket_Number();
            }

        }

       
    }
}
