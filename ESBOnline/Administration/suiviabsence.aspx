<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/administration.Master"
    AutoEventWireup="true" CodeBehind="suiviabsence.aspx.cs" Inherits="ESPOnline.Administration.suiviabsence" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <script src="../Contents/jquery.js" type="text/javascript"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
      <script src="../Contents/Scripts/ScrollableGridPlugin_ASP.NetAJAX_2.0.js" type="text/javascript"></script>
     <script src="../Contents/Scripts/bootstrap-datetimepicker.js" type="text/javascript"></script>
    <script src="../Contents/jquery.js" type="text/javascript"></script>

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
        .style1
        {
            width: 80%;
        }
        .style2
        {
            color: #FF0066;
        }
        .style3
        {
            width: 66px;
        }
        .style4
        {
            color: #FF0066;
            width: 190px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <br />
     <br />
    <br />
    <br />
    <br />
    <center>
        <table class="style1">
            <tr>
                <td colspan="2">
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
                        ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
                        SelectCommand="SELECT  distinct code_cl from esp_module_panier_classe_saiso t1, societe t2 where t1.annee_deb=t2.annee_deb order by fn_tri_classe(code_cl)">
                    </asp:SqlDataSource>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
                        ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
                        SelectCommand="select t1.DATE_SEANCE,t1.num_seance  ,t1.CODE_CL,t2.DESIGNATION,t3.NOM_ET||'  '||t3.PNOM_ET nom_et,JUSTIFICATION,OBSERVATION from ESP_ABSENCE_NEW t1, esp_module t2 ,esp_etudiant t3, SOCIETE t4 where
t1.code_module=t2.code_module and t1.id_et=t3.id_et and t1.id_et=:id_et and code_cl=:code_cl and t1.ANNEE_DEB=t4.ANNEE_DEB order by t1.date_seance desc">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="DropDownList2" Name="id_et" PropertyName="SelectedValue"
                                Type="String" />
                            <asp:ControlParameter ControlID="DropDownList1" Name="code_cl" PropertyName="SelectedValue"
                                Type="String" />
                                 
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Label ID="Label2" runat="server" Text="Suivi des absences par étudiants" CssClass="active" Font-Bold="True"
                        Font-Size="X-Large" ForeColor="#CC0000"></asp:Label></td></tr>
            <tr><td>
                    
                    <asp:ImageButton ID="ImageButton2" runat="server" AlternateText="ExcelML" 
                        ImageUrl="../Contents/Img/Excel_ExcelML.png" OnClick="ImageButton_Click" />
                </td>
            </tr>
            <tr>
                <td class="style4" align="center">
                    classe
                </td>
                <td class="style3" align="center">
                    <telerik:RadComboBox ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1"
                        DataTextField="code_cl" DataValueField="code_cl" EmptyMessage=" " Filter="Contains"
                        Width="200px">
                    </telerik:RadComboBox>
                    <telerik:RadComboBox ID="DropDownList2" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource3"
                        DataTextField="NOM_ET" DataValueField="ID_ET" EmptyMessage=" " Filter="Contains"
                        Width="200px">
                    </telerik:RadComboBox>
                    <%--<telerik:RadComboBox ID="DropDownList3" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource4"
                        DataTextField="DESIGNATION" DataValueField="code_module" EmptyMessage=" " Filter="Contains"
                        Width="200px">
                    </telerik:RadComboBox>--%>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
                        ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
                        SelectCommand="select t1.id_et,NOM_ET||'  '||PNOM_ET nom_et from esp_etudiant t1, esp_inscription t2,
                     societe t3 where etat='A' and t1.id_et=t2.id_et and t3.annee_deb=t2.annee_deb and code_cl=:code_cl order by nom_et ">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="DropDownList1" Name="code_cl" PropertyName="SelectedValue"
                                Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
                        ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
                        SelectCommand="select distinct t1.DESIGNATION,t1.CODE_MODULE from  esp_module t1 , ESP_ABSENCE_NEW t2,societe t3 where t1.code_module=t2.code_module and code_cl=:code_cl and t2.id_et=:id_et and t3.annee_deb=t2.annee_deb ">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="DropDownList1" Name="code_cl" PropertyName="SelectedValue"
                                Type="String" />
                            <asp:ControlParameter ControlID="DropDownList2" Name="id_et" PropertyName="SelectedValue"
                                Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
                <td class="style3">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style2" colspan="2" align="center">
                    <telerik:RadGrid ID="RadGrid1" runat="server" AllowFilteringByColumn="false" AllowPaging="True"
                        AutoGenerateColumns="False" CellSpacing="0" DataSourceID="SqlDataSource2" GridLines="None"
                        PageSize="15" ShowFooter="True" ShowStatusBar="True" Width="100%">
                        <exportsettings filename="test" hidestructurecolumns="true">
                    </exportsettings>
                        <clientsettings allowkeyboardnavigation="true" enablepostbackonrowclick="true">
                        <Selecting AllowRowSelect="true" />
                    </clientsettings>
                        <mastertableview datasourceid="SqlDataSource2" width="100%">
                     
                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" 
                            Visible="True">
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" 
                            Visible="True">
                        </ExpandCollapseColumn>
                        <Columns>
                                <telerik:GridBoundColumn DataField="Date_seance" DataFormatString="{0:d}"
                                FilterControlAltText="Filter Date_seance column" FilterControlWidth="110px" 
                                HeaderText="Date_seance" ReadOnly="True" SortExpression="Date_seance" 
                                UniqueName="Date_seance"/>
                                 <telerik:GridBoundColumn DataField="num_seance" 
                                FilterControlAltText="Filter num_seance column" FilterControlWidth="110px" 
                                HeaderText="num_seance" ReadOnly="True" SortExpression="num_seance" 
                                UniqueName="num_seance"/>
                         <%--   <telerik:GridBoundColumn DataField="CODE_CL" 
                                FilterControlAltText="Filter CODE_CL column" FilterControlWidth="110px" 
                                HeaderText="CODE_CL" ReadOnly="True" SortExpression="CODE_CL" 
                                UniqueName="CODE_CL">
                            </telerik:GridBoundColumn>--%>
                               <telerik:GridBoundColumn DataField="NOM_ET" 
                                FilterControlAltText="Filter NOM_ET column" FilterControlWidth="110px" 
                                HeaderText="NOM_ET" ReadOnly="True" SortExpression="NOM_ET" 
                                UniqueName="NOM_ET"/>
                         
                        
                            <telerik:GridBoundColumn DataField="DESIGNATION" 
                                FilterControlAltText="Filter DESIGNATION column" FilterControlWidth="110px" 
                                HeaderText="Module" ReadOnly="True" SortExpression="DESIGNATION" 
                                UniqueName="DESIGNATION">
                            </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="JUSTIFICATION" 
                               FilterControlWidth="110px" 
                                HeaderText="JUSTIFICATION" ReadOnly="True" 
                               >
                            </telerik:GridBoundColumn>
                              <telerik:GridBoundColumn DataField="OBSERVATION" 
                               FilterControlWidth="110px" 
                                HeaderText="OBSERVATION" ReadOnly="True" 
                               >
                            </telerik:GridBoundColumn>
                        </Columns>
                  
                         
                        <EditFormSettings>
                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                            </EditColumn>
                        </EditFormSettings>
                    </mastertableview>
                        <clientsettings allowkeyboardnavigation="true" enablepostbackonrowclick="true">
                        <Selecting AllowRowSelect="true" />
                    </clientsettings>
                        <pagerstyle mode="NextPrevAndNumeric" />
                        <filtermenu enableimagesprites="False">
                    </filtermenu>
                    </telerik:RadGrid>
                </td>
            </tr>
        </table>
    </center>
</asp:Content>
