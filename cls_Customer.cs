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
    class cls_Customer
    {
        string Id = "", Name = "", FamilyName = "", Sex = "", Marriage = "", DateOfBirt = "", Address = "", Tell = "", Email = "";
        public string Id_sg
        { 
            set {Id= value;}
            get {return Id;}
        }

        public string Name_sg
        {
            set { Name = value; }
            get { return Name; }
        }
        public string FamilyName_sg
        {
            set { FamilyName = value; }
            get { return FamilyName; }
        }
        public string Sex_sg
        {
            set { Sex = value;}
            get { return Sex; }
        }
        public string Marriage_sg
        {
            set { Marriage = value; }
            get { return Marriage; }
        }
        public string DateOfBirth_sg
        {
            set { DateOfBirt = value; }
            get { return DateOfBirt; }
        }
        public string Address_sg
        {
            set { Address = value;}
            get { return Address; }
        }
        public string Tell_sg
        {
            set { Tell = value; }
            get { return Tell; }
        }
        public string Email_sg
        {
            set { Email = value; }
            get { return Email; }
        }
       

        //---------------------------------------------------------------------
        //                   *** INSERT Customer Data****
        //----------------------------------------------------------------------------------------
        public void Insert()
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\dbagency.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand ("Insert_Customer", con );
            cmd.CommandType = CommandType.StoredProcedure ;

            cmd.Parameters.AddWithValue ("@Id",Id );
            cmd.Parameters.AddWithValue ("@Name", Name );
            cmd.Parameters.AddWithValue ("@FamilyName", FamilyName );
            cmd.Parameters.AddWithValue ("@Sex", Sex );
            cmd.Parameters.AddWithValue ("@Marriage", Marriage );
            cmd.Parameters.AddWithValue ("@DateOfBirth", DateOfBirt);
            cmd.Parameters.AddWithValue ("@Address", Address );
            cmd.Parameters.AddWithValue ("@Tell",Tell );
            cmd.Parameters.AddWithValue ("@Email", Email );


            try 
            {
                con.Open ();
                cmd.ExecuteNonQuery ();
                con.Close ();
                MessageBox.Show ("اطلاعات با موفقیت ثبت شد");
            }
            catch(SqlException err)
            {
                MessageBox.Show (err.Message );
            }

        }

        //----------------------------------------------------------------------------------------
        ///                    ****   SEARCH Customer    by   ID   TAB 2 ****
        //----------------------------------------------------------------------------------------
        public DataTable Search_Id()
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\dbagency.mdf;Integrated Security=True");
            SqlDataAdapter da = new SqlDataAdapter("Search_Customer", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Id", Id);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        
        }
        //----------------------------------------------------------------------------------------
        ///                    ****   SEARCH Customer Data   by   Name  TAB 3  ****
        //----------------------------------------------------------------------------------------
        public DataSet Search_by_Name()
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\dbagency.mdf;Integrated Security=True");
            SqlDataAdapter da = new SqlDataAdapter("Search_by_Name", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.AddWithValue("@Name", Name);
            da.SelectCommand.Parameters.AddWithValue("@FamilyName", FamilyName);

            DataSet ds = new DataSet();
            da.Fill(ds, "tbl_Customer");
            return ds;
        
        }


        //----------------------------------------------------------------------------------------
        ///                    ****   EDIT Customer Data    TAB 3  ****
        //----------------------------------------------------------------------------------------
        public void Edit()
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\dbagency.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Edit_Customer", con );
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@FamilyName", FamilyName);
            cmd.Parameters.AddWithValue("@Sex", Sex);
            cmd.Parameters.AddWithValue("@Marriage", Marriage);
            cmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirt);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@Tell", Tell);
            cmd.Parameters.AddWithValue("@Email", Email);

            try
            {
                con.Open ();
                cmd.ExecuteNonQuery ();
                MessageBox.Show("ویرایش اطلاعات به درستی انجام شد ");
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message);
            }
        }
        //----------------------------------------------------------------------------------------
        ///                    ****   DELETE Customer Data   TAB 3  ****
        //----------------------------------------------------------------------------------------
        public void Delete()
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\dbagency.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Delete_Customer", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", Id );

            try 
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("اطلاعات با موفقیت حذف شد");
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message);
            }        
        
        }

    
    }

        
}
