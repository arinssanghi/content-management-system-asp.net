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

namespace CMSNET.Administration.Deploy
{
	public class DeployList : CMSNET.Common.AuthorizedPage
	{
        protected System.Web.UI.WebControls.Table tblNewContent;
        protected System.Web.UI.WebControls.DropDownList ddlZones;
        protected System.Web.UI.WebControls.Button bnUpdtRanks;
        protected System.Web.UI.WebControls.Table tblSiteContent;
    
        Zone zone;
        Distribution dist;
        Content content;

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
            zone = new Zone(appEnv.GetConnection());
            dist = new Distribution(appEnv.GetConnection());
            content = new Content(appEnv.GetConnection());

            LiteralControl lit;
            TableCell cell;
            DropDownList ddlRank;
            DataTable AllRanks = null;

            string inZone = Request.QueryString["Zone"];

            DataTable dtz = zone.GetAllZones();

            DataTable dt = content.GetHeadlines();

            if (dt.Rows.Count > 0)
            {
                int prv = -1;
                int cur;

                foreach (DataRow dr in dt.Rows)
                {
                    cur = Convert.ToInt32(dr["ContentID"]);

                    if (cur != prv)
                    {
                        prv = cur;

                        if (StatusCodes.isApproved(dr["Status"].ToString()))
                        {
                            TableRow row = new TableRow();
                            tblNewContent.Rows.Add(row);

                            lit = new LiteralControl(dr["Headline"].ToString());
                            cell = new TableCell();
                            cell.Controls.Add(lit);
                            row.Cells.Add(cell);

                            BuildImageButton(row, "DeployView.aspx?ID=" + dr["ContentID"] + 
                                "&Ver=" + dr["Version"]);
                            BuildImageButton(row, "DeployDeploy.aspx?ID=" + dr["ContentID"] + 
                                "&Ver=" + dr["Version"]);
                            BuildImageButton(row, "DeployReturn.aspx?ID=" + dr["ContentID"] + 
                                "&Ver=" + dr["Version"]);
                        }
                    }
                }
            }

            if (!IsPostBack)
            {
                if (inZone == null)
                    inZone = "None";

                ListItem item;

                ddlZones.Items.Add(new ListItem("None")); 

                ddlZones.Items.Add(item = new ListItem("All")); 
                if (inZone.Equals("All"))
                    item.Selected = true;

                foreach (DataRow dr in dtz.Rows)
                {
                    ddlZones.Items.Add(item = new ListItem(dr["Title"].ToString())); 

                    if (dr["Title"].ToString().Trim().Equals(inZone))
                    {
                        item.Selected = true;
                    }
                }
            }

//          else
//          {
            foreach (DataRow dr in dtz.Rows)
            {
                DataTable dtd = dist.GetOrdered(Convert.ToInt32(dr["ZoneID"]));
 

                if (ddlZones.SelectedItem.Text.Equals("All") ||
                    ddlZones.SelectedItem.Text.Equals(dr["Title"]))
                {
                    if (dtd.Rows.Count == 0)
                    {
                        TableRow row = new TableRow();
                        tblSiteContent.Rows.Add(row);

                        lit = new LiteralControl(dr["Title"].ToString());
                        cell = new TableCell();
                        cell.Controls.Add(lit);
                        row.Cells.Add(cell);

                        lit = new LiteralControl("No Content");
                        cell = new TableCell();
                        cell.ColumnSpan = 4;
                        cell.Controls.Add(lit);
                        row.Cells.Add(cell);
                    }
                    foreach (DataRow drd in dtd.Rows)
                    {
                        TableRow row = new TableRow();
                        tblSiteContent.Rows.Add(row);

                        lit = new LiteralControl(dr["Title"].ToString());
                        cell = new TableCell();
                        cell.Controls.Add(lit);
                        row.Cells.Add(cell);

                        DataRow drc = content.GetContentForIDVer(Convert.ToInt32(drd["ContentID"]),
                            Convert.ToInt32(drd["Version"]));

                        lit = new LiteralControl(drc["Headline"].ToString());
                        cell = new TableCell();
                        cell.Controls.Add(lit);
                        row.Cells.Add(cell);

                        if (AllRanks == null)
                        {
                            AllRanks = new ContentRank(appEnv.GetConnection()).GetRanks();
                        }
            
                        cell = new TableCell();
                        ddlRank = new DropDownList();
                        foreach (DataRow drr in AllRanks.Rows)
                        {
                            ddlRank.Items.Add(new ListItem(drr["Rank"].ToString(),
                                drr["RankID"].ToString()));
                        }
                        ddlRank.Items.FindByValue(drd["Ranking"].ToString()).Selected = true;
                        cell.Controls.Add(ddlRank);
                        row.Cells.Add(cell);

                        BuildImageButton(row, "DeployView.aspx?ID=" + drd["ContentID"] + 
                            "&Ver=" + drd["Version"]);
                        BuildImageButton(row, "DeployArchive.aspx?ID=" + drd["ContentID"] + 
                            "&Ver=" + drd["Version"]);
                    }
                }
            }
//          }
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
            this.ddlZones.SelectedIndexChanged += new System.EventHandler(this.ddlZones_SelectedIndexChanged);
            this.bnUpdtRanks.Click += new System.EventHandler(this.bnUpdtRanks_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
		#endregion
        
        private void btn_Click(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            Response.Redirect(e.CommandArgument.ToString());
        }

        private void bnUpdtRanks_Click(object sender, System.EventArgs e)
        {
            int crow;
            DataTable dtz = zone.GetAllZones();
            DropDownList ddl;

            crow = 1;  // row 0 is titles
            foreach (DataRow dr in dtz.Rows)
            {
                DataTable dtd = dist.GetOrdered(Convert.ToInt32(dr["ZoneID"]));
            
                if (ddlZones.SelectedItem.Text.Equals("All") ||
                    ddlZones.SelectedItem.Text.Equals(dr["Title"]))
                {
                    if (dtd.Rows.Count <= 0)
                        crow++;

                    int LeadCount = 0;
                    for (int tt = 0; tt < dtd.Rows.Count; tt++)
                    {
                        TableCellCollection tcc = tblSiteContent.Rows[crow++].Cells;
                        ddl = (DropDownList)tcc[2].Controls[0];

                        if (ddl.SelectedItem.Text.Trim().Equals("Lead"))
                            LeadCount++;
                    }
                    if (LeadCount > 1)
                        Page_Error("<h2>**Error** Multiple Leads found</h2> Only allowed one lead per zone");
                }
            }

            crow = 1;  // row 0 is titles
            foreach (DataRow dr in dtz.Rows)
            {
                DataTable dtd = dist.GetOrdered(Convert.ToInt32(dr["ZoneID"]));
            
                if (ddlZones.SelectedItem.Text.Equals("All") ||
                    ddlZones.SelectedItem.Text.Equals(dr["Title"]))
                {
                    if (dtd.Rows.Count <= 0)
                        crow++;

                    foreach (DataRow drd in dtd.Rows)
                    {
                        TableCellCollection tcc = tblSiteContent.Rows[crow++].Cells;
                        ddl = (DropDownList)tcc[2].Controls[0];

                        if (ddl.SelectedIndex+1 != Convert.ToInt32(drd["Ranking"]))
                        {
                            dist.UpdateRank(Convert.ToInt32(dr["ZoneID"]),
                                Convert.ToInt32(drd["ContentID"]),
                                Convert.ToInt32(drd["Version"]),
                                ddl.SelectedIndex+1);
                        }
                    }
                }
            }
        }

        private void ddlZones_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            string tt = "DeployList.aspx?Zone=" + ddlZones.SelectedItem.Text;
            Response.Redirect("DeployList.aspx?Zone=" + ddlZones.SelectedItem.Text);
        }

    }
}
