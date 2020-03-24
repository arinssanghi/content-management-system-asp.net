<%@ Page language="c#" Codebehind="setup.aspx.cs" AutoEventWireup="false" Inherits="CMSNET.Setup.setup" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>setup</title>
        <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
        <meta name="CODE_LANGUAGE" Content="C#">
        <meta name="vs_defaultClientScript" content="JavaScript">
        <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    </HEAD>
    <body>
        <form id="setup" method="post" runat="server">
            <p><IMG height="32" src="Images/setup.jpg"></p>
            <hr width="100%" size="1">
            <p><b>Welcome to the CMS.NET Setup</b></p>
            <p>It has been detected that your system needs to be setup for CMS.NET. This tool 
                will guide you through the configuration of your database and the setting up of 
                an administrator account. After completing the setup, you will then be able to 
                use CMS.NET Administration&nbsp;to build your own site.</p>
            <p>If you encounter problems with the setup process, please report them to <A href="mailto:info@contentmgr.com">
                    info@contentmgr.com</A>.</p>
            <p>
            If you would like to return here at some point in the future after completing 
            the intial setup, change the value of the setup key to false, like this:
            <p><b><code>&lt;add key="setup" value= "false" \&gt; </code></b>
            <p>in the <code><strong>&lt;appsettings&gt;</strong></code> element of 
                CMS.NET's&nbsp;Web.config file.
            </p>
            <p align="center">
                <asp:Button id="bnContinue" runat="server" Text="Continue"></asp:Button></p>
            <hr width="100%" size="1">
            <p align="center">
                <asp:HyperLink id="HyperLink2" runat="server" Font-Size="XX-Small" NavigateUrl="http://www.contentmgr.com">www.contentmgr.com</asp:HyperLink></p>
        </form>
    </body>
</HTML>
