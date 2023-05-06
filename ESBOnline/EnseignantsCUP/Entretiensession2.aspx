<%@ Page Title="" Language="C#" MasterPageFile="~/EnseignantsCUP/Cup.Master" AutoEventWireup="true" CodeBehind="Entretiensession2.aspx.cs" Inherits="ESPOnline.EnseignantsCUP.Entretiensession2" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Contents/Css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />
    <script src="../Contents/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="../Contents/Scripts/bootstrap.js" type="text/javascript"></script>
    <script type="text/javascript" src="../Contents/Scripts/JScript1.js"></script>
    <style type="text/css">
        .RadComboBox
        {
            height: 50px !important;
        }
        .style1
        {
            width: 100%;
            margin-right: 0px;
        }
        .style2
        {
            text-align: center;
        }
        .style3
        {
            width: 395px;
        }
    </style>
    <script language="javascript" type="text/javascript">
        function confirmSubmit() {
            var msg = "Etes-vous sûr que vous voulez sauvegarder les données?";
            if (confirm(msg)) {
                hide.value = "OUI";
            }
            else { hide.value = "Non"; }
        } 
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <%--<asp:button id="butsubmit" text="GO" runat="server"  />--%>
        <input type="hidden" id="hide" runat="server">
        <table class="style1">
            <tr>
                <td>
                    &nbsp;
                </td>
                <td class="style2">
                    <br />
                    <strong>ENTRETIEN D&#39;ADMISSION</strong><br />
                    <br />
                    <br />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                </td>
                <td>
                    <center>
                        &nbsp;<asp:Label ID="Label1" runat="server" Text="Chercher un candidat" Font-Bold="True"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <br />
                        <asp:Panel ID="Panel1" runat="server">
                            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                            </telerik:RadScriptManager>
                            <%-- <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
                            <telerik:RadComboBox ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2"
                                DataTextField="cc" DataValueField="ID_ET" EmptyMessage="Tapez le Nom de l'etudiant "
                                Filter="Contains" Width="300" MaxHeight="400" DropDownWidth="500" EnableLoadOnDemand="True"
                                ShowMoreResultsBox="False" HighlightTemplatedItems="True" AutoPostBack="True">
                            </telerik:RadComboBox>
                            <br />
                            <br />
                        </asp:Panel>
                        <asp:Panel ID="Panel2" runat="server">
                            <table class="style1">
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td colspan="13">
                                        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="true">
                                        </asp:GridView>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td colspan="13">
                                        <asp:Label ID="Label2" runat="server" Text="Ajouter note entretien" Font-Bold="True"></asp:Label>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </td>
                                    <td colspan="13">
                                        <table class="style1" border="5" frame="border">
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                      Langue<br /> et communication française</td>
                                                <td>
                                                     Langue<br /> et communication anglaise</td>
                                                <td>
                                                    Motivation
                                                </td>
                                                <td>
                                                    Culture Générale
                                                </td>
                                                <td rowspan="2">
                                                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Calculer note" />
                                                </td>
                                                <td>
                                                    Note sur 100
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Note
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="DropDownList2" runat="server" >
                                                        <asp:ListItem>1</asp:ListItem>
                                                        <asp:ListItem>2</asp:ListItem>
                                                        <asp:ListItem>3</asp:ListItem>
                                                        <asp:ListItem>4</asp:ListItem>
                                                      <%--  <asp:ListItem>5</asp:ListItem>--%>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="DropDownList5" runat="server">
                                                        <asp:ListItem>1</asp:ListItem>
                                                        <asp:ListItem>2</asp:ListItem>
                                                        <asp:ListItem>3</asp:ListItem>
                                                        <asp:ListItem>4</asp:ListItem>
                                                      <%--  <asp:ListItem>5</asp:ListItem>--%>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="DropDownList6" runat="server">
                                                        <asp:ListItem>1</asp:ListItem>
                                                        <asp:ListItem>2</asp:ListItem>
                                                        <asp:ListItem>3</asp:ListItem>
                                                        <asp:ListItem>4</asp:ListItem>
                                                        <asp:ListItem>5</asp:ListItem>
                                                          <asp:ListItem>6</asp:ListItem>
                                                            <asp:ListItem>7</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="DropDownList7" runat="server">
                                                        <asp:ListItem>1</asp:ListItem>
                                                        <asp:ListItem>2</asp:ListItem>
                                                        <asp:ListItem>3</asp:ListItem>
                                                        <asp:ListItem>4</asp:ListItem>
                                                        <asp:ListItem>5</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    &nbsp;<asp:TextBox ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                             <tr><td>Observation</td><td colspan="6"  dir="ltr">
                                                <asp:TextBox ID="TextBox2" runat="server" Height="82px" Width="693px" 
                                                    TextMode="MultiLine"></asp:TextBox>
                                                </td></tr>
                                        </table>
                                    </td>
                                    <td>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </td>
                                    <td>
                                        &nbsp;&nbsp;&nbsp; &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td class="style3">
                                        <asp:Button ID="Button3" runat="server" Height="26px" OnClick="butsubmit_Click" Text="Enregistrer" />
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                            <br />
                    </center>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>"
                        ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT Id_et,num_cin_passeport,trim(upper(nom_et))||' '|| trim(pnom_et) nom_prenom,MOY_BAC,ANNEE_BAC,(select lib_nome 
from code_nomenclature
where code_str='02'
and code_nome=(select  nature_bac from  ESP_ETUDIANT  where id_et=:ID_ET)) nature_bac,DIPLOME_SUP_ET DIPLOME,ANNEE_DIPLOME,(select lib_nome 
from code_nomenclature
where code_str='03'
and code_nome=(select  SPECIALITE_ESP_ET from  ESP_ETUDIANT where id_et=:ID_ET )) SPECIALITE,NIVEAU_ACCES
FROM ESP_ETUDIANT aa 
where  id_et=:ID_ET
  ">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="DropDownList1" Name="ID_ET" PropertyName="SelectedValue"
                                Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <center>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>"
                            ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT trim(NOM_ET)||'  '||trim(PNOM_ET)||'  '||trim(NUM_CIN_PASSEPORT) cc, ID_ET FROM ESP_ETUDIANT WHERE score_entretien is null and ID_ET LIKE '%T%'  and TRIM(ID_ET) LIKE '19%' ">
                        </asp:SqlDataSource>
                        <br />
                        <br />
                    </center>
                    </asp:Panel> &nbsp;
                </td>
                <td>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <br />
                    <br />
                    <br />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
</asp:Content>