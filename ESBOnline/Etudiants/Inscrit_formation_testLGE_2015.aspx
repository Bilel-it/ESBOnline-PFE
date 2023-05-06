<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inscrit_formation_testLGE_2015.aspx.cs" 
Inherits="ESPOnline.Etudiants.Inscrit_formation_testLGE_2015"MasterPageFile="~/Etudiants/Eol.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <script src="../Contents/jquery.js" type="text/javascript"></script>
    <link href="../Contents/Css/datetimepicker.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/animate.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <script src="../Contents/bootstrap.js" type="text/javascript"></script>
    <script src="../Contents/bootstrap.min.js" type="text/javascript"></script>
    <script src="../Contents/Scripts/bootstrap-datetimepicker.min.js" type="text/javascript"></script>
    <script src="../Contents/Scripts/bootstrap-datetimepicker.js" type="text/javascript"></script>


      
   


      
      <style type="text/css">
          .style1
          {
              font-weight: bold;
          }
          .style2
          {
              font-weight: normal;
          }
          .style3
          {
              color: #CC0000;
          }
          .style4
          {
              color: #CC0000;
              font-size: large;
              font-weight: normal;
          }
          .style5
          {
              font-family: "Berlin Sans FB";
              font-size: medium;
          }
          .style6
          {
              font-family: "Berlin Sans FB";
              font-weight: normal;
              font-size: large;
          }
      </style>


      
   


      
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
<br />
 <asp:Panel ID="panel1" runat="server">
        <center>
        <%--<h3 class="style6">Nous sommes désolés,Vous n&#39;avez pas le droit de passer ni les 
            formations ni les tests!</h3>--%>
<br />
<asp:HyperLink ID="HyperLink1" NavigateUrl="~/Etudiants/Accueil.aspx"  runat="server" ForeColor="#0033CC" > Retour à la page d'Accueil</asp:HyperLink>

</center>
<br />
        </asp:Panel>
        <br />
<asp:Panel ID="pl1" runat="server" >
<br />
<table align="center"><tr><td align="center"><h3 class="style1">

  &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;<span class="style4"> INSCRIPTION AU TEST ET FORMATION LANGUES POUR L'ANNEE UNIVERSITAIRE 2014/2015</span><span class="style3"> 
    </span>
   </h3></td></tr>
   <tr><td><br /></td></tr>
   <tr>
   
   <td align="center">
    <h4 class="style1"><span class="style2"><span class="style5">Veuillez choisir la 
        formation que vous voulez passer :</span> 
     
        </span> 
     
  <asp:DropDownList ID="ddlchoix" runat="server" AutoPostBack="true" AppendDataBoundItems="true">
  <asp:ListItem Value="" >choisissez </asp:ListItem>
  <asp:ListItem Value="1">Formation Français+test</asp:ListItem>
   <asp:ListItem Value="2" >Formation Français+ Anglais+test</asp:ListItem>
 
  <asp:ListItem Value="3" >Test Français</asp:ListItem>
   <asp:ListItem Value="4" >Test Anglais</asp:ListItem>
      <asp:ListItem Value="6" >Test Anglais +Français</asp:ListItem>
        <asp:ListItem Value="5" >Formation Anglais+test</asp:ListItem>
  </asp:DropDownList>
   </h4>
   </td>
   </tr>
   </table>
   <br />
   <br />
   <center>
   <table>
   <tr><td>
   
    
     <asp:ImageButton runat="server" ID="Imgvalid" Width="120px" 
    ImageUrl="~/images/button_valider.gif" onclick="Imgvalid_Click"/>

   </td></tr>
       </table>
        </center>
       <br />
</asp:Panel>


</asp:Content>
