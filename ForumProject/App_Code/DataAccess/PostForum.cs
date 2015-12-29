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
public class PostForum
{
	public PostForum()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static int insertForum(int titleId, string question, string posterName, DateTime datetim)
    {
        int rowsAffected = 0;
        try
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\mydb.mdf;Integrated Security=True");
            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand("InsertForum", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@titleId", SqlDbType.Int).Value = titleId;
                command.Parameters.Add("@question", SqlDbType.VarChar).Value = question;
                command.Parameters.Add("@postername", SqlDbType.VarChar).Value = posterName;
                command.Parameters.Add("@dateTim", SqlDbType.DateTime).Value = datetim;

                rowsAffected = command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                // index.LQueryResult.Text = "Database insert error: " + ex; // Database insert error
            }
        }
        catch(Exception ex)
        {
            // Database errro
        }
        
        return rowsAffected;
    }
}