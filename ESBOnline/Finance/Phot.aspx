<%@ Page Title="" Language="C#" MasterPageFile="~/Finance/RECU.Master" AutoEventWireup="true" CodeBehind="Phot.aspx.cs" Inherits="ESPOnline.Finance.Phot" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            </telerik:RadScriptManager>
    <center>
        <asp:DropDownList ID="DropDownList2" runat="server"  AutoPostBack="True" Width="400px" Height="30px"  AppendDataBoundItems="true"  DataSourceID="SqlDataSource2" DataTextField="date_saisie" DataValueField="date_saisie" OnSelectedIndexChanged="ondropdate" >
    <asp:ListItem>DATE Saisie</asp:ListItem>
    </asp:DropDownList>
    <br />
       <br />
<%-- <asp:DropDownList ID="DropDownList1" runat="server"  AutoPostBack="True" Width="400px" Height="30px"   DataTextField="tt" DataValueField="ID_ET" OnSelectedIndexChanged="tt" >
    
    </asp:DropDownList>--%>
    <telerik:RadComboBox ID="drop" runat="server" OnSelectedIndexChanged="drop2"
                AutoPostBack="True"   DataTextField="tt" 
                DataValueField="ID_ET" DropDownWidth="500" 
                EmptyMessage="recherche par Nom ou ID  d'etudiant " EnableLoadOnDemand="True" 
                Filter="Contains" HighlightTemplatedItems="True" MaxHeight="400" 
                ShowMoreResultsBox="False" Width="348px" Height="33px">
            </telerik:RadComboBox>

       <br />
       <br />
   
      <asp:Button ID="Button2" runat="server" CssClass="form-control" OnClientClick="return confirm('Etes-vous sûr de vouloir confirmer cet élément ?');"
          onclick="Button1_Click" Text="Valider" high="200px" Width="212px" />
  </center> </form> 
  <br />
 
  <br /><center>    <asp:Label ID="Label1" runat="server" Text=" "></asp:Label></center>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"  
        ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
        ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" 
        SelectCommand="select e1.id_et as id_et, e2.NOM_ET||''||e2.PNOM_ET||''||e1.id_et ||''||e2.numcompte as tt,e2.NOM_ET from esp_recu e1,ESP_ETUDIANt e2 where e1.id_et like '16%' and e1.etat='N' and trim(e1.id_et)=trim(e2.id_et) and to_date(e1.date_saisie)=:dd order by (e2.nom_et)">
        <SelectParameters >   <asp:ControlParameter ControlID="DropDownList2" Name="dd"
                    PropertyName="SelectedValue" Type="String" /></SelectParameters>
        </asp:SqlDataSource>
         
     <center>
			<P>
				<TABLE id="Table1" cellSpacing="1" cellPadding="1" border="1">
					<TR>
						<TD class="style1"><img height="900px"  width="900px" src='<%# "Images.aspx?id=" + drop.SelectedValue %>'><br />
                        </TD>
					</TR>
				</TABLE>
			</P>

 </center>
 <asp:SqlDataSource ID="SqlDataSource2" runat="server"  
        ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
        ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" 
        SelectCommand="select    (to_char (date_saisie,'dd/MM/yy')   ) date_saisie from (  select distinct  date_saisie from esp_recu) order by date_saisie desc"></asp:SqlDataSource>
</asp:Content>
