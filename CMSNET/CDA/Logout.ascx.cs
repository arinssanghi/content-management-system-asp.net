using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace CMSNET.CDA
{
	public abstract class Logout : System.Web.UI.UserControl
	{
        protected System.Web.UI.WebControls.ImageButton ibnLogout;

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
		
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.ibnLogout.Click += new System.Web.UI.ImageClickEventHandler(this.ibnLogout_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
		#endregion

        private void ibnLogout_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            FormsAuthentication.SignOut();

            string[] dirs = TemplateSourceDirectory.Split(new Char[] {(Char)0x2f});

            if (dirs[1].ToUpper().Equals("CDA")) //source dir is root
                Response.Redirect("/Default.aspx");
            else
                Response.Redirect("/" + dirs[1] + "/Default.aspx");
        }
	}
}
