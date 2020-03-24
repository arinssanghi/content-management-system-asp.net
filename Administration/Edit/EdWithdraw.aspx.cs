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

namespace CMSNET.Administration.Edit
{
	public class EdWithdraw : CMSNET.Common.AuthorizedPage
	{
        protected System.Web.UI.WebControls.Label lbWhichHeadline;
        protected System.Web.UI.WebControls.Label lbWhichBody;
        protected System.Web.UI.WebControls.Button bnWithdraw;
    
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
            this.bnWithdraw.Click += new System.EventHandler(this.bnWithdraw_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
		#endregion

        private void bnWithdraw_Click(object sender, System.EventArgs e)
        {
            try
            {
                int code;
                Content content = new Content(appEnv.GetConnection());
                Account account = new Account(appEnv.GetConnection());

                DataRow dr = dt.Rows[0];

                content.Insert(cid,	Convert.ToInt32(dr["Version"]) + 1, 0,
                    dr["Headline"].ToString(), dr["Source"].ToString(), 
                    Convert.ToInt32(dr["Byline"]), 
                    dr["Teaser"].ToString(), dr["Body"].ToString(), 
                    dr["TagLine"].ToString(), 0, 
                    Convert.ToInt32(dr["Approver"]), 
                    account.GetAccountID(User.Identity.Name),
                    (code = StatusCodes.AwaitingEdit));

                EmailAlert ea = new EmailAlert(Context, code, 0);
                ea.Send();
            }
            catch (Exception err)
            {
                Page_Error("The following error occured: " + err.Message);
            }
			
            Response.Redirect("EdList.aspx");
        }
	}
}
