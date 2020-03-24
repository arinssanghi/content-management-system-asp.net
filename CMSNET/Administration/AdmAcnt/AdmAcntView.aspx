<%@ Page language="c#" Codebehind="AdmAcntView.aspx.cs" AutoEventWireup="false" Inherits="CMSNET.Administration.AdmAcnt.AdmAcntView" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>AdmAcntView</title>
        <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
        <meta name="CODE_LANGUAGE" Content="C#">
        <meta name="vs_defaultClientScript" content="JavaScript">
        <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    </HEAD>
    <body>
        <form id="AdmAcntView" method="post" runat="server">
            <H2><FONT color="darkslategray"><FONT color="darkslategray">Administrator: Account </FONT>
                    View</FONT></H2>
            <H3>Account Information:</H3>
            <P>
                <TABLE cellSpacing="1" cellPadding="3" width="300" border="1">
                    <TR>
                        <TD><STRONG>UserID:</STRONG></TD>
                        <TD width="70%"><asp:label id="lbUserID" runat="server" Width="100%"></asp:label></TD>
                    </TR>
                    <TR>
                        <TD><STRONG>UserName:</STRONG></TD>
                        <TD><asp:label id="lbUserName" runat="server" Width="100%"></asp:label></TD>
                    </TR>
                    <TR>
                        <TD><STRONG>Email:</STRONG></TD>
                        <TD><asp:label id="lbEmail" runat="server" Width="100%"></asp:label></TD>
                    </TR>
                </TABLE>
            </P>
            <H3>Roles:</H3>
            <P>
                <asp:ListBox id="lbRoles" runat="server" Width="40%"></asp:ListBox></P>
            <P>&nbsp; <INPUT onclick="window.history.back()" type="button" value="Return">&nbsp;
                <asp:Button id="bnUpdate" runat="server" Text="Update"></asp:Button>&nbsp;
                <asp:Button id="bnRemove" runat="server" Text="Remove"></asp:Button>
            </P>
        </form>
    </body>
</HTML>
