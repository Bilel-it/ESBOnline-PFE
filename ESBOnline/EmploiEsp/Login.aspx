<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" MasterPageFile="~/EmploiEsp/Edt.Master"
 Inherits="ESPOnline.EmploiEsp.Login" %>


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
         
          <!--css esponline-->
           <link href="../Contents/Css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
    <%--<link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />--%>
    <link href="../Contents/Css/bootstrap.min.css" rel="stylesheet" type="text/css" />
  <%--  <link href="../Contents/jquery/css/blitzer/jquery-ui-1.10.3.custom.css" rel="stylesheet"
        type="text/css" />--%>
    <script src="../Contents/jquery/js/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Contents/jquery/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript">
    </script>
   

<style type="text/css">
     .nav-pills > li.active > a,
.nav-pills > li.active > a:hover,
.nav-pills > li.active > a:focus {
  color: #ffffff;
  background-color:  #D00000 ;}
        .style1
        {
            color: #000000;
        }
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     
   <div class="row">
        <div class="mainWrapper">
            <div class="wrapper">
                
                <div class="container">
                <script>
                    $(function () {
                        $("#tabs").tabs();
                    });
                 </script>
                    <div id="tabs">
                        <div class="ui-tabs">
                            <ul >                          
                                <li><a href="#tabs-2">Espace Etudiants</a></li>
                                <li><a href="#tabs-3">Espace Parents</a></li>
                                <li><a href="#tabs-1">Espace Enseignants</a></li>
                                <li><a href="#tabs-6">Administration & Gouvernance </a></li>
                                </ul>
                            
                            <%--Espace Enseignants--%>
                            <div id="tabs-1">
                                <asp:Panel ID="Panel1" runat="server" DefaultButton ="Button1">
                               
                                <div class="row">
                                    <div class="col-lg-6">
                                        <div class="well-lg">
                                            <div class="breadcrumb">
                                                <img class="img-thumbnail" src="../Contents/Img/ens.jpg" />
                                                <h2 class="featurette-heading">
                                                    ESPRIT ... <span class="text-muted">Se Former autrement pour une nouvelle génération
                                                        d&#39;ingénieurs.</span></h2>
                                                <%-- <p class="text-center"><a class="btn btn-lg btn-danger" href="#">Get started today</a></p>--%>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="well-lg">
                                            <div class="form-signin">
                                                <div class="form-group">
                                                    <h2 class="form-signin-heading" style="color: #000000">
                                                        Espace Enseignant</h2>
                                                        <p class="style1">
                                                        Protégez vos données personnelles Si vous utilisez un ordinateur public ou partagé,
                                                        assurez-vous de quitter le navigateur à la fin de votre session de travail.
                                                    </p>
                                                </div>
                                                <br />
                                                <div class="form-group">
                                                    <asp:TextBox  Height="35px" Width="400px" ID="TextBox1" placeholder="Identifiant" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                                                        ValidationGroup="EnsignantInfoGroup" ErrorMessage="Identifiant incorrect " CssClass="text-danger"></asp:RequiredFieldValidator>
                                                    <%--<asp:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender" 
                                                                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
                                                            </asp:ValidatorCalloutExtender>  --%>
                                                </div>
                                                <div class="form-group">
                                                    <asp:TextBox  Height="35px" Width="400px" ID="TextBox2" TextMode="Password" placeholder="Mot de passe"
                                                        runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2"
                                                        ValidationGroup="EnsignantInfoGroup" ErrorMessage="Password incorrect" CssClass="text-danger"></asp:RequiredFieldValidator>
                                                    <%--<asp:ValidatorCalloutExtender ID="RequiredFieldValidator2_ValidatorCalloutExtender" 
                                                                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator2">
                                                            </asp:ValidatorCalloutExtender>--%>
                                                </div>
                                                <div class="form-group">
                                                    <asp:Button ID="Button1" CssClass="btn btn-lg btn-block btn-danger" Text="Connexion"   Width="400px"
                                                        ValidationGroup="EnsignantInfoGroup" OnClick="Button1_Click" runat="server" />
                                                </div>
                                                <asp:Label ID="Label1" runat="server"></asp:Label>
                                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                                </asp:ScriptManager>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                 </asp:Panel>
                            </div>
                              <%--Espace Direction--%>
                            <div id="tabs-6">
                                <asp:Panel ID="Panel4" runat="server" DefaultButton ="ButtonAdmin">
                               
                                <div class="row">
                                    <div class="col-lg-6">
                                        <div class="well-lg">
                                            <div class="breadcrumb">
                                                <img class="img-thumbnail" src="../Contents/Img/stat.jpg" />
                                                <h2 class="featurette-heading">
                                                    ESPRIT ... <span class="text-muted">Se Former autrement pour une nouvelle génération
                                                        d&#39;ingénieurs.</span></h2>
                                             
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="well-lg">
                                            <div class="form-signin">
                                                <div class="form-group">
                                                    <h2 class="form-signin-heading" style="color: #000000">
                                                        Espace Administration & Gouvernance</h2>
                                                        <p>
                                                            <span class="style1">Protégez vos données personnelles Si vous utilisez un 
                                                            ordinateur public ou partagé, assurez-vous de quitter le navigateur à la fin de 
                                                            votre session de travail.</span>
                                                    </p>
                                                </div>
                                                <br />
                                                <div class="form-group">
                                                    <asp:TextBox Height="35px" Width="400px" ID="TextBox5" placeholder="Identifiant" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox5"
                                                        ValidationGroup="AdminInfoGroup" ErrorMessage="Identifiant incorrect " CssClass="text-danger"></asp:RequiredFieldValidator>
                                                  
                                                </div>
                                                <div class="form-group">
                                                    <asp:TextBox Height="35px" Width="400px" ID="TextBox6" TextMode="Password" placeholder="Mot de passe"
                                                        runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox6"
                                                        ValidationGroup="AdminInfoGroup" ErrorMessage="Password incorrect" CssClass="text-danger"></asp:RequiredFieldValidator>
                                                 
                                                </div>
                                                <div class="form-group">
                                                    <asp:Button ID="ButtonAdmin" CssClass="btn btn-lg btn-block btn-danger" Text="Connexion"  Width="400px"
                                                        ValidationGroup="AdminInfoGroup"  runat="server" 
                                                        onclick="ButtonAdmin_Click"          />
                                                </div>
                                                <asp:Label ID="Label4" runat="server"></asp:Label>
                                               
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                 </asp:Panel>
                            </div>
                          <%--  Espace Etudiants--%>
                            <div id="tabs-2">
                                <asp:Panel ID="Panel2" runat="server" DefaultButton="ButtonEtudiant">
                                
                                <div class="row">
                                    <div class="col-lg-6">
                                        <div class="well-lg">
                                            <div class="breadcrumb">
                                                <img class="img-thumbnail" src="../Contents/Img/affiche_200613.jpg" />
                                                <h2 class="featurette-heading">
                                                    ESPRIT ... <span class="text-muted">Se Former autrement pour une nouvelle génération
                                                        d&#39;ingénieurs.</span></h2>
                                              
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="well-lg">
                                            <div class="form-signin">
                                                <div class="form-group">
                                                    <h2 class="form-signin-heading" style="color: #000000">
                                                        Espace Etudiant</h2>
                                                    <p class="style1">
                                                        Protégez vos données personnelles Si vous utilisez un ordinateur public ou partagé,
                                                        assurez-vous de quitter le navigateur à la fin de votre session de travail.
                                                    </p>
                                                </div>
                                                <br />
                                                <div class="form-group">
                                                    <asp:TextBox Height="35px" Width="400px" ID="TextBox3" placeholder="Votre CIN ou ID" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3"
                                                        ValidationGroup="EtudiantInfoGroup" ErrorMessage="Cin incorrect " CssClass="text-danger"></asp:RequiredFieldValidator>
                                                    
                                                </div>
                                                 <div class="form-group">
                                                    <asp:TextBox  Height="35px" Width="400px" ID="TextBox7" placeholder="Mot de passe" TextMode="Password" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBox7"
                                                        ValidationGroup="EtudiantInfoGroup" ErrorMessage="Mot de passe incorrect " CssClass="text-danger"></asp:RequiredFieldValidator>
                                                    
                                                </div>
                                                <div class="form-group">
                                                    <asp:Button ID="ButtonEtudiant" CssClass="btn btn-lg btn-block btn-danger" Text="Connexion"   Width="400px"
                                                        ValidationGroup="EtudiantInfoGroup" runat="server" OnClick="ButtonEtudiant_Click" />
                                                </div>
                                                <asp:Label ID="Label2" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                </asp:Panel>
                            </div>
                            <%--Espace parent--%>
                            <div id="tabs-3">
                            <asp:Panel ID="Panel3" runat="server" DefaultButton="ButtonParent">
                                <div class="row">
                                    <div class="col-lg-6">
                                        <div class="well-lg">
                                            <div class="breadcrumb">
                                                <img class="img-thumbnail" src="../Contents/Img/affiche_200613.jpg" />
                                                <h2 class="featurette-heading">
                                                    ESPRIT ... <span class="text-muted">Se Former autrement pour une nouvelle génération
                                                        d&#39;ingénieurs.</span></h2>
                                                <%-- <p class="text-center"><a class="btn btn-lg btn-danger" href="#">Get started today</a></p>--%>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="well-lg">
                                            <div class="form-signin">
                                                <div class="form-group">
                                                    <h2 class="form-signin-heading" style="color: #000000">
                                                        Espace Parent</h2>
                                                        <p class="style1">
                                                        Protégez vos données personnelles Si vous utilisez un ordinateur public ou partagé,
                                                        assurez-vous de quitter le navigateur à la fin de votre session de travail.
                                                    </p>
                                                </div>
                                                <br />
                                                <div class="form-group">
                                                    <asp:TextBox Height="35px" Width="400px" ID="TextBox4" placeholder="Veuillez saisir le n° CIN de l'étudiant "
                                                        runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox4"
                                                        ValidationGroup="ParentInfoGroup" ErrorMessage="Cin incorrect " CssClass="text-danger"></asp:RequiredFieldValidator>
                                                    <%--<asp:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender" 
                                                                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
                                                            </asp:ValidatorCalloutExtender>  --%>
                                                </div>
                                                 <div class="form-group">
                                                     &nbsp;
                                                    <%--<asp:TextBox   ID="TextBox8" placeholder="Mot de passe"  
                                                         Height="35px" Width="400px" TextMode="Password"          runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TextBox8"
                                                        ValidationGroup="ParentInfoGroup" ErrorMessage="Mot de passe incorrect " CssClass="text-danger"></asp:RequiredFieldValidator>--%>
                                                    <%--<asp:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender" 
                                                                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
                                                            </asp:ValidatorCalloutExtender>  --%>
                                                </div>
                                                <div class="form-group">
                                                    <asp:Button ID="ButtonParent" CssClass="btn btn-lg btn-block btn-danger" Text="Connexion"   Width="400px"
                                                        ValidationGroup="ParentInfoGroup" runat="server" OnClick="ButtonParent_Click" />
                                                </div>
                                                <asp:Label ID="Label3" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                </asp:Panel>
                            </div>
                        </div>
                        
                    </div>
                </div>
                      </div>
            </div>
            <div class="push">
            </div>
           
        </div>
  
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <center>
    <h2 class="style1">
                                                        <strong class="style4"><em>Espace D'Authentification</em></strong></h2>
                                                        <p style="font-size: large; font-weight: 700; color: #FFFFFF;">
                                                            <span class="style2"><span class="style3">Protégez vos données personnelles Si vous utilisez un ordinateur public ou partagé,
                                                            </span>
                                                            <span class="style3">assurez-vous de quitter le navigateur à la fin de votre session de travail.</span></span>
                                                    </p>
                                                    <br />
                                                <div class="form-group">
                                                
                                                    <asp:TextBox  Height="35px" Width="400px" ID="TextBox1" placeholder="Identifiant" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                                                        ValidationGroup="EnsignantInfoGroup" ErrorMessage="Identifiant incorrect " CssClass="text-danger"></asp:RequiredFieldValidator>
                                                    <br />
                                                   <br />
                                                </div>
                                                <div class="form-group">
                                                    <asp:TextBox  Height="35px" Width="400px" ID="TextBox2" TextMode="Password" placeholder="Mot de passe"
                                                        runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2"
                                                        ValidationGroup="EnsignantInfoGroup" ErrorMessage="Password incorrect" CssClass="text-danger"></asp:RequiredFieldValidator>
                                                  
                                                </div>
                                                <br />
                                                <div class="form-group" >
                                                <center>
                                                    <asp:ImageButton ID="btnOK" runat="server" ImageUrl="~/EDTCss/imagesemploi/connexion.png" 
                                                ToolTip="Log In" TabIndex="3" Height="40px" onclick="btnOK_Click1" 
                                                Width="150px"  />
                                                </center> 
                                                </div>
                                                <asp:Label ID="Label1" runat="server"></asp:Label>
                                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                                </asp:ScriptManager>
 </center>                                               
</asp:Content>--%>