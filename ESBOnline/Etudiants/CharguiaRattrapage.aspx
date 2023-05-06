<%@ Page Title="" Language="C#" MasterPageFile="~/Etudiants/Eol.Master" AutoEventWireup="true"
    CodeBehind="CharguiaRattrapage.aspx.cs" Inherits="ESPOnline.Etudiants.CharguiaRattrapage" %>

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
    <br />
    
    <br />
    <br />
    <center>
        <asp:Label ID="Label2" runat="server" Style="font-size: large; color: #FF3300; font-weight: 700;
            text-align: center"></asp:Label></center>
    <asp:ObjectDataSource ID="ObjectDataSource7" runat="server" SelectMethod="GetListInscription"
        TypeName="ESPOnline.Inscription">
        <SelectParameters>
            <asp:SessionParameter Name="_Id_et" SessionField="ID_ET" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="ObjectDataSource6" runat="server" SelectMethod="GetListInscription"
        TypeName="ESPOnline.Inscription">
        <SelectParameters>
            <asp:SessionParameter Name="_Id_et" SessionField="ID_ET" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                                            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT MOY_RATT,LIB_DECISION_SESSION_Rat, LIB_DECISION_SESSION_P FROM ESP_INSCRIPTION WHERE (ID_ET =:ID_ET) and annee_deb ='2015'">
                                       <SelectParameters>
            <asp:SessionParameter Name="ID_ET" SessionField="ID_ET" Type="String" />
        </SelectParameters>
                                        </asp:SqlDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetListInscription"
        TypeName="ESPOnline.Inscription">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="" Name="_Id_et" SessionField="ID_ET" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource8" runat="server" SelectMethod="GetListInscription"
        TypeName="ESPOnline.Inscription">
        <SelectParameters>
            <asp:SessionParameter Name="_Id_et" SessionField="ID_ET" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
    <asp:ObjectDataSource ID="ObjectDataSource9" runat="server" SelectMethod="GetListInscription"
        TypeName="ESPOnline.Inscription">
        <SelectParameters>
            <asp:SessionParameter Name="_Id_et" SessionField="ID_ET" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <center>
    <asp:Label ID="Label1" runat="server" Style="color:  #CC0000; font-size: large" 
            Text="Resultat Session Rattrapage" ></asp:Label>
             <%--<asp:Label ID="Label3" runat="server" Style="color:  #CC0000; font-size: large" 
            Text="Site en état de maintenance" ></asp:Label>--%></center>

    <br />
    <br />
    <center>
    <table>
    <asp:DetailsView ID="DetailsView3" runat="server" AutoGenerateRows="False" 
                DataSourceID="SqlDataSource1" Height="50px" Width="536px" 
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
        </table></center>
        <center>
    <table>
  
           
     <tr>
            <td>  &nbsp;&nbsp;</td></tr> &nbsp;&nbsp;<tr>
            <td>  &nbsp;&nbsp;</td></tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1">
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
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource4">
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
    </table></center>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetListModuleP"
        TypeName="ESPOnline.ModuleP">
        <SelectParameters>
            <asp:SessionParameter Name="_Id_et" SessionField="ID_ET" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource5" runat="server" SelectMethod="GetListPanier"
        TypeName="ESPOnline.Panier">
        <SelectParameters>
            <asp:SessionParameter Name="_Id_et" SessionField="ID_ET" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
    <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" SelectMethod="GetListModulePRatt"
        TypeName="ESPOnline.ModuleP">
        <SelectParameters>
            <asp:SessionParameter Name="_Id_et" SessionField="ID_ET" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource3" runat="server"></asp:ObjectDataSource>
    <br />
</asp:Content>
