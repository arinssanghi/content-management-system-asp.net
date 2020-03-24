<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Footer.ascx.cs" Inherits="CMSNET.CDA.Footer" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<center>
	<asp:Table id="tblFootMenu" runat="server" CellPadding="3"></asp:Table>
</center>
<HR width="60%" SIZE="1">
<center>
	&nbsp;
	<asp:HyperLink id="HyperLink1" runat="server" ForeColor="#0A246A" NavigateUrl="mailto:admin@cms.com">
        Contact Us</asp:HyperLink>
	| <U><FONT color="#0a246a">Company Info</FONT></U> | <U><FONT color="#0a246a">Contributors</FONT></U>
	| <U><FONT color="#0a246a">Jobs</FONT></U> | <U><FONT color="#0a246a">Advertising</FONT></U>
	|
	<asp:HyperLink id="hlPrivacy" runat="server" NavigateUrl="../PrivacyPolicy.html" ForeColor="#0A246A">
        Privacy Policy</asp:HyperLink>
	<br>
	<FONT size="2">Copyright © 2004 Cms.com. All rights reserved.</FONT>
</center>
