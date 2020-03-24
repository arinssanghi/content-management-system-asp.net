using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;

namespace CMSNET.DataAccess
{
	/// <summary>
	/// Summary description for AccountRoles.
	/// </summary>
	public class AccountRoles
	{
        private SqlConnection m_Connection;
        private string        m_ErrorMsg;

        public AccountRoles(SqlConnection Connection)
        {
            m_Connection = Connection;
        }

        public void Insert(int AccountID, string Role)
        {
            // INSERT 
            //   INTO AccountRoles ( AccountID,  Role,  ModifiedDate,  CreationDate) 
            // VALUES              (@AccountID, @Role, @ModifiedDate, @CreationDate)

            SqlCommand Command = new SqlCommand("AccountRoles_Insert", m_Connection);
            Command.CommandType  = CommandType.StoredProcedure;
			
            Command.Parameters.Add(new SqlParameter("@AccountID",    SqlDbType.Int));
            Command.Parameters.Add(new SqlParameter("@Role",         SqlDbType.Char, 32));
            Command.Parameters.Add(new SqlParameter("@CreationDate", SqlDbType.DateTime));
			
            Command.Parameters["@AccountID"].Value    = AccountID;
            Command.Parameters["@Role"].Value         = Role;
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

        public void Remove(int AccountID)
        {
            // DELETE FROM AccountRoles 
            // WHERE AccountID=@AccountID

            SqlCommand Command = new SqlCommand("AccountRoles_Remove", m_Connection);
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
        
        public string Message
        {
            get
            {
                return m_ErrorMsg;
            }
        }

		public DataTable GetAllRole(string Role)
		{
			// SELECT AccountID
			//   FROM AccountRoles
			//  WHERE Role=@Role

			SqlCommand Command = new SqlCommand("AccountRoles_GetAllRole", m_Connection);
			Command.CommandType = CommandType.StoredProcedure;

			Command.Parameters.Add(new SqlParameter("@Role", SqlDbType.Char, 32));
			Command.Parameters["@Role"].Value = Role;

			SqlDataAdapter DAdpt = new SqlDataAdapter(Command);

			DataSet ds = new DataSet();
			DAdpt.Fill(ds, "AccountRoles");

			return ds.Tables["AccountRoles"];
		}

        public DataTable GetRolesForID(int AccountID)
        {
            // SELECT Role
            //   FROM AccountRoles
            //  WHERE AccountID=@AccountID

            SqlCommand Command = new SqlCommand("AccountRoles_GetRolesForID", m_Connection);
            Command.CommandType = CommandType.StoredProcedure;

            Command.Parameters.Add(new SqlParameter("@AccountID", SqlDbType.Int));
            Command.Parameters["@AccountID"].Value = AccountID;

            SqlDataAdapter DAdpt = new SqlDataAdapter(Command);

            DataSet ds = new DataSet();
            DAdpt.Fill(ds, "AccountRoles");

            return ds.Tables["AccountRoles"];
        }

        public bool Authorization(ArrayList roles, string username)
        {
            int AccountID;

            if (roles == null || roles.Count <= 0)
                return true;

            try
            {
                Account account = new Account(m_Connection);
                AccountID = account.GetAccountID(username);
            }
            catch (Exception e)
            {
                m_ErrorMsg = e.Message;
                return false;
            }

            // SELECT Role
            //   FROM AccountRoles
            //  WHERE AccountID=@AccountID

            SqlCommand Command = new SqlCommand("AccountRoles_GetRolesForID", m_Connection);
            Command.CommandType = CommandType.StoredProcedure;

            Command.Parameters.Add(new SqlParameter("@AccountID", SqlDbType.Int));
            Command.Parameters["@AccountID"].Value = AccountID;

            try
            {
                m_Connection.Open();
                SqlDataReader dr = Command.ExecuteReader();

                while (dr.Read())
                {
                    foreach ( string role in roles)
                    {
                        if (role.Trim().Equals(dr["Role"].ToString().Trim()))
                            return true;
                    }
                }
            }
            finally
            {
                m_Connection.Close();
            }

            m_ErrorMsg = "User not Authorized";
            return false;
        }
    }
}
