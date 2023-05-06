<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rep_nouv_inscrits.aspx.cs" Inherits="ESPOnline.Direction.rep_nouv_inscrits"
MasterPageFile="~/Direction/Site2.Master"  EnableEventValidation = "false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Contents/Scripts/bootstrap-datetimepicker.js" type="text/javascript"></script>
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
         .footer td
        {
            border: none;
        }
   .table     td {
border-bottom: 1pt solid black;
}     
  .footer      tr {
border-bottom: 1pt solid black;
}
        .footer th
        {
            border: none;
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

      
          </style>

          <script language="javascript" type="text/javascript">

              function CalculSom() 
              {
                  var t = document.getElementById("ContentPlaceHolder1_Gridtoiec");
                  var r = t.insertRow(t.rows.length);

                  for (var j = 0; j < 5; j++)
                   {
                      r.insertCell(j);
                      var s = 0;
                      for (var i = 0; i < t.rows.length-1; i++) 
                      {
                          s += parseInt(t.rows[i].cells[j].valueOf);
                      }
                      r.cells[j].valueOf = s;
                  }
              }
         </script>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
<br />
<center>

<table>
<tr>
<td><asp:Label ID="lbl2" runat="server" BackColor="RoyalBlue" ></asp:Label></td>
</tr>
<tr>

<td>

<h3>Répartition des nouveaux inscrits</h3>

<br />
<asp:GridView runat="server" ID="Gridtoiec" AutoGenerateColumns="False" 
                                                          
                                                         Style="border-bottom: black 2px ridge; border-left: black 2px ridge;
                                                        background-color: white; border-top: black 2px ridge; border-right: black 2px ridge;"
                                                        BorderWidth="0px" BorderColor="Red"  CssClass="grid" 
                                                        RowStyle-CssClass="ItemStyle" HeaderStyle-CssClass="FixedHeaderStyle" 
                                                        GridLines="Both" EmptyDataRowStyle-CssClass="ItemStyle"  BackColor="#0099CC"
                                                     OnPageIndexChanging="gridViewtoiec_PageIndexChanging"
                                                     onrowdatabound="GridView1_RowDataBound" ShowFooter="true"                                                       >
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
          <asp:BoundField DataField="Niveau" HeaderText="Niveau" ReadOnly="True" 
                SortExpression="Niveau" /> 

                 <%-- <asp:BoundField DataField="TIC" HeaderText="TIC" ReadOnly="True" 
                SortExpression="TIC" /> --%>
                <asp:TemplateField HeaderText="TIC">
        <ItemTemplate>
            <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("TIC")%>' />
         </ItemTemplate>
         <FooterTemplate>
            <asp:Label ID="lblTotalPrice" runat="server" />
         </FooterTemplate>                   
      </asp:TemplateField>

                  <%--<asp:BoundField DataField="EM" HeaderText="EM" ReadOnly="True" 
                SortExpression="EM" /> --%>
                <asp:TemplateField HeaderText="EM">
         <ItemTemplate>
            <asp:Label ID="lblUnitsInStock" runat="server" Text='<%# Eval("EM") %>' />
         </ItemTemplate>                   
         <FooterTemplate>
            <asp:Label ID="lblTotalUnitsInStock" runat="server" />
         </FooterTemplate>
      </asp:TemplateField>


                 <%--<asp:BoundField DataField="GC" HeaderText="GC" ReadOnly="True" 
                SortExpression="GC" /> --%>

<asp:TemplateField HeaderText="GC">
         <ItemTemplate>
            <asp:Label ID="lblUnitsInStockGC" runat="server" Text='<%# Eval("GC") %>' />
         </ItemTemplate>                   
         <FooterTemplate>
            <asp:Label ID="lblTotalUnitsInStockGC" runat="server" />
         </FooterTemplate>
      </asp:TemplateField>

                 <%-- <asp:BoundField DataField="Total" HeaderText="Total" ReadOnly="True" 
                SortExpression="Total" /> --%>
                <asp:TemplateField HeaderText="Total">
         <ItemTemplate>
            <asp:Label ID="lblUnitsInStockGCTotal" runat="server" Text='<%# Eval("Total") %>' />
         </ItemTemplate>                   
         <FooterTemplate>
            <asp:Label ID="lblTotalUnitsInStockGCTotal" runat="server" />
         </FooterTemplate>
      </asp:TemplateField>



                     </Columns>
                      <FooterStyle BackColor="Red" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
   <HeaderStyle BackColor="Red" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />

                                                        <HeaderStyle CssClass="GridHeaderStyle" />
                                                        <RowStyle ForeColor="#000000"  />
                                                        <SelectedRowStyle CssClass="GridSelectedStyle" />
                                                        
                                                    </asp:GridView>
                                                    <br />
                                                     <center>
                                           <table>
                                           
                                           <tr>
                                           <td>
                                             
                                                    <asp:Button  ID="Btnprint" runat="server" 
         Text="Imprimer" 
Height="50px" ForeColor="Black" BackColor="#CCCCCC"  CssClass="text-info" onclick="Btnprint_Click" />
                                           </td>
                                           <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; </td>
                                          <td>
                                          <asp:Button  ID="Button1" runat="server" 
         Text="Exporter en excel" 
Height="50px" ForeColor="Black" BackColor="#CCCCCC"  CssClass="text-info" onclick="BuTT2_Click" />
                                          </td>  
                                           <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; </td>
                                          <td>
                                          
                                            
                                            </tr>
                                            </table>        
                                                    
                                                    </center>
</td>

<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    &nbsp;</td>



</tr>

</table>

</center>


                                                   
</asp:Content>
