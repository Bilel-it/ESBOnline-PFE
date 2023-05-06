<%@ Page Title="" Language="C#" MasterPageFile="~/Enseignants/Ens.Master" AutoEventWireup="true" CodeBehind="HL.aspx.cs" Inherits="ESPOnline.Enseignants.HL" %>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<center> 
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                    </telerik:RadScriptManager>
                    <br />
      <telerik:RadComboBox ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" AutoPostBack="True" 
                                                            DataTextField="NOM" DataValueField="ID_ET" EmptyMessage="Tappez le Nom d'etudiant "   
                                                            Filter="Contains" Width="300" MaxHeight="400" DropDownWidth="500" EnableLoadOnDemand="True" ShowMoreResultsBox="False" BorderStyle="Double" BorderColor="Maroon" HighlightTemplatedItems="True">
                                                        </telerik:RadComboBox>
                                                        <br /><br />
                                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server"
     ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
                    ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" 
                    
                    SelectCommand="SELECT NOM_ET||' '||PNOM_ET || ' '||ESP_ETUDIANT.ID_ET ||'  '|| esp_inscription.code_cl as NOM, ESP_ETUDIANT.ID_ET as ID_ET FROM ESP_ETUDIANT, ESP_INSCRIPTION WHERE (ESP_INSCRIPTION.ID_ET=ESP_ETUDIANT.ID_ET )AND (ESP_INSCRIPTION.ANNEE_deb=2013) AND esp_inscription.code_cl NOT LIKE '%-%' and esp_inscription.code_cl not like '%FU%'  order by NOM"></asp:SqlDataSource>


<br />
<asp:GridView ID="GridView2" runat="server"      Width="90%"
                    DataSourceID="SqlDataSource2" ShowFooter="True" AutoGenerateColumns="False">
                    <Columns>
                        
                        
                        <asp:BoundField DataField="ANNEE_DEB" HeaderText="ANNEE"  
                            SortExpression="ANNEE_DEB">
                            <ItemStyle Width="20px" />
                        </asp:BoundField>
                       <asp:BoundField DataField="SEMESTRE" HeaderText="SEMESTRE"  
                            SortExpression="SEMESTRE">
                            <ItemStyle Width="20px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CODE_MODULE" HeaderText="CODE_MODULE" SortExpression="CODE_MODULE" > 
                             <ItemStyle Width="10px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="NOTE_EXAM" HeaderText="NOTE_EXAM"  
                            SortExpression="NOTE_EXAM">
                             <ItemStyle Width="20px" />
                        </asp:BoundField>
                         <asp:BoundField DataField="NOTE_CC" HeaderText="NOTE_CC"  
                            SortExpression="NOTE_CC">
                             <ItemStyle Width="20px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="NOTE_TP" HeaderText="NOTE_TP"  
                            SortExpression="NOTE_TP">
                             <ItemStyle Width="20px" />
                        </asp:BoundField>
                  
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
    </div>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
        ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" 
        SelectCommand="SELECT &quot;CODE_MODULE&quot;, &quot;ANNEE_DEB&quot;,SEMESTRE, &quot;NOTE_CC&quot;, &quot;NOTE_TP&quot;, &quot;NOTE_EXAM&quot; FROM &quot;ESP_NOTE&quot; WHERE (ID_ET =:ID_ETT) and (code_module like 'AN%' or code_module like 'FR%')">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList1" Name="ID_ETT" 
                PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource></center>
  
</asp:Content>
