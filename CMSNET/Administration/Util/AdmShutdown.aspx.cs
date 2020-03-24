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

using CMSNET.Common;

namespace CMSNET.Administration.Util
{
	public class AdmShutdown : CMSNET.Common.AuthorizedPage
	{
        protected System.Web.UI.WebControls.Label lbPrompt;
        protected System.Web.UI.WebControls.Button bnStartStop;
    
        protected string ready;
    
        private void Page_Load(object sender, System.EventArgs e)
		{
            ready = appEnv.GetAppSetting("ready");

            if (ready.Equals("true"))
            {
                lbPrompt.Text = "The site is currently up.";
                bnStartStop.Text = "Bring site down?";
            }
            else
            {
                lbPrompt.Text = "The site is currently down.";
                bnStartStop.Text = "Bring site up?";
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
            this.bnStartStop.Click += new System.EventHandler(this.bnStartStop_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
		#endregion

        private void bnStartStop_Click(object sender, System.EventArgs e)
        {
            bool isready = false; 
            XmlReader xtr = new XmlTextReader(File.OpenRead(Server.MapPath("..\\..\\web.config")));

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
                    if (tmpNode.Value.Equals("ready"))
                    {
                        if (ready.Equals("true"))
                            ((XmlAttribute)attrColl.GetNamedItem("value")).Value = "false";
                        else
                            ((XmlAttribute)attrColl.GetNamedItem("value")).Value = "true";
                        isready = true;
                    }
                }
                if (!isready)
                {
                    // if it gets here, it's the first time the site is started up
                    XmlDocumentFragment newAppSetting = doc.CreateDocumentFragment();
                    newAppSetting.InnerXml=("\n    <add key=\"ready\" value=\"true\" />\n");
                    ((XmlElement)(nodes.Item(i))).AppendChild(newAppSetting);
                }
            }

            File.Delete(Server.MapPath("..\\..\\web.config"));
        
            StreamWriter sr = new StreamWriter(File.OpenWrite(Server.MapPath("..\\..\\web.config")));
            doc.Save(sr);
            sr.Close();

            // Flip prompt
            if (ready.Equals("true"))
            {
                lbPrompt.Text = "The site is currently down.";
                bnStartStop.Text = "Bring site up?";
            }
            else
            {
                lbPrompt.Text = "The site is currently up.";
                bnStartStop.Text = "Bring site down?";
            }
        }
	}
}
