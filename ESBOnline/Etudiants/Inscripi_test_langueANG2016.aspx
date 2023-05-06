<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inscripi_test_langueANG2016.aspx.cs" 
Inherits="ESPOnline.Etudiants.Inscripi_test_langueANG2016"  MasterPageFile="~/Etudiants/Eol.Master"%>

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
.styled-button-5 {
	background-color:#bf322d;
	color:#fff;
	font-family:'Helvetica Neue',sans-serif;
	font-size:18px;
	line-height:30px;
	border-radius:20px;
	-webkit-border-radius:20px;
	-moz-border-radius:20px;
	border:0;
	text-shadow:#C17C3A 0 -1px 0;
	width:120px;
	height:32px
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

      
          .style5
          {
              color: #0066FF;
          }

      
          .style6
          {
              color: #FF0000;
          }
          .style7
          {
              color: #FF0066;
          }

      
          .style8
          {
              color: #006699;
          }

      
          </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <br />
<br />
<br />
<asp:Panel ID="panel1" runat="server" Visible="false">
        <center>
        <%--<h3 class="style6">Nous sommes désolés,Vous n&#39;avez pas le droit de passer ni les 
            formations ni les tests!</h3>--%>
<br />
<asp:HyperLink ID="HyperLink1" NavigateUrl="~/Etudiants/Accueil.aspx"  runat="server" ForeColor="#0033CC" > Retour à la page d'Accueil</asp:HyperLink>

</center>
<br />
        </asp:Panel>
<br />
<br />
<asp:Panel ID="pllo" runat="server" BackColor="#E0E0E0">
<br />
<br />
<center>
<br />
<h3><span class="style5">Inscription au test Anglais pour l&#39;année universitaire 
    2015/2016</h3>

<br />
    </span><span class="style6">Remarques:
    <br />
    </span>
    <br />
    <span class="style7">(*) La plateforme sera fermé le Mercredi 22/02/2016.
    <br />
    (*) Le nombre maximale le d&#39;inscrit ne dépasse pas <strong>50 </strong>
    étudiants.
</span>
<br />
<br />
<table>
<tr><td><asp:Label runat="server" ID="lblnb" Visible="false"/></td></tr>
<tr><td><br /></td><td><br /></td></tr>
<tr><td class="style8">- Veuillez choisir la date de l&#39;examen puis valider:</td>
<tr><td><br /></td><td><br /></td></tr>
    <tr>
        <td>
            <asp:DropDownList ID="ddlchoix" runat="server" AppendDataBoundItems="true" 
                AutoPostBack="true" DataTextField="DATETEST" DataTextFormatString="{0:d}" 
                DataValueField="DATETEST" 
                onselectedindexchanged="ddltestfr_SelectedIndexChanged">
                <asp:ListItem Text="Choisir la date du test anglais" Value="0"> </asp:ListItem>
                <asp:ListItem Text="20/04/2016" Value="20/04/2016"> </asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            <br />
        </td>
        <td>
            <br />
        </td>
    </tr>
</tr>

</table>

<br />
<br />
<%--<asp:ImageButton runat="server" ID="Imgvalid" Width="120px" 
    ImageUrl="~/images/button_valider.gif" onclick="Imgvalid_Click"/>--%>

    <asp:Button  ID="Imgvalid" runat="server" class="styled-button-5"  
        Text="Enregistrer" onclick="Imgvalid_Click1"/>
</center>
<br />
<br />
<br />
<br />
</asp:Panel>
</asp:Content>


