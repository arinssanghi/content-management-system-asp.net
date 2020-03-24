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

namespace CMSNET
{
	/// <summary>
	/// Summary description for login.
	/// </summary>
	public class login : System.Web.UI.Page
	{
        protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
        protected System.Web.UI.WebControls.Label ErrorMsg;
        protected System.Web.UI.WebControls.TextBox tbUsername;
        protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
        protected System.Web.UI.WebControls.TextBox tbPassword;
        protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
        protected System.Web.UI.WebControls.CheckBox cbPersist;
        protected System.Web.UI.WebControls.Label lbPrompt;
        protected System.Web.UI.WebControls.Button bnRegister;
        protected System.Web.UI.WebControls.Button bnLogin;
    
        private string URL = null;

        private void Page_Load(object sender, System.EventArgs e)
		{
            URL = Request.QueryString["URL"];

            if (URL != null)
                URL.Trim();

            if (!IsPostBack)
            {
                if (FormsAuthentication.GetRedirectUrl("", false).IndexOf("admin.aspx") < 0)
                {
                    lbPrompt.Text = "<h2>Accessing Protected Content.</h2><h3>Login required.</h3>";
                    bnRegister.Visible = true;
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
            this.bnLogin.Click += new System.EventHandler(this.bnLogin_Click);
            this.bnRegister.Click += new System.EventHandler(this.bnRegister_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
		#endregion

        private void bnRegister_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("CDA/Register.aspx");
        }

        private void bnLogin_Click(object sender, System.EventArgs e)
        {
            if (Page.IsValid)
            {
                Account account = new Account(new AppEnv(Context).GetConnection());
				
                if (account.Authenticated(tbUsername.Text, tbPassword.Text))
                {
                    if (URL != null && URL.Length > 0)
                    {
                        FormsAuthentication.SetAuthCookie(tbUsername.Text, cbPersist.Checked);
                        Response.Redirect(URL);
                    }
                    else
                        FormsAuthentication.RedirectFromLoginPage(tbUsername.Text, cbPersist.Checked);
                }
                else
                    ErrorMsg.Text = account.Message;
            }
        }
	}
}
