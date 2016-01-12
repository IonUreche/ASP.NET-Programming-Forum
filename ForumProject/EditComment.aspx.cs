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

    public partial class EditComment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int commentId = int.Parse(Request.Params["commentId"]);

                string queryString = "SELECT forumId, answer FROM Thread WHERE threadId = @commentId";

                Label LResult = (Label)LoginView1.FindControl("LResult");

                LResult.Text = "";

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
                            list.Add(reader.GetSqlValue(1).ToString());
                        }

                        allRecords = list.ToArray();
                    }
                   
                }

                if(allRecords.Count() == 2)
                {
                    TextBox TBAnswer = (TextBox)LoginView1.FindControl("TBAnswer");
                    TBAnswer.Text = allRecords[1];
                }
            }
        }

        protected void editComment(object sender, EventArgs e)
        {
             // Now we should update username's roleId
             TextBox TBAnswer = (TextBox)LoginView1.FindControl("TBAnswer");
             Label LResult = (Label)LoginView1.FindControl("LResult");
             DateTime new_time = DateTime.Now;
             SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\mydb.mdf;Integrated Security=True");
             int commentId = int.Parse(Request.Params["commentId"]);

             string queryString = "UPDATE Thread SET answer = @new_answer, datetime = @new_time WHERE threadId = @thrd_Id";
             try
             {
                 var command = new SqlCommand(queryString, connection);
                 command.Parameters.Add("@thrd_Id", SqlDbType.Int).Value = commentId;
                 command.Parameters.Add("@new_time", SqlDbType.DateTime).Value = new_time;
                 command.Parameters.Add("@new_answer", SqlDbType.NVarChar).Value = TBAnswer.Text;

                 connection.Open();

                 int RowsAffected = command.ExecuteNonQuery();
                 if(RowsAffected == 0)
                 {
                     // THis should not happen
                     LResult.Text = "Error: No user was updated. ";
                     return;
                 }
                 else
                 {
                     LResult.Text = "Comment edited successfully !";
                     Button BBack = (Button)LoginView1.FindControl("BBack");
                     BBack.Visible = true;
                     return;
                 }
             }   
             catch(Exception ex)
             {
                 LResult.Text = "DataBase error: " + ex.ToString();
             }

        }

        protected void BBack_Click(object sender, EventArgs e)
        {
            int commentId = int.Parse(Request.Params["commentId"]);
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
                    Response.Redirect("~/Comments.aspx?forumId=" + forumId);
                }
                catch(Exception ex)
                {
                   
                }
            }
        }
}
