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

public partial class ViewProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack && Request.Params["username"] != "")
        {
            string username = Request.Params["username"];
            LUsernameValue.Text = username;

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

                if (allRecords.Count() == 4)
                {
                    LFirstnameValue.Text = allRecords[0].Trim();
                    if (LFirstnameValue.Text == "Null")
                        LFirstnameValue.Text = "Not set";

                    LLastnameValue.Text = allRecords[1].Trim();
                    if(LLastnameValue.Text == "Null")
                        LLastnameValue.Text = "Not set";

                    LAgeValue.Text = allRecords[2].Trim();
                    if(LAgeValue.Text == "Null")
                        LAgeValue.Text = "Not set";

                    LGenderValue.Text = allRecords[3].Trim();
                    if (LGenderValue.Text == "Null")
                        LGenderValue.Text = "Not set";
                }
            }

            connection.Close();
        }
    }

    protected void BBack_Click(object sender, EventArgs e)
    {

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