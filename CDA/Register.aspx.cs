using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using CMSNET.Common;
using CMSNET.DataAccess;

namespace CMSNET.CDA
{
	public class Register : CMSNET.Common.AuthorizedPage
	{
        protected System.Web.UI.WebControls.ValidationSummary ValSum;
        protected System.Web.UI.WebControls.Label lblError;
        protected System.Web.UI.WebControls.TextBox tbUserName;
        protected System.Web.UI.WebControls.RequiredFieldValidator rfvUserName;
        protected System.Web.UI.WebControls.TextBox tbEmail;
        protected System.Web.UI.WebControls.RegularExpressionValidator revEmail;
        protected System.Web.UI.WebControls.TextBox tbPassword;
        protected System.Web.UI.WebControls.RequiredFieldValidator rfvPassword;
        protected System.Web.UI.WebControls.TextBox tbConfirm;
        protected System.Web.UI.WebControls.RequiredFieldValidator rfvConfirm;
        protected System.Web.UI.WebControls.CompareValidator cvConfirm;
        protected System.Web.UI.WebControls.ImageButton ibnRegister;
        protected System.Web.UI.WebControls.ImageButton ibnCancel;
        protected System.Web.UI.WebControls.HyperLink hlPrivacy;
    
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
            this.ibnRegister.Click += new System.Web.UI.ImageClickEventHandler(this.ibnRegister_Click);
            this.ibnCancel.Click += new System.Web.UI.ImageClickEventHandler(this.ibnCancel_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
		#endregion

        private void ibnRegister_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Account account  = new Account(appEnv.GetConnection());

            if (Page.IsValid)
            {
                try
                {
                    if (account.GetAccountID(tbUserName.Text) > 0)
                        lblError.Text = "UserID already in use";
                }
                catch (Exception)
                {
                    try
                    {
                        account.Insert(tbUserName.Text, tbPassword.Text, tbEmail.Text);
                        int AccountID = account.GetAccountID(tbUserName.Text);

                        FormsAuthentication.SetAuthCookie(tbUserName.Text, false);
                    }
                    catch (Exception err)
                    {
                        Page_Error("The following error occurred " + err.Message);
                    }

                    Response.Redirect("../Default.aspx");
                }
            }
        }

        private void ibnCancel_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            this.Controls.Add(new LiteralControl("<script language=javascript>" +
                "history.go(-2);" +
                "</script>"));
        }
	}
}
