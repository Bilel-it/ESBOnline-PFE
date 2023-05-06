<%@ Page Title="" Language="C#" MasterPageFile="~/EnseignantsCUP/Cup.Master" AutoEventWireup="true" CodeBehind="Changepass.aspx.cs" Inherits="ESPOnline.EnseignantsCUP.Changepass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <%-- <script src="../Contents/Scripts/bootstrap-datetimepicker.js" type="text/javascript"></script>
    <script src="../Contents/jquery.js" type="text/javascript"></script>
    <link href="../Contents/Css/datetimepicker.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/animate.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <script src="../Contents/bootstrap.js" type="text/javascript"></script>
    <script src="../Contents/bootstrap.min.js" type="text/javascript"></script>
    <script src="../Contents/Scripts/bootstrap-datetimepicker.min.js" type="text/javascript"></script>
    <script src="../Contents/Scripts/bootstrap-datetimepicker.js" type="text/javascript"></script>--%>
    <script src="../Contents/jquery.js" type="text/javascript"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
  <script src="../Contents/Scripts/ScrollableGridPlugin_ASP.NetAJAX_2.0.js" type="text/javascript"></script>
    <link href="../Contents/Css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />
    <script src="../Contents/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="../Contents/Scripts/bootstrap.js" type="text/javascript"></script>
    <script src="../Contents/CSS3/js/bootstrap.min.js" type="text/javascript"></script>
 <script type="text/javascript" src="../Contents/Scripts/JScript1.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <form id="form1">
        <div>
            <br />
           <%-- <asp:Label ID="Label4" runat="server" Text=""></asp:Label>--%>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Mot de passe actuel" Width="197px" Font-Bold="True"
                ForeColor="Black"></asp:Label>
            <asp:TextBox ID="txt_cpassword" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_cpassword"
                ValidationGroup="ajouter_passe" ErrorMessage="S'il vous plaît entrez le mot de passe actuel"
                ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Nouveau mot de passe" Width="201px" Font-Bold="True"
                ForeColor="Black"></asp:Label>
            <asp:TextBox ID="txt_npassword" MaxLength="20"  runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_npassword"
                ValidationGroup="ajouter_passe" ErrorMessage="S'il vous plaît entrer nouveau mot de passe"
                ForeColor="Red"></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="RegExp1" runat="server" 
                ControlToValidate="txt_npassword" ErrorMessage=" Le mot de passe ne doit pas contenir d'espace et ne dépasse pas 20 caractères"
              ValidationGroup="ajouter_passe"    
                ValidationExpression="^([\w\W](?!.*\s))*$" ForeColor="#CC0000" />
            <br />
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label3" runat="server" Text="Confirmez le mot de passe" Width="200px"
                Font-Bold="True" ForeColor="Black"></asp:Label>
            <asp:TextBox ID="txt_ccpassword" runat="server" MaxLength="20" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_ccpassword"
                ErrorMessage="S'il vous plaît entrez le mot de passe de confirmation" ValidationGroup="ajouter_passe"
                ForeColor="Red"></asp:RequiredFieldValidator><br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txt_npassword"
                ControlToValidate="txt_ccpassword" 
                ErrorMessage="Mot de passe Incompatible" ForeColor="Red" 
                ValidationGroup="ajouter_passe"></asp:CompareValidator><br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                runat="server" ControlToValidate="txt_ccpassword" ErrorMessage=" Le mot de passe ne doit pas contenir d'espace et ne dépasse pas 20 caractères"
              ValidationGroup="ajouter_passe"    
                ValidationExpression="^([\w\W](?!.*\s))*$" ForeColor="#CC0000" />
            <br />
            <br />
        </div>
        <asp:Button ID="btn_update" runat="server" Font-Bold="True" BackColor="Silver" OnClick="btn_update_Click" ValidationGroup="ajouter_passe"
            Text="Modifier" />
        <asp:Label ID="lbl_msg" Font-Bold="True" BackColor="#FFFF66" ForeColor="#FF3300"
            runat="server" Text=""></asp:Label>
        <br />
        <br />
        <br />
        <%--<asp:hyperlink id="link" runat="server"   NavigateUrl="../Online/default.aspx"  >
    <img src="../images/disc.png" /></asp:hyperlink>
    <asp:HyperLink ID="HyperLink1" runat="server" 
        NavigateUrl="../Online/default.aspx" ForeColor="#333333">Se déconnecter</asp:HyperLink>--%>
        </form>
    </center>
</asp:Content>