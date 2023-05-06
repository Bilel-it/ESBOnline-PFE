<%@ Page Title="" Language="C#" MasterPageFile="~/Enseignants/Ens.Master" AutoEventWireup="true" CodeBehind="Suivi.aspx.cs" Inherits="ESPOnline.Enseignants.Suivi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="../Contents/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="../Contents/Scripts/bootstrap.js" type="text/javascript"></script>
    <style type="text/css">
        .style1
        {
            width: 8%;
        }
        .style2
        {
            width: 12%;
        }
        .style3
        {
            width: 17%;
        }
        .style4
        {
            width: 9%;
        }
        .style5
        {
            width: 77px;
        }
        .style6
        {
            width: 10%;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
        SelectMethod="GetProjByEtudiantProjet" 
        TypeName="ESPSuiviEncadrement.ESP_ENCADDREMENT">
        <SelectParameters>
            <asp:SessionParameter Name="id_proj" SessionField="ID_PROJ" Type="String" />
            <asp:SessionParameter Name="id_et" SessionField="ID_ET" Type="String" />
                
        </SelectParameters>
    </asp:ObjectDataSource>
    
<script type="text/javascript" language="javascript">
    function imprimer() { window.print(); }
</script>
         <div class ="container">
    <asp:Panel ID="Panel1" runat="server">
    <div class ="container">
 <div class="navbar-brand btn-group pull-right"></div>

        <div class="navbar-brand btn-group pull-right">
<asp:Button ID="Button2" runat="server" CssClass="btn btn-success" Text="Imprimer" onclick="Button2_Click"  />
</div>

        <table class="table">
            <tr>
                <td class="style1" rowspan="2">
                    <asp:Label ID="Label1" CssClass="text-info pull-left" runat="server" Text=" ID :"></asp:Label>
                </td>
                <td class="style6" colspan="4" rowspan="2">
                    <asp:Label ID="Label2" runat="server" CssClass="text-primary pull-right" Text=""></asp:Label>
                </td>
                <td class="style4" rowspan="2">
                    &nbsp;</td>
                <td class="style2">
                    <asp:Label ID="Label3" runat="server" CssClass="text-info pull-left" 
                        Text=" Nom Prénom :"></asp:Label>
                </td>
                <td class="style1">
                    <asp:Label ID="Label4" runat="server" CssClass="text-primary pull-right" 
                        Text=""></asp:Label>
                </td>
                <td class="style2"><asp:Label ID="Label19" runat="server" CssClass="text-info pull-left" 
                        Text=""></asp:Label></td>
                        <td class="style3">
                    <asp:Label ID="Label21" runat="server" CssClass="text-primary pull-right" 
                        Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="Label5" runat="server" CssClass="text-info pull-left" 
                        Text=" Matricule"></asp:Label>
                </td>
                <td class="style1">
                    <asp:Label ID="Label6" runat="server" CssClass="text-primary pull-right" 
                        Text=""></asp:Label>
                </td>
                <td class="style2"><asp:Label ID="Label18" runat="server" CssClass="text-info pull-left" 
                        Text=""></asp:Label></td>
                        <td class="style3">
                    <asp:Label ID="Label20" runat="server" CssClass="text-primary pull-right" 
                        Text=""></asp:Label>
                </td>
            </tr>
                    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ObjectDataSource2">
        <HeaderTemplate >
            <tr class="alert-danger">
                <td rowspan="2">
                    <span>
                    <h4>
                        <asp:Label ID="Label7" runat="server" CssClass="text-center text-muted" 
                            Text="Date :"></asp:Label>
                    </h4>
                </td>
                <td colspan="5">
                    <span>
                    <asp:Label ID="Label12" runat="server" CssClass="text-info pull-left" 
                        Text="Avancement :"></asp:Label>
                    </span>
                </td>
                <td rowspan="2">
                    <span>
                    <asp:Label ID="Label13" runat="server" CssClass="text-center text-muted" 
                        Text="Comportement"></asp:Label>
                    </span>
                </td>
                <td rowspan="2">
                    <span>
                    <asp:Label ID="Label14" runat="server" CssClass="text-center text-muted" 
                        Text="Remarque"></asp:Label>
                    </span>
                </td>
                <td rowspan="2">
                    <span>
                    <asp:Label ID="Label15" runat="server" CssClass="text-center text-muted" 
                        Text="Travail demandé"></asp:Label>
                    </span>
                </td>
                <td rowspan="2">
                    <span>
                    <asp:Label ID="Label17" runat="server" CssClass="text-center text-muted" 
                        Text="Date Prochaine Seance"></asp:Label>
                    </span>
                </td>
            </tr>

            <tr class="alert-danger">
                <td class="style10">
                    <span>
                    <asp:Label ID="Label8" runat="server" CssClass="text-info pull-left" 
                        Text="Technique"></asp:Label>
                    </span>
                </td>
                <td class="style12">
                    <span>
                    <asp:Label ID="Label9" runat="server" CssClass="text-info pull-left" 
                        Text="Anglais"></asp:Label>
                    </span>
                </td>
                <td class="style11">
                    <span>
                    <asp:Label ID="Label10" runat="server" CssClass="text-info pull-left" 
                        Text="Français"></asp:Label>
                    </span>
                </td>
                <td class="style11">
                    <span>
                    <asp:Label ID="Label11" runat="server" CssClass="text-info pull-left" 
                        Text="Rapport"></asp:Label>
                    </span>
                </td>
                <td class="style11">
                    <span>
                    <asp:Label ID="Label16" runat="server" CssClass="text-info pull-left" 
                        Text="General"></asp:Label>
                    </span>
                </td>
            </tr>
            </tr>
            </HeaderTemplate>
            <ItemTemplate>
            <tr>
                <td>
                    <%# DataBinder.Eval(Container.DataItem, "HEURE_DEB")%></td>
                <td>
                    <%# DataBinder.Eval(Container.DataItem, "AV_TECH")%></td>
                <td>
                    <%# DataBinder.Eval(Container.DataItem, "AV_ANG")%></td>
                <td>
                    <%# DataBinder.Eval(Container.DataItem, "AV_FR")%></td>
                <td>
                    <%# DataBinder.Eval(Container.DataItem, "AV_FR")%></td>
                    <td>
                    <%# DataBinder.Eval(Container.DataItem, "AV_RAPPORT")%></td>
                <td>
                    <%# DataBinder.Eval(Container.DataItem, "AV_CC")%></td>
                <td>
                    <%# DataBinder.Eval(Container.DataItem, "REMARQUE_OBS")%></td>
                <td>
                    <%# DataBinder.Eval(Container.DataItem, "TRAVAUX_DEMANDE")%></td>
                <td>
                    <%# DataBinder.Eval(Container.DataItem, "DATE_ENC")%></td>
            </tr>
            </tr>
            </ItemTemplate>
            <FooterTemplate>
            </table>
            </FooterTemplate>
        </asp:Repeater>
             </asp:Panel>
             </div>
</asp:Content>