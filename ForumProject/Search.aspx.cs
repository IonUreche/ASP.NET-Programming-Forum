using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack && Request.Params["q"] != null)
        {
            string query = Server.UrlDecode(Request.Params["q"]);

            SDSSearch.SelectCommand = "SELECT title, Forum.forumId, question, Forum.postername, datetime, answer " +
                       "FROM Title INNER JOIN Forum ON Title.titleID = Forum.titleId " +
                                  "FULL JOIN Thread ON Forum.forumId = Thread.forumId " +
                       "WHERE question LIKE @q OR answer LIKE @q";

            SDSSearch.SelectParameters.Clear();
            SDSSearch.SelectParameters.Add("q", "%" + query + "%");
            SDSSearch.DataBind();
        }
    }
}