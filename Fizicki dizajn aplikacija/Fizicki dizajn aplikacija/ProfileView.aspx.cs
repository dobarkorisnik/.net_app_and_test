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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Session["id"].ToString();
            //string id = "1";
            BindGridView(id);
            string connectionString = ConfigurationManager.ConnectionStrings["DB_Connection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string sqlString = "Select FirstName, LastName from Users where UserID=@UserID";
                    SqlCommand oCmd = new SqlCommand(sqlString, connection);
                    oCmd.Parameters.AddWithValue("@UserID", id);
                    connection.Open();
                    using (SqlDataReader oReader = oCmd.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            lblName.Text = oReader["FirstName"].ToString();
                            lblLastName.Text = oReader["LastName"].ToString();
                        }

                        connection.Close();
                    }
                }
                catch
                {
                }
            }
        }

        public void BindGridView(string UserID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DB_Connection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string sqlString = "Select w.WorkID, w.Title, w.DateOfMaking from Works as w, Users_Works as uw, Users as u where w.WorkID=uw.WorkID and u.UserID=uw.UserID and u.UserID=@UserID";
                    SqlCommand oCmd = new SqlCommand(sqlString, connection);
                    oCmd.Parameters.AddWithValue("@UserID", UserID);
                    connection.Open();

                    SqlDataAdapter sdr = new SqlDataAdapter();
                    sdr.SelectCommand = oCmd;
                    DataSet ds = new DataSet();
                    sdr.Fill(ds);
                    gvWorks.DataSource = ds.Tables[0].DefaultView;

                    connection.Close();
                }
                catch
                {
                }
            }
            gvWorks.DataBind();
        }

        protected void btnAddWork_Click(object sender, EventArgs e)
        {
            string id = Session["id"].ToString();
            Session["id"] = id;
            Response.Redirect("AddNewWork.aspx");
        }

        protected void btnAddExistingWork_Click(object sender, EventArgs e)
        {
            string id = Session["id"].ToString();
            Session["id"] = id;
            Response.Redirect("AddExistingWork.aspx");
        }

        protected void linkBtnDelete_Click(object sender, EventArgs e)
        {
            string userID = Session["id"].ToString();

            string connectionString = ConfigurationManager.ConnectionStrings["DB_Connection"].ConnectionString;
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int a = row.RowIndex;
            Label lblID = ((Label)gvWorks.Rows[a].FindControl("lblID"));
            int workid = Convert.ToInt32(lblID.Text);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                   string sqlString = "DELETE FROM Users_Works WHERE UserID=@userid and WorkID=@workid";
                    SqlCommand oCmd = new SqlCommand(sqlString, connection);
                    oCmd.Parameters.AddWithValue("@userid", userID);
                    oCmd.Parameters.AddWithValue("@workid", workid);
                    connection.Open();

                    oCmd.ExecuteNonQuery();
                    BindGridView(userID);

                    connection.Close();
                }
                catch
                {
                }
            }
        }
    }
}