<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Consulter_TEST_ANG.aspx.cs"
 Inherits="ESPOnline.Enseignants.Consulter_TEST_ANG" MasterPageFile="~/Enseignants/Ens.Master" %>
 <%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


<style type="text/css"> 
.styled-button-10 {
	background:#5CCD00;
	background:-moz-linear-gradient(top,#5CCD00 0%,#4AA400 100%);
	background:-webkit-gradient(linear,left top,left bottom,color-stop(0%,#5CCD00),color-stop(100%,#4AA400));
	background:-webkit-linear-gradient(top,#5CCD00 0%,#4AA400 100%);
	background:-o-linear-gradient(top,#5CCD00 0%,#4AA400 100%);
	background:-ms-linear-gradient(top,#5CCD00 0%,#4AA400 100%);
	background:linear-gradient(top,#5CCD00 0%,#4AA400 100%);
	filter: progid: DXImageTransform.Microsoft.gradient( startColorstr='#5CCD00', endColorstr='#4AA400',GradientType=0);
	padding:10px 15px;
	color:#fff;
	font-family:'Helvetica Neue',sans-serif;
	font-size:16px;
	border-radius:5px;
	-moz-border-radius:5px;
	-webkit-border-radius:5px;
	border:1px solid #459A00
}
</style>


    <link href="../Contents/Css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />
    <script src="../Contents/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="../Contents/Scripts/bootstrap.js" type="text/javascript"></script>
        <script type="text/javascript" src="../Contents/Scripts/JScript1.js"></script>


        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
        <script type="text/javascript">
            $("[src*=plus]").live("click", function () {
                $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
                $(this).attr("src", "../EnseignantsCUP/Styles/minus.png");
            });
            $("[src*=minus]").live("click", function () {
                $(this).attr("src", "../EnseignantsCUP/Styles/plus.png");
                $(this).closest("tr").next().remove();
            });
        </script>
              
         <style type="text/css">
      
      table.grid tbody tr:hover {background-color:#e5ecf9;}
.GridHeaderStyle{color:#FEF7F7;background-color: #877d7d;font-weight: bold;}
.GridItemStyle{background-color:#eeeeee;color: Black;}
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
 #hurfDurf table
 .Gridstudent
    {
      
        margin-right:80px;
    }
      
          </style>

         <%-- style row color chnged--%>
         <style type="text/css">
  .successMerit {
    background-color: #1fa756;
    border: medium none;
    color: White;
  }
    .defaultColor
    {
        background-color: white;
        color: black;
    }
  .dangerFailed {
    background-color: #f2283a;
    color: White;
  }
             </style>

 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<center>
<br />
<br />
<h3 class="style3">Liste des étudiants</h3>
 

<table>

<tr>
<td valign="middle" >
<asp:GridView runat="server" ID="Gridtoiec" AutoGenerateColumns="False" 
                                                          AllowPaging="True"   PageSize="50"
                                                         Style="border-bottom: white 2px ridge; border-left: white 2px ridge;
                                                        background-color: white; width: 100%; border-top: white 2px ridge; border-right: white 2px ridge;"
                                                        BorderWidth="0px" BorderColor="Red" CellSpacing="1" CellPadding="3" CssClass="grid"
                                                        RowStyle-CssClass="ItemStyle" HeaderStyle-CssClass="FixedHeaderStyle" Width="100%"
                                                        GridLines="Both" EmptyDataRowStyle-CssClass="ItemStyle"  DataKeyNames="id_ET" BackColor="#0099CC"
                                                     OnPageIndexChanging="gridViewtoiec_PageIndexChanging"

                                                       >
                                                        <EmptyDataTemplate>
                                                            Pas d'enregistrement.
                                                        </EmptyDataTemplate>
                                                        
                                                        <HeaderStyle HorizontalAlign="Center" Height="20px" Width="100px" BackColor="Red" />
                                                        <RowStyle HorizontalAlign="Center" CssClass="ItemStyle"></RowStyle>
                                                        <FooterStyle CssClass="ItemStyle" />
                                                        <EmptyDataRowStyle CssClass="ItemStyle"></EmptyDataRowStyle>
                                                        <RowStyle CssClass="GridItemStyle" />
                                                        <AlternatingRowStyle CssClass="GridAlternatingStyle" />
                                                        <HeaderStyle CssClass="GridHeaderStyle" />
                                                        <SelectedRowStyle CssClass="GridSelectedStyle" />
                                                        <Columns>
         <asp:BoundField DataField="id_et" HeaderText="Identifiant" ReadOnly="True" 
                SortExpression="id_et" /> 
                     
              <asp:BoundField DataField="nom_et" HeaderText="Nom" ReadOnly="True" 
                SortExpression="nom_et" />   
                 <asp:BoundField DataField="pnom_et" HeaderText="Prenom" ReadOnly="True" 
                SortExpression="pnom_et" />    
                  
                 <asp:BoundField DataField="NIVEAU_COURANT_FR" HeaderText="Niveau Français" ReadOnly="True" 
                SortExpression="NIVEAU_COURANT_FR" />   
                 
                 <asp:BoundField DataField="NIVEAU_COURANT_ang" HeaderText="Niveau Anglais" ReadOnly="True" 
                SortExpression="NIVEAU_COURANT_ang" /> 
                
                 <asp:BoundField DataField="code_cl" HeaderText="Classe" ReadOnly="True" 
                SortExpression="code_cl" /> 
                 <asp:BoundField DataField="annee_deb" HeaderText=" Promotion" ReadOnly="True" 
                SortExpression="annee_deb" /> 
                 <asp:BoundField DataField="date_choix" HeaderText=" Date examen" ReadOnly="True" 
                SortExpression="date_choix" DataFormatString="{0:d}" />        

                     </Columns>
                                                        <HeaderStyle CssClass="GridHeaderStyle" />
                                                        <RowStyle ForeColor="#000000"  />
                                                        <SelectedRowStyle CssClass="GridSelectedStyle" />
                                                        
                                                    </asp:GridView>
                                                    <br />
                                                    <center>
 <asp:Button  ID="Btntoiec" runat="server" 
         Text="Exporter en excel" 
Height="50px"  onclick="Btntoiec_Click" class="styled-button-10"  />
 </center>
 


                                             
                                             
                                              <td width="200px"> </td>
                                             

 
                                             
</tr>

</table>

<br />


</center>
</asp:Content>
