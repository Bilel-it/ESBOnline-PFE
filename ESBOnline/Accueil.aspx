<%@ Page Title="" Language="C#" MasterPageFile="~/Esprit.Master" AutoEventWireup="true" CodeBehind="Accueil.aspx.cs" Inherits="ESPOnline.Accueil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="Contents/Css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
    <link href="Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="Contents/Css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="Contents/jquery/css/blitzer/jquery-ui-1.10.3.custom.css" rel="stylesheet"
        type="text/css" />
    <script src="Contents/jquery/js/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="Contents/jquery/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <!-- Three columns of text below the carousel -->
    <br /><br />
    <div class="row">
        <div class="jumbotron">
            <div class="container">
                <h1>
                    Bienvenue!</h1>
                    <p>Cette page donne l'accès à l'intranet d'ESPRIT et est réservée aux étudiants, à leurs parents, au personnel de l'école, enseignants et personnel administratif.</p>
                <%--<p>
                    This is a template for a simple marketing or informational website. It includes
                    a large callout called a jumbotron and three supporting pieces of content. Use it
                    as a starting point to create something more unique.</p>--%>
                <p>
                    <a class="btn btn-default btn-lg" href="Online/default.aspx" role="button">Se Connecter »</a></p>
            </div>
        </div>
        <div class="col-lg-4">
            <a href="Online/default.aspx#tabs-2" role="button"><img src="../images/bb_jam_101212.jpg" style="width: 140px; height: 140px;" class="img-circle" data-src="holder.js/140x140"
                alt="140x140"></a>
            <h2 class="text-danger">
                Espace Etudiant</h2>
            <p>
                L'espace étudiant renferme les informations qui vous permettront 
                de bien organiser votre vie étudiante : horaires, documents de référence, plusieurs liens utiles, etc. Bonne navigation!</p>
           
        </div>
        <!-- /.col-lg-4 -->
        <div class="col-lg-4">
            <a href="Online/default.aspx#tabs-3" role="button" ><img src="../images/image001.jpg" href="default.aspx#tabs-3" style="width: 140px; height: 140px;" class="img-circle" data-src="holder.js/140x140"
                alt="140x140"></a>
            <h2 class="text-danger">
                Espace Parents</h2>
            <p>L'espace parents est un endroit privilégié pour effectuer un suivi personnalisé du cheminement scolaire de votre enfant (résultats scolaires et absences).</p>
            
        </div>
        <!-- /.col-lg-4 -->
        <div class="col-lg-4">
            <a href="Online/default.aspx#tabs-1" role="button"><img src="../images/ens.jpg" style="width: 140px; height: 140px;" class="img-circle" data-src="holder.js/140x140"
                alt="140x140"></a>
            <h2 class="text-danger">
                Espace Enseignant</h2>
            <p>L'espace enseignant est un endroit réservé aux enseignants.</p><br /><br />
              
        </div>
        <!-- /.col-lg-4 -->
    </div>
    <!-- /.row -->
</asp:Content>
