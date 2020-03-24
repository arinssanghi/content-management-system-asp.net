<%@ Page language="c#" Codebehind="NoteCreate.aspx.cs" AutoEventWireup="false" Inherits="CMSNET.Administration.Note.NoteCreate" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>NoteCreate</title>
        <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
        <meta name="CODE_LANGUAGE" Content="C#">
        <meta name="vs_defaultClientScript" content="JavaScript">
        <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    </HEAD>
    <body>
        <form id="NoteCreate" method="post" runat="server">
            <H2>
                <FONT color="darkslategray">
                    <asp:Label id="lbWho" runat="server"></asp:Label>
                    :&nbsp;Note Create</FONT>
            </H2>
            <P>
                <asp:ValidationSummary id="ValidationSummary1" runat="server" HeaderText="Error(s) occured while creating content"></asp:ValidationSummary>
                <TABLE cellSpacing="1" cellPadding="3" width="95%" border="1">
                    <TR>
                        <TD style="WIDTH: 8%">
                            <STRONG>Note:</STRONG>
                        </TD>
                        <TD style="WIDTH: 88%">
                            <asp:TextBox id="tbNote" runat="server" TextMode="MultiLine" Width="100%" Rows="16"></asp:TextBox>
                        </TD>
                        <TD>
                            &nbsp;
                            <asp:RequiredFieldValidator id="rfvNote" runat="server" EnableClientScript="False" ControlToValidate="tbNote" Display="Dynamic" ErrorMessage="A note must be entered.">*</asp:RequiredFieldValidator>
                        </TD>
                    </TR>
                </TABLE>
            </P>
            <asp:Button id="bnNote" runat="server" Text="Create Note"></asp:Button>
            &nbsp; <INPUT type="reset" value="Reset">&nbsp; <INPUT onclick="window.history.back()" type="button" value="Cancel">
        </form>
    </body>
</HTML>
