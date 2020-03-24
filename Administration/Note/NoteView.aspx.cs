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
	/// Summary description for NoteView.
	/// </summary>
	public class NoteView : CMSNET.Common.AuthorizedPage
	{
        protected System.Web.UI.WebControls.Label lbWho;
        protected System.Web.UI.WebControls.TextBox lbNote;
        protected System.Web.UI.WebControls.Label lbAuthor;
        protected System.Web.UI.WebControls.Label lbModifiedDate;
        protected System.Web.UI.WebControls.Label lbCreationDate;
        protected System.Web.UI.WebControls.Button bnUpdate;
        protected System.Web.UI.WebControls.Button bnRemove;
        protected System.Web.UI.WebControls.Label lbContentID;
    
        private string origin;
        private int nid = 0;

        private void Page_Load(object sender, System.EventArgs e)
		{
            nid = Convert.ToInt32(Request.QueryString["NoteID"]);
            origin = Request.QueryString["Origin"];

            if (nid == 0)
            {
                Page_Error("NoteID Missing");
            }

            if (!IsPostBack)
            {
                Account account = new Account(appEnv.GetConnection());
                AccountProperty property = new AccountProperty(appEnv.GetConnection());
                DataRow dr = new ContentNotes(appEnv.GetConnection()).GetNote(nid);

                lbWho.Text = origin;

                lbContentID.Text = dr["ContentID"].ToString();
				
                lbNote.Text = dr["Note"].ToString();
                lbAuthor.Text    = property.GetValue(Convert.ToInt32(dr["Author"]), 
                    "UserName").Trim();
                lbModifiedDate.Text  = dr["ModifiedDate"].ToString();
                lbCreationDate.Text  = dr["CreationDate"].ToString();

                if (account.GetAccountID(User.Identity.Name) != Convert.ToInt32(dr["Author"]))
                {
                    bnUpdate.Visible = false;
                    bnRemove.Visible = false;
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
            this.bnUpdate.Click += new System.EventHandler(this.bnUpdate_Click);
            this.bnRemove.Click += new System.EventHandler(this.bnRemove_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
		#endregion

        private void bnUpdate_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("NoteUpdate.aspx?NoteID=" + nid + "&Origin=" + origin);
        }

        private void bnRemove_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("NoteRemove.aspx?NoteID=" + nid + "&Origin=" + origin);
        }
	}
}
