<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Src="~/messagebox.ascx" TagPrefix="msg" TagName="PopMsg" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Custom MessageBox</title>
    <style type="text/css">
        body
        {
            background: gray;
            color: black;
            font-family: Segoe UI;
            font-size: 14px;
        }
        
        .style1
        {
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellpadding="3" cellspacing="3">
            <tr>
                <td colspan="2">
                    <h3>
                        Customised Message Box
                    </h3>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    Enter Message to display
                </td>
                <td>
                    <asp:TextBox ID="txtMessage" runat="server" Width="300px" BorderColor="Gray" BorderStyle="Solid"
                        BorderWidth="1px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Select Messagebox style
                </td>
                <td>
                    <asp:DropDownList ID="cboStyle" runat="server" Width="300px">
                        <asp:ListItem Selected="True">Information</asp:ListItem>
                        <asp:ListItem>Excliamation</asp:ListItem>
                        <asp:ListItem>Question</asp:ListItem>
                        <asp:ListItem>Error</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Enter the message title
                </td>
                <td>
                    <asp:TextBox ID="txtTitle" runat="server" Width="300px" BorderColor="Gray" BorderStyle="Solid"
                        BorderWidth="1px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;
                </td>
                <td class="style1">
                    <asp:Button ID="Button1" runat="server" Text="Show Message" />
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style1">
                    <asp:Button ID="Button3" runat="server" Text="Information Message" />
                    <asp:Button ID="Button2" runat="server" Text="Error Message" />
                    <br />
                    <asp:Button ID="Button5" runat="server" Text="Question Message" />
                    <asp:Button ID="Button4" runat="server" Text="Excliamation Message" />
                </td>
            </tr>
        </table>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <msg:PopMsg ID="PopMsg" runat="server" />
    </form>
</body>
</html>
