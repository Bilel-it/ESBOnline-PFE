<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/EmploiEsp/SiteEDT.Master" CodeBehind="LoginPage.aspx.cs" 
Inherits="ESPOnline.EmploiEsp.LoginPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

        <meta http-equiv="content-type" content="text/html; charset=utf-8" />
		<meta name="description" content="" />
		<meta name="keywords" content="" />
		<script src="../EDTCss/jsemploi/jquery.min.js" type="text/javascript"></script>
		<script src="../EDTCss/jsemploi/skel.min.js"  type="text/javascript"></script>
		<script src="../EDTCss/jsemploi/skel-layers.min.js"  type="text/javascript"></script>
		<script src="../EDTCss/jsemploi/init.js"  type="text/javascript"></script>
			<link rel="stylesheet" href="../EDTCss/cssemploi/skel.css" />
			<link rel="stylesheet" href="../EDTCss/cssemploi/style.css" />
			<link rel="stylesheet" href="../EDTCss/cssemploi/style-desktop.css" />
		<!--[if lte IE 9]><link rel="stylesheet" href="css/ie9.css" /><![endif]-->
		<!--[if lte IE 8]><script src="js/html5shiv.js"></script><![endif]-->
         <script src="../Contents/jquery/js/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Contents/jquery/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript">
    </script>
</asp:Content>
<asp:Content  ID="Conthead" ContentPlaceHolderID="header" runat="server">
 
<%--<nav id="nav">
                                
					<div class="row">
                   
						<div class="12u">

                                 <asp:LinkButton ID="LinkBtnaffecter" runat="server" PostBackUrl="" >Affecter Enseignant</asp:LinkButton>
                                 <asp:LinkButton ID="Linkbtncalender" runat="server" PostBackUrl="" >Calendrier</asp:LinkButton>
                                 <asp:LinkButton ID="LinkBtnverifIndispo" runat="server" PostBackUrl="" >Verifier Indisponibilité</asp:LinkButton>
                                 <asp:LinkButton ID="LinkBtnConsulteredt" runat="server" PostBackUrl="" >Consulter Emploi</asp:LinkButton>
                                 <asp:LinkButton ID="LinkBtContact" runat="server" PostBackUrl="" >Contact</asp:LinkButton>
                                
                                 </div>
                                 </div>
                                 </nav>--%>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


     <center style="font-family: 'Times New Roman', Times, serif; color: #CCCCCC; border: medium solid #CCCCCC; background-color: #333333;" 
         class="container">
     
     

					
<%--<a href="#" class="">
                            <img src="../Css-Template/listimage/images/agenda_clip_image004.jpg" alt="" width="500px"
                                height="250px" /></a>--%>
             <h2 class="style1" >
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

    </asp:Content>


         