<%@ Page language="c#" Codebehind="Register.aspx.cs" AutoEventWireup="false" Inherits="CMSNET.CDA.Register" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>Register</title>
        <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
        <meta name="CODE_LANGUAGE" Content="C#">
        <meta name="vs_defaultClientScript" content="JavaScript">
        <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    </HEAD>
    <body>
        <form id="Register" method="post" runat="server">
            <P>
                <IMG src="Images/registerhead.jpg">
                <HR width="100%" SIZE="1">
            <P>
            </P>
            <TABLE cellSpacing="1" cellPadding="1" width="95%" border="0">
                <TR>
                    <TD width="25%">
                    </TD>
                    <TD>
                        <H1>
                            <FONT color="darkslategray">Register a New Account</FONT>
                        </H1>
                        <H5>
                            To get your account started all we need&nbsp;are these few things:
                        </H5>
                        <P>
                            <asp:validationsummary id="ValSum" runat="server" HeaderText="Sorry, I cannot create the account as the following errors occurred:"></asp:validationsummary>
                        </P>
                        <P>
                            <asp:label id="lblError" runat="server" ForeColor="Red"></asp:label>
                        </P>
                        <TABLE height="184" cellSpacing="1" cellPadding="5" width="364" border="0">
                            <TR>
                                <TD style="WIDTH: 130px">
                                    <P align="right">
                                        <STRONG>User Name:</STRONG>
                                    </P>
                                </TD>
                                <TD style="WIDTH: 177px">
                                    <asp:textbox id="tbUserName" runat="server" Width="100%"></asp:textbox>
                                </TD>
                                <TD>
                                    <asp:requiredfieldvalidator id="rfvUserName" runat="server" ControlToValidate="tbUserName" Display="Dynamic" ErrorMessage="You must enter a user name.">*</asp:requiredfieldvalidator>
                                    &nbsp;
                                </TD>
                            </TR>
                            <TR>
                                <TD style="WIDTH: 130px">
                                    <P align="right">
                                        <STRONG>Email:
                                            <BR>
                                        </STRONG><FONT size="1">(optional)&nbsp; </FONT>
                                    </P>
                                </TD>
                                <TD style="WIDTH: 177px">
                                    <asp:textbox id="tbEmail" runat="server" Width="100%"></asp:textbox>
                                </TD>
                                <TD>
                                    <asp:regularexpressionvalidator id="revEmail" runat="server" ControlToValidate="tbEmail" Display="Dynamic" ErrorMessage="Invalid email address" ValidationExpression="[\w-]+([\+\.][\w-]*)?@([\w-]+\.)+[\w-]+">*</asp:regularexpressionvalidator>
                                    &nbsp;
                                </TD>
                            </TR>
                            <TR>
                                <TD style="WIDTH: 130px">
                                    <P align="right">
                                        <STRONG>Password:</STRONG>
                                    </P>
                                </TD>
                                <TD style="WIDTH: 177px">
                                    <asp:textbox id="tbPassword" runat="server" Width="100%" TextMode="Password"></asp:textbox>
                                </TD>
                                <TD>
                                    <asp:requiredfieldvalidator id="rfvPassword" runat="server" ControlToValidate="tbPassword" Display="Dynamic" ErrorMessage="You must enter a password">*</asp:requiredfieldvalidator>
                                    &nbsp;
                                </TD>
                            </TR>
                            <TR>
                                <TD style="WIDTH: 130px">
                                    <P align="right">
                                        <STRONG>Confirm Password:</STRONG>
                                    </P>
                                </TD>
                                <TD style="WIDTH: 177px">
                                    <asp:textbox id="tbConfirm" runat="server" Width="100%" TextMode="Password"></asp:textbox>
                                </TD>
                                <TD>
                                    <asp:requiredfieldvalidator id="rfvConfirm" runat="server" ControlToValidate="tbConfirm" Display="Dynamic" ErrorMessage="Missing confirmation password">*</asp:requiredfieldvalidator>
                                    <asp:comparevalidator id="cvConfirm" runat="server" ControlToValidate="tbConfirm" Display="Dynamic" ErrorMessage="Password and Confirm password do not match" ControlToCompare="tbPassword">*</asp:comparevalidator>
                                    &nbsp;
                                </TD>
                            </TR>
                            <TR>
                                <TD style="WIDTH: 130px" colSpan="3">
                                    <P align="center">
                                        <asp:imagebutton id="ibnRegister" runat="server" ImageUrl="Images/registerbig.gif"></asp:imagebutton>
                                        <BR>
                                        <asp:imagebutton id="ibnCancel" runat="server" ImageUrl="Images/cancelbig.gif" CausesValidation="False"></asp:imagebutton>
                                    </P>
                                </TD>
                            </TR>
                        </TABLE>
                        <P align="center">
                        </P>
                        <P align="right">
                            <asp:HyperLink id="hlPrivacy" runat="server" NavigateUrl="../PrivacyPolicy.html">Privacy Policy</asp:HyperLink>
                        </P>
                    </TD>
                </TR>
            </TABLE>
        </form>
    </body>
</HTML>
