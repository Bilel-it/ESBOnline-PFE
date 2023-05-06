<%@ Page Title="" Language="C#" MasterPageFile="~/Online/Esp.Master" AutoEventWireup="true"
    CodeBehind="Accueil.aspx.cs" Inherits="ESPOnline.Online.Accueil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Contents/CSS3/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <%-- <link href="../Contents/Css/sticky-footer-navbar.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
     <link href="../Contents/Css/bootstrap.min.css" rel="stylesheet" type="text/css" />--%>
    <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/signin.css" rel="stylesheet" type="text/css" />
    <script src="../Contents/jquery.js" type="text/javascript"></script>
    <script src="../Contents/CSS3/js/bootstrap.min.js" type="text/javascript"></script>
    <style type="text/css">
        .style1
        {
            color: #000000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Three columns of text below the carousel -->
    <div class="row">
        <%--<div class="jumbotron">--%>
        <div class="container" style="background-image: url('../images/AAA.png'); height: 256px;
            width: 1088px;">
            <h1>
                Bienvenue</h1>
            <p class="style1" style="font-size: large; font-weight: normal; color: #CCCCFF;">
                Cette page donne l'accès à l'intranet School of Business est réservée aux étudiants, enseignants
                et personnel administratif.</p>
            <p>
                &nbsp;</p>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
    </div>
    <div class="col-md-3">
        &nbsp;&nbsp;&nbsp;&nbsp; <a href="default.aspx#tabs-2"
            role="button">
            <img src="../Contents/Img/image_ET.jpg" style="width: 140px; height: 140px;" class="img-circle" data-src="holder.js/140x140" alt="140x140"></a>
        <h2 class="text-danger">
            Espace Etudiant</h2>
        <p>
            L'espace étudiant renferme les informations qui vous permettront de bien organiser
            votre vie étudiante : horaires, documents de référence, plusieurs liens utiles,
            etc. Bonne navigation!</p>
    </div>
    <!-- /.col-lg-4 -->
    <div class="col-md-3">
        &nbsp;&nbsp;&nbsp; <a href="default.aspx#tabs-3" role="button">
            <img src="../Contents/Img/image_ET.jpg" style="width: 140px; height: 140px;" class="img-circle" data-src="holder.js/140x140" alt="140x140"></a>
        <h2 class="text-danger">
            Espace Parents</h2>
        <p>
            L'espace parents est un endroit privilégié pour effectuer un suivi personnalisé
            du cheminement scolaire de votre enfant (résultats scolaires et absences).</p>
    </div>
    <!-- /.col-lg-4 -->
    <div class="col-md-3">
        <a href="default.aspx#tabs-1" role="button">
            <img src="../Contents/Img/ENSEsB.jpg" style="width: 140px; height: 140px;" class="img-circle"
                data-src="holder.js/140x140" alt="140x140"></a>
        <h2 class="text-danger">
            Espace Enseignant</h2>
        <p>
            L'espace enseignant est un endroit réservé aux enseignants.</p>
        <br />
        <br />
    </div>
    <div class="col-md-3">
        &nbsp; <a href="default.aspx#tabs-6" role="button">
            <img src="../Contents/Img/page_adminstration.jpg" style="width: 140px; height: 140px;" class="img-circle"
                data-src="holder.js/140x140" alt="140x140"></a>
        <h2 class="text-danger">
            Administration & Gouvernance</h2>
        <p>
            L'espace Administration & Gouvernance est un endroit réservé aux directeurs.</p>
        <br />
        <br />
    </div>
    </div>
    <!-- /.row -->
</asp:Content>
