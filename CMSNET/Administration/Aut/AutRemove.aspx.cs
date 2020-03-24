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

namespace CMSNET.Administration.AUT
{
	/// <summary>
	/// Summary description for AutRemove.
	/// </summary>
	public class AutRemove : CMSNET.Common.AuthorizedPage
	{
        protected System.Web.UI.WebControls.Label lbWhichHeadline;
        protected System.Web.UI.WebControls.Label lbWhichBody;
        protected System.Web.UI.WebControls.Button bnRemove;
    
        private Content content;
        private int cid = 0;
        private DataTable dt;

        private void Page_Load(object sender, System.EventArgs e)
		{
            cid = Convert.ToInt32(Request.QueryString["ContentID"]);

            if (cid == 0)
            {
                Page_Error("ContentID Missing");
            }

            content = new Content(appEnv.GetConnection());
            dt = content.GetContentForID(cid);

            lbWhichHeadline.Text = dt.Rows[0]["Headline"].ToString();
            lbWhichBody.Text = dt.Rows[0]["Body"].ToString();
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
            this.bnRemove.Click += new System.EventHandler(this.bnRemove_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
		#endregion

        private void bnRemove_Click(object sender, System.EventArgs e)
        {
            content.Remove(Convert.ToInt32(dt.Rows[0]["ContentID"]),
                Convert.ToInt32(dt.Rows[0]["Version"]));
            
            Response.Redirect("AutList.aspx");
        }
	}
}
