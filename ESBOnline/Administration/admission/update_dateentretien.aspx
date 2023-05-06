<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="update_dateentretien.aspx.cs" Inherits="ESPOnline.Administration.admission.update_dateentretien"
    
  MasterPageFile="~/Administration/admission/ad.Master" %>
 <%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function RowDeselecting(rowObject) {
            eventArgs.set_cancel(true) //cancel event;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h1> Modification donnée candidats</h1>
      <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                            </telerik:RadScriptManager>
    Nom Candidat:<telerik:RadComboBox ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2"
                                DataTextField="cc" DataValueField="ID_ET" EmptyMessage="Tapez le Nom ou CIN "
                                Filter="Contains" Width="300" MaxHeight="400" DropDownWidth="500" EnableLoadOnDemand="True"
                                ShowMoreResultsBox="False" HighlightTemplatedItems="True" AutoPostBack="True">
                            </telerik:RadComboBox>

Date:<asp:DropDownList ID="DropDownList2" runat="server" 
        DataTextField="DATE_ENT" 
        DataValueField="DATE_ENT" AutoPostBack="True" required="true" 
        CssClass="style4" >
       
    </asp:DropDownList>
       
  <asp:Button  Text="Modifier date" ID="btnmod" runat="server" onclick="btnmod_Click"/>
    <br />




    
   <%--   
    Nom Candidat:<telerik:RadComboBox ID="DropDownList2" runat="server" DataSourceID="SqlDataSource3"
                                DataTextField="cc" DataValueField="ID_ET" EmptyMessage="Tapez le Nom ou CIN "
                                Filter="Contains" Width="300" MaxHeight="400" DropDownWidth="500" EnableLoadOnDemand="True"
                                ShowMoreResultsBox="False" HighlightTemplatedItems="True" AutoPostBack="True">
                            </telerik:RadComboBox>

Specialité:<asp:DropDownList ID="DropDownList3" runat="server" 
        DataTextField="DATE_ENT" 
        DataValueField="DATE_ENT" AutoPostBack="True" required="true" 
        CssClass="style4" >
       
    </asp:DropDownList>
       
  <asp:Button  Text="Modifier specialité" ID="Button1" runat="server" onclick="btnmod_Click"/>--%>
    <br />


    <center>
    
      <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>"
                            ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT trim(NOM_ET)||'  '||trim(PNOM_ET)||'  '||trim(NUM_CIN_PASSEPORT) cc, ID_ET FROM ESP_ETUDIANT WHERE score_final is null   and TRIM(ID_ET) LIKE '22%' ">
                        </asp:SqlDataSource>


                        </asp:UpdatePanel>
       <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
        SelectCommand="SELECT DISTINCT DATe_ent FROM ADMIS_ESB.date_ent e WHERE e.NOMBRE_CONDIDATS<e.NOMBR_MAX and substr(e.DATE_ENT,3,1)='-' and substr(DATE_ENT,8, 4)='2022'">
    </asp:SqlDataSource>



    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>"
                            ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT trim(NOM_ET)||'  '||trim(PNOM_ET)||'  '||trim(NUM_CIN_PASSEPORT) cc, ID_ET FROM ESP_ETUDIANT WHERE score_final is null and ID_ET LIKE '%T%'  and TRIM(ID_ET) LIKE '19%' ">
                        </asp:SqlDataSource>


                        </asp:UpdatePanel>
       <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
        SelectCommand="SELECT DISTINCT DATe_ent FROM admis_esb.date_ent e WHERE e.NOMBRE_CONDIDATS<e.NOMBR_MAX and substr(e.DATE_ENT,3,1)='-' and substr(DATE_ENT,8, 4)='2022'">
    </asp:SqlDataSource>
    
    </center>
    </asp:Content>