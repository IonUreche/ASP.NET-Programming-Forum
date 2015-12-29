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
/// Summary description for PostComment
/// </summary>
public class PostComment
{
	public PostComment()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static int insertComment(int forumId, string answer, string posterName, DateTime datetim)
    {
        int rowsAffected = 0;
        try
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\mydb.mdf;Integrated Security=True");
            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand("InsertComment", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@forumId", SqlDbType.Int).Value = forumId;
                command.Parameters.Add("@answer", SqlDbType.VarChar).Value = answer;
                command.Parameters.Add("@postername", SqlDbType.VarChar).Value = posterName;
                command.Parameters.Add("@dateTim", SqlDbType.DateTime).Value = datetim;

                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // index.LQueryResult.Text = "Database insert error: " + ex; // Database insert error
            }
        }
        catch (Exception ex)
        {
            // Database error
        }

        return rowsAffected;
    }
}