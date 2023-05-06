<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Entretiensession22.aspx.cs" Inherits="ESPOnline.Direction.Entretiensession22" MasterPageFile="~/Direction/Site112.Master" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<link href="../Contents/Css/bootstrap.min.css" rel="stylesheet" type="text/css" />--%>
  <%--  <link href="../Contents/Css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />--%>
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
    .auto-style1 {
        background-color: #00CCFF;
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

    <br /><br /><br />
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
                            <telerik:RadComboBox ID="Radens" runat="server" DataSourceID="SqlDataSource2020"
                                DataTextField="Nom_ENS" DataValueField="ID_Ens" EmptyMessage="Tapez enseignant" required=""
                                Filter="Contains" Width="300" MaxHeight="400" DropDownWidth="500" EnableLoadOnDemand="True"
                                ShowMoreResultsBox="False" HighlightTemplatedItems="True" AutoPostBack="True" 
                                >
                            </telerik:RadComboBox>

                            <br />
                            <telerik:RadComboBox ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2"
                                DataTextField="cc" DataValueField="ID_ET" EmptyMessage="Tapez le Nom ou CIN "
                                Filter="Contains" Width="300" MaxHeight="400" DropDownWidth="500" EnableLoadOnDemand="True"
                                ShowMoreResultsBox="False" HighlightTemplatedItems="True" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                            </telerik:RadComboBox>
                            <br />
                            <asp:Label id="Label22" runat="server"></asp:Label>
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
                                        <asp:GridView ID="GridView5" runat="server"
                                    visible="false"
                                    
                                     AutoGenerateColumns="false"
                                    Width="550"
                                    DataKeyNames="id_et" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"
                                    GridLines="Both">
                                    <EmptyDataTemplate>
                                      Pas d'enregistrement!
                                    </EmptyDataTemplate>
                                    <Columns>

                                         <asp:TemplateField HeaderText="Identifiant" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="70px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblcodemat" runat="server" Text='<%# Eval("id_et")%>' />
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Label ID="lblmat2" runat="server" />
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Photos du candidat(e)" ConvertEmptyStringToNull="false">
                                            <ItemTemplate>

                                                <img onmouseover="function" id="img1" src='data:image/jpg;base64,<%# Eval("PHOTOS_ID") != System.DBNull.Value ? Convert.ToBase64String((byte[])Eval("PHOTOS_ID")) : string.Empty %>'
                                                    alt="image" height="150px" width="270px" />

                                             

                                            </ItemTemplate>
                                        </asp:TemplateField>



                                     


                                      
                                    </Columns>
                                </asp:GridView>
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
                                                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Calculer note" CssClass="auto-style1" />
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
                                                         <asp:ListItem Value="C">choisir</asp:ListItem>
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
                                                         <asp:ListItem Value="C">choisir</asp:ListItem>
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
                                                         <asp:ListItem Value="C">choisir</asp:ListItem>
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
                                                         <asp:ListItem Value="C">choisir</asp:ListItem>
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
                                                         <asp:ListItem Value="C">choisir</asp:ListItem>
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
                                <tr>
                                    <td>&nbsp;</td>
                                    <tr>
                                        <td></td>
                                        <td><strong>Veuillez choisir:</strong>
                                            <asp:RadioButtonList ID="chkcompetences" runat="server" DataSourceID="SqlDataSource16" DataTextField="lib_nome" DataValueField="code_nome" RepeatDirection="Horizontal">
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>
                                            <asp:Button ID="Button3" runat="server" CssClass="btn-lg btn-danger" Height="50px" OnClick="butsubmit_Click" Text="Enregistrer" Width="150px" style="color: #FFFFFF; background-color: #FF0000" />
                                        </td>
                                        <td>&nbsp; </td>
                                    </tr>

                                </tr>
                            </table>
                            <br />
                    </center>



                     <asp:SqlDataSource 
        ID="SqlDataSource16" 
        runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString5%>"
        ProviderName="<%$ ConnectionStrings:ConnectionString5.ProviderName %>"
        SelectCommand="SELECT CODE_NOME,LIB_nome from code_nomenclature where  code_str='08'">
    </asp:SqlDataSource>





                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString5 %>"
                        ProviderName="<%$ ConnectionStrings:ConnectionString5.ProviderName %>" SelectCommand="SELECT Id_et,num_cin_passeport
                         as CIN,trim(upper(nom_et))||' '|| trim(pnom_et) nom_prenom,MOY_BAC,ANNEE_BAC,(select lib_nome 
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
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString5 %>"
                            ProviderName="<%$ ConnectionStrings:ConnectionString5.ProviderName %>" SelectCommand="SELECT 
                            trim(NOM_ET)||'  '||trim(PNOM_ET)||'  '||trim(NUM_CIN_PASSEPORT)|| '  '||trim(id_et) cc, ID_ET
                             FROM ESP_ETUDIANT WHERE (score_entretien is null or score_entretien=0) and TRIM(ID_ET) LIKE '23%' ">
                        </asp:SqlDataSource>
                        <br />
                        <br />
                    </center>



                     <center>
                        <asp:SqlDataSource ID="SqlDataSource2020" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString5 %>"
                            ProviderName="<%$ ConnectionStrings:ConnectionString5.ProviderName %>" SelectCommand="SELECT 
                          id_ens, nom_ens from scoesb02.esp_enseignant where etat='A' and TYPE_ENS='P' ">
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
                   <%-- <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource5"></asp:GridView>

                 
                    <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:MyConnectionString %>"
                            ProviderName="<%$ ConnectionStrings:MyConnectionString.ProviderName %>" SelectCommand="select quiz as id_test ,name as name_test ,
substr(email,1,4) as user, a.sumgrades as note_candidat
from mdl_quiz_attempts a, mdl_user, mdl_quiz where
mdl_user.id = a.userid and a.quiz = mdl_quiz.id and quiz
in (2465, 2466, 2467, 2468)    ">
                        </asp:SqlDataSource>
                --%>

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
