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
	/// Summary description for NoteRemove.
	/// </summary>
	public class NoteRemove : CMSNET.Common.AuthorizedPage
	{
        protected System.Web.UI.WebControls.Label lbWho;
        protected System.Web.UI.WebControls.Label lbWhichNote;
        protected System.Web.UI.WebControls.Button bnRemove;
        protected System.Web.UI.WebControls.Label lbContentID;
    
        private ContentNotes notes;
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

            notes = new ContentNotes(appEnv.GetConnection());
            DataRow dr = notes.GetNote(nid);

            lbWho.Text = origin;

            lbContentID.Text = dr["ContentID"].ToString();
            lbWhichNote.Text = dr["Note"].ToString();
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
            this.bnRemove.Click += new System.EventHandler(this.bnRemove_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
		#endregion

        private void bnRemove_Click(object sender, System.EventArgs e)
        {
            notes.Remove(nid);
            Response.Redirect("NoteList.aspx?ContentID=" + lbContentID.Text + "&origin=" + origin);
        }
	}
}
