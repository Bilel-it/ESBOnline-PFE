<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GenerationEDT.aspx.cs"
    Inherits="ESPOnline.EmploiEsp.GenerationEDT" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            color: #CCCCCC;
            font-size: large;
        }
        .style3
        {
            color: #990000;
            font-size: small;
        }
        .style4
        {
            width: 94px;
        }
        .style5
        {
            color: #C0C0C0;
            font-size: small;
        }
        .style6
        {
            color: #C0C0C0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="background-color: #808080; text-align: center; font-family: 'Times New Roman', Times, serif;
        font-size: x-large;">
        <br />
        <span class="style6"><span class="style1"><strong>Genération Emploi du Temps</strong></span></span><span class="style5"><br />
        </span>
        <br />
        <table align="center" 
            style="height: 200px; width: 433px; background-color: #333333">
            <tr>
                <td class="style4">
                    <asp:Label ID="Label1" runat="server" Text="Enseignant" CssClass="style5" Style="font-size: medium;
                        "></asp:Label>
                    <span class="style3">*</span>
                </td>
                <td>
                    <asp:DropDownList ID="ddlEns" runat="server" Height="30px" Width="250px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Label ID="Label2" runat="server" Text="Module" CssClass="style5" Style="font-size: medium;
                        "></asp:Label>
                    <span class="style3">*</span>
                </td>
                <td>
                    <asp:DropDownList ID="ddlmodule" runat="server" Height="30px" Width="250px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Label ID="Label3" runat="server" Text="Classe" CssClass="style5" Style="font-size: medium;
                        "></asp:Label>
                    <span class="style3">*</span>
                </td>
                <td>
                    <asp:DropDownList ID="ddlclasse" runat="server" Height="30px" Width="250px" 
                        onselectedindexchanged="ddlclasse_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Label ID="Label4" runat="server" Text="Groupe" CssClass="style5" Style="font-size: medium;
                        "></asp:Label>
                    <span class="style3">*</span>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList" runat="server" Height="30px" Width="250px">
                        <asp:ListItem Selected="True">--Veuillez choisir le groupe--</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Label ID="Label6" runat="server" Text="NB_Seance" CssClass="style5" Style="font-size: medium;
                        "></asp:Label>
                    <span class="style3">*</span>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList2" runat="server" Height="30px" Width="250px">
                        <asp:ListItem>--Veuillez choisir la seance--</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Label ID="Label5" runat="server" Text="Semestre" CssClass="style5" Style="font-size: medium;
                        "></asp:Label>
                    <span class="style3">*</span>
                </td>
                <td>
                    <asp:DropDownList ID="ddlSemestre" runat="server" Height="30px" Width="250px">
                    </asp:DropDownList>
                </td>
            </tr>
             <tr>
                <td class="style4">
                    <asp:Label ID="Label7" runat="server" Text="Salle P" CssClass="style5" Style="font-size: medium;
                        "></asp:Label>
                    <span class="style3">*</span>
                </td>
                <td>
                    <asp:DropDownList ID="ddlsalleP" runat="server" Height="30px" Width="250px" 
                        onselectedindexchanged="ddlsalleP_SelectedIndexChanged">

                    </asp:DropDownList>
                </td>
            </tr>
            <%--<tr>
                <td class="style4">
                    <asp:Label ID="Label8" runat="server" Text="Salle S" CssClass="style5" Style="font-size: medium;
                        "></asp:Label>
                    <span class="style3">*</span>
                </td>
                <td>
                    <asp:DropDownList ID="ddlsalleS" runat="server" Height="30px" Width="250px">

                    </asp:DropDownList>
                </td>
            </tr>--%>
            <tr>
                <td>
                </td>
                <td align="center">
                    <asp:ImageButton runat="server" ID="btnValider" ImageUrl="~/EDTCss/imagesemploi/valider.png"
                        Height="24px" Width="92px" OnClick="btnValider_Click" BackColor="#333333" 
                        BorderColor="#333333" />
                </td>
            </tr>
        </table>
        <br /><br />
    </div>
    </form>
</body>
</html>
