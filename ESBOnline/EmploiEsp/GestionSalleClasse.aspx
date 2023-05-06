<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/EmploiEsp/SiteEDT.Master"  CodeBehind="GestionSalleClasse.aspx.cs" Inherits="ESPOnline.EmploiEsp.GestionSalleClasse" %>



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
        <link href="../Css-Template/Drop-menu/css-drop-Menu/css/dzyngiri.css" rel="stylesheet" type="text/css"/>
    <link href="../Css-Template/Drop-menu/css-drop-Menu/css/font/font.css" rel="stylesheet" type="text/css"/>
   <%-- <link rel="stylesheet" href="../Css-Template/css-template2/css/style.css" type="text/css" media="screen">--%>
   <%-- <link rel="stylesheet" type="text/css" href="../Css-Template/css/MonStyle.css" />--%>
     <link rel="stylesheet" type="text/css" href="../Css-Template/css/style.css" />

 
    <style type="text/css">
        .style5
        {
            text-align: center;
            color: #5C0000;
            font-size: large;
        }
    </style>
      <style type="text/css">
        .style1
        {
            color: #CCCCCC;
            font-weight: bold;
            text-align: center;
        }
    </style>
  

       </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField runat="server" ID="hdnIDEntity" Value="" />
    <table cellpadding="0" cellspacing="0" width="100%">
        <tbody>
            <tr>
                <td valign="top">
                    <table width="100%" border="1" cellspacing="0" cellpadding="2">
                        <tbody>
                            <tr>
                                <td colspan="2" class="style5" height="20px">
                                    Affectation des salles de classe</td>
                            </tr>
                            <tr>
                                <td>
                                    <table width="100%" height="100%">
                                        <tbody>
                                            <tr>
                                                <td valign="top">
                                                   
                                                    <asp:GridView runat="server" ID="Gridsalle" AutoGenerateColumns="False" 
                                                        AllowPaging="True" OnPageIndexChanging="gridView_PageIndexChanging"
                                                        PageSize="10" Style="border-bottom: white 2px ridge; border-left: white 2px ridge;
                                                        background-color: white; width: 100%; border-top: white 2px ridge; border-right: white 2px ridge;"
                                                        BorderWidth="0px" BorderColor="Red" CellSpacing="1" CellPadding="3" CssClass="grid"
                                                        RowStyle-CssClass="ItemStyle" HeaderStyle-CssClass="FixedHeaderStyle" Width="100%"
                                                        GridLines="Both" EmptyDataRowStyle-CssClass="ItemStyle"  DataKeyNames="ID" BackColor="#0099CC"
                                                     onrowcancelingedit="GrdEmpData_RowCancelingEdit" 
                                                     OnRowDeleting="GrdSalle_RowDeleting" 
                                                     onrowupdating ="GrdEmpData_RowUpdating"
                                                      onrowediting="GrdEmpData_RowEditing" 
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
                                                                        ImageAlign="Middle" CommandName="Delete" 
                                                                        CommandArgument='<%# Eval("ID")%>' ToolTip="Delete this row"  />
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
                                 OnClientClick = "return confirm('Ëtes-vous sûr de vouloir modifier cette ligne?')"></asp:ImageButton>
                                  <asp:ImageButton runat="server" ID="BtnCancelUpdateCrewSalaryPayment" ImageAlign="Middle"
                                      CausesValidation="false" ImageUrl="~/Css-Template/listimage/images/redo.png" />
                                                            
</EditItemTemplate>    
</asp:TemplateField>
<asp:TemplateField HeaderText="ID" ItemStyle-HorizontalAlign  ="Left"  ItemStyle-Width ="10%" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblIDsalle" runat="server" Text='<% # Eval("ID") %>' Visible="false"></asp:Label>
                        </ItemTemplate>
                     </asp:TemplateField>     

<asp:TemplateField HeaderText="Classe">
                <ItemTemplate>
                    <asp:Label ID="lablcodecl" runat="server" Text='<%# Eval("CODE_CL") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList runat="server" ID="ddlcodecl" DataTextField="CODE_CL" DataValueField="CODE_CL">
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>



<asp:TemplateField HeaderText="Salle">
                <ItemTemplate>
                    <asp:Label ID="Labelsalle" runat="server" Text='<%# Eval("SALLE") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList runat="server" ID="ddlsalle" DataTextField="SALLE" DataValueField="SALLE">
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>
                                                        </Columns>
                                                        <HeaderStyle CssClass="GridHeaderStyle" />
                                                        <RowStyle CssClass="GridItemStyle" />
                                                        <SelectedRowStyle CssClass="GridSelectedStyle" />
                                                    </asp:GridView>
                                                    <%-- </div>--%>
                                                </td>
                                            </tr>
                                             <tr ><td class="style6">
       
       <asp:ImageButton ID="btnOK" runat="server" ImageUrl="~/Css-Template/listimage/images/previous.png" 
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
  