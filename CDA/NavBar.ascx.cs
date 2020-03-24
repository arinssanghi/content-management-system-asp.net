using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using CMSNET.Common;
using CMSNET.DataAccess;

namespace CMSNET.CDA
{
	public abstract class NavBar : System.Web.UI.UserControl
	{
        protected System.Web.UI.WebControls.Table tblNavBar;

        private int m_domain;

        public int Domain
        {
            get
            {
                return m_domain;
            }
            set
            {
                m_domain = value;
            }
        }

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
            LiteralControl lit;

            foreach (DataRow dr in dt.Rows)
            {
                TableRow row = new TableRow();
                tblNavBar.Rows.Add(row);

                cell = new TableCell();

                if (m_domain != Convert.ToInt32(dr["DomainID"]))
                {
                    link = new HyperLink();
                    link.Text = dr["Title"].ToString();
                    link.NavigateUrl = buildDirectory(dr) +
                        dr["DomainType"].ToString().Trim() + 
                        ".aspx?Domain=" + dr["DomainID"];

                    cell.Controls.Add(link);
                }
                else
                {
                    lit = new LiteralControl(dr["Title"].ToString());
                    
                    cell.Controls.Add(lit);
                }
                row.Cells.Add(cell);
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
