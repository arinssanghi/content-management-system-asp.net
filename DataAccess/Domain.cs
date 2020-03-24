using System;
using System.Data;
using System.Data.SqlClient;

namespace CMSNET.DataAccess
{
	/// <summary>
	/// Summary description for Domain.
	/// </summary>
	public class Domain
	{
        private SqlConnection m_Connection;

        public Domain(SqlConnection Connection)
        {
            m_Connection = Connection;
        }

        public DataTable GetAll()
        {
            // Select   * 
            // FROM     Domain

            SqlCommand Command = new SqlCommand("Domain_GetAll", m_Connection);
            Command.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter DAdpt = new SqlDataAdapter(Command);

            DataSet ds = new DataSet();
            DAdpt.Fill(ds, "Domain");

            return ds.Tables["Domain"];
        }

        public DataTable GetDomainForID(int did)
        {
            // SELECT   * 
            // FROM     Domain
            //  WHERE   DomainID=@did

            SqlCommand Command = new SqlCommand("Domain_GetDomainForID", m_Connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.Add(new SqlParameter("@did", SqlDbType.Int));
            Command.Parameters["@did"].Value = did;

            SqlDataAdapter DAdpt = new SqlDataAdapter(Command);

            DataSet ds = new DataSet();
            DAdpt.Fill(ds, "Domain");

            return ds.Tables["Domain"];
        }
    }
}
