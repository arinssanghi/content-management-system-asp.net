<%@ Page language="c#" Codebehind="NoteRemove.aspx.cs" AutoEventWireup="false" Inherits="CMSNET.Administration.Note.NoteRemove" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>NoteRemove</title>
        <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
        <meta name="CODE_LANGUAGE" Content="C#">
        <meta name="vs_defaultClientScript" content="JavaScript">
        <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    </HEAD>
    <body>
        <form id="NoteRemove" method="post" runat="server">
            <H2>
                <FONT color="darkslategray">
                    <asp:Label id="lbWho" runat="server"></asp:Label>
                    :&nbsp;Note Removal</FONT>
            </H2>
            <P>
                <asp:label id="lbWhichNote" runat="server" Width="75%" BorderStyle="Inset"></asp:label>
            </P>
            <P>
                <B>Warning:</B> This will permanently remove this note. Are you really sure you 
                want to do this?
            </P>
            <P>
                <asp:button id="bnRemove" runat="server" Text="Remove Note"></asp:button>
                &nbsp; <INPUT type="button" value="Cancel" onclick="window.history.back()">
            </P>
            <P>
                <asp:Label id="lbContentID" runat="server" Visible="False"></asp:Label>
            </P>
        </form>
    </body>
</HTML>
