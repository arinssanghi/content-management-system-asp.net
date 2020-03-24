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

namespace CMSNET.CDA.Protected
{
	public class myHomePg : CMSNET.Common.AuthorizedPage
	{
		protected CMSNET.CDA.NavBar MainNavBar;
		protected CMSNET.CDA.Protected.ZoneCard ZoneCard1;
		protected CMSNET.CDA.Protected.ZoneCard ZoneCard2;
		protected CMSNET.CDA.Protected.ZoneCard ZoneCard3;
		protected CMSNET.CDA.Protected.ZoneCard ZoneCard4;
		protected CMSNET.CDA.Protected.ZoneCard ZoneCard5;
		protected CMSNET.CDA.Protected.ZoneCard ZoneCard6;

		protected CMSNET.CDA.Protected.ZoneCard[] ZoneCards = new ZoneCard[6];
        
		private void Page_Load(object sender, System.EventArgs e)
		{
			int Domain = Convert.ToInt32(Request.QueryString["Domain"]);

			// First Time in no Domain specified
			if (Domain == 0)
				Domain = 1;

			MainNavBar.Domain = Domain;

			Account account = new Account(appEnv.GetConnection());
			int accountID = account.GetAccountID(User.Identity.Name);

			if (!IsPostBack)
			{
				AccountProperty property = new AccountProperty(appEnv.GetConnection());
				string strZoneIds = property.GetValue(accountID, "ZoneCards");

				if (strZoneIds.Length <= 0)
				{
					property.Insert(accountID, "ZoneCards", "0,0,0,0,0,0");
				}
			}

			for (int i = 0; i < 6; i++)
			{
				ZoneCards[i].Card = i;
				ZoneCards[i].AccountID = accountID;
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			ZoneCards[0] = ZoneCard1;
			ZoneCards[1] = ZoneCard2;
			ZoneCards[2] = ZoneCard3;
			ZoneCards[3] = ZoneCard4;
			ZoneCards[4] = ZoneCard5;
			ZoneCards[5] = ZoneCard6;

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
