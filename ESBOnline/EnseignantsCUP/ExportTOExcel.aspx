<%@ Page Title="" Language="C#" MasterPageFile="~/EnseignantsCUP/Cup.Master" AutoEventWireup="true" CodeBehind="ExportTOExcel.aspx.cs" Inherits="ESPOnline.EnseignantsCUP.ExportTOExcel" %>
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
    <center>
       
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager><br />
        <asp:Label ID="Label3" runat="server" 
            Text="Export affectation semestre 1 AU:2016/2016" Font-Size="X-Large" 
            ForeColor="#CC0000" Width="1055px"></asp:Label>
        <br />
        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="../Contents/Img/Excel_ExcelML.png"
            OnClick="ImageButton_Click" AlternateText="ExcelML" /> 
<telerik:RadGrid ID="RadGrid1" ShowStatusBar="True" runat="server" OnExcelMLWorkBookCreated="RadGrid1_ExcelMLWorkBookCreated"    OnItemCreated="RadGrid1_ItemCreated"
 
AllowFilteringByColumn="True"
            AllowPaging="True" Width="95%" ShowFooter="True"
            PageSize="5" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" 
            CellSpacing="0" GridLines="None"><ExportSettings HideStructureColumns="true" FileName="test">
        </ExportSettings>
            <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
                <Selecting AllowRowSelect="true"></Selecting>
            </ClientSettings>
            <MasterTableView Width="100%"
                DataSourceID="SqlDataSource1">
                  
                <CommandItemSettings ExportToPdfText="Export to PDF" >
                </CommandItemSettings>
                <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                </RowIndicatorColumn>
                <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                </ExpandCollapseColumn>
                <Columns>
                    
                    <telerik:GridBoundColumn DataField="CODE_CL" 
                        FilterControlAltText="Filter CODE_CL column" HeaderText="CODE_CL" FilterControlWidth="110px" ReadOnly="True" 
                        SortExpression="CODE_CL" UniqueName="CODE_CL">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="CODE_MODULE" 
                        FilterControlAltText="Filter CODE_MODULE column" HeaderText="CODE_MODULE" FilterControlWidth="110px" ReadOnly="True" 
                        SortExpression="CODE_MODULE" UniqueName="CODE_MODULE">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="DESIGNATION" 
                        FilterControlAltText="Filter DESIGNATION column" HeaderText="DESIGNATION" FilterControlWidth="110px"
                        SortExpression="DESIGNATION" UniqueName="DESIGNATION" ReadOnly="True">
                    </telerik:GridBoundColumn>
                      <telerik:GridBoundColumn DataField="NB_HEURES" DataType="System.Single" FilterControlWidth="110px"
                        FilterControlAltText="Filter NB_HEURES column" HeaderText="NB_HEURES" ReadOnly="True" 
                        SortExpression="NB_HEURES" UniqueName="NB_HEURES">
                    </telerik:GridBoundColumn>
                     <telerik:GridBoundColumn DataField="CHARGE_P1" DataType="System.Single" FilterControlWidth="110px"
                        FilterControlAltText="Filter CHARGE_P1 column" HeaderText="CHARGE_P1" ReadOnly="True" 
                        SortExpression="CHARGE_P1" UniqueName="CHARGE_P1">
                    </telerik:GridBoundColumn>
                    
                 
                    <telerik:GridBoundColumn DataField="CHARGE_P2" DataType="System.Single" FilterControlWidth="110px"
                        FilterControlAltText="Filter CHARGE_P2 column" HeaderText="CHARGE_P2" ReadOnly="True" 
                        SortExpression="CHARGE_P2" UniqueName="CHARGE_P2">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ENS1" FilterControlWidth="110px"
                        FilterControlAltText="Filter ENS1 column" HeaderText="ENS1" ReadOnly="True" 
                        SortExpression="ENS1" UniqueName="ENS1">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="CHARGE_ENS1_P1" DataType="System.Single" FilterControlWidth="110px" 
                        FilterControlAltText="Filter CHARGE_ENS1_P1 column" HeaderText="CHARGE_ENS1_P1" ReadOnly="True" 
                        SortExpression="CHARGE_ENS1_P1" UniqueName="CHARGE_ENS1_P1">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="CHARGE_ENS1_P2" DataType="System.Single" FilterControlWidth="110px" FilterDelay="200"  
                        FilterControlAltText="Filter CHARGE_ENS1_P2 column" HeaderText="CHARGE_ENS1_P2" ReadOnly="True" 
                        SortExpression="CHARGE_ENS1_P2" UniqueName="CHARGE_ENS1_P2">
                    </telerik:GridBoundColumn>
                  <%--  <telerik:GridBoundColumn DataField="ENS2" 
                        FilterControlAltText="Filter ENS2 column" HeaderText="ENS2" ReadOnly="True" 
                        SortExpression="ENS2" UniqueName="ENS2">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="CHARGE_ENS2_P1" DataType="System.Single" 
                        FilterControlAltText="Filter CHARGE_ENS2_P1 column" HeaderText="CHARGE_ENS2_P1" 
                        SortExpression="CHARGE_ENS2_P1" UniqueName="CHARGE_ENS2_P1">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="CHARGE_ENS2_P2" DataType="System.Single" 
                        FilterControlAltText="Filter CHARGE_ENS2_P2 column" HeaderText="CHARGE_ENS2_P2" 
                        SortExpression="CHARGE_ENS2_P2" UniqueName="CHARGE_ENS2_P2">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ENS3" 
                        FilterControlAltText="Filter ENS3 column" HeaderText="ENS3" ReadOnly="True" 
                        SortExpression="ENS3" UniqueName="ENS3">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="CHARGE_ENS3_P1" DataType="System.Single" 
                        FilterControlAltText="Filter CHARGE_ENS3_P1 column" HeaderText="CHARGE_ENS3_P1" 
                        SortExpression="CHARGE_ENS3_P1" UniqueName="CHARGE_ENS3_P1">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="CHARGE_ENS3_P2" DataType="System.Single" 
                        FilterControlAltText="Filter CHARGE_ENS3_P2 column" HeaderText="CHARGE_ENS3_P2" 
                        SortExpression="CHARGE_ENS3_P2" UniqueName="CHARGE_ENS3_P2">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ENS4" 
                        FilterControlAltText="Filter ENS4 column" HeaderText="ENS4" ReadOnly="True" 
                        SortExpression="ENS4" UniqueName="ENS4">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="CHARGE_ENS4_P1" DataType="System.Single" 
                        FilterControlAltText="Filter CHARGE_ENS4_P1 column" HeaderText="CHARGE_ENS4_P1" 
                        SortExpression="CHARGE_ENS4_P1" UniqueName="CHARGE_ENS4_P1">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="CHARGE_ENS4_P2" DataType="System.Single" 
                        FilterControlAltText="Filter CHARGE_ENS4_P2 column" HeaderText="CHARGE_ENS4_P2" 
                        SortExpression="CHARGE_ENS4_P2" UniqueName="CHARGE_ENS4_P2">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ENS5" 
                        FilterControlAltText="Filter ENS5 column" HeaderText="ENS5" ReadOnly="True" 
                        SortExpression="ENS5" UniqueName="ENS5">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="CHARGE_ENS5_P1" DataType="System.Single" 
                        FilterControlAltText="Filter CHARGE_ENS5_P1 column" HeaderText="CHARGE_ENS5_P1" 
                        SortExpression="CHARGE_ENS5_P1" UniqueName="CHARGE_ENS5_P1">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="CHARGE_ENS5_P2" DataType="System.Single" 
                        FilterControlAltText="Filter CHARGE_ENS5_P2 column" HeaderText="CHARGE_ENS5_P2" 
                        SortExpression="CHARGE_ENS5_P2" UniqueName="CHARGE_ENS5_P2">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="TYPE_EPREUVE" 
                        FilterControlAltText="Filter TYPE_EPREUVE column" HeaderText="TYPE_EPREUVE" 
                        ReadOnly="True" SortExpression="TYPE_EPREUVE" UniqueName="TYPE_EPREUVE">
                    </telerik:GridBoundColumn>--%>
                    
                 
                </Columns>
                <EditFormSettings UserControlName="Affectdet.ascx" EditFormType="WebUserControl">
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
        </telerik:RadGrid><asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
        ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" SelectCommand="SELECT   ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL, CODE_MODULE,(select Designation from ESP_MODULE where ESP_MODULE.CODE_MODULE=ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE)as designation,  NB_HEURES, CHARGE_P1,CHARGE_P2,(select ESP_ENSEIGNANT.NOM_ENS from ESP_ENSEIGNANT where ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS=ESP_ENSEIGNANT.ID_ENS)as ens1,CHARGE_ENS1_P1,CHARGE_ENS1_P2,(select ESP_ENSEIGNANT.NOM_ENS from ESP_ENSEIGNANT where ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS2=ESP_ENSEIGNANT.ID_ENS)as ens2 ,CHARGE_ENS2_P1,CHARGE_ENS2_P2 ,(select ESP_ENSEIGNANT.NOM_ENS from ESP_ENSEIGNANT where ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS3=ESP_ENSEIGNANT.ID_ENS)as ens3,CHARGE_ENS3_P1,CHARGE_ENS3_P2,(select ESP_ENSEIGNANT.NOM_ENS from ESP_ENSEIGNANT where ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS4=ESP_ENSEIGNANT.ID_ENS)as ens4,CHARGE_ENS4_P1,CHARGE_ENS4_P2, (select ESP_ENSEIGNANT.NOM_ENS from ESP_ENSEIGNANT where ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS5=ESP_ENSEIGNANT.ID_ENS)as ens5,CHARGE_ENS5_P1,CHARGE_ENS5_P2, (select lib_nome from CODE_NOMENCLATURE where CODE_NOMENCLATURE.code_nome=ESP_MODULE_PANIER_CLASSE_SAISO.TYPE_EPREUVE and  CODE_NOMENCLATURE.CODE_STR='78') as TYPE_EPREUVE FROM   ESP_MODULE_PANIER_CLASSE_SAISO WHERE ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB = 2016 and ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE in (select CODE_MODULE from esp_module where esp_module.up =: UP  )
 AND ESP_MODULE_PANIER_CLASSE_SAISO.num_semestre=1  AND ESP_MODULE_PANIER_CLASSE_SAISO.annee_deb=2016 order by DESIGNATION
">  <SelectParameters>
                            <asp:SessionParameter Name="UP" SessionField="UP" Type="String" />
                        </SelectParameters>
</asp:SqlDataSource></center>
</asp:Content>
