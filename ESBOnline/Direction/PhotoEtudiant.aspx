<%@ Page Title="" Language="C#" MasterPageFile="~/Direction/Site2.Master" AutoEventWireup="true" CodeBehind="PhotoEtudiant.aspx.cs" Inherits="ESPOnline.Direction.PhotoEtudiant" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"><h3>
    Photo d&#39;étudiant</h3><div>
    <asp:DropDownList ID="DropDownList1" runat="server" 
            DataSourceID="SqlDataSource2" DataTextField="NOM_ENS" 
            DataValueField="ID_et" AutoPostBack="True" 
            onselectedindexchanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
        &nbsp;&nbsp;
        
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="ID_et" BorderColor="White" BorderStyle="None" 
        BorderWidth="0px" ForeColor="Black" GridLines="None" ShowFooter="True" 
        ShowHeader="False">
            <Columns>
              <%--  <asp:BoundField DataField="ID_ENS" HeaderText="ID" ReadOnly="false" 
                    SortExpression="ID" />--%>
                     
                    <asp:TemplateField>  
   <HeaderTemplate>Photo d'etudiant</HeaderTemplate>  
   <ItemTemplate>  
   <img src='data:Image_Detail/jpg;base64,   <%# Eval("photo_etudiant") != System.DBNull.Value ? Convert.ToBase64String((byte[])Eval("photo_etudiant")) : string.Empty %>' alt="pas de photo" height="200px" width="300px" ReadOnly="false"/>  
   </ItemTemplate> 
    
</asp:TemplateField>
            </Columns>
        </asp:GridView>
    
        
    
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" 
            
            SelectCommand="SELECT  ID_et,photo_etudiant FROM ESP_recu where  id_et =:ID_ENS">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="ID_ENS" 
                    PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    
        <br />
    
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" 
            
            SelectCommand="SELECT ESP_RECU.id_et,esp_etudiant.NOM_ET||' '||esp_etudiant.PNOM_ET as nom_ens FROM ESP_RECU  ,esp_etudiant  where trim(esp_etudiant.id_et)=trim(ESP_RECU.id_et) and trim(ESP_RECU.id_et) like '15%' order by esp_etudiant.NOM_ET asc   ">
        </asp:SqlDataSource>
   <%-- SELECT ESP_RECU.id_et,esp_etudiant.NOM_ET||' '||esp_etudiant.PNOM_ET as nom_ens FROM ESP_RECU  ,esp_etudiant  where trim(esp_etudiant.id_et)=trim(ESP_RECU.id_et) and trim(ESP_RECU.id_et) like '15%' order by esp_etudiant.NOM_ET asc   ">--%>
               
    </div>
</asp:Content>
