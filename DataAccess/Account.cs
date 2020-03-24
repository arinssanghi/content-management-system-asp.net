using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;

namespace CMSNET.DataAccess
{
    /// <summary>
    ///    Summary description for Account.
    /// </summary>
    public class Account
    {
		private SqlConnection m_Connection;
        private string        m_ErrorMsg;

        public Account(SqlConnection Connection)
        {
            m_Connection = Connection;
        }

		public void Insert(string UserName, string Password, string Email)
		{
	        // INSERT INTO Account (UserName, Password, Email, 
            //                      ModifiedDate, CreationDate) 
	        // VALUES (@UserName, @Password, @Email, @ModifiedDate, @CreationDate)

			SqlCommand Command = new SqlCommand("Account_Insert", m_Connection);
			Command.CommandType  = CommandType.StoredProcedure;
			
			Command.Parameters.Add(new SqlParameter("@UserName",     SqlDbType.Char, 32));
			Command.Parameters.Add(new SqlParameter("@Password",     SqlDbType.Char, 40));
			Command.Parameters.Add(new SqlParameter("@Email",        SqlDbType.Char, 64));
			Command.Parameters.Add(new SqlParameter("@ModifiedDate", SqlDbType.DateTime));
			Command.Parameters.Add(new SqlParameter("@CreationDate", SqlDbType.DateTime));
			
            Command.Parameters["@UserName"].Value     = UserName;
            if (Password.Length == 40)
            {
                Command.Parameters["@Password"].Value = Password;
            }
            else
            {
                Command.Parameters["@Password"].Value = 
                    FormsAuthentication.HashPasswordForStoringInConfigFile
                    (Password, "SHA1");
            }
            Command.Parameters["@Email"].Value        = Email;
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

		public void Update(int AccountID, string UserName, string Password, string Email)
		{
            //	UPDATE Account
	        //     SET UserName     = @UserName,
	        //         Password     = @Password,
	        //         Email        = @Email,
	        //         ModifiedDate = @ModifiedDate
	        //  WHERE AccountID = @AccountID

			SqlCommand Command = new SqlCommand("Account_Update", m_Connection);
			Command.CommandType  = CommandType.StoredProcedure;
            
			Command.Parameters.Add(new SqlParameter("@AccountID",    SqlDbType.Int));
            Command.Parameters.Add(new SqlParameter("@UserName",     SqlDbType.Char, 32));
            Command.Parameters.Add(new SqlParameter("@Password",     SqlDbType.Char, 40));
			Command.Parameters.Add(new SqlParameter("@Email",        SqlDbType.Char, 64));
			Command.Parameters.Add(new SqlParameter("@ModifiedDate", SqlDbType.DateTime));

			Command.Parameters["@AccountID"].Value    = AccountID;
            Command.Parameters["@UserName"].Value     = UserName;
            if (Password.Length == 40)
            {
                Command.Parameters["@Password"].Value = Password;
            }
            else
            {
                Command.Parameters["@Password"].Value = 
                    FormsAuthentication.HashPasswordForStoringInConfigFile
                    (Password, "SHA1");
            }
            Command.Parameters["@Email"].Value        = Email;
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

        public void Remove(int AccountID)
        {
            // DELETE FROM Account 
            // WHERE AccountID=@AccountID

            SqlCommand Command = new SqlCommand("Account_Remove", m_Connection);
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
        
        public DataTable GetAccounts()
        {
            // SELECT   AccountID, UserName, Email 
            //   FROM   Account

            SqlCommand Command = new SqlCommand("Account_GetAccounts", m_Connection);
            Command.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter DAdpt = new SqlDataAdapter(Command);

            DataSet ds = new DataSet();
            DAdpt.Fill(ds, "Account");

            return ds.Tables["Account"];
        }
        
        public DataRow GetAccountForID(int AccountID)
        {
            // SELECT   AccountID, UserName, Email, Password 
            //   FROM   Account
            //  WHERE   AccountID=@AccountID

            SqlCommand Command = new SqlCommand("Account_GetAccountForID", m_Connection);
            Command.CommandType = CommandType.StoredProcedure;

            Command.Parameters.Add(new SqlParameter("@AccountID", SqlDbType.Int));
            Command.Parameters["@AccountID"].Value = AccountID;

            SqlDataAdapter DAdpt = new SqlDataAdapter(Command);

            DataSet ds = new DataSet();
            DAdpt.Fill(ds, "Account");

			if (ds.Tables["Account"].Rows.Count > 0)
                return ds.Tables["Account"].Rows[0];
			else
				return null;
        }
        
        public int GetAccountID(string UserName)
        {
            // SELECT AccountID 
            //   FROM Account 
            //  WHERE UserName=@UserName

            int retval = -1;

            SqlCommand Command = new SqlCommand("Account_GetAccountID", m_Connection);
            Command.CommandType = CommandType.StoredProcedure;

            Command.Parameters.Add(new SqlParameter("@UserName", SqlDbType.Char, 32));
            Command.Parameters["@UserName"].Value = UserName;

            try
            {
                m_Connection.Open();
                SqlDataReader dr = Command.ExecuteReader();

                if (dr.Read())
                {
                    retval = Convert.ToInt32(dr["AccountID"]);
                }
                else           
                {
                    throw new Exception("Unknown UserName");
                }
            }
            finally
            {
                m_Connection.Close();
            }

            return retval;
        }

        public bool Exist(int AccountID)
        {
            // SELECT AccountID 
            //   FROM Account 
            //  WHERE AccountID=@AccountID

            SqlCommand Command = new SqlCommand("Account_Exist", m_Connection);
            Command.CommandType = CommandType.StoredProcedure;

            Command.Parameters.Add(new SqlParameter("@AccountID", SqlDbType.Int));
            Command.Parameters["@AccountID"].Value = AccountID;

            SqlDataAdapter DAdpt = new SqlDataAdapter(Command);

            DataSet ds = new DataSet();
            DAdpt.Fill(ds, "Account");

            return (ds.Tables["Account"].Rows.Count > 0);
        }

        public string Message
        {
            get
            {
                return m_ErrorMsg;
            }
        }

        public bool Authenticated(string username, string password)
        {
            // SELECT Password 
            //   FROM Account 
            //  WHERE UserName=@username

            bool ret = false;

            SqlCommand Command = new SqlCommand("Account_Authenticated", m_Connection);
            Command.CommandType = CommandType.StoredProcedure;

            Command.Parameters.Add(new SqlParameter("@username", SqlDbType.Char, 32));
            Command.Parameters["@username"].Value = username;

            try
            {
                m_Connection.Open();
                SqlDataReader dr = Command.ExecuteReader();

                if (dr.Read())
                {
                    if(dr["Password"].ToString() == 
                        FormsAuthentication.HashPasswordForStoringInConfigFile
                        (password, "SHA1"))
                    {
                        ret = true;
                    }
                    else
                    {
                        m_ErrorMsg = "Invalid password";
                    }
                }
                else
                {
                    m_ErrorMsg = "User Name not found.";
                    ret = false;
                }
            }
            finally
            {
                m_Connection.Close();
            }

            return ret;
        }
    }
}
