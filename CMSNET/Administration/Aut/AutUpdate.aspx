<%@ Page language="c#" Codebehind="AutUpdate.aspx.cs" AutoEventWireup="false" Inherits="CMSNET.Administration.AUT.AutUpdate" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>AutUpdate</title>
        <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
        <meta name="CODE_LANGUAGE" Content="C#">
        <meta name="vs_defaultClientScript" content="JavaScript">
        <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    </HEAD>
    <body>
        <form id="AutUpdate" method="post" runat="server">
            <H2>
                <FONT color="darkslategray">Author : Content Update</FONT>
            </H2>
            <P>
                <asp:ValidationSummary id="ValSum" runat="server" HeaderText="Error(s) occured while creating content"></asp:ValidationSummary>
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
                            <asp:Label id="lbVersion" runat="server"></asp:Label>
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
                            <asp:TextBox id="tbHeadline" runat="server" Width="100%" TextMode="MultiLine"></asp:TextBox>
                        </TD>
                        <TD>
                            &nbsp;
                            <asp:RequiredFieldValidator id="rfvHeadline" runat="server" ErrorMessage="A Headline must be entered." Display="Dynamic" ControlToValidate="tbHeadline" EnableClientScript="False">*</asp:RequiredFieldValidator>
                        </TD>
                    </TR>
                    <TR>
                        <TD style="WIDTH: 16%">
                            <STRONG>Source:</STRONG>
                        </TD>
                        <TD style="WIDTH: 80%">
                            <asp:TextBox id="tbSource" runat="server" Width="100%" TextMode="MultiLine"></asp:TextBox>
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
                            <asp:Label id="lbBylineNum" runat="server" Visible="False"></asp:Label>
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
                            <asp:TextBox id="tbTeaser" runat="server" Width="100%" TextMode="MultiLine" Rows="4"></asp:TextBox>
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
                            <asp:TextBox id="tbBody" runat="server" Width="100%" TextMode="MultiLine" Rows="16"></asp:TextBox>
                        </TD>
                        <TD>
                            &nbsp;
                            <asp:RequiredFieldValidator id="rfvBody" runat="server" ErrorMessage="A body must be entered." Display="Dynamic" ControlToValidate="tbBody" EnableClientScript="False">*</asp:RequiredFieldValidator>
                        </TD>
                    </TR>
                    <TR>
                        <TD style="WIDTH: 16%">
                            <STRONG>Tagline:</STRONG>
                        </TD>
                        <TD style="WIDTH: 80%">
                            <asp:TextBox id="tbTagline" runat="server" Width="100%" TextMode="MultiLine"></asp:TextBox>
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
                            <asp:Label id="lbEditor" runat="server"></asp:Label>
                            <asp:Label id="lbEditorNum" runat="server" Visible="False"></asp:Label>
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
                            <asp:Label id="lbApprover" runat="server"></asp:Label>
                            <asp:Label id="lbApproverNum" runat="server" Visible="False"></asp:Label>
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
                            <asp:Label id="lbStatus" runat="server"></asp:Label>
                            <asp:Label id="lbStatusNum" runat="server" Visible="False"></asp:Label>
                        </TD>
                        <TD>
                        </TD>
                    </TR>
                    <TR>
                        <TD style="WIDTH: 16%">
                            <STRONG>Modified Date:</STRONG>
                        </TD>
                        <TD style="WIDTH: 80%">
                            <asp:Label id="lbModifiedDate" runat="server" Width="100%"></asp:Label>
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
                            <asp:Label id="lbCreationDate" runat="server" Width="100%"></asp:Label>
                        </TD>
                        <TD>
                            &nbsp;
                        </TD>
                    </TR>
                </TABLE>
            </P>
            <INPUT type="button" value="Back" onclick="window.history.back()">&nbsp;
            <asp:Button id="bnInsert" runat="server" Text="Update with new version"></asp:Button>
            &nbsp;
            <asp:Button id="bnUpdate" runat="server" Text="Update this version"></asp:Button>
            &nbsp;
            <asp:Button id="bnRestore" runat="server" Text="Restore"></asp:Button>
            &nbsp;
            <asp:Button id="bnRemove" runat="server" Text="Remove"></asp:Button>
        </form>
    </body>
</HTML>
