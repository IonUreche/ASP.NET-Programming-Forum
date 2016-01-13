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

public partial class EditProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack && Page.User.Identity.Name != "")
        {
            Label LUsername = (Label)LoginView1.FindControl("LUsernameValue");
            string username = Page.User.Identity.Name;

            LUsername.Text = username;

            Guid userId = GetUserNameId(username);

            System.Data.SqlClient.SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\mydb.mdf;Integrated Security=True");

            if (userId.ToString() != "")
            {
                string queryString = "SELECT firstname, lastname, age, gender FROM UserDetails WHERE userId = @userId";
                string[] allRecords;

                using (var command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.Add("@userId", SqlDbType.UniqueIdentifier).Value = userId;
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        var list = new List<string>();
                        while (reader.Read())
                        {
                            list.Add(reader.GetSqlValue(0).ToString());
                            list.Add(reader.GetSqlValue(1).ToString());
                            list.Add(reader.GetSqlValue(2).ToString());
                            list.Add(reader.GetSqlValue(3).ToString());
                        }

                        allRecords = list.ToArray();
                    }
                }

                if(allRecords.Count() == 4)
                {
                    TextBox TBfirstname = (TextBox)LoginView1.FindControl("TBFirstname");
                    TBfirstname.Text = allRecords[0].Trim();
                    if (TBfirstname.Text == "Null") TBfirstname.Text = "";

                    TextBox TBlastname = (TextBox)LoginView1.FindControl("TBlastname");
                    TBlastname.Text = allRecords[1].Trim();
                    if (TBlastname.Text == "Null") TBlastname.Text = "";

                    TextBox TBAge = (TextBox)LoginView1.FindControl("TBAge");
                    TBAge.Text = allRecords[2].Trim();
                    if (TBAge.Text == "Null") TBAge.Text = "";

                    RadioButtonList TBgender = (RadioButtonList)LoginView1.FindControl("RadioButtonList1");
                    if (allRecords[3].Trim() == "Female")
                        TBgender.SelectedIndex = 1;
                    else
                        TBgender.SelectedIndex = 0;
                }
            }

            connection.Close();
        }
    }

    protected void BFinish_Click(object sender, EventArgs e)
    {
        Guid userId = GetUserNameId(Page.User.Identity.Name);

        TextBox TBfirstname = (TextBox)LoginView1.FindControl("TBFirstname");
        string FirstName = TBfirstname.Text.Trim();

        TextBox TBlastname = (TextBox)LoginView1.FindControl("TBlastname");
        string LastName = TBlastname.Text.Trim();

        TextBox TBAge = (TextBox)LoginView1.FindControl("TBAge");
        int Age = int.Parse(TBAge.Text.Trim());
        
        RadioButtonList TBgender = (RadioButtonList)LoginView1.FindControl("RadioButtonList1");
        string gender = "";
        gender = TBgender.SelectedValue.Trim();

        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\mydb.mdf;Integrated Security=True");
             
        //
        string queryString = "UPDATE UserDetails SET firstname = @FirstName, lastname = @LastName, age = @Age, gender = @gender WHERE userId = @userId";

        Label LResult = (Label)LoginView1.FindControl("LResult");

        try
        {
            var command = new SqlCommand(queryString, connection);
            command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = FirstName;
            command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = LastName;
            command.Parameters.Add("@Age", SqlDbType.Int).Value = Age;
            command.Parameters.Add("@gender", SqlDbType.NVarChar).Value = gender;
            command.Parameters.Add("@userId", SqlDbType.UniqueIdentifier).Value = userId;

            connection.Open();

            int RowsAffected = command.ExecuteNonQuery();
            if (RowsAffected == 0)
            {
                // THis should not happen
                LResult.Text = "Error: Profile was not updated. ";
            }
            else
            {
                LResult.Text = "Profile updated successfully !";
            }
        }
        catch (Exception ex)
        {
            LResult.Text = "DataBase error: " + ex.ToString();
            connection.Close();
        }

        connection.Close();

    }

    protected Guid GetUserNameId(string username)
    {
            string queryString = "SELECT UserId FROM Users WHERE UserName = @username";

            Label LResult = (Label)LoginView1.FindControl("LResult");

            LResult.Text = "";

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