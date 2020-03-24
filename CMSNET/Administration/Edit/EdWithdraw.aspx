<%@ Page language="c#" Codebehind="EdWithdraw.aspx.cs" AutoEventWireup="false" Inherits="CMSNET.Administration.Edit.EdWithdraw" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>EdWithdraw</title>
        <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
        <meta name="CODE_LANGUAGE" Content="C#">
        <meta name="vs_defaultClientScript" content="JavaScript">
        <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    </HEAD>
    <body>
        <form id="EdWithdraw" method="post" runat="server">
            <H2>
                <FONT color="darkslategray">Editor&nbsp;:&nbsp;Withdraw As Content Editor</FONT>
            </H2>
            <P>
                <asp:label id="lbWhichHeadline" runat="server" Font-Bold="True"></asp:label>
                <BR>
                <asp:label id="lbWhichBody" runat="server" Width="75%" BorderStyle="Inset"></asp:label>
            </P>
            <P>
                After&nbsp;withdrawing&nbsp;you will no longer be&nbsp;the editor of this 
                content and any other editor can take over (Including yourself).
            </P>
            <P>
                Are you sure you wish to continue?
            </P>
            <P>
                <asp:button id="bnWithdraw" runat="server" Text="Withdraw As Editor"></asp:button>
                &nbsp; <INPUT type="button" value="Cancel" onclick="window.history.back()">
            </P>
        </form>
    </body>
</HTML>
