<%@ Page Title="" Language="C#" MasterPageFile="~/Enseignants/Ens.Master" AutoEventWireup="true"
    CodeBehind="A1.aspx.cs" Inherits="ESPOnline.Enseignants.A1" %>

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
    <style type="text/css">
        .rgEditForm > div > table
        {
            width: 100%;
            height: 100%;
        }
        .rgEditForm
        {
            width: auto !important;
        }
        .rgEditForm > div > table > tbody > tr > td
        {
            padding: 4px 10px;
        }
        .HeaderwithBorder
        {
            border-left: 1px !important;
            border-left-style: solid !important;
            border-left-color: Red !important;
        }
    </style>
    <script type="text/javascript">
        function RowDblClick(sender, eventArgs) {
            sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
        }

        function onPopUpShowing(sender, args) {
            args.get_popUp().className += " popUpEditForm";
        }
    </script>
    <script type="text/javascript">
             //<![CDATA[
        var RadDateTimePicker1;
        var RadTimePicker1;

        function validate(sender, args) {
            var Date1 = new Date(RadDateTimePicker1.get_selectedDate());
            Date1.getDay();
            Date1.getDate();
            Date1.getFullYear();
            //            var Date2 = new Date(RadTimePicker1.get_selectedDate());
            var Date2 = new Date(2014, 10, 2, 1, 10);
            args.IsValid = true;
            if ((Date1 != null)) {
                alert("The second time value should be greater than the first!");
                args.IsValid = false;
            }
        }</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <center>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
            ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
            SelectCommand="select e2.NOM_PROJET as TITRe,e2.ID_projet,e2.NOM_PROJET,
        e2.DESCRIPTION_PROJET,e2.duree,(SELECT code_module FROM ESP_MODULE where e2.code_module=code_module ) as DESI,
        (SELECT CODE_NOME FROM CODE_NOMENCLATURE  WHERE ( CODE_STR  = '64') and  code_nome=e2.METHODOLOGIE)as METHODOLOGIE ,
         (SELECT CODE_NOME FROM CODE_NOMENCLATURE  WHERE ( CODE_STR  = '65') and  code_nome=e2.Technologies)as TECHNOLOGIES ,
         (SELECT CODE_NOME FROM CODE_NOMENCLATURE  WHERE ( CODE_STR  = '79') and code_nome=e2.type_projet) as TYPE_PROJET,
         (SELECT LIB_NOME FROM CODE_NOMENCLATURE  WHERE ( CODE_STR  = '79') and code_nome=e2.type_projet) as TYPE_PROJET2
        from  esp_projet_n e2 where   (e2.ID_ENS=:ID_ENS)  ">
            <SelectParameters>
                <asp:SessionParameter Name="ID_ENS" SessionField="ID_ENS" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
            ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
            SelectCommand="select  * from esp_ENCADREMENT where id_et=:ID_ET and id_projet=:ID_PROJET">
            <SelectParameters>
                <asp:ControlParameter ControlID="RadGrid3" Name="ID_PROJET" PropertyName="SelectedValue"
                    Type="String"></asp:ControlParameter>
                <asp:ControlParameter ControlID="RadGrid3" Name="ID_ET" PropertyName="SelectedValue"
                    Type="String"></asp:ControlParameter>
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
            ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
            SelectCommand="select NOM_ET||' '||PNOM_ET as NOM, e1.id_projet,e1.id_et,e2.classe_courante_et, e1.date_saisie from esp_projet_etudiant e1,esp_etudiant e2 where id_projet=: ID_PROJET and e1.id_et=e2.id_et and etat='A'">
            <SelectParameters>
                <asp:ControlParameter ControlID="RadGrid1" Name="ID_PROJET" PropertyName="SelectedValue"
                    Type="String"></asp:ControlParameter>
            </SelectParameters>
        </asp:SqlDataSource>
        <%-- <telerik:RadSkinManager ID="QsfSkinManager" runat="server" ShowChooser="true" />
    <telerik:RadFormDecorator ID="QsfFromDecorator" runat="server" DecoratedControls="All" EnableRoundedCorners="false" />--%>
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
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <%--  <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
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
        <asp:Label ID="Label3" runat="server" Text="Encadrement 2015/2016" 
            Font-Bold="True" Font-Size="X-Large" ForeColor="#CC0000"></asp:Label>
        <%-- <asp:RadioButtonList runat="server" ID="RadioButtonList1" AutoPostBack="true" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
        <asp:ListItem Text="EditForms" Value="EditForms" Selected="True"></asp:ListItem>
        <asp:ListItem Text="PopUp" Value="PopUp"></asp:ListItem>
    </asp:RadioButtonList>--%>
        <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="True" ShowFooter="true"
            OnPreRender="RadGrid1_PreRender" Width="95%" BorderColor="#800000" AllowSorting="True"
            AutoGenerateColumns="False" ShowStatusBar="true" OnInsertCommand="RadGrid2_InsertCommand"
            OnUpdateCommand="RadGrid1_UpdateCommand" PageSize="2" DataSourceID="SqlDataSource1">
            <%--OnInsertCommand="RadGrid1_InsertCommand" --%>
            <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
                <Selecting AllowRowSelect="true"></Selecting>
            </ClientSettings>
            <MasterTableView CommandItemDisplay="Top" DataKeyNames="ID_PROJET">
                <NoRecordsTemplate>
                    Aucun enregistrement à afficher!
                </NoRecordsTemplate>
                <CommandItemSettings AddNewRecordText="Ajouter Nouveau projet"></CommandItemSettings>
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
                    <telerik:GridBoundColumn DataField="ID_PROJET" Visible="false" FilterControlAltText="Filter TITRE column"
                        HeaderText="ID_PROJET">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ID_ET" Visible="false" FilterControlAltText="Filter TITRE column"
                        HeaderText="ID_ET">
                    </telerik:GridBoundColumn>
                    <%--<telerik:GridBoundColumn UniqueName="DATE_ENC" HeaderText="Date Encadrement" DataField="DATE_ENC"/>--%>
                    <telerik:GridBoundColumn DataField="METHODOLOGIE" HeaderText="METHODOLOGIE" SortExpression="METHODOLOGIE"
                        UniqueName="METHODOLOGIE" Visible="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="TITRE" FilterControlAltText="Filter TITRE column"
                        HeaderText="TITRE" ReadOnly="True" SortExpression="TITRE" UniqueName="TITRE">
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
                <EditFormSettings UserControlName="Addproj.ascx" EditFormType="WebUserControl">
                    <EditColumn UniqueName="EditCommandColumn1">
                    </EditColumn>
                </EditFormSettings>
            </MasterTableView>
            <ClientSettings>
                <ClientEvents OnRowDblClick="RowDblClick" OnPopUpShowing="onPopUpShowing" />
            </ClientSettings>
        </telerik:RadGrid>
        <br />
        <telerik:RadGrid ID="RadGrid3" ShowStatusBar="True" runat="server" OnSelectedIndexChanged="test" 
            AllowPaging="True" Width="95%" OnPreRender="RadGrid1_PreRender" ShowFooter="True"
            PageSize="5" DataSourceID="SqlDataSource3" AutoGenerateColumns="False" OnInsertCommand="RadGrid3_InsertCommand"
            CellSpacing="0" GridLines="None">
            <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
                <Selecting AllowRowSelect="true"></Selecting>
            </ClientSettings>
            <MasterTableView Width="100%" CommandItemDisplay="Top" DataKeyNames="ID_PROJET,ID_ET"
                DataSourceID="SqlDataSource3">
                <NoRecordsTemplate>
                    Aucun enregistrement à afficher!
                </NoRecordsTemplate>
                <CommandItemSettings ExportToPdfText="Export to PDF" AddNewRecordText="Affecter un projet a un etudiant">
                </CommandItemSettings>
                <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                </RowIndicatorColumn>
                <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                </ExpandCollapseColumn>
                <Columns>
                    <telerik:GridBoundColumn DataField="ID_PROJET" HeaderText="ID_PROJET" SortExpression="ID_PROJET"
                        UniqueName="ID_PROJET" Visible="false" FilterControlAltText="Filter ID_PROJET column" />
                    <telerik:GridBoundColumn DataField="NOM" HeaderText="NOM" SortExpression="NOM" UniqueName="NOM"
                        FilterControlAltText="Filter NOM column" ReadOnly="True" />
                    <telerik:GridBoundColumn DataField="CLASSE_COURANTE_ET" HeaderText="CLASSE" SortExpression="CLASSE_COURANTE_ET"
                        UniqueName="CLASSE_COURANTE_ET" FilterControlAltText="Filter CLASSE_COURANTE_ET column"
                        ReadOnly="True" />
                    <telerik:GridBoundColumn DataField="DATE_SAISIE" HeaderText="DATE SAISIE" SortExpression="DATE_SAISIE"
                        UniqueName="DATE_SAISIE" FilterControlAltText="Filter DATE_SAISIE column" ReadOnly="True">
                    </telerik:GridBoundColumn>
                    <%--<telerik:GridTemplateColumn HeaderText="Details" ColumnGroupName="BookingInformation"
                            AllowFiltering="false">
                            <ItemTemplate>
                                <asp:LinkButton ID="BookButton" runat="server" Text="Details" OnClientClick='<%# String.Format("openConfirmationWindow({0}); return false;", Eval("ID_PROJET")) %>'
                                    CssClass="bookNowLink" />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>--%>
                    <telerik:GridBoundColumn DataField="ID_ET" FilterControlAltText="Filter ID_ET column"
                        HeaderText="ID_ET" Visible="true" SortExpression="ID_ET" UniqueName="ID_ET">
                    </telerik:GridBoundColumn>
                </Columns>
                <EditFormSettings UserControlName="AffectProjetetudiant.ascx" EditFormType="WebUserControl">
                    <%-- <EditColumn UniqueName="EditCommandColumn1">
                </EditColumn>--%>
                    <EditColumn UniqueName="EditCommandColumn1" FilterControlAltText="Filter EditCommandColumn1 column">
                    </EditColumn>
                </EditFormSettings>
            </MasterTableView>
            <%--<ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
            <Selecting AllowRowSelect="true"></Selecting>
        </ClientSettings>--%>
            <PagerStyle Mode="NextPrevAndNumeric"></PagerStyle>
            <FilterMenu EnableImageSprites="False">
            </FilterMenu>
        </telerik:RadGrid>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Seances d'Encadrements:" Visible="false"></asp:Label>
        <br />
        <telerik:RadGrid ID="RadGrid2" ShowStatusBar="True" runat="server" AllowPaging="True"
            Width="95%" OnPreRender="RadGrid1_PreRender" ShowFooter="true" OnUpdateCommand="RadGrid2_UpdateCommand"
            PageSize="5" AutoGenerateColumns="False" OnNeedDataSource="RadGrid2_NeedDataSource"
            Visible="false" OnInsertCommand="RadGrid1_InsertCommand">
            <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
                <Selecting AllowRowSelect="true"></Selecting>
            </ClientSettings>
            <MasterTableView Width="100%" CommandItemDisplay="Top" DataKeyNames="ID_PROJET,ID_ET">
                <NoRecordsTemplate>
                    Aucun enregistrement à afficher!
                </NoRecordsTemplate>
                <CommandItemSettings ExportToPdfText="Export to PDF" AddNewRecordText="Ajouter séance d'encadrement">
                </CommandItemSettings>
                <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                </RowIndicatorColumn>
                <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                </ExpandCollapseColumn>
                <Columns>
                    <%--  <telerik:GridBoundColumn DataField="ID_PROJET" HeaderText="ID_PROJET" 
                    SortExpression="ID_PROJET" UniqueName="ID_PROJET" VISIBLE="false"
                    FilterControlAltText="Filter ID_PROJET column">
                    
                </telerik:GridBoundColumn>--%>
                    <telerik:GridBoundColumn UniqueName="DATE_ENC" HeaderText="Prochaine séance" DataField="DATE_ENC"
                        DataFormatString="{0:d}" />
                    <telerik:GridBoundColumn DataField="HEURE_DEB" HeaderText="HEURE_DEB" SortExpression="HEURE_DEB"
                        UniqueName="HEURE_DEB" />
                    <telerik:GridDateTimeColumn DataField="HEURE_FIN" DataFormatString="{0:HH:mm:ss}"
                        FilterControlAltText="Filter OrderDate column" HeaderText="Heure Fin" UniqueName="HEURE_FIN"
                        DataType="System.DateTime" PickerType="TimePicker">
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
                <EditFormSettings UserControlName="Encadrementdet.ascx" EditFormType="WebUserControl">
                    <%-- <EditColumn UniqueName="EditCommandColumn1">
                </EditColumn>--%>
                </EditFormSettings>
            </MasterTableView>
            <%--<ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
            <Selecting AllowRowSelect="true"></Selecting>
        </ClientSettings>--%>
            <PagerStyle Mode="NextPrevAndNumeric"></PagerStyle>
            <FilterMenu EnableImageSprites="False">
            </FilterMenu>
        </telerik:RadGrid>
    </center>
</asp:Content>
