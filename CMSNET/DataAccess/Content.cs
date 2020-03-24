using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;

using CMSNET.Common;

namespace CMSNET.DataAccess
{
	/// <summary>
	/// Summary description for Content.
	/// </summary>
	public class Content
	{
        private SqlConnection m_Connection;

        public Content(SqlConnection Connection)
        {
            m_Connection = Connection;
        }

        public void Insert(string Headline, string Source, int Byline, string Teaser, string Body, 
                           string Tagline)
        {
            Insert(NextContentID(), 1, 0, Headline, Source, Byline, Teaser, Body, Tagline, 0, 0, 
				   Byline, StatusCodes.Creating);
        }

        public void Insert(int ContentID, int Version, int Protected, string Headline, string Source, int Byline, 
                           string Teaser, string Body, string Tagline, int Editor, int Approver, 
			               int UpdUserID, int Status)
        {
	        // INSERT INTO Content (ContentID, Version, Protected, Headline, Source, 
            //                      Byline, Teaser, Body, Tagline, Status, Editor, 
            //                      Approver, UpdateUserID, ModifiedDate, CreationDate) 
	        // VALUES (@ContentID, @Version, @Headline, @Proected, @Source, @Byline, 
            //         @Teaser, @Body, @Tagline, @Status, @Editor, @Approver, 
            //         @UpdateUserID, @ModifiedDate, @CreationDate)

            SqlCommand Command = new SqlCommand("Content_Insert", m_Connection);
            Command.CommandType  = CommandType.StoredProcedure;
            
            Command.Parameters.Add(new SqlParameter("@ContentID",    SqlDbType.Int));
            Command.Parameters.Add(new SqlParameter("@Version",      SqlDbType.Int));
            Command.Parameters.Add(new SqlParameter("@Protected",    SqlDbType.Int));
            Command.Parameters.Add(new SqlParameter("@Headline",     SqlDbType.Text));
            Command.Parameters.Add(new SqlParameter("@Source",       SqlDbType.Text));
            Command.Parameters.Add(new SqlParameter("@Byline",       SqlDbType.Int));
            Command.Parameters.Add(new SqlParameter("@Teaser",       SqlDbType.Text));
            Command.Parameters.Add(new SqlParameter("@Body",         SqlDbType.Text));
            Command.Parameters.Add(new SqlParameter("@Tagline",      SqlDbType.Text));
            Command.Parameters.Add(new SqlParameter("@Status",       SqlDbType.Int));
            Command.Parameters.Add(new SqlParameter("@Editor",       SqlDbType.Int));
            Command.Parameters.Add(new SqlParameter("@Approver",     SqlDbType.Int));
            Command.Parameters.Add(new SqlParameter("@UpdateUserID", SqlDbType.Int));
            Command.Parameters.Add(new SqlParameter("@ModifiedDate", SqlDbType.DateTime));
            Command.Parameters.Add(new SqlParameter("@CreationDate", SqlDbType.DateTime));

            Command.Parameters["@ContentID"].Value    = ContentID;
            Command.Parameters["@Version"].Value      = Version;
            Command.Parameters["@Protected"].Value    = Protected;
            Command.Parameters["@Headline"].Value     = Headline;
            Command.Parameters["@Source"].Value       = Source;
            Command.Parameters["@Byline"].Value       = Byline;
            Command.Parameters["@Teaser"].Value       = Teaser;
            Command.Parameters["@Body"].Value         = Body;
            Command.Parameters["@Tagline"].Value      = Tagline;
            Command.Parameters["@Status"].Value       = Status;
            Command.Parameters["@Editor"].Value       = Editor;
            Command.Parameters["@Approver"].Value     = Approver;
            Command.Parameters["@UpdateUserID"].Value = UpdUserID;
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

        public void Update(int ContentID, int Version, int Protected, string Headline, string Source,
            int Byline, string Teaser, string Body, string Tagline, int Editor,
            int Approver, int UpdUserID, int Status)
        {
            // UPDATE Content
	        // SET 
            //        Protected    = @Protected,
		    //        Headline     = @Headline,
            //        Source       = @Source,
            //        Byline       = @Byline,
            //        Teaser       = @Teaser,
		    //        Body         = @Body,
		    //        Tagline      = @Tagline,
            //        Status       = @Status,
            //        Editor       = @Editor,
            //        Approver     = @Approver,
            //        UpdateUserID = @UpdateUserID,
	        //        ModifiedDate = @ModifiedDate
	        // WHERE  ContentID = @ContentID
	        //   AND  Version = @Version

            SqlCommand Command = new SqlCommand("Content_Update", m_Connection);
            Command.CommandType  = CommandType.StoredProcedure;
            
            Command.Parameters.Add(new SqlParameter("@ContentID",    SqlDbType.Int));
            Command.Parameters.Add(new SqlParameter("@Version",      SqlDbType.Int));
            Command.Parameters.Add(new SqlParameter("@Protected",    SqlDbType.Int));
            Command.Parameters.Add(new SqlParameter("@Headline",     SqlDbType.Text));
            Command.Parameters.Add(new SqlParameter("@Source",       SqlDbType.Text));
            Command.Parameters.Add(new SqlParameter("@Byline",       SqlDbType.Int));
            Command.Parameters.Add(new SqlParameter("@Teaser",       SqlDbType.Text));
            Command.Parameters.Add(new SqlParameter("@Body",         SqlDbType.Text));
            Command.Parameters.Add(new SqlParameter("@Tagline",      SqlDbType.Text));
            Command.Parameters.Add(new SqlParameter("@Status",       SqlDbType.Int));
            Command.Parameters.Add(new SqlParameter("@Editor",       SqlDbType.Int));
            Command.Parameters.Add(new SqlParameter("@Approver",     SqlDbType.Int));
            Command.Parameters.Add(new SqlParameter("@UpdateUserID", SqlDbType.Int));
            Command.Parameters.Add(new SqlParameter("@ModifiedDate", SqlDbType.DateTime));

            Command.Parameters["@ContentID"].Value    = ContentID;
            Command.Parameters["@Version"].Value      = Version;
            Command.Parameters["@Protected"].Value    = Protected;
            Command.Parameters["@Headline"].Value     = Headline;
            Command.Parameters["@Source"].Value       = Source;
            Command.Parameters["@Byline"].Value       = Byline;
            Command.Parameters["@Teaser"].Value       = Teaser;
            Command.Parameters["@Body"].Value         = Body;
            Command.Parameters["@Tagline"].Value      = Tagline;
            Command.Parameters["@Status"].Value       = Status;
            Command.Parameters["@Editor"].Value       = Editor;
            Command.Parameters["@Approver"].Value     = Approver;
            Command.Parameters["@UpdateUserID"].Value = UpdUserID;
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

        public void SetStatus(int ContentID, int Version, int Status)
        {
            // UPDATE Content
            // SET 
            //        Status       = @Status,
            //        ModifiedDate = @ModifiedDate
            // WHERE  ContentID = @ContentID
            //   AND  Version = @Version

            SqlCommand Command = new SqlCommand("Content_SetStatus", m_Connection);
            Command.CommandType  = CommandType.StoredProcedure;
            
            Command.Parameters.Add(new SqlParameter("@ContentID",    SqlDbType.Int));
            Command.Parameters.Add(new SqlParameter("@Version",      SqlDbType.Int));
            Command.Parameters.Add(new SqlParameter("@Status",       SqlDbType.Int));
            Command.Parameters.Add(new SqlParameter("@ModifiedDate", SqlDbType.DateTime));

            Command.Parameters["@ContentID"].Value    = ContentID;
            Command.Parameters["@Version"].Value      = Version;
            Command.Parameters["@Status"].Value       = Status;
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

		public void SetEditor(int ContentID, int Version, int Editor)
		{
			// UPDATE Content
			// SET 
			//        Status       = @Status,
			//        Editor       = @Editor,
			//        ModifiedDate = @ModifiedDate
			// WHERE  ContentID = @ContentID
			//   AND  Version = @Version
			//   AND  Editor = 0

			SqlCommand Command = new SqlCommand("Content_SetEditor", m_Connection);
			Command.CommandType  = CommandType.StoredProcedure;
            
			Command.Parameters.Add(new SqlParameter("@ContentID",    SqlDbType.Int));
			Command.Parameters.Add(new SqlParameter("@Version",      SqlDbType.Int));
			Command.Parameters.Add(new SqlParameter("@Editor",       SqlDbType.Int));
			Command.Parameters.Add(new SqlParameter("@Status",       SqlDbType.Int));
			Command.Parameters.Add(new SqlParameter("@ModifiedDate", SqlDbType.DateTime));

			Command.Parameters["@ContentID"].Value    = ContentID;
			Command.Parameters["@Version"].Value      = Version;
			Command.Parameters["@Editor"].Value       = Editor;
			Command.Parameters["@Status"].Value       = StatusCodes.Editing;
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
		
		public void SetApproval(int ContentID, int Version, int Approver)
		{
			// UPDATE Content
			// SET 
			//        Status       = @Status,
			//        Approver     = @Approver,
			//        ModifiedDate = @ModifiedDate
			// WHERE  ContentID = @ContentID
			//   AND  Version = @Version

			SqlCommand Command = new SqlCommand("Content_SetApproval", m_Connection);
			Command.CommandType  = CommandType.StoredProcedure;
            
			Command.Parameters.Add(new SqlParameter("@ContentID",    SqlDbType.Int));
			Command.Parameters.Add(new SqlParameter("@Version",      SqlDbType.Int));
			Command.Parameters.Add(new SqlParameter("@Approver",     SqlDbType.Int));
			Command.Parameters.Add(new SqlParameter("@Status",       SqlDbType.Int));
			Command.Parameters.Add(new SqlParameter("@ModifiedDate", SqlDbType.DateTime));

			Command.Parameters["@ContentID"].Value    = ContentID;
			Command.Parameters["@Version"].Value      = Version;
			Command.Parameters["@Approver"].Value     = Approver;
			Command.Parameters["@Status"].Value       = StatusCodes.Approved;
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
		
        public void SetProtected(int ContentID, int Version, int isProtected)
        {
            // UPDATE Content
            // SET 
            //        Protected    = @Protected,
            //        ModifiedDate = @ModifiedDate
            // WHERE  ContentID = @ContentID
            //   AND  Version = @Version

            SqlCommand Command = new SqlCommand("Content_SetProtected", m_Connection);
            Command.CommandType  = CommandType.StoredProcedure;
            
            Command.Parameters.Add(new SqlParameter("@ContentID",    SqlDbType.Int));
            Command.Parameters.Add(new SqlParameter("@Version",      SqlDbType.Int));
            Command.Parameters.Add(new SqlParameter("@Protected",    SqlDbType.Int));
            Command.Parameters.Add(new SqlParameter("@ModifiedDate", SqlDbType.DateTime));

            Command.Parameters["@ContentID"].Value    = ContentID;
            Command.Parameters["@Version"].Value      = Version;
            Command.Parameters["@Protected"].Value    = isProtected;
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

        public int NextContentID()
        {
            // SELECT   DISTINCT ContentID 
            // FROM     Content
            // ORDER BY ContentID DESC

            SqlCommand Command = new SqlCommand("Content_NextContentID", m_Connection);
            Command.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter DAdpt = new SqlDataAdapter(Command);

            DataSet ds = new DataSet();
            DAdpt.Fill(ds, "Content");

            if (ds.Tables["Content"].Rows.Count <= 0)
                return 1;

            return Convert.ToInt32(ds.Tables["Content"].Rows[0]["ContentID"]) + 1;
        }

        public DataTable GetHeadlines()
        {
            // Select   ContentID, Version, Headline, Status 
            // FROM     Content

            SqlCommand Command = new SqlCommand("Content_GetHeadlines", m_Connection);
            Command.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter DAdpt = new SqlDataAdapter(Command);

            DataSet ds = new DataSet();
            DAdpt.Fill(ds, "Content");

            return ds.Tables["Content"];
        }

        public DataTable GetHeadlinesForAuth(int Byline)
        {
            //   SELECT ContentID, Version, Headline, Status 
            //     FROM Content
            //    WHERE Byline=@Byline 

            SqlCommand Command = new SqlCommand("Content_GetHeadlinesForAuth", m_Connection);
            Command.CommandType = CommandType.StoredProcedure;

            Command.Parameters.Add(new SqlParameter("@Byline", SqlDbType.Int));
            Command.Parameters["@Byline"].Value = Byline;

            SqlDataAdapter DAdpt = new SqlDataAdapter(Command);

            DataSet ds = new DataSet();
            DAdpt.Fill(ds, "Content");

            return ds.Tables["Content"];
        }

		public DataTable GetHeadlinesForEdit(int Editor)
		{
			//   SELECT ContentID, Version, Headline, Status 
			//     FROM Content
			//    WHERE Editor=@Editor 
			//       OR Editor=0

			SqlCommand Command = new SqlCommand("Content_GetHeadlinesForEdit", m_Connection);
			Command.CommandType = CommandType.StoredProcedure;

			Command.Parameters.Add(new SqlParameter("@Editor", SqlDbType.Int));
			Command.Parameters["@Editor"].Value = Editor;

			SqlDataAdapter DAdpt = new SqlDataAdapter(Command);

			DataSet ds = new DataSet();
			DAdpt.Fill(ds, "Content");

			return ds.Tables["Content"];
		}

		public DataTable GetHeadlinesForApprove(int Approver)
		{
			//   SELECT ContentID, Version, Headline, Status 
			//     FROM Content
			//    WHERE Approver=@Approver 
			//       OR Approver=0

			SqlCommand Command = new SqlCommand("Content_GetHeadlinesForApprove", m_Connection);
			Command.CommandType = CommandType.StoredProcedure;

			Command.Parameters.Add(new SqlParameter("@Approver", SqlDbType.Int));
			Command.Parameters["@Approver"].Value = Approver;

			SqlDataAdapter DAdpt = new SqlDataAdapter(Command);

			DataSet ds = new DataSet();
			DAdpt.Fill(ds, "Content");

			return ds.Tables["Content"];
		}

		public DataTable GetContentForID(int cid)
        {
            // SELECT * 
            // FROM Content 
            // WHERE ContentID=@cid

            SqlCommand Command = new SqlCommand("Content_GetContentForID", m_Connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.Add(new SqlParameter("@cid", SqlDbType.Int));
            Command.Parameters["@cid"].Value = cid;

            SqlDataAdapter DAdpt = new SqlDataAdapter(Command);

            DataSet ds = new DataSet();
            DAdpt.Fill(ds, "Content");

            return ds.Tables["Content"];
        }

        public DataRow GetContentForIDVer(int cid, int ver)
        {
            // SELECT * 
            // FROM Content 
            // WHERE ContentID=@cid
            //   AND Version=@ver

            SqlCommand Command = new SqlCommand("Content_GetContentForIDVer", m_Connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.Add(new SqlParameter("@cid", SqlDbType.Int));
            Command.Parameters.Add(new SqlParameter("@ver", SqlDbType.Int));
            Command.Parameters["@cid"].Value = cid;
            Command.Parameters["@ver"].Value = ver;

            SqlDataAdapter DAdpt = new SqlDataAdapter(Command);

            DataSet ds = new DataSet();
            DAdpt.Fill(ds, "Content");

            if (ds.Tables["Content"].Rows.Count > 0)
                return ds.Tables["Content"].Rows[0];
            else
                return null;
        }

        public void Remove(int cid, int ver)
        {
            // DELETE FROM Content 
            // WHERE ContentID=@cid
            //   AND Version=@ver

            SqlCommand Command = new SqlCommand("Content_Remove", m_Connection);
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
