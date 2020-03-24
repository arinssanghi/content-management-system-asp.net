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

namespace CMSNET.Administration.Note
{
	/// <summary>
	/// Summary description for NoteList.
	/// </summary>
	public class NoteList : CMSNET.Common.AuthorizedPage
	{
        protected System.Web.UI.WebControls.Label lbWho;
        protected System.Web.UI.WebControls.Button bnCreate;
        protected System.Web.UI.WebControls.Table tblView;
        protected System.Web.UI.WebControls.Button bnReturn;
    
        protected ContentNotes note;
        protected Account account;
		
        private string origin;
        private int cid = 0;
    
        private void BuildImageButton(TableRow row, string cArg)
        {
            ImageButton ibn = new ImageButton();

            if (cArg != null)
            {
                ibn.Command += new CommandEventHandler(this.btn_Click);
                ibn.ImageUrl = "Images/btnSelect.gif";
                ibn.CommandArgument = cArg;
            }
            else
                ibn.ImageUrl = "Images/blank.gif";

            TableCell cell = new TableCell();
            cell.Controls.Add(ibn);
            cell.HorizontalAlign = HorizontalAlign.Center;
            cell.VerticalAlign   = VerticalAlign.Middle;
            
            row.Cells.Add(cell);
        }

        private void Page_Load(object sender, System.EventArgs e)
		{
            cid = Convert.ToInt32(Request.QueryString["ContentID"]);
            origin = Request.QueryString["Origin"];

            if (cid == 0)
            {
                Page_Error("ContentID Missing");
            }

            AccountProperty property = new AccountProperty(appEnv.GetConnection());
            account = new Account(appEnv.GetConnection());
            note = new ContentNotes(appEnv.GetConnection());

            DataTable dt = note.GetNotesForID(cid);

            LiteralControl lit; 
            TableCell      cell;

            lbWho.Text = origin;
			
            foreach (DataRow dr in dt.Rows)
            {
                TableRow row = new TableRow();
                tblView.Rows.Add(row);

                lit = new LiteralControl(dr["ModifiedDate"].ToString());
                cell = new TableCell();
                cell.Font.Size = new FontUnit(FontSize.XSmall);
                cell.Controls.Add(lit);
                row.Cells.Add(cell);

                lit = new LiteralControl(property.GetValue(Convert.ToInt32(dr["Author"]), 
                    "UserName").Trim());
                cell = new TableCell();
                cell.Controls.Add(lit);
                cell.HorizontalAlign = HorizontalAlign.Center;
                row.Cells.Add(cell);

                string tmp = dr["Note"].ToString();

                if (tmp.Length > 80)
                {
                    tmp = tmp.Substring(0, 80);
                    tmp += "...";
                }

                lit = new LiteralControl(tmp);
                cell = new TableCell();
                cell.Controls.Add(lit);
                row.Cells.Add(cell);

                BuildImageButton(row, "NoteView.aspx?NoteID=" + dr["NoteID"].ToString() + "&Origin=" + origin);

                if (account.GetAccountID(User.Identity.Name) == Convert.ToInt32(dr["Author"]))
                {
                    BuildImageButton(row, "NoteUpdate.aspx?NoteID=" + dr["NoteID"].ToString() + "&Origin=" + origin);
                    BuildImageButton(row, "NoteRemove.aspx?NoteID=" + dr["NoteID"].ToString() + "&Origin=" + origin);
                }
                else
                {
                    BuildImageButton(row, null);
                    BuildImageButton(row, null);
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
            this.bnCreate.Click += new System.EventHandler(this.bnCreate_Click);
            this.bnReturn.Click += new System.EventHandler(this.bnReturn_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
		#endregion

        private void btn_Click(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            Response.Redirect(e.CommandArgument.ToString());
        }

        private void bnCreate_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("NoteCreate.aspx?ContentID=" + cid + "&Origin=" + origin);
        }

        private void bnReturn_Click(object sender, System.EventArgs e)
        {
            if (origin.Equals("Author"))
                Response.Redirect("../Aut/AutList.aspx");
            else if (origin.Equals("Editor"))
                Response.Redirect("../Edit/EdList.aspx");
            else if (origin.Equals("Approval"))
                Response.Redirect("../Approve/AppList.aspx");
            else if (origin.Equals("Deploy"))
                Response.Redirect("../Deploy/DeployList.aspx");
        }

    }
}
