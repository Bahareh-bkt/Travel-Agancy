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
    class cls_User_Info
    {
        string Username = "", Name = "", Family = "", Sex = "", Tell = "";

        public string Username_sg
        {
            set { Username = value; }
            get { return Username; }
        }

        public string Name_sg
        {
            set { Name = value; }
            get { return Name; }
        }
        public string Family_sg
        {
            set { Family = value; }
            get { return Family; }
        }
        public string Sex_sg
        {
            set { Sex = value; }
            get { return Sex; }
        }
        public string Tell_sg
        {
            set { Tell = value; }
            get { return Tell; }
        }
        //********************************************************************
        //****************************  Search Users by USERNAME *************
        //**********************************************************************
        public DataTable Search_User_Info()
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\dbagency.mdf;Integrated Security=True");
            SqlDataAdapter da = new SqlDataAdapter("User_Info", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.AddWithValue("@Username", Username);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;

        }
    }
}
