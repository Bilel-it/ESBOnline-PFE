<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rep_etud_niv_pole.aspx.cs" Inherits="ESPOnline.Direction.Rep_etud_niv_pole" MasterPageFile="~/Direction/Site2.Master" %>

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
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
<br />
<table>
<tr>
<td align="right" ><asp:Label ID="lbl2" runat="server" BackColor="RoyalBlue" ></asp:Label></td>
</tr>
<tr>

<td>

<h4>Répartition des étudiants par Niveau et Pôle</h4>
<asp:GridView runat="server" ID="GridView2" AutoGenerateColumns="False" 
                                                          AllowPaging="True"  PageSize="20"
                                                         Style="border-bottom: white 2px ridge; border-left: white 2px ridge;
                                                        background-color: white; width: 100%; border-top: white 2px ridge; border-right: white 2px ridge;"
                                                        BorderWidth="0px" BorderColor="Red" CellSpacing="1" CellPadding="3" CssClass="grid"
                                                        RowStyle-CssClass="ItemStyle" HeaderStyle-CssClass="FixedHeaderStyle" Width="100%"
                                                        GridLines="Both" EmptyDataRowStyle-CssClass="ItemStyle"  BackColor="#0099CC"
                                                     Visible="false"

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
          

                 <asp:BoundField DataField="Pôle_TIC" HeaderText="Pôle_TIC" ReadOnly="True" 
                SortExpression="Pôle_TIC" /> 


                 <asp:BoundField DataField="Pôle_GCEM" HeaderText="Pôle_GCEM" ReadOnly="True" 
                SortExpression="Pôle_GCEM" /> 

                 <asp:BoundField DataField="Total" HeaderText="Total" ReadOnly="True" 
                SortExpression="Total" /> 

                  
                     </Columns>
                                                        <HeaderStyle CssClass="GridHeaderStyle" />
                                                        <RowStyle ForeColor="#000000"  />
                                                        <SelectedRowStyle CssClass="GridSelectedStyle" />
                                                        
                                                    </asp:GridView>
<asp:GridView runat="server" ID="Gridtoiec" AutoGenerateColumns="False" 
                                                          AllowPaging="True"  PageSize="20"
                                                         Style="border-bottom: white 2px ridge; border-left: white 2px ridge;
                                                        background-color: white; width: 100%; border-top: white 2px ridge; border-right: white 2px ridge;"
                                                        BorderWidth="0px" BorderColor="Red" CellSpacing="1" CellPadding="3" CssClass="grid"
                                                        RowStyle-CssClass="ItemStyle" HeaderStyle-CssClass="FixedHeaderStyle" Width="100%"
                                                        GridLines="Both" EmptyDataRowStyle-CssClass="ItemStyle"  BackColor="#0099CC"
                                                     OnPageIndexChanging="gridViewtoiec_PageIndexChanging2"
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
          <asp:BoundField DataField="Niveau" HeaderText="Niveau" ReadOnly="True" 
                SortExpression="Niveau" /> 

                 <%--<asp:BoundField DataField="Pôle_TIC" HeaderText="Pôle_TIC" ReadOnly="True" 
                SortExpression="Pôle_TIC" /> 


                 <asp:BoundField DataField="Pôle_GCEM" HeaderText="Pôle_GCEM" ReadOnly="True" 
                SortExpression="Pôle_GCEM" /> 

                 <asp:BoundField DataField="Total" HeaderText="Total" ReadOnly="True" 
                SortExpression="Total" /> --%>
                 <asp:TemplateField HeaderText="Pôle_TIC">
        <ItemTemplate>
            <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Pôle_TIC")%>' />
         </ItemTemplate>
         <FooterTemplate>
            <asp:Label ID="lblTotalPrice" runat="server" />
         </FooterTemplate>                   
      </asp:TemplateField>

                 <%-- <asp:BoundField DataField="Redoublants_inscrits" HeaderText="Redoublants_inscrits" ReadOnly="True" 
                SortExpression="Redoublants_inscrits" /> --%>

                <asp:TemplateField HeaderText="Pôle_GCEM">
         <ItemTemplate>
            <asp:Label ID="lblUnitsInStock" runat="server" Text='<%# Eval("Pôle_GCEM") %>' />
         </ItemTemplate>                   
         <FooterTemplate>
            <asp:Label ID="lblTotalUnitsInStock" runat="server" />
         </FooterTemplate>
      </asp:TemplateField>


                <%--  <asp:BoundField DataField="Inscrits" HeaderText="Inscrits" ReadOnly="True" 
                SortExpression="Inscrits" /> --%>
                <asp:TemplateField HeaderText="Total">
         <ItemTemplate>
            <asp:Label ID="lblUnitsInStockGC" runat="server" Text='<%# Eval("Total") %>' />
         </ItemTemplate>                   
         <FooterTemplate>
            <asp:Label ID="lblTotalUnitsInStockGC" runat="server" />
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

<td>&nbsp;&nbsp;&nbsp;</td>
<td>
<h4>Répartition des Classes par Niveau etPôle</h4>
<asp:GridView runat="server" ID="GridView3" AutoGenerateColumns="False" 
                                                          AllowPaging="True"  PageSize="20"
                                                         Style="border-bottom: white 2px ridge; border-left: white 2px ridge;
                                                        background-color: white; width: 100%; border-top: white 2px ridge; border-right: white 2px ridge;"
                                                        BorderWidth="0px" BorderColor="Red" CellSpacing="1" CellPadding="3" CssClass="grid"
                                                        RowStyle-CssClass="ItemStyle" HeaderStyle-CssClass="FixedHeaderStyle" Width="100%"
                                                        GridLines="Both" EmptyDataRowStyle-CssClass="ItemStyle"  BackColor="#0099CC"
                                                    Visible="false"

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
         

                 <asp:BoundField DataField="Pôle_TIC" HeaderText="Pôle_TIC" ReadOnly="True" 
                SortExpression="Pôle_TIC" /> 


                 <asp:BoundField DataField="Pôle_GCEM" HeaderText="Pôle_GCEM" ReadOnly="True" 
                SortExpression="Pôle_GCEM" /> 

                 <asp:BoundField DataField="Total" HeaderText="Total" ReadOnly="True" 
                SortExpression="Total" /> 

                     </Columns>
                                                        <HeaderStyle CssClass="GridHeaderStyle" />
                                                        <RowStyle ForeColor="#000000"  />
                                                        <SelectedRowStyle CssClass="GridSelectedStyle" />
                                                        
                                                    </asp:GridView>
<asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="False" 
                                                          AllowPaging="True"  PageSize="20"
                                                         Style="border-bottom: white 2px ridge; border-left: white 2px ridge;
                                                        background-color: white; width: 100%; border-top: white 2px ridge; border-right: white 2px ridge;"
                                                        BorderWidth="0px" BorderColor="Red" CellSpacing="1" CellPadding="3" CssClass="grid"
                                                        RowStyle-CssClass="ItemStyle" HeaderStyle-CssClass="FixedHeaderStyle" Width="100%"
                                                        GridLines="Both" EmptyDataRowStyle-CssClass="ItemStyle"  BackColor="#0099CC"
                                                     OnPageIndexChanging="gridViewtoiec_PageIndexChanging4"
                                                      ShowFooter="true"
                                                       onrowdatabound="GridView2_RowDataBound"
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
           <asp:BoundField DataField="Niveau" HeaderText="Niveau" ReadOnly="True" 
                SortExpression="Niveau" /> 
<%--
                 <asp:BoundField DataField="Pôle_TIC" HeaderText="Pôle_TIC" ReadOnly="True" 
                SortExpression="Pôle_TIC" /> 


                 <asp:BoundField DataField="Pôle_GCEM" HeaderText="Pôle_GCEM" ReadOnly="True" 
                SortExpression="Pôle_GCEM" /> 

                 <asp:BoundField DataField="Total" HeaderText="Total" ReadOnly="True" 
                SortExpression="Total" /> --%>

                  <asp:TemplateField HeaderText="Pôle_TIC">
        <ItemTemplate>
            <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Pôle_TIC")%>' />
         </ItemTemplate>
         <FooterTemplate>
            <asp:Label ID="lblTotalPrice" runat="server" />
         </FooterTemplate>                   
      </asp:TemplateField>

                 <%-- <asp:BoundField DataField="Redoublants_inscrits" HeaderText="Redoublants_inscrits" ReadOnly="True" 
                SortExpression="Redoublants_inscrits" /> --%>

                <asp:TemplateField HeaderText="Pôle_GCEM">
         <ItemTemplate>
            <asp:Label ID="lblUnitsInStock" runat="server" Text='<%# Eval("Pôle_GCEM") %>' />
         </ItemTemplate>                   
         <FooterTemplate>
            <asp:Label ID="lblTotalUnitsInStock" runat="server" />
         </FooterTemplate>
      </asp:TemplateField>


                <%--  <asp:BoundField DataField="Inscrits" HeaderText="Inscrits" ReadOnly="True" 
                SortExpression="Inscrits" /> --%>
                <asp:TemplateField HeaderText="Total">
         <ItemTemplate>
            <asp:Label ID="lblUnitsInStockGC" runat="server" Text='<%# Eval("Total") %>' />
         </ItemTemplate>                   
         <FooterTemplate>
            <asp:Label ID="lblTotalUnitsInStockGC" runat="server" />
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





</tr>

</table>

                                                   
</asp:Content>