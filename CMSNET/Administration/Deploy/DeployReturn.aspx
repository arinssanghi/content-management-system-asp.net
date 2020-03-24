<%@ Page language="c#" Codebehind="DeployReturn.aspx.cs" AutoEventWireup="false" Inherits="CMSNET.Administration.Deploy.DeployReturn" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>DeployReturn</title>
        <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
        <meta name="CODE_LANGUAGE" Content="C#">
        <meta name="vs_defaultClientScript" content="JavaScript">
        <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    </HEAD>
    <body>
        <form id="DeployReturn" method="post" runat="server">
            <H2><FONT color="darkslategray">Deploy&nbsp;: Content Return</FONT></H2>
            <P>
                <asp:label id="lbWhichHeadline" runat="server" Font-Bold="True"></asp:label><BR>
                <asp:label id="lbWhichBody" runat="server" Width="75%" BorderStyle="Inset"></asp:label></P>
            <P>
                Return content to submitter as it needs updating.</P>
            <P>
                <asp:button id="bnReturn" runat="server" Text="Return Content"></asp:button>&nbsp;
                <INPUT type="button" value="Cancel" onclick="window.history.back()">
            </P>
        </form>
    </body>
</HTML>
