using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using CMSNET.Common;
using CMSNET.DataAccess;

namespace CMSNET.CDA.Protected
{
	public abstract class ZoneCard : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.HyperLink hlZoneName;
		protected System.Web.UI.WebControls.DropDownList ddlZones;
		protected System.Web.UI.WebControls.Panel pnlZoneName;
		protected System.Web.UI.WebControls.ImageButton ibnEdit;
		protected System.Web.UI.WebControls.ImageButton ibnExpCon;
		protected System.Web.UI.WebControls.ImageButton ibnClose;
		protected System.Web.UI.WebControls.Panel pnlTitle;
		protected System.Web.UI.WebControls.Label lbHeadline;
		protected System.Web.UI.WebControls.Label lbSource;
		protected System.Web.UI.WebControls.Label lbBy;
		protected System.Web.UI.WebControls.Label lbByline;
		protected System.Web.UI.WebControls.Label lbTeaser;
		protected System.Web.UI.WebControls.Image imgPlus;
		protected System.Web.UI.WebControls.HyperLink hlReadMore;
		protected System.Web.UI.WebControls.Panel pnlBody;
		protected System.Web.UI.WebControls.ImageButton ibnEditNew;
		protected System.Web.UI.WebControls.Label lbEmpty;

		private int m_accountid = 0;
		private int m_card = 0;
		private int ZoneID = 0;
		private AppEnv appEnv;
		private AccountProperty property;
		private Zone zone;
		private string[] strZoneIds;
        
		public int AccountID
		{
			get
			{
				return m_accountid;
			}
			set
			{
				m_accountid = value;
			}
		}

		public int Card
		{
			get 
			{
				return m_card;
			}
			set
			{
				m_card = value;
			}
		}

		private string CommaDelString(string[] str)
		{
			string ret = "";

			for (int i = 0; i < str.Length; i++)
			{
				ret += str[i];

				if (i < str.Length - 1)
					ret += ",";
			}

			return ret;
		}

		private void UpdateZoneCard()
		{
			strZoneIds[Card] = ZoneID.ToString();
			property.Update(AccountID, "ZoneCards", CommaDelString(strZoneIds));
		}

		private void BuildBody()
		{
			Distribution dist = new Distribution(appEnv.GetConnection());
			DataTable dtd = dist.GetOrdered(ZoneID);

			int contentid = 0;
			int version = 0;

			if (dtd.Rows.Count > 0)
			{
				contentid = Convert.ToInt32(dtd.Rows[0]["ContentID"]);
				version = Convert.ToInt32(dtd.Rows[0]["Version"]);
			}

			Content content = new Content(appEnv.GetConnection());
			DataRow dr = content.GetContentForIDVer(contentid, version);

			if (dr != null)
			{
				lbHeadline.Text = dr["Headline"].ToString();
				lbSource.Text = dr["Source"].ToString().Trim();
				lbByline.Text = property.GetValue(Convert.ToInt32(dr["Byline"]), "UserName").Trim();
				lbTeaser.Text = dr["Teaser"].ToString().Trim();
				hlReadMore.NavigateUrl = "StoryPg.aspx?ID=" + contentid + "&Ver=" + version;
				hlReadMore.Visible = true;
				lbBy.Visible = true;
				imgPlus.Visible = true;
			}
			else
			{
				lbHeadline.Text = "No Stories";
				lbSource.Text = "";
				lbByline.Text = "";
				lbTeaser.Text = "";
				hlReadMore.Visible = false;
				lbBy.Visible = false;
				imgPlus.Visible = false;
			}
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			appEnv = new AppEnv(Context);
			zone = new Zone(appEnv.GetConnection());
			property = new AccountProperty(appEnv.GetConnection());

			if (!IsPostBack)
			{
				DataTable dtz = zone.GetAllZones();

				ddlZones.Items.Add(new ListItem("Select a zone", "0"));

				foreach (DataRow dr in dtz.Rows)
				{
					ddlZones.Items.Add(new ListItem(dr["Title"].ToString(),
						dr["ZoneID"].ToString()));
				}
			}

			strZoneIds = property.GetValue(AccountID, "ZoneCards").Split(',');
			ZoneID = Convert.ToInt32(strZoneIds[Card]);

			if (ZoneID == 0)
			{
				pnlTitle.Visible = false;
				pnlBody.Visible = false;
				ibnEditNew.Visible = true;
				lbEmpty.Visible = true;

				return;
			}

			if (ZoneID > 0)
			{
				DataRow drz = zone.GetZone(ZoneID);
				hlZoneName.Text = drz["Title"].ToString();
				hlZoneName.NavigateUrl = "ZonePg.aspx?zone=" + drz["ZoneID"];
				BuildBody();
			}
			else
			{
				DataRow drz = zone.GetZone(-ZoneID);
				hlZoneName.Text = drz["Title"].ToString();
				hlZoneName.NavigateUrl = "ZonePg.aspx?zone=" + drz["ZoneID"];
				pnlBody.Visible = false;
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
			this.ddlZones.SelectedIndexChanged += new System.EventHandler(this.ddlZones_SelectedIndexChanged);
			this.ibnEdit.Click += new System.Web.UI.ImageClickEventHandler(this.ibnEditNew_Click);
			this.ibnExpCon.Click += new System.Web.UI.ImageClickEventHandler(this.ibnExpCon_Click);
			this.ibnClose.Click += new System.Web.UI.ImageClickEventHandler(this.ibnClose_Click);
			this.ibnEditNew.Click += new System.Web.UI.ImageClickEventHandler(this.ibnEditNew_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ibnEditNew_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			pnlTitle.Visible = true;
			hlZoneName.Visible = false;
			ddlZones.Visible = true;

			if (ZoneID > 0)
			{
				ZoneID = -ZoneID;
				pnlBody.Visible = false;
				UpdateZoneCard();
			}

			ibnEditNew.Visible = false;
			lbEmpty.Visible = false;
		}

		private void ibnExpCon_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			hlZoneName.Visible = true;
			ddlZones.Visible = false;

			ZoneID = -ZoneID;
			pnlBody.Visible = (ZoneID > 0);

			if (ZoneID > 0)
				BuildBody();

			UpdateZoneCard();
		}

		private void ibnClose_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			pnlTitle.Visible = false;
			pnlBody.Visible = false;
			ibnEditNew.Visible = true;
			lbEmpty.Visible = true;
			ZoneID = 0;
			UpdateZoneCard();
		}

		private void ddlZones_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ZoneID = Convert.ToInt32(ddlZones.SelectedItem.Value);
			if (ZoneID > 0)
			{

				pnlTitle.Visible = true;
				hlZoneName.Visible = true;
				ddlZones.Visible = false;
				pnlBody.Visible = true;
				ibnEditNew.Visible = false;
				lbEmpty.Visible = false;

				DataRow drz = zone.GetZone(ZoneID);
				hlZoneName.Text = drz["Title"].ToString();
				hlZoneName.NavigateUrl = "ZonePg.aspx?zone=" + drz["ZoneID"];
            
				BuildBody();
			}
			else
			{
				pnlTitle.Visible = false;
				pnlBody.Visible = false;
				ibnEditNew.Visible = true;
				lbEmpty.Visible = true;
			}
			UpdateZoneCard();
		}
	}
}
