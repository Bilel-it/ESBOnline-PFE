<%@ Page Title="" Language="C#" MasterPageFile="~/Direction/Site2.Master" AutoEventWireup="true" CodeBehind="Resultat.aspx.cs" Inherits="ESPOnline.Direction.Resultat" %>
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
    <%--<asp:Label ID="Label2" runat="server" Text=""></asp:Label>--%>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
                 <telerik:RadComboBox ID="DropDownList1" runat="server" 
        DataSourceID="SqlDataSource1" AutoPostBack="True" 
                                                            DataTextField="NOM" 
        DataValueField="ID_ET" EmptyMessage="Tappez le Nom d'etudiant "  
                                                            Filter="Contains" 
        Width="400px" Height="100px">
                                                        </telerik:RadComboBox>
                                                        <br /><br />
 <asp:DetailsView ID="DetailsView3" runat="server" AutoGenerateRows="False" 
                DataSourceID="SqlDataSource3" Height="50px" Width="536px" 
        BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" 
        CellPadding="3" CellSpacing="1" GridLines="None">
                <EditRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                <Fields>
                     <asp:BoundField DataField="MOYENNE_GENERAL" HeaderText="MOYENNE_GENERAL" 
            SortExpression="MOYENNE_GENERAL" >
                           
                        </asp:BoundField>
                  <asp:BoundField DataField="DECISION" HeaderText="DECISION" 
            SortExpression="DECISION" >   
                        </asp:BoundField>
                </Fields>
                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
            </asp:DetailsView>
    </center><br /> <br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"
     ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
                    ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" 
                    
                    SelectCommand="SELECT NOM_ET||' '||PNOM_ET || ' '||ESP_ETUDIANT.ID_ET ||'  '|| esp_inscription.code_cl as NOM, ESP_ETUDIANT.ID_ET as ID_ET FROM ESP_ETUDIANT, ESP_INSCRIPTION WHERE (ESP_INSCRIPTION.ID_ET=ESP_ETUDIANT.ID_ET )AND (ESP_INSCRIPTION.ANNEE_deb=2013)  order by NOM"></asp:SqlDataSource>
<center> <asp:Panel ID="Panel2" runat="server">
                <asp:GridView ID="GridView2" runat="server" OnDataBound="OnDataBound"  onrowdatabound="GridView2_test" 
                    DataSourceID="SqlDataSource2" ShowFooter="false" AutoGenerateColumns="False">
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
                           <asp:BoundField DataField="MOY_UE" HeaderText="MOY_UE" ItemStyle-Width="150"
                            SortExpression="MOY_UE"> </asp:BoundField>  
                        <%--<asp:BoundField DataField="MOY_UE" HeaderText="MOY_UE" ItemStyle-Width="150" SortExpression="MOY_UE">
                            <ItemStyle Width="150px" />

                        </asp:BoundField>--%>
                                                  <asp:TemplateField HeaderText="MOYENNE /UE" SortExpression="MOY_UE">
                            <ItemTemplate>
                                <asp:Label ID="Label14" runat="server" Text='<%# Bind("MOY_UE") %>'></asp:Label>
                            </ItemTemplate>
                             <FooterTemplate>
                                <div style="text-align: center;">
                                    <table width="100%" >
                    <tr><td><asp:Label ID="Label15" runat="server" Text="Total ECTS encaissés :" /></tr></td>
                    
                            <tr><td>     <asp:Label ID="Label1" runat="server" Text="MOYENNE GENERAL :"></asp:Label></tr></td>
                                 <tr><td>   <asp:Label ID="DECISION" runat="server" Text="DECISION :"></asp:Label></tr></td></table>
                                </div>
                            </FooterTemplate>
                            </asp:TemplateField>
                          <asp:TemplateField HeaderText="NB_ECTS Aquis /UE" SortExpression="NB_ECTS">
                            <ItemTemplate>
                                <asp:Label ID="Label8" runat="server" Text='<%# Bind("NB_ECTS") %>'></asp:Label>
                            </ItemTemplate>
                             <FooterTemplate>
                                <div style="text-align: center">
                               <table width="100%" >
                    <tr><td>       <asp:Label ID="Label22" runat="server" /></tr></td>
                     <tr><td>  <asp:Label ID="Label3" runat="server"  ></asp:Label></tr></td>
                             <tr><td>    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>  </td></tr> </table>
                                </div>
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
                    TypeName="ESPOnline.Etudiants.ResultatFinalP">
                    <SelectParameters>
                       <asp:ControlParameter ControlID="DropDownList1" Name="ID_ET" PropertyName="SelectedValue"
                                    Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server"
                ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" 
            SelectCommand="SELECT e2.code_ue ,lib_ue,nb_ects, designation,coef ,e1.moyenne as moy_module,e2.moyenne as moy_ue FROM ESP_V_MOY_MODULE_ETUDIANT_UE e1, ESP_V_MOY_UE_ETUDIANT e2 where   e1.id_et=e2.id_et and e1.annee_deb='2013' AND e2.annee_deb='2013' and e1.code_ue=e2.code_ue and e1.ID_ET=:idet  and e1.type_moy='P'and e2.type_moy='P'  order by lib_ue ">
       
                            <SelectParameters>
                              
                                <asp:ControlParameter ControlID="DropDownList1" Name="idet" PropertyName="SelectedValue" Type="String" />
                            </SelectParameters>
       
        </asp:SqlDataSource>
            </asp:Panel>
            </center>
            <br />
            <center>
                <table>
                    <tr>
                        <td>
    <asp:GridView ID="GridView1" DataSourceID="SqlDataSource3" runat="server" Visible="false" 
        AutoGenerateColumns="False">
    <Columns>
     <asp:BoundField DataField="MOYENNE_GENERAL" HeaderText="MOYENNE_GENERAL" 
            SortExpression="MOYENNE_GENERAL" >
                           
                        </asp:BoundField>
                  <asp:BoundField DataField="DECISION" HeaderText="DECISION" 
            SortExpression="DECISION" >
                           
                        </asp:BoundField>       
                        </Columns>
    </asp:GridView>
                        </td>
                        <td align="center">
                           <asp:GridView ID="GridView3" runat="server" DataSourceID="SqlDataSource4"  
                                AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
                                GridLines="None">
                               <AlternatingRowStyle BackColor="White" />
                  <Columns>
                      <asp:BoundField DataField="SUM(NB_ECTS)" HeaderText="Total ECTS encaissés" 
                          ReadOnly="True" SortExpression="SUM(NB_ECTS)" />
                  </Columns>
                               <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                               <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                               <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                               <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                               <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                               <SortedAscendingCellStyle BackColor="#FDF5AC" />
                               <SortedAscendingHeaderStyle BackColor="#4D0000" />
                               <SortedDescendingCellStyle BackColor="#FCF6C0" />
                               <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView></td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
                
        
                <br /><br />
      <asp:SqlDataSource ID="SqlDataSource3" runat="server"
                ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" 
            SelectCommand="SELECT MOY_GENERAL as moyenne_general, LIB_DECISION_SESSION_P as DECISION  FROM ESP_INSCRIPTION WHERE ANNEE_DEB ='2013' and (ID_ET =:idet) ">
       
                            <SelectParameters>
                              
                                <asp:ControlParameter ControlID="DropDownList1" Name="idet" PropertyName="SelectedValue" Type="String" />
                            </SelectParameters>
       
        </asp:SqlDataSource>
        
          <asp:SqlDataSource ID="SqlDataSource4" runat="server"
                ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" 
            SelectCommand="SELECT sum(nb_ects) FROM ESP_V_MOY_UE_ETUDIANT where type_moy='P' and moyenne>=10 and id_et=:idet ">
       
                            <SelectParameters>
                              
                                <asp:ControlParameter ControlID="DropDownList1" Name="idet" PropertyName="SelectedValue" Type="String" />
                            </SelectParameters>
       
        </asp:SqlDataSource>
        </center>
</asp:Content>