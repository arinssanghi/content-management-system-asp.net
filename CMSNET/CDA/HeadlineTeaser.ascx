<%@ Control Language="c#" AutoEventWireup="false" Codebehind="HeadlineTeaser.ascx.cs" Inherits="CMSNET.CDA.HeadlineTeaser" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<P>
    <STRONG>
        <asp:Label id="lbHeadline" runat="server"></asp:Label>
    </STRONG>
    <BR>
    <asp:Label id="lbSource" runat="server"></asp:Label>
    <BR>
    <EM><FONT size="2">
            <asp:Label id="lbBy" runat="server">by</asp:Label>
        </FONT>
        <asp:Label id="lbByline" runat="server" Font-Size="X-Small"></asp:Label>
    </EM>
    <BR>
    <asp:Label id="lbTeaser" runat="server"></asp:Label>
</P>
<P>
    <asp:Image id="imgPlus" runat="server" Height="11px" Width="11px" ImageUrl="Images/plus.gif"></asp:Image>
    &nbsp;
    <asp:HyperLink id="hlReadMore" runat="server">Read More</asp:HyperLink>
</P>
<HR align="center" width="60%" SIZE="1">
<br>
