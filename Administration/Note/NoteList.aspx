<%@ Page language="c#" Codebehind="NoteList.aspx.cs" AutoEventWireup="false" Inherits="CMSNET.Administration.Note.NoteList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>NoteList</title>
        <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
        <meta name="CODE_LANGUAGE" Content="C#">
        <meta name="vs_defaultClientScript" content="JavaScript">
        <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    </HEAD>
    <body>
        <form id="NoteList" method="post" runat="server">
            <H2>
                <FONT color="darkslategray">
                    <asp:Label id="lbWho" runat="server"></asp:Label>
                    : Notes&nbsp;List</FONT>
            </H2>
            <P align="right">
                <asp:button id="bnCreate" runat="server" Text="Create A Note"></asp:button>
            </P>
            <P>
                <asp:table id="tblView" runat="server" GridLines="Both" CellPadding="3" CellSpacing="1" Width="100%">
                    <asp:TableRow BackColor="#8CD3EF">
                        <asp:TableCell Width="20%" HorizontalAlign="Center" Text="Date"></asp:TableCell>
                        <asp:TableCell Width="20%" HorizontalAlign="Center" Text="Author"></asp:TableCell>
                        <asp:TableCell Width="51%" HorizontalAlign="Center" Text="Note"></asp:TableCell>
                        <asp:TableCell Width="3%" Font-Size="XX-Small" HorizontalAlign="Center" Text="View"></asp:TableCell>
                        <asp:TableCell Width="3%" Font-Size="XX-Small" HorizontalAlign="Center" Text="Updt"></asp:TableCell>
                        <asp:TableCell Width="3%" Font-Size="XX-Small" HorizontalAlign="Center" Text="Del"></asp:TableCell>
                    </asp:TableRow>
                </asp:table>
            </P>
            <P>
                <asp:Button id="bnReturn" runat="server" Text="Return"></asp:Button>
            </P>
        </form>
    </body>
</HTML>
