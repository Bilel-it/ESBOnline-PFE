<%@ Page Title="" Language="C#" MasterPageFile="~/Direction/Site2.Master" AutoEventWireup="true" CodeBehind="recu.aspx.cs" Inherits="ESPOnline.Direction.recu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 170px;
        }
        .style3
        {
            width: 159px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style1">
        <tr>
            <td class="style2">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
            <td class="style3">
                &nbsp;
                </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label4" runat="server" Text="Nombre total:"></asp:Label>
            </td>
            <td class="style3">
                <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label2" runat="server" Text="Nombre de reçus validés:"></asp:Label>
            </td>
            <td class="style3">
    
                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td >
      <br />  
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
&nbsp; 
            <center>
                
            
               <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                    CellPadding="3" CssClass="list-inline" DataSourceID="SQLDataSource1">
                    <Columns>
                          <asp:BoundField DataField="id_et" HeaderText="id_et"  
                      />
                      
                                 <asp:BoundField DataField="nom_et" HeaderText="nom_et" 
                                SortExpression="nom_et" /> 
<asp:BoundField DataField="pnom_et" HeaderText="pnom_et" 
                                SortExpression="pnom_et" /> 
                                <asp:BoundField DataField="SPECIALITE_ESP_ET" HeaderText="SPECIALITE" 
                                SortExpression="SPECIALITE_ESP_ET" /> 
                                  <asp:BoundField DataField="date_dossir" HeaderText="date_dossier" 
                                SortExpression="date_dossir" /> 
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
                        </td>
                       
&nbsp;&nbsp;&nbsp;&nbsp; </center>
            
    
         
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString3 %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString3.ProviderName %>" 
    
       
        
        
        SelectCommand="SELECT e1.ID_ET, e2.NOM_ET, e2.PNOM_ET, e2.SPECIALITE_ESP_ET,e1.date_dossir FROM SCO_ADMIS1415.ESP_RECU e1 INNER JOIN SCO_ADMIS1415.ESP_ETUDIANT e2 ON e1.ID_ET = e2.ID_ET WHERE (e1.ID_ET LIKE '15%') order by nom_et ">
   
     
</asp:SqlDataSource>
 
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
        ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" 
        SelectCommand="select count(*) from esp_recu where etat='V' and id_et like '15%'">
    </asp:SqlDataSource>
   <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
        ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" 
        SelectCommand="select count(*) from esp_recu where  id_et like '15%' ">
    </asp:SqlDataSource>
    </asp:Content>