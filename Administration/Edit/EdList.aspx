<%@ Page language="c#" Codebehind="EdList.aspx.cs" AutoEventWireup="false" Inherits="CMSNET.Administration.Edit.EdList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>EdList</title>
        <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
        <meta name="CODE_LANGUAGE" Content="C#">
        <meta name="vs_defaultClientScript" content="JavaScript">
        <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    </HEAD>
    <body>
        <form id="EdList" method="post" runat="server">
            <H2>
                <FONT color="darkslategray">Editor&nbsp;: Content List</FONT>
            </H2>
            <P>
                <STRONG>Which Content: </STRONG>
                <asp:dropdownlist id="ddlWhichContent" runat="server" AutoPostBack="True">
                    <asp:ListItem Value="0">Currently Available or Being Edited</asp:ListItem>
                    <asp:ListItem Value="1">Currently Editing or Awaiting Approval</asp:ListItem>
                    <asp:ListItem Value="2">All Edited by</asp:ListItem>
                </asp:dropdownlist>
                &nbsp;
            </P>
            <P>
                <asp:table id="tblView" runat="server" GridLines="Both" CellPadding="3" CellSpacing="1">
                    <asp:TableRow BackColor="#8CD3EF">
                        <asp:TableCell Width="5%" HorizontalAlign="Center" Text="ID"></asp:TableCell>
                        <asp:TableCell Width="5%" Font-Size="X-Small" HorizontalAlign="Center" Text="Ver"></asp:TableCell>
                        <asp:TableCell Width="66%" HorizontalAlign="Center" Text="Headline"></asp:TableCell>
                        <asp:TableCell Width="10%" Font-Size="X-Small" HorizontalAlign="Center" Text="Status"></asp:TableCell>
                        <asp:TableCell Width="2%" Font-Size="XX-Small" HorizontalAlign="Center" Text="View"></asp:TableCell>
                        <asp:TableCell Width="4%" Font-Size="XX-Small" Text="&amp;nbsp;Notes&amp;nbsp;"></asp:TableCell>
                        <asp:TableCell Width="2%" Font-Size="XX-Small" HorizontalAlign="Center" Text="Edit"></asp:TableCell>
                        <asp:TableCell Width="2%" Font-Size="XX-Small" HorizontalAlign="Center" Text="With draw"></asp:TableCell>
                        <asp:TableCell Width="2%" Font-Size="XX-Small" HorizontalAlign="Center" Text="Sub"></asp:TableCell>
                        <asp:TableCell Width="2%" Font-Size="XX-Small" HorizontalAlign="Center" Text="Rtn Updt"></asp:TableCell>
                    </asp:TableRow>
                </asp:table>
            </P>
        </form>
    </body>
</HTML>
