<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testSUIVIGROUpe.aspx.cs" Inherits="ESPOnline.testSUIVIGROUpe" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="resultat : "></asp:Label><asp:Label ID="Label2" runat="server" Text=""></asp:Label>
        <br />
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
            DataSourceID="SqlDataSourceListeProjetGP" DataTextField="NOM_GROUPE" 
            DataValueField="NOM_GROUPE">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSourceListeProjetGP" runat="server" 
            ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" 
            SelectCommand="SELECT DISTINCT &quot;NOM_GROUPE&quot; FROM &quot;ESP_GROUPE_ETUDIANT&quot;">
        </asp:SqlDataSource>
        <asp:Button ID="Button1" runat="server" Text="Tester" onclick="Button1_Click" />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    </div>
    <asp:TextBox ID="TextBox1" runat="server" Height="23px" Width="252px"></asp:TextBox>



    <table>
                <tr>
                <td>1</td>
                <td>2</td>
                </tr>
                <tr>
                <td>3</td>
                <td>4</td>
                </tr>
                </table>
    </form>
</body>
</html>
