using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Xml;

namespace CMSNET.Setup
{
	/// <summary>
	/// Summary description for setup4.
	/// </summary>
	public class setup4 : System.Web.UI.Page
	{
        protected System.Web.UI.WebControls.Button btnLogin;
        protected System.Web.UI.WebControls.HyperLink HyperLink1;
    
		private void Page_Load(object sender, System.EventArgs e)
		{
            if (!IsPostBack)
            {
                XmlReader xtr = new XmlTextReader(File.OpenRead(Server.MapPath("..\\web.config")));

                XmlDocument doc = new XmlDocument();
                doc.Load(xtr);
                xtr.Close();

                XmlNodeList nodes = doc.DocumentElement.GetElementsByTagName("appSettings");

                for (int i = 0; i < nodes.Count; i++)
                {   
                    XmlNodeList appnodes = ((XmlElement)(nodes.Item(i))).GetElementsByTagName("add");

                    for (int j = 0; j < appnodes.Count; j++)
                    {
                        XmlAttributeCollection attrColl = appnodes.Item(j).Attributes;
                        XmlAttribute tmpNode = (XmlAttribute)attrColl.GetNamedItem("key");
                        if (tmpNode.Value.Equals("setup"))
                        {
                            ((XmlAttribute)attrColl.GetNamedItem("value")).Value = "true";
                        }
                    }
                }

                File.Copy(Server.MapPath("..\\web.config"), Server.MapPath("..\\web.config.002"), true);
                File.Delete(Server.MapPath("..\\web.config"));
          
                StreamWriter sr = new StreamWriter(File.OpenWrite(Server.MapPath("..\\web.config")));
                doc.Save(sr);
                sr.Close();
            }
        }

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

        private void btnLogin_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("../admin.aspx");
        }
	}
}
