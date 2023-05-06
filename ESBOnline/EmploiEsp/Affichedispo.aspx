<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Affichedispo.aspx.cs" Inherits="ESPOnline.EmploiEsp.Affichedispo" MasterPageFile="~/Direction/Site2.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="content1" runat="server" ContentPlaceHolderID="head">
     <link rel="stylesheet" type="text/css" href="../Css-Template/css/style.css" />

 
    <style type="text/css">
        .style5
        {
            text-align: center;
            color: #800000;
            font-size: large;
        }
        .style6
        {
            color: #FFFFFF;
        }
        .style7
        {
            color: #000000;
        }
        </style>
        </asp:Content>
<asp:Content ID="content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

<div>
   
    <asp:HiddenField runat="server" ID="hdnIDEntity" Value="" />
    <table cellpadding="0" cellspacing="0" width="100%">
        <tbody>
            <tr>
                <td valign="top">
                    <table width="100%" border="1" cellspacing="0" cellpadding="2">
                        
                        <tr><td><span class="style7"><strong style="color: #000000">Veuillez choisir un enseignant pour connaitre son 
                            indisponibilité:</strong></span>
                           
                        <telerik:RadComboBox ID="ddlnomenseig" runat="server"  EnableLoadOnDemand="True"  
              
                                                            
     EmptyMessage="Veuillez taper le nom de l'enseignant"  Filter="Contains" 
                                                            
        Width="279px" Height="120px" 
        
         AutoPostBack="true" onselectedindexchanged="ddlnomenseig_SelectedIndexChanged">
        </telerik:RadComboBox>
      
                  <%--<asp:DropDownList runat="server" ID="ddlnomenseig" 
         
         onselectedindexchanged="ddlnomenseig_SelectedIndexChanged" AutoPostBack="true"  AppendDataBoundItems="True">
          <asp:ListItem>--choisir un enseignant-- </asp:ListItem>
                    </asp:DropDownList>--%></td></tr>
                           
            </td></tr>
                            <tr>
                                <td colspan="2" class="style5" height="20px">
                                    <br />
                                    <strong>
                                    <span class="style6">Affich</span> Indisponibilité des enseignants<br />
                                    </strong></td>
                            </tr>
                            <tr>
                                <td>
                                    <table width="100%" height="100%">
                                        <tbody>
                                            <tr>
                                                <td valign="top">


                                                    <asp:GridView runat="server" ID="GridIndispo" AutoGenerateColumns="False" 
                                                        AllowPaging="True" 
                                                        PageSize="10" Style="border-bottom: white 2px ridge; border-left: white 2px ridge;
                                                        background-color: white; width: 100%; border-top: white 2px ridge; border-right: white 2px ridge;"
                                                        BorderWidth="0px" BorderColor="Red" CellSpacing="1" CellPadding="3" CssClass="grid"
                                                        RowStyle-CssClass="ItemStyle" HeaderStyle-CssClass="FixedHeaderStyle" Width="100%"
                                                        GridLines="Both" EmptyDataRowStyle-CssClass="ItemStyle"  DataKeyNames="ID_ENS"
                                                    
                                                     BackColor="#0099CC"
                                                     
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
                                                          <%-- <asp:TemplateField HeaderText="Code">
                                                               <ItemTemplate>
                                                              <asp:Label ID="lblcode" runat="server" Text='<%# Eval("ID_DISPO") %>'></asp:Label>
                                                               </ItemTemplate>
                                                            </asp:TemplateField>--%>
                                                            
                                                             <asp:TemplateField HeaderText="Non Enseignant">
                                                               <ItemTemplate>
                                                              <asp:Label ID="lblcode" runat="server" Text='<%# Eval("NOM_ENS") %>'></asp:Label>
                                                               </ItemTemplate>
                                                            </asp:TemplateField>
                                                            
                                                             <asp:TemplateField HeaderText="Jour">
                                                               <ItemTemplate>
                                                              <asp:Label ID="lblcode" runat="server" Text='<%# Eval("JOURS","{0:dd/MM/yyyy}") %>'></asp:Label>
                                                               </ItemTemplate>
                                                            </asp:TemplateField>
                                                            
                                                             <asp:TemplateField HeaderText="Heure début">
                                                               <ItemTemplate>
                                                              <asp:Label ID="lblcode" runat="server" Text='<%# Eval("SEANCE_Df") %>'></asp:Label>
                                                               </ItemTemplate>
                                                            </asp:TemplateField>
                                                            
                                                             <asp:TemplateField HeaderText="Heure Fin">
                                                               <ItemTemplate>
                                                              <asp:Label ID="lblcode" runat="server" Text='<%# Eval("SEANCE_Fg") %>'></asp:Label>
                                                               </ItemTemplate>
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
                  <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>


  
    </div>
</asp:Content>
    
   