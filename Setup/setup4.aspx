<%@ Page language="c#" Codebehind="setup4.aspx.cs" AutoEventWireup="false" Inherits="CMSNET.Setup.setup4" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>setup4</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="setup4" method="post" runat="server">
			<p><IMG src="Images/setup.jpg"></p>
			<hr width="100%" size="1">
			<p><b>Setup Complete!</b>
				<ul>
					CMS.NET setup is now complete. Click the button below to jump to the 
					Administation Site where you'll be able to create and administer your web site.
				</ul>
				<center>
					<asp:Button id="btnLogin" runat="server" Text="Login to CMS.NET Administation"></asp:Button></center>
				<br>
				<hr size="0">
				<center>
					<asp:hyperlink id="HyperLink1" runat="server" NavigateUrl="http://www.cms.com" Font-Size="XX-Small">www.cms.com</asp:hyperlink>
				</center>
		</form>
	</body>
</HTML>
