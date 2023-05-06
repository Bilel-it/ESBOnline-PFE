<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List_Formation_langues.aspx.cs" Inherits="ESPOnline.EnseignantsCUP.List_Formation_langues"

 MasterPageFile="~/EnseignantsCUP/cup.Master" EnableEventValidation = "false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Contents/jquery.js" type="text/javascript"></script>
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

      
          </style>

<style type="text/css">
    
    .container { 
 width:100%; }

.align-left { 
 float: left;
 width:50%; 
 height:20%;
 } 

 .align-right{
 float: right; 
 height:20%;
 width:50%
 }
    
    </style>

    <style type="text/css">
    
    .verticalLine {
    border-left: thick solid #ff0000;
}
    
        .style1
        {
            font-weight: bold;
            font-family: "Courier New", Courier, monospace;
        }
    
        .style2
        {
            font-size: medium;
        }
        .style3
        {
            font-weight: bold;
            font-family: "Courier New", Courier, monospace;
            font-size: medium;
        }
    
    </style>

    
    <link href="../Contents/Css/datetimepicker.css" rel="stylesheet" type="text/css" />

    <link href="../Contents/animate.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <script src="../Contents/bootstrap.js" type="text/javascript"></script>
    <script src="../Contents/bootstrap.min.js" type="text/javascript"></script>

    
    <script src="../Contents/Scripts/bootstrap-datetimepicker.min.js" type="text/javascript"></script>
    <script src="../Contents/Scripts/bootstrap-datetimepicker.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
<br />
<br />
<center><h1 class="style3">Liste des etudiants inscrits au formation français 
    et anglais
     pour l'année: <asp:Label ID="lblanneedeb" runat="server" CssClass="style7"></asp:Label>/<asp:Label 
            ID="lblanneefin" runat="server" CssClass="style7"></asp:Label></h1></center>
 

<table>

<tr>
<td valign="top" >
<h3> Liste des etudiants inscrits au formation français</h3>
<asp:GridView runat="server" ID="Gridtoiec" AutoGenerateColumns="False" 
                                                          AllowPaging="True"   PageSize="50"
                                                         Style="border-bottom: white 2px ridge; border-left: white 2px ridge;
                                                        background-color: white; width: 100%; border-top: white 2px ridge; border-right: white 2px ridge;"
                                                        BorderWidth="0px" BorderColor="Red" CellSpacing="1" CellPadding="3" CssClass="grid"
                                                        RowStyle-CssClass="ItemStyle" HeaderStyle-CssClass="FixedHeaderStyle" Width="100%"
                                                        GridLines="Both" EmptyDataRowStyle-CssClass="ItemStyle"  DataKeyNames="id_et" BackColor="#0099CC"
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
                     
              <asp:BoundField DataField="NOM_ET" HeaderText="NOM" ReadOnly="True" 
                SortExpression="NOM_ET" />     
                  <asp:BoundField DataField="PNOM_ET" HeaderText="Prenom" ReadOnly="True" 
                SortExpression="PNOM_ET" />    
                
                  <asp:BoundField DataField="CODE_CL" HeaderText="Classe" ReadOnly="True" 
                SortExpression="CODE_CL" />         


                     </Columns>
                                                        <HeaderStyle CssClass="GridHeaderStyle" />
                                                        <RowStyle ForeColor="#000000"  />
                                                        <SelectedRowStyle CssClass="GridSelectedStyle" />
                                                        
                                                    </asp:GridView>
                                                    <br />
                                                    <center>
 <asp:Button  ID="Btntoiec" runat="server" 
         Text="Exporter en excel" 
Height="50px" ForeColor="Black" BackColor="#CCCCCC" onclick="Btntoiec_Click" CssClass="text-info" />
 </center>
 


                                             
                                             
                                              <td width="200px"> </td>
                                             

<td valign="top" >
<h3>Liste des etudiants inscrits au formation Anglais</h3>
<asp:GridView runat="server" ID="Gridprep" AutoGenerateColumns="False" 
                                                          AllowPaging="True"   PageSize="50"
                                                         Style="border-bottom: white 2px ridge; border-left: white 2px ridge;
                                                        background-color: white; width: 100%; border-top: white 2px ridge; border-right: white 2px ridge;"
                                                        BorderWidth="0px" BorderColor="Red" CellSpacing="1" CellPadding="3" CssClass="grid"
                                                        RowStyle-CssClass="ItemStyle" HeaderStyle-CssClass="FixedHeaderStyle" Width="100%"
                                                        GridLines="Both" EmptyDataRowStyle-CssClass="ItemStyle"  DataKeyNames="id_et" BackColor="#0099CC"
                                                      OnPageIndexChanging="gridView_PageIndexChanging"

                                                       >
                                                        <EmptyDataTemplate>
                                                            Pas d'enregistrement.
                                                        </EmptyDataTemplate>
                                                        
                                                        <HeaderStyle HorizontalAlign="Center" Height="20px" Width="100px" BackColor="Red"/>
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
                     
              <asp:BoundField DataField="NOM_ET" HeaderText="NOM" ReadOnly="True" 
                SortExpression="NOM_ET" />     
                  <asp:BoundField DataField="PNOM_ET" HeaderText="Prenom" ReadOnly="True" 
                SortExpression="PNOM_ET" />    
                
                  <asp:BoundField DataField="CODE_CL" HeaderText="Classe" ReadOnly="True" 
                SortExpression="CODE_CL" />         


                     </Columns>
                                                        <HeaderStyle CssClass="GridHeaderStyle" />
                                                        <RowStyle ForeColor="#000000"  />
                                                        <SelectedRowStyle CssClass="GridSelectedStyle" />
                                                    </asp:GridView>
                                                    <br />
                                                    <center>
 <asp:Button  ID="Btnprep" runat="server" 
         Text="Exporter en excel" 
Height="50px" ForeColor="Black" BackColor="#CCCCCC" onclick="Btnprep_Click" CssClass="text-info" />
 </center>
</td> 

</tr>

</table>

<br />
<center>

<asp:HyperLink ID="HyperLink1" NavigateUrl="~/EnseignantsCUP/Liste_Formation_langue_Commun.aspx" Text="Liste des etudiants inscrits au formation français et anglais" runat="server" ForeColor="#0033CC" > </asp:HyperLink>
</center>

</center>
<br />
<br />
<br />
<br />
<center>
<h3 class="style2">Cliquez pour afficher le nombre des inscrits</h3>
<asp:Button  ID="btnres" runat="server" 
        Text="Afficher le nombre" onclick="btnres_Click"
Height="50px" ForeColor="Black" BackColor="#CCCCCC" CssClass="text-info"/>
</center>
<br />
<br />
<center>
<table>
<tr><td>Liste des etudiants inscrits au formation français:</td><td>
        <asp:Label  ID="lblnbtoiec"  

            runat="server" CssClass="style1" BackColor="#66CCFF" Height="50px" 
            Width="50px" ></asp:Label></td></tr>
<tr><td></td><td></td></tr>
<tr><td>Liste des etudiants inscrits au formation anglais:</td><td>
        <asp:Label  ID="Lblpreptoiec"  runat="server" CssClass="style1" 
            BackColor="Red" Height="50px" Width="50px" ></asp:Label></td></tr>
    
</table>

</center>
<br />
<br />
<center>

 
</center>
</asp:Content>


