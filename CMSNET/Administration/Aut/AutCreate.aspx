<%@ Page language="c#" Codebehind="AutCreate.aspx.cs" AutoEventWireup="false" Inherits="CMSNET.Administration.AUT.AutCreate" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>AutCreate</title>
        <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
        <meta name="CODE_LANGUAGE" Content="C#">
        <meta name="vs_defaultClientScript" content="JavaScript">
        <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    </HEAD>
    <body>
        <form id="AutCreate" method="post" runat="server">
            <H2><FONT color="darkslategray">Author : Content Create</FONT></H2>
            <P>
                <asp:ValidationSummary id="ValidationSummary1" runat="server" HeaderText="Error(s) occured while creating content"></asp:ValidationSummary>
                <TABLE cellSpacing="1" cellPadding="3" width="95%" border="1">
                    <TR>
                        <TD style="WIDTH: 16%"><STRONG>Headline:</STRONG></TD>
                        <TD style="WIDTH: 80%">
                            <asp:TextBox id="tbHeadline" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox></TD>
                        <TD>&nbsp;
                            <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" EnableClientScript="False" ControlToValidate="tbHeadline" Display="Dynamic" ErrorMessage="A Headline must be entered.">*</asp:RequiredFieldValidator></TD>
                    </TR>
                    <TR>
                        <TD style="WIDTH: 16%"><STRONG>Source:</STRONG></TD>
                        <TD style="WIDTH: 80%">
                            <asp:TextBox id="tbSource" runat="server" Width="100%" TextMode="MultiLine"></asp:TextBox></TD>
                        <TD>&nbsp;</TD>
                    </TR>
                    <TR>
                        <TD style="WIDTH: 16%"><STRONG>Teaser:</STRONG></TD>
                        <TD style="WIDTH: 80%">
                            <asp:TextBox id="tbTeaser" runat="server" TextMode="MultiLine" Width="100%" Rows="4"></asp:TextBox></TD>
                        <TD>&nbsp;</TD>
                    </TR>
                    <TR>
                        <TD style="WIDTH: 16%"><STRONG>Body:</STRONG></TD>
                        <TD style="WIDTH: 80%">
                            <asp:TextBox id="tbBody" runat="server" TextMode="MultiLine" Width="100%" Rows="12"></asp:TextBox></TD>
                        <TD>&nbsp;
                            <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" EnableClientScript="False" ControlToValidate="tbBody" Display="Dynamic" ErrorMessage="A body must be entered.">*</asp:RequiredFieldValidator></TD>
                    </TR>
                    <TR>
                        <TD style="WIDTH: 16%"><STRONG>Tagline:</STRONG></TD>
                        <TD style="WIDTH: 80%">
                            <asp:TextBox id="tbTagline" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox></TD>
                        <TD>&nbsp;</TD>
                    </TR>
                </TABLE>
            </P>
            <asp:Button id="bnNext" runat="server" Text="Create Content"></asp:Button>&nbsp;
            <INPUT type="reset" value="Reset">&nbsp; <INPUT onclick="window.history.back()" type="button" value="Cancel">
        </form>
    </body>
</HTML>
