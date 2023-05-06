<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EntretienSession3.aspx.cs" Inherits="ESPOnline.Enseignants.EntretienSession3" MasterPageFile="~/Enseignants/Ens.Master" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <%-- <link href="../Contents/Css/bootstrap.min.css" rel="stylesheet" type="text/css" />
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
            width: 176px;
        }
        .style4
        {
            height: 70px;
        }
        .style5
        {
            color: #CC0000;
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
    </script>--%>
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
                    <span class="style5"><strong>ENTRETIEN D&#39;ADMISSION</strong></span><br />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <center>
                       <table class="style1">
            <tr>
                <td>
              
                </td> <td align="center"><asp:Label ID="Label6" runat="server" Text="Chercher un candidat" Font-Bold="True"></asp:Label></td> <td></td></tr></table>
                    <table class="style1">
            <tr>
                <td align="center">
                  
                   <asp:Label ID="Label4" runat="server" Text="Remarque:Pour les 3A, les étudiants doivent maitriser:JAVA, UML, C, C++, Réseaux, BD.." style="color: #FF0000" visible="false"></asp:Label>
                </td> <td align="center"></td> <td></td></tr></table>
                        
                        <asp:Panel ID="Panel1" runat="server">
                            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                            </telerik:RadScriptManager>
                            <%-- <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
                            <telerik:RadComboBox ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2"
                                DataTextField="cc" DataValueField="ID_ET" EmptyMessage="Tapez le Nom ou CIN "
                                Filter="Contains" Width="300" MaxHeight="400" DropDownWidth="500" EnableLoadOnDemand="True"
                                ShowMoreResultsBox="False" HighlightTemplatedItems="True" AutoPostBack="True">
                            </telerik:RadComboBox>
                            <br />
                            <asp:DropDownList ID="Ddlchoix3" runat="server" AutoPostBack="true" required="" ValidationGroup="valid"
                                Visible="false" CssClass="style3">
                                <asp:ListItem Value="">Choisir Type Classe</asp:ListItem>
                                <asp:ListItem Value="3A">3A</asp:ListItem>
                                <asp:ListItem Value="3B">3B</asp:ListItem>
                                <asp:ListItem Value="AB">À vérifier</asp:ListItem>
                            </asp:DropDownList>
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
                                                   Qualité d'expression <br />
                                                    en français
                                                </td>
                                                <td>
                                                    Qualité d'expression<br />
                                                   en anglais
                                                </td>
                                                <td>
                                                    Motivation
                                                </td>
                                                <td>
                                                    Culture Générale
                                                </td>

                                                 <td>
                                                   Bonus
                                                </td>
                                                <td rowspan="2">
                                                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Calculer note" />
                                                </td>
                                                <td class="style3">
                                                    Note sur 100
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Note
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="DropDownList2" runat="server">
                                                     <asp:ListItem>0</asp:ListItem>
                                                        <asp:ListItem>1</asp:ListItem>
                                                        <asp:ListItem>2</asp:ListItem>
                                                        <asp:ListItem>3</asp:ListItem>
                                                        <asp:ListItem>4</asp:ListItem>
                                                        <%--<asp:ListItem>5</asp:ListItem>--%>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="DropDownList5" runat="server">
                                                     <asp:ListItem>0</asp:ListItem>
                                                        <asp:ListItem>1</asp:ListItem>
                                                        <asp:ListItem>2</asp:ListItem>
                                                        <asp:ListItem>3</asp:ListItem>
                                                        <asp:ListItem>4</asp:ListItem>
                                                        <%-- <asp:ListItem>5</asp:ListItem>--%>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="DropDownList6" runat="server">
                                                     <asp:ListItem>0</asp:ListItem>
                                                        <asp:ListItem>1</asp:ListItem>
                                                        <asp:ListItem>2</asp:ListItem>
                                                        <asp:ListItem>3</asp:ListItem>
                                                        <asp:ListItem>4</asp:ListItem>
                                                        <asp:ListItem>5</asp:ListItem>
                                                       
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="DropDownList7" runat="server">
                                                     <asp:ListItem>0</asp:ListItem>
                                                        <asp:ListItem>1</asp:ListItem>
                                                        <asp:ListItem>2</asp:ListItem>
                                                        <asp:ListItem>3</asp:ListItem>
                                                        <asp:ListItem>4</asp:ListItem>
                                                        <asp:ListItem>5</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>

                                                  <td>
                                                    <asp:DropDownList ID="DropDownList3" runat="server">
                                                     <asp:ListItem>0</asp:ListItem>
                                                        <asp:ListItem>1</asp:ListItem>
                                                        <asp:ListItem>2</asp:ListItem>
                                                      
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="style3">
                                                    &nbsp;<asp:TextBox ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style4">
                                                    Observation
                                                </td>
                                                <td colspan="6" dir="ltr" class="style4">
                                                    <asp:TextBox ID="TextBox2" runat="server" Height="52px" Width="693px" TextMode="MultiLine"></asp:TextBox>
                                                </td>
                                            </tr>
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


                                     </tr>
                                <td>  &nbsp;</td>
                                <tr>
                                    <td></td>
                                   <td><strong>Veuillez choisir:</strong>
                                      <asp:RadioButtonList runat="server" ID="chkcompetences" DataSourceID="SqlDataSource16"
                                        RepeatDirection="Horizontal" DataTextField="lib_nome" DataValueField="code_nome">
                                          </asp:RadioButtonList>

                                   </td>

                                </tr>
                                <tr>
                                    <td></td>
                                    <td>
                                        <asp:Button ID="Button3" runat="server" Height="50px" OnClick="butsubmit_Click" Text="Enregistrer"
                                            CssClass="btn-lg btn-danger" Width="150px" />
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                            <br />
                    </center>



                     <asp:SqlDataSource 
        ID="SqlDataSource16" 
        runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString2%>"
        ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>"
        SelectCommand="SELECT CODE_NOME,LIB_nome from code_nomenclature where  code_str='80'">
    </asp:SqlDataSource>





                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>"
                        ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT Id_et,num_cin_passeport as CIN,trim(upper(nom_et))||' '|| trim(pnom_et) nom_prenom,MOY_BAC,ANNEE_BAC,(select lib_nome 
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
                            ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT trim(NOM_ET)||'  '||trim(PNOM_ET)||'  '||trim(NUM_CIN_PASSEPORT) cc, ID_ET FROM ESP_ETUDIANT WHERE score_entretien is null and ID_ET LIKE '%T%'  and TRIM(ID_ET) LIKE '22%' ">
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
