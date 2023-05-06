<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/Administration.Master"
    AutoEventWireup="true" CodeBehind="ReclamationNOV.aspx.cs" Inherits="ESPOnline.Administration.ReclamationNOV" %>

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel2" runat="server">
        <h3 class="text-center text-info">
            <strong>Traitement Reclamation</strong></h3>
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
                            </div>
                        </div>
                    </div>
                </div>
                <div class="container">
                    <div class="form-group">
                        <div class="form-inline">
                            <div class="form-group">
                                <center>
                                    <asp:Label ID="Label9" runat="server" CssClass="text-info h4" Text="Suivi Reclamation Enseignant"></asp:Label>
                                </center>
                                <div class="form-group pull-right">
                                    <%--<asp:DropDownList ID="DropDownList5" CssClass="form-control" runat="server" AutoPostBack="True"
                                    DataSourceID="ObjectDataSource1" DataTextField="DATE_RECLAMATION" DataValueField="DATE_RECLAMATION"
                                    OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged">
                                </asp:DropDownList>--%>
                                    <asp:ScriptManager ID="ScriptManager2" runat="server">
                                    </asp:ScriptManager>
                                    <%--            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="listerEntete_Reclamation"
                                    TypeName="BLL.EnteteService" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>
                            </div>
                        </div>
                    </div>
                </div>--%>
                                    <center>
                                        <div class="container">
                                            <div class="form-group">
                                                <div class="form-inline">
                                                    <div class="form-group">
                                                        <%-- <asp:ObjectDataSource ID="ObjectDataSource6" runat="server" SelectMethod="listerEntete_ReclamationParnom"
                                    TypeName="BLL.EnteteService" DataObjectTypeName="DAL.ENTETE_RECLAMATION" UpdateMethod="modifierEntete_Reclamation">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="DropDownList5" Name="nom" PropertyName="SelectedValue"
                                            Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>--%>
                                                        <br />
                                                        <br />
                                                        <asp:GridView ID="GridView1" CssClass="form-control" runat="server" AutoGenerateColumns="False"
                                                            DataSourceID="SqlDataSource2" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                                                            BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                                                            DataKeyNames="ID_ENTETE_RECLAMATION,ID_ENS">
                                                            <Columns>
                                                                <asp:CommandField ShowSelectButton="True" />
                                                                <asp:BoundField DataField="NOM_ENS" HeaderText="NOM_ENS" SortExpression="NOM_ENS" />
                                                                <asp:BoundField DataField="TYPE_RECLAMATION" HeaderText="TYPE_RECLAMATION" SortExpression="TYPE_RECLAMATION" />
                                                                <asp:BoundField DataField="DATE_RECLAMATION" HeaderText="DATE_RECLAMATION" SortExpression="DATE_RECLAMATION" />
                                                                <asp:BoundField DataField="DESIGNATION" HeaderText="DESIGNATION" SortExpression="DESIGNATION" />
                                                            </Columns>
                                                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                                            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                                                            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                                            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                                            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                                            <SortedDescendingHeaderStyle BackColor="#242121" />
                                                            <EditRowStyle BackColor="#999999" />
                                                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                        </asp:GridView>
                                    </center>
                                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT * FROM &quot;ENTETE_RECLAMATION&quot;WHERE DATE_RECLAMATION > SYSDATE -0.5">
                                    </asp:SqlDataSource>
                                    <%--        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="listerEntete_ReclamationParDate"
                                    TypeName="BLL.EnteteService" OldValuesParameterFormatString="original_{0}">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="DropDownList5" Name="date" PropertyName="SelectedValue"
                                            Type="DateTime" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>--%>
                                    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="listerEntete_Reclamation"
                                        TypeName="BLL.EnteteService"></asp:ObjectDataSource>
                                    </br>
                                    <asp:GridView ID="GridView2" CssClass="form-control" runat="server" AutoGenerateColumns="False"
                                        DataSourceID="SqlDataSource3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                                        BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" OnSelectedIndexChanged="GridView2_SelectedIndexChanged"
                                        DataKeyNames="ID_RECLAMTION">
                                        <Columns>
                                            <asp:BoundField DataField="TRAITER" HeaderText="TRAITER" SortExpression="TRAITER" />
                                            <asp:BoundField DataField="UTILISATEUR" HeaderText="UTILISATEUR" SortExpression="UTILISATEUR" />
                                            <asp:BoundField DataField="NOM_ENS" HeaderText="NOM_ENS" SortExpression="NOM_ENS" />
                                        </Columns>
                                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                        <SortedDescendingHeaderStyle BackColor="#242121" />
                                        <EditRowStyle BackColor="#999999" />
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    </asp:GridView>
                                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT * FROM &quot;RECLAMATIONN&quot;WHERE DATE_TRAITEMENT > SYSDATE -0.5">
                                    </asp:SqlDataSource>
                                    <asp:Button ID="Button1" CssClass="btn btn-danger " runat="server" Text="Envoyer Notification Reclamation"
                                        OnClick="Button1_Click1" />
                                </div>
                            </div>
                    </div>
                </div>
                <script type="text/javascript" language="javascript">
                    function openModal() {
                        $('#Modal1').modal('show');
                    }
                </script>
                <div class="modal fade" id="Modal1" role="dialog">
                    <asp:Panel ID="panel5" class="modal-dialog" runat="server">
                        <div class="modal-content">
                            <div class="modal-header">
                                <div class="text-danger h2">
                                    <center>
                                        <b><i>Envoyer Notification Reclamation</i></b></center>
                                </div>
                            </div>
                            <div class="modal-body">
                                <div class="form-group">
                                    <div class="form-inline">
                                        <div class="form-group">
                                            <asp:Label ID="Label40" CssClass="control-label text-info h4" runat="server" Text="Enseignant :"></asp:Label>
                                        </div>
                                        <div class="form-group pull-right">
                                            <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server" AutoPostBack="True"
                                                DataSourceID="SqlDataSource1" DataTextField="NOM_ENS" DataValueField="NOM_ENS"
                                                OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="202px">
                                            </asp:DropDownList>
                                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                                                ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT unique (NOM_ENS) FROM &quot;ENTETE_RECLAMATION&quot;">
                                            </asp:SqlDataSource>
                                            <asp:ObjectDataSource ID="ObjectDataSource7" runat="server" SelectMethod="listerEntete_Reclamation"
                                                TypeName="BLL.EnteteService"></asp:ObjectDataSource>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="form-inline">
                                        <div class="form-group">
                                            <asp:Label ID="Label6" CssClass="text-info h4" runat="server" Text="Email :"></asp:Label>
                                        </div>
                                        <div class="form-group pull-right">
                                            <asp:TextBox ID="TextBox1" Width="202px" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="form-inline">
                                        <div class="form-group">
                                            <asp:Label ID="Label7" CssClass="text-info h4" runat="server" Text="Password :"></asp:Label>
                                        </div>
                                        <div class="form-group pull-right">
                                            <asp:TextBox ID="TextBox3" Width="202px" TextMode="Password" placeholder="Mot de passe"
                                                runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="form-inline">
                                        <div class="form-group">
                                            <asp:Label ID="Label1" CssClass="text-info h4" runat="server" Text="To :"></asp:Label>
                                        </div>
                                        <div class="form-group pull-right">
                                            <asp:TextBox ID="TextBox4" Width="202px" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="form-inline">
                                        <div class="form-group">
                                            <asp:Label ID="Label8" runat="server" CssClass="text-info h4" Text="Traiter"></asp:Label>
                                        </div>
                                        <div class="form-group pull-right">
                                            <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control" AutoPostBack="false"
                                                Width="202px">
                                                <asp:ListItem Value="0">Choisir</asp:ListItem>
                                                <asp:ListItem>traiter</asp:ListItem>
                                                <asp:ListItem>non traiter</asp:ListItem>
                                                <asp:ListItem>en cours</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="form-inline">
                                        <div class="form-group">
                                            <asp:Label ID="Label11" runat="server" CssClass="text-info h4" Text="Description"></asp:Label>
                                        </div>
                                        <div class="form-group pull-right">
                                            <br />
                                            <asp:TextBox ID="TextBox7" runat="server" TextMode="MultiLine" Width="500px"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <br />
                                <br />
                                <br />
                                <div class="form-group">
                                    <div class="form-inline">
                                        <div class="form-group">
                                            <asp:Label ID="Label12" runat="server" CssClass="text-info h4" Text="Utilisateur"></asp:Label>
                                        </div>
                                        <div class="form-group pull-right">
                                            <asp:DropDownList ID="DropDownList4" runat="server" CssClass="form-control" AutoPostBack="false"
                                                Width="202px">
                                                <asp:ListItem Value="0">Choisir</asp:ListItem>
                                                <asp:ListItem>Farouk</asp:ListItem>
                                                <asp:ListItem>Mohamed</asp:ListItem>
                                                <asp:ListItem>Nizar</asp:ListItem>
                                                <asp:ListItem>Omar</asp:ListItem>
                                                <asp:ListItem>Ahmed</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="form-inline">
                                        <div class="form-group">
                                            <asp:Label ID="lblResult" runat="server"></asp:Label>
                                            <div class="modal-footer">
                                                <div class="btn-group">
                                                    <asp:Button ID="LinkButton155" CssClass="btn btn-danger " runat="server" Text="Notification Enseignant"
                                                        OnClick="LinkButton155_Click" />
                                                    <asp:Button ID="Button8" CssClass="btn btn-default " runat="server" Text="Annuler" />
                                                </div>
                                            </div>
                                        </div>
                    </asp:Panel>
                </div>
                <div class="col-xs-3">
                </div>
</asp:Content>
