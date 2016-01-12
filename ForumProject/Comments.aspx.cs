using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;


public partial class Comments : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int forumId = int.Parse(Request.Params["forumId"]);

        string queryString = "SELECT question FROM Forum WHERE forumId = @forumId";

        Label LResult = (Label)LoginView1.FindControl("LResult");

        LResult.Text = "";

        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\mydb.mdf;Integrated Security=True");

        string[] allRecords;

        using (var command = new SqlCommand(queryString, connection))
        {
            command.Parameters.Add("@forumId", SqlDbType.Int).Value = forumId;
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                var list = new List<string>();
                while (reader.Read())
                {
                    list.Add(reader.GetSqlValue(0).ToString());
                }

                allRecords = list.ToArray();
            }
        }

        if (allRecords.Count() == 1)
        {
            LTopicname.Text = allRecords[0];
        }
        else
        {
            LTopicname.Text = "ERROR: found " + allRecords.Count() + " topics with such ID";
        }
    }

    protected void BPostQuestion_Click(object sender, EventArgs e)
    {
            TextBox TBAnswer = (TextBox)LoginView1.FindControl("TBAnswer");
            Label LResult = (Label)LoginView1.FindControl("LResult");

            int ctitleId = Convert.ToInt32(Request.QueryString["forumId"]);
            string question = TBAnswer.Text;
            string posterName = HttpContext.Current.User.Identity.Name;
            DateTime dateTime = DateTime.Now;

            try
            {
                PostComment.insertComment(ctitleId, question, posterName, dateTime);
                LResult.Text = "Answer posted successfully.";
                TBAnswer.Text = "";
            }
            catch(Exception ex)
            {
                LResult.Text = "Exception: " + ex.ToString();
            }

            RepComments.DataBind();
    }

    protected void deleteComment(Object sender, EventArgs e)
    {
        string commentId = ((LinkButton)sender).CommandArgument;
        Response.Redirect("~/DeleteComment.aspx?commentId=" + commentId);
    }

    protected void editComment(Object sender, EventArgs e)
    {
        string commentId = ((LinkButton)sender).CommandArgument;
        Response.Redirect("~/EditComment.aspx?commentId=" + commentId);
    }
 
    protected void BMove_Click(object sender, EventArgs e)
    {
        DropDownList DDL = (DropDownList)LoginView3.FindControl("DDLCategories");
        int titleID = int.Parse(DDL.SelectedValue);
        int forumId = int.Parse(Request.Params["forumId"]);
       
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\mydb.mdf;Integrated Security=True");
        
        string queryString = "UPDATE Forum SET titleId = @titleId WHERE forumId = @forumId";
        
        var command = new SqlCommand(queryString, connection);
        command.Parameters.Add("@titleId", SqlDbType.Int).Value = titleID;
        command.Parameters.Add("@forumId", SqlDbType.Int).Value = forumId;

        connection.Open();

        int RowsAffected = command.ExecuteNonQuery();
        Response.Redirect("~/index.aspx");
         
    }
}