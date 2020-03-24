using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using CMSNET.Common;
using CMSNET.DataAccess;

namespace CMSNET.CDA
{
	public abstract class Login : System.Web.UI.UserControl
	{
        protected System.Web.UI.WebControls.TextBox tbUsername;
        protected System.Web.UI.WebControls.TextBox tbPassword;
        protected System.Web.UI.WebControls.CheckBox cbPersist;
        protected System.Web.UI.WebControls.ImageButton ibnSignIn;
        protected System.Web.UI.WebControls.ImageButton ibnRegister;
        protected System.Web.UI.WebControls.Label ErrorMsg;

		private void Page_Load(object sender, System.EventArgs e)
		{
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
		
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.ibnSignIn.Click += new System.Web.UI.ImageClickEventHandler(this.ibnSignIn_Click);
            this.ibnRegister.Click += new System.Web.UI.ImageClickEventHandler(this.ibnRegister_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
		#endregion

        private void ibnSignIn_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Account account = new Account(new AppEnv(Context).GetConnection());
				
            if (account.Authenticated(tbUsername.Text, tbPassword.Text))
            {
                FormsAuthentication.SetAuthCookie(tbUsername.Text, cbPersist.Checked);
                Response.Redirect(Request.RawUrl);
            }
            else
                ErrorMsg.Text = account.Message;
        }

        private void ibnRegister_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
	}
}
