<%@ Page language="c#" Codebehind="EdSubmit.aspx.cs" AutoEventWireup="false" Inherits="CMSNET.Administration.Edit.EdSubmit" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>EdSubmit</title>
        <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
        <meta name="CODE_LANGUAGE" Content="C#">
        <meta name="vs_defaultClientScript" content="JavaScript">
        <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    </HEAD>
    <body>
        <form id="EdSubmit" method="post" runat="server">
            <H2>
                <FONT color="darkslategray">Editor&nbsp;: Content Submittal</FONT>
            </H2>
            <P>
                <asp:label id="lbWhichHeadline" runat="server" Font-Bold="True"></asp:label>
                <BR>
                <asp:label id="lbWhichBody" runat="server" Width="75%" BorderStyle="Inset"></asp:label>
            </P>
            <P>
                After&nbsp;submitting this content, you will no longer be able to edit it. To 
                enable editing, you must request, from your approver, that the content be 
                returned to you.
            </P>
            <P>
                Are you sure you wish to continue?
            </P>
            <P>
                <asp:button id="bnSubmit" runat="server" Text="Submit Content"></asp:button>
                &nbsp; <INPUT type="button" value="Cancel" onclick="window.history.back()">
            </P>
        </form>
    </body>
</HTML>
