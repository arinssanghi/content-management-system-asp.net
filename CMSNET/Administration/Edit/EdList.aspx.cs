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

namespace CMSNET.Administration.Edit
{
	/// <summary>
	/// Summary description for EdList.
	/// </summary>
	public class EdList : CMSNET.Common.AuthorizedPage
	{
        protected System.Web.UI.WebControls.DropDownList ddlWhichContent;
        protected System.Web.UI.WebControls.Table tblView;
    
        protected Account account;
        protected Content content;
        protected ContentNotes notes;
    
        private bool IsTypeRequested(string status, int editor)
        {
            switch(Convert.ToInt32(ddlWhichContent.SelectedItem.Value))
            {
                case 0:
                    return (StatusCodes.isAwaitingEdit(status) ||
                        StatusCodes.isEditing(status));
                case 1:
                    if (editor == 0)
                        return false;
                    return (StatusCodes.isAwaitingEdit(status) ||
                        StatusCodes.isRequiresUpdate(status) ||
                        StatusCodes.isEditing(status) ||
                        StatusCodes.isAwaitingApproval(status));
                case 2:
                    if (editor == 0)
                        return false;
                    return true;
                default :
                    return false;
            }
        }

        private void BuildImageButton(TableRow row, string cArg, int count)
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
            cell.HorizontalAlign = HorizontalAlign.Center;
            cell.VerticalAlign   = VerticalAlign.Middle;
            cell.Controls.Add(ibn);

            if (count >= 0)
            {
                LiteralControl lit = new LiteralControl("[" + count +"]");
                cell.Font.Size = new FontUnit(FontSize.XXSmall);
                cell.Controls.Add(lit);
            }
            
            row.Cells.Add(cell);
        }

        private void Page_Load(object sender, System.EventArgs e)
		{
            account = new Account(appEnv.GetConnection());
            content = new Content(appEnv.GetConnection());
            notes   = new ContentNotes(appEnv.GetConnection());

            DataTable dt;
            int accountNo = account.GetAccountID(User.Identity.Name);

            if (accountNo == 1)  // Admin sees all
            {
                dt = content.GetHeadlines();
            }
            else
            {
                dt = content.GetHeadlinesForEdit(accountNo);
            }

            LiteralControl lit; 
            TableCell      cell;
            int prv = -1;
            int cur;

            foreach (DataRow dr in dt.Rows)
            {
                cur = Convert.ToInt32(dr["ContentID"]);

                if (cur != prv)
                {
                    prv = cur;

                    if (IsTypeRequested(dr["Status"].ToString(), 
                        Convert.ToInt32(dr["Editor"])))
                    {
                        TableRow row = new TableRow();
                        tblView.Rows.Add(row);

                        lit = new LiteralControl(dr["ContentID"].ToString());
                        cell = new TableCell();
                        cell.Controls.Add(lit);
                        cell.HorizontalAlign = HorizontalAlign.Center;
                        row.Cells.Add(cell);

                        lit = new LiteralControl(dr["Version"].ToString());
                        cell = new TableCell();
                        cell.Controls.Add(lit);
                        cell.HorizontalAlign = HorizontalAlign.Center;
                        row.Cells.Add(cell);

                        lit = new LiteralControl(dr["Headline"].ToString());
                        cell = new TableCell();
                        cell.Controls.Add(lit);
                        row.Cells.Add(cell);

                        lit = new LiteralControl(StatusCodes.ToString(
                            Convert.ToInt32(dr["Status"])));
                        cell = new TableCell();
                        cell.Font.Size = new FontUnit(FontSize.XSmall);
                        cell.HorizontalAlign = HorizontalAlign.Center;
                        cell.Controls.Add(lit);
                        row.Cells.Add(cell);

                        BuildImageButton(row, "EdView.aspx?ContentID=" + dr["ContentID"].ToString(), -1);
                        BuildImageButton(row, "../Note/NoteList.aspx?ContentID=" + dr["ContentID"].ToString()+ "&Origin=Editor",
                            notes.CountNotesForID(Convert.ToInt32(dr["ContentID"])));

                        if (StatusCodes.isAwaitingEdit(dr["Status"].ToString()) ||
                            StatusCodes.isEditing(dr["Status"].ToString()))
                            BuildImageButton(row, "EdEdit.aspx?ContentID=" + dr["ContentID"].ToString(), -1);
                        else
                            BuildImageButton(row, null, -1);

                        if (StatusCodes.isEditing(dr["Status"].ToString()))
                        {
                            BuildImageButton(row, "EdWithdraw.aspx?ContentID=" + dr["ContentID"].ToString(), -1);
                            BuildImageButton(row, "EdSubmit.aspx?ContentID=" + dr["ContentID"].ToString(), -1);
                            BuildImageButton(row, "EdReturn.aspx?ContentID=" + dr["ContentID"].ToString(), -1);
                        }
                        else
                        {
                            BuildImageButton(row, null, -1);
                            BuildImageButton(row, null, -1);
                            BuildImageButton(row, null, -1);
                        }
                    }
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
