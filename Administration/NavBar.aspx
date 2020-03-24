<%@ Page language="c#" Codebehind="NavBar.aspx.cs" AutoEventWireup="false" Inherits="CMSNET.Administration.CMA.NavBar" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>NavBar</title>
        <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
        <meta name="CODE_LANGUAGE" Content="C#">
        <meta name="vs_defaultClientScript" content="JavaScript">
        <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    </HEAD>
    <body bgColor="#8cd3ef">
        <form id="Menu" method="post" runat="server">
            <P>
                <asp:Table id="tblMenu" runat="server" Font-Bold="True"></asp:Table></P>
            <P><IMG hspace="3" src="Images/blank.gif" width="11">
                <asp:Button id="bnLogout" runat="server" Text="Logout"></asp:Button></P>
        </form>
    </body>
</HTML>
