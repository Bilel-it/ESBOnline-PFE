<%@ Page Title="" Language="C#" MasterPageFile="~/Online/Esp.Master" AutoEventWireup="true" CodeBehind="Signin.aspx.cs" Inherits="ESPOnline.Online.Signin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Contents/Css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/sticky-footer-navbar.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/signin.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        

        <div class="col-lg-6">
        <div class="well-lg">
    <div class="breadcrumb">
        <img class="img-thumbnail" src="../Contents/Img/affiche_200613.jpg" />
        <h2 class="featurette-heading">ESPRIT ...
        <span class="text-muted">Se Former autrement pour une nouvelle génération d&#39;ingénieurs.</span></h2>
       <%-- <p class="text-center"><a class="btn btn-lg btn-danger" href="#">Get started today</a></p>--%>
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
            <%--<asp:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender" 
                                                                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
                                                            </asp:ValidatorCalloutExtender>  --%>                                   
        </div>
        
        <div class="form-group">
            
        <asp:TextBox CssClass="form-control" ID="TextBox2" TextMode="Password" placeholder="Mot de passe" runat="server"></asp:TextBox>                      
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" 
            ErrorMessage="Password incorrect" CssClass="text-danger"></asp:RequiredFieldValidator>
            <%--<asp:ValidatorCalloutExtender ID="RequiredFieldValidator2_ValidatorCalloutExtender" 
                                                                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator2">
                                                            </asp:ValidatorCalloutExtender>--%>
        </div>

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
