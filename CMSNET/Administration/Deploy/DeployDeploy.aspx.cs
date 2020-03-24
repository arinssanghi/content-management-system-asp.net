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
	public class DeployDeploy : CMSNET.Common.AuthorizedPage
	{
        protected System.Web.UI.WebControls.Label tbWhichHeadline;
        protected System.Web.UI.WebControls.Label tbWhichBody;
        protected System.Web.UI.WebControls.ListBox lbZones;
        protected System.Web.UI.WebControls.Button bnDeploy;
    
        private Content content;
        private Zone zone;
        private int cid = 0;
        private int ver = 0;
        private DataTable dtz;
        private DataRow drc;

        private void Page_Load(object sender, System.EventArgs e)
		{
            cid = Convert.ToInt32(Request.QueryString["ID"]);
            ver = Convert.ToInt32(Request.QueryString["Ver"]);

            if (cid == 0)
            {
                Page_Error("ContentID Missing");
            }

            if (ver == 0)
            {
                Page_Error("Version Missing");
            }

            zone = new Zone(appEnv.GetConnection());
            dtz = zone.GetAllZones();

            foreach (DataRow dr in dtz.Rows)
            {
                lbZones.Items.Add(new ListItem(dr["Title"].ToString(),
                    dr["ZoneID"].ToString()));
            }

            content = new Content(appEnv.GetConnection());
            drc = content.GetContentForIDVer(cid, ver);

            tbWhichHeadline.Text = drc["Headline"].ToString();
            tbWhichBody.Text = drc["Body"].ToString();
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
            this.bnDeploy.Click += new System.EventHandler(this.bnDeploy_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
		#endregion

        private void bnDeploy_Click(object sender, System.EventArgs e)
        {
            bool protectedZone = false;
            int zoneVal;

            Distribution dist = new Distribution(appEnv.GetConnection());
            content.SetStatus(cid, ver, StatusCodes.Deployed);

            int avgRank = new ContentRank(appEnv.GetConnection()).GetRankID("Average");

            for (int i = 0; i < lbZones.Items.Count; i++)
            {
                if (lbZones.Items[i].Selected)
                {
                    zoneVal = Convert.ToInt32(lbZones.Items[i].Value);

                    dist.Insert(cid, ver, zoneVal, avgRank);

                    if (!protectedZone)
                        protectedZone = zone.IsProtected(zoneVal);
                }
            }

            if (protectedZone)
                content.SetProtected(cid, ver, (protectedZone ? 1 : 0));

            Response.Redirect("DeployList.aspx");
        }
	}
}
