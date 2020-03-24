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
	public class ContentPg : CMSNET.Common.AuthorizedPage
	{
        protected System.Web.UI.WebControls.Label lbDomain;
        protected System.Web.UI.WebControls.Table tblDomHeadlines;
    
        protected System.Web.UI.WebControls.TableCell tcLeft;
        protected System.Web.UI.WebControls.TableCell tcRight;

        protected CMSNET.CDA.NavBar MainNavBar;
        protected CMSNET.CDA.Login ucLogin;
        protected CMSNET.CDA.Logout ucLogout;

        private void Page_Load(object sender, System.EventArgs e)
		{
            int curDomain = Convert.ToInt32(Request.QueryString["Domain"]);

            if (curDomain == 0)
                Page_Error("No domain specified");

            MainNavBar.Domain = curDomain;

            if (!Request.IsAuthenticated)
                ucLogin.Visible = true;
            else
                ucLogout.Visible = true;

            Domain domain = new Domain(appEnv.GetConnection());
            DataTable dt = domain.GetDomainForID(curDomain);
            lbDomain.Text = dt.Rows[0]["Title"].ToString();

            Zone zone = new Zone(appEnv.GetConnection());
            dt = zone.GetZonesForDomain(curDomain);

            Distribution dist = new Distribution(appEnv.GetConnection());

            int i;
            HyperLink link;
            for (i = 0; i < (int)Math.Ceiling((float)(dt.Rows.Count) / 2.0); i++)
            {
                link = new HyperLink();
                link.Text = dt.Rows[i]["Title"].ToString();
                link.NavigateUrl = "ZonePg.aspx?zone=" + dt.Rows[i]["ZoneID"];
                link.Font.Size = new FontUnit(FontSize.Large);
                tcLeft.Controls.Add(link);

                DataTable dtd = dist.GetOrdered(Convert.ToInt32(dt.Rows[i]["ZoneID"]));
                HeadlineTeaser hlt = (HeadlineTeaser) LoadControl("../HeadlineTeaser.ascx");
                if (dtd.Rows.Count > 0)
                {
                    hlt.ContentID = Convert.ToInt32(dtd.Rows[0]["ContentID"]);
                    hlt.Version = Convert.ToInt32(dtd.Rows[0]["Version"]);
                }
                tcLeft.Controls.Add(hlt);
            }

            for ( ; i < dt.Rows.Count; i++)
            {
                link = new HyperLink();
                link.Text = dt.Rows[i]["Title"].ToString();
                link.NavigateUrl = "ZonePg.aspx?zone=" + dt.Rows[i]["ZoneID"];
                link.Font.Size = new FontUnit(FontSize.Large);
                tcRight.Controls.Add(link);

                DataTable dtd = dist.GetOrdered(Convert.ToInt32(dt.Rows[i]["ZoneID"]));
                HeadlineTeaser hlt = (HeadlineTeaser) LoadControl("../HeadlineTeaser.ascx");
                if (dtd.Rows.Count > 0)
                {
                    hlt.ContentID = Convert.ToInt32(dtd.Rows[0]["ContentID"]);
                    hlt.Version = Convert.ToInt32(dtd.Rows[0]["Version"]);
                }
                tcRight.Controls.Add(hlt);
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
