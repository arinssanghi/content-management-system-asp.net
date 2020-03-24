using System;
using System.IO;
using System.Collections;
using System.Web;
using System.Xml;

using CMSNET.Common;
using CMSNET.DataAccess;

namespace CMSNET.Common
{
	/// <summary>
	/// Summary description for PageEx.
	/// </summary>
	public class AuthorizedPage : System.Web.UI.Page
	{
        private AppEnv m_appenv;

		public AuthorizedPage()
		{
            m_appenv = new AppEnv(Context);

        }

        public AppEnv appEnv
        {
            get
            {
                return m_appenv;
            }
        }
    
        public ArrayList Roles()
        {
            ArrayList rolelist = new ArrayList();

            XmlReader xtr =  null;
            XmlDocument doc;

            try
            {
                xtr = new XmlTextReader(File.OpenRead(Server.MapPath("web.config")));
                doc = new XmlDocument();
                doc.Load(xtr);
            }
            catch (IOException)
            {
                return rolelist;
            }
            finally
            {
                if (xtr != null)
                    xtr.Close();
            }

            XmlElement root = doc.DocumentElement;
            XmlNodeList nodes = root.GetElementsByTagName("authorization");

            if (nodes.Count > 0)
            {
                for (int i = 0; i < nodes.Count; i++)
                {
                    XmlNodeList allowNodes =
                        ((XmlElement)(nodes.Item(i))).GetElementsByTagName("allow");

                    for (int j = 0; j < allowNodes.Count; j++)
                    {
                        XmlAttributeCollection roleColl = allowNodes.Item(j).Attributes;
                        XmlAttribute role = (XmlAttribute)roleColl.GetNamedItem("roles");
                        string[] temp = role.Value.Split(',');
                        for (int k = 0; k < temp.Length; k++)
                            rolelist.Add(temp[k]);
                    }
                }
            }

            return rolelist;
        }

        override protected void OnInit(EventArgs e)
        {
            base.OnInit(e);

            AccountRoles accountRoles = new AccountRoles(appEnv.GetConnection());
            if (!accountRoles.Authorization(Roles(), User.Identity.Name))
            {
                Page_Error(accountRoles.Message);
            }
        }

        public void Page_Error(string error)
        {
            // Simple code to find root directory where CMS.NET resides
            // Only supports 0 or 1 deep root directory
            string[] dirs = TemplateSourceDirectory.Split(new Char[] {(Char)0x2f});

            if (dirs[1].Equals("Administration")) // source dir is root
                Response.Redirect( "/Error.aspx?errmsg=" + HttpUtility.UrlEncode(error));
            else if (dirs[1].Equals("CDA")) //source dir is root
                Response.Redirect( "/Error.aspx?errmsg=" + HttpUtility.UrlEncode(error));
            else
                Response.Redirect( "/" + dirs[1] + "/Error.aspx?errmsg=" + 
                    HttpUtility.UrlEncode(error));
        }
    }
}
