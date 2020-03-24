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

namespace CMSNET.Administration.AdmAcnt
{
	public class AdmAcntView : CMSNET.Common.AuthorizedPage
	{
        protected System.Web.UI.WebControls.Label lbUserID;
        protected System.Web.UI.WebControls.Label lbUserName;
        protected System.Web.UI.WebControls.Label lbEmail;
        protected System.Web.UI.WebControls.ListBox lbRoles;
        protected System.Web.UI.WebControls.Button bnUpdate;
        protected System.Web.UI.WebControls.Button bnRemove;
    
        private Account account;
        private AccountProperty property;
        private AccountRoles roles;
        private int aid = 0;
        private DataRow dr;

        private void Page_Load(object sender, System.EventArgs e)
		{
            aid = Convert.ToInt32(Request.QueryString["AccountID"]);

            if (aid == 0)
            {
                Page_Error("AccountID Missing");
            }

            if (aid == 1)
            {
                bnRemove.Visible = false;
            }

            account  = new Account(appEnv.GetConnection());
            property = new AccountProperty(appEnv.GetConnection());
            roles = new AccountRoles(appEnv.GetConnection());

            dr = account.GetAccountForID(aid);

            lbUserID.Text = dr["UserName"].ToString();
            lbUserName.Text = property.GetValue(aid, "UserName");
            lbEmail.Text = dr["Email"].ToString();

            DataTable roledt = roles.GetRolesForID(aid);

            foreach (DataRow drr in roledt.Rows)
            {
                lbRoles.Items.Add(drr["Role"].ToString());
            }
    
            if (roledt.Rows.Count == 0)
                lbRoles.Items.Add("User");
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
            this.bnUpdate.Click += new System.EventHandler(this.bnUpdate_Click);
            this.bnRemove.Click += new System.EventHandler(this.bnRemove_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
		#endregion

        private void bnUpdate_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("AdmAcntUpdate.aspx?AccountID=" + aid);
        }

        private void bnRemove_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("AdmAcntRemove.aspx?AccountID=" + aid);
        }
	}
}
