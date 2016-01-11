using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Data.Sql;
using Microsoft.SqlServer.Server;

/// <summary>
/// Summary description for PostForum
/// </summary>
public class PostTitle
{
    public PostTitle()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static int insertTitle(string title)
    {
        int rowsAffected = 0;
        try
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\mydb.mdf;Integrated Security=True");
            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand("InsertTitle", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@title", SqlDbType.NVarChar).Value = title;

                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // index.LQueryResult.Text = "Database insert error: " + ex; // Database insert error
            }
        }
        catch (Exception ex)
        {
            // Database errro
        }

        return rowsAffected;
    }
}