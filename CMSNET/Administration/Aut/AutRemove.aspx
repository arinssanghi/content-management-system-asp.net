<%@ Page language="c#" Codebehind="AutRemove.aspx.cs" AutoEventWireup="false" Inherits="CMSNET.Administration.AUT.AutRemove" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>AutRemove</title>
        <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
        <meta name="CODE_LANGUAGE" Content="C#">
        <meta name="vs_defaultClientScript" content="JavaScript">
        <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    </HEAD>
    <body>
        <form id="AutRemove" method="post" runat="server">
            <H2><FONT color="darkslategray">Author : Content Removal</FONT></H2>
            <P><asp:label id="lbWhichHeadline" runat="server" Font-Bold="True"></asp:label><BR>
                <asp:label id="lbWhichBody" runat="server" Width="75%" BorderStyle="Inset"></asp:label></P>
            <P><B>Warning:</B> This will permanently remove this version of the content. Are 
                you really sure you want to do this?</P>
            <P><asp:button id="bnRemove" runat="server" Text="Remove Content"></asp:button>&nbsp;
                <INPUT type="button" value="Cancel" onclick="window.history.back()">
            </P>
        </form>
    </body>
</HTML>
