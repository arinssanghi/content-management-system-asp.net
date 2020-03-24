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

namespace CMSNET.CDA
{
	public class ZonePg : CMSNET.Common.AuthorizedPage
	{
        protected System.Web.UI.WebControls.Label lbZone;
        protected System.Web.UI.WebControls.Table tblDomHeadlines;
        protected System.Web.UI.WebControls.TableCell tcLeft;
        protected System.Web.UI.WebControls.TableCell tcRight;
        protected CMSNET.CDA.HeadlineTeaser htLead;
        protected CMSNET.CDA.Login ucLogin;
        protected CMSNET.CDA.Logout ucLogout;
    
		private void Page_Load(object sender, System.EventArgs e)
		{
            int curZone = Convert.ToInt32(Request.QueryString["Zone"]);

            if (curZone == 0)
                Page_Error("No zone specified");

            if (!Request.IsAuthenticated)
                ucLogin.Visible = true;
            else
                ucLogout.Visible = true;

            Zone zone = new Zone(appEnv.GetConnection());
            DataRow dr = zone.GetZone(curZone);
            lbZone.Text = dr["Title"].ToString();

            if (Convert.ToInt32(dr["Protected"]) > 0)
            {
                if (!Request.IsAuthenticated)
                    Response.Redirect("../Login.aspx?URL=" + HttpUtility.UrlEncode(Request.RawUrl));
            }

            Distribution dist = new Distribution(appEnv.GetConnection());
            DataTable dtd = dist.GetOrdered(Convert.ToInt32(dr["ZoneID"]));

            if (dtd.Rows.Count > 0)
            {
                htLead.ContentID = Convert.ToInt32(dtd.Rows[0]["ContentID"]);
                htLead.Version = Convert.ToInt32(dtd.Rows[0]["Version"]);

                int i;
                for (i = 0; i < (int)Math.Ceiling((float)(dtd.Rows.Count-1) / 2.0); i++)
                {
                    HeadlineTeaser hlt = (HeadlineTeaser) LoadControl("HeadlineTeaser.ascx");
                    hlt.ContentID = Convert.ToInt32(dtd.Rows[i+1]["ContentID"]);
                    hlt.Version = Convert.ToInt32(dtd.Rows[i+1]["Version"]);
                    tcLeft.Controls.Add(hlt);
                }
                for ( ; i < dtd.Rows.Count-1; i++)
                {
                    HeadlineTeaser hlt = (HeadlineTeaser) LoadControl("HeadlineTeaser.ascx");
                    hlt.ContentID = Convert.ToInt32(dtd.Rows[i+1]["ContentID"]);
                    hlt.Version = Convert.ToInt32(dtd.Rows[i+1]["Version"]);
                    tcRight.Controls.Add(hlt);
                }
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
