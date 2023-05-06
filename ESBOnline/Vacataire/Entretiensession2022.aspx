<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Entretiensession2022.aspx.cs" Inherits="ESPOnline.Vacataire.Entretiensession2022" 
   
 MasterPageFile="~/Vacataire/Vaca.Master" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

 <%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <style type="text/css">
         .MessageBoxPopupBackground {
             filter: Alpha(Opacity=40);
             -moz-opacity: 0.4;
             opacity: 0.4;
             width: 100%;
             height: 100%;
             background-color: #999999;
             position: absolute;
             z-index: 500001;
             top: 0px;
             left: 0px;
         }

         .popupHeader {
             float: left;
             padding: 5px 0px 0px 0px;
             width: 520px;
             font-family: tahoma;
             font-weight: bold;
             height: 25px;
             text-decoration: none;
             background-image: url("../Contentcls/Images/bg1.png");
             color: #FFFFFF;
         }

             .popupHeader span {
                 color: #fff;
                 text-decoration: none;
                 line-height: 15px;
                 text-decoration: none;
                 float: left;
                 margin-left: 10px;
             }

             .popupHeader a {
                 color: #fff !important;
                 text-decoration: none !important;
                 line-height: 15px;
                 text-decoration: none;
                 float: right;
                 margin-right: 10px;
             }

         .popup_button {
             color: #fff !important;
             font-family: arial, Geneva, sans-serif;
             font-size: 12px;
             font-weight: normal;
             text-decoration: none !important;
             width: auto;
             background-image: url('../Contentcls/Images/ok.png');
             background-repeat: repeat-x; /*height: 24px;*/
             line-height: 22px;
             padding: 3px 15px 3px 15px;
             float: left;
             margin: 0px 0px 0px 5px;
         }
     </style>
    <style type="text/css">
        .MessageBoxPopupBackground {
            filter: Alpha(Opacity=40);
            -moz-opacity: 0.4;
            opacity: 0.4;
            width: 100%;
            height: 100%;
            background-color: #999999;
            position: absolute;
            z-index: 500001;
            top: 0px;
            left: 0px;
        }

        .popupHeader {
            float: left;
            padding: 5px 0px 0px 0px;
            width: 520px;
            font-family: tahoma;
            font-weight: bold;
            height: 25px;
            text-decoration: none;
            background-image: url("../Contentcls/Images/bg1.png");
            color: #FFFFFF;
        }

            .popupHeader span {
                color: #fff;
                text-decoration: none;
                line-height: 15px;
                text-decoration: none;
                float: left;
                margin-left: 10px;
            }

            .popupHeader a {
                color: #fff !important;
                text-decoration: none !important;
                line-height: 15px;
                text-decoration: none;
                float: right;
                margin-right: 10px;
            }

        .popup_button {
            color: #fff !important;
            font-family: arial, Geneva, sans-serif;
            font-size: 12px;
            font-weight: normal;
            text-decoration: none !important;
            width: auto;
            background-image: url('../Contentcls/Images/ok.png');
            background-repeat: repeat-x; /*height: 24px;*/
            line-height: 22px;
            padding: 3px 15px 3px 15px;
            float: left;
            margin: 0px 0px 0px 5px;
        }
    </style>
    <style type="text/css">
        .style1 {
            width: 442px;
        }

        .style2 {
            width: 392px;
        }

        .style3 {
            width: 491px;
        }

        .style4 {
            width: 204px;
        }

        .style5 {
            color: #FF0000;
        }

        .style10 {
            color: #000000;
            font-weight: 700;
        }

        .style11 {
            width: 442px;
            color: #003366;
            font-family: Arial, Helvetica, sans-serif;
        }

        .style12 {
            color: #666666;
        }

        .style13 {
            width: 442px;
            color: #666666;
        }
    </style>
    <link href="../Contents/Css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />
    <script src="../Contents/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="../Contents/Scripts/bootstrap.js" type="text/javascript"></script>
    <script type="text/javascript" src="../Contents/Scripts/JScript1.js"></script>
    <%--<style type="text/css">
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
    </style>--%>
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

     <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    
    <br />
    <br />
    <br />
    
    <div 
        <%--<asp:button id="butsubmit" text="GO" runat="server"  />--%>
        <input type="hidden" id="hide" runat="server">

        <center><table >
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
              
                </td> <td align="center"><asp:Label ID="Label6" runat="server"
                     Text="Chercher un candidat" Font-Bold="True"></asp:Label></td> <td></td></tr></table>
                    <table class="style1">
            <tr>
                <td align="center">
                  
                   <asp:Label ID="Label4" runat="server" Text="Remarque:Pour les 3A, les étudiants doivent maitriser:JAVA, UML, C, C++, Réseaux, BD.." style="color: #FF0000" visible="false"></asp:Label>
                </td> <td align="center"></td> <td></td></tr></table>
                        
                        <asp:Panel ID="Panel1" runat="server">
                           <%-- <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                            </telerik:RadScriptManager>--%>
                            
                            <%-- <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
                            <telerik:RadComboBox ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2" required=""
                                DataTextField="cc" DataValueField="ID_ET" EmptyMessage="Tapez le Nom ou CIN "
                                Filter="Contains" Width="300" MaxHeight="400" DropDownWidth="500" EnableLoadOnDemand="True"
                                ShowMoreResultsBox="False" HighlightTemplatedItems="True" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                            </telerik:RadComboBox>
                            <br />
                            <br />
                            <asp:DropDownList ID="Ddlchoix3" runat="server" AutoPostBack="true" required=""
                                 ValidationGroup="valid" Width="200px" Height="55px"
                                Visible="false" CssClass="style3">
                                <asp:ListItem Value="">Choisir Type Classe</asp:ListItem>
                                <asp:ListItem Value="3A">3A</asp:ListItem>
                                <asp:ListItem Value="3B">3B</asp:ListItem>
                                <asp:ListItem Value="AB">À vérifier</asp:ListItem>
                            </asp:DropDownList>
                            <br />
                            <br />
                        </asp:Panel>
                        <asp:Panel ID="Panel2" runat="server">
                            <table class="style1">
                                <tr>
                                    <td>
                                        &nbsp; 
                                    </td>
                                     <caption>
                                         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                         <td colspan="13">
                                             <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="true">
                                             </asp:GridView>
                                         </td>
                                         <td>
                                             <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                                         </td>
                                    </caption>
                                </tr>
                                <tr><td><br /></td></tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td colspan="13">
                                        <asp:Label ID="Label2" runat="server" Text="Ajouter note d'entretien" Font-Bold="True"></asp:Label>
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
                                              <%--  <td rowspan="2">
                                                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Calculer note" />
                                                </td>--%>
                                                <td class="style3">
                                                    Note sur 100
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Note
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="DropDownList2"   runat="server" 
                                                        AutoPostBack="true"
                                                        OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"   
                                                        
                                                        >
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
                                                    <asp:DropDownList ID="DropDownList5"  AutoPostBack="true"
                                                         runat="server" OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged"  >
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
                                                    <asp:DropDownList ID="DropDownList6" runat="server"
                                                         OnSelectedIndexChanged="DropDownList6_SelectedIndexChanged" 
                                                          AutoPostBack="true"
                                                        >
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
                                                    <asp:DropDownList ID="DropDownList7"  runat="server" 
                                                         AutoPostBack="true"
                                                        OnSelectedIndexChanged="DropDownList7_SelectedIndexChanged" 
                                                        >
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
                                                    <asp:DropDownList ID="DropDownList3"  runat="server" 
                                                        OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" AutoPostBack="true">
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
                                   
                                   

                                </tr>
                            </table>
                            <center><strong>Veuillez choisir une compétence:</strong>
                                            <asp:RadioButtonList ID="chkcompetences" runat="server" DataSourceID="SqlDataSource16" DataTextField="lib_nome" DataValueField="code_nome" RepeatDirection="Horizontal">
                                            </asp:RadioButtonList></center>
                            <center> <asp:Button ID="Button3" runat="server" CssClass="btn-lg btn-danger" Height="50px" OnClick="butsubmit_Click" Text="Enregistrer" Width="150px" />
                                       </center>
                            <br />
                    </center>
                    <asp:UpdatePanel runat="server" ID="upMain1">
        <ContentTemplate>
            <%--<asp:Button runat="server" ID="btnShow"
                OnClick="btnShowSuccess_Click" Text="Success" />
            <asp:Button runat="server" ID="Button1"
                OnClick="btnShowError_Click" Text="Error" />
            <asp:Button runat="server" ID="Button2"
                OnClick="btnShowWarning_Click" Text="Warning" />
            <asp:Button runat="server" ID="Button3"
                OnClick="btnShowMessage_Click" Text="Message" />--%>
            <%--Message popup area start--%>
            <asp:Button runat="server" ID="btnMessagePopupTargetButton" Style="display: none;" />
            <ajaxToolkit:ModalPopupExtender ID="mpeMessagePopup" runat="server" PopupControlID="pnlMessageBox"
                TargetControlID="btnMessagePopupTargetButton" OkControlID="btnOk" CancelControlID="btnCancel"
                BackgroundCssClass="MessageBoxPopupBackground">
            </ajaxToolkit:ModalPopupExtender>
            <asp:Panel runat="server" ID="pnlMessageBox" BackColor="White" Width="423" Style="display: none;
                border: 2px solid #780606;">
                <div class="popupHeader" style="width: 423px;">
                    <asp:Label ID="lblMessagePopupHeading" Text="Information" runat="server"></asp:Label><asp:LinkButton
                        ID="btnCancel" runat="server" Style="float: right; margin-right: 5px; background-color: #d82222;">X</asp:LinkButton>
                </div>
                <div style="max-height: 500px; width: 423px; overflow: hidden;">
                    <div style="float: left; width: 300px; margin: 10px;">
                        <table style="padding: 0; border-spacing: 0; border-collapse: collapse; width: 100%;">
                            <tr>
                                <td style="text-align: left; vertical-align: top; width: 11%;">
                                    <asp:Literal runat="server" ID="ltrMessagePopupImage"></asp:Literal>
                                </td>
                                <td style="width: 2%;">
                                </td>
                                <td style="text-align: left; vertical-align: top; width: 87%;">
                                    <p style="margin: 0px; padding: 0px; color: #5F0202;">
                                        <asp:Label runat="server" ID="lblMessagePopupText"></asp:Label>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; vertical-align: top;" colspan="3">
                                    <div style="margin-right: -65px; float: right; width: auto;">
                                        <asp:LinkButton ID="btnOk" runat="server" CssClass="popup_button">Ok</asp:LinkButton>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </asp:Panel>
            <%--Message popup area end--%>
        </ContentTemplate>
    </asp:UpdatePanel>


                     <asp:SqlDataSource 
        ID="SqlDataSource16" 
        runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString2%>"
        ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>"
        SelectCommand="SELECT CODE_NOME,LIB_nome from code_nomenclature where  code_str='08'">
    </asp:SqlDataSource>





                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>"
                        ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT Id_et,num_cin_passeport as CIN,trim(upper(nom_et))||' '|| trim(pnom_et) nom_prenom,MOY_BAC,ANNEE_BAC,(select lib_nome 
from code_nomenclature
where code_str='02'
and code_nome=(select  nature_bac from  ESP_ETUDIANT  where id_et=:ID_ET)) nature_bac,DIPLOME_SUP_ET DIPLOME,ANNEE_DIPLOME,(select lib_nome 
from code_nomenclature
where code_str='59'
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
                            ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT 
                            trim(NOM_ET)||'  '||trim(PNOM_ET)||'  '||trim(NUM_CIN_PASSEPORT)|| '  '||trim(id_et) cc, ID_ET 
                            FROM ESP_ETUDIANT WHERE (score_entretien is null   ) and TRIM(ID_ET) LIKE '22%'  ">
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
        </table></center>
        
    </div>

    
</asp:Content>
