<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inscr_fr_ang_2015.aspx.cs" Inherits="ESPOnline.Etudiants.Inscr_fr_ang_2015" 
 MasterPageFile="~/Etudiants/Eol.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <script src="../Contents/jquery.js" type="text/javascript"></script>
    <link href="../Contents/Css/datetimepicker.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/animate.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <script src="../Contents/bootstrap.js" type="text/javascript"></script>
    <script src="../Contents/bootstrap.min.js" type="text/javascript"></script>
    <script src="../Contents/Scripts/bootstrap-datetimepicker.min.js" type="text/javascript"></script>
    <script src="../Contents/Scripts/bootstrap-datetimepicker.js" type="text/javascript"></script>

      <style type="text/css">
          .style1
          {
              color: #FFFFFF;
          }
          </style>


      <style type="text/css">
      
      table.grid tbody tr:hover {background-color:#e5ecf9;}
.GridHeaderStyle{color:#FEF7F7;background-color: #877d7d;font-weight: bold;}
.GridItemStyle{background-color:#eeeeee;color: white;}
.GridAlternatingStyle{background-color:#dddddd;color: black;}
.GridSelectedStyle{background-color:#d6e6f6;color: black;}


.GridStyle
{
	border-bottom: white 2px ridge; 
	border-left: white 2px ridge; 
	background-color: white; 
	width: 100%; 
	border-top: white 2px ridge; 
	border-right: white 2px ridge; 
}
.ItemStyle {
	BACKGROUND-COLOR: #eeeeee; 
	COLOR: black;
	padding-bottom: 5px;
	padding-right: 3px;
	padding-top: 5px;
	padding-left: 3px;
	height: 25px
}

.ItemStyle td{
	BACKGROUND-COLOR: #eeeeee; 
	COLOR: black;
	padding-bottom: 5px;
	padding-right: 3px;
	padding-top: 5px;
	padding-left: 3px;
	height: 25px
}
.FixedHeaderStyle {
	BACKGROUND-COLOR:  #7591b1; 
	COLOR: #FFFFFF; 
	FONT-WEIGHT: bold;
	position:relative ;   
	top:expression(this.offsetParent.scrollTop);  
	z-index: 10;  
}
.Caption_1_Customer
{
	background-color:#beccda;
	color: #000000;
	width: 30%;
	height: 20px;
}

      
          .style7
          {
              height: 30px;
              font-size: x-large;
          }
          
      
          </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
   

    <br />
<center>
<asp:Panel ID="Panelfrang" runat="server"  BackColor="#CC0000" Height="400px" 
        Width="1150px">
       
<center>
<table><tr><td class="style13"><h2 class="style1" style="color: #CCCCCC">
    <span class="style7">INSCRIPTION AU FORMATION FRANCAIS ET ANGLAIS :</span><span class="style14">
    <asp:Label ID="lblanneedeb" runat="server" CssClass="style7" Visible="false"></asp:Label>
    <asp:Label ID="lblanneefin" runat="server" CssClass="style7" Visible="false"></asp:Label>
    </span></h2></td></tr>
       </table>

 <%--<asp:Label ID="lblchoix" runat="server" Text="Certification TOEIC:Choisissez Toeic si vous voulez passer:" 
        ForeColor="White"></asp:Label>
 <br />
 <br />
 <asp:Label ID="lblprep" runat="server" Text="Prep TOEIC:Si vous voulez préparer la certification Toeic,choisissez:" 
        ForeColor="White"></asp:Label>--%>
        <asp:Panel ID="panel1" runat="server">
        <center>
<asp:HyperLink ID="HyperLink1" NavigateUrl="~/Etudiants/Accueil.aspx"  runat="server" ForeColor="#0033CC" > Retour à la page d'Accueil</asp:HyperLink>

</center>
        </asp:Panel>
      
 <asp:Panel ID="panelddr" runat="server">
 <center>
 <%--<asp:Panel ID="paneltoiec" runat="server" Width="550px" Height="20px">
 <table bgcolor="#999999" style="background-color: #CCCCCC">


 <tr>
        <td width="30px"></td>
         <td> <asp:Label ID="Label6" runat="server" Text="Nombre d'Inscription au certification TOEIC:"></asp:Label>
                                    <asp:Label ID="lblcounttoiec" runat="server" ForeColor="Red"></asp:Label><asp:Label ID="lbl" runat="server" Text=" Candidats"></asp:Label></td>
         
         </tr>
          </table></asp:Panel>--%>

 
  <%--<asp:Panel ID="panelprep" runat="server" Width="550px" Height="20px">
  
  <table bgcolor="#999999" style="background-color: #CCCCCC">

          <tr>
              <td>
                  <asp:Label ID="Label3" runat="server" Text="Nombre d'Inscription au preparation certification TOEIC:"></asp:Label>
                  <asp:Label ID="lblcountpreptoiec" runat="server" ForeColor="Red"></asp:Label>
                  <asp:Label ID="Label5" runat="server" Text=" Candidats"></asp:Label>
              </td>
          </tr>
    
 
 </table>
  
  </asp:Panel>--%>
  <center>
    
    <%-- <asp:Panel ID="plrst" runat="server" BackColor="#999999" Width="500px" Height="30px">
    <asp:Label ID="lbltpd" runat="server"></asp:Label>
    </asp:Panel>--%>
    
    </center>

  <h3 class="style1">Veuillez choisir la formation que vous voulez passer</h3>
     <p class="style1">
         &nbsp;</p>
  <asp:DropDownList ID="ddlchoix" runat="server" AutoPostBack="true" AppendDataBoundItems="true">
  <asp:ListItem Value="" >choisissez </asp:ListItem>
  <asp:ListItem Value="1">Passez formation français</asp:ListItem>
<asp:ListItem Value="2" >Passez formation Anglais</asp:ListItem>
  <asp:ListItem Value="3" >Passez les deux</asp:ListItem>
  </asp:DropDownList>

  <br />
  <br />

 <center>
     <asp:Button ID="Button1" runat="server" 
            Height="41px"  Text="Valider votre choix" Width="235px" 
         onclick="Button1_Click" /></center>
 </center>
 <br />
 </asp:Panel>
            </center>
            </asp:Panel>

            </center>
            <br />


</asp:Content>






