using System;
using System.Collections.Specialized;
using System.Web;
using System.Data.SqlClient;

namespace CMSNET.Common
{
    public class AppEnv
    {
        HttpContext context;

        public AppEnv(HttpContext Context)
        {
            context = Context;
        }

        public string GetAppSetting (string setting)
        {
            string val;
            try
            {
                val = (string)((NameValueCollection)context.GetConfig("appSettings"))[setting];
            }
            catch (NullReferenceException)
            {
                val = "";
            }

            if (val == null)
                val = "";

            return val;
        }

        public SqlConnection GetConnection()
        {
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString ="Data Source=localhost;Initial Catalog=CMSNET2;User Id=sa";
 
                
            return myConnection;
        }
    }
}
