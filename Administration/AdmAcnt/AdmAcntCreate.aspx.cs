using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
	/// <summary>
	/// Summary description for AdmAcntCreate.
	/// </summary>
	public class AdmAcntCreate : CMSNET.Common.AuthorizedPage
	{
        protected System.Web.UI.WebControls.ValidationSummary ValSum;
        protected System.Web.UI.WebControls.Label lblError;
        protected System.Web.UI.WebControls.TextBox tbUserName;
        protected System.Web.UI.WebControls.TextBox tbUserID;
        protected System.Web.UI.WebControls.RequiredFieldValidator rfvUserID;
        protected System.Web.UI.WebControls.TextBox tbEmail;
        protected System.Web.UI.WebControls.RequiredFieldValidator rfvEmail;
        protected System.Web.UI.WebControls.RegularExpressionValidator revEmail;
        protected System.Web.UI.WebControls.TextBox tbPassword;
        protected System.Web.UI.WebControls.RequiredFieldValidator rfvPassword;
        protected System.Web.UI.WebControls.TextBox tbConfirm;
        protected System.Web.UI.WebControls.RequiredFieldValidator rfvConfirm;
        protected System.Web.UI.WebControls.CompareValidator cvConfirm;
        protected System.Web.UI.WebControls.ListBox lbRoles;
        protected System.Web.UI.WebControls.Button bnCreate;
    
        protected Account         account;
        protected AccountProperty property;
        protected AccountRoles    accountRoles;

        private void ProcessUserName(int AccountID) 
        {
            if (tbUserName.Text.Length > 0)
            {
                property.Insert(AccountID, "UserName", tbUserName.Text);
            }
        }

        private void ProcessAccountRoles(int AccountID) 
        {
            for (int i = 0; i < lbRoles.Items.Count; i++)
            {
                if (lbRoles.Items[i].Selected)
                {
                    accountRoles.Insert(AccountID, lbRoles.Items[i].Text);
                }
            }
        }
        
        private void Page_Load(object sender, System.EventArgs e)
		{
            if (!IsPostBack)
            {
                string Cmd = "Select * FROM Roles";
                SqlDataAdapter DAdpt = new SqlDataAdapter(Cmd, appEnv.GetConnection());

                DataSet ds = new DataSet();
                DAdpt.Fill(ds, "Roles");
                
                DataTable dt = ds.Tables["Roles"];

                foreach (DataRow dr in dt.Rows)
                {
                    lbRoles.Items.Add(dr["Role"].ToString());
                }
            }
            else
            {
                account  = new Account(appEnv.GetConnection());
                property = new AccountProperty(appEnv.GetConnection());
                accountRoles = new AccountRoles(appEnv.GetConnection());

                Page.Validate();

                if (Page.IsValid)
                {
                    try
                    {
                        if (account.GetAccountID(tbUserID.Text) > 0)
                            lblError.Text = "UserID already in use";
                    }
                    catch (Exception)
                    {
                        try
                        {
                            account.Insert(tbUserID.Text, tbPassword.Text, tbEmail.Text);
                            int AccountID = account.GetAccountID(tbUserID.Text);
                            ProcessUserName(AccountID);
                            ProcessAccountRoles(AccountID);
                        }
                        catch (Exception err)
                        {
                            Page_Error("The following error occurred " + err.Message);
                        }

                        Response.Redirect("AdmAcntList.aspx");
                    }
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
