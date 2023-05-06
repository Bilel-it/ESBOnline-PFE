<%@ Page Title="" Language="C#" MasterPageFile="~/Direction/Site2.Master" AutoEventWireup="true" CodeBehind="ResultatRattrapage.aspx.cs" Inherits="ESPOnline.Direction.ResultatRattrapage" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
    <style type="text/css">
         .footer td
        {
            border: none;
        }
   .table     td {
border-bottom: 1pt solid black;
}     
  .footer      tr {
border-bottom: 1pt solid black;
}
        .footer th
        {
            border: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
    
       
            <asp:Label ID="Label18" runat="server" Text="Resultat Session Rattrapage" Font-Bold="True" 
                Font-Italic="True" Font-Names="Bookman Old Style" Font-Size="X-Large" 
                Width="634px" ForeColor="#CC0000"></asp:Label><br />
          
    <asp:Label ID="Label2" runat="server" Text=""></asp:Label><asp:Label ID="Label5"
        runat="server" Text="Label" Visible="false"></asp:Label>
     <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                    </telerik:RadScriptManager>
       
                 <telerik:RadComboBox ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" AutoPostBack="True" 
                                                            DataTextField="NOM" DataValueField="ID_ET" EmptyMessage="Tappez le Nom d'etudiant "   OnSelectedIndexChanged="test"
                                                            Filter="Contains" Width="300" MaxHeight="400" DropDownWidth="500" EnableLoadOnDemand="True" ShowMoreResultsBox="False" BorderStyle="Double" BorderColor="Maroon" HighlightTemplatedItems="True">
                                                        </telerik:RadComboBox>
                                                        <br /><br />
                                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server"
     ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
                    ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" 
                    
                    SelectCommand="SELECT NOM_ET||' '||PNOM_ET || ' '||ESP_ETUDIANT.ID_ET ||'  '|| esp_inscription.code_cl as NOM, ESP_ETUDIANT.ID_ET as ID_ET FROM ESP_ETUDIANT, ESP_INSCRIPTION WHERE (ESP_INSCRIPTION.ID_ET=ESP_ETUDIANT.ID_ET )AND (ESP_INSCRIPTION.ANNEE_deb=2013) AND esp_inscription.code_cl NOT LIKE '%-%' and esp_inscription.code_cl not like '%FU%'  order by NOM"></asp:SqlDataSource>


<br /><br />
 <div class="col-xs-1">
    </div>
    <center>
      <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                                            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT MOY_RATT,LIB_DECISION_SESSION_Rat FROM ESP_INSCRIPTION WHERE (ID_ET =:ID_ET) and annee_deb ='2013'">
                                       <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList1" Name="_Id_et" 
                    PropertyName="SelectedValue" Type="String" /></SelectParameters>
                                        </asp:SqlDataSource>
    
        <asp:DetailsView ID="DetailsView2" runat="server" AutoGenerateRows="False" 
                DataSourceID="SqlDataSource2" Height="50px" Width="536px" 
            BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" 
            CellPadding="3" CellSpacing="1" GridLines="None">
                <EditRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                <Fields>
                     
                    <asp:BoundField DataField="LIB_DECISION_SESSION_Rat" 
                        HeaderText="Session de rattrapage:" 
                        SortExpression="LIB_DECISION_SESSION_Rat" />
                    <asp:BoundField DataField="MOY_RATT" HeaderText="Moyenne rattapage:" 
                        SortExpression="MOY_RATT" />
                </Fields>
                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#660066" ForeColor="White" Font-Bold="True"/>
            </asp:DetailsView>
           </center>
       
        <asp:Label ID="Label19" runat="server" Text="Label" Visible="false" ></asp:Label>
        <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>

      <%--  <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>--%>
        &nbsp;
        <asp:Label ID="Label9" runat="server"  Visible="false" Text=""></asp:Label>
         <asp:Label ID="Label3" runat="server"  Visible="false" Text=""></asp:Label>
        &nbsp;<asp:Label ID="Label16" runat="server" Visible="false" Text="Label"></asp:Label>
&nbsp;<center>
            <asp:Panel ID="Panel2" runat="server">
                <asp:GridView ID="GridView2" runat="server" OnDataBound="OnDataBound" OnRowDataBound="GridView1_test" OnRowCreated="grdView2_RowCreated"  Width="90%"
                    DataSourceID="ObjectDataSource1" ShowFooter="True" AutoGenerateColumns="False">
                    <Columns>
                        <%-- <asp:BoundField DataField="CODE_UE" HeaderText="CODE_UE" 
                                 SortExpression="CODE_UE" />--%>
                        <asp:BoundField DataField="LIB_UE" HeaderText="Unite d'Enseignement" ItemStyle-Width="150" SortExpression="LIB_UE">
                            <ItemStyle Width="150px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="NB_ECTS" SortExpression="NB_ECTS">
                            <ItemTemplate>
                                <asp:Label ID="Label8" runat="server" Text='<%# Bind("NB_ECTS") %>'></asp:Label>
                            </ItemTemplate>
                           
                        </asp:TemplateField>
                        <%--<asp:BoundField DataField="MOY_UE" HeaderText="MOY_UE" ItemStyle-Width="150" SortExpression="MOY_UE">
                            <ItemStyle Width="150px" />

                        </asp:BoundField>--%>
                                                  <asp:TemplateField HeaderText="MOYENNE UE PRINCIPALE" SortExpression="MOY_UE">
                                                   <ItemStyle Width="400px" />
                            <ItemTemplate>
                                <asp:Label ID="Label14" runat="server" Text='<%# Bind("MOY_UE") %>'></asp:Label>
                            </ItemTemplate>
                            <%-- <FooterTemplate>
                                <div style="text-align: center;">
                                    <table width="100%" >
                    <tr><td><asp:Label ID="Label15" runat="server" Text="Total ECTS encaissés :" Visible="false"/></td><td >       <asp:Label ID="Label2" runat="server" Visible="false" /></td></tr>
                    
                            <tr><td>     <asp:Label ID="Label1" runat="server" Text="MOYENNE Principale :" Visible="false"></asp:Label></td><td>  <asp:Label ID="Label3" runat="server" Visible="false" ></asp:Label></td></tr>
                                 <tr><td>   <asp:Label ID="DECISION" runat="server" Text="DECISION :" Visible="false"></asp:Label></td><td>    <asp:Label ID="Label4" runat="server" Text="Label" Visible="false"></asp:Label>  </td</tr></table>
                                </div>
                            </FooterTemplate>--%>
                            </asp:TemplateField>
                          <asp:TemplateField HeaderText="NB_ECTS Aquis UE" SortExpression="NB_ECTS">
                           <ItemStyle Width="20px" />
                            <ItemTemplate>
                                <asp:Label ID="Label8" runat="server" Text='<%# Bind("NB_ECTS") %>'></asp:Label>
                            </ItemTemplate>
                             <FooterTemplate>
                                <%--<div style="text-align: center">
                               <table width="100%" >
                    <tr><td>       <asp:Label ID="Label2" runat="server" /></tr></td>
                     <tr><td>  <asp:Label ID="Label3" runat="server"  ></asp:Label></tr></td>
                             <tr><td>    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>  </td></tr> </table>
                                </div>--%>
                            </FooterTemplate>
                            </asp:TemplateField>
                            <%-- <asp:BoundField DataField="MOY_UE_RATT" HeaderText="UE RATT" ItemStyle-Width="150" SortExpression="MOY_UE_RATT">
                            <ItemStyle Width="150px" />
                        </asp:BoundField>--%>
                         <asp:TemplateField HeaderText="MOYENNE UE RATTRAPAGE" SortExpression="MOY_UE_RATT">
                             <ItemStyle Width="500px" />
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("MOY_UE_RATT") %>'></asp:Label>
                            </ItemTemplate>
 <FooterTemplate>
                                <div style="text-align: center;">
                                    <table width="100%" >
                                         
                                        
                    <tr><td><asp:Label ID="Label7" runat="server" Text="Total ECTS encaissés :" /></td><td>       <asp:Label ID="Label12" runat="server" /></td></tr>
                    
                            <tr><td>     <asp:Label ID="Label10" runat="server" Text="MOYENNE Rattrapage :" Visible="false"></asp:Label></td><td>       <asp:Label ID="Label13" runat="server"   Visible="false"/></td></tr>
                                 <tr><td>   <asp:Label ID="DECISIONR" runat="server" Text="DECISION :"  Visible="false"></asp:Label> </td><td>   <asp:Label ID="Label17" runat="server"  Visible="false"/></td></tr></table>
                                </div>
                            </FooterTemplate>
 </asp:TemplateField><%--
                         <asp:BoundField DataField="NB_ECTS_R" HeaderText="NB_ECTS_R" ItemStyle-Width="150"
                            SortExpression="NB_ECTS_R">
                            
                        </asp:BoundField>--%>
                         <asp:TemplateField HeaderText="NB_ECTS Aquis UE" SortExpression="NB_ECTS_R">
                           <ItemStyle Width="20px" />
                            <ItemTemplate>
                                 
  <asp:Label ID="Label11" runat="server" Text='<%# Bind("NB_ECTS") %>'></asp:Label>
                            </ItemTemplate>
                             <FooterTemplate>
                               <%-- <div style="text-align: center">
                               <table width="100%" >
                                    
                    <tr><td>       <asp:Label ID="Label12" runat="server" /></tr></td>
                     <tr><td>       <asp:Label ID="Label13" runat="server" /></tr></td>
                      <tr><td>       <asp:Label ID="Label17" runat="server" /></tr></td>
                     </table>
                                </div>--%>
                            </FooterTemplate>
 </asp:TemplateField>
                        
                        <asp:BoundField DataField="DESIGNATION" HeaderText="MODULES" ItemStyle-Width="150"
                            SortExpression="DESIGNATION">
                            <ItemStyle Width="200px" />
                        </asp:BoundField>
                        <%--<asp:BoundField DataField="NB_ECTS" HeaderText="NB_ECTS" ItemStyle-Width="150" SortExpression="NB_ECTS" />--%>
                        <asp:BoundField DataField="COEF" HeaderText="COEF" SortExpression="COEF" >
                           
                        </asp:BoundField>
                        <asp:BoundField DataField="MOY_MODULE" HeaderText="MOY_MODULE"  
                            SortExpression="MOY_MODULE">
                             
                        </asp:BoundField>
                         <asp:BoundField DataField="MOY_MODULERATT" HeaderText="MOY_MODULERATT"  
                            SortExpression="MOY_MODULERATT">
                             
                        </asp:BoundField>
                        
                  
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" CssClass="footer" />
                    <HeaderStyle BackColor="#A80000 " Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#E0E0E0 " ForeColor="#000000" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000000" />
                    <SelectedRowStyle BackColor="#E0E0E0" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetResFinal"
                    TypeName="ESPOnline.Etudiants.Rattra">
                    <SelectParameters>
                        
                          <asp:ControlParameter ControlID="DropDownList1" Name="_Id_et" 
                    PropertyName="SelectedValue" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </asp:Panel>
        </center>
         <center>
    <table>
    <asp:DetailsView ID="DetailsView3" runat="server" AutoGenerateRows="False" 
                DataSourceID="SqlDataSource2" Height="50px" Width="536px" 
            BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" 
            CellPadding="3" CellSpacing="1" GridLines="None">
                <EditRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                <Fields>
                    <asp:BoundField DataField="LIB_DECISION_SESSION_P" 
                        HeaderText="Session Principale" SortExpression="LIB_DECISION_SESSION_P" />
                    <asp:BoundField DataField="LIB_DECISION_SESSION_Rat" 
                        HeaderText="Session de rattrapage" 
                        SortExpression="LIB_DECISION_SESSION_Rat" />
                    <asp:BoundField DataField="MOY_RATT" HeaderText="Moyenne" 
                        SortExpression="MOY_RATT" />
                </Fields>
                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
            </asp:DetailsView>
        </table>
         <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                                            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT MOY_RATT,LIB_DECISION_SESSION_Rat, LIB_DECISION_SESSION_P FROM ESP_INSCRIPTION WHERE (ID_ET =:ID_ETT) and annee_deb ='2013'">
                                       
            <SelectParameters>
                        
                          <asp:ControlParameter ControlID="DropDownList1" Name="ID_ETT" 
                    PropertyName="SelectedValue" Type="String" />
                     
        </SelectParameters>
                                        </asp:SqlDataSource></center>
                                        <table>
  
           
     <tr>
            <td>  &nbsp;&nbsp;</td></tr> &nbsp;&nbsp;<tr>
            <td>  &nbsp;&nbsp;</td></tr>
        <tr>
            <td>
                <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource2">
                    <Columns>
                        <asp:BoundField DataField="Code_module" HeaderText="Code_module" SortExpression="Code Module" />
                        <asp:BoundField DataField="Designation" HeaderText="Designation" SortExpression="Designation" />
                        <asp:BoundField DataField="Moyenne" HeaderText="Principale" SortExpression="Moyenne" />
                    </Columns>
                     <FooterStyle BackColor="White" ForeColor="#000066" CssClass="footer" />
                    <HeaderStyle BackColor="#A80000 " Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#E0E0E0 " ForeColor="#000000" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000000" />
                    <SelectedRowStyle BackColor="#E0E0E0" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
            </td>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource4">
                    <Columns>
                        <asp:BoundField DataField="Moyenne" HeaderText="Controle" SortExpression="Moyenne" />
                    </Columns>
                     <FooterStyle BackColor="White" ForeColor="#000066" CssClass="footer" />
                    <HeaderStyle BackColor="#A80000 " Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#E0E0E0 " ForeColor="#000000" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000000" />
                    <SelectedRowStyle BackColor="#E0E0E0" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
            </td>
            <td>
                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource5"
                    OnLoad="GrouperAffichage">
                    <Columns>
                        <asp:BoundField DataField="NUM_PANIER" HeaderText="Panier " SortExpression="NUM_PANIER" />
                        <asp:BoundField DataField="MOYENNE" HeaderText="Moyenne Panier" SortExpression="MOYENNE" />
                    </Columns>
                     <FooterStyle BackColor="White" ForeColor="#000066" CssClass="footer" />
                    <HeaderStyle BackColor="#A80000 " Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#E0E0E0 " ForeColor="#000000" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000000" />
                    <SelectedRowStyle BackColor="#E0E0E0" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetListModuleP"
        TypeName="ESPOnline.ModuleP">
        <SelectParameters>
                        
                          <asp:ControlParameter ControlID="DropDownList1" Name="_Id_et" 
                    PropertyName="SelectedValue" Type="String" />
                    </SelectParameters>
    </asp:ObjectDataSource><br /> <asp:ObjectDataSource ID="ObjectDataSource5" runat="server" SelectMethod="GetListPanier"
        TypeName="ESPOnline.Panier">
       <SelectParameters>
                        
                          <asp:ControlParameter ControlID="DropDownList1" Name="_Id_et" 
                    PropertyName="SelectedValue" Type="String" />
                    </SelectParameters>
    </asp:ObjectDataSource><br /><asp:ObjectDataSource ID="ObjectDataSource4" runat="server" SelectMethod="GetListModulePRatt"
        TypeName="ESPOnline.ModuleP">
        <SelectParameters>
                        
                          <asp:ControlParameter ControlID="DropDownList1" Name="_Id_et" 
                    PropertyName="SelectedValue" Type="String" />
                    </SelectParameters>
    </asp:ObjectDataSource>
    </center>

</asp:Content>
