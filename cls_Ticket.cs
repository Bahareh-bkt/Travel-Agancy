using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Agancy
{
    class cls_Ticket
    {
        string FlightNum = "", Id = "", Capacity = "";

        public string FlightNum_sg
        {
            set { FlightNum = value; }
            get { return FlightNum; }
        }
        public string Id_sg
        {
            set { Id = value; }
            get { return Id; }
        }
        public string Capacity_sg
        {
            set { Capacity = value; }
            get { return Capacity; }
        }
        //**************************************************************************
        //*************************  Insert into tbl Buy_Ticket Info  **************************
        //***************************************************************************
        public void Buy_Ticket()
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\dbagency.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("buy_Ticket", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FlightNum", FlightNum);
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@Capacity", Capacity);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("خرید بلیط با موفقیت انجام شد");
            }
            catch (SqlException err)
            {
                //MessageBox.Show(err.Message);
                MessageBox.Show("این کد ملی تکراری است");
            }
        }
        //----------------------------------------------------------------------------------------
        ///                    ****   SEARCH Number of Tickek    by   capacity TAB 5 ****
        //----------------------------------------------------------------------------------------
        public DataTable Search_Capacity()
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\dbagency.mdf;Integrated Security=True");
            SqlDataAdapter da = new SqlDataAdapter("Search_Capacity", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.AddWithValue("@FlightNum", FlightNum);
            da.SelectCommand.Parameters.AddWithValue("@Capacity", Capacity);

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }

        //----------------------------------------------------------------------------------------
        ///                    ****   UPDATE Ticket_Numbers  in Table Flight  TAB 5  ****
        //----------------------------------------------------------------------------------------
        public void Update_Ticket_Number()
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\dbagency.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Update_Ticket_Number", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FlightNum", FlightNum);
            cmd.Parameters.AddWithValue("@Capacity", Capacity);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();               
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message);
            }
        }

        //----------------------------------------------------------------------------------------
        ///                    ****   SEARCH Capacity in table Buy-Ticket ****
        //----------------------------------------------------------------------------------------
        public DataTable Search_buy_Capacity()
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\dbagency.mdf;Integrated Security=True");
            SqlDataAdapter da = new SqlDataAdapter("Search_in_tblBuyTicket", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.AddWithValue("@FlightNum", FlightNum);
            da.SelectCommand.Parameters.AddWithValue("@Id", Id);

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
        //----------------------------------------------------------------------------------------
        ///                    ****   UPDATE Ticket_Numbers  in Table Buy_Ticket  TAB 5  ****
        //----------------------------------------------------------------------------------------
        public void Update_Bought_Ticket()
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\dbagency.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Update_tbl_BuyTicket", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@Capacity", Capacity);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                //MessageBox.Show("ویرایش ظرفیت باقی مانده به درستی انجام شد ");
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
