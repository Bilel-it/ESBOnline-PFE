<%@ Page Title="" Language="C#" MasterPageFile="~/EnseignantsCUP/Cup.Master" AutoEventWireup="true" CodeBehind="NOTE1415.aspx.cs" Inherits="ESPOnline.EnseignantsCUP.NOTE1415" %>
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
    <script type="text/javascript">
        function RowDblClick(sender, eventArgs) {
            sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
        }

        function onPopUpShowing(sender, args) {
            args.get_popUp().className += " popUpEditForm";
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
            ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
            SelectCommand="select distinct code_cl from ESP_V_NOTE_ENS where   (ID_ENS=:ID_ENS)  ">
            <SelectParameters>
                <asp:SessionParameter Name="ID_ENS" SessionField="ID_ENS" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
     <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
            ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
            SelectCommand="select distinct code_module,designation,code_cl from ESP_V_NOTE_ENS where   code_cl=:CODE_CL AND iD_ens=:ID_ENS  ">
            <SelectParameters>
             <asp:ControlParameter ControlID="RadGrid1"   Name="CODE_CL"
                PropertyName="SelectedValue" Type="String"></asp:ControlParameter>
                 <asp:SessionParameter Name="ID_ENS" SessionField="ID_ENS" Type="String" /></SelectParameters>

        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
            ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
            SelectCommand="select nom_et from ESP_V_NOTE_ENS where   code_cl=:CODE_CL AND code_module=:code_module  ">
            <SelectParameters>
             <asp:ControlParameter ControlID="RadGrid2"   Name="CODE_CL"
                PropertyName="SelectedValue" Type="String">
                </asp:ControlParameter>
                <asp:ControlParameter ControlID="RadGrid2"   Name="CODE_MODULE"
                PropertyName="SelectedValue" Type="String"/>
               </SelectParameters>

        </asp:SqlDataSource>
        <center>
    <asp:Label ID="Label1" runat="server" Text="NOTES 14/15" Font-Size="XX-Large" 
                ForeColor="#CC0000"></asp:Label></center>
       <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
        </telerik:RadAjaxLoadingPanel>
        <br />
        <center>
          <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="True"    OnSelectedIndexChanged="test2" 
                ShowFooter="True"  DataSourceID="SqlDataSource1"
             Width="95%" BorderColor="Maroon" AllowSorting="True"
            AutoGenerateColumns="False" ShowStatusBar="True" 
              PageSize="2" CellSpacing="0" GridLines="None" >
          
            <ClientSettings>
                <ClientEvents OnRowDblClick="RowDblClick" OnPopUpShowing="onPopUpShowing" />
            </ClientSettings>
            <ClientSettings AllowKeyboardNavigation="true"  EnablePostBackOnRowClick="true">
                <Selecting AllowRowSelect="true"></Selecting>

<ClientEvents OnRowDblClick="RowDblClick" OnPopUpShowing="onPopUpShowing"></ClientEvents>
            </ClientSettings>
            <MasterTableView  DataKeyNames="CODE_CL">
               
                <NoRecordsTemplate>
                    Aucun enregistrement à afficher!
                </NoRecordsTemplate>
              
                <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                </RowIndicatorColumn>
                <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                </ExpandCollapseColumn>
                <Columns>
                    <telerik:GridBoundColumn DataField="CODE_CL" FilterControlAltText="Filter CODE_CL column"
                        HeaderText="Classes" ReadOnly="True" SortExpression="CODE_CL" 
                        UniqueName="CODE_CL">
                    </telerik:GridBoundColumn>
                   
                </Columns>
                <EditFormSettings>
<EditColumn UniqueName="EditCommandColumn1" FilterControlAltText="Filter EditCommandColumn1 column"></EditColumn>

                    <PopUpSettings Modal="true" />
                </EditFormSettings>
            </MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>
        </telerik:RadGrid>
        <br />

        <telerik:RadGrid ID="RadGrid2" runat="server" AllowPaging="True"  OnSelectedIndexChanged="test" 
                ShowFooter="True"  DataSourceID="SqlDataSource2"
             Width="95%" BorderColor="Maroon" AllowSorting="True"
            AutoGenerateColumns="False" ShowStatusBar="True" 
              PageSize="2" CellSpacing="0" GridLines="None" >
            
            <ClientSettings>
<Selecting AllowRowSelect="True"></Selecting>

                <ClientEvents OnRowDblClick="RowDblClick" OnPopUpShowing="onPopUpShowing" />
            </ClientSettings>
            <ClientSettings AllowKeyboardNavigation="true"  EnablePostBackOnRowClick="true">
                <Selecting AllowRowSelect="true"></Selecting>

<ClientEvents OnRowDblClick="RowDblClick" OnPopUpShowing="onPopUpShowing"></ClientEvents>
            </ClientSettings>
            <MasterTableView  DataKeyNames="CODE_CL,CODE_MODULE">
                
               
                <NoRecordsTemplate>
                    Aucun enregistrement à afficher!
                </NoRecordsTemplate>
              
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

                <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                </RowIndicatorColumn>
                <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                </ExpandCollapseColumn>
                <Columns>
                    <telerik:GridBoundColumn DataField="CODE_MODULE" FilterControlAltText="Filter CODE_MODULE column"
                        HeaderText="CODE_MODULE" ReadOnly="True" SortExpression="CODE_MODULE" 
                        UniqueName="CODE_MODULE">
                    </telerik:GridBoundColumn>
                   
                    <telerik:GridBoundColumn DataField="DESIGNATION" 
                        FilterControlAltText="Filter DESIGNATION column" HeaderText="DESIGNATION" 
                        ReadOnly="True" SortExpression="DESIGNATION" UniqueName="DESIGNATION">
                    </telerik:GridBoundColumn>
                   
                    <telerik:GridBoundColumn DataField="CODE_CL" 
                        FilterControlAltText="Filter CODE_CL column" HeaderText="Classes" 
                        ReadOnly="True" SortExpression="CODE_CL" UniqueName="CODE_CL">
                    </telerik:GridBoundColumn>
                   
                </Columns>
                <EditFormSettings>
<EditColumn UniqueName="EditCommandColumn1" FilterControlAltText="Filter EditCommandColumn1 column"></EditColumn>

                    <PopUpSettings Modal="true" />
                </EditFormSettings>
            </MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>
        </telerik:RadGrid>
        <br />
           <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="../Contents/Img/Excel_ExcelML.png"
            OnClick="ImageButton_Click" AlternateText="ExcelML" Height="21px" Visible="false"
                Width="53px" />
        <br />
        <telerik:RadGrid ID="RadGrid3" runat="server" AllowPaging="True"   OnExcelMLWorkBookCreated="RadGrid1_ExcelMLWorkBookCreated" 
                ShowFooter="True"  OnNeedDataSource="RadGrid3_NeedDataSource" Visible="false"
             Width="95%" BorderColor="Maroon" AllowSorting="True"
            AutoGenerateColumns="False" ShowStatusBar="True" 
              PageSize="5" CellSpacing="0" GridLines="None" >
          
            <ClientSettings>
<Selecting AllowRowSelect="True"></Selecting>

                <ClientEvents OnRowDblClick="RowDblClick" OnPopUpShowing="onPopUpShowing" />
            </ClientSettings>
            <ClientSettings AllowKeyboardNavigation="true"  EnablePostBackOnRowClick="true">
                <Selecting AllowRowSelect="true"></Selecting>

<ClientEvents OnRowDblClick="RowDblClick" OnPopUpShowing="onPopUpShowing"></ClientEvents>
            </ClientSettings>
            <MasterTableView  >
               
                <NoRecordsTemplate>
                    Aucun enregistrement à afficher!
                </NoRecordsTemplate>
              
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

                <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                </RowIndicatorColumn>
                <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                </ExpandCollapseColumn>
                <Columns>
                    <telerik:GridBoundColumn DataField="NOM_ET" FilterControlAltText="Filter NOM_ET column"
                        HeaderText="NOM_ET" SortExpression="NOM_ET" 
                        UniqueName="NOM_ET">
                    </telerik:GridBoundColumn>
                      <telerik:GridBoundColumn DataField="PNOM_ET" FilterControlAltText="Filter PNOM_ET column"
                        HeaderText="PNOM_ET" SortExpression="PNOM_ET" 
                        UniqueName="PNOM_ET">
                    </telerik:GridBoundColumn>
                     <telerik:GridBoundColumn DataField="NOTE_CC" FilterControlAltText="Filter NOTE_CC column"
                        HeaderText="NOTE_CC" SortExpression="NOTE_CC" 
                        UniqueName="NOTE_CC">
                    </telerik:GridBoundColumn>
                     
                 
                     <telerik:GridBoundColumn DataField="NOTE_TP" FilterControlAltText="Filter NOTE_TP column"
                        HeaderText="NOTE_TP" SortExpression="NOTE_TP" 
                        UniqueName="NOTE_TP">
                    </telerik:GridBoundColumn>
                      <telerik:GridBoundColumn DataField="NOTE_EXAM" FilterControlAltText="Filter NOTE_EXAM column"
                        HeaderText="NOTE_EXAM" SortExpression="NOTE_EXAM" 
                        UniqueName="NOTE_EXAM">
                    </telerik:GridBoundColumn>
                </Columns>
                <EditFormSettings>
<EditColumn UniqueName="EditCommandColumn1" FilterControlAltText="Filter EditCommandColumn1 column"></EditColumn>

                    <PopUpSettings Modal="true" />
                </EditFormSettings>
            </MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>
        </telerik:RadGrid>
        </center>
</asp:Content>
