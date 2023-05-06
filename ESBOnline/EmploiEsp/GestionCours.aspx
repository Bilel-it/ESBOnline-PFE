<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/EmploiEsp/SiteEDT.Master"  CodeBehind="~/EmploiEsp/GestionCours.aspx.cs" Inherits="ESPOnline.EmploiEsp.GestionCours" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <meta http-equiv="content-type" content="text/html; charset=utf-8" />
        <meta name="description" content="" />
        <meta name="keywords" content="" />
        <script src="../EDTCss/jsemploi/jquery.min.js" type="text/javascript"></script>
        <script src="../EDTCss/jsemploi/skel.min.js" type="text/javascript"></script>
        <script src="../EDTCss/jsemploi/skel-layers.min.js" type="text/javascript"></script>
        <script src="../EDTCss/jsemploi/init.js" type="text/javascript"></script>
        <link rel="stylesheet" href="../EDTCss/cssemploi/skel.css" />
        <link rel="stylesheet" href="../EDTCss/cssemploi/style.css" />
        <link rel="stylesheet" href="../EDTCss/cssemploi/style-desktop.css" />
        <!--[if lte IE 9]><link rel="stylesheet" href="css/ie9.css" /><![endif]-->
        <!--[if lte IE 8]><script src="js/html5shiv.js"></script><![endif]-->
    <link rel="stylesheet" type="text/css" href="../Css-Template/css/style.css" />

    <style type="text/css">
        .style1
        {
            color: #CCCCCC;
            font-weight: bold;
            text-align: center;
        }
        .style2
        {
            font-size: large;
        }
    </style>
  
    
</asp:Content>

   <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <asp:HiddenField runat="server" ID="hdnIDEntity" Value="" />
    <table cellpadding="0" cellspacing="0" width="100%">
        <tbody>
            <tr>
                <td >
                    <table id="Table1"  cellspacing="2" cellpadding="2" align="center" width="70%" >
                        <tbody>
                            <tr>
                                <td colspan="2" class="style1" height="20px">
                                    <strong class="style2">Gestion des cours ESPRIT<br />
                                    </strong></td>
                            </tr>
                            <tr>
                                <td align=center>
                                    <table width="100%" height="100%">
                                        <tbody>
                                            <tr>
                                                <td valign="middle" style="background-color: #666666">
                                                   
                                                   <asp:GridView runat="server" ID="Gridens" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="gridView_PageIndexChanging"
                                                        PageSize="10" Style="border-bottom: white 2px ridge; border-left: white 2px ridge;
                                                        background-color: white; width: 100%; border-top: white 2px ridge; border-right: white 2px ridge;"
                                                        BorderWidth="0px" BorderColor="White" CellSpacing="1" CellPadding="3" CssClass="grid"
                                                        RowStyle-CssClass="ItemStyle" HeaderStyle-CssClass="FixedHeaderStyle" Width="100%"
                                                        GridLines="None" EmptyDataRowStyle-CssClass="ItemStyle"  DataKeyNames="NOM_ENS"
                                                        onrowediting="GrdEmpData_RowEditing"   onrowcancelingedit="GrdEmpData_RowCancelingEdit" 
                                                         onrowupdating ="GrdEmpData_RowUpdating"
                                                         OnRowDeleting ="Grdenseig_RowDeleting"
                                                         
                                                         >
                                                        <EmptyDataTemplate>
                                                            Empty Result.
                                                        </EmptyDataTemplate>
                                                        
                                                        <HeaderStyle HorizontalAlign="Center" Height="20" />
                                                        <RowStyle HorizontalAlign="Center" CssClass="ItemStyle"></RowStyle>
                                                        <FooterStyle CssClass="ItemStyle" />
                                                        <EmptyDataRowStyle CssClass="ItemStyle"></EmptyDataRowStyle>
                                                        <RowStyle CssClass="GridItemStyle" />
                                                        <AlternatingRowStyle CssClass="GridAlternatingStyle" />
                                                        <HeaderStyle CssClass="GridHeaderStyle" />
                                                        <SelectedRowStyle CssClass="GridSelectedStyle" />
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:ImageButton runat="server" ID="imgAddNew" ImageUrl="~/Css-Template/listimage/images/add.png" alt="" CausesValidation="false"
                                                                        Style="cursor: hand;" ImageAlign="Middle"   ToolTip="add"
                                                                        />
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:ImageButton runat="server" ID="IbDelete" ImageUrl="~/Css-Template/listimage/images/delete.png" CausesValidation="false"
                                                                        ImageAlign="Middle" CommandName="Delete" OnClientClick="return confirm('Êtes-vous sûr de vouloir supprimer cet Enseignant?');"
                                                                        CommandArgument='<%# Eval("NOM_ENS")%>' ToolTip="Delete this row"  />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-Width="20px" ControlStyle-Width="20px" FooterStyle-Width="20px">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton runat="server" ID="imgEdit" ImageUrl="~/Css-Template/listimage/images/edit.png" 
                                                                        Style="cursor: hand;" ImageAlign="Middle"  Enabled="true"  Text="Edit"   CommandName="Edit"  ToolTip="Edit"/>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                             <asp:TemplateField HeaderStyle-Width="20px" ControlStyle-Width="20px" FooterStyle-Width="20px">
                                                             
                                                            <EditItemTemplate>   
                                <asp:ImageButton ID="btnUpdate" runat="server" Text="Update"  CausesValidation="false"  CommandName="Update" ImageUrl="~/Css-Template/listimage/images/save.png" ToolTip="Update"
                                 OnClientClick = "return confirm('�tes-vous s�r de vouloir modifier cet abonn�?')"></asp:ImageButton>
                                  <asp:ImageButton runat="server" ID="BtnCancelUpdateCrewSalaryPayment" ImageAlign="Middle"
                                                                    CausesValidation="false" ImageUrl="~/Css-Template/listimage/images/redo.png" />
                                                            
</EditItemTemplate>    
</asp:TemplateField>
 <asp:TemplateField HeaderText="Civ">
                <ItemTemplate>
                    <asp:Label ID="labeta" runat="server" Text='<%# Eval("ETAT_CIVIL_ENS") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList runat="server" ID="ddletat" DataTextField="ETAT_CIVIL_ENS" DataValueField="ETAT_CIVIL_ENS">
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>
             
     <asp:TemplateField HeaderText="Nom Enseignant">
                <ItemTemplate>
                    <asp:Label ID="lblnom" runat="server" Text='<%# Eval("NOM_ENS") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
               <%-- <asp:TextBox ID="txtSurnameNames" runat="server"></asp:TextBox>--%>
                    <asp:DropDownList runat="server" ID="ddlnomenseig" DataTextField="ID_ENS" DataValueField="NOM_ENS">
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>         

<asp:TemplateField HeaderText="Classe">
                <ItemTemplate>
                    <asp:Label ID="lablcodecl" runat="server" Text='<%# Eval("CODE_CL") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList runat="server" ID="ddlcodclasse" DataTextField="CODE_CL" DataValueField="CODE_CL">
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="Matières enseignables">
                <ItemTemplate>
                    <asp:Label ID="lablcodemodule" runat="server" Text='<%# Eval("DESIGNATION") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList runat="server" ID="ddlcodemodule" DataTextField="CODE_MODULE" DataValueField="DESIGNATION">
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>
<asp:TemplateField HeaderText="Salle">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("SALLE") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList runat="server" ID="ddlsalle" DataTextField="SALLE" DataValueField="ID">
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>
                                                        </Columns>
                                                        <HeaderStyle CssClass="GridHeaderStyle" />
                                                        <RowStyle CssClass="GridItemStyle" />
                                                        <SelectedRowStyle CssClass="GridSelectedStyle" />
                                                    </asp:GridView>
                                                    
                                                </td>
                                            </tr>
                                             <tr ><td class="style6" style="background-color: #666666">
       
       <asp:ImageButton ID="btnOK" runat="server" ImageUrl="~/Css-Template/listimage/images/Previous-icon.png" 
               ToolTip="Log In" TabIndex="3" Height="20px"  
               Width="30px"   /></td></tr> 
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
