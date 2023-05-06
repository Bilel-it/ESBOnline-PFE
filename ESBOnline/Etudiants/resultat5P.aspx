<%@ Page Title="" Language="C#" MasterPageFile="~/Etudiants/Eol.Master" AutoEventWireup="true" CodeBehind="resultat5P.aspx.cs" Inherits="ESPOnline.Etudiants.resultat5P" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<center><asp:GridView ID="GridView2" runat="server" OnDataBound="OnDataBound" OnRowDataBound="GridView1_test"
                    DataSourceID="ObjectDataSource1" ShowFooter="True" AutoGenerateColumns="False">
                    <Columns>
                        <%-- <asp:BoundField DataField="CODE_UE" HeaderText="CODE_UE" 
                                 SortExpression="CODE_UE" />--%>
                        <asp:BoundField DataField="LIB_UE" HeaderText="Unite d'Enseignement" ItemStyle-Width="150" SortExpression="LIB_UE">
                            <ItemStyle Width="150px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="NB_ECTS" SortExpression="NB_ECTS">
                            <ItemTemplate>
                                <asp:Label ID="Label8" runat="server" Text='<%# Bind("NB_ECTS") %>'></asp:Label>
                            </ItemTemplate>
                           
                        </asp:TemplateField>
                        <%--<asp:BoundField DataField="MOY_UE" HeaderText="MOY_UE" ItemStyle-Width="150" SortExpression="MOY_UE">
                            <ItemStyle Width="150px" />

                        </asp:BoundField>--%>
                                                  <asp:TemplateField HeaderText="MOYENNE /UE" SortExpression="MOY_UE">
                            <ItemTemplate>
                                <asp:Label ID="Label14" runat="server" Text='<%# Bind("MOY_UE") %>'></asp:Label>
                            </ItemTemplate>
                             <FooterTemplate>
                                <div style="text-align: center;">
                                    <table width="100%" >
                    <tr><td><asp:Label ID="Label15" runat="server" Text="Total ECTS encaissés :" /></tr></td>
                    
                            <tr><td>     <asp:Label ID="Label1" runat="server" Text="MOYENNE GENERAL :"></asp:Label></tr></td>
                                 <tr><td>   <asp:Label ID="DECISION" runat="server" Text="DECISION :"></asp:Label></tr></td></table>
                                </div>
                            </FooterTemplate>
                            </asp:TemplateField>
                          <asp:TemplateField HeaderText="NB_ECTS Aquis /UE" SortExpression="NB_ECTS">
                            <ItemTemplate>
                                <asp:Label ID="Label8" runat="server" Text='<%# Bind("NB_ECTS") %>'></asp:Label>
                            </ItemTemplate>
                             <FooterTemplate>
                                <div style="text-align: center">
                               <table width="100%" >
                    <tr><td>       <asp:Label ID="Label2" runat="server" /></tr></td>
                     <tr><td>  <asp:Label ID="Label3" runat="server"  ></asp:Label></tr></td>
                             <tr><td>    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>  </td></tr> </table>
                                </div>
                            </FooterTemplate>
                            </asp:TemplateField>
                        <asp:BoundField DataField="DESIGNATION" HeaderText="MODULES" ItemStyle-Width="150"
                            SortExpression="DESIGNATION">
                            <ItemStyle Width="200px" />
                        </asp:BoundField>
                        <%--<asp:BoundField DataField="NB_ECTS" HeaderText="NB_ECTS" ItemStyle-Width="150" SortExpression="NB_ECTS" />--%>
                        <asp:BoundField DataField="COEF" HeaderText="COEF" SortExpression="COEF" >
                           
                        </asp:BoundField>
                        <asp:BoundField DataField="MOY_MODULE" HeaderText="MOY_MODULE"  
                            SortExpression="MOY_MODULE">
                             
                        </asp:BoundField>
                        
                    <%--    <asp:TemplateField HeaderText="Quantity">
                            <ItemTemplate>
                                <div style="text-align: right;">
                                    <asp:Label ID="lblqty" runat="server" Text='' />
                                </div>
                            </ItemTemplate>
                           
                        </asp:TemplateField>--%>
                        <%-- <FooterTemplate>
                                <div style="text-align: right;">
                                    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                                </div>
                            </FooterTemplate>--%>
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" CssClass="footer" />
                    <HeaderStyle BackColor="#A80000 " Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#E0E0E0 " ForeColor="#000000" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000000" />
                    <SelectedRowStyle BackColor="#E0E0E0" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView> <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetResFinal"
                    TypeName="ESPOnline.Etudiants.ResultatFinalP">
                    <SelectParameters>
                        <asp:SessionParameter Name="_Id_et" SessionField="ID_ET" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource></center>
</asp:Content>
