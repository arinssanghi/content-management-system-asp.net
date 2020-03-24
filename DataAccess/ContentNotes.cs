using System;
using System.Data;
using System.Data.SqlClient;

namespace CMSNET.DataAccess
{
	/// <summary>
	/// Summary description for ContentNotes.
	/// </summary>
	public class ContentNotes
	{
		private SqlConnection m_Connection;

		public ContentNotes(SqlConnection Connection)
		{
			m_Connection = Connection;
		}

		public void Insert(int ContentID, string Note, int Author) 
		{
			// INSERT INTO ContentNotes (ContentID, Note, Author, ModifiedDate, 
			//                           CreationDate) 
			// VALUES (@ContentID, @Note, @Author, @ModifiedDate, @CreationDate)

			SqlCommand Command = new SqlCommand("ContentNotes_Insert", m_Connection);
			Command.CommandType  = CommandType.StoredProcedure;
            
			Command.Parameters.Add(new SqlParameter("@ContentID",    SqlDbType.Int));
			Command.Parameters.Add(new SqlParameter("@Note",         SqlDbType.Text));
			Command.Parameters.Add(new SqlParameter("@Author",       SqlDbType.Int));
			Command.Parameters.Add(new SqlParameter("@ModifiedDate", SqlDbType.DateTime));
			Command.Parameters.Add(new SqlParameter("@CreationDate", SqlDbType.DateTime));

			Command.Parameters["@ContentID"].Value    = ContentID;
			Command.Parameters["@Note"].Value         = Note;
			Command.Parameters["@Author"].Value       = Author;
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

		public void Update(int NoteID, string Note)
		{
			// UPDATE ContentNotes
			// SET 
			//        Note         = @Note,
			//        ModifiedDate = @ModifiedDate
			// WHERE  NoteID = @NoteID

			SqlCommand Command = new SqlCommand("ContentNotes_Update", m_Connection);
			Command.CommandType  = CommandType.StoredProcedure;
            
			Command.Parameters.Add(new SqlParameter("@NoteID",       SqlDbType.Int));
			Command.Parameters.Add(new SqlParameter("@Note",         SqlDbType.Text));
			Command.Parameters.Add(new SqlParameter("@ModifiedDate", SqlDbType.DateTime));

			Command.Parameters["@NoteID"].Value       = NoteID;
			Command.Parameters["@Note"].Value         = Note;
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

		public int CountNotesForID(int ContentID)
		{
			// SELECT COUNT(*) 
			// FROM ContentNotes 
			// WHERE ContentID=@ContentID

			SqlCommand Command = new SqlCommand("ContentNotes_CountNotesForID", m_Connection);
			Command.CommandType = CommandType.StoredProcedure;
			Command.Parameters.Add(new SqlParameter("@ContentID", SqlDbType.Int));
			Command.Parameters["@ContentID"].Value = ContentID;

			try
			{
				m_Connection.Open();
				return (int)Command.ExecuteScalar();
			}
			finally
			{
				m_Connection.Close();
			}
		}

		public DataTable GetNotesForID(int ContentID)
		{
			// SELECT * 
			// FROM ContentNotes 
			// WHERE ContentID=@ContentID
			// ORDER BY ModifiedDate DESC

			SqlCommand Command = new SqlCommand("ContentNotes_GetNotesForID", m_Connection);
			Command.CommandType = CommandType.StoredProcedure;
			Command.Parameters.Add(new SqlParameter("@ContentID", SqlDbType.Int));
			Command.Parameters["@ContentID"].Value = ContentID;

			SqlDataAdapter DAdpt = new SqlDataAdapter(Command);

			DataSet ds = new DataSet();
			DAdpt.Fill(ds, "ContentNotes");

			return ds.Tables["ContentNotes"];
		}

		public DataRow GetNote(int NoteID)
		{
			// SELECT * 
			// FROM ContentNotes 
			// WHERE NoteID=@NoteID

			SqlCommand Command = new SqlCommand("ContentNotes_GetNote", m_Connection);
			Command.CommandType = CommandType.StoredProcedure;
			Command.Parameters.Add(new SqlParameter("@NoteID", SqlDbType.Int));
			Command.Parameters["@NoteID"].Value = NoteID;

			SqlDataAdapter DAdpt = new SqlDataAdapter(Command);

			DataSet ds = new DataSet();
			DAdpt.Fill(ds, "ContentNotes");

			if (ds.Tables["ContentNotes"].Rows.Count > 0)
				return ds.Tables["ContentNotes"].Rows[0];
			else
				return null;
		}

		public void Remove(int NoteID)
		{
			// DELETE FROM ContentNotes 
			// WHERE NoteID=@NoteID

			SqlCommand Command = new SqlCommand("ContentNotes_Remove", m_Connection);
			Command.CommandType = CommandType.StoredProcedure;

			Command.Parameters.Add(new SqlParameter("@NoteID", SqlDbType.Int));
			Command.Parameters["@NoteID"].Value = NoteID;

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
