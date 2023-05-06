<%@ Page Title="" Language="C#" MasterPageFile="~/EnseignantsCUP/Cup.Master" AutoEventWireup="true" CodeBehind="Consultation_orientation.aspx.cs" Inherits="ESPOnline.EnseignantsCUP.Consultation_orientation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../Contents/Css/datetimepicker.css" rel="stylesheet" type="text/css" />

    <link href="../Contents/animate.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <script src="../Contents/bootstrap.js" type="text/javascript"></script>
    <script src="../Contents/bootstrap.min.js" type="text/javascript"></script>

    
    <script src="../Contents/Scripts/bootstrap-datetimepicker.min.js" type="text/javascript"></script>
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
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
        SelectCommand="select distinct ch1 as options,substr(code_cl,1,2) as classe, count(*) as nombre_dinscrit from esp_orientation where annee_deb=2014 and code_cl like '3%'group by ch1, substr(code_cl,1,2) order by ch1">
    </asp:SqlDataSource>
  <div align="center">  <table class="style1">
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
  
  
                <table class="style1">
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:GridView ID="GridView2" runat="server"  
                                 DataSourceID="SqlDataSource1" AutoGenerateColumns="False" 
                                >
                                     <Columns>

       
      
              
                                         <asp:BoundField DataField="count(*)" HeaderText="nombre d'inscrit" ReadOnly="True" 
                                             SortExpression="nombre d'inscrit" />
                                        
              
         </Columns>
                               
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                                ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                                SelectCommand="SELECT count(*) FROM &quot;ESP_ORIENTATION&quot; where annee_deb=2014 and code_cl like '3%'">
                            </asp:SqlDataSource>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
  
  
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
         DataSourceID="SqlDataSource3">
        <Columns>

          <%--  <asp:BoundField DataField="b" HeaderText="Classe" ReadOnly="True" 
                SortExpression="Classe" />--%>
            <asp:BoundField DataField="OPTIONS" HeaderText="choix 1" ReadOnly="True" 
                SortExpression="choix 1" />
              
         
            <asp:BoundField DataField="CLASSE" 
                HeaderText="CLASSE" ReadOnly="True" 
                SortExpression="CLASSE" />
            <asp:BoundField DataField="NOMBRE_DINSCRIT" HeaderText="NOMBRE_DINSCRIT" ReadOnly="True" 
                SortExpression="NOMBRE_DINSCRIT" />
              
         
        </Columns>
    </asp:GridView>
                            </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            <table class="style1" style=" border-color: #000000;" 
                                border="2" >
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                       <asp:Label ID="Label48" runat="server" Text="ArcTic (cloud)"></asp:Label>
                                    </td>
                                    <td>
                                        
                                        <asp:Label ID="Label49" runat="server" Text="ERP-BI"></asp:Label>
                                    </td>
                                    <td>
                                        
                                        <asp:Label ID="Label50" runat="server" Text="GL"></asp:Label>
                                    </td>
                                    <td>
                                        
                                        <asp:Label ID="Label51" runat="server" Text="INFINI"></asp:Label>
                                    </td>
                                    <td>
                                        
                                        <asp:Label ID="Label52" runat="server" Text="NIDS (sécurité)"></asp:Label>
&nbsp;</td>
                                    <td>
                                        
                                        <asp:Label ID="Label53" runat="server" Text="SIM"></asp:Label>
                                    </td>
                                    <td>
                                        
                                        <asp:Label ID="Label54" runat="server" Text="SLEAM"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label55" runat="server" Text="WEB(TWIN)"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label56" runat="server" Text="INFO B"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label57" runat="server" Text="IRT"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label58" runat="server" Text="ISEM"></asp:Label>
                                    </td>
                                    <td>
                                       <asp:Label ID="Label59" runat="server" Text="Méca A"></asp:Label>
                                    </td>
                                    <td>
                                       <asp:Label ID="Label60" runat="server" Text="OGI A"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label61" runat="server" Text="Méca B"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label62" runat="server" Text="OGI B"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        choix 1</td>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label15" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label16" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label17" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        choix 2</td>
                                    <td>
                                        <asp:Label ID="Label18" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label19" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label20" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label21" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label22" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label23" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label24" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label25" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label26" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label27" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label28" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label29" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label30" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label31" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label32" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        choix 3</td>
                                    <td>
                                        <asp:Label ID="Label33" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label34" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label35" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label36" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label37" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label38" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label39" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label40" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label41" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label42" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label43" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label44" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label45" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label46" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label47" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Refrech" 
                    CssClass="btn-lg" Width="138px" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table></div>
</asp:Content>
