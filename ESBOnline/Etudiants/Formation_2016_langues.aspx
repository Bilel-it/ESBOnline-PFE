<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Formation_2016_langues.aspx.cs" 
Inherits="ESPOnline.Etudiants.Formation_2016_langues"  MasterPageFile="~/Etudiants/Eol.Master"%>

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


      
   <style type="text/css"> 
.styled-button-10 {
	background:#ff0000;
	background:-moz-linear-gradient(top,#ff0000 0%,#ff0000 100%);
	background:-weNeue',sans-serif;
	font-size:16px;bkit-gradient(linear,left top,left bottom,color-stop(0%,#ff0000),color-stop(100%,#ff0000)): "Helvetica 
	border-radius:5px";
	background:-webkit-linear-gradient(top,#ff0000 0%,#ff0000 100%);
	background:-o-linear-gradient(top,#f65c6c 0%,#ff0000 100%);
	background:-ms-linear-gradient(top,#ff0000 0%,#ff0000 100%);
	background:#ff0000;
	filter: progid: DXImageTransform.Microsoft.gradient( startColorstr='#ff0000', endColorstr='#ff0000',GradientType=0);
	padding:10px 15px;
	color:#fff;
	font-family:'Helvetica 
	border-radius:5px;
	-moz-border-radius:5px;
	-webkit-border-radius:5px;
	border:1px solid #a70f1f
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

  &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;<span class="style4"> Inscription aux formation de langue</span><span class="style3"> 
    </span>
   </h3></td></tr>
   <tr><td><br /></td></tr>
   <tr>
   
   <td align="center">
    <h4 class="style1"><span class="style2"><span class="style5">Veuillez choisir la 
        formation que vous voulez passer :</span> 
     
        </span> 
     
  <asp:DropDownList ID="ddlchoix" runat="server" AutoPostBack="true" AppendDataBoundItems="true">
  <asp:ListItem Value="" >Veuillez choisir </asp:ListItem>
  <asp:ListItem Value="1">FORMATION FR</asp:ListItem>
   <asp:ListItem Value="2" >FORMATION ANG</asp:ListItem>
  <asp:ListItem Value="3" >FORMATION FR+ANG</asp:ListItem>
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
   
    
    <asp:Button ID="btnUpdate" runat="server" Text="Enregistrer" OnClick = "Enregistrer" 
class="styled-button-10"
 height="44px"/>
&nbsp;
   </td></tr>
       </table>
        </center>
       <br />
</asp:Panel>


</asp:Content>
