using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fizicki_dizajn_aplikacija
{
    public partial class AddExistingWork : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGridView();
        }

        protected void linkBtnAdd_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int a = row.RowIndex;
            Label lblID = ((Label)gvAllWorks.Rows[a].FindControl("lblID"));

            string userId = Session["id"].ToString();

            string connectionString = ConfigurationManager.ConnectionStrings["DB_Connection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string sqlStringUsersWorks = "INSERT INTO Users_Works(UserID, WorkID) VALUES (@UserID, @WorkID)";
                    SqlCommand oCmdUW = new SqlCommand(sqlStringUsersWorks, connection);
                    oCmdUW.Parameters.AddWithValue("@UserID", userId);
                    oCmdUW.Parameters.AddWithValue("@WorkID", lblID.Text);

                    connection.Open();
                    oCmdUW.ExecuteNonQuery();
                    connection.Close();
                }
                catch
                {
                }
            }
            Response.Redirect("ProfileView.aspx");
        }



        public void BindGridView()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DB_Connection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string sqlString = "Select WorkId, Title, DateOfMaking from Works";
                    SqlCommand oCmd = new SqlCommand(sqlString, connection);
                    connection.Open();

                    SqlDataAdapter sdr = new SqlDataAdapter();
                    sdr.SelectCommand = oCmd;
                    DataSet ds = new DataSet();
                    sdr.Fill(ds);
                    gvAllWorks.DataSource = ds.Tables[0].DefaultView;

                    connection.Close();
                }
                catch
                {
                }
            }
            gvAllWorks.DataBind();
        }
    }
}