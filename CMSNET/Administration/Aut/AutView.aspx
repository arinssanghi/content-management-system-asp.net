<%@ Page language="c#" Codebehind="AutView.aspx.cs" AutoEventWireup="false" Inherits="CMSNET.Administration.AUT.AutView" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>AutView</title>
        <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
        <meta name="CODE_LANGUAGE" Content="C#">
        <meta name="vs_defaultClientScript" content="JavaScript">
        <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    </HEAD>
    <body>
        <form id="AutView" method="post" runat="server">
            <H2>
                <FONT color="darkslategray">Author : Content View</FONT>
            </H2>
            <P>
                <TABLE cellSpacing="1" cellPadding="1" width="90%" border="1">
                    <TR>
                        <TD style="WIDTH: 20%">
                            <STRONG>ContentID:</STRONG>
                        </TD>
                        <TD>
                            <asp:label id="lbContentID" runat="server" Width="100%"></asp:label>
                        </TD>
                    </TR>
                    <TR>
                        <TD style="WIDTH: 20%">
                            <STRONG>Version:</STRONG>
                        </TD>
                        <TD>
                            <asp:label id="lbVersion" runat="server" Width="100%"></asp:label>
                        </TD>
                    </TR>
                    <TR>
                        <TD style="WIDTH: 20%">
                            <STRONG>Headline:</STRONG>
                        </TD>
                        <TD>
                            <asp:label id="lbHeadline" runat="server" Width="100%"></asp:label>
                        </TD>
                    </TR>
                    <TR>
                        <TD style="WIDTH: 20%">
                            <STRONG>Source:</STRONG>
                        </TD>
                        <TD width="100%">
                            <asp:Label id="lbSource" runat="server" Width="100%"></asp:Label>
                        </TD>
                    </TR>
                    <TR>
                        <TD style="WIDTH: 20%">
                            <STRONG>Byline:</STRONG>
                        </TD>
                        <TD width="100%">
                            <asp:label id="lbByline" runat="server" Width="100%"></asp:label>
                        </TD>
                    </TR>
                    <TR>
                        <TD style="WIDTH: 20%">
                            <STRONG>Teaser:</STRONG>
                        </TD>
                        <TD>
                            <asp:label id="lbTeaser" runat="server" Width="100%"></asp:label>
                        </TD>
                    </TR>
                    <TR>
                        <TD style="WIDTH: 20%">
                            <STRONG>Body:</STRONG>
                        </TD>
                        <TD>
                            <asp:label id="lbBody" runat="server" Width="100%"></asp:label>
                        </TD>
                    </TR>
                    <TR>
                        <TD style="WIDTH: 20%">
                            <STRONG>Tagline:</STRONG>
                        </TD>
                        <TD>
                            <asp:label id="lbTagline" runat="server" Width="100%"></asp:label>
                        </TD>
                    </TR>
                    <TR>
                        <TD style="WIDTH: 20%">
                            <STRONG>Status:</STRONG>
                        </TD>
                        <TD>
                            <asp:label id="lbStatus" runat="server" Width="100%"></asp:label>
                        </TD>
                    </TR>
                    <TR>
                        <TD style="WIDTH: 20%">
                            <STRONG>Editor:</STRONG>
                        </TD>
                        <TD>
                            <asp:Label id="lbEditor" runat="server" Width="100%"></asp:Label>
                        </TD>
                    </TR>
                    <TR>
                        <TD style="WIDTH: 20%">
                            <STRONG>Approver:</STRONG>
                        </TD>
                        <TD>
                            <asp:Label id="lbApprover" runat="server" Width="100%"></asp:Label>
                        </TD>
                    </TR>
                    <TR>
                        <TD style="WIDTH: 20%">
                            <STRONG>Update User:</STRONG>
                        </TD>
                        <TD>
                            <asp:label id="lbUpdateUser" runat="server" Width="100%"></asp:label>
                        </TD>
                    </TR>
                    <TR>
                        <TD style="WIDTH: 20%">
                            <STRONG>Modified Date:</STRONG>
                        </TD>
                        <TD>
                            <asp:label id="lbModifiedDate" runat="server" Width="100%"></asp:label>
                        </TD>
                    </TR>
                    <TR>
                        <TD style="WIDTH: 20%">
                            <STRONG>Creation Date:</STRONG>
                        </TD>
                        <TD>
                            <asp:label id="lbCreationDate" runat="server" Width="100%"></asp:label>
                        </TD>
                    </TR>
                </TABLE>
            </P>
            <asp:Button id="bnReturn" runat="server" Text="Back"></asp:Button>
            &nbsp;
            <asp:button id="bnNext" runat="server" Text="Next Version" Enabled="False"></asp:button>
            &nbsp;
            <asp:button id="bnPrevious" runat="server" Text="Previous Version" Enabled="False"></asp:button>
            &nbsp;
            <asp:button id="bnUpdate" runat="server" Text="Update"></asp:button>
            &nbsp;
            <asp:button id="bnRemove" runat="server" Text="Remove"></asp:button>
        </form>
    </body>
</HTML>
