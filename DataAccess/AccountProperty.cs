using System;
using System.Data;
using System.Data.SqlClient;

namespace CMSNET.DataAccess
{
    public class AccountProperty
    {
		private SqlConnection m_Connection;
        private SqlCommand    m_InsertCommand;
        private SqlCommand    m_UpdateCommand;

        public AccountProperty(SqlConnection Connection)
        {
            m_Connection = Connection;
        }

		public void Insert(int AccountID, string Property, string Value)
		{
            //	INSERT INTO AccountProperty (AccountID, Property, Value, ModifiedDate, 
            //                               CreationDate) 
	        //  VALUES (@AccountID, @Property, @Value, @ModifiedDate, @CreationDate)
			
            SqlParameterCollection Params;

            if ( m_InsertCommand == null )
            {
				m_InsertCommand = new SqlCommand("AccountProperty_Insert", m_Connection);
				m_InsertCommand.CommandType  = CommandType.StoredProcedure;
			    Params = m_InsertCommand.Parameters;
            
				Params.Add(new SqlParameter("@AccountID",    SqlDbType.Int));
				Params.Add(new SqlParameter("@Property",     SqlDbType.Char, 32));
				Params.Add(new SqlParameter("@Value",        SqlDbType.Text));
				Params.Add(new SqlParameter("@ModifiedDate", SqlDbType.DateTime));
				Params.Add(new SqlParameter("@CreationDate", SqlDbType.DateTime));
			}

			Params = m_InsertCommand.Parameters;

			Params["@AccountID"].Value    = AccountID;
			Params["@Property"].Value     = Property;
			Params["@Value"].Value        = Value;
			Params["@ModifiedDate"].Value = DateTime.Now;
			Params["@CreationDate"].Value = DateTime.Now;
					
			try
			{
				m_Connection.Open();
				m_InsertCommand.ExecuteNonQuery();
			}
			finally
			{
				m_Connection.Close();
			}
		}

        public void Update(int AccountID, string Property, string Value)
		{
	        // UPDATE AccountProperty
	        // SET 
		    //     Value = @Value,
	        //     ModifiedDate = @ModifiedDate
	        // WHERE (AccountID = @AccountID AND Property = @Property)

			SqlParameterCollection Params;

            if ( m_UpdateCommand == null )
            {
				m_UpdateCommand = new SqlCommand("AccountProperty_Update", m_Connection);
				m_UpdateCommand.CommandType  = CommandType.StoredProcedure;
			    Params = m_UpdateCommand.Parameters;
            
				Params.Add(new SqlParameter("@AccountID",    SqlDbType.Int));
				Params.Add(new SqlParameter("@Property",     SqlDbType.Char, 32));
				Params.Add(new SqlParameter("@Value",        SqlDbType.Text));
				Params.Add(new SqlParameter("@ModifiedDate", SqlDbType.DateTime));
			}

			Params = m_UpdateCommand.Parameters;

			Params["@AccountID"].Value    = AccountID;
			Params["@Property"].Value     = Property;
			Params["@Value"].Value        = Value;
			Params["@ModifiedDate"].Value = DateTime.Now;
					
			try
			{
				m_Connection.Open();
				m_UpdateCommand.ExecuteNonQuery();
			}
			finally
			{
				m_Connection.Close();
			}
		}

        public void Remove(int AccountID)
        {
            // DELETE FROM AccountProperty 
            // WHERE AccountID=@AccountID

            SqlCommand Command = new SqlCommand("AccountProperty_Remove", m_Connection);
            Command.CommandType = CommandType.StoredProcedure;

            Command.Parameters.Add(new SqlParameter("@AccountID", SqlDbType.Int));
            Command.Parameters["@AccountID"].Value = AccountID;

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
        
        public void RemoveProperty(int AccountID, string Property)
        {
            // DELETE FROM AccountProperty 
            // WHERE AccountID=@AccountID
            //   AND Property=@Property

            SqlCommand Command = new SqlCommand("AccountProperty_RemoveProperty", m_Connection);
            Command.CommandType = CommandType.StoredProcedure;

            Command.Parameters.Add(new SqlParameter("@AccountID", SqlDbType.Int));
            Command.Parameters.Add(new SqlParameter("@Property", SqlDbType.Char, 32));

            Command.Parameters["@AccountID"].Value = AccountID;
            Command.Parameters["@Property"].Value = Property;

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
        
        public string GetValue(int AccountID, string Property)
        {
            // SELECT Value
            //   FROM AccountProperty
            //  WHERE (AccountID = @AccountID AND Property = @Property)

            SqlCommand Command = new SqlCommand("AccountProperty_GetValue", m_Connection);
            Command.CommandType  = CommandType.StoredProcedure;
            
            Command.Parameters.Add(new SqlParameter("@AccountID", SqlDbType.Int));
            Command.Parameters.Add(new SqlParameter("@Property", SqlDbType.Char, 32));

            Command.Parameters["@AccountID"].Value = AccountID;
            Command.Parameters["@Property"].Value = Property;
					
            string retval = "";

            try
            {
                m_Connection.Open();
                SqlDataReader dr = Command.ExecuteReader();

                if (dr.Read())
                {
                    retval = dr["Value"].ToString();
                }
            }
            finally
            {
                m_Connection.Close();
            }

            return retval;
        }
    }
}
