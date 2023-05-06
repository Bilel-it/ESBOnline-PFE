<%@ Page Title="" Language="C#" MasterPageFile="~/Parents/Par.Master" AutoEventWireup="true" CodeBehind="ResultatPrincipale2021P.aspx.cs" Inherits="ESPOnline.Parents.ResultatPrincipale2021P" %>
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
    <div class="col-xs-1">
    </div>
    <div class="col-xs-10">
        <center>
            <asp:Label ID="lbletat" runat="server" Visible="false"></asp:Label>

                 <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
            
            <h1>
                <asp:Label ID="Label5" runat="server" Text=" "></asp:Label>
                <asp:Label ID="Label6" runat="server" Text="Resultat Session Principale"></asp:Label>

            </h1>
        </center>
      <%--  <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>--%>
        &nbsp;
        <asp:Label ID="Label9" runat="server"  Visible="false" Text=""></asp:Label>
         <asp:Label ID="Label3" runat="server"  Visible="false" Text=""></asp:Label>
        &nbsp;
        <center>
        <br />
        <asp:DetailsView ID="DetailsView2" runat="server" AutoGenerateRows="False" 
                DataSourceID="SqlDataSource3" Height="50px" Width="536px" 
            BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" 
            CellPadding="3" CellSpacing="1" GridLines="None">
                <EditRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                <Fields>
                     
                    <asp:BoundField DataField="LIB_DECISION_SESSION_P" 
                        HeaderText="Session Principale:" 
                        SortExpression="LIB_DECISION_SESSION_P" />
                    <asp:BoundField DataField="moy_general" HeaderText="Moyenne :" 
                        SortExpression="moy_general" />
                         <asp:BoundField DataField="NB_ECTS_SP" HeaderText="NB_ECTS_AQUIS :" 
                        SortExpression="NB_ECTS_AQUIS" />
                </Fields>
                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#660066" ForeColor="White" Font-Bold="True"/>
            </asp:DetailsView>

<asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
                                            ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" 
    SelectCommand="SELECT moy_general,lib_decision_session_p,nb_ects_sp FROM ESP_INSCRIPTION a    WHERE  (ID_ET =:ID_ET) and a.annee_deb = (select max(annee_deb) from societe)  ">
                                       <SelectParameters>
            <asp:SessionParameter Name="ID_ET" SessionField="ID_ET" Type="String" />
        </SelectParameters>
                                        </asp:SqlDataSource><br />
            <asp:Panel ID="Panel1" runat="server">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Visible="false">
                    <Columns>
                        <%-- <asp:BoundField DataField="CODE_MODULE" HeaderText="CODE_MODULE" SortExpression="CODE_MODULE" />--%>
                        <asp:BoundField DataField="DESIGNATION" HeaderText="DESIGNATION" SortExpression="DESIGNATION" />
                        <asp:BoundField DataField="COEF" HeaderText="COEF" SortExpression="COEF" />
                        <asp:BoundField DataField="MOYENNE" HeaderText="MOYENNE" SortExpression="MOYENNE" />
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#A80000 " Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#E0E0E0 " ForeColor="#000000" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#070719" />
                    <SelectedRowStyle BackColor="#E0E0E0" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
                    ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
                    SelectCommand="SELECT * FROM ESP_V_MOY_MODULE_ETUDIANT_UE WHERE (ID_ET =:ID_ET) and type_moy = 'P'">
                    <SelectParameters>
                        <asp:SessionParameter Name="ID_ET" SessionField="ID_ET" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </asp:Panel>
        </center>
        <center>
            <asp:Panel ID="Panel2" runat="server">
                <asp:GridView ID="GridView2" runat="server" OnDataBound="OnDataBound" OnRowDataBound="GridView1_test"
                    DataSourceID="ObjectDataSource1" ShowFooter="false" AutoGenerateColumns="False">
                    <Columns>
                        <%-- <asp:BoundField DataField="CODE_UE" HeaderText="CODE_UE" 
                                 SortExpression="CODE_UE" />--%>
                        <asp:BoundField DataField="LIB_UE" HeaderText="Unite d'Enseignement"
                             ItemStyle-Width="150" SortExpression="LIB_UE">
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
                          <asp:TemplateField HeaderText="NB_ECTS Aquis /UE" SortExpression="NB_ECTS" Visible="false">
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
                            SortExpression="DESIGNATION" Visible="false">
                            <ItemStyle Width="200px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="NB_ECTS" HeaderText="NB_ECTS" ItemStyle-Width="150" SortExpression="NB_ECTS" Visible="false" />
                        <asp:BoundField DataField="COEF" HeaderText="COEF" SortExpression="COEF" Visible="false" >
                           
                        </asp:BoundField>
                        <asp:BoundField DataField="MOY_MODULE" HeaderText="MOY_MODULE"   Visible="false"
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
                </asp:GridView>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetResFinal"
                    TypeName="ESPOnline.Etudiants.ResultatFinalP">
                    <SelectParameters>
                        <asp:SessionParameter Name="_Id_et" SessionField="ID_ET" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </asp:Panel>
        </center>
        <br />
        <br />
        <center>
            <asp:Panel ID="Panel3" runat="server">
                <asp:GridView ID="GridView3" runat="server" DataSourceID="SqlDataSource2" Visible="false">
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
                    ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
                    SelectCommand="SELECT MOY_GENERAL as moyenne_general, LIB_DECISION_SESSION_P as DECISION  FROM ESP_INSCRIPTION WHERE code_cl  like '5%'  and ANNEE_DEB =(select max(annee_deb) from societe) and (ID_ET =:ID_ET) ">
                    <SelectParameters>
                        <asp:SessionParameter Name="ID_ET" SessionField="ID_ET" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </asp:Panel>
        </center>
</asp:Content>