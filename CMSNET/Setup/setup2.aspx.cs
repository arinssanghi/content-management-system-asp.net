using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using System.Xml;
using CMSNET.Common;


namespace CMSNET.Setup
{
	public class setup2 : System.Web.UI.Page
	{
        protected System.Web.UI.WebControls.Label lblErrorHeader;
        protected System.Web.UI.WebControls.ValidationSummary ValSum;
        protected System.Web.UI.WebControls.Label lblConnectError;
        protected System.Web.UI.WebControls.TextBox txtDatabase;
        protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
        protected System.Web.UI.WebControls.TextBox txtDataSource;
        protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
        protected System.Web.UI.WebControls.TextBox txtUserID;
        protected System.Web.UI.WebControls.TextBox txtPassword;
        protected System.Web.UI.WebControls.TextBox txtTimeout;
        protected System.Web.UI.WebControls.RangeValidator RangeValidator1;
        protected System.Web.UI.WebControls.Button bnDBConnect;
        protected System.Web.UI.WebControls.TextBox txtSMTP;
        protected System.Web.UI.WebControls.HyperLink HyperLink1;
    
        public void UpdateConfigWeb(String database, String datasource, String userid, 
            String password, String timeout, String smtp)
        {
            XmlReader xtr = new XmlTextReader(File.OpenRead(Server.MapPath("..\\web.config")));

            XmlDocument doc = new XmlDocument();
            doc.Load(xtr);
            xtr.Close();

            XmlElement  root  = doc.DocumentElement;
            XmlNodeList nodes = root.GetElementsByTagName("appSettings");
			
            if (nodes.Count <= 0)
            {
                // place in complete appsettings section
                XmlDocumentFragment newAppSettings = doc.CreateDocumentFragment();
                newAppSettings.InnerXml=("<!-- APPSETTINGS\n          This section sets all the custom application settings\n    -->" +
                    "<appSettings>\n" +
                    "    <add key=\"setup\" value=\"false\" />\n" +  // will be set to true later
                    "    <add key=\"database\" value=\"" + database + "\" />\n" +
                    "    <add key=\"datasource\" value=\"" + datasource + "\" />\n" +
                    "    <add key=\"userid\" value=\"" + userid + "\" />\n" +
                    "    <add key=\"password\" value=\"" + password + "\" />\n" +
                    "    <add key=\"timeout\" value=\"" + timeout + "\" />\n" +
                    "    <add key=\"smtpserver\" value=\"" + smtp + "\" />\n" +
                    "  </appSettings>");
          
                //add the new appsettings to the doc
                root.AppendChild(newAppSettings);
            }
            else
            {
                bool issetup      = false;
                bool isdatabase   = false;
                bool isdatasource = false;
                bool isuserid     = false;
                bool ispassword   = false;
                bool istimeout    = false;
                bool issmtp       = false;

                for (int i=0; i < nodes.Count; i++)
                {   
                    XmlNodeList appnodes = ((XmlElement)(nodes.Item(i))).GetElementsByTagName("add");

                    for (int j=0; j < appnodes.Count; j++)
                    {
                        // replace with new values 
                        // record to make sure none are missing 
                        XmlAttributeCollection attrColl = appnodes.Item(j).Attributes;
                        XmlAttribute tmpNode = (XmlAttribute)attrColl.GetNamedItem("key");
                        XmlAttribute tmpNodeValue = (XmlAttribute)attrColl.GetNamedItem("value");
                        if (tmpNode.Value.Equals("setup"))
                        {
                            // will be set to true later
                            tmpNodeValue.Value = "false";
                            issetup = true;
                        }
                        else if (tmpNode.Value.Equals("database"))
                        {
                            tmpNodeValue.Value = database;
                            isdatabase = true;
                        }
                        else if (tmpNode.Value.Equals("datasource"))
                        {
                            tmpNodeValue.Value = datasource;
                            isdatasource = true;
                        }
                        else if (tmpNode.Value.Equals("userid"))
                        {
                            tmpNodeValue.Value = userid;
                            isuserid = true;
                        }
                        else if (tmpNode.Value.Equals("password"))
                        {
                            tmpNodeValue.Value = password;
                            ispassword = true;
                        }
                        else if (tmpNode.Value.Equals("timeout"))
                        {
                            tmpNodeValue.Value = timeout;
                            istimeout = true;
                        }
                        else if (tmpNode.Value.Equals("smtpserver"))
                        {
                            tmpNodeValue.Value = timeout;
                            issmtp = true;
                        }
                    }

                    // if any entries are missing insert mising keys

                    XmlDocumentFragment newAppSetting = doc.CreateDocumentFragment();

                    if (!issetup)
                    {
                        // will be set to true later
                        newAppSetting.InnerXml=("\n    <add key=\"setup\" value=\"false\" />");
                        ((XmlElement)(nodes.Item(i))).AppendChild(newAppSetting);
                    }
                    if (!isdatabase)
                    {
                        newAppSetting.InnerXml=("\n    <add key=\"database\" value=\"" + database + "\" />");
                        ((XmlElement)(nodes.Item(i))).AppendChild(newAppSetting);
                    }
                    if (!isdatasource)
                    {
                        newAppSetting.InnerXml=("\n    <add key=\"datasource\" value=\"" + datasource + "\" />");
                        ((XmlElement)(nodes.Item(i))).AppendChild(newAppSetting);
                    }
                    if (!isuserid)
                    {
                        newAppSetting.InnerXml=("\n    <add key=\"userid\" value=\"" + userid + "\" />");
                        ((XmlElement)(nodes.Item(i))).AppendChild(newAppSetting);
                    }
                    if (!ispassword)
                    {
                        newAppSetting.InnerXml=("\n    <add key=\"password\" value=\"" + password + "\" />");
                        ((XmlElement)(nodes.Item(i))).AppendChild(newAppSetting);
                    }
                    if (!istimeout)
                    {
                        newAppSetting.InnerXml=("\n    <add key=\"timeout\" value=\"" + timeout + "\" />");
                        ((XmlElement)(nodes.Item(i))).AppendChild(newAppSetting);
                    }
                    if (!issmtp)
                    {
                        newAppSetting.InnerXml=("\n    <add key=\"smtpserver\" value=\"" + smtp + "\" />");
                        ((XmlElement)(nodes.Item(i))).AppendChild(newAppSetting);
                    }
                }  
            }
          
            File.Copy(Server.MapPath("..\\web.config"), Server.MapPath("..\\web.config.001"), true);
            File.Delete(Server.MapPath("..\\web.config"));
          
            StreamWriter sr = new StreamWriter(File.OpenWrite(Server.MapPath("..\\web.config")));
            doc.Save(sr);
            sr.Close();
        }

        private void Page_Load(object sender, System.EventArgs e)
		{
            if (IsPostBack)
            {
                Page.Validate();

                lblConnectError.Text = "";

                if (Page.IsValid)
                {
                    try
                    {
                        SqlConnection myConnection = new SqlConnection();

                        myConnection.ConnectionString =
                            "server=" + txtDataSource.Text +
                            ";database=" + txtDatabase.Text +
                            ";uid=" + txtUserID.Text +
                            ";pwd=" + txtPassword.Text +
                            ((txtTimeout.Text.Length > 0) ? 
                            ";Connection Timeout=" + txtTimeout.Text :
                            "");

                        SqlDataAdapter myCommand = new SqlDataAdapter("select * from Account", myConnection);

                        // Can we get to the database?
                        DataSet ds = new DataSet();
                        myCommand.Fill(ds, "Account");

                        UpdateConfigWeb(txtDatabase.Text, txtDataSource.Text, txtUserID.Text,
                            txtPassword.Text, txtTimeout.Text, txtSMTP.Text);

                        Response.Redirect("setup3.aspx");
                        return;
                    }
                    catch (Exception err)
                    {
                        lblConnectError.Text = err.Message;
                    }
                }
                lblErrorHeader.Text = "Sorry, cannot connect to your database the following errors occured:";
            }
            else
            {
                AppEnv appEnv = new AppEnv(Context);

                txtDatabase.Text   = appEnv.GetAppSetting("database");
                if (txtDatabase.Text.Length <= 0)
                {
                    txtDatabase.Text = "CMSNET";
                }
                txtDataSource.Text = appEnv.GetAppSetting("datasource");
                txtUserID.Text     = appEnv.GetAppSetting("userid");
                txtPassword.Text   = appEnv.GetAppSetting("password");
                txtTimeout.Text    = appEnv.GetAppSetting("timeout");
                txtSMTP.Text       = appEnv.GetAppSetting("smtpserver");
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
            this.Load += new System.EventHandler(this.Page_Load);

        }
		#endregion
	}
}
