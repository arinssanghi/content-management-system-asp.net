<%@ Page language="c#" Codebehind="AdmAcntList.aspx.cs" AutoEventWireup="false" Inherits="CMSNET.Administration.AdmAcnt.AdmAcntList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>AdmAcntList</title>
        <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
        <meta name="CODE_LANGUAGE" Content="C#">
        <meta name="vs_defaultClientScript" content="JavaScript">
        <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    </HEAD>
    <body>
        <form id="AdmAcntList" method="post" runat="server">
            <H2><FONT color="darkslategray">Administrator: Account List</FONT></H2>
            <P>
                <asp:table id="tblView" runat="server" GridLines="Both" CellPadding="3" CellSpacing="1">
                    <asp:TableRow BackColor="#8CD3EF">
                        <asp:TableCell Width="20%" HorizontalAlign="Center" Text="User ID"></asp:TableCell>
                        <asp:TableCell Width="34%" HorizontalAlign="Center" Text="User Name"></asp:TableCell>
                        <asp:TableCell Width="40%" HorizontalAlign="Center" Text="Email"></asp:TableCell>
                        <asp:TableCell Width="2%" Font-Size="XX-Small" HorizontalAlign="Center" Text="View"></asp:TableCell>
                        <asp:TableCell Width="2%" Font-Size="XX-Small" HorizontalAlign="Center" Text="Updt"></asp:TableCell>
                        <asp:TableCell Width="2%" Font-Size="XX-Small" HorizontalAlign="Center" Text="Del"></asp:TableCell>
                    </asp:TableRow>
                </asp:table></P>
        </form>
    </body>
</HTML>
