<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Memedates.aspx.cs" Inherits="ESPOnline.EnseignantsCUP.Memedates"

MasterPageFile="~/EnseignantsCUP/CUP.Master" EnableEventValidation = "false" %>

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
  
  <div id="grdfr" runat="server">
  <br />
  <br />
<center><h1 class="style3">Liste des condidats qui vont passer le test du niveau ANGLAIS ET FRANCAIS à la même date: <asp:Label ID="Label1" runat="server" CssClass="style7"></asp:Label>/<asp:Label 
            ID="Label2" runat="server" CssClass="style7"></asp:Label></h1></center>
 <table >
        
     <td class="navigator_green_day"> <h1 class="navigator_green_day">Veuillez choisir la date :</h1></td>   
         <td>
         <asp:DropDownList runat="server" ID="ddltestang" 
         
          AutoPostBack="true"  AppendDataBoundItems="True"  
                    dataTextFormatString="{0:d}" 
                 onselectedindexchanged="ddltestang_SelectedIndexChanged">
          <asp:ListItem Value="">--Veuillez choisir la date-- </asp:ListItem>
                    </asp:DropDownList></td>
        </table>
<table>
<tr>
<td valign="top" >
<div id="gfr"  runat="server">
<asp:GridView runat="server" ID="GridALL" AutoGenerateColumns="False" 
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
                                                        
                                                        <HeaderStyle HorizontalAlign="Center" Height="20px" Width="100px" />
                                                        <RowStyle HorizontalAlign="Center" CssClass="ItemStyle"></RowStyle>
                                                        <FooterStyle CssClass="ItemStyle" />
                                                        <EmptyDataRowStyle CssClass="ItemStyle"></EmptyDataRowStyle>
                                                        <RowStyle ForeColor="#000000"  />
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
                     
                  

                    <asp:BoundField DataField="DATE_TEST_ANG" HeaderText="Date du test FR" ReadOnly="True"  DataFormatString="{0:d}"
                SortExpression="DATE_TEST_ANG" />  
                <asp:BoundField DataField="DATE_TEST_FR" HeaderText="Date du test ANG" ReadOnly="True"  DataFormatString="{0:d}"
                SortExpression="DATE_TEST_FR" />  


                     </Columns>
                                                        <HeaderStyle CssClass="GridHeaderStyle" />
                                                        <RowStyle CssClass="GridItemStyle" />
                                                        <SelectedRowStyle CssClass="GridSelectedStyle" />
                                                    </asp:GridView>
</div>
                                              </td>
</tr>
</table>
<asp:Button  ID="Button1" runat="server" 
         Text="Export to Excel" 
Height="50px" ForeColor="White" BackColor="Red" onclick="Button1_Click1" />
</div>
  
  </center>  



<br />
<br />
<center>
<h3 class="style2">Cliquez sur le bouton bour afficher le nombre des condidats qui vont passer le test TOIEC ET PREPTOIEC</h3>
<asp:Button  ID="btnres" runat="server" 
        Text="Afficher nbr condidats qui vont passer les tests toiec et preptoiec" onclick="btnres_Click"
Height="50px" ForeColor="White" BackColor="Red"/>
</center>
<br />
<br />
<center>
<table>
<tr><td><asp:Label ID="lblcountfr" runat="server" 
        Text="Le nombre des condidats qui vont passer le test de TOIEC est:" 
        CssClass="style1"></asp:Label></td><td>
        <asp:Label  ID="lblnbtoiec"  

            runat="server" CssClass="style1" BackColor="#009933" Height="50px" 
            Width="50px" ></asp:Label></td></tr>
<tr><td></td><td></td></tr>
<tr><td><asp:Label ID="lblcountang" runat="server" 
        Text="Le nombre des condidats qui vont passer le test de PREP TOIEC est:" 
        CssClass="style1"></asp:Label>
</td><td>
        <asp:Label  ID="Lblpreptoiec"  runat="server" CssClass="style1" 
            BackColor="Red" Height="50px" Width="50px" ></asp:Label></td></tr>
    
</table>
</center>
</asp:Content>


    
