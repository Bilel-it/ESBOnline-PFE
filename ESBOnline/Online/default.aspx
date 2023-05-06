<%@ Page Title="" Language="C#" MasterPageFile="~/Online/Esp.Master" AutoEventWireup="true"
    CodeBehind="default.aspx.cs" Inherits="ESPOnline.Online._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Contents/Css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/jquery/css/blitzer/jquery-ui-1.10.3.custom.css" rel="stylesheet"
        type="text/css" />
    <script src="../Contents/jquery/js/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Contents/jquery/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript">
    
    </script>
    <style type="text/css">
        .nav-pills > li.active > a, .nav-pills > li.active > a:hover, .nav-pills > li.active > a:focus
        {
            color: #ffffff;
            background-color: #D00000;
        }
        .style1
        {
            color: #000000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                            <ul>
                                <li id="a1" runat="server"><a href="#tabs-2">Espace Etudiants</a></li>
                                <li id="a2" runat="server"><a href="#tabs-3">Espace Parents</a></li>
                                <li id="a3" runat="server"><a href="#tabs-1">Espace Enseignants</a></li>
                                <li id="a4" runat="server"><a href="#tabs-6">Administration & Gouvernance </a></li>
                            </ul>
                            <%--Espace Enseignants--%>
                            <div id="tabs-1">
                                <asp:Panel ID="Panel1" runat="server" DefaultButton="Button1">
                                    <div class="row">
                                        <div class="col-sm-3 col-md-6 col-lg-6">
                                            <div class="well-lg">
                                                <div class="breadcrumb">
                                                    <img class="img-thumbnail" src="" />
                                                    <h2 class="featurette-heading">
                                                        School of Business... <span class="text-muted">&nbsp;</span></h2>
                                                    <%-- <p class="text-center"><a class="btn btn-lg btn-danger" href="#">Get started today</a></p>--%>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-3 col-md-6 col-lg-6">
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
                                                    <asp:Label ID="Label5" runat="server" Text="Identifiant" Font-Bold="True" Font-Italic="True"></asp:Label>
                                                    <br />
                                                    <div class="form-group">
                                                        <asp:TextBox Height="35px" Width="400px" ID="TextBox1" placeholder="Identifiant"
                                                            runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                                                            ValidationGroup="EnsignantInfoGroup" ErrorMessage="Identifiant incorrect " CssClass="text-danger"></asp:RequiredFieldValidator>
                                                        <%--<asp:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender" 
                                                                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
                                                            </asp:ValidatorCalloutExtender>  --%>
                                                        <br />
                                                        <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Italic="True" ForeColor="#CC0000"
                                                            Text="Mot de passe" Visible="False"></asp:Label>
                                                        <br />
                                                        <asp:TextBox Height="35px" Width="400px" ID="TextBox2" TextMode="Password" placeholder="Mot de passe"
                                                            runat="server" Visible="false"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2"
                                                            ValidationGroup="EnsignantInfoGroup" ErrorMessage="Password incorrect" CssClass="text-danger"
                                                            Enabled="false"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="form-group">
                                                        <%--<asp:ValidatorCalloutExtender ID="RequiredFieldValidator2_ValidatorCalloutExtender" 
                                                                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator2">
                                                            </asp:ValidatorCalloutExtender>--%>
                                                    </div>
                                                    <div class="form-group">
                                                        <asp:Button ID="Button1" CssClass="btn btn-lg btn-block" Text="Suivant" Width="400px"
                                                            ValidationGroup="EnsignantInfoGroup" runat="server" OnClick="Button1_Click1"
                                                            BackColor="#999999" ForeColor="Black" />
                                                        <asp:Button ID="Button2" CssClass="btn btn-lg btn-block btn-danger" Text="Connexion"
                                                            Width="400px" ValidationGroup="EnsignantInfoGroup" OnClick="Button1_Click" runat="server"
                                                            Visible="false" />
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
                                <asp:Panel ID="Panel4" runat="server" DefaultButton="ButtonAdmin">
                                    <div class="row">
                                        <div class="col-sm-3 col-md-6 col-lg-6">
                                            <div class="well-lg">
                                                <div class="breadcrumb">
                                                    <img class="img-thumbnail" src="../Contents/Img/page_adminstration.jpg" />
                                                    <h2 class="featurette-heading">
                                                        School of Business...<span class="text-muted"> </span>
                                                    </h2>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-3 col-md-6 col-lg-6">
                                            <div class="well-lg">
                                                <div class="form-signin">
                                                    <div class="form-group">
                                                        <h2 class="form-signin-heading" style="color: #000000">
                                                            Espace Administration & Gouvernance</h2>
                                                        <p>
                                                            <span class="style1">Protégez vos données personnelles Si vous utilisez un ordinateur
                                                                public ou partagé, assurez-vous de quitter le navigateur à la fin de votre session
                                                                de travail.</span>
                                                        </p>
                                                    </div>
                                                    <br />
                                                    <div class="form-group">
                                                        <asp:TextBox Height="35px" Width="400px" ID="TextBox5" placeholder="Identifiant"
                                                            runat="server"></asp:TextBox>
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
                                                        <asp:Button ID="ButtonAdmin" CssClass="btn btn-lg btn-block btn-danger" Text="Connexion"
                                                            Width="400px" ValidationGroup="AdminInfoGroup" runat="server" OnClick="ButtonAdmin_Click" />
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
                                <asp:Panel ID="Panel2" runat="server" DefaultButton="Button3">
                                    <div class="row">
                                        <div class="col-sm-3 col-md-6 col-lg-6">
                                            <div class="well-lg">
                                                <div class="breadcrumb">
                                                    <img class="img-thumbnail" src="../Contents/Img/image_ET.jpg" />
                                                    <h2 class="featurette-heading">
                                                        School of Business...</h2>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-3 col-md-6 col-lg-6">
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
                                                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Italic="True" Text="Identifiant"></asp:Label>
                                                    <br />
                                                    <div class="form-group">
                                                        <asp:TextBox Height="35px" Width="400px" ID="TextBox3" placeholder="Votre CIN ou ID"
                                                            runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3"
                                                            ValidationGroup="EtudiantInfoGroup" ErrorMessage="Cin incorrect " CssClass="text-danger"></asp:RequiredFieldValidator>
                                                        <br />
                                                        <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Italic="True" Text="Mot de passe"
                                                            Visible="False" ForeColor="#990033"></asp:Label>
                                                        <asp:TextBox Height="35px" Width="400px" ID="TextBox7" placeholder="Mot de passe"
                                                            TextMode="Password" runat="server" Visible="false"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBox7"
                                                            ValidationGroup="EtudiantInfoGroup" ErrorMessage="Mot de passe incorrect " CssClass="text-danger"
                                                            Enabled="false"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="form-group">
                                                    </div>
                                                    <div class="form-group">
                                                        <asp:Button ID="ButtonEtudiant" CssClass="btn btn-lg btn-block btn-danger" Text="Connexion"
                                                            Width="400px" ValidationGroup="EtudiantInfoGroup" runat="server" OnClick="ButtonEtudiant_Click"
                                                            Visible="false" />
                                                             <asp:LinkButton ID="LinkButton2" runat="server" ForeColor="#CC0000" 
                                                         Visible="false" onclick="LinkButton2_Click"
                                                         >J&#39;ai oublié mon mot de passe</asp:LinkButton>
                                                        <asp:Button ID="Button3" CssClass="btn btn-lg btn-block" Text="Suivant" Width="400px"
                                                            BackColor="#666666" ForeColor="Black" ValidationGroup="EtudiantInfoGroup" runat="server"
                                                            OnClick="Button3_Click" />
                                                    </div>
                                                    <asp:Label ID="Label2" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </asp:Panel>
                            </div>
                            <%--Espace Etudiants--%>
                            <div id="tabs-3">
                                <asp:Panel ID="Panel3" runat="server" DefaultButton="ButtonParent">
                                    <div class="row">
                                        <div class="col-sm-3 col-md-6 col-lg-6">
                                            <div class="well-lg">
                                                <div class="breadcrumb">
                                                    <img class="img-thumbnail" src="../Contents/Img/image_ET.jpg" />
                                                    <h2 class="featurette-heading">
                                                        School of Business...</h2>
                                                    <%-- <p class="text-center"><a class="btn btn-lg btn-danger" href="#">Get started today</a></p>--%>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-3 col-md-6 col-lg-6">
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
                                                 <asp:Label ID="Label99" runat="server" Font-Bold="True" Font-Italic="True" 
                                                    Text="Numéro CIN"></asp:Label>
                                                <br />
                                                <div class="form-group">
                                                    <asp:TextBox Height="35px" Width="400px" ID="TextBox4" placeholder="Veuillez saisir le n° CIN de l'étudiant "
                                                        runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox4"
                                                        ValidationGroup="ParentInfoGroup" ErrorMessage="Cin incorrect " CssClass="text-danger"></asp:RequiredFieldValidator>
                                                    <%--<asp:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender" 
                                                                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
                                                            </asp:ValidatorCalloutExtender>  --%>
                                                            <br />
                                                            <asp:Label ID="Label95" runat="server" Font-Bold="True" Font-Italic="True" 
                                                    Text="Mot de passe"  ForeColor="#990033"></asp:Label>
                                                             <asp:TextBox  Height="35px" Width="400px" ID="pass_parent" placeholder="Mot de passe" TextMode="Password" runat="server" ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TextBox7"
                                                        ValidationGroup="EtudiantInfoGroup" ErrorMessage="Mot de passe incorrect " CssClass="text-danger" Enabled="false"></asp:RequiredFieldValidator>
                                                    
                                                </div>
                                                <%-- <div class="form-group">
                                                     &nbsp;</div>--%>
                                                <div class="form-group">
                                                    <asp:Button ID="ButtonParent" CssClass="btn btn-lg btn-block btn-danger" Text="Connexion"   Width="400px"
                                                        ValidationGroup="ParentInfoGroup" runat="server" OnClick="ButtonParent_Click" />
                                                    <br />
                                                  
                                                    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
                                                        ForeColor="#CC0000">J'ai oublié mon mot de passe</asp:LinkButton>
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
            <div class="push">
            </div>
        </div>
    </div>
</asp:Content>
