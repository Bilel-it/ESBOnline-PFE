<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SuiviETG.aspx.cs" Inherits="ESPOnline.Enseignants.SuiviETG" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
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
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
        SelectMethod="EVALGetListeEtudiantDansunGroupe" 
        TypeName="ESPSuiviEncadrement.ESP_ETUDIANT_NOTE_GROUPE">
        <SelectParameters>
            <asp:SessionParameter Name="id_gp_pj" SessionField="ID_GROUPE_PROJET" Type="String" />
            <asp:SessionParameter Name="id_et" SessionField="ID_ET" Type="String" />
            
                
        </SelectParameters>
    </asp:ObjectDataSource>
    

<div class ="container">
    <asp:Panel ID="Panel1" runat="server">
    <div class ="container">
 <%--<div class="navbar-brand btn-group pull-right">
 <asp:Button ID="Button1" runat="server" CssClass="btn btn-danger" Text="Retour" onclick="Button1_Click" />
        </div>--%>
<table class="table table-responsive">
            <tr>
                <td class="style1" rowspan="2">
                    <asp:Label ID="Label1" CssClass="text-info pull-left" runat="server" Text=" Nom Du Projet"></asp:Label>
                </td>
                <td class="style6" colspan="4" rowspan="2">
                    <asp:Label ID="Label2" runat="server" CssClass="text-primary text-danger pull-right" Text=""></asp:Label>
                </td>
                <td class="style4" rowspan="2">
                    &nbsp;</td>
                <td class="style2">
                    <asp:Label ID="Label3" runat="server" CssClass="text-info pull-left" 
                        Text=" Nom & Prénom :"></asp:Label>
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
                        <asp:Label ID="Label8" runat="server" CssClass="text-info pull-left" 
                            Text="Suivi Par"></asp:Label>
                    </h4>
                </td>

                <td rowspan="2">
                    <span>
                    <h4>
                        <asp:Label ID="Label7" runat="server" CssClass="text-info pull-left" 
                            Text="Date Evaluation"></asp:Label>
                    </h4>
                </td>
                <td rowspan="2">
                    <span>
                    <h4>
                    <asp:Label ID="Label12" runat="server" CssClass="text-info pull-left" 
                        Text="Les Absences "></asp:Label>
                    </span>
                    </h4>
                </td>
                <td rowspan="2">
                    <span>
                    <h4>
                    <asp:Label ID="Label13" runat="server" CssClass="text-info pull-left" 
                        Text="Les Remarques"></asp:Label>
                        </h4>
                    </span>
                </td>
                <td rowspan="2">
                    <span>
                    <h4>
                    <asp:Label ID="Label14" runat="server" CssClass="text-info pull-left" 
                        Text="Les Notes"></asp:Label>
                        </h4>
                    </span>
                </td>
                
            </tr>

            <tr>
           </tr>
             <tr>
           </tr>
            </HeaderTemplate>
            <ItemTemplate>
            
            <tr class="alert-success" style="vertical-align:middle">
                <td>
                    <%# DataBinder.Eval(Container.DataItem, "ID_ENS")%></td>
                <td>
                    <%# DataBinder.Eval(Container.DataItem, "DATE_EVAL")%></td>
                <td>
                    <%# DataBinder.Eval(Container.DataItem, "ABS_ET")%></td>
                <td>
                    <%# DataBinder.Eval(Container.DataItem, "REMARQUE")%></td>
                <td>
                    <%# DataBinder.Eval(Container.DataItem, "NOTE_ET")%></td>
                
            </tr>
            
            </ItemTemplate>
            <FooterTemplate>
            </table>
            </FooterTemplate>
        </asp:Repeater>


             </asp:Panel>
    
             </div>

    <script type="text/javascript" language="javascript">
        function imprimer() { window.print(); }
</script>
<div class="navbar-brand btn-group pull-right">
<asp:Button ID="Button2" runat="server" CssClass="btn btn-success" Text="Imprimer" onclick="Button2_Click"  />
</div>

    </div>
    </form>
</body>
</html>
