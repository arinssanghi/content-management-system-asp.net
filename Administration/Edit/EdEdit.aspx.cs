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
	/// Summary description for EdEdit.
	/// </summary>
	public class EdEdit : CMSNET.Common.AuthorizedPage
	{
        protected System.Web.UI.WebControls.ValidationSummary ValSum;
        protected System.Web.UI.WebControls.Label lbContentID;
        protected System.Web.UI.WebControls.Label lbVersion;
        protected System.Web.UI.WebControls.TextBox tbHeadline;
        protected System.Web.UI.WebControls.RequiredFieldValidator rfvHeadline;
        protected System.Web.UI.WebControls.TextBox tbSource;
        protected System.Web.UI.WebControls.Label lbByline;
        protected System.Web.UI.WebControls.Label lbBylineNum;
        protected System.Web.UI.WebControls.TextBox tbTeaser;
        protected System.Web.UI.WebControls.TextBox tbBody;
        protected System.Web.UI.WebControls.RequiredFieldValidator rfvBody;
        protected System.Web.UI.WebControls.TextBox tbTagline;
        protected System.Web.UI.WebControls.Label lbEditor;
        protected System.Web.UI.WebControls.Label lbEditorNum;
        protected System.Web.UI.WebControls.Label lbApprover;
        protected System.Web.UI.WebControls.Label lbApproverNum;
        protected System.Web.UI.WebControls.Label lbStatus;
        protected System.Web.UI.WebControls.Label lbStatusNum;
        protected System.Web.UI.WebControls.Label lbModifiedDate;
        protected System.Web.UI.WebControls.Label lbCreationDate;
        protected System.Web.UI.WebControls.Button bnInsert;
        protected System.Web.UI.WebControls.Button bnUpdate;
        protected System.Web.UI.WebControls.Button bnRestore;
        protected System.Web.UI.WebControls.Button bnReturn;
    
        protected DataTable dt;
        
        private void SetAsEditor()
        {
            int id;
            Content content = new Content(appEnv.GetConnection());
            Account account = new Account(appEnv.GetConnection());
            DataRow dr = dt.Rows[0];

            content.SetEditor(Convert.ToInt32(dr["ContentID"]), 
                Convert.ToInt32(dr["Version"]),
                (id = account.GetAccountID(User.Identity.Name)));

            dt = new Content(appEnv.GetConnection()).GetContentForID(Convert.ToInt32(dr["ContentID"]));

            // Only one person can edit a piece of content
            if (id != Convert.ToInt32(dt.Rows[0]["Editor"]))
                Page_Error("<h3>Too Slow!!</h3>Someone is editing this already");
        }
		
        private void BuildOrigPage()
        {
            AccountProperty property = new AccountProperty(appEnv.GetConnection());

            DataRow dr = dt.Rows[0];

            lbContentID.Text = dr["ContentID"].ToString();
            lbVersion.Text   = dr["Version"].ToString();
            tbHeadline.Text  = dr["Headline"].ToString();
            tbSource.Text    = dr["Source"].ToString();
            lbBylineNum.Text = dr["Byline"].ToString();
            lbByline.Text    = property.GetValue(Convert.ToInt32(dr["Byline"]), 
                "UserName").Trim();
            tbTeaser.Text    = dr["Teaser"].ToString();
            tbBody.Text      = dr["Body"].ToString();
            tbTagline.Text   = dr["Tagline"].ToString();
            lbEditorNum.Text = dr["Editor"].ToString();
            lbEditor.Text    = property.GetValue(Convert.ToInt32(dr["Editor"]), 
                "UserName").Trim();
            lbApproverNum.Text   = dr["Approver"].ToString();
            lbApprover.Text      = property.GetValue(Convert.ToInt32(dr["Approver"]), 
                "UserName").Trim();
            lbStatusNum.Text     = dr["Status"].ToString();
            lbStatus.Text        = StatusCodes.ToString(Convert.ToInt32(dr["Status"]));
            lbModifiedDate.Text  = dr["ModifiedDate"].ToString();
            lbCreationDate.Text  = dr["CreationDate"].ToString();
        }

        private void Page_Load(object sender, System.EventArgs e)
		{
            int cid = Convert.ToInt32(Request.QueryString["ContentID"]);

            if (cid == 0)
            {
                Page_Error("ContentID Missing");
            }
            dt = new Content(appEnv.GetConnection()).GetContentForID(cid);

            if (!IsPostBack)
            {
                if (StatusCodes.isAwaitingEdit(dt.Rows[0]["Status"].ToString()))
                    SetAsEditor();
					
                BuildOrigPage();
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
            this.bnInsert.Click += new System.EventHandler(this.bnInsert_Click);
            this.bnUpdate.Click += new System.EventHandler(this.bnUpdate_Click);
            this.bnRestore.Click += new System.EventHandler(this.bnRestore_Click);
            this.bnReturn.Click += new System.EventHandler(this.bnReturn_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
		#endregion

        private void bnInsert_Click(object sender, System.EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    Content content = new Content(appEnv.GetConnection());
                    Account account = new Account(appEnv.GetConnection());
                    content.Insert(Convert.ToInt32(lbContentID.Text),
                        Convert.ToInt32(lbVersion.Text) + 1,
                        0,
                        tbHeadline.Text, tbSource.Text, 
                        Convert.ToInt32(lbBylineNum.Text), 
                        tbTeaser.Text, tbBody.Text, tbTagline.Text, 
                        Convert.ToInt32(lbEditorNum.Text), 
                        Convert.ToInt32(lbApproverNum.Text), 
                        account.GetAccountID(User.Identity.Name),
                        Convert.ToInt32(lbStatusNum.Text));

                }
                catch (Exception err)
                {
                    Page_Error("The following error occured: " + err.Message);
                }

                Response.Redirect("EdList.aspx");
            }
        }

        private void bnUpdate_Click(object sender, System.EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    Content content = new Content(appEnv.GetConnection());
                    Account account = new Account(appEnv.GetConnection());
                    content.Update(Convert.ToInt32(lbContentID.Text),
                        Convert.ToInt32(lbVersion.Text),
                        0,
                        tbHeadline.Text, tbSource.Text, 
                        Convert.ToInt32(lbBylineNum.Text), 
                        tbTeaser.Text, tbBody.Text, tbTagline.Text, 
                        Convert.ToInt32(lbEditorNum.Text), 
                        Convert.ToInt32(lbApproverNum.Text), 
                        account.GetAccountID(User.Identity.Name),
                        Convert.ToInt32(lbStatusNum.Text));

                }
                catch (Exception err)
                {
                    Page_Error("The following error occured: " + err.Message);
                }

                Response.Redirect("EdList.aspx");
            }
        }

        private void bnRestore_Click(object sender, System.EventArgs e)
        {
            BuildOrigPage();
        }

        private void bnReturn_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("EdReturn.aspx?ContentID=" + lbContentID.Text);
        }
	}
}
