<%@ Page language="c#" Codebehind="NoteUpdate.aspx.cs" AutoEventWireup="false" Inherits="CMSNET.Administration.Note.NoteUpdate" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>NoteUpdate</title>
        <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
        <meta name="CODE_LANGUAGE" Content="C#">
        <meta name="vs_defaultClientScript" content="JavaScript">
        <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    </HEAD>
    <body>
        <form id="NoteUpdate" method="post" runat="server">
            <H2>
                <FONT color="darkslategray">
                    <asp:label id="lbWho" runat="server"></asp:label>
                    :&nbsp;Note Update</FONT>
            </H2>
            <P>
                <asp:validationsummary id="ValSum" runat="server" HeaderText="Error(s) occured while creating content"></asp:validationsummary>
            </P>
            <P>
                <TABLE cellSpacing="1" cellPadding="1" width="95%" border="1">
                    <TR>
                        <TD style="WIDTH: 16%">
                            <STRONG>Note:</STRONG>
                        </TD>
                        <TD style="WIDTH: 80%">
                            <asp:textbox id="tbNote" runat="server" Width="100%" TextMode="MultiLine" Rows="16"></asp:textbox>
                        </TD>
                        <TD>
                            &nbsp;
                            <asp:requiredfieldvalidator id="rfvNote" runat="server" EnableClientScript="False" ControlToValidate="tbNote" Display="Dynamic" ErrorMessage="A note must be entered.">*</asp:requiredfieldvalidator>
                        </TD>
                    </TR>
                    <TR>
                        <TD style="WIDTH: 16%">
                            <STRONG>Author:</STRONG>
                        </TD>
                        <TD style="WIDTH: 80%">
                            <asp:label id="lbAuthor" runat="server"></asp:label>
                            &nbsp;
                        </TD>
                        <TD>
                            &nbsp;
                        </TD>
                    </TR>
                    <TR>
                        <TD style="WIDTH: 16%">
                            <STRONG>Modified Date:</STRONG>
                        </TD>
                        <TD style="WIDTH: 80%">
                            <asp:label id="lbModifiedDate" runat="server" Width="100%"></asp:label>
                        </TD>
                        <TD>
                            &nbsp;
                        </TD>
                    </TR>
                    <TR>
                        <TD style="WIDTH: 16%">
                            <STRONG>Creation Date:</STRONG>
                        </TD>
                        <TD style="WIDTH: 80%">
                            <asp:label id="lbCreationDate" runat="server" Width="100%"></asp:label>
                        </TD>
                        <TD>
                            &nbsp;
                        </TD>
                    </TR>
                </TABLE>
            </P>
            <P>
                <INPUT onclick="window.history.back()" type="button" value="Return">&nbsp;&nbsp;
                <asp:button id="bnUpdate" runat="server" Text="Update Note"></asp:button>
                &nbsp;
                <asp:button id="bnRestore" runat="server" Text="Restore"></asp:button>
                &nbsp;
                <asp:button id="bnRemove" runat="server" Text="Remove"></asp:button>
            </P>
            <P>
                <asp:label id="lbContentID" runat="server" Visible="False"></asp:label>
            </P>
        </form>
    </body>
</HTML>
