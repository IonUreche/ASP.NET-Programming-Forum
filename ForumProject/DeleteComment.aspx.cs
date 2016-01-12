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

public partial class DeleteComment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BYes_Click(object sender, EventArgs e)
    {
            int commentId = int.Parse(Request.Params["commentId"]);
            int forumId = GetForumIdFromCommentId(commentId);
        
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\mydb.mdf;Integrated Security=True");

            string queryString = "DELETE Thread WHERE threadId = @thrd_Id";
            int RowsAffected = 0;
            try
            {
                var command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@thrd_Id", SqlDbType.Int).Value = commentId;

                connection.Open();

                RowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                LResult.Text = "DataBase error: " + ex.ToString();
            }

            if (RowsAffected == 0)
            {
                // THis should not happen
                LResult.Text = "Error: No comment was deleted. ";
                return;
            }
            else
            {
                LResult.Text = "Comment deleted successfully !";
                Response.Redirect("~/Comments.aspx?forumId=" + forumId);
            }    
    }

    protected void BNo_Click(object sender, EventArgs e)
    {
        int commentId = 0;
        try
        {
            commentId = int.Parse(Request.Params["commentId"]);
        }
        catch(Exception ex)
        {
            Response.Redirect("~/index.aspx");
        }

        int forumId = GetForumIdFromCommentId(commentId);
        string url = "~/Comments.aspx?forumId=" + forumId.ToString();
        Response.Redirect(url);
    }

    protected int GetForumIdFromCommentId(int commentId)
    {
        string queryString = "SELECT forumId FROM Thread WHERE threadId = @commentId";

        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\mydb.mdf;Integrated Security=True");

        string[] allRecords;

        using (var command = new SqlCommand(queryString, connection))
        {
            command.Parameters.Add("@commentId", SqlDbType.Int).Value = commentId;
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
            try
            {
                int forumId = int.Parse(allRecords[0]);
                return forumId;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        else
        {
            return -1;
        }
    }
}