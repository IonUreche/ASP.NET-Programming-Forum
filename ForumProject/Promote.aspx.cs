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

public partial class PromoteToModerator : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                var rolesArray = Roles.GetRolesForUser();
                if(rolesArray.Contains("Admin") == false)
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

    protected void BPromote_Click(object sender, EventArgs e)
    {
        RadioButtonList RBL = (RadioButtonList) LoginView1.FindControl("RadioButtonList1");
        string _role = RBL.SelectedValue;

        TextBox TBUN = (TextBox)LoginView1.FindControl("TBUsername");
        string _username = TBUN.Text;
        string queryString = "SELECT UserId FROM Users WHERE UserName = @un";

        Label LResult = (Label)LoginView1.FindControl("LResult");

        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\mydb.mdf;Integrated Security=True");

        string _resultUserId;
        string[] allRecords;
        
        using (var command = new SqlCommand(queryString, connection))
        {

            command.Parameters.Add("@un", SqlDbType.NVarChar).Value = _username;
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                var list = new List<string>();
                while (reader.Read())
                    list.Add(reader.GetSqlValue(0).ToString());
                allRecords = list.ToArray();
            }
        }
        
         if(allRecords.Length == 1)
         {
             _resultUserId = allRecords[0];
         }
         else
         if(allRecords.Length > 1)
         {
             // THis should not happen
             LResult.Text = "Error: More than one users with the same name. ";
             return;
         }
         else
         {
             // THis should not happen
             LResult.Text = "No user with such name exists.";
             return;
         }

        // Once we have the ID of the user to promote, we should also find the Id of the role we have chosen to promote that user
         queryString = "SELECT RoleId FROM Roles WHERE RoleName = @rn";
         string _resultRoleId;
         string[] allRoleRecords;

         using (var command = new SqlCommand(queryString, connection))
         {

             command.Parameters.Add("@rn", SqlDbType.NVarChar).Value = _role;
             using (var reader = command.ExecuteReader())
             {
                 var list = new List<string>();
                 while (reader.Read())
                     list.Add(reader.GetSqlValue(0).ToString());
                 allRoleRecords = list.ToArray();
             }
         }

         if (allRoleRecords.Length == 1)
         {
             _resultRoleId = allRoleRecords[0];
         }
         else
        if (allRoleRecords.Length > 1)
        {
            // THis should not happen
            LResult.Text = "Error: More than one roles with the same name. ";
            return;
        }
        else
        {
            // THis should not happen
            LResult.Text = "No role with such name exists.";
            return;
        }
        // Now we should update username's roleId
         queryString = "UPDATE UsersInRoles SET RoleId = @id_role WHERE UserId = @id_user";
         try
         {
             var command = new SqlCommand(queryString, connection);
             command.Parameters.Add("@id_user", SqlDbType.NVarChar).Value = _resultUserId;
             command.Parameters.Add("@id_role", SqlDbType.NVarChar).Value = _resultRoleId;

             int RowsAffected = command.ExecuteNonQuery();
             if(RowsAffected == 0)
             {
                 // THis should not happen
                 LResult.Text = "Error: No user was updated. ";
                 return;
             }
             else
             {
                 LResult.Text = "Change applied successfully !";
                 return;
             }
         }   
         catch(Exception ex)
         {
             LResult.Text = "DataBase error: " + ex.ToString();
         }
    }
}