<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="accueil.aspx.cs" Inherits="ESPOnline.EmploiEsp.accueil" MasterPageFile="~/EmploiEsp/SiteEDT.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <meta http-equiv="content-type" content="text/html; charset=utf-8" />
          <meta name="description" content="" />
          <meta name="keywords" content="" />
        <script src="../EDTCss/jsemploi/jquery.min.js" type="text/javascript"></script>
        <script src="../EDTCss/jsemploi/skel.min.js" type="text/javascript"></script>
        <script src="../EDTCss/jsemploi/skel-layers.min.js" type="text/javascript"></script>
        <script src="../EDTCss/jsemploi/init.js" type="text/javascript"></script>
       
        <link href="../Contents/CSS3/css/bootstrap.css" rel="stylesheet" type="text/css" />
          <link rel="stylesheet" href="../EDTCss/cssemploi/skel.css" />
          <link rel="stylesheet" href="../EDTCss/cssemploi/style.css" />
          <link rel="stylesheet" href="../EDTCss/cssemploi/style-desktop.css" />
          <link href="../Contents/CSS3/css/bootstrap.css" rel="stylesheet" type="text/css" />
          <%-- <link href="../Contents/jquery/css/blitzer/jquery-ui-1.10.3.custom.css" rel="stylesheet"
        type="text/css" />--%>
        <%-- <link href="../Contents/jquery/css/blitzer/jquery-ui-1.10.3.custom.min.css" rel="stylesheet"
        type="text/css" />--%>
          <!--[if lte IE 9]>
          <link rel="stylesheet" href="css/ie9.css" /><![endif]--><!--[if lte IE 8]><script src="js/html5shiv.js"></script>
          <![endif]-->

          <script src="../Contents/CSS3/js/bootstrap.min.js" type="text/javascript"></script>
          <script src="../Contents/CSS3/js/bootstrap.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <br /><br /><br />
<div class="container">

        <h2>Bienvenue dans votre Espace</h2>

        <p class="lead">Vous pouvez consulter dans cet espace </p>
        <p><a class="btn-lg btn-link" href="GestionSalleClasse.aspx" role="button">Gestion Des Salles</a></p>
        <p><a class="btn-lg btn-link" href="GestionCours.aspx" role="button">Gestion des Enseignants</a></p>
        <p><a class="btn-lg btn-link" href="Affichedispo.aspx" role="button">Disponibilite de chaque enseignants</a></p>
        <p><a class="btn-lg btn-link" href="EmploiparEnsClasse.aspx" role="button">Generation d'emploi du temps</a></p>
         <p><a class="btn-lg btn-link" href="Ajouter_Matiere.aspx" role="button">Ajouter Matiere</a></p>
           <p><a class="btn-lg btn-link" href="Generation_Emp_temps.aspx" role="button">Affecter les enseignants aux salles</a></p>
          

</div>      
</asp:Content>
