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

namespace CMSNET.Setup
{
	public class setup : System.Web.UI.Page
	{
        protected System.Web.UI.WebControls.Button bnContinue;
        protected System.Web.UI.WebControls.HyperLink HyperLink2;
    
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
            this.bnContinue.Click += new System.EventHandler(this.bnContinue_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
		#endregion

        private void bnContinue_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("setup2.aspx");
        }
	}
}
