<%@ Page Title="" Language="C#" MasterPageFile="~/Finance/RECU.Master" AutoEventWireup="true" CodeBehind="listevalider.aspx.cs" Inherits="ESPOnline.Finance.listevalider" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <link href="../Contents/Css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />
    <script src="../Contents/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="../Contents/Scripts/bootstrap.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="row">
            <div class="col-xs-1">
               
            </div>
            <div class="col-xs-10">
                
                <asp:Panel ID="Panel1" runat="server">
                    <a href="PHOTO.aspx">Retour</a><hr />
                <center>
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" 
                        CssClass="list-inline" BackColor="White" BorderColor="#CCCCCC" 
                        BorderStyle="None" BorderWidth="1px" CellPadding="3">
                          <Columns>
                              
                            <asp:BoundField DataField="id_et" HeaderText="id_et" 
                        SortExpression="id_et" />
                         <asp:BoundField DataField="nom_et" HeaderText="nom_et" 
                        SortExpression="nom_et" />
                                                 <asp:BoundField DataField="pnom_et" HeaderText="pnom_et" 
                        SortExpression="pnom_et" />
                        </Columns>
                           <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#A80000" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#E0E0E0" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" Font-Bold="True" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>
                     <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                        SelectCommand="select e2.id_et,e3.nom_et,e3.pnom_et from  SCO_ADMIS1415.esp_recu e2, SCO_ADMIS1415.esp_etudiant e3 where trim(e2.id_et) like '15%' AND e2.etat='V'
and e2.id_et not in(select id_et from scoesb02.esp_inscription e1 where trim(id_et) like '15%') and e2.id_et=e3.id_et ">
    
                    </asp:SqlDataSource>
                </center>
                </asp:Panel>
</asp:Content>