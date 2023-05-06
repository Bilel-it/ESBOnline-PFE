<%@ Page Title="" Language="C#" MasterPageFile="~/Direction/admin2.Master" AutoEventWireup="true" CodeBehind="A.aspx.cs" Inherits="ESPOnline.Direction.A" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


 <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
           <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
        </telerik:RadAjaxLoadingPanel>
    
    <div>
    <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="True" ShowFooter="True"
            Width="95%" BorderColor="Maroon" AllowSorting="True"
            AutoGenerateColumns="False" ShowStatusBar="True" 
            OnUpdateCommand="RadGrid1_UpdateCommand" PageSize="100" 
            DataSourceID="SqlDataSource1" CellSpacing="0" GridLines="None">
            <%--OnInsertCommand="RadGrid1_InsertCommand" --%>
          <%--  EnablePostBackOnRowClick="true"--%>
            <ClientSettings AllowKeyboardNavigation="true" >
                <Selecting AllowRowSelect="true"></Selecting>
            </ClientSettings>
            <MasterTableView CommandItemDisplay="Top" DataKeyNames="ID_ET"><CommandItemSettings ShowAddNewRecordButton="false" />
                <NoRecordsTemplate>
                    Aucun enregistrement à afficher!
                </NoRecordsTemplate>
               <%-- <CommandItemSettings AddNewRecordText="Ajouter Nouveau projet"></CommandItemSettings>--%>
                <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                </RowIndicatorColumn>
                <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                </ExpandCollapseColumn>
                <EditFormSettings>
                    <PopUpSettings Modal="true" />
                </EditFormSettings>
                <Columns>
                    <telerik:GridEditCommandColumn UniqueName="EditCommandColumn" EditText="Modifier">
                    </telerik:GridEditCommandColumn>
                    <telerik:GridBoundColumn DataField="code_cl"   FilterControlAltText="Filter TITRE column"
                        HeaderText="code_cl" ReadOnly="True">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ID_ET"   FilterControlAltText="Filter TITRE column"
                        HeaderText="ID_ET" ReadOnly="True">
                    </telerik:GridBoundColumn>
                    <%--<telerik:GridBoundColumn UniqueName="DATE_ENC" HeaderText="Date Encadrement" DataField="DATE_ENC"/>--%>
                    <telerik:GridBoundColumn DataField="nom_et" HeaderText="nom_et" SortExpression="nom_et"
                        UniqueName="nom_et"  ReadOnly="True">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="pnom_et" FilterControlAltText="Filter TITRE column"
                        HeaderText="pnom_et" ReadOnly="True" SortExpression="pnom_et" UniqueName="pnom_et">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="nom_arb" HeaderText="nom_arb" SortExpression="nom_et"
                        UniqueName="nom_arb"  ReadOnly="True">
                    </telerik:GridBoundColumn>
                </Columns>
                <%--   UserControlName="Addproj.ascx" EditFormType="WebUserControl"--%>
                <EditFormSettings UserControlName="ARAB.ascx" EditFormType="WebUserControl">
                    <EditColumn UniqueName="EditCommandColumn1">
                    </EditColumn>
                </EditFormSettings>
            </MasterTableView>
            <ClientSettings>
                <ClientEvents OnRowDblClick="RowDblClick" OnPopUpShowing="onPopUpShowing" />
            </ClientSettings>
        </telerik:RadGrid>
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DefaultConnectionString2 %>" 
        ProviderName="<%$ ConnectionStrings:DefaultConnectionString2.ProviderName %>" 
        SelectCommand="select t1.id_et,nom_et,pnom_et,t2.code_cl,ETAB_ORIGINE,t1.DIPLOME_SUP_ET,
LIEU_NAIS_ET,PNOM_ARB,NOM_ARB,LIEU_NAIS_ARB,NATURE_BAC_ARB,ETAB_ORIGINE_ARB,DIPLOME_SUP_ARB,(select LIB_NOME from CODE_NOMENCLATURE where code_str='02'  and code_nome=Nature_bac)Nature_bac  from esp_etudiant t1, esp_inscription t2 where t1.id_et=t2.id_et and
t2.annee_deb=2017 and code_cl not like '%-%' and code_cl not like 'MP%' order by FN_TRI_CLASSE(code_cl)">
    </asp:SqlDataSource>
  


</asp:Content>