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
    public partial class EditWork : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTitle.Text))
            {
                int workId = getLastWorkID() + 1;
                string userid = Session["id"].ToString();
                //string userid = "1";
                string connectionString = ConfigurationManager.ConnectionStrings["DB_Connection"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        string sqlString = "INSERT INTO Works (WorkID,Title,DateOfMaking) VALUES (@workid, @title, @date)";
                        SqlCommand oCmd = new SqlCommand(sqlString, connection);
                        oCmd.Parameters.AddWithValue("@workid", workId);
                        oCmd.Parameters.AddWithValue("@title", txtTitle.Text);
                        oCmd.Parameters.AddWithValue("@date", txtDate.Text);

                        string sqlStringUsersWorks = "INSERT INTO Users_Works(UserID, WorkID) VALUES (@UserID, @WorkID)";
                        SqlCommand oCmdUW = new SqlCommand(sqlStringUsersWorks, connection);
                        oCmdUW.Parameters.AddWithValue("@UserID", userid);
                        oCmdUW.Parameters.AddWithValue("@WorkID", workId);

                        connection.Open();
                        oCmd.ExecuteNonQuery();
                        oCmdUW.ExecuteNonQuery();
                        connection.Close();
                    }
                    catch
                    {
                    }
                }
            }
            Response.Redirect("ProfileView.aspx");
        }

        private int getLastWorkID()
        {
            string max = string.Empty;
            string connectionString = ConfigurationManager.ConnectionStrings["DB_Connection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string sqlString = "select MAX(WorkID) as maxID from Works";
                    SqlCommand oCmd = new SqlCommand(sqlString, connection);
                    connection.Open();
                    using (SqlDataReader oReader = oCmd.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            max = oReader["maxID"].ToString();
                        }
                        connection.Close();
                    }
                }
                catch
                {
                }
            }
            return Convert.ToInt32(max);
        }
    }
}