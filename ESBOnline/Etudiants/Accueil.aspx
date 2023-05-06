<%@ Page Title="" Language="C#" MasterPageFile="~/Etudiants/Eol.Master" AutoEventWireup="true" CodeBehind="Accueil.aspx.cs" Inherits="ESPOnline.Etudiants.Accueil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Contents/Css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />
    <script src="../Contents/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="../Contents/Scripts/bootstrap.js" type="text/javascript"></script>
       
        <script type="text/javascript" src="../Contents/Scripts/JScript1.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<br /><br /><br />
<div class="container">
<div class="jumbotron">
        <h2>Bienvenue dans votre Espace</h2>
        <p class="lead">Vous pouvez consulter dans cet espace :</p>
        <p><a class="btn-lg btn-link" href="Emplois.aspx" role="button">Votre Emploi du temps</a></p>
        <p><a class="btn-lg btn-link" href="absenceetud.aspx" role="button">Votre Absence</a></p>
          <p><a class="btn-lg btn-link" href="evaluation2.aspx" role="button">Evaluation de l'enseignement</a></p>
        
</div>
</div>      
</asp:Content>
