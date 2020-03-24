using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using CMSNET.Common;
using CMSNET.DataAccess;

namespace CMSNET.Administration.Deploy
{
	public class DeployView : CMSNET.Common.AuthorizedPage
	{
        protected System.Web.UI.WebControls.Label lbContentID;
        protected System.Web.UI.WebControls.Label lbVersion;
        protected System.Web.UI.WebControls.Label lbHeadline;
        protected System.Web.UI.WebControls.Label lbSource;
        protected System.Web.UI.WebControls.Label lbByline;
        protected System.Web.UI.WebControls.Label lbTeaser;
        protected System.Web.UI.WebControls.Label lbBody;
        protected System.Web.UI.WebControls.Label lbTagline;
        protected System.Web.UI.WebControls.Label lbStatus;
        protected System.Web.UI.WebControls.Label lbUpdateUser;
        protected System.Web.UI.WebControls.Label lbModifiedDate;
        protected System.Web.UI.WebControls.Label lbCreationDate;
    
        protected DataRow dr;
        
        private void Page_Load(object sender, System.EventArgs e)
		{
            int cid = Convert.ToInt32(Request.QueryString["ID"]);
            int ver = Convert.ToInt32(Request.QueryString["Ver"]);

            if (cid == 0)
            {
                Page_Error("ContentID Missing");
            }
            if (ver == 0)
            {
                Page_Error("Version Missing");
            }
            dr = new Content(appEnv.GetConnection()).GetContentForIDVer(cid,ver);

            if (!IsPostBack)
            {
                AccountProperty property = new AccountProperty(appEnv.GetConnection());

                lbContentID.Text = dr["ContentID"].ToString();
                lbVersion.Text   = dr["Version"].ToString();
                lbHeadline.Text  = dr["Headline"].ToString();
                lbSource.Text    = dr["Source"].ToString() + "&nbsp;";
                lbByline.Text    = property.GetValue(Convert.ToInt32(dr["Byline"]), 
                    "UserName").Trim();
                lbTeaser.Text    = dr["Teaser"].ToString() + "&nbsp;";
                lbBody.Text      = dr["Body"].ToString();
                lbTagline.Text   = dr["Tagline"].ToString() + "&nbsp;";
                lbStatus.Text    = dr["Status"].ToString();
                lbUpdateUser.Text  = property.GetValue(Convert.ToInt32(dr["UpdateUserID"]), 
                    "UserName").Trim();
                lbModifiedDate.Text  = dr["ModifiedDate"].ToString();
                lbCreationDate.Text  = dr["CreationDate"].ToString();
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
