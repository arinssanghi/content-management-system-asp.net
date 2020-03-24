using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace CMSNET.CDA
{
	public abstract class Header : System.Web.UI.UserControl
	{
        protected System.Web.UI.WebControls.Image imgHeader;

        private string level;

        public string Level
        {
            get
            {
                return level;
            }
            set 
            {
                level = value;
            }
        }

        private void Page_Load(object sender, System.EventArgs e)
		{
            imgHeader.ImageUrl = "Images/" + level + ".jpg";
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
            this.Load += new System.EventHandler(this.Page_Load);

        }
		#endregion
	}
}
