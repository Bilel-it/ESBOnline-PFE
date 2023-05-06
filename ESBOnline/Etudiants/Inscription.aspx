<%--<%@ Page Title="" Language="C#" MasterPageFile="~/Etudiants/Eol.Master" AutoEventWireup="true"
    CodeBehind="Inscription.aspx.cs" Inherits="ESPOnline.Etudiants.Inscription" %>

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel2" runat="server">
        <h3 class="text-center text-info">
            <strong>Bienvenue à la page d&#39;inscription à la certification CCNA4 session 2013/2014
            </strong>
        </h3>
    </asp:Panel>
    <div class="row">
        <div class="col-xs-3">
        </div>
        <div class="col-xs-6">
            <h5 class="text-danger center">
                * Veuillez choisir votre date de passage de la certification</h5>
            <h5 class="text-danger center">
                * Après validation, vos choix ne seront plus modifiable</h5>
            <h5 class="text-danger center">
                * Le nombre d'inscription ne doit pas dépasser 15 personnes
            </h5>
            <h5 class="text-danger center">
                * Veuillez récupérer le jeton afin de confirmer votre inscription
            </h5>
            <div class="row">
                <div class="container">
                    <div class="form-group">
                        <div class="form-inline">
                            <div class="form-inline">
                                <br />
                            </div>
                        </div>
                    </div>
                    <asp:Panel ID="Panel3" runat="server">
                        <div class="form-group">
                            <div class="form-inline">
                                <div class="form-group">
                                    <asp:Label ID="Label23" runat="server" CssClass="text-info h4" Text="Nom Etudiant :"></asp:Label>
                                </div>
                                <div class="form-group pull-right">
                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" Height="30px" Width="202px"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="form-inline">
                                <div class="form-group">
                                    <asp:Label ID="Label1" CssClass="text-info h4" runat="server" Text="Prenom Etudiant :"></asp:Label>
                                </div>
                                <div class="form-group pull-right">
                                    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" Width="202px"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="form-inline">
                                <div class="form-group">
                                    <asp:Label ID="Label2" CssClass="text-info h4" runat="server" Text="Adresse Etudiant :"></asp:Label>
                                </div>
                                <div class="form-group pull-right">
                                    <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" OnTextChanged="TextBox3_TextChanged"
                                        Width="202px"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="form-inline">
                                <div class="form-group">
                                    <asp:Label ID="Label5" runat="server" CssClass="control-label text-info h4" Text="Choisir Heure :"></asp:Label>
                                </div>
                                <div class="form-group pull-right">
                                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Width="202px"
                                        CssClass="form-control" DataTextField="HEURE" DataValueField="HEURE" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                        <asp:ListItem>Choisir</asp:ListItem>
                                        <asp:ListItem>09:00</asp:ListItem>
                                        <asp:ListItem>11:00 </asp:ListItem>
                                         <asp:ListItem>14:00 </asp:ListItem>
                                         
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="form-inline">
                                <div class="form-group">
                                    <asp:Label ID="Label13" runat="server" CssClass="control-label text-info h4" Text="Choisir Date :"></asp:Label>
                                </div>
                                <div class="form-group pull-right">
                                    <asp:DropDownList ID="DropDownList3" runat="server" AppendDataBoundItems="true" AutoPostBack="true"
                                        Width="202px" CssClass="form-control" DataSourceID="SqlDataSource2" DataTextField="DATE_CERT"
                                        DataTextFormatString="{0:dd/MM/yyyy}" DataValueField="DATE_CERT" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
                                        ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
                                        SelectCommand="SELECT UNIQUE date_cert FROM &quot;COMPT_CERT&quot;"></asp:SqlDataSource>
                                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                                        OnSelecting="ObjectDataSource1_Selecting" SelectMethod="listerCOMPT_CERT" TypeName="BLL.COMPT_CERTSERVICES">
                                    </asp:ObjectDataSource>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="form-inline">
                                
                                <div class="form-group pull-right">
                                    <asp:DropDownList ID="DropDownList4" runat="server" CssClass="form-control" Width="202px"
                                        DataSourceID="SqlDataSource4" DataTextField="NOM_JETON" DataValueField="NOM_JETON"
                                        Visible="False">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
                                        ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
                                        SelectCommand="SELECT UNIQUE (NOM_JETON) FROM JETON WHERE (NOM_JETON NOT IN (SELECT NOM_JETON FROM scoesb02.ESP_CCNA3))and rownum &lt;= 1">
                                    </asp:SqlDataSource>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="form-inline">
                                <div class="form-group">
                                    <asp:Label ID="Label6" CssClass="text-info h4" runat="server" Text="Nombre d'Inscription :"></asp:Label>
                                    <asp:Label ID="LabCount" runat="server"></asp:Label>
                                    <br />
                                    <br />
                                    <br />
                                </div>
                                <div class="form-group pull-right">
                                    <br />
                                    <asp:Button ID="LinkButton11" CssClass="btn btn-group-justified btn-success" runat="server"
                                        Text="Envoyer" OnClick="LinkButton11_Click"></asp:Button>
                    </asp:Panel>
                    <br />
                </div>
            </div>
        </div>
        <br />
        <br />
        <br />
        <br />
        <center>
                                 <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" 
                                     AutoGenerateColumns="False" DataKeyNames="NOM_JETON" 
                         Width="454px" CellPadding="4" ForeColor="#333333" GridLines="None" 
                         onselectedindexchanged="GridView1_SelectedIndexChanged">
                                     <AlternatingRowStyle BackColor="White" />
                                     <Columns>
                                         <asp:BoundField DataField="DATE_INS" HeaderText="DATE_INS" 
                                             SortExpression="DATE_INS" />
                                         <asp:BoundField DataField="HEURE_INS" HeaderText="HEURE_INS" 
                                             SortExpression="HEURE_INS" />
                                         <asp:BoundField DataField="NOM_JETON" HeaderText="NOM_JETON" ReadOnly="True" 
                                             SortExpression="NOM_JETON" />
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
                                 </asp:GridView>
                          
                                 <br />
                                 </center>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
            ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
            SelectCommand="SELECT * FROM &quot;ESP_CCNA3&quot; WHERE (&quot;ID_ET&quot; = :ID_ET)">
            <SelectParameters>
                <asp:SessionParameter Name="ID_ET" SessionField="ID_ET" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <center>
        <asp:Panel ID="Panel1" runat="server" Visible="False">
            <asp:Button ID="LinkButton10" CssClass="btn btn-group-justified btn-primary" runat="server"
                OnClick="LinkButton10_Click" Text="Lien vers Cisco" Width="338px"></asp:Button>
        </asp:Panel>
        </center>
        <div class="col-xs-3">
        </div>
    </div>
</asp:Content>
--%>