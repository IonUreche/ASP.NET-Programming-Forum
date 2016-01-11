using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Web.Security;

public partial class AddCategory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                var rolesArray = Roles.GetRolesForUser();
                if (rolesArray.Contains("Admin") == false)
                {
                    Response.Redirect("~/index.aspx");
                }
            }
            catch (HttpException ex)
            {
                //Msg.Text = "There is no current logged on user.";
                //return;
            }
        }
    }
    protected void BAddCategory_Click(object sender, EventArgs e)
    {
        TextBox TBCN = (TextBox)LoginView1.FindControl("TBCategoryName");
        string _categoryName = TBCN.Text;
        string queryString = "SELECT [title], [titleID] FROM [Title] WHERE title = @title_p";

        Label LResult = (Label)LoginView1.FindControl("LResult");

        if(_categoryName == "")
        {
            LResult.Text = "Empty category name is proxibited.";
            return ;
        }

        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\mydb.mdf;Integrated Security=True");

        string _resultUserId;
        string[] allRecords;

        using (var command = new SqlCommand(queryString, connection))
        {
            command.Parameters.Add("@title_p", SqlDbType.NVarChar).Value = _categoryName;
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                var list = new List<string>();
                while (reader.Read())
                    list.Add(reader.GetSqlValue(0).ToString());
                allRecords = list.ToArray();
            }
        }

        if (allRecords.Length == 1)
        {
            // Error: User category with such name already exists !
            LResult.Text = "Error: Category with such name already exists ! ";
            return;
        }
        else
        if (allRecords.Length == 0)
        {
            // It's ok, let's add this category to the Database

            try
            {
                PostTitle.insertTitle(_categoryName);
                LResult.Text = "Category added succesfully.";
                TBCN.Text = "";
                Response.Redirect("ManageCategories.aspx");
            }
            catch (Exception ex)
            {
                LResult.Text = "Exception: " + ex.ToString();
            }
        }
        else
        if (allRecords.Length >= 1)
        {
            // THis should not happen
            LResult.Text = "ERROR: More categories with such names exists 1";
            return;
        }
    }

    protected void BDeleteCategory_Click(object sender, EventArgs e)
    {
        // A category should be selected
        DropDownList DDLN = (DropDownList) LoginView1.FindControl("DDLCategories");
        int _categoryNameId = int.Parse(DDLN.SelectedValue);
        string queryString = "DELETE FROM [Title] WHERE titleID = @title_ID";

        Label LResult = (Label)LoginView1.FindControl("LResult");
   
        try
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\mydb.mdf;Integrated Security=True");
            connection.Open();
                
            SqlCommand command = new SqlCommand(queryString, connection);
            command.Parameters.Add("@title_ID", SqlDbType.Int).Value = _categoryNameId;

            command.ExecuteNonQuery();
            LResult.Text = "Category deleted successfully !";
            Response.Redirect("ManageCategories.aspx");
        }
        catch(Exception ex)
        {
            LResult.Text = "ERROR: " + ex.ToString();
        }
        
    }
}