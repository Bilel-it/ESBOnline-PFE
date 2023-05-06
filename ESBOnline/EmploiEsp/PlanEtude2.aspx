<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlanEtude2.aspx.cs" Inherits="ESPOnline.EmploiEsp.PlanEtude2"
MasterPageFile="~/EnseignantsCUP/Cup.Master" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
    <link href="../Contents/Css/style.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center style="font-size: x-large">
      <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
        </telerik:RadAjaxLoadingPanel>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager><br />Emploi 2014/2015
        <br />
 <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="True" ShowFooter="True"  OnItemCreated="RadGrid1_ItemCreated"
             Width="95%" BorderColor="Maroon" AllowSorting="True" AllowFilteringByColumn="True" 
            AutoGenerateColumns="False" ShowStatusBar="True" 
            PageSize="3" CellSpacing="0" GridLines="None">
           
           <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
                <Selecting AllowRowSelect="true"></Selecting>
            </ClientSettings>
                
 
            <MasterTableView   DataKeyNames="ID_ENS">
                <NoRecordsTemplate>
                    Aucun enregistrement à afficher!
                </NoRecordsTemplate>
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

                <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                </RowIndicatorColumn>
                <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                </ExpandCollapseColumn>
                
                 <Columns>
                    
                  
                    <telerik:GridBoundColumn DataField="CODE_CL" 
                        FilterControlAltText="Filter CODE_CL column" HeaderText="CODE_CL" FilterControlWidth="110px" ReadOnly="True"
                        SortExpression="CODE_CL" UniqueName="CODE_CL">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="NOM_ENS" 
                        FilterControlAltText="Filter NOM_ENS column" HeaderText="NOM_ENS" FilterControlWidth="110px" ReadOnly="True"
                        SortExpression="NOM_ENS" UniqueName="NOM_ENS">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ANNEE_DEB"   
                        FilterControlAltText="Filter NB_HEURES column" HeaderText="ANNEE_DEB" FilterControlWidth="110px" ReadOnly="True"
                        SortExpression="ANNEE_DEB" UniqueName="ANNEE_DEB">
                    </telerik:GridBoundColumn>
                      <telerik:GridBoundColumn DataField="DESIGNATION"  
                        FilterControlAltText="Filter CHARGE_P1 column" HeaderText="DESIGNATION" FilterControlWidth="110px" ReadOnly="True"
                        SortExpression="DESIGNATION" UniqueName="DESIGNATION">
                    </telerik:GridBoundColumn>
                    
                </Columns>
                 
<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
               
                 
            </MasterTableView>
            

<FilterMenu EnableImageSprites="False"></FilterMenu>
        </telerik:RadGrid><br />

        </center>
</asp:Content>

