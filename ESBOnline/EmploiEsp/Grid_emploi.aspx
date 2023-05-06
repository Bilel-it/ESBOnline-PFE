<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Grid_emploi.aspx.cs" Inherits="ESPOnline.EmploiEsp.Grid_emploi" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language='JavaScript' type='text/JavaScript'>

        function OpenPopWindow() {
            var url = "Generation_Emp_temps.aspx";

            window.open(url, "popUp", "width=350, height=400, top=0, left=0, menubar=no, resizable=no, " +
                        "scrollbars=yes, status=no", '');
        }
    </script>
    <link rel="stylesheet" type="text/css" href="../Stylesmaha/style.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <h1 align="center" class="style1" >Indisponibilite des enseignants</h1>
    <table width="100%" height="100%">
                                        <tbody>
                                            <tr>
                                                <td valign="top">
                                                   
                                                    <asp:GridView runat="server" ID="Gridbord" AutoGenerateColumns="False" 
                                                        AllowPaging="True" OnPageIndexChanging="gridView_PageIndexChanging"
                                                        PageSize="10" Style="border-bottom: white 2px ridge; border-left: white 2px ridge;
                                                        background-color: white; width: 100%; border-top: white 2px ridge; border-right: white 2px ridge;"
                                                        BorderWidth="0px" BorderColor="Red" CellSpacing="1" CellPadding="3" CssClass="grid"
                                                        RowStyle-CssClass="ItemStyle" HeaderStyle-CssClass="FixedHeaderStyle" Width="100%"
                                                        GridLines="Both" EmptyDataRowStyle-CssClass="ItemStyle"  DataKeyNames="CODE_EMPLOI" BackColor="#0099CC"
                                                     onrowcancelingedit="GrdEmpData_RowCancelingEdit" 
                                                     
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
                                                                        CommandArgument='<%# Eval("CODE_EMPLOI")%>' ToolTip="Delete this row"  />
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
  <asp:TemplateField HeaderText="Code Emploi" ItemStyle-HorizontalAlign  ="center"  ItemStyle-Width ="10%">
                        <ItemTemplate>
                            <asp:Label ID="lbid" runat="server" Text='<% # Eval("CODE_EMPLOI") %>'></asp:Label>
                        </ItemTemplate>
                     </asp:TemplateField>     
           
           <asp:TemplateField HeaderText="Annee deb">
                <ItemTemplate>
                    <asp:Label ID="lblannedeb" runat="server" Text='<%# Eval("ANNEE_DEB") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                     <asp:TextBox ID="txtnumbs" runat="server" Text='<%# Eval("ANNEE_DEB")%>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>           

<asp:TemplateField HeaderText="Classe">
                <ItemTemplate>
                    <asp:Label ID="lblclasse" runat="server" Text='<%# Eval("CODE_CL") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                     <asp:TextBox ID="txtnumbs" runat="server" Text='<%# Eval("CODE_CL")%>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Designation">
                <ItemTemplate>
                    <asp:Label ID="lbldesign" runat="server" Text='<%# Eval("DESIGNATION") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                     <asp:TextBox ID="txtnumbs" runat="server" Text='<%# Eval("DESIGNATION")%>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>

             <asp:TemplateField HeaderText="Nom Ens">
                <ItemTemplate>
                    <asp:Label ID="lblnomEns" runat="server" Text='<%# Eval("NOM_ENS") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                     <asp:TextBox ID="txtnumbs" runat="server" Text='<%# Eval("NOM_ENS")%>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>

             <asp:TemplateField HeaderText=" Code classe">
                <ItemTemplate>
                    <asp:Label ID="lblcodeCl" runat="server" Text='<%# Eval("CODE_CL") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                     <asp:TextBox ID="txtnumbs" runat="server" Text='<%# Eval("CODE_CL")%>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Salle Principale">
                <ItemTemplate>
                    <asp:Label ID="lblsallePrinc" runat="server" Text='<%# Eval("SALLE_PRINCIPALE") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                     <asp:TextBox ID="txtnumbs" runat="server" Text='<%# Eval("SALLE_PRINCIPALE")%>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>

             <asp:TemplateField HeaderText="Jours">
                <ItemTemplate>
                    <asp:Label ID="lbljours" runat="server" Text='<%# Eval("JOURS") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                     <asp:TextBox ID="txtnumbs" runat="server" Text='<%# Eval("JOURS")%>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>

             <asp:TemplateField HeaderText="Num Seance1">
                <ItemTemplate>
                    <asp:Label ID="lblnumseance1" runat="server" Text='<%# Eval("CREN_1") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                     <asp:TextBox ID="txtnumbs" runat="server" Text='<%# Eval("CREN_1")%>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>

             <asp:TemplateField HeaderText="Num Seance2">
                <ItemTemplate>
                    <asp:Label ID="lblnumseance2" runat="server" Text='<%# Eval("CREN_2") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                     <asp:TextBox ID="txtnumbs" runat="server" Text='<%# Eval("CREN_2")%>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>



                                                   </Columns>
                                                        <HeaderStyle CssClass="GridHeaderStyle" />
                                                        <RowStyle CssClass="GridItemStyle" />
                                                        <SelectedRowStyle CssClass="GridSelectedStyle" />
                                                    </asp:GridView>
                                                   
                                                </td>
                                            </tr>
                                             <tr ><td class="style6">
       
       <asp:ImageButton ID="btnOK" runat="server" ImageUrl="~/Css-Template/listimage/images/redo.png" 
               ToolTip="Log In" TabIndex="3" Height="20px"  
               Width="30px"   /></td></tr> 
                                        </tbody>
                                    </table>
    </div>
    </form>
</body>
</html>
