<%@ Page language="c#" Codebehind="login.aspx.cs" AutoEventWireup="false" Inherits="CMSNET.login" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>login</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="login" method="post" runat="server">
			<IMG src="Images/login.jpg">
			<HR width="100%" SIZE="1">
			<TABLE cellSpacing="1" cellPadding="1" width="95%" border="0">
				<TR>
					<TD width="25%">
					</TD>
					<TD>
						<H1>
							<FONT color="darkslategray">Login</FONT>
						</H1>
						<P>
							<asp:label id="lbPrompt" runat="server"></asp:label>
						</P>
						<P>
							<asp:validationsummary id="ValidationSummary1" runat="server" HeaderText="The following error(s) occurred while login in:"></asp:validationsummary>
						</P>
						<P>
							<asp:label id="ErrorMsg" runat="server" ForeColor="Red"></asp:label>
						</P>
						<TABLE cellSpacing="1" cellPadding="5" width="300" border="0">
							<TR>
								<TD width="15%">
									<P align="right">
										<STRONG>Username:</STRONG>
									</P>
								</TD>
								<TD width="85%">
									<asp:textbox id="tbUsername" runat="server" Width="100%"></asp:textbox>
								</TD>
								<TD width="2%">
									<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="tbUsername" Display="Dynamic"
										ErrorMessage="You must enter a Username">*</asp:requiredfieldvalidator>
								</TD>
							</TR>
							<TR>
								<TD>
									<P align="right">
										<STRONG>Password:</STRONG>
									</P>
								</TD>
								<TD>
									<asp:textbox id="tbPassword" runat="server" Width="100%" TextMode="Password"></asp:textbox>
								</TD>
								<TD>
									<asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ControlToValidate="tbPassword" Display="Dynamic"
										ErrorMessage="You must enter a password">*</asp:requiredfieldvalidator>
								</TD>
							</TR>
							<TR>
								<TD colSpan="3">
									<P align="center">
										<asp:checkbox id="cbPersist" runat="server" Text="Remember Login"></asp:checkbox>
									</P>
								</TD>
							</TR>
							<TR>
								<TD colSpan="3">
									<P align="center">
										<asp:button id="bnLogin" runat="server" Text="Login"></asp:button>
										&nbsp;
										<asp:button id="bnRegister" runat="server" Text="Register" Visible="False" CausesValidation="False"></asp:button>
									</P>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
