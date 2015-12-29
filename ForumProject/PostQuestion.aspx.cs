using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PostQuestion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ( ! HttpContext.Current.User.Identity.IsAuthenticated)
        {
            Response.Redirect("~/index.aspx");
        }
        else
        {
            
        }
    }
    
    protected void BPostQuestion_Click(object sender, EventArgs e)
    {
        TextBox TBQuestion = (TextBox)LoginView1.FindControl("TBQuestion");
        DropDownList DDLCategories = (DropDownList)LoginView1.FindControl("DDLCategories");

        string titleId = DDLCategories.Text;
        int ctitleId = Convert.ToInt32(titleId);
        string question = TBQuestion.Text;
        string posterName = HttpContext.Current.User.Identity.Name;
        DateTime dateTime = DateTime.Now;

        Label LResult = (Label)LoginView1.FindControl("LResult");

        try
        {
            PostForum.insertForum(ctitleId, question, posterName, dateTime);
            LResult.Text = "Question Posted succesfully.";
            TBQuestion.Text = "";
        }
        catch(Exception ex)
        {
            LResult.Text = "Exception: " + ex.ToString();
        }
    }
}