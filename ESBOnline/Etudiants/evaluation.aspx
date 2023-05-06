<%@ Page Title="" Language="C#" MasterPageFile="~/Etudiants/Eol.Master" AutoEventWireup="true"
    CodeBehind="evaluation.aspx.cs" Inherits="ESPOnline.Etudiants.evaluation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
    <link href="../Contents/Css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />
    <script src="../Contents/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="../Contents/Scripts/bootstrap.js" type="text/javascript"></script>
    
    <style type="text/css">
        .style1
        {
            width: 97%;
        }
        .style2
        {
            font-family: "Times New Roman", serif;
        }
        .style4
        {
        }
        .style6
        {
            width: 501px;
            height: 61px;
        }
        .style8
        {
            height: 61px;
        }
        .style9
        {
            width: 1431px;
            height: 61px;
        }
    p.MsoNormal
	{margin-bottom:.0001pt;
	text-autospace:ideograph-numeric;
	font-size:10.0pt;
	font-family:"Arial","sans-serif";
	        margin-left: 0cm;
            margin-right: 0cm;
            margin-top: 0cm;
        }
        .style12
        {
            font-family: "Times New Roman", Times, serif;
            font-size: medium;
        }
        .style16
        {
            font-family: "Times New Roman", Times, serif;
        }
        .style18
        {
            height: 61px;
            width: 12px;
        }
        .style19
        {
            font-size: large;
        }
        .style20
        {
            width: 886px;
            height: 61px;
        }
        .style21
        {
            width: 151px;
        }
        .style22
        {
            width: 612px;
            height: 61px;
        }
        .style24
        {
            width: 273px;
        }
        .style27
        {
            width: 73%;
            height: 31px;
        }
        .style28
        {
            font-size: large;
            text-align: center;
        }
        .style29
        {
            width: 286px;
        }
        .style30
        {
        }
        .style31
        {
            width: 621px;
        }
        .style32
        {
            border-collapse: collapse;
            font-size: 10.0pt;
            font-family: "Times New Roman", serif;
        }
        .style33
        {
            width: 671px;
        }
        .style35
        {
            font-size: medium;
        }
        .style36
        {
            font-size: medium;
            font-weight: bold;
        }
        .style38
        {
            width: 391pt;
        }
        .style39
        {
            width: 326pt;
        }
        .style40
        {
            width: 425pt;
        }
        .style41
        {
            width: 14.3cm;
        }
        .style42
        {
            width: 12pt;
        }
        .style43
        {
            width: 597px;
        }
        .style44
        {
            height: 61px;
            width: 100px;
        }
        .style46
        {
            width: 601px;
        }
        .style47
        {
            width: 233px;
        }
    </style>
    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div class="row">
    <div class="col-lg-2"></div>
    <div class="col-lg-8">
<table class="style1">
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <table class="style1">
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td colspan="3">
                                            <asp:Panel ID="Panel3" runat="server" BackColor="#D8D8D8" 
                                   Width="798px">
                                                <table class="style27">
                                                    <tr>
                                                       
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;</td>
                                                        <td colspan="2">
                                                            <table class="style27">
                                                                <tr>
                                                                    <td>
                                                                        &nbsp;</td>
                                                                    <td>
                                                                        &nbsp;</td>
                                                                    <td>
                                                                        &nbsp;</td>
                                                                    <td>
                                                                        &nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        &nbsp;</td>
                                                                    <td colspan="2">
                                                                        <strong>
                                                                        <asp:Panel ID="q1panel1" runat="server" BackColor="White" CssClass="style12" 
                                                                            Width="749px">
                                                                            <table class="style1">
                                                                                <tr>
                                                                                    <td class="style47">
                                                                                        <strong>&nbsp;</strong></td>
                                                                                    <td class="style28">
                                                                                        <strong>&nbsp;Evaluation des enseignements du BALC-on&nbsp;&nbsp;&nbsp;&nbsp; </strong></td>
                                                                                    <td class="style28">
                                                                                        2016-2017<br /> </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="style47">
                                                                                        &nbsp;</td>
                                                                                    <td class="style24">
                                                                                        &nbsp;</td>
                                                                                    <td>
                                                                                        &nbsp;</td>
                                                                                </tr>
                                                                            </table>
                                                                        </asp:Panel>
                                                                        <asp:RoundedCornersExtender ID="q1panel1_RoundedCornersExtender" runat="server" 
                                                                            Enabled="True" Radius="20" TargetControlID="q1panel1" BorderColor="Black">
                                                                        </asp:RoundedCornersExtender>
                                                                        </strong>
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        &nbsp;</td>
                                                                    <td>
                                                                        &nbsp;</td>
                                                                    <td>
                                                                        &nbsp;</td>
                                                                    <td>
                                                                        &nbsp;</td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td>
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;</td>
                                                        <td colspan="2">
                                                            &nbsp;</td>
                                                        <td>
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;</td>
                                                        <td class="style31">
                                                        <div class="row">
                                                        <div >
                                                            <asp:DropDownList ID="DDlistmodule" runat="server" CssClass="form-control" Width="200px" AutoPostBack="True" 
                                                                onselectedindexchanged="DDlistmodule_SelectedIndexChanged" 
                                                                AppendDataBoundItems="True">
   
                                                                <asp:ListItem>Veuillez choisir un module </asp:ListItem>
                                                            </asp:DropDownList>
                                                            </div>
                                                            <div  >
                                                            <asp:Label ID="NBmodrest" runat="server"></asp:Label>
                                                            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" Width="70px" AutoPostBack="True" 
                                                                DataSourceID="SqlDataSource1" DataTextField="NUM_SEMESTRE" 
                                                                DataValueField="NUM_SEMESTRE">
                                                            </asp:DropDownList>
                                                            </div>
                                                            </div>
                      
                                                 <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                                                ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
                                                                ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
                                                                 SelectCommand="SELECT     NUM_SEMESTRE
FROM         ESP_MODULE_PANIER_CLASSE_SAISO
GROUP BY CODE_MODULE, CODE_CL, NUM_SEMESTRE, ANNEE_DEB
HAVING      (CODE_MODULE = :code) AND (CODE_CL = :classe) AND (ANNEE_DEB = '2016')">
                                                                <SelectParameters>
                                                                    <asp:ControlParameter ControlID="DDlistmodule" Name="code" 
                                                                        PropertyName="SelectedValue" />
                                                                    <asp:ControlParameter ControlID="LabelClasse" Name="classe" 
                                                                        PropertyName="Text" />
                                                                </SelectParameters>
                                                            </asp:SqlDataSource>

                                                        </td>
                                                        <td>
                                                          <table class="style27">
               
                                                                <tr>
                                                                    <td>
                                                                        <strong>
                                                                        <asp:Panel ID="q1panel2" runat="server" BackColor="White" CssClass="style12" Visible="false"
                                                                            Height="27px" Width="156px">
                                                                            <strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                            <asp:Label ID="LabelClasse" runat="server" style="font-size: large" 
                                                                                Text="Label" ></asp:Label>
                                                                            </strong>
                                                                        </asp:Panel>
                                                                        <asp:RoundedCornersExtender ID="q1panel2_RoundedCornersExtender" runat="server" 
                                                                            Enabled="True" Radius="20" TargetControlID="q1panel2" BorderColor="Black">
                                                                        </asp:RoundedCornersExtender>
                                                                        </strong>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td>
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;</td>
                                                        
                                                        <td>
                                                            &nbsp;</td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        <asp:RoundedCornersExtender ID="Panel3_RoundedCornersExtender" 
                                    runat="server" Enabled="True" Radius="20" TargetControlID="Panel3" BorderColor="Black">
                                </asp:RoundedCornersExtender>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td colspan="3">
                                <table class="style1">
                                    <tr>
                                        <td>
                                            <asp:Panel ID="Panel2" runat="server" BackColor="#B80000" Height="1367px" 
                                                Width="798px">
                                                <table class="style1">
                                                    <tr>
                                                        <td>
                                                            &nbsp;</td>
                                                        <td>
                                                            &nbsp;</td>
                                                        <td>
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;</td>
                                                        <td>
                                                            <strong>
                                                            <asp:Panel ID="q1panel0" runat="server" BackColor="White" CssClass="style12" 
                                                                Width="776px">
                                                                <table class="style1">
                                                                    <tr>
                                                                        <td class="style30">
                                                                            <strong>
                                                                            &nbsp;</strong></td>
                                                                        <td class="style24">
                                                                            &nbsp;</td>
                                                                        <td>
                                                                            &nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="style30">
                                                                            &nbsp;</td>
                                                                        <td class="style24">
                                                                            <strong>Module :&nbsp;
                                                                            <asp:Label ID="LabelModule" runat="server" Text="Label"></asp:Label>
                                                                            </strong>
                                                                        </td>
                                                                        <td>
                                                                            &nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="style30">
                                                                            &nbsp;</td>
                                                                        <td class="style24">
                                                                            &nbsp;</td>
                                                                        <td>
                                                                            &nbsp;</td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                            <asp:RoundedCornersExtender ID="q1panel0_RoundedCornersExtender" runat="server" 
                                                                Enabled="True" Radius="20" TargetControlID="q1panel0">
                                                            </asp:RoundedCornersExtender>
                                                            </strong>
                                                        </td>
                                                        <td>
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;</td>
                                                        <td>
                                                            &nbsp;</td>
                                                        <td>
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;</td>
                                                        <td>
                                                            <strong>
                                                            <asp:Panel ID="q1panelinfo" runat="server" BackColor="White" CssClass="style12" 
                                                                Width="776px">
                                                                <table class="style1">
                                                                    <tr>
                                                                        <td>
                                                                            &nbsp;</td>
                                                                        <td class="style33">
                                                                            <table border="0" cellpadding="0" cellspacing="0" class="style32" 
                                                                                style="mso-table-layout-alt: fixed; mso-padding-alt: 0cm 5.4pt 0cm 5.4pt">
                                                                                <tr style="mso-yfti-irow:0;mso-yfti-firstrow:yes;mso-yfti-lastrow:yes">
                                                                                    <td style="padding:0cm 5.4pt 0cm 5.4pt" valign="top" class="style38">
                                                                                        <p align="right" class="style16">
                                                                                            <span class="style35">T</span><b><span class="style35" 
                                                                                                style="color: black; letter-spacing: -.3pt">Total désaccord<p>
                                                                                            </p>
                                                                                            </span></b>
                                                                                            <p>
                                                                                            </p>
                                                                                        </p>
                                                                                    </td>
                                                                                    <td style="background: #E0E0E0; padding: 0cm 5.4pt 0cm 5.4pt" 
                                                                                        valign="top" class="style42">
                                                                                        <p align="right">
                                                                                            <b><span class="style35" style="color: black; letter-spacing: -.3pt">1<p>
                                                                                            </p>
                                                                                            </span></b>
                                                                                            <p>
                                                                                            </p>
                                                                                        </p>
                                                                                    </td>
                                                                                    </strong>
                                                                                    <td style="padding:0cm 5.4pt 0cm 5.4pt" valign="top" class="style41">
                                                                                        <p align="right" class="style16">
                                                                                            <span class="style36">P</span><b><span class="style35" 
                                                                                                style="color: black; letter-spacing: -.3pt">Plutôt désaccord<p>
                                                                                            </p>
                                                                                            </span></b>
                                                                                            <p>
                                                                                            </p>
                                                                                        </p>
                                                                                    </td>
                                                                                    <strong>
                                                                                    <td style="width: 14.2pt; background: #E0E0E0; padding: 0cm 5.4pt 0cm 5.4pt" 
                                                                                        valign="top" width="19">
                                                                                        <p align="right">
                                                                                            <b><span class="style35" style="color: black; letter-spacing: -.3pt">2<p>
                                                                                            </p>
                                                                                            </span></b>
                                                                                            <p>
                                                                                            </p>
                                                                                        </p>
                                                                                    </td>
                                                                                    <td style="padding:0cm 5.4pt 0cm 5.4pt" valign="top" class="style40">
                                                                                        <p align="right" class="style16">
                                                                                            <span class="style36">P</span><b><span class="style35" 
                                                                                                style="color: black; letter-spacing: -.3pt">Plutôt d’accord<p>
                                                                                            </p>
                                                                                            </span></b>
                                                                                            <p>
                                                                                            </p>
                                                                                        </p>
                                                                                    </td>
                                                                                    <td style="width: 14.15pt; background: #E0E0E0; padding: 0cm 5.4pt 0cm 5.4pt" 
                                                                                        valign="top" width="19">
                                                                                        <p align="right">
                                                                                            <b><span class="style35" style="color: black; letter-spacing: -.3pt">3<p>
                                                                                            </p>
                                                                                            </span></b>
                                                                                            <p>
                                                                                            </p>
                                                                                        </p>
                                                                                    </td>
                                                                                    <td style="padding:0cm 5.4pt 0cm 5.4pt" valign="top" class="style39">
                                                                                        <p align="right" class="style16">
                                                                                            <b><span class="style35">T</span><span class="style35" 
                                                                                                style="color: black; letter-spacing: -.3pt">Total accord<p>
                                                                                            </p>
                                                                                            </span></b>
                                                                                            <p>
                                                                                            </p>
                                                                                        </p>
                                                                                    </td>
                                                                                   <td style="width: 14.15pt; background: #E0E0E0; padding: 0cm 5.4pt 0cm 5.4pt" 
                                                                                        valign="top" width="19">
                                                                                        <p align="right">
                                                                                            <b><span class="style35" style="color: black; letter-spacing: -.3pt">4<p>
                                                                                            </p>
                                                                                            </span></b>
                                                                                            <p>
                                                                                            </p>
                                                                                        </p>
                                                                                    </td>
                                                                                    </strong>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td>
                                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                            <asp:RoundedCornersExtender ID="q1panelinfo_RoundedCornersExtender" runat="server" 
                                                                Enabled="True" Radius="20" TargetControlID="q1panelinfo">
                                                            </asp:RoundedCornersExtender>
                                                            </strong>
                                                        </td>
                                                        <td>
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;</td>
                                                        <td>
                                                            <strong>
                                                            <asp:Panel ID="panelbaloon" runat="server" BackColor="White" CssClass="style12" 
                                                                Width="776px">
                                                                <table class="style1">
                                                                    <tr>
                                                                        <td class="style30">
                                                                            <strong>1. <b><span class="style35" 
                                                                                style="color: black; letter-spacing: -.3pt">Total désaccord</span></b><br /> 2.<b><span class="style35" 
                                                                                style="color: black; letter-spacing: -.3pt">Plutôt désaccord</span></b><br /> 3.<b><span class="style35" 
                                                                                style="color: black; letter-spacing: -.3pt">Plutôt d’accord</span></b><br /> 4.<b><span class="style35" 
                                                                                style="color: black; letter-spacing: -.3pt">Total accord</span></b></strong></td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                            <asp:RoundedCornersExtender ID="panelbaloon_RoundedCornersExtender" 
                                                                runat="server" Enabled="True" Radius="20" TargetControlID="panelbaloon">
                                                            </asp:RoundedCornersExtender>
                                                            </strong></td>
                                                        <td>
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;</td>
                                                        <td>
                                                            <strong>
                                                            <asp:Panel ID="q1panel" runat="server" BackColor="#CCCCCC" CssClass="style12" 
                                                                Width="776px">
                                                                <table class="style1">
                                                                    <tr>
                                                                        <td>
                                                                            &nbsp;</td>
                                                                        <td class="style4">
                                                                            <strong>1. Comment estimez-vous le progrès de vos compétences linguistiques 
                                                                            durant<br /> 
                                                                           <%-- &nbsp;le BALC-on ? <br /> --%>
                                                                         
                                                                            </strong></td>
                                                                        <td>
                                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                            <asp:RadioButtonList ID="RD1" runat="server" Font-Bold="True" 
                                                                                Font-Size="Medium" RepeatDirection="Horizontal" TextAlign="Left">
                                                                                <asp:ListItem Value="1">1.</asp:ListItem>
                                                                                <asp:ListItem Value="2">2.</asp:ListItem>
                                                                                <asp:ListItem Value="3">3.</asp:ListItem>
                                                                                <asp:ListItem Value="4">4.</asp:ListItem>
                                                                            </asp:RadioButtonList>
                                                                            <asp:BalloonPopupExtender ID="RD1_BalloonPopupExtender" runat="server" 
                                                                                CustomCssUrl="" DynamicServicePath="" Enabled="True" 
                                                                                BalloonPopupControlID="panelbaloon" ExtenderControlID="" 
                                                                                TargetControlID="RD1" DisplayOnMouseOver="True" Position="TopLeft">
                                                                            </asp:BalloonPopupExtender>
                                                                        </td>
                                                                        <td>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                                                ControlToValidate="RD1" ValidationGroup="EvaluationGroup" ErrorMessage="Champ Obligatoire" 
                                                                                ForeColor="#CC3300">*</asp:RequiredFieldValidator>
                                                                            <asp:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender" 
                                                                                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1" 
                                                                                PopupPosition="Left">
                                                                            </asp:ValidatorCalloutExtender>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                            </strong>
                                                            <asp:RoundedCornersExtender ID="q1panel_RoundedCornersExtender" runat="server" 
                                                                Enabled="True" Radius="20" TargetControlID="q1panel">
                                                            </asp:RoundedCornersExtender>
                                                        </td>
                                                        <td class="style12">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style12">
                                                            &nbsp;</td>
                                                        <td class="style12">
                                                            &nbsp;</td>
                                                        <td class="style12">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style12">
                                                            &nbsp;</td>
                                                        <td>
                                                            <strong>
                                                            <asp:Panel ID="q2panel" runat="server" BackColor="#CECECE" CssClass="style12" 
                                                                Width="776px">
                                                                <table class="style1">
                                                                    <tr>
                                                                        <td>
                                                                            &nbsp;</td>
                                                                        <td class="style46">
                                                                            <strong>2. Comment estimez-vous l’amélioration de vos compétences informatiques durant le BALC-on ? </strong></td>
                                                                        <td>
                                                                            <asp:RadioButtonList ID="RD2" runat="server" Font-Bold="True" 
                                                                                Font-Size="Medium" RepeatDirection="Horizontal" TextAlign="Left">
                                                                                <asp:ListItem Value="1">1.</asp:ListItem>
                                                                                <asp:ListItem Value="2">2.</asp:ListItem>
                                                                                <asp:ListItem Value="3">3.</asp:ListItem>
                                                                                <asp:ListItem Value="4">4.</asp:ListItem>
                                                                            </asp:RadioButtonList>
                                                                        </td>
                                                                        <td>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                                                ControlToValidate="RD2" ValidationGroup="EvaluationGroup" ErrorMessage="Champ Obligatoire" 
                                                                                ForeColor="#CC3300">*</asp:RequiredFieldValidator>
                                                                            <asp:ValidatorCalloutExtender ID="RequiredFieldValidator2_ValidatorCalloutExtender" 
                                                                                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator2" PopupPosition="Left">
                                                                            </asp:ValidatorCalloutExtender>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                            </strong>
                                                            <asp:RoundedCornersExtender ID="q2panel_RoundedCornersExtender" runat="server" 
                                                                Enabled="True" Radius="20" TargetControlID="q2panel">
                                                            </asp:RoundedCornersExtender>
                                                        </td>
                                                        <td class="style12">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style12">
                                                            &nbsp;</td>
                                                        <td class="style12">
                                                            &nbsp;</td>
                                                        <td class="style12">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style12">
                                                            &nbsp;</td>
                                                        <td>
                                                            <strong>
                                                            <asp:Panel ID="q3panel" runat="server" BackColor="#CCCCCC" CssClass="style12" 
                                                                Width="776px">
                                                                <table class="style1">
                                                                    <tr>
                                                                        <td>
                                                                            &nbsp;</td>
                                                                        <td class="style43">
                                                                            <span class="style2"><strong style="font-size: medium">3. Est-ce que les activités effectuées en classe ont permis  d’éveiller  votre curiosité, de s’ouvrir à des problématiques nouvelles, de se poser de nouvelles questions ?
                                                                            </strong></span>
                                                                        </td>
                                                                        <td>
                                                                            <asp:RadioButtonList ID="RD3" runat="server" Font-Bold="True" 
                                                                                Font-Size="Medium" RepeatDirection="Horizontal" TextAlign="Left">
                                                                                <asp:ListItem Value="1">1.</asp:ListItem>
                                                                                <asp:ListItem Value="2">2.</asp:ListItem>
                                                                                <asp:ListItem Value="3">3.</asp:ListItem>
                                                                                <asp:ListItem Value="4">4.</asp:ListItem>
                                                                            </asp:RadioButtonList>
                                                                        </td>
                                                                        <td>
                                                                            <strong>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                                                                ControlToValidate="RD3" ValidationGroup="EvaluationGroup" ErrorMessage="Champ Obligatoire" ForeColor="#CC3300">*</asp:RequiredFieldValidator>
                                                                            <asp:ValidatorCalloutExtender ID="RequiredFieldValidator7_ValidatorCalloutExtender" 
                                                                                runat="server" Enabled="True" PopupPosition="Left" 
                                                                                TargetControlID="RequiredFieldValidator7">
                                                                            </asp:ValidatorCalloutExtender>
                                                                            </strong>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                            </strong>
                                                            <asp:RoundedCornersExtender ID="q3panel_RoundedCornersExtender" runat="server" 
                                                                Enabled="True" Radius="20" TargetControlID="q3panel">
                                                            </asp:RoundedCornersExtender>
                                                        </td>
                                                        <td class="style12">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style12">
                                                            &nbsp;</td>
                                                        <td class="style12">
                                                            &nbsp;</td>
                                                        <td class="style12">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style12">
                                                            &nbsp;</td>
                                                        <td>
                                                            <strong>
                                                            <asp:Panel ID="q4panel" runat="server" BackColor="#CCCCCC" CssClass="style12" 
                                                                Width="776px">
                                                                <table class="style1">
                                                                    <tr>
                                                                        <td class="style18">
                                                                        </td>
                                                                        <td class="style22">
                                                                            <span class="style12" style="mso-fareast-font-family:&quot;Times New Roman&quot;;mso-ansi-language:FR;mso-fareast-language:
ZH-CN;mso-bidi-language:AR-SA"><strong>4. Pensez vous que les activités proposées durant le BALC-on ont amélioré vos compétences en communication (argumentation, prise de position, écoute active …) ?</strong><span style="mso-spacerun:yes"><strong>&nbsp;
                                                                            </strong></span></span>
                                                                        </td>
                                                                        <td class="style44">
                                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>
                                                                            <asp:RadioButtonList ID="RD4" runat="server" Font-Bold="True" 
                                                                                Font-Size="Medium" RepeatDirection="Horizontal" TextAlign="Left">
                                                                                <asp:ListItem Value="1">1.</asp:ListItem>
                                                                                <asp:ListItem Value="2">2.</asp:ListItem>
                                                                                <asp:ListItem Value="3">3.</asp:ListItem>
                                                                                <asp:ListItem Value="4">4.</asp:ListItem>
                                                                            </asp:RadioButtonList>
                                                                            </strong>
                                                                        </td>
                                                                        <td class="style8">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                                                                ControlToValidate="RD4" ValidationGroup="EvaluationGroup" ErrorMessage="Champ Obligatoire" 
                                                                                ForeColor="#CC3300">*</asp:RequiredFieldValidator>
                                                                            <asp:ValidatorCalloutExtender ID="RequiredFieldValidator4_ValidatorCalloutExtender" 
                                                                                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator4" 
                                                                                PopupPosition="Left">
                                                                            </asp:ValidatorCalloutExtender>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                            </strong>
                                                            <asp:RoundedCornersExtender ID="q4panel_RoundedCornersExtender" runat="server" 
                                                                Enabled="True" Radius="20" TargetControlID="q4panel">
                                                            </asp:RoundedCornersExtender>
                                                        </td>
                                                        <td class="style12">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style12">
                                                            &nbsp;</td>
                                                        <td class="style12">
                                                            &nbsp;</td>
                                                        <td class="style12">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style12">
                                                            &nbsp;</td>
                                                        <td>
                                                            <strong>
                                                            <asp:Panel ID="q5panel" runat="server" BackColor="#CCCCCC" CssClass="style12" 
                                                                Width="776px">
                                                                <table class="style1">
                                                                    <tr>
                                                                        <td class="style18">
                                                                        </td>
                                                                        <td class="style9">
                                                                            <span style="mso-spacerun:yes"><strong>
                                                                            <span class="style16" style="mso-fareast-font-family:&quot;Times New Roman&quot;;mso-ansi-language:FR;mso-fareast-language:
ZH-CN;mso-bidi-language:AR-SA">5. <span>&nbsp;Pensez-vous que le travail en groupe&nbsp;pendant le BALC-on a été satisfaisant? </span></span><span class="style16" style="font-size:10.0pt;mso-fareast-font-family:&quot;Times New Roman&quot;;mso-ansi-language:FR;mso-fareast-language:
ZH-CN;mso-bidi-language:AR-SA"><br /> </span></strong></span>
                                                                        </td>
                                                                        <td class="style6">
                                                                            <asp:RadioButtonList ID="RD5" runat="server" Font-Bold="True" 
                                                                                Font-Size="Medium" RepeatDirection="Horizontal" style="margin-left: 0px" 
                                                                                TextAlign="Left">
                                                                                <asp:ListItem Value="0">0h.</asp:ListItem>
                                                                                <asp:ListItem Value="1">1h.</asp:ListItem>
                                                                                <asp:ListItem Value="2">2h.</asp:ListItem>
                                                                                <asp:ListItem Value="3">3h.</asp:ListItem>
                                                                                <asp:ListItem Value="4">4h.</asp:ListItem>
                                                                            </asp:RadioButtonList>
                                                                        </td>
                                                                        <td class="style8">
                                                                            <strong>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                                                                ControlToValidate="RD5" ValidationGroup="EvaluationGroup" ErrorMessage="Champ Obligatoire" ForeColor="#CC3300">*</asp:RequiredFieldValidator>
                                                                            <asp:ValidatorCalloutExtender ID="RequiredFieldValidator8_ValidatorCalloutExtender" 
                                                                                runat="server" Enabled="True" PopupPosition="Left" 
                                                                                TargetControlID="RequiredFieldValidator8">
                                                                            </asp:ValidatorCalloutExtender>
                                                                            </strong>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                            </strong>
                                                            <asp:RoundedCornersExtender ID="q5panel_RoundedCornersExtender" runat="server" 
                                                                Enabled="True" Radius="20" TargetControlID="q5panel">
                                                            </asp:RoundedCornersExtender>
                                                        </td>
                                                        <td class="style12">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style12">
                                                            &nbsp;</td>
                                                        <td class="style12">
                                                            &nbsp;</td>
                                                        <td class="style12">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;</td>
                                                        <td>
                                                            <strong>
                                                            <asp:Panel ID="q5panel1" runat="server" BackColor="#CCCCCC" CssClass="style12">
                                                                <table class="style1">
                                                                    <tr>
                                                                        <td class="style18">
                                                                        </td>
                                                                        <td class="style20">
                                                                            <table class="style1">
                                                                                <tr>
                                                                                    <td>
                                                                                        <strong><span style="mso-spacerun:yes"><b><span class="style19" 
                                                                                            style="color: black; letter-spacing: -.35pt">
                                                                                        <span style="mso-fareast-font-family:&quot;Times New Roman&quot;;mso-ansi-language:FR;mso-fareast-language:
ZH-CN;mso-bidi-language:AR-SA">Dans l&#39;ensemble, j&#39;estime que cet enseignement&nbsp; est :</span><span style="font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;
mso-fareast-font-family:&quot;Times New Roman&quot;;mso-ansi-language:FR;mso-fareast-language:
ZH-CN;mso-bidi-language:AR-SA"> </span></span></b></span></strong>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <table class="style1">
                                                                                            <tr>
                                                                                                <td class="style21">
                                                                                                    &nbsp;</td>
                                                                                                <td>
                                                                                                    <strong>
                                                                                                    <asp:RadioButtonList ID="RD6" runat="server" Font-Bold="True" 
                                                                                                        Font-Size="Medium" RepeatDirection="Horizontal" 
                                                                                                        style="margin-left: 0px; text-align: center;">
                                                                                                        <asp:ListItem Value="5">Excellent  </asp:ListItem>
                                                                                                        <asp:ListItem Value="4">Bon</asp:ListItem>
                                                                                                        <asp:ListItem Value="3">Suffisant</asp:ListItem>
                                                                                                        <asp:ListItem Value="2">Insuffisant</asp:ListItem>
                                                                                                        <asp:ListItem Value="1">Très insuffisant</asp:ListItem>
                                                                                                    </asp:RadioButtonList>
                                                                                                    </strong>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <strong>
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                                                                                        ControlToValidate="RD6" ValidationGroup="EvaluationGroup" ErrorMessage="Champ Obligatoire" ForeColor="#CC3300">*</asp:RequiredFieldValidator>
                                                                                                    <asp:ValidatorCalloutExtender ID="RequiredFieldValidator9_ValidatorCalloutExtender" 
                                                                                                        runat="server" Enabled="True" PopupPosition="Left" 
                                                                                                        TargetControlID="RequiredFieldValidator9">
                                                                                                    </asp:ValidatorCalloutExtender>
                                                                                                    </strong>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <p class="MsoNormal">
                                                                                            <span style="color: black"><span class="style12">Avec les raisons principales 
                                                                                            suivantes :</span></span></p>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <i style="mso-bidi-font-style:normal">
                                                                                        <span style="font-size:9.5pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;mso-fareast-font-family:
&quot;Times New Roman&quot;;color:black;letter-spacing:-.1pt;mso-ansi-language:FR;
mso-fareast-language:ZH-CN;mso-bidi-language:AR-SA">Points forts :</span></i><span style="font-size:9.5pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;mso-fareast-font-family:
&quot;Times New Roman&quot;;color:black;letter-spacing:-.1pt;mso-ansi-language:FR;
mso-fareast-language:ZH-CN;mso-bidi-language:AR-SA"> </span>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:TextBox ID="TBfort" runat="server" Height="116px" style="text-align: left" 
                                                                                            TextMode="MultiLine" Width="713px" MaxLength="2000"></asp:TextBox>

                                                                                        <strong>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                                                                                            ControlToValidate="TBfort" ValidationGroup="EvaluationGroup" ErrorMessage="Champ Obligatoire" ForeColor="#CC3300">*</asp:RequiredFieldValidator>
                                                                                        <asp:ValidatorCalloutExtender ID="RequiredFieldValidator12_ValidatorCalloutExtender" 
                                                                                            runat="server" Enabled="True" PopupPosition="Left" 
                                                                                            TargetControlID="RequiredFieldValidator12">
                                                                                        </asp:ValidatorCalloutExtender>
                                                                                        </strong>

                                                                                    </td>

                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <i style="mso-bidi-font-style:normal">
                                                                                        <span style="font-size:9.5pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;mso-fareast-font-family:
&quot;Times New Roman&quot;;color:black;letter-spacing:-.1pt;mso-ansi-language:FR;
mso-fareast-language:ZH-CN;mso-bidi-language:AR-SA">Points faibles :</span></i></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <strong>
                                                                                        <asp:TextBox ID="TBfaible" runat="server" Height="116px" 
                                                                                            style="text-align: left" TextMode="MultiLine" Width="713px" 
                                                                                            MaxLength="2000"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                                                                            ControlToValidate="TBfaible" ValidationGroup="EvaluationGroup" ErrorMessage="Champ Obligatoire" 
                                                                                            ForeColor="#CC3300">*</asp:RequiredFieldValidator>
                                                                                        <asp:ValidatorCalloutExtender ID="RequiredFieldValidator10_ValidatorCalloutExtender" 
                                                                                            runat="server" Enabled="True" PopupPosition="Left" 
                                                                                            TargetControlID="RequiredFieldValidator10">
                                                                                        </asp:ValidatorCalloutExtender>
                                                                                        </strong>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <i style="mso-bidi-font-style:normal">
                                                                                        <span style="font-size:9.5pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;mso-fareast-font-family:
&quot;Times New Roman&quot;;color:black;letter-spacing:-.1pt;mso-ansi-language:FR;
mso-fareast-language:ZH-CN;mso-bidi-language:AR-SA">Vos propositions d’amélioration &nbsp;:</span></i></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <strong>
                                                                                        <asp:TextBox ID="TBprop" runat="server" Height="116px" style="text-align: left" 
                                                                                            TextMode="MultiLine" Width="713px" MaxLength="2000"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                                                                                            ControlToValidate="TBfaible" ErrorMessage="Champ Obligatoire" ValidationGroup="EvaluationGroup"
                                                                                            ForeColor="#CC3300">*</asp:RequiredFieldValidator>
                                                                                        <asp:ValidatorCalloutExtender ID="RequiredFieldValidator11_ValidatorCalloutExtender" 
                                                                                            runat="server"  Enabled="True" PopupPosition="Left" 
                                                                                            TargetControlID="RequiredFieldValidator11">
                                                                                        </asp:ValidatorCalloutExtender>
                                                                                        </strong>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td class="style8">
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                            <asp:RoundedCornersExtender ID="q5panel1_RoundedCornersExtender" runat="server" 
                                                                Enabled="True" Radius="20" TargetControlID="q5panel1">
                                                            </asp:RoundedCornersExtender>
                                                            </strong>
                                                        </td>
                                                        <td>
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;</td>
                                                        <td>
                                                            <asp:TextBox ID="TBnmbr" runat="server" BackColor="#5D7B9D" 
                                                                BorderColor="#5D7B9D" BorderStyle="None" ForeColor="#5D7B9D" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;</td>
                                                        <td>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                            <asp:Button ID="BTnValidation" runat="server" Text="Valider" ValidationGroup="EvaluationGroup"
                                                                onclick="BTnValidation_Click" 
                                                               CssClass="btn-lg btn-default " style="text-align: center" Font-Bold="True" Font-Italic="True" />
                                                        </td>
                                                        <td>
                                                            &nbsp;</td>
                                                    </tr>
                                                </table>

                                            </asp:Panel>
                                            
                                            <asp:RoundedCornersExtender ID="Panel2_RoundedCornersExtender" runat="server" 
                                                Enabled="True" Radius="20" TargetControlID="Panel2" >
                                            </asp:RoundedCornersExtender>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
        
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        
                                                                                             <script language="javascript" type="text/javascript">
                                                                                                 function btnClick() {
                                                                                                     if (Page_ClientValidate() == true) {

                                                                                                         var sName = document.getElementById('TBnmbr').value;


                                                                                                         alert(' Merci  Il Vous Reste  ' + sName + '  Modules à valider ');
                                                                                                     }
                                                                                                 }
    </script>
        <br />
        <br />
    </div>
    <div class="col-lg-2"></div>
    </div>
</asp:Content>
