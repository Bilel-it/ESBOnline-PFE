<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reçu_valide.aspx.cs" Inherits="ESPOnline.images.Finance.Reçu_valide" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    
    <style type="text/css">
        #Table1
        {
            width: 500px;
        }
        .style1
        {
            height:500px;
            width: 500px;
        }
    </style>
    
</head>
<body>
  <form id="form1" runat="server" method="post">
  <h3>
      <center></ce>
          <h2>
              <strong>Liste Reçus validés 
          </h2>
  </center>
  </strong>
  </h3>
  <center>Année
    <asp:DropDownList ID="DropDownList2" runat="server" required="true" 
          AutoPostBack="True" onselectedindexchanged="DropDownList2_SelectedIndexChanged">
           <asp:ListItem Value="nn">select année</asp:ListItem>
          <asp:ListItem Value="14">2014</asp:ListItem>
          <asp:ListItem Value="15">2015</asp:ListItem>
          <asp:ListItem Value="16">2016</asp:ListItem>
      </asp:DropDownList> &nbsp; &nbsp;
   <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            </telerik:RadScriptManager>
                            <%-- <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
                            <telerik:RadComboBox ID="drop1" runat="server" 
                AutoPostBack="True"  DataTextField="tt" 
                DataValueField="ID_ET" DropDownWidth="500" 
                EmptyMessage="recherche par Nom ou ID  d'etudiant " EnableLoadOnDemand="True" 
                Filter="Contains" HighlightTemplatedItems="True" MaxHeight="400" 
                ShowMoreResultsBox="False" Width="500">
            </telerik:RadComboBox>

    
    
      &nbsp;<br /><br /><br />
      <asp:Button ID="Button1" runat="server" Text="Afficher le reçu"  onclick="Button1_Click"/>
 <asp:DropDownList ID="DropDownList1" runat="server"   Width="400px" Height="30px" Visible="false"   >
    
    </asp:DropDownList>
    
      <br />
  </center>  
  <br />
  
 
  <br /><center>    <asp:Label ID="Label1" runat="server" Text=" "></asp:Label></center>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"  
        ConnectionString="<%$ ConnectionStrings:ConnectionString2%>" 
        ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" 
          
        SelectCommand=" select e1.id_et as id_et, e2.NOM_ET||''||e2.PNOM_ET||'  '||e1.id_et ||'  '||e2.numcompte as tt,e2.NOM_ET from esp_recu e1,esp_etudiant e2 where (substr(e1.id_et,1,2) =  :annee)  and trim(e1.id_et)=trim(e2.id_et) order by (e2.date_saisie)">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList2" Name="annee" 
                PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>

         
    <asp:SqlDataSource ID="SqlDataSource2" runat="server"  
        ConnectionString="<%$ ConnectionStrings:ConnectionString3%>" 
        ProviderName="<%$ ConnectionStrings:ConnectionString3.ProviderName %>" 
          
        
      SelectCommand=" select e1.id_et as id_et, e2.NOM_ET||''||e2.PNOM_ET||'   '||e1.id_et ||'  '||e2.numcompte as tt,e2.NOM_ET from esp_recu e1,ESP_ETUDIANt e2 where (substr(e1.id_et,1,2) =  :annee)  and trim(e1.id_et)=trim(e2.id_et) order by (e2.date_saisie)">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList2" Name="annee" 
                PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
         
    </form> 

         
     <center>
         <asp:Panel ID="Panel1" runat="server" Visible="false">
         
			<P>
				<TABLE id="Table1" cellSpacing="1" cellPadding="1" border="1" >
					<TR>
						<TD class="style1"><img height="900px" src='<%# "Images_reçu.aspx?id=" + DropDownList1.SelectedValue %>'><br />
                        </TD>
					</TR>
				</TABLE>
			</P>
            </asp:Panel>

 </center>
    
</body>
</html>
