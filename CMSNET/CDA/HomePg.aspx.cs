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

namespace CMSNET.CDA
{
	public class HomePg : CMSNET.Common.AuthorizedPage
	{
        protected CMSNET.CDA.NavBar MainNavBar;
        protected CMSNET.CDA.Login ucLogin;
        protected CMSNET.CDA.Logout ucLogout;

        private void Page_Load(object sender, System.EventArgs e)
		{
            int Domain = Convert.ToInt32(Request.QueryString["Domain"]);

            // First Time in no Domain specified
            if (Domain == 0)
                Domain = 2;

            MainNavBar.Domain = Domain;

            if (!Request.IsAuthenticated)
                ucLogin.Visible = true;
            else
                ucLogout.Visible = true;
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
