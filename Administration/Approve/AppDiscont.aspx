<%@ Page language="c#" Codebehind="AppDiscont.aspx.cs" AutoEventWireup="false" Inherits="CMSNET.Administration.Approve.AppDiscont" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>AppDiscont</title>
        <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
        <meta name="CODE_LANGUAGE" Content="C#">
        <meta name="vs_defaultClientScript" content="JavaScript">
        <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    </HEAD>
    <body>
        <form id="AppDiscont" method="post" runat="server">
            <H2>
                <FONT color="darkslategray">Approval&nbsp;: Content&nbsp;Discontinued</FONT>&nbsp;</FONT>
            </H2>
            <P>
                <asp:label id="lbWhichHeadline" runat="server" Font-Bold="True"></asp:label>
                <BR>
                <asp:label id="lbWhichBody" runat="server" Width="75%" BorderStyle="Inset"></asp:label>
            </P>
            <P>
                Content will be&nbsp;discontinued and will not be available for further 
                updates.
            </P>
            <P>
                Message to Editor for reason content was discontinued:
            </P>
            <P>
                <asp:TextBox id="tbEdReason" runat="server" Width="60%" TextMode="MultiLine" Rows="3"></asp:TextBox>
            </P>
            <P>
                Message to Author for reason content was discontinued:
            </P>
            <P>
                <asp:TextBox id="tbAutReason" runat="server" Width="60%" TextMode="MultiLine" Rows="3"></asp:TextBox>
            </P>
            <P>
                Are you sure you wish to continue?
            </P>
            <P>
                <asp:button id="bnReturn" runat="server" Text="Discontinue Content"></asp:button>
                &nbsp; <INPUT type="button" value="Cancel" onclick="window.history.back()">
            </P>
        </form>
    </body>
</HTML>
