using System;
using System.Data;
using System.Data.SqlClient;

namespace CMSNET.DataAccess
{
	/// <summary>
	/// Summary description for Zone.
	/// </summary>
	public class Zone
	{
        private SqlConnection m_Connection;

        public Zone(SqlConnection Connection)
        {
            m_Connection = Connection;
        }

        public DataTable GetAllZones()
        {
            // SELECT *
            //   FROM Zone

            SqlCommand Command = new SqlCommand("Zone_GetAllZones", m_Connection);
            Command.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter DAdpt = new SqlDataAdapter(Command);

            DataSet ds = new DataSet();
            DAdpt.Fill(ds, "Zone");

            return ds.Tables["Zone"];
        }

        public DataTable GetZonesForDomain(int domain)
        {
            // SELECT *
            //   FROM Zone
            //  WHERE DomainID=@domain

            SqlCommand Command = new SqlCommand("Zone_GetZonesForDomain", m_Connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.Add(new SqlParameter("@domain", SqlDbType.Int));
            Command.Parameters["@domain"].Value = domain;

            SqlDataAdapter DAdpt = new SqlDataAdapter(Command);

            DataSet ds = new DataSet();
            DAdpt.Fill(ds, "Zone");

            return ds.Tables["Zone"];
        }

        public DataRow GetZone(int ZoneID)
        {
            // SELECT *
            //   FROM Zone
            //  WHERE ZoneID=@ZoneID

            SqlCommand Command = new SqlCommand("Zone_GetZone", m_Connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.Add(new SqlParameter("@ZoneID", SqlDbType.Int));
            Command.Parameters["@ZoneID"].Value = ZoneID;

            SqlDataAdapter DAdpt = new SqlDataAdapter(Command);

            DataSet ds = new DataSet();
            DAdpt.Fill(ds, "Zone");

            if (ds.Tables["Zone"].Rows.Count > 0)
                return ds.Tables["Zone"].Rows[0];
            else
                return null;
        }

        public bool IsProtected(int ZoneID)
        {
            DataRow dr = GetZone(ZoneID);

            return (Convert.ToInt32(dr["Protected"]) > 0);
        }
    }
}
