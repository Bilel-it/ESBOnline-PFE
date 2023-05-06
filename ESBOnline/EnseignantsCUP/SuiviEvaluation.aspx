<%@ Page Title="" Language="C#" MasterPageFile="~/EnseignantsCUP/Cup.Master" AutoEventWireup="true" CodeBehind="SuiviEvaluation.aspx.cs" Inherits="ESPOnline.EnseignantsCUP.SuiviEvaluation" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title></title>
    <link href="../Contents/Css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />
    <script src="../Contents/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="../Contents/Scripts/bootstrap.js" type="text/javascript"></script>
    <script type="text/javascript" src="../Contents/Scripts/JScript1.js"></script>
    <style type="text/css">
        .text-inf
        {
            color: #000000;
        }
        .form-control
        {
        }
        .style1
        {
            color: #CC0000;
            font-size: medium;
        }
    </style>
</asp:Content>
<%--declaration d'une reclamation--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Panel ID="Panel2" runat="server">
        <h3 class="text-center text-info">
            <strong>Suivie des evaluations des enseignements par les etudiants</strong></h3>
    </asp:Panel>
    <div class="row">
        <div class="col-xs-3">
        </div>
        <div class="col-xs-6">
            <div class="row">
                <div class="container">
                    <div class="form-group">
                        <div class="form-inline">
                            <div class="form-group">
                                <br />
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="form-inline">
                            <div class="form-group">
                                <asp:Label ID="Label3" CssClass="text-inf h4" runat="server" Text="Classe :"></asp:Label>
                            </div>
                            <div class="form-group pull-right">
                                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1"
                                    AppendDataBoundItems="True" DataTextField="CODE_CL" DataValueField="CODE_CL"
                                    AutoPostBack="True">
                                    <asp:ListItem>Choisir Une classe</asp:ListItem>
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                                    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand=" SELECT distinct(code_cl)  FROM scoesb02.ESP_MODULE_PANIER_CLASSE_SAISO where annee_deb='2013' and code_cl not like 'FU%' and code_cl <> '4TELB2' order by code_cl asc ">
                                    <%-- <SelectParameters>
                                        <asp:SessionParameter Name="ID_ENS" SessionField="ID_ENS" Type="String" />
                                    </SelectParameters>--%>
                                </asp:SqlDataSource>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="form-group">
                        <div class="form-inline">
                            <div class="form-group">
                                <asp:Label ID="Label1" CssClass="text-inf h4" runat="server" Text="Nombre des Etudiants par classe :"
                                    Visible="false"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="form-group pull-right">
                        <asp:FormView ID="formview1" runat="server" DataSourceID="SqlDataSource2">
                            <ItemTemplate>
                                <asp:Label ID="label5" runat="server" Text='<%# Eval("ID_ET") %>' Visible="false" />
                            </ItemTemplate>
                        </asp:FormView>
                        <asp:Label ID="Label6" runat="server" Text="" Visible="false"></asp:Label>
                        <%-- <asp:Label ID="Label7" runat="server" Text="" > </asp:Label>--%>
                        <br />
                        <asp:Label ID="Label2" runat="server" Text="" Visible="false"></asp:Label>
                        <br />
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT count (*) as ID_ET FROM ESP_ETUDIANT, ESP_INSCRIPTION WHERE ESP_ETUDIANT.ID_ET = ESP_INSCRIPTION.ID_ET AND (ESP_INSCRIPTION.CODE_CL = :CODE_CL) AND (ESP_INSCRIPTION.ANNEE_DEB = '2013') AND (ESP_ETUDIANT.ETAT = 'A')">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="DropDownList1" Name="CODE_CL" PropertyName="SelectedValue"
                                    Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </div>
                    <div class="form-group">
                        <div class="form-inline">
                            <div class="form-group">
                                <asp:Label ID="Label9" CssClass="text-inf h4" runat="server" Text="Pourcentage Evaluation :" Visible="false"></asp:Label>
                            </div>
                            <asp:Label ID="Label7" runat="server" Text="" Visible="false"> </asp:Label>
                            <div>
                                <div class="form-group pull-right">
                                    <asp:FormView ID="formview2" runat="server" DataSourceID="SqlDataSource5">
                                        <ItemTemplate>
                                            <asp:Label ID="nbmod" runat="server" Text='<%# Eval("mod") %>' Visible="false" />
                                        </ItemTemplate>
                                    </asp:FormView>
                                    <br />
                                    <br />
                                    <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT count(*) as mod FROM ESP_MODULE_PANIER_CLASSE_SAISO where annee_deb='2013' and code_cl=:CODE_CL">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="DropDownList1" Name="CODE_CL" PropertyName="SelectedValue"
                                                Type="String" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </div>
                            </div>
                        </div>
                        <br />
                        <br />
                        <div class="form-group">
                            <div class="form-inline">
                                <div class="form-group">
                                    <br />
                                    <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource3" Width="926px"
                                        Palette="SemiTransparent" Height="360px">
                                        <Series>
                                            <asp:Series Name="Series1" XValueMember="c_designation" YValueMembers="c_nb_eval">
                                            </asp:Series>
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="ChartArea1" >
                                            </asp:ChartArea>
                                        </ChartAreas>
                                    </asp:Chart>
                                    <br />
                                    <center>
                                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
                                            BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" 
                                            CellPadding="4" DataSourceID="SqlDataSource8">
                                        <Columns>
                                            <asp:BoundField DataField="CODE_CL" HeaderText="CODE_CL" ReadOnly="True" 
                                                SortExpression="CODE_CL" />
                                            <asp:BoundField DataField="C_NB_EVAL" HeaderText="NB_EVALUATION" ReadOnly="True" 
                                                SortExpression="C_NB_EVAL" />
                                            <asp:BoundField DataField="TAUX" HeaderText="TAUX" ReadOnly="True" 
                                                SortExpression="TAUX" />
                                        </Columns>
                                        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                                        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                                        <RowStyle BackColor="White" ForeColor="#330099" />
                                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                                        <SortedAscendingCellStyle BackColor="#FEFCEB" />
                                        <SortedAscendingHeaderStyle BackColor="#AF0101" />
                                        <SortedDescendingCellStyle BackColor="#F6F0C0" />
                                        <SortedDescendingHeaderStyle BackColor="#7E0000" />
                                    </asp:GridView>
                                        <asp:SqlDataSource ID="SqlDataSource8" runat="server" 
                                            ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
                                            ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" 
                                            
                                            SelectCommand=" select code_cl,c_nb_eval,round(taux,2) as Taux from (select code_cl,c_nb_et,c_nb_eval,c_nb_module,((c_nb_eval/(c_nb_module*c_nb_et))*100) as Taux from
(SELECT code_cl,COUNT(*) c_nb_eval ,(SELECT COUNT(*) FROM esp_inscription WHERE annee_deb='2013' AND code_cl = esp_evaluation.code_cl) c_nb_et, 
(SELECT COUNT(*) FROM esp_module_panier_classe_saiso WHERE annee_deb='2013' AND code_cl = esp_evaluation.code_cl) c_nb_module FROM esp_evaluation WHERE annee_deb='2013' and code_cl &lt;&gt; '4TELB2' GROUP BY code_cl) order by Taux DESC)">
                                        </asp:SqlDataSource>
                                    </center>
                                    <br />
                                    <br />
                                     <center>
                                 <asp:GridView ID="GridView2" runat="server"  DataSourceID="SqlDataSource6" OnRowDataBound="GridView2_RowDataBound"  onsorting="GridView2_Sorting" Visible="false"
    CurrentSortField="c_nb_eval" 
    CurrentSortDirection="DESC"  AllowSorting="true"
                                     AutoGenerateColumns="False"    >
                                 <Columns>
                                   <asp:TemplateField HeaderText="Taux"  >
                                <ItemTemplate>
                                    <asp:TextBox ID="txtDS2" runat="server" ></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        
                                     <asp:BoundField DataField="CODE_CL" HeaderText="CODE CLASSE" SortExpression="CODE_CL"
                                         />
                                 
                                     <asp:BoundField DataField="C_NB_EVAL" HeaderText="NB_EVALUATION" ReadOnly="True" 
                                       />
                                     <asp:BoundField DataField="C_NB_ET" HeaderText="NB_ETUDIANT" ReadOnly="True" 
                                          />
                                     <asp:BoundField DataField="C_NB_MODULE" HeaderText="NB_MODULE" 
                                         ReadOnly="True"  />
                               
                        </Columns>
                       
 

                                 </asp:GridView>
                                   <span class="style1"><strong>Nombre Total des evaluations:</strong></span><asp:FormView ID="formview3" runat="server" DataSourceID="SqlDataSource7">
                                    <ItemTemplate>
                                        <asp:Label ID="label9" runat="server" Text='<%# Eval("nbevaltotal") %>'  />
                                    </ItemTemplate>
                                </asp:FormView></center>
                                 <br /><br />
                                    <br />
                                    <center>
                                        <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource4" onrowdatabound="GridView_RowDataBound" Visible="false">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Pourcentage">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtDS1" runat="server"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </center>
                                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
                                        ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
                                        SelectCommand="  SELECT    ESP_MODULE.DESIGNATION  c_designation  ,
(SELECT count(*) 
    FROM ESP_EVALUATION  
   WHERE ( ESP_EVALUATION.ANNEE_DEB = '2013' ) AND  
         ( ESP_EVALUATION.CODE_CL = :CODE_CL  ) AND  
         ( ESP_EVALUATION.CODE_MODULE =ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE) ) c_nb_eval
    FROM ESP_MODULE_PANIER_CLASSE_SAISO,   
         ESP_MODULE  
   WHERE ( ESP_MODULE.CODE_MODULE = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE ) and  
         ( ( ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB = '2013') AND  
         ( ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL = :CODE_CL ) )   
ORDER BY ESP_MODULE.DESIGNATION ASC  ">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="DropDownList1" Name="CODE_CL" PropertyName="SelectedValue"
                                                Type="String" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                    <br />
                                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
                                        ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
                                        SelectCommand="  SELECT    ESP_MODULE.DESIGNATION   c_designation  ,
(SELECT count(*) 
    FROM ESP_EVALUATION  
   WHERE ( ESP_EVALUATION.ANNEE_DEB = '2013' ) AND  
         ( ESP_EVALUATION.CODE_CL = :CODE_CL  ) AND  
         ( ESP_EVALUATION.CODE_MODULE =ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE) ) c_nb_eval
    FROM ESP_MODULE_PANIER_CLASSE_SAISO,   
         ESP_MODULE  
   WHERE ( ESP_MODULE.CODE_MODULE = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE ) and  
         ( ( ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB = '2013' ) AND  
         ( ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL = :CODE_CL ) )   
ORDER BY ESP_MODULE.DESIGNATION ASC   ">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="DropDownList1" Name="CODE_CL" PropertyName="SelectedValue"
                                                Type="String" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                    <br />
                                      <asp:SqlDataSource ID="SqlDataSource6" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
                                    ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" 
                                    SelectCommand="SELECT code_cl,COUNT(*) c_nb_eval ,(SELECT COUNT(*) FROM esp_inscription WHERE annee_deb='2013' AND code_cl = esp_evaluation.code_cl) c_nb_et, (SELECT COUNT(*) FROM esp_module_panier_classe_saiso WHERE annee_deb='2013' AND code_cl = esp_evaluation.code_cl) c_nb_module FROM esp_evaluation WHERE annee_deb='2013' and code_cl &lt;&gt; '4TELB2' GROUP BY code_cl">
                                </asp:SqlDataSource> <br /> <br />
                                <asp:SqlDataSource ID="SqlDataSource7" runat="server" 
                                     ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
                                     ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" 
                                     SelectCommand="select  count(*) nbevaltotal from esp_evaluation where annee_deb='2013'">
                                 </asp:SqlDataSource>
</asp:Content>