<%@ Page Title="" Language="C#" MasterPageFile="~/Parents/Par.Master" AutoEventWireup="true" CodeBehind="accueilp.aspx.cs" Inherits="ESPOnline.Parents.accueilp" %>
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
<div class="container">
<div class="jumbotron">
        <h2>Bienvenue dans votre Espace</h2>
        <p class="lead">Vous pouvez consulter dans cet espace :</p>
        <p><a class="btn-lg btn-link" href="emploi.aspx" role="button">L'Emploi du temps de votre enfant</a></p>
        <p><a class="btn-lg btn-link" href="absencepar.aspx" role="button">L'absence de votre enfant</a></p>
        
</div>
</div>
</asp:Content>