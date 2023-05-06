<%@ Page Title="" Language="C#" MasterPageFile="~/Etudiants/Eol.Master" AutoEventWireup="true" CodeBehind="SuiviEncadrement.aspx.cs" Inherits="ESPOnline.Etudiants.SuiviEncadrement" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="../Contents/Scripts/bootstrap-datetimepicker.js" type="text/javascript"></script>
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
 
      
    <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
    <%--<telerik:RadSkinManager ID="QsfSkinManager" runat="server" ShowChooser="true" />--%>
    <telerik:RadFormDecorator ID="QsfFromDecorator" runat="server" DecoratedControls="All" EnableRoundedCorners="false" />
    
    
     
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Liste des projets" 
        Font-Size="X-Large" ForeColor="Red"></asp:Label>
 
       <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="All" EnableRoundedCorners="false" />
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
       <%-- <script type="text/javascript">
            function RowDblClick(sender, eventArgs) {
                sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
            }

            function onPopUpShowing(sender, args) {
                args.get_popUp().className += " popUpEditForm";
            }
             </script>--%>
        
    </telerik:RadCodeBlock>
    <%--<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadGrid1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>--%>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
        
    </telerik:RadAjaxLoadingPanel>
    
   <%-- <asp:RadioButtonList runat="server" ID="RadioButtonList1" AutoPostBack="true" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
        <asp:ListItem Text="EditForms" Value="EditForms" Selected="True"></asp:ListItem>
        <asp:ListItem Text="PopUp" Value="PopUp"></asp:ListItem>
    </asp:RadioButtonList>--%>
    <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="True" ShowFooter="true"   Width="95%" BorderColor="#800000" 
        AllowSorting="True" AutoGenerateColumns="False" ShowStatusBar="true"   PageSize="2" OnPreRender="Page_PreRender"
         DataSourceID="SqlDataSource1" 
        ><%--OnInsertCommand="RadGrid1_InsertCommand" --%>
         <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
            <Selecting AllowRowSelect="true"></Selecting>
        </ClientSettings>
        <MasterTableView     DataKeyNames="ID_projet">
        <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>
       <NoRecordsTemplate>
        Aucun enregistrement à afficher!
    </NoRecordsTemplate>
<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>
           <%-- <EditFormSettings>
                <PopUpSettings Modal="true" />
            </EditFormSettings>--%>
            <Columns>
             <telerik:GridEditCommandColumn UniqueName="EditCommandColumn" EditText="Detail">
                </telerik:GridEditCommandColumn>
             <telerik:GridBoundColumn DataField="ID_PROJET" Visible="false"
                    FilterControlAltText="Filter TITRE column" HeaderText="ID_PROJET"  ></telerik:GridBoundColumn>
            <%--<telerik:GridBoundColumn UniqueName="DATE_ENC" HeaderText="Date Encadrement" DataField="DATE_ENC"/>--%>
                <telerik:GridBoundColumn DataField="NOM_PROJET" 
                    HeaderText="TITRE" 
                    SortExpression="NOM_PROJET" UniqueName="NOM_PROJET">
                </telerik:GridBoundColumn>
                  <telerik:GridBoundColumn DataField="METHODOLOGIE" 
                    HeaderText="METHODOLOGIE" 
                    SortExpression="METHODOLOGIE" UniqueName="METHODOLOGIE" Visible="false">
                </telerik:GridBoundColumn>
                  <telerik:GridBoundColumn DataField="NOM_ENS" 
                    HeaderText="ENSEIGNANT" 
                    SortExpression="NOM_ENS" UniqueName="NOM_ENS" >
                </telerik:GridBoundColumn>
                
                 <telerik:GridBoundColumn DataField="METHODOLOGIE" 
                    HeaderText="METHODOLOGIE" 
                    SortExpression="METHODOLOGIE" UniqueName="METHODOLOGIE" Visible="false">
                </telerik:GridBoundColumn>
                
              
       <%--    <telerik:GridTemplateColumn HeaderText="Details" ColumnGroupName="BookingInformation"
                            AllowFiltering="false">
                            <ItemTemplate>
                                <asp:LinkButton ID="BookButton" runat="server" Text="Details" OnClientClick='<%# String.Format("openConfirmationWindow({0}); return false;", Eval("ID_PROJET")) %>'
                                    CssClass="bookNowLink" />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>--%>
                    
                     
            </Columns>
           <%--   UserControlName="Addproj.ascx" EditFormType="WebUserControl"--%>
            <EditFormSettings  UserControlName="DetailProjet.ascx" EditFormType="WebUserControl">
                <EditColumn UniqueName="EditCommandColumn1" >
                </EditColumn>
            </EditFormSettings>
        </MasterTableView>
        <%-- <ClientSettings>
            <ClientEvents OnRowDblClick="RowDblClick" OnPopUpShowing="onPopUpShowing"  />
        </ClientSettings>--%>
    </telerik:RadGrid>
      <br />
       <b> <asp:Label ID="Label4" runat="server" Text="Seances d'Encadrements:"></asp:Label></b>
    <br />
    <telerik:RadGrid ID="RadGrid2" ShowStatusBar="True" runat="server" AllowPaging="True" WIDTH="95%"   ShowFooter="true"  
        PageSize="5" DataSourceID="SqlDataSource2" AutoGenerateColumns="False"    >
        <MasterTableView Width="100%"   DataKeyNames="ID_PROJET"
            DataSourceID="SqlDataSource2"> 
            <NoRecordsTemplate>
        Aucun enregistrement à afficher!
    </NoRecordsTemplate>
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings> 
<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>
            <Columns>
               
              <%--  <telerik:GridBoundColumn DataField="ID_PROJET" HeaderText="ID_PROJET" 
                    SortExpression="ID_PROJET" UniqueName="ID_PROJET" VISIBLE="false"
                    FilterControlAltText="Filter ID_PROJET column">
                    
                </telerik:GridBoundColumn>--%>
                <telerik:GridBoundColumn UniqueName="DATE_ENC" HeaderText="Prochain encadrement" DataField="DATE_ENC"
                    DataFormatString="{0:d}"/>
                 <telerik:GridBoundColumn DataField="HEURE_DEB" HeaderText="HEURE_DEB" 
                    SortExpression="HEURE_DEB" UniqueName="HEURE_DEB" 
                    />
                    <telerik:GridDateTimeColumn DataField="HEURE_FIN" DataFormatString="{0:HH:mm:ss}" FilterControlAltText="Filter OrderDate column" HeaderText="Heure Fin" UniqueName="HEURE_FIN" DataType="System.DateTime" PickerType="TimePicker" > 
</telerik:GridDateTimeColumn>
 <%--<telerik:GridTemplateColumn HeaderText="Details" ColumnGroupName="BookingInformation"
                            AllowFiltering="false">
                            <ItemTemplate>
                                <asp:LinkButton ID="BookButton" runat="server" Text="Details" OnClientClick='<%# String.Format("openConfirmationWindow({0}); return false;", Eval("ID_PROJET")) %>'
                                    CssClass="bookNowLink" />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>--%>
                         <telerik:GridEditCommandColumn UniqueName="EditCommandColumn" EditText="Details">
                </telerik:GridEditCommandColumn>
            </Columns>

<EditFormSettings UserControlName="DetailEncadrement.ascx" EditFormType="WebUserControl">
               <%-- <EditColumn UniqueName="EditCommandColumn1">
                </EditColumn>--%>
            </EditFormSettings>
        </MasterTableView>
        <%--<ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
            <Selecting AllowRowSelect="true"></Selecting>
        </ClientSettings>--%>
        <PagerStyle Mode="NextPrevAndNumeric"></PagerStyle>

<FilterMenu EnableImageSprites="False"></FilterMenu>
                                </telerik:RadGrid>
   </center>
     <asp:SqlDataSource 
                ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
                ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" 
                SelectCommand="select e1.*,(select nom_ens from esp_enseignant where e1.id_ens=id_ens) as nom_ens,(SELECT LIB_NOME FROM CODE_NOMENCLATURE  WHERE ( CODE_STR  = '79') and code_nome=e1.type_projet) as TYPE_PROJET2 from esp_projet_n e1,esp_projet_etudiant e2  WHERE  e1.id_projet=e2.id_projet   and  ID_et= :ID_ET">
                 <SelectParameters>
                          <asp:SessionParameter Name="ID_ET" SessionField="ID_ET" Type="String" />
                          
                      
                     
        </SelectParameters></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2"   runat="server" 
        ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
        ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" 
        SelectCommand=" select (Select lib_nome from CODE_NOMENCLATURE  WHERE ( CODE_STR  = '80') and  code_nome=e2.AV_ANG)as LANG,(Select lib_nome from CODE_NOMENCLATURE  WHERE ( CODE_STR  = '80') and  code_nome=e2.AV_FR)as LFR,(SELECT CODE_NOME FROM CODE_NOMENCLATURE  WHERE ( CODE_STR  = '80') and  code_nome=e2.AV_ANG)as ANG ,(SELECT CODE_NOME FROM CODE_NOMENCLATURE  WHERE ( CODE_STR  = '80') and  code_nome=e2.AV_FR)as FR ,
DATE_ENC,Heure_deb,heure_fin,av_tech,av_cc,av_rapport,REMARQUE_OBS,TRAVAUX_DEMANDE,id_projet,OBS_RAPPORT,OBS_ANGLAIS,OBS_TECH,OBS_FRANCAIS,OBS_CC  FROM ESP_ENCADREMENT e2  where id_projet=: ID_PROJET and id_et=:ID_ET">
        <SelectParameters>
            <asp:ControlParameter ControlID="RadGrid1"  Name="ID_PROJET"
                PropertyName="SelectedValue" Type="String">
                 
                          </asp:ControlParameter>
                       <asp:SessionParameter Name="ID_ET" SessionField="ID_ET" Type="String" />   
        </SelectParameters>
    </asp:SqlDataSource>
    
 </center>
 
</asp:Content>
