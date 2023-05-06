<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="detaffect.ascx.cs" Inherits="ESPOnline.EnseignantsCUP.detaffect" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<style type="text/css">
    .style1
    {Background-Color:#D8D8D8 ;
        width: 100%;
    }
     .td1 { 
 border-width:1px;
 border-style:solid; 
 border-color:black;
 width:50%;
 }
    .style2
    {
        border: 1px solid black;
        width: 49%;
    }
    .style3
    {
        color: #CC0000;
    }
    .style4
    {
        color: #993333;
    }
    .style5
    {
        color: #CC6699;
    }
    .style6
    {
        color: #FF9933;
    }
    .text-danger
    {
        color: #FF0000;
    }
    .style7
    {
        width: 100%;
    }
    </style>

<table class="style1">
    <tr>
        <td>
            &nbsp;</td>
        <td>
            <strong>ENS1</strong></td>
        <td>
            &nbsp;</td>
        <td>
            <table class="style1" bgcolor="#780000 ">
                <tr>
                    <td colspan="2" class="td1">
                        <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>--%>
                                <telerik:RadComboBox ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" SelectedValue='<%# Bind("iden") %>' 
                                    DataTextField="NOM_ENS" DataValueField="ID_ENS" EmptyMessage="Tappez le Nom de l'enseignant1 "
                                    Filter="Contains" Width="300" MaxHeight="400" DropDownWidth="500" ShowMoreResultsBox="False"
                                    HighlightTemplatedItems="True">
                                </telerik:RadComboBox>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
                ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
                SelectCommand="select id_ens,upper(nom_ens) as nom_ens FROM ESP_ENSEIGNANT WHERE ETAT='A' order by upper(nom_ens) ">
            </asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="td1" >
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="td1">
                        <strong>P1</strong>
                        <asp:TextBox ID="TBEns1P1" runat="server" Font-Size="X-Small" Height="25px" 
                            Style="text-align: center;" Text='<%# Eval("CHARGE_ENS1_P1") %>' Width="32px"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                            ControlToValidate="TBEns1P1" CssClass="h5 text-danger" ErrorMessage="*" 
                            SetFocusOnError="True" 
                            ValidationExpression="^[4][2]?$|^[4][0-1](\.[0-9]{0,2})?$|^[1-3][0-9](\.[0-9]{0,2})?$|^[0-9](\.[0-9]{0,2})?$|^[4][0-1](\,[0-9]{0,2})?$|^[1-3][0-9](\,[0-9]{0,2})?$|^[0-9](\,[0-9]{0,2})?$" 
                            ValidationGroup="Button1Validate"></asp:RegularExpressionValidator>
                      <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" Enabled="True"
                                                                            FilterType="Custom, numbers" ValidChars=",." TargetControlID="TBEns1P1"></asp:FilteredTextBoxExtender>
                         <%-- <asp:RangeValidator ID="Value1RangeValidator" ControlToValidate="TBEns1P1"  
                                                                    MinimumValue="0" MaximumValue='<%# Eval("CHARGE_P1") %>' Display="Dynamic" ErrorMessage="**" runat="server" />--%>                                               
                    </td>
                    <td class="style2">  <strong>P2</strong><asp:TextBox ID="TBEns1P2" runat="server" Text='<%# Eval("CHARGE_ENS1_P2") %>'
                                                                            Font-Size="X-Small" Height="25px" Style="text-align: center;" Width="32px"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationExpression="^[4][2]?$|^[4][0-1](\.[0-9]{0,2})?$|^[1-3][0-9](\.[0-9]{0,2})?$|^[0-9](\.[0-9]{0,2})?$|^[4][0-1](\,[0-9]{0,2})?$|^[1-3][0-9](\,[0-9]{0,2})?$|^[0-9](\,[0-9]{0,2})?$"
                                                                            ErrorMessage="*" ControlToValidate="TBEns1P2" CssClass="h5 text-danger" ValidationGroup="Button1Validate"
                                                                            SetFocusOnError="True"></asp:RegularExpressionValidator>
                                                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="True"
                                                                            FilterType="Custom, numbers" ValidChars=",." TargetControlID="TBEns1P2"></asp:FilteredTextBoxExtender>

                                                                            <%-- <asp:RangeValidator ID="RangeValidator1" ControlToValidate="TBEns1P2"  
                                                                    MinimumValue="0" MaximumValue='<%# Eval("CHARGE_P2") %>' Display="Dynamic" ErrorMessage="**" runat="server" />--%>    
                    </td>
                </tr>
            </table>
        </td>
        <td>
            &nbsp;</td>
        <td>
            <span class="style3">
            <strong>ENS2</strong></span>:</td>
        <td>
            &nbsp;</td>
        <td>
            <table class="style1">
                <tr>
                    <td colspan="2" class="td1">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate> 
                            <asp:DropDownList ID="ddens2" runat="server"  DataTextField="NOM_ENS"      AppendDataBoundItems="True"            DataValueField="ID_ENS"  DataSourceID="SqlDataSource2" TabIndex="7"
                                                 Width="300px" MaxHeight="200"
                                                     SelectedValue='<%# Bind("idens2") %>'  ><asp:ListItem Selected="True" Text="" Value="">
                                                </asp:ListItem>
                                                </asp:DropDownList>
                                                </ContentTemplate></asp:UpdatePanel>
                                <%--<telerik:RadComboBox ID="RadComboBox1" runat="server" DataSourceID="SqlDataSource2" SelectedValue='<%# Bind("idens2") %>' 
                                    AutoPostBack="True" DataTextField="NOM_ENS" DataValueField="ID_ENS" EmptyMessage="Tappez le Nom de l'enseignant2 "
                                    Filter="Contains" Width="300" MaxHeight="400" DropDownWidth="500" ShowMoreResultsBox="False" AppendDataBoundItems="true"
                                    HighlightTemplatedItems="True"> 
                                </telerik:RadComboBox>--%>
                       <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
                ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
                SelectCommand="select id_ens,upper(nom_ens) as nom_ens FROM ESP_ENSEIGNANT WHERE ETAT='A' order by upper(nom_ens) ">
            </asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="td1">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="td1" >
                                                                        <strong>P1</strong>
                                                                        <asp:TextBox ID="TBEns2P1" runat="server" Text='<%# Eval("CHARGE_ENS2_P1") %>' Font-Size="X-Small"
                                                                            Height="25px" Style="text-align: center;" Width="32px"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression="^[4][2]?$|^[4][0-1](\.[0-9]{0,2})?$|^[1-3][0-9](\.[0-9]{0,2})?$|^[0-9](\.[0-9]{0,2})?$|^[4][0-1](\,[0-9]{0,2})?$|^[1-3][0-9](\,[0-9]{0,2})?$|^[0-9](\,[0-9]{0,2})?$"
                                                                            ErrorMessage="*" ControlToValidate="TBEns2P1" CssClass="h5 text-danger" ValidationGroup="Button1Validate"
                                                                            SetFocusOnError="True"></asp:RegularExpressionValidator>
                                                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server" Enabled="True"
                                                                            FilterType="Custom, numbers" ValidChars=",." TargetControlID="TBEns2P1">
                                                                        </asp:FilteredTextBoxExtender>
                                                                             <%--<asp:RangeValidator ID="RangeValidator2" ControlToValidate="TBEns1P2"  
                                                                    MinimumValue="0" MaximumValue='<%# Eval("CHARGE_P1") %>' Display="Dynamic" ErrorMessage="**" runat="server" />--%>
                                                                    </td>
                                                                    <td class="td1">
                                                                        <strong>P2</strong>
                                                                        <asp:TextBox ID="TBEns2P2" runat="server" Text='<%# Eval("CHARGE_ENS2_P2") %>' Font-Size="X-Small"
                                                                            Height="25px" Style="text-align: center;" Width="32px"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ValidationExpression="^[4][2]?$|^[4][0-1](\.[0-9]{0,2})?$|^[1-3][0-9](\.[0-9]{0,2})?$|^[0-9](\.[0-9]{0,2})?$|^[4][0-1](\,[0-9]{0,2})?$|^[1-3][0-9](\,[0-9]{0,2})?$|^[0-9](\,[0-9]{0,2})?$"
                                                                            ErrorMessage="*" ControlToValidate="TBEns2P2" CssClass="h5 text-danger" ValidationGroup="Button1Validate"
                                                                            SetFocusOnError="True"></asp:RegularExpressionValidator>
                                                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" Enabled="True"
                                                                            FilterType="Custom, numbers" ValidChars=",." TargetControlID="TBEns2P2">
                                                                        </asp:FilteredTextBoxExtender>
                                                                             <%--<asp:RangeValidator ID="RangeValidator3" ControlToValidate="TBEns1P2"  
                                                                    MinimumValue="0" MaximumValue='<%# Eval("CHARGE_P2") %>' Display="Dynamic" ErrorMessage="**" runat="server" />--%>
                                                                    </td>
                </tr>
            </table>
        </td>
        <td>
            &nbsp;</td>
        <td class="style4">
            <strong>ENS3</strong></td>
        <td>
            &nbsp;</td>
        <td>
            <table class="style1">
                <tr>
                    <td colspan="2" class="td1">

                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate> 
                            <asp:DropDownList ID="ddens3" runat="server"  DataTextField="NOM_ENS"      AppendDataBoundItems="True"            DataValueField="ID_ENS"  DataSourceID="SqlDataSource3" TabIndex="7"
                                                 Width="300px" MaxHeight="200" 
                                                     SelectedValue='<%# Bind("id_ens3") %>'  ><asp:ListItem Selected="True" Text="" Value="">
                                                </asp:ListItem>
                                                </asp:DropDownList>
                                                </ContentTemplate></asp:UpdatePanel><asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
                ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
                SelectCommand="select id_ens,upper(nom_ens) as nom_ens FROM ESP_ENSEIGNANT WHERE ETAT='A' order by upper(nom_ens)">
            </asp:SqlDataSource></td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2" class="td1">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="td1" >
                                                                        <strong>P1</strong>
                                                                        <asp:TextBox ID="TBEns3P1" runat="server" Text='<%# Eval("CHARGE_ENS3_P1") %>' Font-Size="X-Small"
                                                                            Height="25px" Style="text-align: center;" Width="32px"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ValidationExpression="^[4][2]?$|^[4][0-1](\.[0-9]{0,2})?$|^[1-3][0-9](\.[0-9]{0,2})?$|^[0-9](\.[0-9]{0,2})?$|^[4][0-1](\,[0-9]{0,2})?$|^[1-3][0-9](\,[0-9]{0,2})?$|^[0-9](\,[0-9]{0,2})?$"
                                                                            ErrorMessage="*" ControlToValidate="TBEns3P1" CssClass="h5 text-danger" ValidationGroup="Button1Validate"
                                                                            SetFocusOnError="True"></asp:RegularExpressionValidator>
                                                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" Enabled="True"
                                                                            FilterType="Custom, numbers" ValidChars=",." TargetControlID="TBEns3P1">
                                                                        </asp:FilteredTextBoxExtender>
                                                                    </td>
                                                                    <td class="td1">
                                                                        <strong>P2</strong>
                                                                        <asp:TextBox ID="TBEns3P2" runat="server" Text='<%# Eval("CHARGE_ENS3_P2") %>' Font-Size="X-Small"
                                                                            Height="25px" Style="text-align: center;" Width="32px"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ValidationExpression="^[4][2]?$|^[4][0-1](\.[0-9]{0,2})?$|^[1-3][0-9](\.[0-9]{0,2})?$|^[0-9](\.[0-9]{0,2})?$|^[4][0-1](\,[0-9]{0,2})?$|^[1-3][0-9](\,[0-9]{0,2})?$|^[0-9](\,[0-9]{0,2})?$"
                                                                            ErrorMessage="*" ControlToValidate="TBEns3P2" CssClass="h5 text-danger" ValidationGroup="Button1Validate"
                                                                            SetFocusOnError="True"></asp:RegularExpressionValidator>
                                                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" Enabled="True"
                                                                            FilterType="Custom, numbers" ValidChars=",." TargetControlID="TBEns3P2">
                                                                        </asp:FilteredTextBoxExtender>
                                                                    </td>
                </tr>
            </table>
        </td>
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
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td class="style6">
            <strong>ENS4</strong></td>
        <td>
            &nbsp;</td>
        <td>
            <table class="style1">
                <tr>
                    <td colspan="2" class="td1">
                       <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate> 
                            <asp:DropDownList ID="ddens4" runat="server"  DataTextField="NOM_ENS"      AppendDataBoundItems="True"            DataValueField="ID_ENS"  DataSourceID="SqlDataSource4" TabIndex="7"
                                                 Width="300px" MaxHeight="200" 
                                                     SelectedValue='<%# Bind("id_ens4") %>'  ><asp:ListItem Selected="True" Text="" Value="">
                                                </asp:ListItem>
                                                </asp:DropDownList>
                                                </ContentTemplate></asp:UpdatePanel><asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
                ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
                SelectCommand="select id_ens,upper(nom_ens) as nom_ens FROM ESP_ENSEIGNANT WHERE ETAT='A' order by upper(nom_ens) ">
            </asp:SqlDataSource></td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2" class="td1">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="td1" >
                                                                        <strong>P1</strong>
                                                                        <asp:TextBox ID="TBEns4P1" runat="server" Text='<%# Eval("CHARGE_ENS4_P1") %>' Font-Size="X-Small"
                                                                            Height="25px" Style="text-align: center;" Width="32px"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ValidationExpression="^[4][2]?$|^[4][0-1](\.[0-9]{0,2})?$|^[1-3][0-9](\.[0-9]{0,2})?$|^[0-9](\.[0-9]{0,2})?$|^[4][0-1](\,[0-9]{0,2})?$|^[1-3][0-9](\,[0-9]{0,2})?$|^[0-9](\,[0-9]{0,2})?$"
                                                                            ErrorMessage="*" ControlToValidate="TBEns4P1" CssClass="h5 text-danger" ValidationGroup="Button1Validate"
                                                                            SetFocusOnError="True"></asp:RegularExpressionValidator>
                                                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" Enabled="True"
                                                                            FilterType="Custom, numbers" ValidChars=",." TargetControlID="TBEns4P1">
                                                                        </asp:FilteredTextBoxExtender>
                                                                    </td>
                                                                    <td class="td1">
                                                                        <strong>P2</strong>
                                                                        <asp:TextBox ID="TBEns4P2" runat="server" Text='<%# Eval("CHARGE_ENS4_P2") %>' Font-Size="X-Small"
                                                                            Height="25px" Style="text-align: center;" Width="32px"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ValidationExpression="^[4][2]?$|^[4][0-1](\.[0-9]{0,2})?$|^[1-3][0-9](\.[0-9]{0,2})?$|^[0-9](\.[0-9]{0,2})?$|^[4][0-1](\,[0-9]{0,2})?$|^[1-3][0-9](\,[0-9]{0,2})?$|^[0-9](\,[0-9]{0,2})?$"
                                                                            ErrorMessage="*" ControlToValidate="TBEns4P2" CssClass="h5 text-danger" ValidationGroup="Button1Validate"
                                                                            SetFocusOnError="True"></asp:RegularExpressionValidator>
                                                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" Enabled="True"
                                                                            FilterType="Custom, numbers" ValidChars=",." TargetControlID="TBEns4P2">
                                                                        </asp:FilteredTextBoxExtender>
                                                                    </td>
                </tr>
            </table>
        </td>
        <td>
            &nbsp;</td>
        <td class="style5">
            <strong>ENS5</strong></td>
        <td>
            &nbsp;</td>
        <td>
            <table class="style1">
                <tr>
                    <td colspan="2" class="td1">
                       <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate> 
                            <asp:DropDownList ID="ddens5" runat="server"  DataTextField="NOM_ENS"      AppendDataBoundItems="True"            DataValueField="ID_ENS"  DataSourceID="SqlDataSource5" TabIndex="7"
                                                 Width="300px" MaxHeight="200" 
                                                     SelectedValue='<%# Bind("id_ens5") %>'  ><asp:ListItem Selected="True" Text="" Value="">
                                                </asp:ListItem>
                                                </asp:DropDownList>
                                                </ContentTemplate></asp:UpdatePanel><asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
                ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
                SelectCommand="select id_ens,upper(nom_ens) as nom_ens FROM ESP_ENSEIGNANT WHERE ETAT='A' order by upper(nom_ens) ">
            </asp:SqlDataSource></td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2" class="td1">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="td1" >
                                                                        <strong>P1</strong>
                                                                        <asp:TextBox ID="TBEns5P1" runat="server" Text='<%# Eval("CHARGE_ENS5_P1") %>' Font-Size="X-Small"
                                                                            Height="25px" Style="text-align: center;" Width="32px"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ValidationExpression="^[4][2]?$|^[4][0-1](\.[0-9]{0,2})?$|^[1-3][0-9](\.[0-9]{0,2})?$|^[0-9](\.[0-9]{0,2})?$|^[4][0-1](\,[0-9]{0,2})?$|^[1-3][0-9](\,[0-9]{0,2})?$|^[0-9](\,[0-9]{0,2})?$"
                                                                            ErrorMessage="*" ControlToValidate="TBEns5P1" CssClass="h5 text-danger" ValidationGroup="Button1Validate"
                                                                            SetFocusOnError="True"></asp:RegularExpressionValidator>
                                                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" Enabled="True"
                                                                            FilterType="Custom, numbers" ValidChars=",." TargetControlID="TBEns5P1">
                                                                        </asp:FilteredTextBoxExtender>
                                                                    </td>
                                                                    <td class="td1">
                                                                        <strong>P2</strong>
                                                                        <asp:TextBox ID="TBEns5P2" runat="server" Text='<%# Eval("CHARGE_ENS5_P2") %>' Font-Size="X-Small"
                                                                            Height="25px" Style="text-align: center;" Width="32px"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ValidationExpression="^[4][2]?$|^[4][0-1](\.[0-9]{0,2})?$|^[1-3][0-9](\.[0-9]{0,2})?$|^[0-9](\.[0-9]{0,2})?$|^[4][0-1](\,[0-9]{0,2})?$|^[1-3][0-9](\,[0-9]{0,2})?$|^[0-9](\,[0-9]{0,2})?$"
                                                                            ErrorMessage="*" ControlToValidate="TBEns5P2" CssClass="h5 text-danger" ValidationGroup="Button1Validate"
                                                                            SetFocusOnError="True"></asp:RegularExpressionValidator>
                                                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" Enabled="True"
                                                                            FilterType="Custom, numbers" ValidChars=",." TargetControlID="TBEns5P2">
                                                                        </asp:FilteredTextBoxExtender>
                                                                    </td>
                </tr>
            </table>
        </td>
        <td>
            &nbsp;</td>
        <td>
            <strong>TYPE_EPREUVE</strong>&nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            <table class="style7">
                <tr>
                    <td>
                         <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate> 
                            <asp:DropDownList ID="type_ep" runat="server"  DataTextField="LIB_NOME"      AppendDataBoundItems="True"            DataValueField="CODE_NOME"  DataSourceID="SqlDataSource6" TabIndex="7"
                                                 Width="100px" MaxHeight="200" 
                                                     SelectedValue='<%# Bind("TYPE_EPREUVE") %>'  >
                                                    <%-- <asp:ListItem Selected="True" Text="" Value="">
                                                </asp:ListItem>--%>
                                                </asp:DropDownList>
                                                </ContentTemplate></asp:UpdatePanel><asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
                ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
                SelectCommand=" SELECT  CODE_STR ,  CODE_NOME , LIB_NOME  FROM CODE_NOMENCLATURE WHERE CODE_STR='78'">
            </asp:SqlDataSource></td>
                </tr>
                <tr>
                    <td>
                      <%--  <asp:Button ID="btnUpdate" runat="server" CommandName="Update" Text="Modifier" 
                Visible="<%# !(DataItem is Telerik.Web.UI.GridInsertionObject) %>" ValidationGroup="Button1Validate" />
            &nbsp;
            <asp:Button ID="btnCancel" runat="server" CausesValidation="False" 
                CommandName="Cancel" Text="Annuler" />--%></td>
                </tr>
            </table>
        </td>  
        <%--<td>
            &nbsp;
            <asp:Button ID="btnUpdate" runat="server" CommandName="Update" Text="Modifier" 
                Visible="<%# !(DataItem is Telerik.Web.UI.GridInsertionObject) %>" ValidationGroup="Button1Validate" />
            &nbsp;
            <asp:Button ID="btnCancel" runat="server" CausesValidation="False" 
                CommandName="Cancel" Text="Annuler" />
        </td>--%>
       
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
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
              </td>
        <td>
            &nbsp;</td>
        <td>
             <asp:Button ID="Button3" runat="server" CommandName="Update" Text="Enregistrer" 
                Visible="<%# !(DataItem is Telerik.Web.UI.GridInsertionObject) %>" ValidationGroup="Button1Validate" />
            &nbsp;
            <asp:Button ID="Button4" runat="server" CausesValidation="False" 
                CommandName="Cancel" Text="Annuler" />&nbsp;</td>
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
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>



