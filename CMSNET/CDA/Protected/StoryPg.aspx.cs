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

namespace CMSNET.CDA.Protected
{
	public class StoryPg : CMSNET.Common.AuthorizedPage
	{
        protected System.Web.UI.WebControls.Label lbHeadline;
        protected System.Web.UI.WebControls.Label lbSource;
        protected System.Web.UI.WebControls.Label lbBy;
        protected System.Web.UI.WebControls.Label lbByline;
        protected System.Web.UI.WebControls.Label lbDashes;
        protected System.Web.UI.WebControls.Label lbDate;
        protected System.Web.UI.WebControls.Label lbTeaser;
        protected System.Web.UI.WebControls.Label lbBody;
        protected System.Web.UI.WebControls.Label lbTagline;
        protected CMSNET.CDA.Login ucLogin;
        protected CMSNET.CDA.Logout ucLogout;
        
        private void Page_Load(object sender, System.EventArgs e)
		{
            int curId  = Convert.ToInt32(Request.QueryString["ID"]);
            int curVer = Convert.ToInt32(Request.QueryString["Ver"]);

            if (!Request.IsAuthenticated)
                ucLogin.Visible = true;
            else
                ucLogout.Visible = true;

            Content content = new Content(appEnv.GetConnection());
            AccountProperty property = new AccountProperty(appEnv.GetConnection());

            DataRow dr = content.GetContentForIDVer(curId, curVer);

            if (dr != null)
            {
                lbHeadline.Text = dr["Headline"].ToString();
                lbSource.Text = dr["Source"].ToString();
                lbByline.Text = property.GetValue(Convert.ToInt32(dr["Byline"]), "UserName").Trim();
                lbDate.Text = dr["ModifiedDate"].ToString();
                lbTeaser.Text = dr["Teaser"].ToString();
                lbBody.Text = dr["Body"].ToString();
                lbTagline.Text = dr["Tagline"].ToString();
            }
            else
            {
                lbHeadline.Text = "No Stories";
                lbBy.Visible = false;
                lbDashes.Visible = false;
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
