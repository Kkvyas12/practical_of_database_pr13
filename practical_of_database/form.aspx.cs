using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace practical_of_database
{
    public partial class form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vyas\source\repos\practical_of_database\practical_of_database\App_Data\database.mdf;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand("Insert into [dbo].[user] (name,email) values('" + tbname.Text + "','" + tbemail.Text + "');", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                GridView1.DataBind();
            }
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vyas\source\repos\practical_of_database\practical_of_database\App_Data\database.mdf;Integrated Security=True"))
            {
                int selected_user = GridView1.SelectedIndex;
                int id = Convert.ToInt32(GridView1.DataKeys[selected_user].Value);
                SqlCommand cmd = new SqlCommand("delete from [dbo].[user] where id =" + id + ";", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                GridView1.DataBind();
            }
        }
        protected void select_update_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vyas\source\repos\practical_of_database\practical_of_database\App_Data\database.mdf;Integrated Security=True"))
            {
                int selected_user = GridView1.SelectedIndex;
                int id = Convert.ToInt32(GridView1.DataKeys[selected_user].Value);
                SqlCommand fetch = new SqlCommand("select id,name,email from [dbo].[user] where id =" + id + ";", conn);
                conn.Open();
                fetch.ExecuteNonQuery();
                SqlDataReader reader = fetch.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string new_id = reader["id"].ToString();
                        string name = reader["name"].ToString();
                        string email = reader["email"].ToString();

                        tbname.Text = name;
                        tbemail.Text = email;
                        HiddenField1.Value = new_id;
                    }
                }
                GridView1.DataBind();
            }
        }

        protected void btnuptodate_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vyas\source\repos\practical_of_database\practical_of_database\App_Data\database.mdf;Integrated Security=True"))
            {
                int id = Convert.ToInt32(HiddenField1.Value);
                SqlCommand fetch = new SqlCommand("update [dbo].[user] set name='" + tbname.Text + "', email='" + tbemail.Text + "' where id =" + id + ";", conn);
                conn.Open();
                fetch.ExecuteNonQuery();
            }
            GridView1.DataBind();
        }
    }
}