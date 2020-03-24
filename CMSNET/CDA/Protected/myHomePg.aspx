<%@ Register TagPrefix="cmsnet" TagName="Footer" Src="../Footer.ascx" %>
<%@ Register TagPrefix="cmsnet" TagName="Logout" Src="../Logout.ascx" %>
<%@ Register TagPrefix="cmsnet" TagName="Login" Src="../Login.ascx" %>
<%@ Register TagPrefix="cmsnet" TagName="NavBar" Src="../NavBar.ascx" %>
<%@ Register TagPrefix="cmsnet" TagName="Header" Src="../Header.ascx" %>
<%@ Register TagPrefix="cmsnet" TagName="ZoneCard" Src="ZoneCard.ascx" %>
<%@ Page language="c#" Codebehind="myHomePg.aspx.cs" AutoEventWireup="false" Inherits="CMSNET.CDA.Protected.myHomePg" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>myHomePg</title>
        <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
        <meta name="CODE_LANGUAGE" Content="C#">
        <meta name="vs_defaultClientScript" content="JavaScript">
        <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    </HEAD>
    <body>
        <form id="myHomePg" method="post" runat="server">
            <TABLE cellSpacing="8" cellPadding="1" width="100%" border="0">
                <TR>
                    <TD colSpan="2">
                        <cmsnet:Header id="Header" runat="server" Level="myHome"></cmsnet:Header>
                    </TD>
                </TR>
                <TR>
                    <TD vAlign="top" width="20%" bgColor="#8cd3ef">
                        <P>
                            <BR>
                            <cmsnet:NavBar id="MainNavBar" runat="server"></cmsnet:NavBar>
                        </P>
                        <cmsnet:Logout id="ucLogout" runat="server"></cmsnet:Logout>
                        <P>
                        </P>
                    </TD>
                    <TD vAlign="top" width="80%">
                        <TABLE cellSpacing="2" cellPadding="5" width="100%" border="0">
                            <TR>
                                <TD width="50%">
                                    <TABLE cellSpacing="5" cellPadding="3" width="100%" border="0">
                                        <TR>
                                            <TD>
                                                <cmsnet:ZoneCard id="ZoneCard1" runat="server"></cmsnet:ZoneCard>
                                            </TD>
                                        </TR>
                                        <TR>
                                            <TD>
                                                <cmsnet:ZoneCard id="ZoneCard2" runat="server"></cmsnet:ZoneCard>
                                            </TD>
                                        </TR>
                                        <TR>
                                            <TD>
                                                <cmsnet:ZoneCard id="ZoneCard3" runat="server"></cmsnet:ZoneCard>
                                            </TD>
                                        </TR>
                                    </TABLE>
                                </TD>
                                <TD width="50%">
                                    <TABLE cellSpacing="5" cellPadding="3" width="100%" border="0">
                                        <TR>
                                            <TD>
                                                <cmsnet:ZoneCard id="ZoneCard4" runat="server"></cmsnet:ZoneCard>
                                            </TD>
                                        </TR>
                                        <TR>
                                            <TD>
                                                <cmsnet:ZoneCard id="ZoneCard5" runat="server"></cmsnet:ZoneCard>
                                            </TD>
                                        </TR>
                                        <TR>
                                            <TD>
                                                <cmsnet:ZoneCard id="ZoneCard6" runat="server"></cmsnet:ZoneCard>
                                            </TD>
                                        </TR>
                                    </TABLE>
                                </TD>
                            </TR>
                        </TABLE>
                    </TD>
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
