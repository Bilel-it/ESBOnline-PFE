<%@ Page Title="" Language="C#" MasterPageFile="~/EnseignantsCUP/Cup.Master" AutoEventWireup="true" CodeBehind="Charg.aspx.cs" Inherits="ESPOnline.EnseignantsCUP.Charg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
  <script src="../Contents/Scripts/ScrollableGridPlugin_ASP.NetAJAX_2.0.js" type="text/javascript"></script>
    <link href="../Contents/Css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />
    <script src="../Contents/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="../Contents/Scripts/bootstrap.js" type="text/javascript"></script>
    <script src="../Contents/CSS3/js/bootstrap.min.js" type="text/javascript"></script>
 <script type="text/javascript" src="../Contents/Scripts/JScript1.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
<asp:Panel ID="Panel1" runat="server">
                        
    <h3 class="text-center text-info"><strong>Charge Horaire</strong></h3>
</asp:Panel>
<br/>
<asp:Panel ID="Panel7" CssClass="tab-pane" runat="server" style="text-align: left">
                                                    
    <asp:Label ID="Labelnomens" runat="server"  
        style="font-size: large; font-weight: 700;  color: #000000" Text="Label"></asp:Label>
<br/>
    <asp:Label ID="Labelup" runat="server" 
        style="font-size: large; color: #000000; font-weight: 700" Text="Label"></asp:Label>
        <asp:Label ID="Labelup0" runat="server" 
        style="font-size: large; color: #000000; font-weight: 700" Text="Label"></asp:Label>
        </asp:Panel>
<br/>
<asp:Panel ID="Panel2" CssClass="container-fluid" runat="server" 
                        style="text-align: left;" GroupingText="Charge en tant que Enseignant 1 :">
                        <asp:Repeater id="Repeater1"  runat="server">
                            <HeaderTemplate>
                                <table class="table" >
                                    <tr>
                                        <td>
                                            <b>Module</b></td>
                                        <td>
                                            <b>Classe</b></td>
                                        <td>
                                            <b>Nombre d'heures</b></td>
                                        <td>
                                            <b>Semestre</b></td>
                                        <td>
                                            <b>Charge P1</b></td>
                                        <td>
                                            <b>Charge P2</b></td>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label1" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "CODE_MODULE") %>' Runat="server"/>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label2" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "CODE_CL") %>' Runat="server"/>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label3" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "NB_HEURES") %>' Runat="server"/>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label4" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "NUM_SEMESTRE") %>' 
                        Runat="server"/>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label5" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "CHARGE_ENS1_P1") %>' Runat="server"/>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label6" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "CHARGE_ENS1_P2") %>' Runat="server"/>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                        <br />
                        <div class="input-large" style="width:auto; text-align:right;">
                        <asp:Label ID="Label31" Runat="server" CssClass="style12" />
                        <asp:Label ID="Label32" Runat="server" CssClass="style12" />
                        
                        </div>
                    </asp:Panel>

<asp:Panel ID="Panel3" runat="server" CssClass="container-fluid" 
    GroupingText="Charge en tant que Enseignant 2 :" style="text-align: left">

    <asp:Repeater id="Repeater2"  runat="server">
        <HeaderTemplate>
            <table class="table">
                <tr>
                    <td>
                        <b>Module</b></td>
                    <td>
                        <b>Classe</b></td>
                    <td>
                        <b>Nombre d'heures</b></td>
                    <td>
                        <b>Semestre</b></td>
                    <td>
                        <b>Charge P1</b></td>
                    <td>
                        <b>Charge P2</b></td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:Label ID="Label7" 
    Text='<%# DataBinder.Eval(Container.DataItem, "CODE_MODULE") %>' Runat="server"/>
                </td>
                <td>
                    <asp:Label ID="Label8" 
    Text='<%# DataBinder.Eval(Container.DataItem, "CODE_CL") %>' Runat="server"/>
                </td>
                <td>
                    <asp:Label ID="Label9" 
    Text='<%# DataBinder.Eval(Container.DataItem, "NB_HEURES") %>' Runat="server"/>
                </td>
                <td>
                    <asp:Label ID="Label10" 
    Text='<%# DataBinder.Eval(Container.DataItem, "NUM_SEMESTRE") %>' 
    Runat="server"/>
                </td>
                <td>
                    <asp:Label ID="Label11" 
    Text='<%# DataBinder.Eval(Container.DataItem, "CHARGE_ENS2_P1") %>' Runat="server"/>
                </td>
                <td>
                    <asp:Label ID="Label12" 
    Text='<%# DataBinder.Eval(Container.DataItem, "CHARGE_ENS2_P2") %>' Runat="server"/>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <br />
    <div class="input-large" style="width:auto; text-align:right;">
    <asp:Label ID="Label33" Runat="server" CssClass="style12" />
    <asp:Label ID="Label34" Runat="server" CssClass="style12" />
    </div>
</asp:Panel>

<asp:Panel ID="Panel4" runat="server" CssClass="container-fluid" 
                        GroupingText="Charge en tant que Enseignant 3 :" style=" text-align: left">
                        <asp:Repeater id="Repeater3"  runat="server">
                            <HeaderTemplate>
                                <table class="table">
                                    <tr>
                                        <td>
                                            <b>Module</b></td>
                                        <td>
                                            <b>Classe</b></td>
                                        <td>
                                            <b>Nombre d'heures</b></td>
                                        <td>
                                            <b>Semestre</b></td>
                                        <td>
                                            <b>Charge P1</b></td>
                                        <td>
                                            <b>Charge P2</b></td>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label13" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "CODE_MODULE") %>' Runat="server"/>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label14" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "CODE_CL") %>' Runat="server"/>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label15" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "NB_HEURES") %>' Runat="server"/>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label16" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "NUM_SEMESTRE") %>' 
                        Runat="server"/>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label17" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "CHARGE_ENS3_P1") %>' Runat="server"/>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label18" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "CHARGE_ENS3_P2") %>' Runat="server"/>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                        <br />
                        <div class="input-large" style="width:auto; text-align:right;">
                        <asp:Label ID="Label35" Runat="server" CssClass="style12" />
                        <asp:Label ID="Label36" Runat="server" CssClass="style12" />
                        </div>
                    </asp:Panel>

<asp:Panel ID="Panel5" runat="server" CssClass="container-fluid" 
GroupingText="Charge en tant que Enseignant 4 :" style="text-align: left">

<asp:Repeater id="Repeater4"  runat="server">
<HeaderTemplate>
    <table class="table">
        <tr>
            <td>
                <b>Module</b></td>
            <td>
                <b>Classe</b></td>
            <td>
                <b>Nombre d'heures</b></td>
            <td>
                <b>Semestre</b></td>
            <td>
                <b>Charge P1</b></td>
            <td>
                <b>Charge P2</b></td>
        </tr>
</HeaderTemplate>
<ItemTemplate>
    <tr>
        <td>
            <asp:Label ID="Label19" 
Text='<%# DataBinder.Eval(Container.DataItem, "CODE_MODULE") %>' Runat="server"/>
        </td>
        <td>
            <asp:Label ID="Label20" 
Text='<%# DataBinder.Eval(Container.DataItem, "CODE_CL") %>' Runat="server"/>
        </td>
        <td>
            <asp:Label ID="Label21" 
Text='<%# DataBinder.Eval(Container.DataItem, "NB_HEURES") %>' Runat="server"/>
        </td>
        <td>
            <asp:Label ID="Label22" 
Text='<%# DataBinder.Eval(Container.DataItem, "NUM_SEMESTRE") %>' 
Runat="server"/>
        </td>
        <td>
            <asp:Label ID="Label23" 
Text='<%# DataBinder.Eval(Container.DataItem, "CHARGE_ENS4_P1") %>' Runat="server"/>
        </td>
        <td>
            <asp:Label ID="Label24" 
Text='<%# DataBinder.Eval(Container.DataItem, "CHARGE_ENS4_P2") %>' Runat="server"/>
        </td>
    </tr>
</ItemTemplate>
<FooterTemplate>
    </table>
</FooterTemplate>
</asp:Repeater>
<br />
<div class="input-large" style="width:auto; text-align:right;">
<asp:Label ID="Label37" Runat="server" CssClass="style12" />
<asp:Label ID="Label38" Runat="server" CssClass="style12" />
</div>
</asp:Panel>

<asp:Panel ID="Panel6" GroupingText="Charge en tant que Enseignant 5 :" 
                        CssClass="container-fluid" runat="server" style="text-align: left;">
                        <asp:Repeater id="Repeater5"  runat="server">
                            <HeaderTemplate>
                                <table class="table">
                                    <tr>
                                        <td>
                                            <b>Module</b></td>
                                        <td>
                                            <b>Classe</b></td>
                                        <td>
                                            <b>Nombre d'heures</b></td>
                                        <td>
                                            <b>Semestre</b></td>
                                        <td>
                                            <b>Charge P1</b></td>
                                        <td>
                                            <b>Charge P2</b></td>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label25" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "CODE_MODULE") %>' Runat="server"/>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label26" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "CODE_CL") %>' Runat="server"/>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label27" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "NB_HEURES") %>' Runat="server"/>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label28" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "NUM_SEMESTRE") %>' 
                        Runat="server"/>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label29" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "CHARGE_ENS5_P1") %>' Runat="server"/>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label30" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "CHARGE_ENS5_P2") %>' Runat="server"/>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                        <br />
                        <div class="input-large" style="width:auto; text-align:right;">
                        <asp:Label ID="Label39" Runat="server" CssClass="style12" />
                        <asp:Label ID="Label40" Runat="server" CssClass="style12" />
                        </div>
                    </asp:Panel>

<asp:Panel ID="Panel8" CssClass="container-fluid" GroupingText="Total " runat="server" >
<div class="modal-body" style="text-align:right" >
    <asp:Label ID="Label41" runat="server" Text="Total Charge Periode 1 : " 
        CssClass="style10"></asp:Label><asp:Label ID="Label44" runat="server" 
        Text="" CssClass="style9"></asp:Label><br /><br />
    <asp:Label ID="Label42" runat="server" Text="Total Charge Periode 2 : " 
        CssClass="style10"></asp:Label><asp:Label ID="Label45" runat="server" 
        Text="" CssClass="style9"></asp:Label><br /><br />
    <asp:Label ID="Label43" runat="server" Text="Total des charges : " CssClass="style10"></asp:Label>
    <asp:Label ID="Label46" runat="server" Text="" CssClass="style9"></asp:Label>
    </div>
</asp:Panel>
<div class="btn-danger pull-right">
<asp:Button ID="Button2" runat="server" CssClass="btn" Height="43px" 
onclick="Button2_Click" Text="Exporter en Pdf" 
Width="130px" />
</div>
</div>
</asp:Content>