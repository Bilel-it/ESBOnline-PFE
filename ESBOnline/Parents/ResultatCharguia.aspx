<%@ Page Title="" Language="C#" MasterPageFile="~/Parents/Par.Master" AutoEventWireup="true" CodeBehind="ResultatCharguia.aspx.cs" Inherits="ESPOnline.Parents.ResultatCharguia" %>
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
    <style type="text/css">
        .style1
        {
            width: 95%;
        }
    </style>
    <style type="text/css">
        .grid-sltrow
        {
            background: #ddd;
            font-weight: bold;
        }
        .SubTotalRowStyle
        {
            border: solid 1px Black;
            background-color: #D8D8D8;
            font-weight: bold;
        }
        .GrandTotalRowStyle
        {
            border: solid 1px Gray;
            background-color: #000000;
            color: #ffffff;
            font-weight: bold;
        }
        .GroupHeaderStyle
        {
            border: solid 1px Black;
            background-color: #909090;
            color: #ffffff;
            font-weight: bold;
        }
        .serh-grid
        {
            width: 85%;
            border: 1px solid #6AB5FF;
            background: #fff;
            line-height: 20px;
            font-size: 15px;
            font-family: Verdana;
        }
        .style2
        {
            width: 37px;
        }
        .style3
        {
            width: 100%;
        }
        .style4
        {
            width: 385px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style1">
        <tr>
            <td class="style2">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;
            </td>
            <td>
                <table class="style1">
                    <tr>
                        <td>
                            <table class="style3">
                                <tr>
                                    <td class="style4">
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:DetailsView ID="DetailsView1" runat="server" DataSourceID="SqlDataSource2" Height="50px"
                                            Width="549px" AutoGenerateRows="False" CellPadding="4" ForeColor="#333333" 
                                            GridLines="None">
                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                            <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
                                            <EditRowStyle BackColor="#999999" />
                                            <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
                                            <Fields>
                                                <asp:BoundField DataField="MOY_GENERAL" HeaderText="MOYENNE GENERAL" SortExpression="MOY_GENERAL" />
                                                <asp:BoundField DataField="LIB_DECISION_SESSION_P" HeaderText="DECISION SESSION Principale"
                                                    SortExpression="DECISION_SESSION_P" />
                                            </Fields>
                                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        </asp:DetailsView>
                                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                                            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT MOY_GENERAL, LIB_DECISION_SESSION_P FROM ESP_INSCRIPTION WHERE (ID_ET =:ID_ET) and annee_deb ='2015'">
                                       <SelectParameters>
            <asp:SessionParameter Name="ID_ET" SessionField="ID_ET" Type="String" />
        </SelectParameters>
                                        </asp:SqlDataSource>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                       <tr>
                        <td> &nbsp; &nbsp;</td></tr>
                    <tr>
                        <td>
                            <asp:GridView ID="GridView2" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False"
                                OnRowCreated="GridView2_RowCreated" OnRowDataBound="GridView2_RowDataBound" CssClass="serh-grid" 
                                TabIndex="1" Width="100%" CellPadding="4" ForeColor="Black" GridLines="Vertical"
                                BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px">
                                <Columns>
                                    <asp:BoundField DataField="DESIGNATION_MODULE" HeaderText="MODULE" ReadOnly="True"
                                        SortExpression="DESIGNATION_MODULE" />
                                    <asp:BoundField DataField="MOYENNE" HeaderText="MOYENNE Module" ReadOnly="True" SortExpression="MOYENNE" />
                                    <asp:BoundField DataField="COEF" HeaderText="COEF" ReadOnly="True" SortExpression="COEF" />
                                </Columns>
                                 <HeaderStyle BackColor="#A80000 " Font-Bold="True" ForeColor="White" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
                                ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
                                SelectCommand="SELECT scoesb02.ESP_V_MOY_MODULE_ETUDIANT.DESIGNATION_MODULE, scoesb02.ESP_V_MOY_MODULE_ETUDIANT.MOYENNE, scoesb02.ESP_V_MOY_MODULE_ETUDIANT.COEF, scoesb02.ESP_V_MOY_PANIER_ETUDIANT.NUM_PANIER, scoesb02.ESP_V_MOY_PANIER_ETUDIANT.COEF AS COEF_P, scoesb02.ESP_V_MOY_PANIER_ETUDIANT.MOYENNE AS MoyenneP FROM scoesb02.ESP_V_MOY_MODULE_ETUDIANT INNER JOIN scoesb02.ESP_V_MOY_PANIER_ETUDIANT ON scoesb02.ESP_V_MOY_MODULE_ETUDIANT.ID_ET = scoesb02.ESP_V_MOY_PANIER_ETUDIANT.ID_ET AND scoesb02.ESP_V_MOY_MODULE_ETUDIANT.ANNEE_DEB = '2015' AND scoesb02.ESP_V_MOY_PANIER_ETUDIANT.ANNEE_DEB = scoesb02.ESP_V_MOY_MODULE_ETUDIANT.ANNEE_DEB AND scoesb02.ESP_V_MOY_MODULE_ETUDIANT.ID_ET =:ID_ET AND scoesb02.ESP_V_MOY_MODULE_ETUDIANT.NUM_PANIER = scoesb02.ESP_V_MOY_PANIER_ETUDIANT.NUM_PANIER AND ESP_V_MOY_PANIER_ETUDIANT.TYPE_moy='P'">
                           <SelectParameters>
            <asp:SessionParameter Name="ID_ET" SessionField="ID_ET" Type="String" />
        </SelectParameters>
                            </asp:SqlDataSource>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>