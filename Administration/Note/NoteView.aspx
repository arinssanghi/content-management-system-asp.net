<%@ Page language="c#" Codebehind="NoteView.aspx.cs" AutoEventWireup="false" Inherits="CMSNET.Administration.Note.NoteView" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>NoteView</title>
        <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
        <meta name="CODE_LANGUAGE" Content="C#">
        <meta name="vs_defaultClientScript" content="JavaScript">
        <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    </HEAD>
    <body>
        <form id="NoteView" method="post" runat="server">
            <H2>
                <FONT color="darkslategray">
                    <asp:Label id="lbWho" runat="server"></asp:Label>
                    :&nbsp;Note View</FONT>
            </H2>
            <P>
                <TABLE cellSpacing="1" cellPadding="1" width="90%" border="1">
                    <TR>
                        <TD style="WIDTH: 20%">
                            <STRONG>Note:</STRONG>
                        </TD>
                        <TD>
                            <asp:TextBox id="lbNote" runat="server" Width="100%" BorderStyle="None" ReadOnly="True" TextMode="MultiLine" Rows="16"></asp:TextBox>
                        </TD>
                    </TR>
                    <TR>
                        <TD style="WIDTH: 20%">
                            <STRONG>Author:</STRONG>&nbsp;
                        </TD>
                        <TD>
                            <asp:label id="lbAuthor" runat="server" Width="100%"></asp:label>
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
            <P>
                <INPUT onclick="window.history.back()" type="button" value="Return"> 
                &nbsp;
                <asp:button id="bnUpdate" runat="server" Text="Update"></asp:button>
                &nbsp;
                <asp:button id="bnRemove" runat="server" Text="Remove"></asp:button>
                &nbsp;
            </P>
            <P>
                <asp:Label id="lbContentID" runat="server" Visible="False"></asp:Label>
            </P>
        </form>
    </body>
</HTML>
