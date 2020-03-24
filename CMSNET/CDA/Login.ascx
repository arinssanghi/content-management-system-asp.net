<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Login.ascx.cs" Inherits="CMSNET.CDA.Login" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<P>
    <B><FONT color="darkslategray" size="2">&nbsp; Account Login</FONT></B>
    <BR>
    <FONT color="darkslategray" size="2">&nbsp;&nbsp;Username:</FONT>
    <BR>
    &nbsp;
    <asp:TextBox id="tbUsername" runat="server" Width="90%" BackColor="LightCyan"></asp:TextBox>
    <BR>
    <FONT color="darkslategray" size="2">&nbsp; Password:</FONT>
    <BR>
    &nbsp;
    <asp:TextBox id="tbPassword" runat="server" Width="90%" TextMode="Password" BackColor="LightCyan"></asp:TextBox>
    <BR>
    <FONT color="darkslategray">&nbsp;
        <asp:CheckBox id="cbPersist" runat="server" Text="Remember Login" Font-Size="X-Small"></asp:CheckBox>
    </FONT>
    <BR>
    &nbsp;
    <asp:ImageButton id="ibnSignIn" runat="server" ImageUrl="Images/signin.gif"></asp:ImageButton>
    <BR>
    &nbsp;
    <asp:ImageButton id="ibnRegister" runat="server" ImageUrl="Images/register.gif"></asp:ImageButton>
</P>
<P>
    &nbsp;
    <asp:Label id="ErrorMsg" runat="server" ForeColor="Red"></asp:Label>
</P>
