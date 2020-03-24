<%@ Control Language="c#" AutoEventWireup="false" Codebehind="ZoneCard.ascx.cs" Inherits="CMSNET.CDA.Protected.ZoneCard" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<asp:Panel id="pnlTitle" runat="server" Width="100%" BorderStyle="None">
    <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
        <TR>
            <TD align="middle" width="85%" bgColor="#8cd3ef">
                <asp:Panel id="pnlZoneName" BorderStyle="Ridge" Width="100%" runat="server">
<asp:HyperLink id="hlZoneName" runat="server" Font-Bold="True" ForeColor="DarkSlateGray"></asp:HyperLink>&nbsp; 
<asp:DropDownList id="ddlZones" runat="server" AutoPostBack="True" Visible="False"></asp:DropDownList></asp:Panel></TD>
            <TD width="5%"></TD>
            <TD width="2%">
                <asp:ImageButton id="ibnEdit" BorderStyle="Outset" runat="server" ImageUrl="Images/edit.gif"></asp:ImageButton></TD>
            <TD width="2%">
                <asp:ImageButton id="ibnExpCon" BorderStyle="Outset" runat="server" ImageUrl="Images/ExpCon.gif"></asp:ImageButton></TD>
            <TD width="2%">
                <asp:ImageButton id="ibnClose" BorderStyle="Outset" runat="server" ImageUrl="Images/close.gif"></asp:ImageButton></TD>
            <TD width="4%"></TD>
        </TR>
    </TABLE>
</asp:Panel>
<asp:Panel id="pnlBody" runat="server" Width="100%" BorderStyle="Ridge">
    <P><STRONG>
            <asp:Label id="lbHeadline" runat="server"></asp:Label></STRONG><BR>
        <asp:Label id="lbSource" runat="server"></asp:Label><BR>
        <EM><FONT size="2">
                <asp:Label id="lbBy" runat="server">
                    by</asp:Label></FONT>
            <asp:Label id="lbByline" runat="server" Font-Size="X-Small"></asp:Label></EM><BR>
        <asp:Label id="lbTeaser" runat="server"></asp:Label></P>
    <P>
        <asp:Image id="imgPlus" Width="11px" runat="server" ImageUrl="Images/plus.gif" Height="11px"></asp:Image>&nbsp;
        <asp:HyperLink id="hlReadMore" runat="server">
            Read More</asp:HyperLink></P>
</asp:Panel>
<asp:ImageButton id="ibnEditNew" BorderStyle="Outset" runat="server" ImageUrl="Images/edit.gif" Visible="False"></asp:ImageButton>
<asp:Label id="lbEmpty" runat="server" Font-Size="XX-Small" Visible="False" ForeColor="DarkSlateGray">
    (empty zone)</asp:Label>
