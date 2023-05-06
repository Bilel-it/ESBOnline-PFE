<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm4.aspx.cs" Inherits="ESPOnline.EnseignantsCUP.WebForm4" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Contents/jquery.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="../Contents/jquery.notifyBar.css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="../Contents/Scripts/jquery.notifyBar.js" type="text/javascript"></script>
      <%-- <link href="../Contents/Css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link type="text/css" rel="stylesheet" href="Styles/Site.css" />--%>
    <style type="text/css">
         .style1
        {border: solid 1px black;
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
        .collapse
    {
        background-position: left -172px;
        height: 14px;
        width: 13px;
        background-repeat: no-repeat;
        background-image: url('../plus.png');
        cursor:pointer;
    }
    .expand
    {
        background-position: -14px -187px;
        height: 14px;
        width: 13px;
        background-repeat: no-repeat;
        background-image: url('../plus.png');
        cursor:pointer;
    }
   table
     {
        border:solid 1px black;
    }
        table td 
        {
            border-right:solid 1px black; 
            border-bottom:solid 1px black; 
        }
        table th
        {
     
            border-bottom:solid 1px black; 
        }
    .SUBDIV table {
        border:0px;
        border-left:1px solid black;
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
                html: "Settings aren't changed!"
            })
        };
    </script>
    <%--<script type="text/javascript">
        $("[src*=plus]").live("click", function () {
            $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
            $(this).attr("src", "../Contents/Img/minus.png");
        });
        $("[src*=minus]").live("click", function () {
            $(this).attr("src", "../Contents/Img/plus.png");
            $(this).closest("tr").next().remove();
        }); </script>--%>
     
    
<script language="javascript">
    $(document).ready(function () {
        // THIS IS FOR HIDE ALL DETAILS ROW
        $(".SUBDIV table tr:not(:first-child)").not("tr tr").hide();
        $(".SUBDIV .btncolexp").click(function () {
            $(this).closest('tr').next('tr').toggle();
            //this is for change img of btncolexp button
            if ($(this).attr('class').toString() == "btncolexp collapse") {
                $(this).addClass('expand');
                $(this).removeClass('collapse');
            }
            else {
                $(this).removeClass('expand');
                $(this).addClass('collapse');
            }
        });
    });
</script>
</head>
<body>
    <form id="form1" runat="server">
    <center>
        <asp:RadioButtonList ID="Semestre" runat="server" RepeatDirection="Vertical" AutoPostBack="True">
            <asp:ListItem Value="1" Selected="True">Semestre 1</asp:ListItem>
            <asp:ListItem Value="2">Semestre 2</asp:ListItem>
        </asp:RadioButtonList>
       
    </center>
    <asp:Button ID="Button1" runat="server" Text="ExportToPDF" /><asp:Button ID="Button2"
        runat="server" OnClick="ExportExcel" Text="ExportToXslt" />
    <br /><%--<asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>--%>
    <center>
  <%--  <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>--%>
    <asp:ListView ID="ListView1" runat="server" DataKeyNames="CODE_CL" OnItemDataBound="test">
        <LayoutTemplate>
           
            <table width="100%" border="0" cellpadding="0" cellspacing="0" >
                <tr>
                    <th width="15px">
                  
                    </th>
                    <th width="100%">
                        Classe
                    </th>
                    <%-- <th>City</th>--%>
                </tr>
            </table>
            <div runat="server" id="itemPlaceHolder">
            </div>
        </LayoutTemplate>
        <ItemTemplate>
       
            <div id="Div1" class="SUBDIV" runat="server">
              
                <table width="100%" border="0" cellpadding="0" id="table1" cellspacing="0">
             
                    <tr>
                    
                        <td width="16px" height="16px">
                           
                            <div class="btncolexp collapse">
                            <%-- <div Style="display: none">   --%>
                                &nbsp;
                            </div>
                        </td>
                        <td width="100%">
                            <%# DataBinder.Eval(Container.DataItem, "CODE_CL") %>
                        </td>
                        <%--<td width="100%"><%# Container.DataItem %></td>--%>
                    </tr>
                    <tr>
                        <td colspan="6">
                         <div style="margin:5px">
                      
                          <%--   style="margin: 20px" --%>
                          <%--Style="display: none"--%>
                        <%--    <div >--%>
                              <%--<img alt="" style="cursor: pointer" src="../Contents/Img/plus.png"  />--%>
                             <%-- <asp:Panel ID="pnlEmployees" runat="server" Style="display: none">--%>
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowDataBound="grid_RowDataBound"  CssClass="mGrid"
                                    OnRowEditing="grid_RowEditing" OnRowUpdating="grid_RowUpdating" OnRowCancelingEdit="grid_RowCancelingEdit">
                                    <Columns>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkEdit" runat="server" Text="" CommandName="Edit" ToolTip="Edit"
                                                    CommandArgument=''>  <img src="../Contents/Img/show.png" /> </asp:LinkButton>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:LinkButton ID="lnkInsert" runat="server" Text="" ValidationGroup="editGrp" CommandName="Update"
                                                    ToolTip="Save" CommandArgument=''><img src="../Contents/Img/icon_save.png"  /></asp:LinkButton>
                                                <asp:LinkButton ID="lnkCancel" runat="server" Text="" CommandName="Cancel" ToolTip="Cancel"
                                                    CommandArgument=''><img src="../Contents/Img/Refresh.png" /></asp:LinkButton>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="CODE CL" Visible="false">
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
                                       <%-- <asp:BoundField DataField="DESIGNATION" HeaderText="DESIGNATION" ReadOnly="True"
                                            SortExpression="DESIGNATION"  />--%>
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
                                        <%--    <asp:BoundField HeaderText="ID_ENS" DataField="ID_ENS" />--%>
                                        <%-- <asp:TemplateField HeaderText="ENS1">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtIDENS" runat="server" Text='<%# Bind("ID_ENS") %>' CssClass=""
                                                    MaxLength="30"></asp:TextBox>
                                                     <asp:RequiredFieldValidator ID="valFirstName" runat="server" ControlToValidate="txtIDENS"
                                    Display="Dynamic" ErrorMessage="First Name is required." ForeColor="Red" SetFocusOnError="True"
                                   ValidationGroup="editGrp">*</asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblFirstName" runat="server" Text='<%# Bind("ID_ENS") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <%--<asp:BoundField HeaderText="codeup" DataField="CODE_UE" />--%>
                                        <%--<asp:BoundField HeaderText="ID_ENS2" DataField="ID_ENS2" />--%>
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
                                                        </td>
                                                        <td>
                                                            <strong>P2</strong><asp:TextBox ID="TBEnsP2" runat="server" Text='<%# Eval("CHARGE_ENS1_P2") %>'
                                                                Font-Size="X-Small" Height="25px" Style="text-align: center;" Width="32px"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationExpression="^[4][2]?$|^[4][0-1](\.[0-9]{0,2})?$|^[1-3][0-9](\.[0-9]{0,2})?$|^[0-9](\.[0-9]{0,2})?$|^[4][0-1](\,[0-9]{0,2})?$|^[1-3][0-9](\,[0-9]{0,2})?$|^[0-9](\,[0-9]{0,2})?$"
                                                                ErrorMessage="*" ControlToValidate="TBEnsP2" CssClass="h5 text-danger" ValidationGroup="Button1Validate"
                                                                SetFocusOnError="True"></asp:RegularExpressionValidator>
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
                                                        </td>
                                                        <td>
                                                            <strong>P2</strong><asp:TextBox ID="TBEns2P2" runat="server" Text='<%# Eval("CHARGE_ENS2_P2") %>'
                                                                Font-Size="X-Small" Height="25px" Style="text-align: center;" Width="32px"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ValidationExpression="^[4][2]?$|^[4][0-1](\.[0-9]{0,2})?$|^[1-3][0-9](\.[0-9]{0,2})?$|^[0-9](\.[0-9]{0,2})?$|^[4][0-1](\,[0-9]{0,2})?$|^[1-3][0-9](\,[0-9]{0,2})?$|^[0-9](\,[0-9]{0,2})?$"
                                                                ErrorMessage="*" ControlToValidate="TBEns2P2" CssClass="h5 text-danger" ValidationGroup="Button1Validate"
                                                                SetFocusOnError="True"></asp:RegularExpressionValidator>
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
                                                        </td>
                                                        <td>
                                                            <strong>P2</strong><asp:TextBox ID="TBEns3P2" runat="server" Text='<%# Eval("CHARGE_ENS3_P2") %>'
                                                                Font-Size="X-Small" Height="25px" Style="text-align: center;" Width="32px"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ValidationExpression="^[4][2]?$|^[4][0-1](\.[0-9]{0,2})?$|^[1-3][0-9](\.[0-9]{0,2})?$|^[0-9](\.[0-9]{0,2})?$|^[4][0-1](\,[0-9]{0,2})?$|^[1-3][0-9](\,[0-9]{0,2})?$|^[0-9](\,[0-9]{0,2})?$"
                                                                ErrorMessage="*" ControlToValidate="TBEns2P2" CssClass="h5 text-danger" ValidationGroup="Button1Validate"
                                                                SetFocusOnError="True"></asp:RegularExpressionValidator>
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
                                                        </td>
                                                        <td>
                                                            <strong>P2</strong><asp:TextBox ID="TBEns4P2" runat="server" Text='<%# Eval("CHARGE_ENS4_P2") %>'
                                                                Font-Size="X-Small" Height="25px" Style="text-align: center;" Width="32px"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ValidationExpression="^[4][2]?$|^[4][0-1](\.[0-9]{0,2})?$|^[1-3][0-9](\.[0-9]{0,2})?$|^[0-9](\.[0-9]{0,2})?$|^[4][0-1](\,[0-9]{0,2})?$|^[1-3][0-9](\,[0-9]{0,2})?$|^[0-9](\,[0-9]{0,2})?$"
                                                                ErrorMessage="*" ControlToValidate="TBEns4P2" CssClass="h5 text-danger" ValidationGroup="Button1Validate"
                                                                SetFocusOnError="True"></asp:RegularExpressionValidator>
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
                                                        </td>
                                                        <td>
                                                            <strong>P2</strong><asp:TextBox ID="TBEns5P2" runat="server" Text='<%# Eval("CHARGE_ENS5_P2") %>'
                                                                Font-Size="X-Small" Height="25px" Style="text-align: center;" Width="32px"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ValidationExpression="^[4][2]?$|^[4][0-1](\.[0-9]{0,2})?$|^[1-3][0-9](\.[0-9]{0,2})?$|^[0-9](\.[0-9]{0,2})?$|^[4][0-1](\,[0-9]{0,2})?$|^[1-3][0-9](\,[0-9]{0,2})?$|^[0-9](\,[0-9]{0,2})?$"
                                                                ErrorMessage="*" ControlToValidate="TBEns5P2" CssClass="h5 text-danger" ValidationGroup="Button1Validate"
                                                                SetFocusOnError="True"></asp:RegularExpressionValidator>
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
                                        <%-- <asp:TemplateField  HeaderText="SEMESTRE">
                                             <ItemTemplate>
                                                <asp:Label ID="lblsem" Text='<%# Eval("NUM_SEMESTRE") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                    </Columns>
                                </asp:GridView>
                              </asp:Panel>
                            </div>
                        </td>
                    </tr>
                </table>
        </div>
       
            
        </ItemTemplate>
    </asp:ListView></center>
    </form>
</body>
</html>
