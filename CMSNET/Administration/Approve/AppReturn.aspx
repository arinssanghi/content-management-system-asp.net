<%@ Page language="c#" Codebehind="AppReturn.aspx.cs" AutoEventWireup="false" Inherits="CMSNET.Administration.Approve.AppReturn" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>AppReturn</title>
        <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
        <meta name="CODE_LANGUAGE" Content="C#">
        <meta name="vs_defaultClientScript" content="JavaScript">
        <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    </HEAD>
    <body>
        <form id="AppReturn" method="post" runat="server">
            <H2>
                <FONT color="darkslategray">Approval&nbsp;: Return Content To Editor for Updating</FONT>&nbsp;</FONT>
            </H2>
            <P>
                <asp:label id="lbWhichHeadline" runat="server" Font-Bold="True"></asp:label>
                <BR>
                <asp:label id="lbWhichBody" runat="server" Width="75%" BorderStyle="Inset"></asp:label>
            </P>
            <P>
                Content will be return to editor for updating. Content must be resubmitted for 
                approval by the editor.
            </P>
            <P>
                Are you sure you wish to continue?
            </P>
            <P>
                <asp:button id="bnReturn" runat="server" Text="Return Content"></asp:button>
                &nbsp; <INPUT type="button" value="Cancel" onclick="window.history.back()">
            </P>
        </form>
    </body>
</HTML>
