<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Etat_niveau_langue_2017.aspx.cs"
 Inherits="ESPOnline.Direction.Etat_niveau_langue_2017" 
MasterPageFile="~/Direction/Site2.Master" %>

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

      
          .grid td, .grid th{
     text-align:center;
      
          }
        .style2
        {
            color: #000099;
        }
        .style3
        {
            color: #CC0000;
        }
      
          </style>

           <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
  <%--  <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>--%>
<script src="../Contents/Scripts/ScrollableGridPlugin_ASP.NetAJAX_2.0.js" type="text/javascript"></script>
     <script type="text/javascript">
    $(document).ready(function () {
        $('#<%=Gridtoiec.ClientID %>').Scrollable({
            ScrollHeight: 300,
         
        });
    });
    </script>

    <script type="text/javascript">
    $(document).ready(function () {
        $('#<%=GridView1.ClientID %>').Scrollable({
            ScrollHeight: 300,
         
        });
    });
    </script>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<br />
    <center>
    <h3>Etat niveaux de langue </h3>
<table>
<tr>
<td>
<asp:RadioButtonList ID="rblangue" runat="server"  AutoPostBack="true"
            Width="220px" RepeatDirection="Horizontal" 
        onselectedindexchanged="rblangue_SelectedIndexChanged" >
                 <asp:ListItem Value="FR">Français</asp:ListItem>

                 <asp:ListItem Value="AN">Anglais </asp:ListItem>
            </asp:RadioButtonList>
</td>
</tr>
</table>
<asp:Panel ID="lblfr" runat="server">
<h3 class="style2">
            Etat niveau Français
        </h3>
<table>
   <%-- <caption>--%>
        
        <tr>
            <td>
                <asp:GridView ID="Gridtoiec" runat="server" AutoGenerateColumns="False" 
                    BackColor="#0099CC" BorderColor="Red" BorderWidth="0px" CellPadding="3" 
                    CellSpacing="1" CssClass="grid" EmptyDataRowStyle-CssClass="ItemStyle" 
                    GridLines="Both" HeaderStyle-CssClass="FixedHeaderStyle" 
                    RowStyle-CssClass="ItemStyle" 
                    ShowFooter="true" 
                    Style="border-bottom: white 2px ridge; border-left: white 2px ridge;
                 background-color: white; border-top: white 2px ridge; border-right: white 2px ridge;"
                 
                 OnRowDataBound="GridView1_RowDataBound">
                    <EmptyDataTemplate>
                        Pas d&#39;enregistrement.
                    </EmptyDataTemplate>
                    <HeaderStyle BackColor="Red" Height="20px" HorizontalAlign="Center" 
                        Width="100px" />
                    <RowStyle CssClass="ItemStyle" HorizontalAlign="Center" />
                    <FooterStyle CssClass="ItemStyle" />
                    <EmptyDataRowStyle CssClass="ItemStyle" />
                    <RowStyle CssClass="GridItemStyle" />
                    <AlternatingRowStyle CssClass="GridAlternatingStyle" />
                    <HeaderStyle CssClass="GridHeaderStyle" />
                    <SelectedRowStyle CssClass="GridSelectedStyle" />
                    <Columns>
                        <%-- <asp:BoundField DataField="Site" HeaderText="Site" ReadOnly="True" 
                SortExpression="Site" /> --%>
                        <asp:BoundField DataField="Niveau" HeaderText="Niveau" ReadOnly="True" 
                            SortExpression="Niveau" />
                        <asp:TemplateField HeaderText="Niveau A1">
                            <ItemTemplate>
                                <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Niveau_A1")%>' />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblTotalPrice" runat="server" />
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Niveau A2">
                            <ItemTemplate>
                                <asp:Label ID="lblUnitsInStock" runat="server" 
                                    Text='<%# Eval("Niveau_A2") %>' />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblTotalUnitsInStock" runat="server" />
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Niveau B1">
                            <ItemTemplate>
                                <asp:Label ID="lblUnitsInStockGC" runat="server" 
                                    Text='<%# Eval("Niveau_B1") %>' />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblTotalUnitsInStockGC" runat="server" />
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Niveau B2">
                            <ItemTemplate>
                                <asp:Label ID="lblUnitsInStockGCTotal" runat="server" 
                                    Text='<%# Eval("Niveau_B2") %>' />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblTotalUnitsInStockGCTotal" runat="server" />
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total">
                            <ItemTemplate>
                                <asp:Label ID="lblUnitsInStockGCTredoub" runat="server" 
                                    Text='<%# Eval("TOTAL") %>' />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblTotalUnitsInStockredoub" runat="server" />
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="Red" Font-Bold="True" ForeColor="White" 
                        HorizontalAlign="Center" />
                    <HeaderStyle BackColor="Red" Font-Bold="True" ForeColor="White" 
                        HorizontalAlign="Left" />
                    <HeaderStyle CssClass="GridHeaderStyle" />
                    <RowStyle ForeColor="#000000" />
                    <SelectedRowStyle CssClass="GridSelectedStyle" />
                </asp:GridView>
            </td>
        </tr>
   <%-- </caption>--%>
</table>
</asp:Panel>
<br />
<asp:Panel ID="plbtn" runat="server">

<table>
                                           
                                           <tr>
                                           <td>
                                             
                                                    <asp:Button  ID="Button2" runat="server" 
         Text="Imprimer" 
Height="50px" ForeColor="Black" BackColor="#CCCCCC"  CssClass="text-info" onclick="Button2_Click" />
                                           </td>
                                           <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; </td>
                                          <td>
                                          <asp:Button  ID="Button3" runat="server" Text="Exporter en excel" 
Height="50px" ForeColor="Black" BackColor="#CCCCCC"  CssClass="text-info" onclick="Button3_Click"  />
                                          </td>  
                                            
                                            </tr>
                                            </table>        
                                                 
</asp:Panel>
<br />
<asp:Panel ID="lblang" runat="server">
 <h3 class="style3">
            Etat niveau d&#39;Anglais
        </h3>
<table>
    <%--<caption>--%>
       
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    BackColor="#0099CC" BorderColor="Red" BorderWidth="0px" CellPadding="3" 
                    CellSpacing="1" CssClass="grid" EmptyDataRowStyle-CssClass="ItemStyle" 
                    GridLines="Both" HeaderStyle-CssClass="FixedHeaderStyle" 
                     RowStyle-CssClass="ItemStyle" 
                    ShowFooter="true" 
                    Style="border-bottom: white 2px ridge; border-left: white 2px ridge;
                                                        background-color: white; border-top: white 2px ridge; border-right: white 2px ridge;"
                                                         OnRowDataBound="GridView2_RowDataBound">
                    <EmptyDataTemplate>
                        Pas d&#39;enregistrement.
                    </EmptyDataTemplate>
                    <HeaderStyle BackColor="Red" Height="20px" HorizontalAlign="Center" 
                        Width="100px" />
                    <RowStyle CssClass="ItemStyle" HorizontalAlign="Center" />
                    <FooterStyle CssClass="ItemStyle" />
                    <EmptyDataRowStyle CssClass="ItemStyle" />
                    <RowStyle CssClass="GridItemStyle" />
                    <AlternatingRowStyle CssClass="GridAlternatingStyle" />
                    <HeaderStyle CssClass="GridHeaderStyle" />
                    <SelectedRowStyle CssClass="GridSelectedStyle" />
                    <Columns>
                        <%-- <asp:BoundField DataField="Site" HeaderText="Site" ReadOnly="True" 
                SortExpression="Site" /> --%>
                        <asp:BoundField DataField="Niveau" HeaderText="Niveau" ReadOnly="True" 
                            SortExpression="Niveau" />
                        <asp:TemplateField HeaderText="Niveau A1">
                            <ItemTemplate>
                                <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Niveau_A1")%>' />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblTotalPrice" runat="server" />
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Niveau A2">
                            <ItemTemplate>
                                <asp:Label ID="lblUnitsInStock" runat="server" 
                                    Text='<%# Eval("Niveau_A2") %>' />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblTotalUnitsInStock" runat="server" />
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Niveau B1">
                            <ItemTemplate>
                                <asp:Label ID="lblUnitsInStockGC" runat="server" 
                                    Text='<%# Eval("Niveau_B1") %>' />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblTotalUnitsInStockGC" runat="server" />
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Niveau B2">
                            <ItemTemplate>
                                <asp:Label ID="lblUnitsInStockGCTotal" runat="server" 
                                    Text='<%# Eval("Niveau_B2") %>' />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblTotalUnitsInStockGCTotal" runat="server" />
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total">
                            <ItemTemplate>
                                <asp:Label ID="lblUnitsInStockGCTredoub" runat="server" 
                                    Text='<%# Eval("TOTAL") %>' />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblTotalUnitsInStockredoub" runat="server" />
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="Red" Font-Bold="True" ForeColor="White" 
                        HorizontalAlign="Center" />
                    <HeaderStyle BackColor="Red" Font-Bold="True" ForeColor="White" 
                        HorizontalAlign="Left" />
                    <HeaderStyle CssClass="GridHeaderStyle" />
                    <RowStyle ForeColor="#000000" />
                    <SelectedRowStyle CssClass="GridSelectedStyle" />
                </asp:GridView>
            </td>
        </tr>
    <%--</caption>--%>
</table>

</asp:Panel>
<br />
<asp:Panel ID="plbtn1" runat="server">

<table>
                                           
                                           <tr>
                                           <td>
                                             
                                                    <asp:Button  ID="Btnprint" runat="server" 
         Text="Imprimer" 
Height="50px" ForeColor="Black" BackColor="#CCCCCC"  CssClass="text-info" onclick="Btnprint_Click" />
                                           </td>
                                           <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; </td>
                                          <td>
                                          <asp:Button  ID="Button1" runat="server" Text="Exporter en excel" 
Height="50px" ForeColor="Black" BackColor="#CCCCCC"  CssClass="text-info" onclick="BuTT2_Click" />
                                          </td>  
                                            
                                            </tr>
                                            </table>        
                                                 
</asp:Panel>
</center>

</asp:Content>