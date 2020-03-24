<%@ Page language="c#" Codebehind="admAcntRemove.aspx.cs" AutoEventWireup="false" Inherits="CMSNET.Administration.AdmAcnt.admAcntRemove" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>admAcntRemove</title>
        <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
        <meta name="CODE_LANGUAGE" Content="C#">
        <meta name="vs_defaultClientScript" content="JavaScript">
        <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    </HEAD>
    <body>
        <form id="admAcntRemove" method="post" runat="server">
            <H2><FONT color="darkslategray"><FONT color="darkslategray">Administrator: Account </FONT>
                    Removal</FONT></H2>
            <P>
                <TABLE cellSpacing="1" cellPadding="3" width="300" border="1">
                    <TR>
                        <TD><STRONG>UserID:</STRONG></TD>
                        <TD width="70%">
                            <asp:Label id="lbUserID" runat="server" Width="100%"></asp:Label></TD>
                    </TR>
                    <TR>
                        <TD><STRONG>UserName:</STRONG></TD>
                        <TD>
                            <asp:Label id="lbUserName" runat="server" Width="100%"></asp:Label></TD>
                    </TR>
                    <TR>
                        <TD><STRONG>Email:</STRONG></TD>
                        <TD>
                            <asp:Label id="lbEmail" runat="server" Width="100%"></asp:Label></TD>
                    </TR>
                </TABLE>
            </P>
            <P><B>Warning:</B> This will permanently remove this account. Are you really sure 
                you want to do this?</P>
            <P>
                <asp:button id="bnRemove" runat="server" Text="Remove Account"></asp:button>&nbsp;
                <INPUT onclick="window.history.back()" type="button" value="Cancel">
            </P>
        </form>
    </body>
</HTML>
