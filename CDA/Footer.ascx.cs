using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using CMSNET.Common;
using CMSNET.DataAccess;

namespace CMSNET.CDA
{
	public abstract class Footer : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		protected System.Web.UI.WebControls.HyperLink hlPrivacy;
		protected System.Web.UI.WebControls.Table tblFootMenu;

		private string buildDirectory (DataRow dr)
		{
			if (Convert.ToInt32(dr["Protected"]) == 0)
				return "";

			return "Protected/";
		}
        
		private void Page_Load(object sender, System.EventArgs e)
		{
			Domain domain = new Domain(new AppEnv(Context).GetConnection());

			DataTable dt = domain.GetAll();
			TableCell   cell;
			HyperLink   link;

			TableRow row = new TableRow();
			tblFootMenu.Rows.Add(row);

			foreach (DataRow dr in dt.Rows)
			{
				cell = new TableCell();
				link = new HyperLink();
				link.Text = dr["Title"].ToString();
				link.NavigateUrl = buildDirectory(dr) +
					dr["DomainType"].ToString().Trim() + 
					".aspx?Domain=" + dr["DomainID"];

				cell.Controls.Add(link);
				row.Cells.Add(cell);
			}
			cell = new TableCell();
			link = new HyperLink();
			link.Text = "Back";
			link.NavigateUrl = "javascript:history.go(-1);";
			cell.Controls.Add(link);
			row.Cells.Add(cell);
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
