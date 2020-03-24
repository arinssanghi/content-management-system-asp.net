using System;
using System.Data;
using System.Data.SqlClient;

namespace CMSNET.DataAccess
{
	/// <summary>
	/// Summary description for Distribution.
	/// </summary>
	public class Distribution
	{
        private SqlConnection m_Connection;

        public Distribution(SqlConnection Connection)
        {
            m_Connection = Connection;
        }

        public void Insert(int ContentID, int Version, int ZoneID, int Ranking) 
        {
            // INSERT INTO Distribution (ContentID, Version, ZoneID, Ranking, 
            //                           ModifiedDate, CreationDate) 
            // VALUES (@ContentID, @Version, @ZoneID, @Ranking, 
            //                     @ModifiedDate, @CreationDate)

            SqlCommand Command = new SqlCommand("Distribution_Insert", m_Connection);
            Command.CommandType  = CommandType.StoredProcedure;
            
            Command.Parameters.Add(new SqlParameter("@ContentID",    SqlDbType.Int));
            Command.Parameters.Add(new SqlParameter("@Version",      SqlDbType.Int));
            Command.Parameters.Add(new SqlParameter("@ZoneID",       SqlDbType.Int));
            Command.Parameters.Add(new SqlParameter("@Ranking",      SqlDbType.Int));
            Command.Parameters.Add(new SqlParameter("@ModifiedDate", SqlDbType.DateTime));
            Command.Parameters.Add(new SqlParameter("@CreationDate", SqlDbType.DateTime));

            Command.Parameters["@ContentID"].Value    = ContentID;
            Command.Parameters["@Version"].Value      = Version;
            Command.Parameters["@ZoneID"].Value       = ZoneID;
            Command.Parameters["@Ranking"].Value      = Ranking;
            Command.Parameters["@ModifiedDate"].Value = DateTime.Now;
            Command.Parameters["@CreationDate"].Value = DateTime.Now;
					
            try
            {
                m_Connection.Open();
                Command.ExecuteNonQuery();
            }
            finally
            {
                m_Connection.Close();
            }
        }

        public DataTable GetOrdered(int zone)
        {
            //   SELECT ContentID, Version
            //     FROM Distribution
            //    WHERE ZoneID=@ZoneID
            // ORDER BY Rank DESC, ModifiedDate DESC

            SqlCommand Command = new SqlCommand("Distribution_GetOrdered", m_Connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.Add(new SqlParameter("@ZoneID", SqlDbType.Int));
            Command.Parameters["@ZoneID"].Value = zone;

            SqlDataAdapter DAdpt = new SqlDataAdapter(Command);

            DataSet ds = new DataSet();
            DAdpt.Fill(ds, "Distribution");

            return ds.Tables["Distribution"];
        }

        public void UpdateRank(int ZoneID, int ContentID, int Version, int Ranking)
        {
            // UPDATE Distribution
            // SET 
            //        Ranking      = @Ranking,
            //        ModifiedDate = @ModifiedDate
            // WHERE  ContentID = @ContentID
            //   AND  Version = @Version
            //   AND  ZoneID = @ZoneID

            SqlCommand Command = new SqlCommand("Distribution_UpdateRank", m_Connection);
            Command.CommandType  = CommandType.StoredProcedure;
            
            Command.Parameters.Add(new SqlParameter("@ContentID",    SqlDbType.Int));
            Command.Parameters.Add(new SqlParameter("@Version",      SqlDbType.Int));
            Command.Parameters.Add(new SqlParameter("@ZoneID",       SqlDbType.Int));
            Command.Parameters.Add(new SqlParameter("@Ranking",      SqlDbType.Int));
            Command.Parameters.Add(new SqlParameter("@ModifiedDate", SqlDbType.DateTime));

            Command.Parameters["@ContentID"].Value    = ContentID;
            Command.Parameters["@Version"].Value      = Version;
            Command.Parameters["@ZoneID"].Value       = ZoneID;
            Command.Parameters["@Ranking"].Value      = Ranking;
            Command.Parameters["@ModifiedDate"].Value = DateTime.Now;
					
            try
            {
                m_Connection.Open();
                Command.ExecuteNonQuery();
            }
            finally
            {
                m_Connection.Close();
            }
        }

        public void Remove(int cid, int ver)
        {
            // DELETE FROM Distribution 
            // WHERE ContentID=@cid
            //   AND Version=@ver

            SqlCommand Command = new SqlCommand("Distribution_Remove", m_Connection);
            Command.CommandType = CommandType.StoredProcedure;

            Command.Parameters.Add(new SqlParameter("@cid", SqlDbType.Int));
            Command.Parameters.Add(new SqlParameter("@ver", SqlDbType.Int));
            Command.Parameters["@cid"].Value = cid;
            Command.Parameters["@ver"].Value = ver;

            try
            {
                m_Connection.Open();
                Command.ExecuteNonQuery();
            }
            finally
            {
                m_Connection.Close();
            }
        }
    }
}
