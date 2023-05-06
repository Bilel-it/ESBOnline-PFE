<%@ Page Title="" Language="C#" MasterPageFile="~/Etudiants/Eol.Master" AutoEventWireup="true" CodeBehind="LANG2.aspx.cs" Inherits="ESPOnline.Etudiants.LANG2" %>
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
            <br /><br /><br />
            <div class="col-xs-10">
              <center><h1> Notes Des Modules LANGUES </h1></center>
                
                <asp:Panel ID="Panel1" runat="server">
                <hr /><hr />
                <center>
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" OnRowDataBound="GridView1_test"
                      CssClass="list-inline" BackColor="White" BorderColor="#CCCCCC"  
                        BorderStyle="None" BorderWidth="1px" CellPadding="3">
                          <Columns>
                            <asp:BoundField DataField="NIVEAU_COURANT_FR" HeaderText="FRANCAIS" 
                        SortExpression="NIVEAU_COURANT_FR" />
                         <asp:BoundField DataField="NIVEAU_COURANT_ANG" HeaderText="ANGLAIS" 
                        SortExpression="NIVEAU_COURANT_ANG" />
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
                        SelectCommand="SELECT NIVEAU_COURANT_ANG,NIVEAU_COURANT_FR FROM ESP_V_LANG_5 WHERE (ID_ET =: ID_ET) and annee_deb=2015">
    <SelectParameters>
        <asp:SessionParameter Name="ID_ET" SessionField="ID_ET" Type="String" />
    </SelectParameters>
                    </asp:SqlDataSource>
                </center>
                </asp:Panel>
</asp:Content>