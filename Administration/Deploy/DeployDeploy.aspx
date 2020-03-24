<%@ Page language="c#" Codebehind="DeployDeploy.aspx.cs" AutoEventWireup="false" Inherits="CMSNET.Administration.Deploy.DeployDeploy" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>DeployDeploy</title>
        <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
        <meta name="CODE_LANGUAGE" Content="C#">
        <meta name="vs_defaultClientScript" content="JavaScript">
        <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    </HEAD>
    <body>
        <form id="DeployDeploy" method="post" runat="server">
            <H2><FONT color="darkslategray">Deploy&nbsp;: Content Deployment</FONT></H2>
            <P>
                <asp:label id="tbWhichHeadline" runat="server" Font-Bold="True"></asp:label><BR>
                <asp:label id="tbWhichBody" runat="server" Width="75%" BorderStyle="Inset"></asp:label></P>
            <H3>Zones to deploy in :</H3>
            <P><FONT size="2">(Select role or ctrl click to select more than one role)<BR>
                </FONT>
                <asp:ListBox id="lbZones" runat="server" Width="40%" SelectionMode="Multiple"></asp:ListBox></P>
            <P>
                <asp:button id="bnDeploy" runat="server" Text="Deploy Content"></asp:button>&nbsp;
                <INPUT type="button" value="Cancel" onclick="window.history.back()">
            </P>
        </form>
    </body>
</HTML>
