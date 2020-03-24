<%@ Page language="c#" Codebehind="DeployList.aspx.cs" AutoEventWireup="false" Inherits="CMSNET.Administration.Deploy.DeployList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>DeployList</title>
        <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
        <meta name="CODE_LANGUAGE" Content="C#">
        <meta name="vs_defaultClientScript" content="JavaScript">
        <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    </HEAD>
    <body>
        <form id="DeployList" method="post" runat="server">
            <H2><FONT color="darkslategray">Deploy :&nbsp;List</FONT></H2>
            <H3>New Content</H3>
            <P><asp:table id="tblNewContent" runat="server" Width="75%" GridLines="Both" CellSpacing="1" CellPadding="3">
                    <asp:TableRow BackColor="#8CD3EF">
                        <asp:TableCell Width="50%" Text="Headline"></asp:TableCell>
                        <asp:TableCell Width="5%" Font-Size="XX-Small" Text="View"></asp:TableCell>
                        <asp:TableCell Width="5%" Font-Size="XX-Small" Text="Deploy"></asp:TableCell>
                        <asp:TableCell Width="5%" Font-Size="XX-Small" Text="Return"></asp:TableCell>
                    </asp:TableRow>
                </asp:table></P>
            <H3>Site Content for zone :
                <asp:dropdownlist id="ddlZones" runat="server" AutoPostBack="True"></asp:dropdownlist>&nbsp;&nbsp;&nbsp;
                <asp:button id="bnUpdtRanks" runat="server" Text="Update Ranks"></asp:button></H3>
            <P><asp:table id="tblSiteContent" runat="server" GridLines="Both" CellSpacing="1" CellPadding="3">
                    <asp:TableRow BackColor="#8CD3EF">
                        <asp:TableCell Width="30%" Text="Zone"></asp:TableCell>
                        <asp:TableCell Width="50%" Text="Headline"></asp:TableCell>
                        <asp:TableCell Width="12%" Font-Size="X-Small" Text="Rank"></asp:TableCell>
                        <asp:TableCell Width="4%" Font-Size="XX-Small" Text="View"></asp:TableCell>
                        <asp:TableCell Width="4%" Font-Size="XX-Small" Text="Archive"></asp:TableCell>
                    </asp:TableRow>
                </asp:table></P>
        </form>
    </body>
</HTML>
