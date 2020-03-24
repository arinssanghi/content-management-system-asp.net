<%@ Page language="c#" Codebehind="setup3.aspx.cs" AutoEventWireup="false" Inherits="CMSNET.Setup.setup3" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>setup3</title>
        <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
        <meta name="CODE_LANGUAGE" Content="C#">
        <meta name="vs_defaultClientScript" content="JavaScript">
        <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    </HEAD>
    <body>
        <form id="setup3" method="post" runat="server">
            <p><IMG src="Images/setup.jpg"></p>
            <p>
                <hr width="100%" size="1">
            <p></p>
            <p><b>Create an Administrator Account</b>
                <ul>
                    An administrator account will allow you to administer CMS.NET.
                    <br>
                    Be sure to remember your password! If you forget it, you'll have to redo this 
                    setup.</ul>
                <ul>
                    <p>
                        <asp:ValidationSummary id="ValSum" runat="server" HeaderText="Sorry, cannot create administrator account the following errors occured:"></asp:ValidationSummary></p>
                    <blockquote dir="ltr" style="MARGIN-RIGHT: 0px">
                        <p>
                            <asp:Label id="lblError" runat="server" ForeColor="Red"></asp:Label></p>
                    </blockquote>
                </ul>
                <ul>
                    <table cellspacing="1" cellpadding="3" width="60%" border="1">
                        <tr>
                            <td style="WIDTH: 35%">
                                <p><strong>Administrator Name<br>
                                    </strong><em>(optional)</em></p>
                            </td>
                            <td style="WIDTH: 40%">
                                <asp:TextBox id="txtAdministratorName" runat="server" maxlength="256" width="185"></asp:TextBox></td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="WIDTH: 35%"><strong>User ID</strong></td>
                            <td style="WIDTH: 40%">
                                <asp:TextBox id="txtUserName" runat="server" maxlength="32" width="185">Admin</asp:TextBox></td>
                            <td style="WIDTH: 15%">&nbsp;
                                <asp:RequiredFieldValidator id="rfvUserID" runat="server" ErrorMessage="You must enter a User ID" Display="Dynamic" ControlToValidate="txtUserName">*</asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td style="WIDTH: 35%"><strong>Email Address</strong></td>
                            <td style="WIDTH: 40%">
                                <asp:TextBox id="txtEmail" runat="server" maxlength="64" width="185"></asp:TextBox></td>
                            <td style="WIDTH: 15%">&nbsp;
                                <asp:RequiredFieldValidator id="rfvEmail" runat="server" ErrorMessage="You must enter an email address" Display="Dynamic" ControlToValidate="txtEmail">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator id="revEmail" runat="server" ErrorMessage="Invalid email address" Display="Dynamic" ControlToValidate="txtEmail" ValidationExpression="[\w-]+([\+\.][\w-]*)?@([\w-]+\.)+[\w-]+">*</asp:RegularExpressionValidator></td>
                        </tr>
                        <tr>
                            <td style="WIDTH: 35%"><strong>Password</strong></td>
                            <td style="WIDTH: 40%">
                                <asp:TextBox id="txtPassword" runat="server" maxlength="16" TextMode="Password" width="185"></asp:TextBox></td>
                            <td style="WIDTH: 15%">&nbsp;
                                <asp:RequiredFieldValidator id="rfvPassword" runat="server" ErrorMessage="You must enter a password" Display="Dynamic" ControlToValidate="txtPassword">*</asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td style="WIDTH: 35%"><strong>Password</strong><br>
                                <em>(Confirm)</em></td>
                            <td style="WIDTH: 40%">
                                <asp:TextBox id="txtConfirm" runat="server" maxlength="16" TextMode="Password" width="185"></asp:TextBox></td>
                            <td style="WIDTH: 15%">&nbsp;
                                <asp:RequiredFieldValidator id="rfvConfirm" runat="server" ErrorMessage="Missing confirmation password" Display="Dynamic" ControlToValidate="txtConfirm">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator id="cvConfirm" runat="server" ErrorMessage="Password and Confirm password do not match" Display="Dynamic" ControlToValidate="txtConfirm" ControlToCompare="txtPassword">*</asp:CompareValidator></td>
                        </tr>
                    </table>
                </ul>
                <ul>
                    <div align="center">
                        <table cellspacing="0" cellpadding="0" width="60%" align="left" border="0">
                            <tr>
                                <td>
                                    <p align="center">
                                        <asp:Button id="btnCreateAdmin" runat="server" Text="Create Administrator"></asp:Button></p>
                                </td>
                            </tr>
                        </table>
                    </div>
                </ul>
                &nbsp;
                <div></div>
            <p>
                <hr size="0">
            <p></p>
            <center>
                <asp:hyperlink id="HyperLink1" runat="server" NavigateUrl="http://www.contentmgr.com" font-size="XX-Small">www.contentmgr.com</asp:hyperlink>
            </center>
        </form>
    </body>
</HTML>
