using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Comments : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
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
}