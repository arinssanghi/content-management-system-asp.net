<%@ Page language="c#" Codebehind="setup2.aspx.cs" AutoEventWireup="false" Inherits="CMSNET.Setup.setup2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>setup2</title>
        <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
        <meta name="CODE_LANGUAGE" Content="C#">
        <meta name="vs_defaultClientScript" content="JavaScript">
        <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    </HEAD>
    <body>
        <form id="setup2" method="post" runat="server">
            <p><IMG src="Images/setup.jpg"></p>
            <hr width="100%" size="1">
            <p>
                <b>Setting up Your Database and SMTP Connection</b>
                <ul>
                    CMS.NET needs to connect to a database in order to function properly. Fill in 
                    the following fields with the connection information for your database. Note: 
                    you should already have completed the import of the CMS.NET database schema as 
                    outlined in the installation guide.
                    <p>
                        <asp:label id="lblErrorHeader" runat="server" ForeColor="Red"></asp:label>
                    </p>
                    <p>
                        <asp:validationsummary id="ValSum" runat="server"></asp:validationsummary>
                    </p>
                    <ul>
                        <asp:label id="lblConnectError" runat="server" ForeColor="Red"></asp:label>
                    </ul>
                    <p></p>
                    <table cellspacing="1" cellpadding="3" width="90%" border="1">
                        <tr>
                            <td style="WIDTH: 20%"><strong>Database</strong></td>
                            <td style="WIDTH: 25%"><asp:textbox id="txtDatabase" runat="server" width="100%">CMSNET</asp:textbox></td>
                            <td style="WIDTH: 2%">&nbsp;
                                <asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" display="dynamic" ErrorMessage="You must enter database name" controltovalidate="txtDatabase">*</asp:requiredfieldvalidator></td>
                            <td style="WIDTH: 53%"><em>The name of the database to be used.<br>
                                    &nbsp;No default value.&nbsp; </I></FONT><font size="+0">e.g. 'CMSNET'</font></em></td>
                        </tr>
                        <tr>
                            <td style="WIDTH: 20%"><strong>Data</strong> <strong>Source</strong></td>
                            <td style="WIDTH: 25%">
                                <asp:textbox id="txtDataSource" runat="server" width="100%"></asp:textbox></td>
                            <td style="WIDTH: 2%">&nbsp;
                                <asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" display="dynamic" ErrorMessage="You must enter a data source or server" controltovalidate="txtDataSource">*</asp:requiredfieldvalidator></td>
                            <td style="WIDTH: 53%"><em>The name of the data source or server&nbsp;to connect to.
                                    <br>
                                    No default value.&nbsp; </I></FONT><font size="+0">e.g. 'localhost'</font></em></td>
                        </tr>
                        <tr>
                            <td style="WIDTH: 20%"><strong>User</strong> <strong>ID</strong></td>
                            <td style="WIDTH: 25%">
                                <asp:textbox id="txtUserID" runat="server" width="100%"></asp:textbox></td>
                            <td style="WIDTH: 2%">&nbsp;</td>
                            <td style="WIDTH: 53%">
                                <p><em>The user ID to use when connecting.
                                        <br>
                                        The default value is an empty string.&nbsp; e.g. 'sa'</em></p>
                            </td>
                        </tr>
                        <tr>
                            <td style="WIDTH: 20%"><strong>Password</strong></td>
                            <td style="WIDTH: 25%">
                                <asp:textbox id="txtPassword" runat="server" TextMode="Password" width="100%"></asp:textbox></td>
                            <td style="WIDTH: 2%">&nbsp;</td>
                            <td style="WIDTH: 53%"><em>The password to use when connecting.
                                    <br>
                                    The default value is an empty string.&nbsp; e.g. 'TheGr8PW'</em></td>
                        </tr>
                        <tr>
                            <td style="WIDTH: 20%"><strong>Connection</strong> <strong>Timeout</strong></td>
                            <td style="WIDTH: 25%">
                                <asp:textbox id="txtTimeout" runat="server" width="100%"></asp:textbox></td>
                            <td style="WIDTH: 2%">&nbsp;
                                <asp:rangevalidator id="RangeValidator1" runat="server" display="Dynamic" ErrorMessage="Only numbers between 0 and 10000 accepted" controltovalidate="txtTimeout" maximumvalue="10000" minimumvalue="0" type="Integer">*</asp:rangevalidator></td>
                            <td style="WIDTH: 53%"><em>The time (in seconds) to wait for a connection to open.
                                    <br>
                                    The default value is 15 seconds.&nbsp; e.g. '15'</em></td>
                        </tr>
                        <TR>
                            <TD style="WIDTH: 20%"><STRONG>SMTP Server</STRONG></TD>
                            <TD style="WIDTH: 25%">
                                <asp:TextBox id="txtSMTP" runat="server" Width="100%"></asp:TextBox></TD>
                            <TD style="WIDTH: 2%"></TD>
                            <TD style="WIDTH: 53%">
                                <P><EM>The SMTP Server that you will use to send email workflow notifications with.<BR>
                                        The default is blank no notification sent using email.</EM></P>
                            </TD>
                        </TR>
                    </table>
                </ul>
                <ul>
                    <p align="center">
                        <asp:button id="bnDBConnect" runat="server" Text="Make Connections"></asp:button></p>
                    <hr width="100%" size="1">
                    <p align="center">
                        <asp:HyperLink id="HyperLink1" runat="server" Font-Size="XX-Small" NavigateUrl="http://www.contentmgr.com">www.contentmgr.com</asp:HyperLink></p>
        </form>
        </UL>
    </body>
</HTML>
