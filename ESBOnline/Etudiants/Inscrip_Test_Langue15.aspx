<%@ Page Title="" Language="C#" MasterPageFile="~/Etudiants/Eol.Master" AutoEventWireup="true" CodeBehind="Inscrip_Test_Langue15.aspx.cs" Inherits="ESPOnline.Etudiants.Inscrip_Test_Langue" %>
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
          .style2
          {
              color: #FF0000;
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

      
          .style3
          {
              color: #000000;
          }

      
          .style4
          {
              font-size: large;
          }

      
          </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
<br />
<br />
<br />
<center>
<table runat="server" ID="tbl">
<tr>
<td class="style2"> 
    * <span class="style3">Veuillez choisir votre date de passage de l&#39;examen d&#39;évaluation de test de 
    niveau (Choix entre trois dates uniques).</span></td>
</tr> 

<tr>
<td class="style2"> 
   *  <span class="style3">Après validation, vos choix ne seront plus modifiables.
    </span>
 </td>
</tr>  


<tr><td class="style2">
* <span class="style3">Le nombre d'inscription ne doit pas dépasser 150 personnes par date.
    </span>
</td></tr>   
<tr><td>
<span class="style2">*  
    </span>
    les étudiants auront droit à une seule inscription par épreuve, les absences ne seront pas donc tolérées.
<span class="style2">
    <br />
    *  les étudiants auront un niveau B2 seront invités à passer le test TOIEC ou 
    bien PREP TOIEC.
    </span>
</td></tr>  
<tr><td></td></tr>  
</table>

<asp:Panel ID="panel"  runat="server" BackColor="#CC0000">
 <br />
 <br />
 <br />
 <center><h1 class="style1">INSCRIPTION AU TEST DU LANGUE POUR L'ANNEE UNIVERSITAIRE: <asp:Label ID="lblanneedeb" runat="server" CssClass="style7"></asp:Label>/<asp:Label 
            ID="lblanneefin" runat="server" CssClass="style7"></asp:Label></h1></center>
 <center>
 
     Classe:<asp:Label ID="lblcodecl" runat="server" align="right"></asp:Label>

 <table  height="300px" bgcolor="#CCCCCC" 
         style="background-color: #CCCCCC; width: 860px;">
         <tr><td></td></tr>
 
         <tr>
             <td>
                 <asp:Label ID="lblfr" runat="server" Text="Test Français"></asp:Label>
             </td>
             <td>
                 <asp:DropDownList ID="ddltestfr" runat="server" AppendDataBoundItems="true" 
                     AutoPostBack="true" dataTextFormatString="{0:dd/MM/yyyy}" 
                     >
                     <asp:ListItem>--Choisir la date du test Français--</asp:ListItem>
                 </asp:DropDownList>
             </td>
             <td> <asp:Label ID="Label6" runat="server" Text="Nombre d'Inscription :"></asp:Label>
                                    <asp:Label ID="LabCount" runat="server"></asp:Label><asp:Label ID="lbl" runat="server" Text=":étudiant(e)s"></asp:Label></td>
         </tr>
 <tr><td></td></tr>

 <tr>
 <td>
 <asp:Label ID="lbltestang" runat="server" Text="Test Anglais"></asp:Label>
 </td>

 <td>
 <asp:DropDownList ID="ddltestang" runat="server" AutoPostBack="true"   
         AppendDataBoundItems="true" dataTextFormatString="{0:dd/MM/yyyy}"
            >
                    <asp:listitem>--Choisir la date du test Anglais--</asp:listitem>
                    </asp:DropDownList>
 </td>
 <td> <asp:Label ID="Label1" runat="server" Text="Nombre d'Inscription :"></asp:Label>
                                    <asp:Label ID="LabCountang" runat="server"></asp:Label><asp:Label ID="Lab" runat="server" Text=":étudiant(e)s"></asp:Label></td>
 </tr> 
 <tr>
  <td></td>
   <%--<td  class="style7" align="center">
         <asp:Button ID="btnRemove" runat="server" CssClass="style12" Height="38px" 
            Text="Annuler" Width="91px" />
     </td>--%>
     <td  align="center">
         <asp:Button ID="btnOk" runat="server" CssClass="style12" Height="38px" 
             Text="Ajouter" Width="91px"    />
     </td>
 </tr>
 </table>
 </center>
 </asp:Panel>
 <asp:Panel ID="pl" runat="server">
 <br />
 <br />
 <asp:Label ID="lblTOIEC" runat="server" CssClass="style2"></asp:Label>
 <br />
 <br />
  <asp:Label ID="LblprepTOIEC" runat="server" CssClass="style2"></asp:Label>
  </asp:Panel>
 <br />
  <asp:Panel ID="panelddr" runat="server">
 <center>
 
 <table bgcolor="#999999" style="background-color: #CCCCCC">
 <tr><td height="30px"></td></tr>

 <tr>
<td height="30px">
<asp:Label ID="lblchek" runat="server" ForeColor="Red" CssClass="style4">
</asp:Label>

</td>
</tr>
<tr>
<td height="30px">
<asp:Label ID="lblchekPREP" runat="server" ForeColor="#666666" CssClass="style4"></asp:Label>

</td>
</tr>

<tr>
<td height="30px"></td>
</tr>
 <tr>
 
<td height="30px"><h1>Si vous êtes interssé par Toic ou prep TOIEC cochez:</h1></td> </tr>
<tr><td height="30px"></td></tr>
 <tr><td height="30px"><asp:CheckBox  ID="chkTOIEC" runat="server" Text="Examen TOIEC" AutoPostBack="true"
         /></td></tr><tr><td height="30px"></td></tr>
 <tr> <td height="30px"><asp:CheckBox  ID="chkprepTOIEC" runat="server" Text="PREPARATION TOIEC"  AutoPostBack="true"
         /></td>
 </tr>
 <tr><td height="30px"></td></tr>
 
 <tr>
 
 <td align="center" height="30px">
     <asp:Button ID="Button1" runat="server" Font-Bold="True" Font-Size="Large"
            Height="41px"  Text="Envoyer" Width="150px" onclick="Button1_Click" /></td>
 </tr>
 </table>
 </center>
 </asp:Panel>
</center>
    <br />
 <br />
<center> 
<asp:HyperLink ID="HyperLink1" NavigateUrl="~/Etudiants/Accueil.aspx" Text="Créer un compte" runat="server" ForeColor="#0033CC" > Retour à la page d'Accueil</asp:HyperLink></td></tr>
 

</center>
   

     


</asp:Content>