<%@ Page Title="" Language="C#" MasterPageFile="~/Etudiants/Eol.Master" AutoEventWireup="true" CodeBehind="LANG.aspx.cs" Inherits="ESPOnline.Etudiants.LANG" %>
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
              <center><h1> Notes Des Modules LANGUES </h1></center>
                
                <asp:Panel ID="Panel1" runat="server">
                <hr /><hr />
                <center>
                 
                    <asp:GridView ID="GridView1" runat="server" 
                AutoGenerateColumns="False" DataSourceID="SqlDataSource1" 
                        CssClass="list-inline" BackColor="White" BorderColor="#CCCCCC" 
                        BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                         >
                        <Columns>
                            <asp:BoundField DataField="DESIGNATION" HeaderText="MODULES" 
                        SortExpression="DESIGNATION" />
                        <asp:BoundField DataField="COEF" HeaderText="COEF"    SortExpression="COEF" />
                            <asp:BoundField DataField="NOM_ENS" HeaderText="NOM ENSEIGNANT" 
                                SortExpression="NOM_ENS" />

                             <asp:BoundField DataField="NOTE_ORALE_LANG" HeaderText="ORAL" 
                                SortExpression="NOTE_ORALE_LANG" />
                                 <asp:BoundField DataField="TAUX_ORALE_LANG" HeaderText="TAUX ORAL" 
                                SortExpression="TAUX_ORALE_LANG" />
                             <asp:BoundField DataField="NOTE_CC_LANG" HeaderText="CONTROLE CONTINU" 
                                SortExpression="NOTE_CC_LANG" />
                      
                           <asp:BoundField DataField="TAUX_CC_LANG" HeaderText="TAUX CC" 
                                SortExpression="TAUX_CC_LANG" />

                              <asp:BoundField DataField="NOTE_ECRIT_LANG" HeaderText="ECRIT" 
                                SortExpression="NOTE_ECRIT_LANG" />

                               <asp:BoundField DataField="TAUX_ECRIT_LANG" HeaderText="TAUX ECRIT" 
                                SortExpression="TAUX_ECRIT_LANG" />
                            <asp:BoundField DataField="NOTE_EXAM" HeaderText="MOYENNE" 
                                SortExpression="NOTE_EXAM" />
                        </Columns>
                          <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#A80000" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#E0E0E0" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                        SelectCommand="SELECT DESIGNATION, COEF, NOM_ENS, NOTE_EXAM, NOTE_ECRIT_LANG, NOTE_ORALE_LANG,NOTE_CC_LANG,TAUX_CC_LANG,TAUX_ORALE_LANG,TAUX_ECRIT_LANG FROM ESP_V_NOTE_LANG WHERE (ID_ET ='1')">
    <SelectParameters>
        <asp:SessionParameter Name="ID_ET" SessionField="ID_ET" Type="String" />
    </SelectParameters>
                    </asp:SqlDataSource>
                     
                <hr /> <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" OnRowDataBound="GridView1_test"
                        CssClass="list-inline" BackColor="White" BorderColor="#CCCCCC" 
                        BorderStyle="None" BorderWidth="1px" CellPadding="3">
                          <Columns>
                            <asp:BoundField DataField="NIV_ACQUIS_FRANCAIS" HeaderText="NIV_ACQUIS_FRANCAIS" 
                        SortExpression="NIV_ACQUIS_FRANCAIS" />
                         <asp:BoundField DataField="NIV_ACQUIS_ANGLAIS" HeaderText="NIV_ACQUIS_ANGLAIS" 
                        SortExpression="NIV_ACQUIS_ANGLAIS" />
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
                        SelectCommand="SELECT NIV_ACQUIS_FRANCAIS,NIV_ACQUIS_ANGLAIS FROM ESP_INSCRIPTION WHERE (ID_ET ='1') and annee_deb=2014">
    <SelectParameters>
        <asp:SessionParameter Name="ID_ET" SessionField="ID_ET" Type="String" />
    </SelectParameters>
                    </asp:SqlDataSource><hr />
                </asp:Panel>
                
                </div>
                <div class="col-xs-1">
               
            </div>
    
            </div>

</asp:Content>