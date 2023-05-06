<%@ Page Title="" Language="C#" MasterPageFile="~/Online/Esp.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ESPOnline.Online.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Contents/Css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/sticky-footer-navbar.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/signin.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            -webkit-box-shadow: 0 1px 2px rgba(0, 0, 0, 0.075);
            box-shadow: 0 1px 2px rgba(0, 0, 0, 0.075);
            display: inline-block;
            height: 339px;
            max-width: 100%;
            line-height: 1.428571429;
            border-radius: 4px;
            -webkit-transition: all .2s ease-in-out;
            transition: all .2s ease-in-out;
            width: 404px;
            border: 1px solid #ddd;
            padding: 4px;
            background-color: #fff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        

        <div class="col-lg-6">
        <div class="well-lg">
    <div class="breadcrumb">
        &nbsp;<img class="auto-style1" src="https://esprit-tn.com/esbonline/Contents/Img/logoESB.png" /><h2 class="featurette-heading">ESPRIT ESB...</h2>
    
      </div>
      </div>
      
    </div>
    <div class="col-lg-6">
     <div class="well-lg">
    <div class="form-signin">
    <div class="form-group">
        <h2 class="form-signin-heading" style="color: #000000">Se connecter</h2>
        </div>
        <div class="form-group">

        <asp:TextBox CssClass="form-control" ID="TextBox1" placeholder="Identifiant" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" 
            ErrorMessage="Identifiant incorrect " CssClass="text-danger"></asp:RequiredFieldValidator>
                                         
        </div>
        
        <div class="form-group">
            
      
         

        <div class="form-group">
        <asp:Button ID="Button1" CssClass="btn btn-lg btn-block btn-danger" Text="Connexion" Onclick="Button1_Click" runat="server"/>
        </div>
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
      </div>
      </div>

    </div>
    
    </div>
</asp:Content>
