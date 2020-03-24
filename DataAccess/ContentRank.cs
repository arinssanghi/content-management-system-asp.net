using System;
using System.Data;
using System.Data.SqlClient;

namespace CMSNET.DataAccess
{
	/// <summary>
	/// Summary description for ContentRank.
	/// </summary>
	public class ContentRank
	{
        private SqlConnection m_Connection;

        public ContentRank(SqlConnection Connection)
        {
            m_Connection = Connection;
        }

        public DataTable GetRanks()
        {
            // Select   rank
            // FROM     ContentRanks

            SqlCommand Command = new SqlCommand("ContentRank_GetRanks", m_Connection);
            Command.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter DAdpt = new SqlDataAdapter(Command);

            DataSet ds = new DataSet();
            DAdpt.Fill(ds, "ContentRank");

            return ds.Tables["ContentRank"];

        }

        public int GetRankID(string rank)
        {
            // Select RankID
            // FROM   ContentRanks
            // WHERE  Rank=@rank

            SqlCommand Command = new SqlCommand("ContentRank_GetRankID", m_Connection);
            Command.CommandType = CommandType.StoredProcedure;

            Command.Parameters.Add(new SqlParameter("@rank", SqlDbType.Char, 10));
            Command.Parameters["@rank"].Value = rank;

            SqlDataAdapter DAdpt = new SqlDataAdapter(Command);

            DataSet ds = new DataSet();
            DAdpt.Fill(ds, "ContentRank");

            if (ds.Tables[0].Rows.Count <= 0)
                return -1;
            else
                return Convert.ToInt32(ds.Tables[0].Rows[0]["RankID"]);

        }
    }
}
