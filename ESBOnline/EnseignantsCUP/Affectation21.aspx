<%@ Page Title="" Language="C#" MasterPageFile="~/EnseignantsCUP/Cup.Master" AutoEventWireup="true" CodeBehind="Affectation21.aspx.cs" Inherits="ESPOnline.EnseignantsCUP.Affectation2" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <script src="../Contents/jquery.js" type="text/javascript"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
  <script src="../Contents/Scripts/ScrollableGridPlugin_ASP.NetAJAX_2.0.js" type="text/javascript"></script>
    <link href="../Contents/Css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />
    <script src="../Contents/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="../Contents/Scripts/bootstrap.js" type="text/javascript"></script>
    <script src="../Contents/CSS3/js/bootstrap.min.js" type="text/javascript"></script>
 <script type="text/javascript" src="../Contents/Scripts/JScript1.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center style="font-size: x-large">
      <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
        </telerik:RadAjaxLoadingPanel>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager><br />Affectation 2015/2016
        <br />
 <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="True" ShowFooter="True"  OnItemCreated="RadGrid1_ItemCreated"
             Width="95%" BorderColor="Maroon" AllowSorting="True" AllowFilteringByColumn="True" 
            AutoGenerateColumns="False" ShowStatusBar="True" 
            PageSize="3" 
        DataSourceID="SqlDataSource1" CellSpacing="0" GridLines="None">
           
           <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
                <Selecting AllowRowSelect="true"></Selecting>
            </ClientSettings>
                
 
            <MasterTableView   DataKeyNames="CODE_MODULE">
                <NoRecordsTemplate>
                    Aucun enregistrement à afficher!
                </NoRecordsTemplate>
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

                <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                </RowIndicatorColumn>
                <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                </ExpandCollapseColumn>
                
                <Columns>
                   
                   
                    <telerik:GridBoundColumn DataField="CODE_MODULE" FilterControlWidth="110px" ReadOnly="True"  

                        FilterControlAltText="Filter CODE_MODULE column" HeaderText="CODE_MODULE" 
                          SortExpression="CODE_MODULE" UniqueName="CODE_MODULE">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="DESIGNATION" FilterControlWidth="110px" ReadOnly="True"
                        FilterControlAltText="Filter DESIGNATION column" HeaderText="DESIGNATION" 
                        SortExpression="DESIGNATION" UniqueName="DESIGNATION"  >
                    </telerik:GridBoundColumn>
                   
                  <%--  <telerik:GridBoundColumn DataField="NUM_SEMESTRE"  
                        FilterControlAltText="Filter NUM_SEMESTRE column" HeaderText="NUM_SEMESTRE" FilterControlWidth="110px" ReadOnly="True"
                        SortExpression="NUM_SEMESTRE" UniqueName="NUM_SEMESTRE" AutoPostBackOnFilter="false" CurrentFilterFunction="Contains">
                    </telerik:GridBoundColumn>--%>
                </Columns>
               
                 
<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
               
                 
            </MasterTableView>
            

<FilterMenu EnableImageSprites="False"></FilterMenu>
        </telerik:RadGrid><br />
        <telerik:RadGrid ID="RadGrid2" ShowStatusBar="True" runat="server"  OnUpdateCommand="RadGrid2_UpdateCommand" OnItemCreated="RadGrid2_ItemCreated"
            AllowPaging="True" Width="95%" ShowFooter="True" AllowFilteringByColumn="True"
            PageSize="5" DataSourceID="SqlDataSource2" AutoGenerateColumns="False" 
            CellSpacing="0" GridLines="None" 
           >
            <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
                <Selecting AllowRowSelect="true"></Selecting>
            </ClientSettings>
            <MasterTableView Width="100%"
                DataSourceID="SqlDataSource2"><NoRecordsTemplate>
                    Aucun enregistrement à afficher!
                </NoRecordsTemplate>
                <CommandItemSettings ExportToPdfText="Export to PDF" >
                </CommandItemSettings>
                <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                </RowIndicatorColumn>
                <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                </ExpandCollapseColumn>
                <Columns>
                    
                  <telerik:GridEditCommandColumn UniqueName="EditCommandColumn" EditText="Modifier">
                    </telerik:GridEditCommandColumn>
                    <telerik:GridBoundColumn DataField="CODE_CL" 
                        FilterControlAltText="Filter CODE_CL column" HeaderText="CODE_CL" FilterControlWidth="110px" ReadOnly="True"
                        SortExpression="CODE_CL" UniqueName="CODE_CL">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="NOM_ENS" 
                        FilterControlAltText="Filter NOM_ENS column" HeaderText="NOM_ENS" FilterControlWidth="110px" ReadOnly="True"
                        SortExpression="NOM_ENS" UniqueName="NOM_ENS">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="NB_HEURES"   
                        FilterControlAltText="Filter NB_HEURES column" HeaderText="NB_HEURES" FilterControlWidth="110px" ReadOnly="True"
                        SortExpression="NB_HEURES" UniqueName="NB_HEURES">
                    </telerik:GridBoundColumn>
                      <telerik:GridBoundColumn DataField="CHARGE_P1"  
                        FilterControlAltText="Filter CHARGE_P1 column" HeaderText="CHARGE_P1" FilterControlWidth="110px" ReadOnly="True"
                        SortExpression="CHARGE_P1" UniqueName="CHARGE_P1">
                    </telerik:GridBoundColumn>
                     <telerik:GridBoundColumn DataField="CHARGE_P2"  
                        FilterControlAltText="Filter CHARGE_P2 column" HeaderText="CHARGE_P2" FilterControlWidth="110px" ReadOnly="True"
                        SortExpression="CHARGE_P2" UniqueName="CHARGE_P2">
                    </telerik:GridBoundColumn>
                     <telerik:GridBoundColumn DataField="NUM_SEMESTRE"  
                        FilterControlAltText="Filter NUM_SEMESTRE column" HeaderText="SEMESTRE" FilterControlWidth="110px" ReadOnly="True"
                        SortExpression="NUM_SEMESTRE" UniqueName="NUM_SEMESTRE" AutoPostBackOnFilter="false" CurrentFilterFunction="Contains">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="LIB_NOME"  
                        FilterControlAltText="Filter LIB_NOME column" HeaderText="EPREUVE" FilterControlWidth="110px" ReadOnly="True"
                        SortExpression="LIB_NOME" UniqueName="LIB_NOME" AutoPostBackOnFilter="false" CurrentFilterFunction="Contains">
                    </telerik:GridBoundColumn>
                </Columns>
                <EditFormSettings UserControlName="detaffect.ascx" EditFormType="WebUserControl">
                     <EditColumn UniqueName="EditCommandColumn1">
                </EditColumn>
                    <EditColumn UniqueName="EditCommandColumn1" FilterControlAltText="Filter EditCommandColumn1 column">
                    </EditColumn>
                </EditFormSettings>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
            </MasterTableView>
            <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
            <Selecting AllowRowSelect="true"></Selecting>
        </ClientSettings>
            <PagerStyle Mode="NextPrevAndNumeric"></PagerStyle>
            <FilterMenu EnableImageSprites="False">
            </FilterMenu>
        </telerik:RadGrid>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
            ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
            SelectCommand="select distinct e2.code_module,e2.designation from esp_module_panier_classe_saiso e1,esp_module e2 where annee_deb=2015 and up=:up  and e1.code_module=e2.code_module order by  designation ">
            <SelectParameters>
                <asp:SessionParameter Name="up" SessionField="up" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
            ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
            SelectCommand="select e1.*,e1.id_ens as iden ,e2.nom_ens,id_ens2 as idens2,id_ens3 ,id_ens4,id_ens5 ,LIB_NOME from esp_module_panier_classe_saiso e1,esp_enseignant e2,CODE_NOMENCLATURE e3 where annee_deb='2015' and trim(code_module)=:CODE_MODULEE  and e1.id_ens=e2.id_ens and e3.CODE_STR='78' and e1.type_epreuve= e3.CODE_NOME  ">
            <SelectParameters>
            <asp:ControlParameter ControlID="RadGrid1" Name="CODE_MODULEE" PropertyName="SelectedValue"
                    Type="String"></asp:ControlParameter>
                
            </SelectParameters>
        </asp:SqlDataSource> </center>
</asp:Content>
