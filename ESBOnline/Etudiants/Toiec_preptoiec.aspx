<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Toiec_preptoiec.aspx.cs" Inherits="ESPOnline.Etudiants.Toiec_preptoiec" 
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

      
          .style4
          {
              font-size: medium;
          }

      
          .style6
          {
              font-size: medium;
              color: #000000;
          }

      
          .style7
          {
              height: 30px;
              font-size: x-large;
          }
          
      
          </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <center>

    

    <asp:Panel ID="panelmsg" runat="server" BackColor="#999999" Width="1050px" 
          >
    
    <table>
  <%--  <tr>
    
    
    
    <td class="style13"><h3 class="style1"><span class="style14" style="color: #FF0000">INSCRIPTION 
    AU TEST TOIEC ET PREPTOIEC POUR L'ANNEE UNIVERSITAIRE:
    <asp:Label ID="Label4" runat="server" CssClass="style7"></asp:Label>
    /<asp:Label ID="Label7" runat="server" CssClass="style7"></asp:Label>
    
    
   
    </tr>--%>
        <tr>
<td height="30px">
<asp:Label ID="Label1" runat="server" ForeColor="Black" CssClass="style6"></asp:Label>

</td>
</tr>
 <tr>
<td height="30px">
<asp:Label ID="Label2" runat="server" ForeColor="Black" CssClass="style6"></asp:Label>

</td>
</tr>
       
       <tr>
<td height="30px">
<asp:Label ID="lbltoiec" runat="server" ForeColor="White" CssClass="style4"></asp:Label>

</td>
</tr>
<tr>
<td>
<asp:Label ID="lblpreptoiec" runat="server" ForeColor="White" CssClass="style4"></asp:Label>

</td>
</tr>
       </table>
    </asp:Panel>
    <br />

<asp:Panel ID="Panelfrang" runat="server"  BackColor="#CC0000" Height="400px" 
        Width="1150px">
       
<center>
<table><tr><td class="style13"><h2 class="style1" style="color: #CCCCCC">
    <span class="style7">INSCRIPTION 
    AU CERTIFICATION TOEIC POUR L'ANNEE UNIVERSITAIRE:</span><span class="style14">
    <asp:Label ID="lblanneedeb" runat="server" CssClass="style7"></asp:Label>
    /<asp:Label ID="lblanneefin" runat="server" CssClass="style7"></asp:Label>
    </span></h2></td></tr>
       </table>
       
       
     
      
    <%--<table bgcolor="#999999" style="background-color: #CCCCCC; width: 749px;">
 <tr><td height="30px">
  <asp:Label ID="lblnb" runat="server" CssClass="style7"></asp:Label>
 </td></tr>

 


 <tr>
 
<td ><h4>Choisissez le test que vous voulez le passer puis valider votre choix:</h4></td> </tr>
<tr><td height="30px"></td></tr>
<asp:Panel ID="paneltoiec" runat="server">
 <tr><td height="30px"><asp:CheckBox  ID="chkTOIEC" runat="server" Text="TEST TOIEC" 
         AutoPostBack="true" 
         /></td></tr><tr><td height="30px"></td>
         <td>
         Nombre des inscrits au test TOIEC:<asp:Label ID="lblcounttoiec" runat="server" 
                 CssClass="style2" ForeColor="Black"></asp:Label>
         </td>
         
         </tr>


</asp:Panel>





<asp:Panel ID="panelprep" runat="server">


<tr> <td height="30px"><asp:CheckBox  ID="chkprepTOIEC" runat="server" 
         Text="TEST PREPARATION TOIEC"  AutoPostBack="true" 
         /></td>
         <td>
          Nombre condidats pour passer le test PRESP TOIEC<asp:Label ID="lblcountprep" 
                 runat="server" CssClass="style2" ForeColor="Black"></asp:Label>
         </td>
 </tr>
</asp:Panel>
 
 <tr><td class="style8"></td></tr>
 
 <tr>
 <td align="center" height="30px" class="style9">
     <asp:Button ID="Button1" runat="server" Font-Bold="True" 
            Height="41px"  Text="Valider votre choix" Width="200px" 
         onclick="Button1_Click" /></td>
 </tr>
 </table>--%>
 
 <br />
 <asp:Label ID="lblchoix" runat="server" Text="Certification TOEIC:Cochez Toeic si vous voulez passer:" 
        ForeColor="White"></asp:Label>
 <br />
 <br />
 <asp:Panel ID="panelddr" runat="server">
 <center>
 <asp:Panel ID="paneltoiec" runat="server" Width="550px" Height="20px">
 <table bgcolor="#999999" style="background-color: #CCCCCC">


 <tr><td height="50px"><asp:CheckBox  ID="chkTOIEC" runat="server" Text="Certification TOEIC" AutoPostBack="true"
        /></td>
        <td width="30px"></td>
         <td> <asp:Label ID="Label6" runat="server" Text="Nombre d'Inscription :"></asp:Label>
                                    <asp:Label ID="lblcounttoiec" runat="server" ForeColor="Red"></asp:Label><asp:Label ID="lbl" runat="server" Text=":Candidats"></asp:Label></td>
         
         </tr>
          </table></asp:Panel>

 <br />
 <br />
 <asp:Label ID="lblprep" runat="server" Text="Prep TOEIC:Si vous voulez préparer la certification Toeic,cochez:" 
        ForeColor="White"></asp:Label>
        <br />
        <br />
  <asp:Panel ID="panelprep" runat="server" Width="550px" Height="20px">
  
  <table bgcolor="#999999" style="background-color: #CCCCCC">
      <caption>

      
          <tr>
              <td height="50px">
                  <asp:CheckBox ID="chkprepTOIEC" runat="server" AutoPostBack="true" 
                      Text=" Certification PREP TOEIC" />
              </td>
               <td width="30px"></td>
              <td>
                  <asp:Label ID="Label3" runat="server" Text="Nombre d'Inscription :"></asp:Label>
                  <asp:Label ID="lblcountpreptoiec" runat="server" ForeColor="Red"></asp:Label>
                  <asp:Label ID="Label5" runat="server" Text=":Candidats"></asp:Label>
              </td>
          </tr>
      </caption>
 
 </table>
  
  </asp:Panel>
         
 <br />
 <br /> 
 

 <center>
     <asp:Button ID="Button1" runat="server" 
            Height="41px"  Text="Valider votre choix" Width="203px" 
         onclick="Button1_Click" /></center>
 </center>
 <br />
 </asp:Panel>
            </center>
            </asp:Panel>

            </center>
            <br />
<center>
<asp:HyperLink ID="HyperLink1" NavigateUrl="~/Etudiants/Accueil.aspx" Text="Créer un compte" runat="server" ForeColor="#0033CC" > Retour à la page d'Accueil</asp:HyperLink>

</center>

</asp:Content>

