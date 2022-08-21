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
    class cls_Login
    {
        string Username = "", Password = "", UserType = "";
        public string Username_sg
        {
            set { Username = value; }
            get { return Username; }
        }
        public string Password_sg
        {
            set { Password = value; }
            get { return Password; }
        }
        public string UserType_sg
        {
            set { UserType = value; }
            get { return UserType; }
        }

        public DataTable Login()
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\dbagency.mdf;Integrated Security=True");
            SqlDataAdapter da = new SqlDataAdapter("Login", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.AddWithValue("@Username", Username);
            da.SelectCommand.Parameters.AddWithValue("@Password", Password );

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
    }
}
