<%@ Page language="c#" Codebehind="ContentPg.aspx.cs" AutoEventWireup="false" Inherits="CMSNET.CDA.ContentPg" %>
<%@ Register TagPrefix="cmsnet" TagName="Footer" Src="Footer.ascx" %>
<%@ Register TagPrefix="cmsnet" TagName="NavBar" Src="NavBar.ascx" %>
<%@ Register TagPrefix="cmsnet" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="cmsnet" TagName="Login" Src="Login.ascx" %>
<%@ Register TagPrefix="cmsnet" TagName="Logout" Src="Logout.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>CMS.NET -- Content/Domain Page</title>
        <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
        <meta name="CODE_LANGUAGE" Content="C#">
        <meta name="vs_defaultClientScript" content="JavaScript">
        <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    </HEAD>
    <body>
        <form id="ContentPg" method="post" runat="server">
            <TABLE cellSpacing="8" cellPadding="1" width="100%" border="0">
                <TR>
                    <TD colSpan="2">
                        <cmsnet:Header id="Header" Level="domain" runat="server"></cmsnet:Header>
                    </TD>
                </TR>
                <TR>
                    <TD width="20%" bgColor="#8cd3ef" valign="top">
                        <P>
                            <br>
                            <cmsnet:NavBar id="MainNavBar" runat="server"></cmsnet:NavBar>
                        </P>
                        <P>&nbsp;</P>
                        <P>
                            <cmsnet:Login id="ucLogin" runat="server" Visible="False"></cmsnet:Login>
                            <cmsnet:Logout id="ucLogout" runat="server" Visible="False"></cmsnet:Logout>
                        </P>
                        <P>&nbsp;</P>
                    </TD>
                    <td width="80%" vAlign="top">
                        <H1>
                            <asp:Label id="lbDomain" runat="server" ForeColor="DarkSlateGray"></asp:Label>
                        </H1>
                        <P>
                            <asp:Table id="tblDomHeadlines" runat="server" CellPadding="8" Width="100%">
                                <asp:TableRow>
                                    <asp:TableCell Width="50%" ID="tcLeft"></asp:TableCell>
                                    <asp:TableCell Width="50%" ID="tcRight"></asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </P>
                    </td>
                </TR>
                <TR>
                    <TD colSpan="2">
                        <cmsnet:Footer id="Footer" runat="server"></cmsnet:Footer>
                    </TD>
                </TR>
            </TABLE>
        </form>
    </body>
</HTML>
