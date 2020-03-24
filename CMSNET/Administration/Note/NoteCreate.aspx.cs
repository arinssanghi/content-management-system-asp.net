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

using CMSNET.DataAccess;
using CMSNET.Common;

namespace CMSNET.Administration.Note
{
	/// <summary>
	/// Summary description for NoteCreate.
	/// </summary>
	public class NoteCreate : CMSNET.Common.AuthorizedPage
	{
        protected System.Web.UI.WebControls.Label lbWho;
        protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
        protected System.Web.UI.WebControls.TextBox tbNote;
        protected System.Web.UI.WebControls.RequiredFieldValidator rfvNote;
        protected System.Web.UI.WebControls.Button bnNote;
    
        private string origin;
        private int cid = 0;
    
        private void Page_Load(object sender, System.EventArgs e)
		{
            cid = Convert.ToInt32(Request.QueryString["ContentID"]);
            origin = Request.QueryString["Origin"];

            if (cid == 0)
            {
                Page_Error("ContentID Missing");
            }
			
            if (IsPostBack)
            {
                Page.Validate();

                if (Page.IsValid)
                {
                    try
                    {
                        Account account = new Account(appEnv.GetConnection());
                        ContentNotes notes = new ContentNotes(appEnv.GetConnection());
                        notes.Insert(cid, tbNote.Text, account.GetAccountID(User.Identity.Name)); 
                    }
                    catch (Exception err)
                    {
                        Page_Error("The following error occured: " + err.Message);
                    }

                    Response.Redirect("NoteList.aspx?ContentID=" + cid + "&Origin=" + origin);
                }
            }
            else
            {
                lbWho.Text = origin;
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
	}
}
