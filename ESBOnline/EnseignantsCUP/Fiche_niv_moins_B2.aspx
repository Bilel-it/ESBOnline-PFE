<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fiche_niv_moins_B2.aspx.cs" Inherits="ESPOnline.EnseignantsCUP.Fiche_niv_moins_B2" 
MasterPageFile="~/EnseignantsCUP/Cup.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

        <link href="../Contents/Css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
        <link href="../Contents/Css/bootstrap.min.css" rel="stylesheet" type="text/css" />
        <script src="../Contents/jquery.js" type="text/javascript"></script>
               <script src="../Contents/CSS3/js/bootstrap.min.js" type="text/javascript"></script>
        <link href="../Contents/Css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
        <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />
         <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
  <%--  <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>--%>
<script src="../Contents/Scripts/ScrollableGridPlugin_ASP.NetAJAX_2.0.js" type="text/javascript"></script>
     <script type="text/javascript">
    $(document).ready(function () {
        $('#<%=GridView1.ClientID %>').Scrollable({
            ScrollHeight: 300,
         
        });
    });
    </script>
    
    <style type="text/css">
      
      table.grid tbody tr:hover {background-color:#e5ecf9;}
.GridHeaderStyle{color:#FEF7F7;background-color: #877d7d;font-weight: normal;}
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
	FONT-WEIGHT: normal;
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
.grid td, .grid th{
  text-align:center;
      
          }
        .style1
        {
            color: #CC0000;
        }
      
          </style>

           

        </asp:Content>

        <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <br />
        <br />
        <br />
        <center><h3 class="style1">Fiche niveau de langue (Français et Anglais) inférieure à B2 </h3>
        <br />
        <table>
        <tr>
<td>
<asp:Label ID="lbiannee" runat="server">choisir l'année:&nbsp</asp:Label>
<asp:DropDownList ID="ddlannee_deb" runat="server" AppendDataBoundItems="true"  Width="150px"
   Height="30px"   AutoPostBack="true" 
        onselectedindexchanged="ddlannee_deb_SelectedIndexChanged" >
<asp:ListItem Value="0">Veuillez choisir</asp:ListItem>
<asp:ListItem >2014</asp:ListItem>
<asp:ListItem >2015</asp:ListItem>
</asp:DropDownList>
</td>
<td>
Niveau d'étude:
<asp:DropDownList ID="ddlniv" runat="server" AppendDataBoundItems="true"  Width="150px"
   Height="30px"   AutoPostBack="true" onselectedindexchanged="ddlniv_SelectedIndexChanged" 
         >
<asp:ListItem Value="0">Veuillez choisir</asp:ListItem>

</asp:DropDownList>
</td>
<td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
<td>
    liste des clases:
<asp:DropDownList ID="ddclasse" runat="server"  Width="150px"
   Height="30px"
    AutoPostBack="true" onselectedindexchanged="ddclasse_SelectedIndexChanged"  >

</asp:DropDownList>

</td>
</tr>
        </table>
        <br />
        <asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="False" 
                                                          
                                                         Style="border-bottom: white 2px ridge; border-left: white 2px ridge;
                                                        background-color: white; border-top: white 2px ridge; border-right: white 2px ridge;"
                                                        BorderWidth="0px" BorderColor="Red" CellSpacing="1" CellPadding="3" CssClass="grid"
                                                        RowStyle-CssClass="ItemStyle" HeaderStyle-CssClass="FixedHeaderStyle" 
                                                        GridLines="Both" EmptyDataRowStyle-CssClass="ItemStyle"  BackColor="#0099CC"
                                                     DataKeyNames="ID_ET"
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


                  <asp:BoundField DataField="ID_ET" HeaderText="Identifiant" ReadOnly="True" 
                SortExpression="ID_ET"  ItemStyle-HorizontalAlign="Center"  HeaderStyle-Width="150px" /> 

                  <asp:BoundField DataField="NOM" HeaderText="Nom et Prenom" ReadOnly="True" 
                SortExpression="NOM"  ItemStyle-HorizontalAlign="Center"  HeaderStyle-Width="150px"/> 
               
              <asp:BoundField DataField="code_cl" HeaderText="Classe" ReadOnly="True" 
                SortExpression="code_cl" /> 

              <asp:BoundField DataField="niveau_courant_fr" HeaderText="Niveau Français " ReadOnly="True" 
                SortExpression="niveau_courant_fr"  ItemStyle-HorizontalAlign="Center"  HeaderStyle-Width="150px"/> 

                  <asp:BoundField DataField="niveau_courant_ang" HeaderText="Niveau Anglais " ReadOnly="True" 
                SortExpression="niveau_courant_ang"  ItemStyle-HorizontalAlign="Center"  HeaderStyle-Width="150px" /> 
                     </Columns>

                                                        <HeaderStyle CssClass="GridHeaderStyle" />
                                                        <RowStyle ForeColor="#000000"  />
                                                        <SelectedRowStyle CssClass="GridSelectedStyle" />
                                                        
                                                    </asp:GridView>
        
        </center>
        </asp:Content>
