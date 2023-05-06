<%@ Page Title="" Language="C#" MasterPageFile="~/EnseignantsCUP/Cup.Master" AutoEventWireup="true"
    CodeBehind="TestAffectation.aspx.cs" Inherits="ESPOnline.EnseignantsCUP.TestAffectation" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Styles/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="Styles/ScrollableGridPlugin.js" type="text/javascript"></script>
    <link href="../Contents/Css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link type="text/css" rel="stylesheet" href="Styles/Site.css" />
    <link rel="stylesheet" type="text/css" href="../Contents/jquery.notifyBar.css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="../Contents/Scripts/jquery.notifyBar.js" type="text/javascript"></script>
    <script type="text/javascript">
        function showNotification(message) {
            $.notifyBar({
                html: message,
                cssClass: "success",
                close: true,
                delay: 0,
                animationSpeed: "normal"
            });
        }
        function showwarning() {
            $.notifyBar({
                cssClass: "warning",
                close: true,
                html: "Les paramètres ne sont pas modifiés!"
            })
        };
    </script>
    <style type="text/css">
        .style1
        {
            width: 100%;
            font-size: x-small;
        }
        .style7
        {
            width: 381px;
        }
        .style8
        {
            width: 642px;
        }
    </style>
    <script type="text/javascript">
        function focusRow(id, rowIndex) {
            var tbl = document.getElementById(id);
            var rows = tbl.childNodes[0].childNodes;
            rows[rowIndex].childNodes[0].focus();
            document.getElementById('console').innerText = rows[rowIndex].childNodes[0].innerHTML;
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%=GridView1.ClientID %>').Scrollable({
                ScrollHeight: 425
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
    </telerik:RadStyleSheetManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    </telerik:RadAjaxManager>
    <div class="container">
        <table class="style1">
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                    </telerik:RadScriptManager>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <table class="style1">
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <table class="style1">
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <table class="style1">
                                                <tr>
                                                    <%--<td class="style7">
                                                        &nbsp;
                                                    </td>--%>
                                                    <td class="style8">
                                                        <asp:Label ID="Labelnomens" runat="server" Style="font-size: x-large; font-weight: 700;
                                                            color: #000000" Text="Label" CssClass="collapse"></asp:Label>
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:Label ID="Labelup" runat="server" Style="font-size: x-large; color: #000000;
                                                            font-weight: 700" Text="Label" CssClass="collapse"></asp:Label>
                                                    </td>
                                                    <%-- <td>
                                                        &nbsp;
                                                    </td>--%>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <table class="style1">
                                                <tr>
                                                    <%-- <td>
                                                        &nbsp;
                                                    </td>--%>
                                                    <td>
                                                        Choisir Module:&nbsp;
                                                        <telerik:RadComboBox ID="RadComboBox2" runat="server" DataSourceID="SqlDataSource2"
                                                            DataTextField="DESIGNATION" DataValueField="CODE_MODULE" EmptyMessage="Tappez le Nom du Module "
                                                            Filter="Contains" Width="192px">
                                                        </telerik:RadComboBox>
                                                        &nbsp;
                                                        <asp:CheckBox ID="CBmodules" runat="server" AutoPostBack="True" Text="Filtrer" OnCheckedChanged="CBmodules_CheckedChanged" />
                                                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
                                                            ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
                                                            SelectCommand="SELECT &quot;CODE_MODULE&quot;, &quot;DESIGNATION&quot; FROM &quot;ESP_MODULE&quot;  order by DESIGNATION ">
                                                        </asp:SqlDataSource>
                                                    </td>
                                                    <td rowspan="2">
                                                        &nbsp; Semestre:&nbsp;
                                                        <asp:RadioButtonList ID="RadioButtonList3" runat="server" RepeatDirection="Vertical"
                                                            AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList3_SelectedIndexChanged">
                                                            <asp:ListItem Value="1" Selected="True">Semestre 1</asp:ListItem>
                                                            <asp:ListItem Value="2">Semestre 2</asp:ListItem>
                                                            <asp:ListItem Value="3">Année Universitaire</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                    <td>
                                                        Niveau :<asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal"
                                                            AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged">
                                                            <asp:ListItem Value="">All </asp:ListItem>
                                                            <asp:ListItem Value="1">1ere année </asp:ListItem>
                                                            <asp:ListItem Value="2">2ème année</asp:ListItem>
                                                            <asp:ListItem Value="3">3ème année</asp:ListItem>
                                                            <asp:ListItem Value="4">4ème année</asp:ListItem>
                                                            <asp:ListItem Value="5">5ème année</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="Button3" runat="server" Text="ExportToExcel" OnClick="ExportExcel"
                                                            Visible="false" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="Button1" CssClass="btn btn-default pull-right" runat="server" Font-Bold="True"
                                                            OnClick="Button1_Click" Text="Enregistrer" ValidationGroup="Button1Validate"
                                                            Height="40px" Width="98px" />
                                                        <asp:Button ID="Button2" CssClass="btn btn-danger pull-right" runat="server" Font-Bold="True"
                                                            OnClick="Button2_Click" Text="Affecter" ValidationGroup="Button1Validate" Height="40px"
                                                            Width="98px" />
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;<asp:Label ID="Label3" runat="server" Font-Size="XX-Small" CssClass=" text-info pull-right"
                                                            Text="(*) "></asp:Label>
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="XX-Small" ForeColor="Red"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <div id="ScrollGrid">
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        CssClass="mGrid" PagerStyle-CssClass="pgr" Height="39px" Width="100%" PageSize="5"
                                        OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound"
                                        OnRowCommand="GridView1_Row_Command">
                                        <%--<AlternatingRowStyle CssClass="alt" />--%>
                                        <%--OnRowCancelingEdit="CancelEdit" OnRowEditing="EditAffectation"
                                    OnRowUpdating="UpdateAffectation"--%>
                                        <Columns>
                                            <%--<asp:CommandField ShowEditButton="True"/>--%>
                                            <asp:BoundField DataField="NUM_SEMESTRE" HeaderText="S" ReadOnly="True" SortExpression="NUM_SEMESTRE" />
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="false" OnCheckedChanged="CheckBox1_Checked_Changed" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="CODE_MODULE" HeaderText="CODE_MODULE" ReadOnly="True"
                                                SortExpression="CODE_MODULE" />
                                            <asp:BoundField DataField="DESIGNATION" HeaderText="DESIGNATION" ReadOnly="True"
                                                SortExpression="DESIGNATION" />
                                            <asp:BoundField DataField="CODE_CL" HeaderText="CLASSE" ReadOnly="True" SortExpression="CODE_CL" />
                                            <asp:BoundField DataField="NB_HEURES" HeaderText="NB HEURES" ReadOnly="True" SortExpression="NB_HEURES" />
                                            <asp:TemplateField HeaderText="P1" SortExpression="Active">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label4" runat="server" Text='<%# FormatNullValue(Eval("CHARGE_P1"))%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="P2" SortExpression="Active">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label5" runat="server" Text='<%# FormatNullValue(Eval("CHARGE_P2"))%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ENS1" ItemStyle-Width="150">
                                                <ItemTemplate>
                                                    <table class="style1">
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:Label ID="lblCountry1" runat="server" Text='<%# Eval("DD") %>' Font-Bold="True"
                                                                    Font-Size="X-Small" ForeColor="Black"></asp:Label>
                                                                <asp:DropDownList ID="RadComboBox1" runat="server" DataTextField="NOM_ENS" DataValueField="ID_ENS"
                                                                    EmptyMessage="Tappez le Nom" Visible="false" Filter="Contains" Font-Size="X-Small"
                                                                    Height="25px" Style="text-align: center;" Width="100px">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <strong>&nbsp;P1</strong><asp:TextBox ID="TBEnsP1" runat="server" Text='<%# Eval("CHARGE_ENS1_P1") %>'
                                                                    Font-Size="X-Small" Height="25px" Style="text-align: center;" Width="32px"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression="^[4][2]?$|^[4][0-1](\.[0-9]{0,2})?$|^[1-3][0-9](\.[0-9]{0,2})?$|^[0-9](\.[0-9]{0,2})?$|^[4][0-1](\,[0-9]{0,2})?$|^[1-3][0-9](\,[0-9]{0,2})?$|^[0-9](\,[0-9]{0,2})?$"
                                                                    ErrorMessage="*" ControlToValidate="TBEnsP1" CssClass="h5 text-danger" ValidationGroup="Button1Validate"
                                                                    SetFocusOnError="True"></asp:RegularExpressionValidator>
                                                                <asp:RangeValidator ID="Value1RangeValidator" ControlToValidate="TBEnsP1" MinimumValue="0"
                                                                    MaximumValue='<% # DataBinder.Eval (Container.DataItem, "CHARGE_P1")%>' Display="Dynamic"
                                                                    ErrorMessage=">P1" runat="server" />
                                                            </td>
                                                            <td>
                                                                <strong>P2</strong><asp:TextBox ID="TBEnsP2" runat="server" Text='<%# Eval("CHARGE_ENS1_P2") %>'
                                                                    Font-Size="X-Small" Height="25px" Style="text-align: center;" Width="32px"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationExpression="^[4][2]?$|^[4][0-1](\.[0-9]{0,2})?$|^[1-3][0-9](\.[0-9]{0,2})?$|^[0-9](\.[0-9]{0,2})?$|^[4][0-1](\,[0-9]{0,2})?$|^[1-3][0-9](\,[0-9]{0,2})?$|^[0-9](\,[0-9]{0,2})?$"
                                                                    ErrorMessage="*" ControlToValidate="TBEnsP2" CssClass="h5 text-danger" ValidationGroup="Button1Validate"
                                                                    SetFocusOnError="True"></asp:RegularExpressionValidator>
                                                                       <asp:RangeValidator ID="RangeValidator1" ControlToValidate="TBEnsP2"  
                                                                    MinimumValue="0" MaximumValue='<% # DataBinder.Eval (Container.DataItem, "CHARGE_P2")%>' Display="Dynamic" ErrorMessage=">P2" runat="server" /> 
                                                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="True"
                                                                    FilterType="Custom, numbers" ValidChars=",." TargetControlID="TBEnsP2">
                                                                </asp:FilteredTextBoxExtender>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                                <ItemStyle Width="150px"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ENS2" ItemStyle-Width="150">
                                                <ItemTemplate>
                                                    <table class="style1">
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:Label ID="lblCountry2" runat="server" Text='<%# Eval("DD2") %>' Font-Bold="True"
                                                                    Font-Size="X-Small" ForeColor="Black"></asp:Label>
                                                                <asp:DropDownList ID="RadComboBox2" runat="server" DataTextField="NOM_ENS" DataValueField="ID_ENS"
                                                                    EmptyMessage="Tappez le Nom" Visible="false" Filter="Contains" Font-Size="X-Small"
                                                                    Height="25px" Style="text-align: center;" Width="100px">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <strong>P1</strong>
                                                                <asp:TextBox ID="TBEns2P1" runat="server" Text='<%# Eval("CHARGE_ENS2_P1") %>' Font-Size="X-Small"
                                                                    Height="25px" Style="text-align: center;" Width="32px"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationExpression="^[4][2]?$|^[4][0-1](\.[0-9]{0,2})?$|^[1-3][0-9](\.[0-9]{0,2})?$|^[0-9](\.[0-9]{0,2})?$|^[4][0-1](\,[0-9]{0,2})?$|^[1-3][0-9](\,[0-9]{0,2})?$|^[0-9](\,[0-9]{0,2})?$"
                                                                    ErrorMessage="*" ControlToValidate="TBEns2P1" CssClass="h5 text-danger" ValidationGroup="Button1Validate"
                                                                    SetFocusOnError="True"></asp:RegularExpressionValidator>
                                                              <asp:RangeValidator ID="RangeValidator2" ControlToValidate="TBEns2P1"  
                                                                    MinimumValue="0" MaximumValue='<% # DataBinder.Eval (Container.DataItem, "CHARGE_P1")%>' Display="Dynamic" ErrorMessage=">P1" runat="server" /> 
                                                            </td>
                                                            <td>
                                                                <strong>P2</strong>
                                                                <asp:TextBox ID="TBEns2P2" runat="server" Text='<%# Eval("CHARGE_ENS2_P2") %>' Font-Size="X-Small"
                                                                    Height="25px" Style="text-align: center;" Width="32px"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ValidationExpression="^[4][2]?$|^[4][0-1](\.[0-9]{0,2})?$|^[1-3][0-9](\.[0-9]{0,2})?$|^[0-9](\.[0-9]{0,2})?$|^[4][0-1](\,[0-9]{0,2})?$|^[1-3][0-9](\,[0-9]{0,2})?$|^[0-9](\,[0-9]{0,2})?$"
                                                                    ErrorMessage="*" ControlToValidate="TBEns2P2" CssClass="h5 text-danger" ValidationGroup="Button1Validate"
                                                                    SetFocusOnError="True"></asp:RegularExpressionValidator>
                                                                  <asp:RangeValidator ID="RangeValidator3" ControlToValidate="TBEns2P2"  
                                                                    MinimumValue="0" MaximumValue='<% # DataBinder.Eval (Container.DataItem, "CHARGE_P2")%>' Display="Dynamic" ErrorMessage=">P2" runat="server" /> 
                                                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" Enabled="True"
                                                                    FilterType="Custom, numbers" ValidChars=",." TargetControlID="TBEns2P2">
                                                                </asp:FilteredTextBoxExtender>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                                <ItemStyle Width="150px"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ENS3" ItemStyle-Width="150">
                                                <ItemTemplate>
                                                    <table class="style1">
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:Label ID="lblCountry3" runat="server" Text='<%# Eval("dd3") %>' Font-Bold="True"
                                                                    Font-Size="X-Small" ForeColor="Black"></asp:Label>
                                                                <asp:DropDownList ID="RadComboBox3" runat="server" DataTextField="NOM_ENS" DataValueField="ID_ENS"
                                                                    EmptyMessage="Tappez le Nom" Visible="false" Filter="Contains" Font-Size="X-Small"
                                                                    Height="25px" Style="text-align: center;" Width="100px">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <strong>&nbsp;P1</strong><asp:TextBox ID="TBEns3P1" runat="server" Text='<%# Eval("CHARGE_ENS3_P1") %>'
                                                                    Font-Size="X-Small" Height="25px" Style="text-align: center;" Width="32px"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ValidationExpression="^[4][2]?$|^[4][0-1](\.[0-9]{0,2})?$|^[1-3][0-9](\.[0-9]{0,2})?$|^[0-9](\.[0-9]{0,2})?$|^[4][0-1](\,[0-9]{0,2})?$|^[1-3][0-9](\,[0-9]{0,2})?$|^[0-9](\,[0-9]{0,2})?$"
                                                                    ErrorMessage="*" ControlToValidate="TBEns3P1" CssClass="h5 text-danger" ValidationGroup="Button1Validate"
                                                                    SetFocusOnError="True"></asp:RegularExpressionValidator>
                                                                     <asp:RangeValidator ID="RangeValidator4" ControlToValidate="TBEns3P1"  
                                                                    MinimumValue="0" MaximumValue='<% # DataBinder.Eval (Container.DataItem, "CHARGE_P1")%>' Display="Dynamic" ErrorMessage=">P1" runat="server" /> 
                                                            </td>
                                                            <td>
                                                                <strong>P2</strong><asp:TextBox ID="TBEns3P2" runat="server" Text='<%# Eval("CHARGE_ENS3_P2") %>'
                                                                    Font-Size="X-Small" Height="25px" Style="text-align: center;" Width="32px"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server"
                                                                    ValidationExpression="^[4][2]?$|^[4][0-1](\.[0-9]{0,2})?$|^[1-3][0-9](\.[0-9]{0,2})?$|^[0-9](\.[0-9]{0,2})?$|^[4][0-1](\,[0-9]{0,2})?$|^[1-3][0-9](\,[0-9]{0,2})?$|^[0-9](\,[0-9]{0,2})?$"
                                                                    ErrorMessage="*" ControlToValidate="TBEns3P2" CssClass="h5 text-danger" ValidationGroup="Button1Validate"
                                                                    SetFocusOnError="True"></asp:RegularExpressionValidator>
                                                                       <asp:RangeValidator ID="RangeValidator5" ControlToValidate="TBEns3P2"  
                                                                    MinimumValue="0" MaximumValue='<% # DataBinder.Eval (Container.DataItem, "CHARGE_P2")%>' Display="Dynamic" ErrorMessage=">P2" runat="server" />
                                                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" Enabled="True"
                                                                    FilterType="Custom, numbers" ValidChars=",." TargetControlID="TBEns3P2">
                                                                </asp:FilteredTextBoxExtender>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                                <ItemStyle Width="150px"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ENS4" ItemStyle-Width="150">
                                                <ItemTemplate>
                                                    <table class="style1">
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:Label ID="lblCountry4" runat="server" Text='<%# Eval("dd4") %>' Font-Bold="True"
                                                                    Font-Size="X-Small" ForeColor="Black"></asp:Label>
                                                                <asp:DropDownList ID="RadComboBox4" runat="server" DataTextField="NOM_ENS" DataValueField="ID_ENS"
                                                                    EmptyMessage="Tappez le Nom" Visible="false" Filter="Contains" Font-Size="X-Small"
                                                                    Height="25px" Style="text-align: center;" Width="100px">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <strong>&nbsp;P1</strong><asp:TextBox ID="TBEns4P1" runat="server" Text='<%# Eval("CHARGE_ENS4_P1") %>'
                                                                    Font-Size="X-Small" Height="25px" Style="text-align: center;" Width="32px"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator17" runat="server"
                                                                    ValidationExpression="^[4][2]?$|^[4][0-1](\.[0-9]{0,2})?$|^[1-3][0-9](\.[0-9]{0,2})?$|^[0-9](\.[0-9]{0,2})?$|^[4][0-1](\,[0-9]{0,2})?$|^[1-3][0-9](\,[0-9]{0,2})?$|^[0-9](\,[0-9]{0,2})?$"
                                                                    ErrorMessage="*" ControlToValidate="TBEns4P1" CssClass="h5 text-danger" ValidationGroup="Button1Validate"
                                                                    SetFocusOnError="True"></asp:RegularExpressionValidator>
                                                                      <asp:RangeValidator ID="RangeValidator6" ControlToValidate="TBEns4P1"  
                                                                    MinimumValue="0" MaximumValue='<% # DataBinder.Eval (Container.DataItem, "CHARGE_P1")%>' Display="Dynamic" ErrorMessage=">P1" runat="server" CssClass="h5 text-danger" />
                                                            </td>
                                                            <td>
                                                                <strong>P2</strong><asp:TextBox ID="TBEns4P2" runat="server" Text='<%# Eval("CHARGE_ENS4_P2") %>'
                                                                    Font-Size="X-Small" Height="25px" Style="text-align: center;" Width="32px"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ValidationExpression="^[4][2]?$|^[4][0-1](\.[0-9]{0,2})?$|^[1-3][0-9](\.[0-9]{0,2})?$|^[0-9](\.[0-9]{0,2})?$|^[4][0-1](\,[0-9]{0,2})?$|^[1-3][0-9](\,[0-9]{0,2})?$|^[0-9](\,[0-9]{0,2})?$"
                                                                    ErrorMessage="*" ControlToValidate="TBEns4P2" CssClass="h5 text-danger" ValidationGroup="Button1Validate"
                                                                    SetFocusOnError="True"></asp:RegularExpressionValidator>
                                                                     <asp:RangeValidator ID="RangeValidator7" ControlToValidate="TBEns4P2"  
                                                                    MinimumValue="0" MaximumValue='<% # DataBinder.Eval (Container.DataItem, "CHARGE_P2")%>' Display="Dynamic" ErrorMessage=">P2" runat="server" CssClass="h5 text-danger" />
                                                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" Enabled="True"
                                                                    FilterType="Custom, numbers" ValidChars=",." TargetControlID="TBEns4P2">
                                                                </asp:FilteredTextBoxExtender>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                                <ItemStyle Width="150px"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ENS5" ItemStyle-Width="150">
                                                <ItemTemplate>
                                                    <table class="style1">
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:Label ID="lblCountry5" runat="server" Text='<%# Eval("DD5") %>' Font-Bold="True"
                                                                    Font-Size="X-Small" ForeColor="Black"></asp:Label>
                                                                <asp:DropDownList ID="RadComboBox5" runat="server" DataTextField="NOM_ENS" DataValueField="ID_ENS"
                                                                    EmptyMessage="Tappez le Nom" Visible="false" Filter="Contains" Font-Size="X-Small"
                                                                    Height="25px" Style="text-align: center;" Width="100px">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <strong>&nbsp;P1</strong><asp:TextBox ID="TBEns5P1" runat="server" Text='<%# Eval("CHARGE_ENS5_P1") %>'
                                                                    Font-Size="X-Small" Height="25px" Style="text-align: center;" Width="32px"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ValidationExpression="^[4][2]?$|^[4][0-1](\.[0-9]{0,2})?$|^[1-3][0-9](\.[0-9]{0,2})?$|^[0-9](\.[0-9]{0,2})?$|^[4][0-1](\,[0-9]{0,2})?$|^[1-3][0-9](\,[0-9]{0,2})?$|^[0-9](\,[0-9]{0,2})?$"
                                                                    ErrorMessage="*" ControlToValidate="TBEns5P1" CssClass="h5 text-danger" ValidationGroup="Button1Validate"
                                                                    SetFocusOnError="True"></asp:RegularExpressionValidator>
                                                                        <asp:RangeValidator ID="RangeValidator8" ControlToValidate="TBEns5P1"  
                                                                    MinimumValue="0" MaximumValue='<% # DataBinder.Eval (Container.DataItem, "CHARGE_P1")%>' Display="Dynamic" ErrorMessage=">P1" runat="server" CssClass="h5 text-danger" />
                                                            </td>
                                                            <td>
                                                                <strong>P2</strong><asp:TextBox ID="TBEns5P2" runat="server" Text='<%# Eval("CHARGE_ENS5_P2") %>'
                                                                    Font-Size="X-Small" Height="25px" Style="text-align: center;" Width="32px"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ValidationExpression="^[4][2]?$|^[4][0-1](\.[0-9]{0,2})?$|^[1-3][0-9](\.[0-9]{0,2})?$|^[0-9](\.[0-9]{0,2})?$|^[4][0-1](\,[0-9]{0,2})?$|^[1-3][0-9](\,[0-9]{0,2})?$|^[0-9](\,[0-9]{0,2})?$"
                                                                    ErrorMessage="*" ControlToValidate="TBEns5P2" CssClass="h5 text-danger" ValidationGroup="Button1Validate"
                                                                    SetFocusOnError="True"></asp:RegularExpressionValidator>
                                                                     <asp:RangeValidator ID="RangeValidator9" ControlToValidate="TBEns5P2"  
                                                                    MinimumValue="0" MaximumValue='<% # DataBinder.Eval (Container.DataItem, "CHARGE_P2")%>' Display="Dynamic" ErrorMessage=">P2" runat="server" CssClass="h5 text-danger" />
                                                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" Enabled="True"
                                                                    FilterType="Custom, numbers" ValidChars=",." TargetControlID="TBEns5P2">
                                                                </asp:FilteredTextBoxExtender>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                                <ItemStyle Width="150px"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Type_Epreuve">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCountry6" runat="server" Text='<%# Eval("TYPE_EPREUVE") %>' Font-Bold="True"
                                                        Font-Size="X-Small" ForeColor="Black"></asp:Label>
                                                    <asp:DropDownList ID="type_ep" runat="server" AppendDataBoundItems="true" DataTextField="LIB_NOME"
                                                        Visible="false" DataValueField="CODE_NOME">
                                                    </asp:DropDownList>
                                                    <%--<asp:SqlDataSource ID="tpepreuve" runat="server" 
                         ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
                                                            ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
                                                            
                        
                                                            SelectCommand="SELECT &quot;CODE_STR&quot;, &quot;CODE_NOME&quot;,&quot;LIB_NOME&quot; FROM &quot;CODE_NOMENCLATURE&quot; WHERE CODE_STR='78'"></asp:SqlDataSource>--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle Font-Bold="False" />
                                        <HeaderStyle CssClass="th" />
                                        <PagerStyle CssClass="pgr" />
                                    </asp:GridView>
                                </div>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <br />
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
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
        </table>
    </div>
    <br />
    <br />
    
    
    <br />
</asp:Content>
