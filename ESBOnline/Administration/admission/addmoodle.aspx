 <%@ Page Title="" Language="C#" MasterPageFile="~/Direction/admission/ad.Master" AutoEventWireup="true" CodeBehind="addmoodle.aspx.cs" Inherits="ESPOnline.Direction.admission.addmoodle" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                            </telerik:RadScriptManager>
               <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>"
                            ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT trim(NOM_ET)||'  '||trim(PNOM_ET)||'  '||trim(NUM_CIN_PASSEPORT)||' '|| ID_ET cc, ID_ET FROM ESP_ETUDIANT WHERE id_et like '17%T%' ">
                        </asp:SqlDataSource>
                            <telerik:RadComboBox ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2"
                                DataTextField="cc" DataValueField="ID_ET" EmptyMessage="Tapez le Nom ou CIN "
                                Filter="Contains" Width="300" MaxHeight="400" DropDownWidth="500" EnableLoadOnDemand="True"
                                ShowMoreResultsBox="False" HighlightTemplatedItems="True" AutoPostBack="True">
                            </telerik:RadComboBox>
                            
                            <asp:Button ID="Button1"
                                runat="server" Text="updatemoodle" OnClick="addmood" /><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</asp:Content>

