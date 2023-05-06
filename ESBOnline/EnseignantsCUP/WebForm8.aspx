<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm8.aspx.cs" Inherits="ESPOnline.EnseignantsCUP.WebForm8" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Contents/jquery.notifyBar.css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="../Contents/Scripts/jquery.notifyBar.js" type="text/javascript"></script>
   
    <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        .Grid td
        {
            background-color: #A1DCF2;
            color: black;
            font-size: 10pt;
            line-height: 200%;
        }
        .Grid th
        {
            background-color: #3AC0F2;
            color: White;
            font-size: 10pt;
            line-height: 200%;
        }
        .ChildGrid td
        {
            background-color: #eee !important;
            color: black;
            font-size: 10pt;
            line-height: 200%;
        }
        .ChildGrid th
        {
            background-color: #6C6C6C !important;
            color: White;
            font-size: 10pt;
            line-height: 200%;
        }
        .GridViewEditRow input[type=text]
        {
            width: 50px;
        }
        /* size textboxes */
        .GridViewEditRow select
        {
            width: 90px;
        }
    </style>
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
    <script language="javascript" type="text/javascript">
        function expandcollapse(obj, row) {
            var div = document.getElementById(obj);
            var img = document.getElementById('img' + obj);

            if (div.style.display == "none") {
                div.style.display = "block";
                if (row == 'alt') {
                    img.src = "../Contents/Img/minus.png";
                }
                else {
                    img.src = "../Contents/Img/minus.png";
                }
                img.alt = "Close to view other Customers";
            }
            else {
                div.style.display = "none";
                if (row == 'alt') {
                    img.src = "../Contents/Img/plus.png";
                }
                else {
                    img.src = "../Contents/Img/plus.png";
                }
                img.alt = "Expand to show Orders";
            }
        } 
    </script>
</head>
<body>
    <%--   OnRowUpdating="UpdateAffectaion" OnRowEditing="gvAffectation_OnRowEditing"--%>
    <form id="form1" runat="server">
    <div>
        <%-- <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>

        --%>
        <asp:Button ID="Button2" runat="server" OnClick="ExportExcel" Text="ExportToExcel" /><br />
        <br />
        <asp:GridView ID="gvClasses" runat="server" AutoGenerateColumns="false" CssClass="Grid"
            Width="100%" OnRowDataBound="OnRowDataBound" DataKeyNames="CODE_CL">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <a href="javascript:expandcollapse('div<%# Eval("CODE_CL") %>', 'one');">
                            <img id="imgdiv<%# Eval("CODE_CL") %>" alt="Click to show/hide Orders for Customer <%# Eval("CODE_CL") %>"
                                width="9px" border="0" src="../Contents/Img/plus.png" />
                        </a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField ItemStyle-Width="98%" DataField="CODE_CL" HeaderText="CLASSES" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <tr>
                            <td colspan="100%">
                                <div id="div<%# Eval("CODE_CL") %>" style="display: none; position: relative; left: 15px;
                                    overflow: auto; width: 97%">
                                    <asp:GridView ID="gvAffectation" runat="server" AutoGenerateColumns="false" OnRowEditing="gvAffectation_OnRowEditing"
                                        OnRowDataBound="grid_RowDataBound" OnRowUpdating="grid_RowUpdating" OnRowCancelingEdit="grid_RowCancelingEdit"
                                        DataKeyNames="CODE_CL" CssClass="ChildGrid">
                                        <EditRowStyle CssClass="GridViewEditRow" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkEdit" runat="server" Text="" CommandName="Edit" ToolTip="Edit"
                                                        CommandArgument=''>  <img src="../Contents/Img/show.png" /> </asp:LinkButton>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <%--ValidationGroup="editGrp"--%>
                                                    <asp:LinkButton ID="lnkInsert" runat="server" Text="" CommandName="Update" ValidationGroup="Button1Validate"
                                                        ToolTip="Save" CommandArgument=''><img src="../Contents/Img/icon_save.png"  /></asp:LinkButton>
                                                    <asp:LinkButton ID="lnkCancel" runat="server" Text="" CommandName="Cancel" ToolTip="Cancel"
                                                        CommandArgument=''><img src="../Contents/Img/Refresh.png" /></asp:LinkButton>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Classes" Visible="false">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtLastName" runat="server" Text='<%# Bind("CODE_CL") %>'></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblcodecl" runat="server" Text='<%# Bind("CODE_CL") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="CODE">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblcodemodule" Text='<%# Eval("CODE_MODULE")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="DESIGNATION">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDESIGNATION" runat="server" Text='<%# Eval("DESIGNATION") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="150px" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="NB_HEURES" HeaderText="HEURES" ReadOnly="True" />
                                            <asp:TemplateField HeaderText="P1" SortExpression="Active">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label4" runat="server" Style="text-align: center;" Text='<%#Eval("CHARGE_P1")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="P2" SortExpression="Active">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label5" Style="text-align: center;" runat="server" Text='<%# Eval("CHARGE_P2")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ENS1" ItemStyle-Width="150">
                                                <EditItemTemplate>
                                                    <table class="style1">
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:DropDownList ID="ddeneseignant" runat="server">
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
                                                                <asp:RangeValidator ID="Value1RangeValidator" ControlToValidate="TBEnsP1"  
                                                                    MinimumValue="0" MaximumValue='<% # DataBinder.Eval (Container.DataItem, "CHARGE_P1")%>' Display="Dynamic" ErrorMessage="**" runat="server" />
                                                            </td>
                                                            <td>
                                                                <strong>P2</strong><asp:TextBox ID="TBEnsP2" runat="server" Text='<%# Eval("CHARGE_ENS1_P2") %>'
                                                                    Font-Size="X-Small" Height="25px" Style="text-align: center;" Width="32px"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationExpression="^[4][2]?$|^[4][0-1](\.[0-9]{0,2})?$|^[1-3][0-9](\.[0-9]{0,2})?$|^[0-9](\.[0-9]{0,2})?$|^[4][0-1](\,[0-9]{0,2})?$|^[1-3][0-9](\,[0-9]{0,2})?$|^[0-9](\,[0-9]{0,2})?$"
                                                                    ErrorMessage="*" ControlToValidate="TBEnsP2" CssClass="h5 text-danger" ValidationGroup="Button1Validate"
                                                                    SetFocusOnError="True"></asp:RegularExpressionValidator>
                                                                   <asp:RangeValidator ID="RangeValidator1" ControlToValidate="TBEnsP2"  
                                                                    MinimumValue="0" MaximumValue='<% # DataBinder.Eval (Container.DataItem, "CHARGE_P2")%>' Display="Dynamic" ErrorMessage="**" runat="server" />    
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <table class="style1">
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:Label ID="ddleneseignant" runat="server" Text='<%# Bind("NOM_ENS") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <strong>&nbsp;P1</strong><asp:TextBox ID="TBREnsP1" runat="server" Text='<%# Eval("CHARGE_ENS1_P1") %>'
                                                                    ReadOnly="true" Font-Size="X-Small" Height="25px" Style="text-align: center;"
                                                                    Width="32px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <strong>P2</strong><asp:TextBox ID="TBEnsP2" runat="server" Text='<%# Eval("CHARGE_ENS1_P2") %>'
                                                                    ReadOnly="true" Font-Size="X-Small" Height="25px" Style="text-align: center;"
                                                                    Width="32px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ENS2" ItemStyle-Width="150">
                                                <EditItemTemplate>
                                                    <table class="style1">
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:DropDownList ID="ddeneseignant2" runat="server">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <strong>&nbsp;P1</strong><asp:TextBox ID="TBEns2P1" runat="server" Text='<%# Eval("CHARGE_ENS2_P1") %>'
                                                                    Font-Size="X-Small" Height="25px" Style="text-align: center;" Width="32px"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationExpression="^[4][2]?$|^[4][0-1](\.[0-9]{0,2})?$|^[1-3][0-9](\.[0-9]{0,2})?$|^[0-9](\.[0-9]{0,2})?$|^[4][0-1](\,[0-9]{0,2})?$|^[1-3][0-9](\,[0-9]{0,2})?$|^[0-9](\,[0-9]{0,2})?$"
                                                                    ErrorMessage="*" ControlToValidate="TBEns2P1" CssClass="h5 text-danger" ValidationGroup="Button1Validate"
                                                                    SetFocusOnError="True"></asp:RegularExpressionValidator>
                                                                     <asp:RangeValidator ID="RangeValidator2" ControlToValidate="TBEns2P1"  
                                                                    MinimumValue="0" MaximumValue='<% # DataBinder.Eval (Container.DataItem, "CHARGE_P1")%>' Display="Dynamic" ErrorMessage="**" runat="server" />  
                                                            </td>
                                                            <td>
                                                                <strong>P2</strong><asp:TextBox ID="TBEns2P2" runat="server" Text='<%# Eval("CHARGE_ENS2_P2") %>'
                                                                    Font-Size="X-Small" Height="25px" Style="text-align: center;" Width="32px"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ValidationExpression="^[4][2]?$|^[4][0-1](\.[0-9]{0,2})?$|^[1-3][0-9](\.[0-9]{0,2})?$|^[0-9](\.[0-9]{0,2})?$|^[4][0-1](\,[0-9]{0,2})?$|^[1-3][0-9](\,[0-9]{0,2})?$|^[0-9](\,[0-9]{0,2})?$"
                                                                    ErrorMessage="*" ControlToValidate="TBEns2P2" CssClass="h5 text-danger" ValidationGroup="Button1Validate"
                                                                    SetFocusOnError="True"></asp:RegularExpressionValidator>
                                                                     <asp:RangeValidator ID="RangeValidator3" ControlToValidate="TBEns2P2"  
                                                                    MinimumValue="0" MaximumValue='<% # DataBinder.Eval (Container.DataItem, "CHARGE_P2")%>' Display="Dynamic" ErrorMessage="**" runat="server" />  
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <table class="style1">
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:Label ID="ddleneseignant2" runat="server" Text='<%# Bind("NOM_ENS2") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <strong>&nbsp;P1</strong><asp:TextBox ID="TBREns2P1" runat="server" Text='<%# Eval("CHARGE_ENS2_P1") %>'
                                                                    ReadOnly="true" Font-Size="X-Small" Height="25px" Style="text-align: center;"
                                                                    Width="32px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <strong>P2</strong><asp:TextBox ID="TBEns2P2" runat="server" Text='<%# Eval("CHARGE_ENS2_P2") %>'
                                                                    ReadOnly="true" Font-Size="X-Small" Height="25px" Style="text-align: center;"
                                                                    Width="32px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ENS3" ItemStyle-Width="150">
                                                <EditItemTemplate>
                                                    <table class="style1">
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:DropDownList ID="ddeneseignant3" runat="server">
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
                                                                    MinimumValue="0" MaximumValue='<% # DataBinder.Eval (Container.DataItem, "CHARGE_P1")%>' Display="Dynamic" ErrorMessage="**" runat="server" />  
                                                            </td>
                                                            <td>
                                                                <strong>P2</strong><asp:TextBox ID="TBEns3P2" runat="server" Text='<%# Eval("CHARGE_ENS3_P2") %>'
                                                                    Font-Size="X-Small" Height="25px" Style="text-align: center;" Width="32px"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ValidationExpression="^[4][2]?$|^[4][0-1](\.[0-9]{0,2})?$|^[1-3][0-9](\.[0-9]{0,2})?$|^[0-9](\.[0-9]{0,2})?$|^[4][0-1](\,[0-9]{0,2})?$|^[1-3][0-9](\,[0-9]{0,2})?$|^[0-9](\,[0-9]{0,2})?$"
                                                                    ErrorMessage="*" ControlToValidate="TBEns2P2" CssClass="h5 text-danger" ValidationGroup="Button1Validate"
                                                                    SetFocusOnError="True"></asp:RegularExpressionValidator>
                                                                     <asp:RangeValidator ID="RangeValidator5" ControlToValidate="TBEns3P2"  
                                                                    MinimumValue="0" MaximumValue='<% # DataBinder.Eval (Container.DataItem, "CHARGE_P2")%>' Display="Dynamic" ErrorMessage="**" runat="server" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <table class="style1">
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:Label ID="ddleneseignant3" runat="server" Text='<%# Bind("NOM_ENS3") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <strong>&nbsp;P1</strong><asp:TextBox ID="TBREns3P1" runat="server" Text='<%# Eval("CHARGE_ENS3_P1") %>'
                                                                    ReadOnly="true" Font-Size="X-Small" Height="25px" Style="text-align: center;"
                                                                    Width="32px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <strong>P2</strong><asp:TextBox ID="TBEns3P2" runat="server" Text='<%# Eval("CHARGE_ENS3_P2") %>'
                                                                    ReadOnly="true" Font-Size="X-Small" Height="25px" Style="text-align: center;"
                                                                    Width="32px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ENS4" ItemStyle-Width="150">
                                                <EditItemTemplate>
                                                    <table class="style1">
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:DropDownList ID="ddeneseignant4" runat="server">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <strong>&nbsp;P1</strong><asp:TextBox ID="TBEns4P1" runat="server" Text='<%# Eval("CHARGE_ENS4_P1") %>'
                                                                    Font-Size="X-Small" Height="25px" Style="text-align: center;" Width="32px"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ValidationExpression="^[4][2]?$|^[4][0-1](\.[0-9]{0,2})?$|^[1-3][0-9](\.[0-9]{0,2})?$|^[0-9](\.[0-9]{0,2})?$|^[4][0-1](\,[0-9]{0,2})?$|^[1-3][0-9](\,[0-9]{0,2})?$|^[0-9](\,[0-9]{0,2})?$"
                                                                    ErrorMessage="*" ControlToValidate="TBEns4P1" CssClass="h5 text-danger" ValidationGroup="Button1Validate"
                                                                    SetFocusOnError="True"></asp:RegularExpressionValidator>
                                                                     <asp:RangeValidator ID="RangeValidator6" ControlToValidate="TBEns4P1"  
                                                                    MinimumValue="0" MaximumValue='<% # DataBinder.Eval (Container.DataItem, "CHARGE_P1")%>' Display="Dynamic" ErrorMessage="**" runat="server" CssClass="h5 text-danger" />
                                                            </td>
                                                            <td>
                                                                <strong>P2</strong><asp:TextBox ID="TBEns4P2" runat="server" Text='<%# Eval("CHARGE_ENS4_P2") %>'
                                                                    Font-Size="X-Small" Height="25px" Style="text-align: center;" Width="32px"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ValidationExpression="^[4][2]?$|^[4][0-1](\.[0-9]{0,2})?$|^[1-3][0-9](\.[0-9]{0,2})?$|^[0-9](\.[0-9]{0,2})?$|^[4][0-1](\,[0-9]{0,2})?$|^[1-3][0-9](\,[0-9]{0,2})?$|^[0-9](\,[0-9]{0,2})?$"
                                                                    ErrorMessage="*" ControlToValidate="TBEns4P2" CssClass="h5 text-danger" ValidationGroup="Button1Validate"
                                                                    SetFocusOnError="True"></asp:RegularExpressionValidator>
                                                                     <asp:RangeValidator ID="RangeValidator7" ControlToValidate="TBEns4P2"  
                                                                    MinimumValue="0" MaximumValue='<% # DataBinder.Eval (Container.DataItem, "CHARGE_P2")%>' Display="Dynamic" ErrorMessage="**" runat="server" CssClass="h5 text-danger" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <table class="style1">
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:Label ID="ddleneseignant4" runat="server" Text='<%# Bind("NOM_ENS4") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <strong>&nbsp;P1</strong><asp:TextBox ID="TBREns4P1" runat="server" Text='<%# Eval("CHARGE_ENS4_P1") %>'
                                                                    ReadOnly="true" Font-Size="X-Small" Height="25px" Style="text-align: center;"
                                                                    Width="32px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <strong>P2</strong><asp:TextBox ID="TBEns4P2" runat="server" Text='<%# Eval("CHARGE_ENS4_P2") %>'
                                                                    ReadOnly="true" Font-Size="X-Small" Height="25px" Style="text-align: center;"
                                                                    Width="32px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ENS5" ItemStyle-Width="150">
                                                <EditItemTemplate>
                                                    <table class="style1">
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:DropDownList ID="ddeneseignant5" runat="server">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <strong>&nbsp;P1</strong><asp:TextBox ID="TBEns5P1" runat="server" Text='<%# Eval("CHARGE_ENS5_P1") %>'
                                                                    Font-Size="X-Small" Height="25px" Style="text-align: center;" Width="32px"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ValidationExpression="^[4][2]?$|^[4][0-1](\.[0-9]{0,2})?$|^[1-3][0-9](\.[0-9]{0,2})?$|^[0-9](\.[0-9]{0,2})?$|^[4][0-1](\,[0-9]{0,2})?$|^[1-3][0-9](\,[0-9]{0,2})?$|^[0-9](\,[0-9]{0,2})?$"
                                                                    ErrorMessage="*" ControlToValidate="TBEns5P1" CssClass="h5 text-danger" ValidationGroup="Button1Validate"
                                                                    SetFocusOnError="True"></asp:RegularExpressionValidator>
                                                                    <asp:RangeValidator ID="RangeValidator8" ControlToValidate="TBEns5P1"  
                                                                    MinimumValue="0" MaximumValue='<% # DataBinder.Eval (Container.DataItem, "CHARGE_P1")%>' Display="Dynamic" ErrorMessage="**" runat="server" CssClass="h5 text-danger" />

                                                            </td>
                                                            <td>
                                                                <strong>P2</strong><asp:TextBox ID="TBEns5P2" runat="server" Text='<%# Eval("CHARGE_ENS5_P2") %>'
                                                                    Font-Size="X-Small" Height="25px" Style="text-align: center;" Width="32px"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server"
                                                                    ValidationExpression="^[4][2]?$|^[4][0-1](\.[0-9]{0,2})?$|^[1-3][0-9](\.[0-9]{0,2})?$|^[0-9](\.[0-9]{0,2})?$|^[4][0-1](\,[0-9]{0,2})?$|^[1-3][0-9](\,[0-9]{0,2})?$|^[0-9](\,[0-9]{0,2})?$"
                                                                    ErrorMessage="*" ControlToValidate="TBEns5P2" CssClass="h5 text-danger" ValidationGroup="Button1Validate"
                                                                    SetFocusOnError="True"></asp:RegularExpressionValidator>
                                                                    <asp:RangeValidator ID="RangeValidator9" ControlToValidate="TBEns5P2"  
                                                                    MinimumValue="0" MaximumValue='<% # DataBinder.Eval (Container.DataItem, "CHARGE_P2")%>' Display="Dynamic" ErrorMessage="**" runat="server" CssClass="h5 text-danger" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <table class="style1">
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:Label ID="ddleneseignant5" runat="server" Text='<%# Bind("NOM_ENS5") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <strong>&nbsp;P1</strong><asp:TextBox ID="TBREns5P1" runat="server" Text='<%# Eval("CHARGE_ENS5_P1") %>'
                                                                    ReadOnly="true" Font-Size="X-Small" Height="25px" Style="text-align: center;"
                                                                    Width="32px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <strong>P2</strong><asp:TextBox ID="TBEns5P2" runat="server" Text='<%# Eval("CHARGE_ENS5_P2") %>'
                                                                    ReadOnly="true" Font-Size="X-Small" Height="25px" Style="text-align: center;"
                                                                    Width="32px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="EPREUVE">
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddepreuve" runat="server" Visible="false">
                                                    </asp:DropDownList>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblepreuve" runat="server" Text='<%# Bind("TYPE_EPREUVE")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
        ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
        SelectCommand="SELECT   ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL, CODE_MODULE,(select Designation from ESP_MODULE where ESP_MODULE.CODE_MODULE=ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE)as designation,  NB_HEURES, CHARGE_P1,CHARGE_P2,(select ESP_ENSEIGNANT.NOM_ENS from ESP_ENSEIGNANT where ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS=ESP_ENSEIGNANT.ID_ENS)as ens1,CHARGE_ENS1_P1,CHARGE_ENS1_P2,(select ESP_ENSEIGNANT.NOM_ENS from ESP_ENSEIGNANT where ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS2=ESP_ENSEIGNANT.ID_ENS)as ens2 ,CHARGE_ENS2_P1,CHARGE_ENS2_P2 ,(select ESP_ENSEIGNANT.NOM_ENS from ESP_ENSEIGNANT where ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS3=ESP_ENSEIGNANT.ID_ENS)as ens3,CHARGE_ENS3_P1,CHARGE_ENS3_P2,(select ESP_ENSEIGNANT.NOM_ENS from ESP_ENSEIGNANT where ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS4=ESP_ENSEIGNANT.ID_ENS)as ens4,CHARGE_ENS4_P1,CHARGE_ENS4_P2, (select ESP_ENSEIGNANT.NOM_ENS from ESP_ENSEIGNANT where ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS5=ESP_ENSEIGNANT.ID_ENS)as ens5,CHARGE_ENS5_P1,CHARGE_ENS5_P2, (select lib_nome from CODE_NOMENCLATURE where CODE_NOMENCLATURE.code_nome=ESP_MODULE_PANIER_CLASSE_SAISO.TYPE_EPREUVE and  CODE_NOMENCLATURE.CODE_STR='78') as TYPE_EPREUVE FROM   ESP_MODULE_PANIER_CLASSE_SAISO WHERE ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB = 2013 and ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE in (select CODE_MODULE from esp_module where esp_module.up = 'UP_TELECOM'  )
 AND ESP_MODULE_PANIER_CLASSE_SAISO.num_semestre=1  AND ESP_MODULE_PANIER_CLASSE_SAISO.annee_deb=2013 order by DESIGNATION
"></asp:SqlDataSource>
    </form>
</body>
</html>
