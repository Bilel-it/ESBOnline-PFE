﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="ESPOnline.EmploiEsp.Edit" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>New event</title>
    <link href='../Media/empty.css' type="text/css" rel="stylesheet" /> 
</head>
<body style="background-color:white; margin:10px;">
    <form id="form1" runat="server">
    <div>
        <table border="0" cellspacing="4" cellpadding="0">
            <tr>
                <td align="right"></td>
                <td>
                    <h2>Edit Event</h2>
                </td>
            </tr>
            <tr>
                <td align="right">Start:</td>
                <td><asp:TextBox ID="TextBoxStart" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right">End:</td>
                <td><asp:TextBox ID="TextBoxEnd" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right">Name:</td>
                <td><asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right"></td>
                <td>
                    <asp:Button ID="ButtonOK" runat="server" OnClick="ButtonOK_Click" Text="OK" />
                    <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" OnClick="ButtonCancel_Click" />
                </td>
            </tr>
        </table>
        
        </div>
    </form>

    <script type="text/javascript">
        document.getElementById("TextBoxName").focus();
    </script>

</body>
</html>
