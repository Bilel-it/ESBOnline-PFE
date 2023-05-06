<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Stat_etudiants.aspx.cs" Inherits="ESPOnline.Direction.Stat_etudiants" MasterPageFile="~/Direction/Site2.Master" %>

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
<h3>Répartition des étudiants par site,niveau,type d'inscription,Nouveau et redoublant</h3>

<asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="False" Visible="false"
                                                          AllowPaging="True"  PageSize="20"
                                                         Style="border-bottom: white 2px ridge; border-left: white 2px ridge;
                                                        background-color: white; border-top: white 2px ridge; border-right: white 2px ridge;"
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
         

                  

                  <asp:BoundField DataField="Nouveaux_Inscrits" HeaderText="Nouveaux_Inscrits" ReadOnly="True" 
                SortExpression="Nouveaux_Inscrits" /> 

                  <asp:BoundField DataField="Redoublants_Inscrits" HeaderText="Redoublants_Inscrits" ReadOnly="True" 
                SortExpression="Redoublants_Inscrits" /> 
               
                <asp:BoundField DataField="Inscrits" HeaderText="Inscrits" ReadOnly="True" 
                SortExpression="Inscrits" /> 

                 <asp:BoundField DataField="Nouveaux_Pre_Inscrits" HeaderText="Nouveaux_Pre_Inscrits" ReadOnly="True" 
                SortExpression="Nouveaux_Pre_Inscrits" /> 

                 <asp:BoundField DataField="Redoublants_Pre_Inscrits" HeaderText="Redoublants_Pre_Inscrits" ReadOnly="True" 
                SortExpression="Redoublants_Pre_Inscrits" /> 

                 <asp:BoundField DataField="Pré_Inscrits" HeaderText="Pré_Inscrits" ReadOnly="True" 
                SortExpression="Pré_Inscrits" /> 

                <asp:BoundField DataField="total" HeaderText="total" ReadOnly="True" 
                SortExpression="total" /> 
                

                     </Columns>
                     
                                                        <HeaderStyle CssClass="GridHeaderStyle" />
                                                        <RowStyle ForeColor="#000000"  />
                                                        <SelectedRowStyle CssClass="GridSelectedStyle" />
                                                        
                                                    </asp:GridView>

<br />

<asp:GridView runat="server" ID="Gridtoiec" AutoGenerateColumns="False" 
                                                       
                                                         Style="border-bottom: black 2px ridge; border-left: black 2px ridge;
                                                        background-color: white; border-top: black 2px ridge; border-right: black 2px ridge;"
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

                  <asp:BoundField DataField="Niveau" HeaderText="Niveau" ReadOnly="True" 
                SortExpression="Niveau" /> 

                  <asp:BoundField DataField="NB_Classes" HeaderText="NB_Classes" ReadOnly="True" 
                SortExpression="NB_Classes" /> 

                 <%-- <asp:BoundField DataField="Nouveaux_Inscrits" HeaderText="Nouveaux_Inscrits" ReadOnly="True" 
                SortExpression="Nouveaux_Inscrits" /> 

                  <asp:BoundField DataField="Redoublants_Inscrits" HeaderText="Redoublants_Inscrits" ReadOnly="True" 
                SortExpression="Redoublants_Inscrits" /> 

                   <asp:BoundField DataField="Inscrits" HeaderText="Inscrits" ReadOnly="True" 
                SortExpression="Inscrits" /> 
                 <asp:BoundField DataField="Nouveaux_Pre_Inscrits" HeaderText="Nouveaux_Pre_Inscrits" ReadOnly="True" 
                SortExpression="Nouveaux_Pre_Inscrits" /> 

                 <asp:BoundField DataField="Redoublants_Pre_Inscrits" HeaderText="Redoublants_Pre_Inscrits" ReadOnly="True" 
                SortExpression="Redoublants_Pre_Inscrits" /> 

                 <asp:BoundField DataField="Pré_Inscrits" HeaderText="Pré_Inscrits" ReadOnly="True" 
                SortExpression="Pré_Inscrits" /> 

                <asp:BoundField DataField="total" HeaderText="total" ReadOnly="True" 
                SortExpression="total" /> 
                --%>
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
                <asp:TemplateField HeaderText="total">
         <ItemTemplate>
            <asp:Label ID="lblUnitsInStockNB" runat="server" Text='<%# Eval("total") %>' />
         </ItemTemplate>                   
         <FooterTemplate>
            <asp:Label ID="lblTotalUnitsInStockNB" runat="server" />
         </FooterTemplate>
      </asp:TemplateField>
                

                     </Columns>
                     <FooterStyle BackColor="Red" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"  />
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
                                          <asp:Button  ID="Button1" runat="server" Text="Exporter en excel" 
Height="50px" ForeColor="Black" BackColor="#CCCCCC"  CssClass="text-info" onclick="BuTT2_Click" />
                                          </td>  
                                            
                                            </tr>
                                            </table>        
                                                    
                                                    </center>

</td>

<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    &nbsp;</td>



</tr>

</table>

                                                   
</asp:Content>
