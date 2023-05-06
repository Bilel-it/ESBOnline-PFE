<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Statistique_2017.aspx.cs" Inherits="ESPOnline.Direction.Statistique_2017"
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
      <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
  <%--  <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>--%>
<script src="../Contents/Scripts/ScrollableGridPlugin_ASP.NetAJAX_2.0.js" type="text/javascript"></script>
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

    <script language="javascript" type="text/javascript">

        function CalculSom() {
            var t = document.getElementById("ContentPlaceHolder1_Gridtoiec");
            var r = t.insertRow(t.rows.length);

            for (var j = 0; j < 2; j++) {
                r.insertCell(j);
                var s = 0;
                for (var i = 0; i < t.rows.length - 1; i++) {
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
<table>
<tr>
<td>
<asp:Label ID="lbl2" runat="server" BackColor="White" Font-Bold="True" 
        Font-Size="X-Large" ForeColor="#CC0000" ></asp:Label>
</td>
</tr>
<tr>
<td>
<asp:Label ID="lbl1" runat="server" BackColor="White" Font-Bold="True" 
        Font-Size="Larger" ></asp:Label>
</td>

</tr>
</table>
<table>

<tr>
<td valign="middle"><asp:Button  ID="Btntoiec" runat="server" 
         Text="Exporter en excel" 
Height="50px" onclick="BUTT1_Click" /></td>
<td>&nbsp;&nbsp;</td>
<td align="left">
<h3>Site Ghazala</h3>

<h4 >
 <asp:Label ID="Lblgh" runat="server" ForeColor="Blue" Visible="false"></asp:Label>
 
 </h4>
<asp:GridView runat="server" ID="Gridtoiec" AutoGenerateColumns="False" 
                                                      
                                                         Style="border-bottom: black 2px ridge; border-left: black 2px ridge;
                                                        background-color: white;  border-top: black 2px ridge; border-right: black 2px ridge;"
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
          <asp:BoundField DataField="Classe" HeaderText="Classe" ReadOnly="True" 
                SortExpression="Classe" /> 
                 <%--<asp:BoundField DataField="Effectif" HeaderText="Effectif" ReadOnly="True" 
                SortExpression="Effectif" /> --%>

                 <asp:TemplateField HeaderText="Effectif">
         <ItemTemplate>
            <asp:Label ID="lblPricezer" runat="server" Text='<%# Eval("Effectif") %>' />
         </ItemTemplate>                   
         <FooterTemplate>
            <asp:Label ID="lblTotalPriceeze" runat="server" />
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
                                                   
                                                  
                                                    <br />
                                                    <br />
                                                  

</td>

<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    &nbsp;</td>
    <td>
    
     
                                                    <asp:Button  ID="Button1" runat="server" 
         Text="Exporter en excel" 
Height="50px"   onclick="BuTT2_Click" />
    </td>
    <td valign="middle">&nbsp;&nbsp;</td>
<td align="right" valign="top">
 <h3>Site Charguia </h3>
 <h4>
 <asp:Label ID="lblch" runat="server" ForeColor="Blue" Visible="false"></asp:Label>
 
 </h4>
<asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="False" 
                                                        
                                                         Style="border-bottom: black 2px ridge; border-left: black 2px ridge;
                                                        background-color: white;  border-top: black 2px ridge; border-right: black 2px ridge;"
                                                        BorderWidth="0px" BorderColor="Red" CellSpacing="1" CellPadding="3" CssClass="grid"
                                                        RowStyle-CssClass="ItemStyle" HeaderStyle-CssClass="FixedHeaderStyle" 
                                                        GridLines="Both" EmptyDataRowStyle-CssClass="ItemStyle"  BackColor="#0099CC"
                                                     OnPageIndexChanging="gridViewtoiec62_PageIndexChanging"
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
         <asp:BoundField DataField="Classe" HeaderText="Classe" ReadOnly="True" 
                SortExpression="Classe" /> 
                <%-- <asp:BoundField DataField="Effectif" HeaderText="Effectif" ReadOnly="True" 
                SortExpression="Effectif" /> --%>
                <asp:TemplateField HeaderText="Effectif">
         <ItemTemplate>
            <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Effectif") %>' />
         </ItemTemplate>                   
         <FooterTemplate>
            <asp:Label ID="lblTotalPrice" runat="server" />
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
                                                     
                                                    
                                                   
                                                  
</td>

</tr>

</table>

                                                   
</asp:Content>
