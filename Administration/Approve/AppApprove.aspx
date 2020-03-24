<%@ Page language="c#" Codebehind="AppApprove.aspx.cs" AutoEventWireup="false" Inherits="CMSNET.Administration.Approve.AppApprove" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>AppApprove</title>
        <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
        <meta name="CODE_LANGUAGE" Content="C#">
        <meta name="vs_defaultClientScript" content="JavaScript">
        <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    </HEAD>
    <body>
        <form id="AppApprove" method="post" runat="server">
            <H2>
                <FONT color="darkslategray">Approval&nbsp;: Content Approval</FONT>
            </H2>
            <P>
                <asp:label id="lbWhichHeadline" runat="server" Font-Bold="True"></asp:label>
                <BR>
                <asp:label id="lbWhichBody" runat="server" Width="75%" BorderStyle="Inset"></asp:label>
            </P>
            <P>
                After approving this content, it will be available to be deployed on the web 
                site. To enable editing, you must request, from your deployer, that the content 
                be returned to the editor.
            </P>
            <P>
                Are you sure you wish to continue?
            </P>
            <P>
                <asp:button id="bnApprove" runat="server" Text="Approve Content"></asp:button>
                &nbsp; <INPUT type="button" value="Cancel" onclick="window.history.back()">
            </P>
        </form>
    </body>
</HTML>
