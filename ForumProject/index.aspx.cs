using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
    {
        Int64 ForumId = (Int64)GridView1.SelectedValue;

        Session["titleId"] = ForumId;

        Response.Redirect("Thread.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
}