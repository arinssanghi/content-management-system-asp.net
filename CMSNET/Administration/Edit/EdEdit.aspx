<%@ Page language="c#" Codebehind="EdEdit.aspx.cs" AutoEventWireup="false" Inherits="CMSNET.Administration.Edit.EdEdit" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>EdEdit</title>
        <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
        <meta name="CODE_LANGUAGE" Content="C#">
        <meta name="vs_defaultClientScript" content="JavaScript">
        <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    </HEAD>
    <body>
        <form id="EdEdit" method="post" runat="server">
            <H2>
                <FONT color="darkslategray">Edit&nbsp;: Content Edit</FONT>
            </H2>
            <P>
                <asp:validationsummary id="ValSum" runat="server" HeaderText="Error(s) occured while creating content"></asp:validationsummary>
            </P>
            <P>
                <TABLE cellSpacing="1" cellPadding="1" width="95%" border="1">
                    <TR>
                        <TD style="WIDTH: 16%">
                            <STRONG>ContentID:</STRONG>
                        </TD>
                        <TD style="WIDTH: 80%">
                            <asp:label id="lbContentID" runat="server" Width="100%"></asp:label>
                        </TD>
                        <TD>
                            &nbsp;
                        </TD>
                    </TR>
                    <TR>
                        <TD style="WIDTH: 16%">
                            <STRONG>Version:</STRONG>
                        </TD>
                        <TD style="WIDTH: 80%">
                            <asp:label id="lbVersion" runat="server"></asp:label>
                        </TD>
                        <TD>
                            &nbsp;
                        </TD>
                    </TR>
                    <TR>
                        <TD style="WIDTH: 16%">
                            <STRONG>Headline:</STRONG>
                        </TD>
                        <TD style="WIDTH: 80%">
                            <asp:textbox id="tbHeadline" runat="server" Width="100%" TextMode="MultiLine"></asp:textbox>
                        </TD>
                        <TD>
                            &nbsp;
                            <asp:requiredfieldvalidator id="rfvHeadline" runat="server" EnableClientScript="False" ControlToValidate="tbHeadline" Display="Dynamic" ErrorMessage="A Headline must be entered.">*</asp:requiredfieldvalidator>
                        </TD>
                    </TR>
                    <TR>
                        <TD style="WIDTH: 16%">
                            <STRONG>Source:</STRONG>
                        </TD>
                        <TD style="WIDTH: 80%">
                            <asp:textbox id="tbSource" runat="server" Width="100%" TextMode="MultiLine"></asp:textbox>
                        </TD>
                        <TD width="100%">
                            &nbsp;
                        </TD>
                    </TR>
                    <TR>
                        <TD style="WIDTH: 16%">
                            <STRONG>Byline:</STRONG>
                        </TD>
                        <TD style="WIDTH: 80%">
                            <asp:label id="lbByline" runat="server"></asp:label>
                            <asp:label id="lbBylineNum" runat="server" Visible="False"></asp:label>
                        </TD>
                        <TD width="100%">
                            &nbsp;
                        </TD>
                    </TR>
                    <TR>
                        <TD style="WIDTH: 16%">
                            <STRONG>Teaser:</STRONG>
                        </TD>
                        <TD style="WIDTH: 80%">
                            <asp:textbox id="tbTeaser" runat="server" Width="100%" TextMode="MultiLine" Rows="4"></asp:textbox>
                        </TD>
                        <TD>
                            &nbsp;
                        </TD>
                    </TR>
                    <TR>
                        <TD style="WIDTH: 16%">
                            <STRONG>Body:</STRONG>
                        </TD>
                        <TD style="WIDTH: 80%">
                            <asp:textbox id="tbBody" runat="server" Width="100%" TextMode="MultiLine" Rows="16"></asp:textbox>
                        </TD>
                        <TD>
                            &nbsp;
                            <asp:requiredfieldvalidator id="rfvBody" runat="server" EnableClientScript="False" ControlToValidate="tbBody" Display="Dynamic" ErrorMessage="A body must be entered.">*</asp:requiredfieldvalidator>
                        </TD>
                    </TR>
                    <TR>
                        <TD style="WIDTH: 16%">
                            <STRONG>Tagline:</STRONG>
                        </TD>
                        <TD style="WIDTH: 80%">
                            <asp:textbox id="tbTagline" runat="server" Width="100%" TextMode="MultiLine"></asp:textbox>
                        </TD>
                        <TD>
                            &nbsp;
                        </TD>
                    </TR>
                    <TR>
                        <TD style="WIDTH: 16%">
                            <STRONG>Editor:</STRONG>
                        </TD>
                        <TD style="WIDTH: 80%">
                            <asp:label id="lbEditor" runat="server"></asp:label>
                            <asp:label id="lbEditorNum" runat="server" Visible="False"></asp:label>
                            &nbsp;
                        </TD>
                        <TD>
                            &nbsp;
                        </TD>
                    </TR>
                    <TR>
                        <TD style="WIDTH: 16%">
                            <STRONG>Approver:</STRONG>
                        </TD>
                        <TD style="WIDTH: 80%">
                            <asp:label id="lbApprover" runat="server"></asp:label>
                            <asp:label id="lbApproverNum" runat="server" Visible="False"></asp:label>
                            &nbsp;
                        </TD>
                        <TD>
                            &nbsp;
                        </TD>
                    </TR>
                    <TR>
                        <TD style="WIDTH: 16%">
                            <STRONG>Status:</STRONG>
                        </TD>
                        <TD style="WIDTH: 80%">
                            <asp:label id="lbStatus" runat="server"></asp:label>
                            <asp:label id="lbStatusNum" runat="server" Visible="False"></asp:label>
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
            <INPUT onclick="window.history.back()" type="button" value="Back"> &nbsp;
            <asp:button id="bnInsert" runat="server" Text="Edit to new version"></asp:button>
            &nbsp;
            <asp:button id="bnUpdate" runat="server" Text="Edit to this version"></asp:button>
            &nbsp;
            <asp:button id="bnRestore" runat="server" Text="Restore"></asp:button>
            &nbsp;
            <asp:button id="bnReturn" runat="server" Text="Return to Author for Fix"></asp:button>
        </form>
    </body>
</HTML>
