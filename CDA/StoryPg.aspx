<%@ Register TagPrefix="cmsnet" TagName="HeadlineTeaser" Src="HeadlineTeaser.ascx" %>
<%@ Register TagPrefix="cmsnet" TagName="Login" Src="Login.ascx" %>
<%@ Register TagPrefix="cmsnet" TagName="Logout" Src="Logout.ascx" %>
<%@ Register TagPrefix="cmsnet" TagName="Footer" Src="Footer.ascx" %>
<%@ Register TagPrefix="cmsnet" TagName="NavBar" Src="NavBar.ascx" %>
<%@ Register TagPrefix="cmsnet" TagName="Header" Src="Header.ascx" %>
<%@ Page language="c#" Codebehind="StoryPg.aspx.cs" AutoEventWireup="false" Inherits="CMSNET.CDA.StoryPg" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>CMS.NET -- Story Page</title>
        <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
        <meta name="CODE_LANGUAGE" Content="C#">
        <meta name="vs_defaultClientScript" content="JavaScript">
        <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    </HEAD>
    <body>
        <form id="StoryPg" method="post" runat="server">
            <TABLE cellSpacing="8" cellPadding="1" width="100%" border="0">
                <TR>
                    <TD colSpan="2">
                        <cmsnet:header id="Header" style="LEFT: 1px; TOP: 2px" runat="server" Level="story"></cmsnet:header>
                    </TD>
                </TR>
                <TR>
                    <TD vAlign="top" width="20%" bgColor="#8cd3ef">
                        <P>
                            <BR>
                            <cmsnet:navbar id="MainNavBar" runat="server"></cmsnet:navbar>
                        </P>
                        <P>&nbsp;</P>
                        <P>
                            <cmsnet:Login id="ucLogin" runat="server" Visible="False"></cmsnet:Login>
                            <cmsnet:Logout id="ucLogout" runat="server" Visible="False"></cmsnet:Logout>
                        </P>
                        <P>&nbsp;</P>
                    </TD>
                    </FONT>
                    <TD width="80%" valign="top">
                        <FONT color="darkslategray">
                            <P>
                                <asp:label id="lbHeadline" runat="server" Font-Size="Large"></asp:label>
                            </P>
                            <P>
                                <STRONG>
                                    <asp:Label id="lbSource" runat="server"></asp:Label>
                                </STRONG>
                            </P>
                            <P>
                        </FONT>
                        <asp:label id="lbBy" runat="server" Font-Size="Smaller">by</asp:label>
                        &nbsp;<asp:label id="lbByline" runat="server" Font-Size="Smaller"></asp:label>&nbsp;<asp:label id="lbDashes" runat="server" Font-Size="Smaller">--</asp:label>&nbsp;<asp:label id="lbDate" runat="server" Font-Size="Smaller"></asp:label>
                        </P>
                        <P>
                            <asp:label id="lbTeaser" runat="server"></asp:label>
                        </P>
                        <P>
                            <asp:label id="lbBody" runat="server"></asp:label>
                        </P>
                        <EM><FONT size="2">
                                <P>
                                    <asp:label id="lbTagline" runat="server"></asp:label>
                                </P>
                            </FONT></EM>
                    </TD>
                </TR>
                <TR>
                    <TD colSpan="2">
                        <cmsnet:footer id="Footer" runat="server"></cmsnet:footer>
                    </TD>
                </TR>
            </TABLE>
        </form>
    </body>
</HTML>
