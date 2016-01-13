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


public partial class SignUp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {
        Roles.AddUserToRole(CreateUserWizard1.UserName, "User");
        Session.Add("username", CreateUserWizard1.UserName);
    }

    protected void CreateUserWizard1_FinishButtonClick(object sender, WizardNavigationEventArgs e)
    {
        try
        {
            //Profile.FirstName = TBFirstName.Text;
            //Profile.LastName = TBLastName.Text;
            //Profile.Age = int.Parse(TBAge.Text);
            //Profile.Gender = int.Parse(RBLGender.SelectedValue);
        }
        catch (Exception ex)
        {

        }
    }

    protected void CreateUserWizard1_ContinueButtonClick(object sender, EventArgs e)
    {
        Response.Redirect("Index.aspx");
    }

    protected void ContinueButton_Click(object sender, EventArgs e)
    {
        string firstname = TBFirstName.Text;
        string lastname = TBLastName.Text;
        int age = int.Parse(TBAge.Text);
        string gender = RBLGender.SelectedValue;
        string username = Session["username"].ToString();

        Guid userId = GetUserNameId(username);

        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\mydb.mdf;Integrated Security=True");

        //
        string queryString = "INSERT INTO UserDetails (userId, firstname, lastname, age, gender) VALUES (@userId, @FirstName, @LastName, @Age, @gender)";

        try
        {
            var command = new SqlCommand(queryString, connection);
            command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = firstname;
            command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = lastname;
            command.Parameters.Add("@Age", SqlDbType.Int).Value = age;
            command.Parameters.Add("@gender", SqlDbType.NVarChar).Value = gender;
            command.Parameters.Add("@userId", SqlDbType.UniqueIdentifier).Value = userId;

            connection.Open();

            int RowsAffected = command.ExecuteNonQuery();
            if (RowsAffected == 0)
            {
                // THis should not happen
                //LResult.Text = "Error: Profile was not updated. ";
            }
            else
            {
                //LResult.Text = "Profile updated successfully !";
            }
        }
        catch (Exception ex)
        {
            //LResult.Text = "DataBase error: " + ex.ToString();
            connection.Close();
        }

        connection.Close();
    }

    protected Guid GetUserNameId(string username)
    {
        string queryString = "SELECT UserId FROM Users WHERE UserName = @username";

        System.Data.SqlClient.SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\mydb.mdf;Integrated Security=True");

        string[] allRecords;

        using (var command = new SqlCommand(queryString, connection))
        {
            command.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
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

        connection.Close();

        if (allRecords.Count() == 1)
        {
            return Guid.Parse(allRecords[0]);
        }
        else
        {
            return Guid.Parse("");
        }
    }
}