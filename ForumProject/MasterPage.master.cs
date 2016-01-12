﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("SignUp.aspx");
    }
    protected void BPostQuestion_Click(object sender, EventArgs e)
    {
        Response.Redirect("PostQuestion.aspx");
    }
    protected void PromoteClickButton(object sender, EventArgs e)
    {
        Response.Redirect("Promote.aspx");
    }
    protected void BSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("Search.aspx?q=" + Server.UrlEncode(TBSearch.Text));
    }
}
