using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using CMSNET.Common;
using CMSNET.DataAccess;

namespace CMSNET.Setup
{
	public class setup3 : System.Web.UI.Page
	{
        protected System.Web.UI.WebControls.ValidationSummary ValSum;
        protected System.Web.UI.WebControls.Label lblError;
        protected System.Web.UI.WebControls.TextBox txtAdministratorName;
        protected System.Web.UI.WebControls.TextBox txtUserName;
        protected System.Web.UI.WebControls.RequiredFieldValidator rfvUserID;
        protected System.Web.UI.WebControls.TextBox txtEmail;
        protected System.Web.UI.WebControls.RequiredFieldValidator rfvEmail;
        protected System.Web.UI.WebControls.RegularExpressionValidator revEmail;
        protected System.Web.UI.WebControls.TextBox txtPassword;
        protected System.Web.UI.WebControls.RequiredFieldValidator rfvPassword;
        protected System.Web.UI.WebControls.TextBox txtConfirm;
        protected System.Web.UI.WebControls.RequiredFieldValidator rfvConfirm;
        protected System.Web.UI.WebControls.CompareValidator cvConfirm;
        protected System.Web.UI.WebControls.Button btnCreateAdmin;
        protected System.Web.UI.WebControls.HyperLink HyperLink1;
    
        Account         account;
        AccountProperty property;
        AccountRoles    role;


        private void ProcessAdministratorName() 
        {
            if (txtAdministratorName.Text.Length > 0)
            {
                try
                {
                    property.Insert(1, "UserName", txtAdministratorName.Text);
                }
                catch (SqlException sqlerr)
                {
                    if (sqlerr.Message.IndexOf("duplicate key") >= 0)
                    {
                        property.Update(1, "UserName", txtAdministratorName.Text);
                    }
                    else
                        throw sqlerr;
                }
            }
        }

        private void ProcessAccountRoles() 
        {
            try
            {
                role.Insert(1, "Administrator");
            }
            catch (SqlException)
            {
                // Duplicate key means jobs done already... move on.
            }
        }

        private void Page_Load(object sender, System.EventArgs e)
		{
            if (IsPostBack)
            {
                Page.Validate();

                if (Page.IsValid)
                {
                    try
                    {
                        if (!account.Exist(1))
                        {
                            account.Insert(txtUserName.Text, txtPassword.Text, txtEmail.Text);
                        }
                        else
                        {
                            account.Update(1, txtUserName.Text, txtPassword.Text, txtEmail.Text);
                        }
                        ProcessAdministratorName();
                        ProcessAccountRoles();

                        Response.Redirect("setup4.aspx");
                    }
                    catch (Exception err)
                    {
                        lblError.Text = "Sorry, the following error occured: " + err.Message;
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
        
            SqlConnection connection = new AppEnv(Context).GetConnection();
            account  = new Account(connection);
            property = new AccountProperty(connection);
            role     = new AccountRoles(connection);
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
