<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Stat_par_site.aspx.cs" Inherits="ESPOnline.Direction.Stat_par_site"

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

      
          </style>


<%--script calcul total--%>

<script language="javascript" type="text/javascript" >

    function CalculateFloatTotal(ListId, DestinationId) {

        var ElementTable = new Array();
        //Récupération des objets
        for (var n in ListId) {
            ElementTable[n] = document.getElementById(ListId[n]);
        }
        var ValuesTables = new Array();
        //récupération des valeurs
        for (var n in ElementTable) {
            if (ElementTable[n].value != null)
                ValuesTables[n] = parseFloat(ElementTable[n].value);
            //test des valeurs
            if (isNaN(ValuesTables[n]) || ValuesTables[n] == 0)
                ValuesTables[n] = 0;
        }
        var total = 0;
        //Somme
        for (var n in ValuesTables) {
            total += ValuesTables[n];
        }
        //Affichage
        var elemntDestination = document.getElementById(DestinationId);
        elemntDestination.value = total.toFixed(2);
    }
 
 
</script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
<br />
<table>
<tr>
<td><asp:Label ID="lbl2" runat="server" BackColor="RoyalBlue" ></asp:Label></td>
</tr>
<tr>

<td>
<h3>Répartition des étudiants par site,type d'inscription,Nouveau et redoublant</h3>
<asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="False" Visible="false"
                                                         Style="border-bottom: white 2px ridge; border-left: white 2px ridge;
                                                        background-color: white;  border-top: white 2px ridge; border-right: white 2px ridge;"
                                                        BorderWidth="0px" BorderColor="Red" CellSpacing="1" CellPadding="3" CssClass="grid"
                                                        RowStyle-CssClass="ItemStyle" HeaderStyle-CssClass="FixedHeaderStyle"
                                                        GridLines="Both" EmptyDataRowStyle-CssClass="ItemStyle"  BackColor="#0099CC"
                                                

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
         <asp:TemplateField   HeaderText = "Nouveaux_Inscrits">
    <ItemTemplate>
        <asp:Label ID="lbl1" runat="server"
                Text='<%# Eval("Nouveaux_Inscrits")%>'></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:Label ID="lbl11" runat="server"
                Text='<%# Eval("Nouveaux_Inscrits")%>'></asp:Label>
    </EditItemTemplate> 
    <FooterTemplate>
        <asp:TextBox ID="txt1" runat="server"></asp:TextBox>
   </FooterTemplate>
</asp:TemplateField>

 <asp:TemplateField   HeaderText = "Redoublants_Inscrits">
    <ItemTemplate>
        <asp:Label ID="lbl2" runat="server"
                Text='<%# Eval("Redoublants_Inscrits")%>'></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:Label ID="lbl22" runat="server"
                Text='<%# Eval("Redoublants_Inscrits")%>'></asp:Label>
    </EditItemTemplate> 
    <FooterTemplate>
        <asp:TextBox ID="txt2" runat="server"></asp:TextBox>
   </FooterTemplate>
</asp:TemplateField>

 <asp:TemplateField   HeaderText = "Inscrits">
    <ItemTemplate>
        <asp:Label ID="lbl3" runat="server"
                Text='<%# Eval("Inscrits")%>'></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:Label ID="lbl33" runat="server"
                Text='<%# Eval("Inscrits")%>'></asp:Label>
    </EditItemTemplate> 
    <FooterTemplate>
        <asp:TextBox ID="txt3" runat="server"></asp:TextBox>
   </FooterTemplate>
</asp:TemplateField>

                 <%-- <asp:BoundField DataField="Nouveaux_Inscrits" HeaderText="Nouveaux_Inscrits" ReadOnly="True" 
                SortExpression="Nouveaux_Inscrits" /> --%>

                 <%-- <asp:BoundField DataField="Redoublants_Inscrits" HeaderText="Redoublants_Inscrits" ReadOnly="True" 
                SortExpression="Redoublants_Inscrits" /> --%>

                 <%-- <asp:BoundField DataField="Inscrits" HeaderText="Inscrits" ReadOnly="True" 
                SortExpression="Inscrits" /> --%>

                <asp:TemplateField   HeaderText = "Nouveaux_Pre_inscrits">
    <ItemTemplate>
        <asp:Label ID="lbl5" runat="server"
                Text='<%# Eval("Nouveaux_Pre_inscrits")%>'></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:Label ID="lbl55" runat="server"
                Text='<%# Eval("Nouveaux_Pre_inscrits")%>'></asp:Label>
    </EditItemTemplate> 
    <FooterTemplate>
        <asp:TextBox ID="txt5" runat="server"></asp:TextBox>
   </FooterTemplate>
</asp:TemplateField>

                 <%-- <asp:BoundField DataField="Redoublants_Pre_Inscrits" HeaderText="Redoublants_Pre_Inscrits" ReadOnly="True" 
                SortExpression="Redoublants_Pre_Inscrits" /> --%>
               


                 <%--<asp:BoundField DataField="Pré_Inscrits" HeaderText="Pré_Inscrits" ReadOnly="True" 
                SortExpression="Pré_Inscrits" /> --%>

                 <asp:TemplateField   HeaderText = "Redoublants_Pre_Inscrits">
    <ItemTemplate>
        <asp:Label ID="lbl6" runat="server"
                Text='<%# Eval("Redoublants_Pre_Inscrits")%>'></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:Label ID="lbl66" runat="server"
                Text='<%# Eval("Redoublants_Pre_Inscrits")%>'></asp:Label>
    </EditItemTemplate> 
    <FooterTemplate>
        <asp:TextBox ID="txt6" runat="server"></asp:TextBox>
   </FooterTemplate>
</asp:TemplateField>

 <asp:TemplateField   HeaderText = "Pré_Inscrits">
    <ItemTemplate>
        <asp:Label ID="lbl5" runat="server"
                Text='<%# Eval("Pré_Inscrits")%>'></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:Label ID="lbl55" runat="server"
                Text='<%# Eval("Pré_Inscrits")%>'></asp:Label>
    </EditItemTemplate> 
    <FooterTemplate>
        <asp:TextBox ID="txt5" runat="server"></asp:TextBox>
   </FooterTemplate>
</asp:TemplateField>
                <%-- <asp:BoundField DataField="Redoublants_Pre_Inscrits" HeaderText="Redoublants_Pre_Inscrits" ReadOnly="True" 
                SortExpression="Redoublants_Pre_Inscrits" /> --%>

   


                <%-- <asp:BoundField DataField="Pré_Inscrits" HeaderText="Pré_Inscrits" ReadOnly="True" 
                SortExpression="Pré_Inscrits" /> --%>

                  <asp:TemplateField   HeaderText = "Total">
    <ItemTemplate>
        <asp:Label ID="lbl8" runat="server"
                Text='<%# Eval("Total")%>'></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:Label ID="lbl88" runat="server"
                Text='<%# Eval("Total")%>'></asp:Label>
    </EditItemTemplate> 
    <FooterTemplate>
        <asp:TextBox ID="txt8" runat="server"></asp:TextBox>
   </FooterTemplate>
</asp:TemplateField>


               <%-- <asp:BoundField DataField="Total" HeaderText="Total" ReadOnly="True" 
                SortExpression="Total" /> --%>
                

                     </Columns>
                                                        <HeaderStyle CssClass="GridHeaderStyle" />
                                                        <RowStyle ForeColor="#000000"  />
                                                        <SelectedRowStyle CssClass="GridSelectedStyle" />
                                                        
                                                    </asp:GridView>
<br />
<br />

<br />
<asp:GridView runat="server" ID="Gridtoiec" AutoGenerateColumns="False" 
                                                       
                                                         Style="border-bottom: white 2px ridge; border-left: white 2px ridge;
                                                        background-color: white; border-top: white 2px ridge; border-right: white 2px ridge;"
                                                        BorderWidth="0px" BorderColor="Red" CellSpacing="1" CellPadding="3" CssClass="grid"
                                                        RowStyle-CssClass="ItemStyle" HeaderStyle-CssClass="FixedHeaderStyle" 
                                                        GridLines="Both" EmptyDataRowStyle-CssClass="ItemStyle"  BackColor="#0099CC"
                                                     OnPageIndexChanging="gridViewtoiec_PageIndexChanging"
                                                    
                                                     ShowFooter="true"
                                                       onrowdatabound="GridView1_RowDataBound"

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
          <asp:BoundField DataField="Site" HeaderText="Site" ReadOnly="True" 
                SortExpression="Site" /> 


 

               
<asp:TemplateField HeaderText="Nouveaux_inscrits">
        <ItemTemplate>
            <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Nouveaux_inscrits")%>' />
         </ItemTemplate>
         <FooterTemplate>
            <asp:Label ID="lblTotalPrice" runat="server" />
         </FooterTemplate>                   
      </asp:TemplateField>

                 <%-- <asp:BoundField DataField="Redoublants_inscrits" HeaderText="Redoublants_inscrits" ReadOnly="True" 
                SortExpression="Redoublants_inscrits" /> --%>

                <asp:TemplateField HeaderText="Redoublants_inscrits">
         <ItemTemplate>
            <asp:Label ID="lblUnitsInStock" runat="server" Text='<%# Eval("Redoublants_inscrits") %>' />
         </ItemTemplate>                   
         <FooterTemplate>
            <asp:Label ID="lblTotalUnitsInStock" runat="server" />
         </FooterTemplate>
      </asp:TemplateField>


                <%--  <asp:BoundField DataField="Inscrits" HeaderText="Inscrits" ReadOnly="True" 
                SortExpression="Inscrits" /> --%>
                <asp:TemplateField HeaderText="Inscrits">
         <ItemTemplate>
            <asp:Label ID="lblUnitsInStockGC" runat="server" Text='<%# Eval("Inscrits") %>' />
         </ItemTemplate>                   
         <FooterTemplate>
            <asp:Label ID="lblTotalUnitsInStockGC" runat="server" />
         </FooterTemplate>
      </asp:TemplateField>

                <%-- <asp:BoundField DataField="Nouveaux_Pre_inscrits" HeaderText="Nouveaux_Pre_inscrits" ReadOnly="True" 
                SortExpression="Nouveaux_Pre_inscrits" /> --%>
                 <asp:TemplateField HeaderText="Nouveaux_Pre_inscrits">
         <ItemTemplate>
            <asp:Label ID="lblUnitsInStockGCTotal" runat="server" Text='<%# Eval("Nouveaux_Pre_inscrits") %>' />
         </ItemTemplate>                   
         <FooterTemplate>
            <asp:Label ID="lblTotalUnitsInStockGCTotal" runat="server" />
         </FooterTemplate>
      </asp:TemplateField>

                <%-- <asp:BoundField DataField="Redoublants_Pre_inscrits" HeaderText="Redoublants_Pre_inscrits" ReadOnly="True" 
                SortExpression="Redoublants_Pre_inscrits" /> --%>

                          <asp:TemplateField HeaderText="Redoublants_Pre_inscrits">
         <ItemTemplate>
            <asp:Label ID="lblUnitsInStockGCTredoub" runat="server" Text='<%# Eval("Redoublants_Pre_inscrits") %>' />
         </ItemTemplate>                   
         <FooterTemplate>
            <asp:Label ID="lblTotalUnitsInStockredoub" runat="server" />
         </FooterTemplate>
      </asp:TemplateField>

                <%-- <asp:BoundField DataField="Pre_Inscrits" HeaderText="Pre_Inscrits" ReadOnly="True" 
                SortExpression="Pre_Inscrits" /> --%>
                 <asp:TemplateField HeaderText="Pré_Inscrits">
         <ItemTemplate>
            <asp:Label ID="lblUnitsInStockGCTprins" runat="server" Text='<%# Eval("Pré_Inscrits") %>' />
         </ItemTemplate>                   
         <FooterTemplate>
            <asp:Label ID="lblTotalUnitsInStockprins" runat="server" />
         </FooterTemplate>
      </asp:TemplateField>

                <%--<asp:BoundField DataField="NB" HeaderText="NB" ReadOnly="True" 
                SortExpression="NB" /> --%>
                <asp:TemplateField HeaderText="Total">
         <ItemTemplate>
            <asp:Label ID="lblUnitsInStockNB" runat="server" Text='<%# Eval("Total") %>' />
         </ItemTemplate>                   
         <FooterTemplate>
            <asp:Label ID="lblTotalUnitsInStockNB" runat="server" />
         </FooterTemplate>
      </asp:TemplateField>
                

                     </Columns>
                      <FooterStyle BackColor="Red" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
   <HeaderStyle BackColor="Red" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                  
                 
                                                        <HeaderStyle CssClass="GridHeaderStyle" />
                                                        <RowStyle ForeColor="#000000"  />
                                                        <SelectedRowStyle CssClass="GridSelectedStyle" />
                                                        
                                                    </asp:GridView>

</td>

<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    &nbsp;</td>



</tr>

</table>

                                                   
</asp:Content>