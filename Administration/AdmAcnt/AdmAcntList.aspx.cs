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

using CMSNET.Common;
using CMSNET.DataAccess;

namespace CMSNET.Administration.AdmAcnt
{
	public class AdmAcntList : CMSNET.Common.AuthorizedPage
	{
        protected System.Web.UI.WebControls.Table tblView;
    
        protected Account account;
        protected AccountProperty property;
        
        private void BuildImageButton(TableRow row, string cArg)
        {
            ImageButton ibn = new ImageButton();

            ibn.Command += new CommandEventHandler(this.btn_Click);
            ibn.ImageUrl = "Images/btnSelect.gif";
            ibn.CommandArgument = cArg;

            TableCell cell = new TableCell();
            cell.Controls.Add(ibn);
            cell.HorizontalAlign = HorizontalAlign.Center;
            cell.VerticalAlign   = VerticalAlign.Middle;
            
            row.Cells.Add(cell);
        }

        private void Page_Load(object sender, System.EventArgs e)
		{
            account  = new Account(appEnv.GetConnection());
            property = new AccountProperty(appEnv.GetConnection());
 
            DataTable dt = account.GetAccounts();

            LiteralControl lit; 
            TableCell      cell;

            foreach (DataRow dr in dt.Rows)
            {
                TableRow row = new TableRow();
                tblView.Rows.Add(row);

                lit = new LiteralControl(dr["UserName"].ToString());
                cell = new TableCell();
                cell.Controls.Add(lit);
                row.Cells.Add(cell);

                lit = new LiteralControl(property.GetValue(Convert.ToInt32(dr["AccountID"]), "UserName") + "&nbsp;");
                cell = new TableCell();
                cell.Controls.Add(lit);
                row.Cells.Add(cell);

                lit = new LiteralControl(dr["Email"].ToString());
                cell = new TableCell();
                cell.Controls.Add(lit);
                row.Cells.Add(cell);

                if (dr["AccountID"].ToString().Trim().Equals("1"))
                {
                    int i = 0;

                    // is the cuurent user the administrator allow viewing and updating
                    if (dr["UserName"].ToString().Trim().Equals(User.Identity.Name.Trim()))
                    {
                        BuildImageButton(row, "AdmAcntView.aspx?AccountID=" + dr["AccountID"].ToString());
                        BuildImageButton(row, "AdmAcntUpdate.aspx?AccountID=" + dr["AccountID"].ToString());
                        i = 2;
                    }

                    // never allow delete button for administrator account
                    for ( ; i < 3; i++)
                    {
                        lit = new LiteralControl("&nbsp;");
                        cell = new TableCell();
                        cell.Controls.Add(lit);
                        row.Cells.Add(cell);
                    }
                }
                else
                {
                    BuildImageButton(row, "AdmAcntView.aspx?AccountID=" + dr["AccountID"].ToString());
                    BuildImageButton(row, "AdmAcntUpdate.aspx?AccountID=" + dr["AccountID"].ToString());
                    BuildImageButton(row, "AdmAcntRemove.aspx?AccountID=" + dr["AccountID"].ToString());
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

        private void btn_Click(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            Response.Redirect(e.CommandArgument.ToString());
        }

    }
}
