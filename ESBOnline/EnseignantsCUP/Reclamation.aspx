<%@ Page Title="" Language="C#" MasterPageFile="~/EnseignantsCUP/Cup.Master" AutoEventWireup="true" CodeBehind="Reclamation.aspx.cs" Inherits="ESPOnline.EnseignantsCUP.Reclamation" %>
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <asp:Panel ID="Panel2" runat="server">
        <h3 class="text-center text-info">
            <strong>Envoyer Reclamation</strong></h3>
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
                                <asp:Label ID="Label3" CssClass="text-inf h4" runat="server" Text="Enseignant :"></asp:Label>
                            </div>
                            <div class="form-group pull-right">
                                <asp:TextBox ID="TextBox123" runat="server" CssClass="form-control" Width="202px"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                     <div class="form-group">
                        <div class="form-inline">
                            <div class="form-group">
                                <asp:Label ID="Label6" CssClass="text-inf h4" runat="server" Text="Email :"></asp:Label>
                            </div>
                            <div class="form-group pull-right">
                                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" Width="202px"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                     <div class="form-group">
                        <div class="form-inline">
                            <div class="form-group">
                                <asp:Label ID="Label7" CssClass="text-inf h4" runat="server" Text="Password :"></asp:Label>
                            </div>
                            <div class="form-group pull-right">
                                <asp:TextBox ID="TextBox3" TextMode="Password" placeholder="Mot de passe"  runat="server" CssClass="form-control" Width="202px" 
                                    ontextchanged="TextBox3_TextChanged"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                       <div class="form-group">
                        <div class="form-inline">
                            <div class="form-group">
                                 <asp:Label ID="Label2" runat="server" CssClass="text-inf h4" Text="Module Reclamation :"></asp:Label>
                                   </div>
                            <div class="form-group pull-right">
                                <asp:DropDownList ID="DropDownList3" CssClass="form-control" runat="server" Width="202px" AutoPostBack="True"
                                    OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
                                    <asp:ListItem Value="Choisir">Choisir</asp:ListItem>
                                    <asp:ListItem Value="Absence">Absence</asp:ListItem>
                                    <asp:ListItem Value="Login">Certification</asp:ListItem>
                                    <asp:ListItem>Encadrement</asp:ListItem>
                                    <asp:ListItem>Scolarité</asp:ListItem>
                                    <asp:ListItem>Evaluation</asp:ListItem>
                                     <asp:ListItem>Accès EOL</asp:ListItem>
                                      <asp:ListItem>BI</asp:ListItem>
                                       <asp:ListItem>Plan Etude</asp:ListItem>
                                    <asp:ListItem Value="Autres">Autres</asp:ListItem>
                                </asp:DropDownList>

                    </div>
                </div>
            </div>
  <%--                   <div class="form-group">
                        <div class="form-inline">
                            <div class="form-group">
                                <asp:Label ID="Label8" CssClass="text-info h4" runat="server" Text="To :"></asp:Label>
                            </div>--%>
                            <div class="form-group pull-right">
                                <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" Width="202px" 
                                    Visible="False"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                   
            <br />
            <asp:Panel ID="Panel1" runat="server">
                <div class="form-group">
                    <div class="form-inline">
                        <div class="form-group">
                            <asp:Label ID="Label1" runat="server" CssClass="control-label text-muted h5" Text="Autre Reclamation"></asp:Label>
                        </div>
                        <div class="form-group pull-right">
                            <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server" Width="202px"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="form-inline">
                        <div class="form-group">
                            <asp:Label ID="Label4" runat="server" CssClass="control-label text-inf h4" Text="Description :"></asp:Label>
                        </div>
                        <div class="form-group pull-right">
                            <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control" Width="500px" 
                                TextMode="MultiLine" Height="103px"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            
            <br />
            <asp:Label ID="lblResult" runat="server"></asp:Label>
            <br />
            <asp:Button ID="Button1" CssClass="btn btn-danger pull-right" runat="server" Width="202px" Text="Envoyer"
                OnClick="Button1_Click" />

                  <br />
                  <br />
            <asp:Panel ID="Panel3" runat="server">
           
                   <h5 class="text-danger center">* Une Nouvelle Notification Reclamation Reçu</h5><asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                
            <asp:DropDownList ID="DropDownList1"  CssClass="form-control" runat="server" Width="202px"
            
                DataSourceID="SqlDataSource3" DataTextField="COUNT(*)" 
                DataValueField="COUNT(*)" 
                onselectedindexchanged="DropDownList1_SelectedIndexChanged3">
            </asp:DropDownList>  
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
                ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" 
                SelectCommand="SELECT count (*) FROM &quot;RECLAMATIONN&quot; WHERE (&quot;NOM_ENS&quot; = :NOM_ENS) and DATE_TRAITEMENT > SYSDATE -0.5">
                <SelectParameters>
                    <asp:SessionParameter Name="NOM_ENS" SessionField="NOM_ENS" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
                   <br>
                   <br>
                   <br>
                   <br></br>
                   <center>
                       <asp:Button ID="LinkButton11" runat="server" 
                           CssClass="btn btn-group-justified btn-success" OnClick="LinkButton11_Click" 
                           Text="Historiques Reclamation" Width="360px" />
                   </center>
                   <br />
                   <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                       CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" 
                       GridLines="None">
                       <AlternatingRowStyle BackColor="White" />
                       <Columns>
                           <asp:BoundField DataField="DESCRIPTION" HeaderText="Réponse Reclamation" 
                               SortExpression="DESCRIPTION" />
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
                   <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                       ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                       ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                       SelectCommand="SELECT &quot;DESCRIPTION&quot; FROM &quot;RECLAMATIONN&quot; WHERE (&quot;NOM_ENS&quot; = :NOM_ENS) and DATE_TRAITEMENT &gt; SYSDATE -0.5">
                       <SelectParameters>
                           <asp:SessionParameter Name="NOM_ENS" SessionField="NOM_ENS" Type="String" />
                       </SelectParameters>
                   </asp:SqlDataSource>
                   <br>
                   <br></br>
                   <br></br>
                   <br></br>
                   </br>
                   </br>
                   </br>
            </br>
         </asp:Panel>
        
            <br />
       
 
    <br />
    <br />
    <div class="row">
    </div>
    <div class="col-xs-3">
    </div>
    <script type="text/javascript" language="javascript">
        function openModalModifier() {
            $('#modifier_projet').modal('show');
        }
    </script>
    <div class="modal fade" id="modifier_projet" role="dialog">
        <div class="modal-content">
            <div class="modal-header">
                <br />
                <div class="text-danger h2">
                    <center>
                        <b><i>Notification Reclamation</i></b></center>
                </div>
            </div>
            <div class="modal-body">
                <div class="form-group">
                    <div class="form-inline">
                        <div class="form-group">
                            <%--GRID ENTETE_RECLAMATION--%>
                            <center>
                            <asp:Panel ID="Panel20" runat="server" Visible="False">
                            <center>
                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                                    DataSourceID="SqlDataSource2" DataKeyNames="ID_RECLAMTION" 
                                    onselectedindexchanged="GridView2_SelectedIndexChanged" CellPadding="4" 
                                    ForeColor="#333333" GridLines="None">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:CommandField ShowSelectButton="True" />
                                        <asp:BoundField DataField="TRAITER" HeaderText="TRAITER" 
                                            SortExpression="TRAITER" />
                                        <asp:BoundField DataField="DATE_TRAITEMENT" HeaderText="DATE_TRAITEMENT" 
                                            SortExpression="DATE_TRAITEMENT" />
                                        <asp:BoundField DataField="DESCRIPTION" HeaderText="DESCRIPTION" 
                                            SortExpression="DESCRIPTION" />
                                        <asp:BoundField DataField="UTILISATEUR" HeaderText="UTILISATEUR" 
                                            SortExpression="UTILISATEUR" />
                                        <asp:BoundField DataField="NOM_ENS" HeaderText="NOM_ENS" 
                                            SortExpression="NOM_ENS" />
                                        <asp:CheckBoxField ReadOnly="True" Text="READ_VALIDE" />
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
                                </center>
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
                                    ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" 
                                    
                                    SelectCommand="SELECT * FROM &quot;RECLAMATIONN&quot; WHERE (NOM_ENS = :NOM_ENS) order by  date_traitement desc">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="NOM_ENS" SessionField="NOM_ENS" Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <div class="modal-footer">
                                    <div class="btn-group">
                                        <asp:Button ID="Button4" CssClass="btn btn-default " runat="server" 
                                            Text="Annuler" onclick="Button4_Click" />
                                </asp:Panel>
                            </center>
                        </div>
                    </div>
                </div>
            </div>
</asp:Content>
