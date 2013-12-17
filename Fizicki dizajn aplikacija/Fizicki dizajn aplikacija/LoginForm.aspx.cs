using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fizicki_dizajn_aplikacija
{
    public partial class LoginForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string id = string.Empty;
            string connectionString = ConfigurationManager.ConnectionStrings["DB_Connection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string sqlString = "Select UserId from Account where Email=@Email and Password=@Password";
                    SqlCommand oCmd = new SqlCommand(sqlString, connection);
                    oCmd.Parameters.AddWithValue("@Email", txtUsername.Text);
                    oCmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                    connection.Open();

                    using (SqlDataReader oReader = oCmd.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            id = oReader["UserID"].ToString();
                        }

                        connection.Close();
                    }
                }
                catch
                {
                }
            }
            if (string.IsNullOrEmpty(id))
            {
                lblWrongData.Text = "Wrong Username and/or Password";
            }
            else
            {
                Session["id"] = id;
                Response.Redirect("ProfileView.aspx");
            }
        }
    }
}