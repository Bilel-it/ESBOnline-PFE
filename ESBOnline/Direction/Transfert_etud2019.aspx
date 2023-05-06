<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Transfert_etud2019.aspx.cs" 
Inherits="ESPOnline.Direction.Transfert_etud2019"

   MasterPageFile="~/Direction/admission/ad.Master" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
 <%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
    function RowDeselecting(rowObject) {
        eventArgs.set_cancel(true) //cancel event;
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <br />
    <center>    
        <%--<asp:TextBox ID="TextBox1" runat="server"  ></asp:TextBox>--%>
               
        <asp:Button ID="Button1" runat="server" Text="Transfert" OnClick="RadButton1_Click" />
             <asp:Button ID="Cancel1" runat="server" Text="Cancel" OnClick="chk_CheckedChanged" />
               
    </center>
    <center>

                    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
           <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
        </telerik:RadAjaxLoadingPanel>
    
                    
    
    <div>
 

    <telerik:RadGrid ID="RadGrid1" runat="server" ShowFooter="true"  AllowFilteringByColumn="True" AllowSorting="True"  
            BorderColor="Maroon"   CellSpacing="0"    GridLines="Vertical" allowmultirowselection="True" 
            AutoGenerateColumns="False" onItemDataBound="grid1" Width="100%" OnNeedDataSource="RadGrid2_NeedDataSource"
               BorderStyle="Groove" 
             >
            
       <ExportSettings HideStructureColumns="true" FileName="liste"/>
           
            <ClientSettings AllowKeyboardNavigation="true" >
               
                
<Selecting AllowRowSelect="true"></Selecting>
            </ClientSettings>
<ExportSettings FileName="liste" HideStructureColumns="True"></ExportSettings>

               <ClientSettings>
                  <ClientEvents OnRowDeselecting="RowDeselecting" />
                            <Scrolling   AllowScroll="true"  SaveScrollPosition="True"/>
                          <%--  <Resizing   AllowColumnResize="true"/> --%>                  
<Selecting AllowRowSelect="True"></Selecting>

<Scrolling AllowScroll="True" UseStaticHeaders="True"></Scrolling>

<Resizing AllowColumnResize="True"></Resizing>
                          </ClientSettings>
            <MasterTableView   datakeynames="ID_ET"><CommandItemSettings ShowAddNewRecordButton="false" />
                <NoRecordsTemplate>
                    Aucun enregistrement à afficher!
                </NoRecordsTemplate>
              

<CommandItemSettings ExportToPdfText="Export to PDF" ShowAddNewRecordButton="False"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>

                <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                </ExpandCollapseColumn>
                <EditFormSettings>
<EditColumn UniqueName="EditCommandColumn1" FilterControlAltText="Filter EditCommandColumn1 column"></EditColumn>

                    <PopUpSettings Modal="true" />

<PopUpSettings Modal="True"></PopUpSettings>
                </EditFormSettings>
                <Columns>
                <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn" AllowFiltering="false">
              <ItemTemplate>
                <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="ToggleRowSelection"
                  AutoPostBack="True" />
              </ItemTemplate>
              </telerik:GridTemplateColumn>
               <telerik:GridBoundColumn DataField="ID_ET"  AutoPostBackOnFilter="true" AllowFiltering="true" CurrentFilterFunction="Contains" ShowFilterIcon="false"
                          FilterControlAltText="Filter ID_ET column" HeaderText="ID_ET" ReadOnly="True" 
                          SortExpression="ID_ET" UniqueName="ID_ET">
                      </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="NUM_CIN_PASSEPORT"  FilterControlAltText="Filter NUM_CIN_PASSEPORT column" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" ShowFilterIcon="false"
                        HeaderText="CIN_PASSEPORT" SortExpression="NUM_CIN_PASSEPORT" 
                          UniqueName="NUM_CIN_PASSEPORT">
                         <HeaderStyle Width="150px" />
    <ItemStyle Width="150px" />
    <FooterStyle Width="150px" />
                    </telerik:GridBoundColumn>
                    
                   
                    <telerik:GridBoundColumn DataField="NOM" HeaderText="NOM" SortExpression="NOM" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" ShowFilterIcon="false"
                        UniqueName="NOM" FilterControlAltText="Filter NOM column" ReadOnly="True">
                    </telerik:GridBoundColumn>
                     
                      <telerik:GridBoundColumn DataField="NATURE_BAC" 
                          FilterControlAltText="Filter NATURE_BAC column" HeaderText="BAC" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" ShowFilterIcon="false"
                          SortExpression="NATURE_BAC" UniqueName="NATURE_BAC">
                      </telerik:GridBoundColumn>
                      
                    
                      
                      <telerik:GridBoundColumn DataField="MOY_BAC_ET" 
                          FilterControlAltText="Filter MOY_BAC_ET column" HeaderText="MOY_BAC" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" ShowFilterIcon="false"
                          SortExpression="MOY_BAC_ET" UniqueName="MOY_BAC_ET">
                      </telerik:GridBoundColumn>
                      <telerik:GridBoundColumn DataField="NIVEAU_ACCES" DataType="System.Int16" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" ShowFilterIcon="false"
                          FilterControlAltText="Filter NIVEAU_ACCES column" HeaderText="NIV" 
                          SortExpression="NIVEAU_ACCES" UniqueName="NIVEAU_ACCES">
                      </telerik:GridBoundColumn>
                      <telerik:GridBoundColumn DataField="DIPLOME_SUP_ET" 
                          FilterControlAltText="Filter DIPLOME_SUP_ET column" HeaderText="DIPLOME" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" ShowFilterIcon="false"
                          SortExpression="DIPLOME_SUP_ET" UniqueName="DIPLOME_SUP_ET">
                      </telerik:GridBoundColumn>
                      <telerik:GridBoundColumn DataField="E_MAIL_ET" 
                          FilterControlAltText="Filter E_MAIL_ET column" HeaderText="MAIL" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" ShowFilterIcon="false"
                          SortExpression="E_MAIL_ET" UniqueName="E_MAIL_ET">
                      </telerik:GridBoundColumn>
                  
                      <telerik:GridBoundColumn DataField="SPECIALITE_ESP_ET" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" ShowFilterIcon="false"
                          FilterControlAltText="Filter SPECIALITE_ESP_ET column" 
                          HeaderText="SPECIALITE" SortExpression="SPE" 
                          UniqueName="SPECIALITE_ESP_ET"></telerik:GridBoundColumn>
                          
                      
                     
                       
                      
  
                   
                </Columns>
       
                  
            </MasterTableView>
       

<SelectedItemStyle CssClass="SelectedItem"></SelectedItemStyle>


<FilterMenu EnableImageSprites="False"></FilterMenu>
        </telerik:RadGrid>
    </div><br />
                    <asp:sqldatasource runat="server"  id="ee"
        ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
        ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" 
        
   SelectCommand="SELECT  T1.num_cin_passeport, T1.NOM_ET||' '||T1.PNOM_ET nom,(case when NATURE_BAC='01' then 'MATH' when NATURE_BAC='03' then 'SC EXP' WHEN NATURE_BAC='02' 
then 'ECONOMIE' when NATURE_BAC='04' then 'TECHNIQUE'  when NATURE_BAC='35' then 'INFO' end)NATURE_BAC,SCORE_dossier,T1.SCORE_ENTRETIEN,score_final,score_francais,score_qi,score_anglais,T1.ANNEE_BAC,T1.MOY_BAC_ET,T1.NIVEAU_ACCES,T1.DIPLOME_SUP_ET,T1.E_MAIL_ET,T1.PASSWORD,(case when t1.SPECIALITE_ESP_ET='05' then 'TIC' when t1.SPECIALITE_ESP_ET='04' then 'EM' when t1.SPECIALITE_ESP_ET='03' then 'GC'  
when t1.SPECIALITE_ESP_ET='01' then 'INFO' when t1.SPECIALITE_ESP_ET='02' then 'TELECOM'   when t1.SPECIALITE_ESP_ET='06' then 'Licence en Sciences de Gestion'  when t1.SPECIALITE_ESP_ET='07'  then 'Licence en Informatique de Gestion'   when 
t1.SPECIALITE_ESP_ET='08' then 'Master en Management	Digital	et Systèmes d’Information'   when t1.SPECIALITE_ESP_ET='09' then 'Master en Marketing Digital' when t1.SPECIALITE_ESP_ET='10' then 'Master en Innovation	 Entrepreneuriat'   
end) SPECIALITE_ESP_ET ,T1.ID_ET,T1.dateentr,etab_origine, T1.TEL_ET,T1.NATIONALITE FROM   ESP_ETUDIANT t1  WHERE   id_et like '17%' and code_decision!='01' and envoi_mail!='O' order by specialite_esp_et desc ">

   
          
   
   
   </asp:sqldatasource><br />
   <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
                        ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" 
                        SelectCommand="select count(*) from esp_etudiant where id_et LIKE '17%T%'"></asp:SqlDataSource>
   </center>
</asp:Content>
