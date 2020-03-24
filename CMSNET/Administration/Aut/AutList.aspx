<%@ Page language="c#" Codebehind="AutList.aspx.cs" AutoEventWireup="false" Inherits="CMSNET.Administration.AUT.AutList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>AutList</title>
        <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
        <meta name="CODE_LANGUAGE" Content="C#">
        <meta name="vs_defaultClientScript" content="JavaScript">
        <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    </HEAD>
    <body>
        <form id="AutList" method="post" runat="server">
            <H2>
                <FONT color="darkslategray">Author : Content List</FONT>
            </H2>
            <P>
                <STRONG>Which Content: </STRONG>
                <asp:dropdownlist id="ddlWhichContent" runat="server" AutoPostBack="True">
                    <asp:ListItem Value="0">Currently Being Created</asp:ListItem>
                    <asp:ListItem Value="1">Currently Creating or Editing</asp:ListItem>
                    <asp:ListItem Value="2">All Written by</asp:ListItem>
                </asp:dropdownlist>
                &nbsp;
            </P>
            <P>
                <asp:table id="tblView" runat="server" CellSpacing="1" CellPadding="3" GridLines="Both">
                    <asp:TableRow BackColor="#8CD3EF">
                        <asp:TableCell Width="5%" HorizontalAlign="Center" Text="ID"></asp:TableCell>
                        <asp:TableCell Width="5%" Font-Size="X-Small" HorizontalAlign="Center" Text="Ver"></asp:TableCell>
                        <asp:TableCell Width="72%" HorizontalAlign="Center" Text="Headline"></asp:TableCell>
                        <asp:TableCell Width="10%" Font-Size="X-Small" HorizontalAlign="Center" Text="Status"></asp:TableCell>
                        <asp:TableCell Width="2%" Font-Size="XX-Small" HorizontalAlign="Center" Text="View"></asp:TableCell>
                        <asp:TableCell Font-Size="XX-Small" Text="&amp;nbsp;Notes&amp;nbsp;"></asp:TableCell>
                        <asp:TableCell Width="2%" Font-Size="XX-Small" HorizontalAlign="Center" Text="Updt"></asp:TableCell>
                        <asp:TableCell Width="2%" Font-Size="XX-Small" HorizontalAlign="Center" Text="Sub"></asp:TableCell>
                        <asp:TableCell Width="2%" Font-Size="XX-Small" HorizontalAlign="Center" Text="Del"></asp:TableCell>
                    </asp:TableRow>
                </asp:table>
            </P>
        </form>
    </body>
</HTML>
