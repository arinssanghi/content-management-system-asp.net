using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Xml;

using CMSNET.Common;
using CMSNET.DataAccess;

namespace CMSNET.Administration.CMA
{
	/// <summary>
	/// Summary description for Menu.
	/// </summary>
	public class NavBar : System.Web.UI.Page
	{
        protected System.Web.UI.WebControls.Button bnLogout;
        protected System.Web.UI.WebControls.Table tblMenu;
    
        public System.Web.UI.WebControls.Image AddImage(string imgURL)
        {
            System.Web.UI.WebControls.Image image = 
                new System.Web.UI.WebControls.Image();
            image.ImageUrl = imgURL;
            image.Width = Unit.Pixel(11);
            image.Height = Unit.Pixel(11);
            image.BorderWidth = Unit.Pixel(0);

            return image;
        }

        public ArrayList Roles (string role)
        {
            ArrayList list = new ArrayList();

            string[] temp = role.Split(',');
            for (int k = 0; k < temp.Length; k++)
                list.Add(temp[k]);

            return list;
        }

        private void Page_Load(object sender, System.EventArgs e)
		{
            bool authorized = false;

            XmlReader reader = new XmlTextReader(File.OpenRead(Server.MapPath("..\\XMLFiles\\CMAMenu.xml")));

            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            reader.Close();

            string expand = Request.QueryString["Expand"];
            
            int ExpandWhich;
            if (expand == null)
                ExpandWhich = -1;
            else
                ExpandWhich = Convert.ToInt16(expand);

            TableCell   cell;
            HyperLink   link;

            XmlNodeList Menus = doc.GetElementsByTagName("Menu");

            for (int i = 0; i < Menus.Count; i++)
            {
                int currnode = 0;

                XmlNodeList MenuNodes = Menus[i].ChildNodes;

                if (MenuNodes[currnode].Name.Equals("authorization"))
                {
                    AppEnv appEnv = new AppEnv(Context);
                    AccountRoles accountRoles = new AccountRoles(appEnv.GetConnection());
                    if (accountRoles.Authorization(
                        Roles(MenuNodes[currnode++].InnerText), 
                        User.Identity.Name))
                    {
                        authorized = true;
                    }
                    else
                    {
                        authorized = false;
                    }
                }
                else
                {
                    authorized = true;
                }

                if (authorized)
                {
                    TableRow row = new TableRow();
                    tblMenu.Rows.Add(row);
                    
                    if (ExpandWhich == i)
                    {
                        cell = new TableCell();
                        cell.Width = Unit.Percentage(1.0);
                        cell.Controls.Add(AddImage("Images/minus.gif"));
                        row.Cells.Add(cell);

                        link = new HyperLink();
                        link.Text = MenuNodes[currnode++].InnerText;
                        link.NavigateUrl = "NavBar.aspx?Expand=-1";

                        cell = new TableCell();
                        cell.Width = Unit.Percentage(99.0);
                        cell.Controls.Add(link);

                        row.Cells.Add(cell);

                        // start at 1 since 0 is the Menu Name
                        for (int j = currnode; j < MenuNodes.Count; j++)
                        {
                            row = new TableRow();
                            tblMenu.Rows.Add(row);

                            cell = new TableCell();
                            cell.Width = Unit.Percentage(1.0);
                            cell.Controls.Add(AddImage("Images/blank.gif"));
                            row.Cells.Add(cell);

                            link = new HyperLink();
                            link.Text = MenuNodes[j].ChildNodes[0].InnerText;
                            link.NavigateUrl = MenuNodes[j].ChildNodes[1].InnerText;
                            link.Target = "main";

                            cell = new TableCell();
                            cell.Width = Unit.Percentage(99.0);
                            cell.Controls.Add(link);

                            row.Cells.Add(cell);
                        }
                    }
                    else
                    {
                        cell = new TableCell();
                        cell.Width = Unit.Percentage(1.0);
                        cell.Controls.Add(AddImage("Images/plus.gif"));
                        row.Cells.Add(cell);

                        link = new HyperLink();
                        link.Text = MenuNodes[currnode++].InnerText;
                        link.NavigateUrl = "NavBar.aspx?Expand=" + i;

                        cell = new TableCell();
                        cell.Width = Unit.Percentage(99.0);
                        cell.Controls.Add(link);

                        row.Cells.Add(cell);
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
            this.bnLogout.Click += new System.EventHandler(this.bnLogout_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
		#endregion

        private void bnLogout_Click(object sender, System.EventArgs e)
        {
            FormsAuthentication.SignOut();
            this.Controls.Add(new LiteralControl(
                "<script language=javascript>" + 
                "    window.parent.location='../admin.aspx';" +
                "</script>")
                );
        }
	}
}
