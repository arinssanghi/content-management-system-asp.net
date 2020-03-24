<%@ Page language="c#" Codebehind="DeployArchive.aspx.cs" AutoEventWireup="false" Inherits="CMSNET.Administration.Deploy.DeployArchive" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>DeployArchive</title>
        <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
        <meta name="CODE_LANGUAGE" Content="C#">
        <meta name="vs_defaultClientScript" content="JavaScript">
        <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    </HEAD>
    <body>
        <form id="DeployArchive" method="post" runat="server">
            <H2><FONT color="darkslategray">Deploy&nbsp;: Content Archival</FONT></H2>
            <P>
                <asp:label id="lbWhichHeadline" runat="server" Font-Bold="True"></asp:label><BR>
                <asp:label id="lbWhichBody" runat="server" Width="75%" BorderStyle="Inset"></asp:label></P>
            <P>Normally, archiving would make the content accessable to searches. But for now 
                the archive process will simply remove the content from the web site. (It sets 
                the the status to submitted again as well.)</P>
            <P>
                <asp:button id="bnArchive" runat="server" Text="Archive Content"></asp:button>&nbsp;
                <INPUT type="button" value="Cancel" onclick="window.history.back()">
            </P>
        </form>
    </body>
</HTML>
