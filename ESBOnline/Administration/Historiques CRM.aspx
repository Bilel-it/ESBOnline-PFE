<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/Administration.Master" AutoEventWireup="true" CodeBehind="Historiques CRM.aspx.cs" Inherits="ESPOnline.Administration.Historiques_CRM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title></title>
    <script src="../Contents/jquery.js" type="text/javascript"></script>
    <%--<link href="../Contents/Css/datetimepicker.css" rel="stylesheet" type="text/css" />--%>
    <link href="../Contents/animate.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />
    <%--<link href="../Contents/Css/bootstrap-theme.css" rel="stylesheet" type="text/css" />--%>
    <script src="../Contents/bootstrap.js" type="text/javascript"></script>
    <script src="../Contents/bootstrap.min.js" type="text/javascript"></script>
    <%-- <script src="../Contents/Scripts/bootstrap-datetimepicker.min.js" type="text/javascript"></script>
    <script src="../Contents/Scripts/bootstrap-datetimepicker.js" type="text/javascript"></script>--%>
        
    <%--journal reclamation--%>
  </asp:Content>
  <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <asp:Panel ID="Panel2" runat="server">
  <h3 class="text-center text-info"><strong>Journal Reclamation</strong></h3>
  </asp:Panel>
      <div class="row">
        <div class="col-xs-4">
         </div>
        <div class="col-xs-4">
            <div class="row">
                <div class="container">
                    <div class="form-group">
                        <div class="form-inline">
                            <div class="form-group">
                                <asp:Panel ID="Panel1" CssClass="text-info h4" runat="server">
                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                                        onselectedindexchanged="RadioButtonList1_SelectedIndexChanged" 
                                        AutoPostBack="True">
                                     <asp:ListItem>Historiques Reclamations</asp:ListItem>
                                     <asp:ListItem>Suivi Reclamations</asp:ListItem>
                                    </asp:RadioButtonList>
                                      <br />
                                </asp:Panel>
                                <asp:Panel ID="Panel4" runat="server" Visible="False">
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                        DataSourceID="SqlDataSource1" 
                                        onselectedindexchanged="GridView1_SelectedIndexChanged" BackColor="White" 
                                        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                                        GridLines="Vertical">
                                        <AlternatingRowStyle BackColor="#DCDCDC" />
                                        <Columns>
                                            <asp:BoundField DataField="EXPR1" HeaderText="EXPR1" 
                                                SortExpression="EXPR1" ReadOnly="True" />
                                            <asp:BoundField DataField="TYPE_RECLAMATION" HeaderText="TYPE_RECLAMATION" 
                                                SortExpression="TYPE_RECLAMATION" />
                                        </Columns>
                                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                        <SortedAscendingHeaderStyle BackColor="#0000A9" />
                                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                        <SortedDescendingHeaderStyle BackColor="#000065" />
                                    </asp:GridView>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                                        
                                         
                                         SelectCommand="SELECT COUNT(TYPE_RECLAMATION) AS EXPR1, TYPE_RECLAMATION FROM scoesb02.ENTETE_RECLAMATION GROUP BY TYPE_RECLAMATION ORDER BY TYPE_RECLAMATION">
                                    </asp:SqlDataSource>
                                </asp:Panel>
                                  <asp:Button ID="LinkButton11" CssClass="btn btn-group-justified btn-success" runat="server"  
                                Text="Diagrammes Reclamations" onclick="LinkButton11_Click"></asp:Button>
                                 <asp:Panel ID="Panel3" runat="server" Visible="False">
                                  <%--<asp:Chart ID="Chart1" runat=server DataSourceID="SqlDataSource2" Width="669px"><Series>
                                      <asp:Series Name="Series1" YValueMembers="EXPR1" 
                                          XValueMember="TYPE_RECLAMATION"></asp:Series></Series><ChartAreas><asp:ChartArea
                                   Name="ChartArea1"></asp:ChartArea></ChartAreas></asp:Chart>                                 
                                     <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                                         ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                                         ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                                         SelectCommand="SELECT COUNT(TYPE_RECLAMATION) AS EXPR1, TYPE_RECLAMATION FROM scoesb02.ENTETE_RECLAMATION GROUP BY TYPE_RECLAMATION ORDER BY TYPE_RECLAMATION">
                                     </asp:SqlDataSource>--%>
                                 </asp:Panel>
                                 <script type="text/javascript" language="javascript">
                                     function openModal() {
                                         $('#Modal1').modal('show');
                                     }
                                 </script>

    <%--historiques reclamations--%>
<div class="modal fade" id="Modal1" role="dialog">
                    <asp:Panel ID="panel5" class="modal-dialog" runat="server" Height="419px">
                         <div class="modal-content">
                            <div class="modal-header">                           
                              <%--</div>
                                 <div class="modal-body">--%>
                                
                                     <div class="text-danger h2"><center><b><i>Historiques Reclamations</i></b></center></div>                                
                                    </div>
                              <div class="modal-body">
                               <div class="form-group">
                                   <div class="form-inline">
                                      <div class="form-group">

                                          <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                                              DataSourceID="SqlDataSource3" CellPadding="4" ForeColor="#333333" 
                                              GridLines="None" onselectedindexchanged="GridView2_SelectedIndexChanged">
                                              <AlternatingRowStyle BackColor="White" />
                                              <Columns>
                                                  <asp:BoundField DataField="TRAITER" HeaderText="TRAITER" 
                                                      SortExpression="TRAITER" />
                                                  <asp:BoundField DataField="UTILISATEUR" HeaderText="UTILISATEUR" 
                                                      SortExpression="UTILISATEUR" />
                                                  <asp:BoundField DataField="NOM_ENS" HeaderText="NOM_ENS" 
                                                      SortExpression="NOM_ENS" />
                                              </Columns>
                                              <EditRowStyle BackColor="#2461BF" />
                                              <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                              <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                              <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                              <RowStyle BackColor="#EFF3FB" />
                                              <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                              <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                              <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                              <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                              <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                          </asp:GridView>
                                            <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                                              ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                                              ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                                              SelectCommand="SELECT &quot;TRAITER&quot;, &quot;UTILISATEUR&quot;, &quot;NOM_ENS&quot; FROM &quot;RECLAMATIONN&quot;">
                                          </asp:SqlDataSource>
                                               <br />
                                          <br />
                                          <br />
                                               </div>
                                                                       
                                    <asp:Button ID="Button8" CssClass="btn btn-default " runat="server" Text="Annuler" />
                                        </div>
                                    </div>
                                </div> 
                                        
                                 </asp:Panel>
                                </div>
                            </div>
                        </div>


                                
     </div>
   </div>
</asp:Content>