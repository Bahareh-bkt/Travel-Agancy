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
    class cls_Flights
    {
        string FlightNum = "", Airline = "", Source = "", Destination = "", Capacity = "", DateOfFlight = "", HourOfFlight = "", TravelClass = "";

        public string FlightNum_sg
        {
            set { FlightNum = value; }
            get { return FlightNum; }
        }
        public string Airline_sg
        {
            set { Airline = value; }
            get { return Airline; }
        }
        public string Source_sg
        {
            set { Source  = value; }
            get { return Source ; }
        }
        public string Destination_sg
        {
            set { Destination  = value; }
            get { return Destination ; }
        }
        public string Capacity_sg
        {
            set { Capacity  = value; }
            get { return Capacity ; }
        }
        public string DateOfFlight_sg
        {
            set { DateOfFlight = value; }
            get { return DateOfFlight ; }
        }
        public string HourOfFlight_sg
        {
            set { HourOfFlight  = value; }
            get { return HourOfFlight ; }
        }
        public string TravelClass_sg
        {
            set { TravelClass  = value; }
            get { return TravelClass ; }
        }
         //--------------------------------------------------------------------------------------------
        ////----------------------------------------   INSERT FLIGHT DATA TAB 4  --------------------------
        //-----------------------------------------------------------------------------------------------
        public void Insert_Flight()
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\dbagency.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Insert_Flight", con );
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FlightNum", FlightNum );
            cmd.Parameters.AddWithValue("@Airline", Airline );
            cmd.Parameters.AddWithValue("@Source", Source );
            cmd.Parameters.AddWithValue("@Destination", Destination );
            cmd.Parameters.AddWithValue("@Capacity", Capacity );
            cmd.Parameters.AddWithValue("@DateOfFlight", DateOfFlight );
            cmd.Parameters.AddWithValue("@HourOfFlight", HourOfFlight );
            cmd.Parameters.AddWithValue("@TravelClass", TravelClass );

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("اطلاعات پرواز با موفقیت ثبت شد");
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message);
            }                    
            
        }

        //----------------------------------------------------------------------------------------
        ///                    ****   SEARCH FLIGHT   by   NUMBER TAB 5 ****
        //----------------------------------------------------------------------------------------
        public DataTable Search_Flight_by_Num()
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\dbagency.mdf;Integrated Security=True");
            SqlDataAdapter da = new SqlDataAdapter("Search_FlightNum", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@FlightNum", FlightNum);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }

        //----------------------------------------------------------------------------------------
        ///                    ****   EDIT FLIGHT Data    TAB 5  ****
        //----------------------------------------------------------------------------------------
        public void Edit_Flight_Data()
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\dbagency.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Edit_Flight", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FlightNum", FlightNum);
            cmd.Parameters.AddWithValue("@Airline", Airline);
            cmd.Parameters.AddWithValue("@Source", Source);
            cmd.Parameters.AddWithValue("@Destination", Destination);
            cmd.Parameters.AddWithValue("@Capacity", Capacity);
            cmd.Parameters.AddWithValue("@DateOfFlight", DateOfFlight);
            cmd.Parameters.AddWithValue("@HourOfFlight", HourOfFlight);
            cmd.Parameters.AddWithValue("@TravelClass", TravelClass);
          

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("ویرایش اطلاعات به درستی انجام شد ");
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message);
            }
        }

        //----------------------------------------------------------------------------------------
        ///                    ****   DELETE FLIGHT Data   TAB 5  ****
        //----------------------------------------------------------------------------------------
        public void Delete_Flight_Data()
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\dbagency.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Delete_Flight", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FlightNum", FlightNum);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("اطلاعات پرواز با موفقیت حذف شد");
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message);
            }

        }
    }
    
}
