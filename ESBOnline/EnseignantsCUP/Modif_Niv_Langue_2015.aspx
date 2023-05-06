<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modif_Niv_Langue_2015.aspx.cs" Inherits="ESPOnline.EnseignantsCUP.Modif_Niv_Langue_2015"

MasterPageFile="~/EnseignantsCUP/Cup.Master" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

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
    <style type="text/css">
        .style9
        {
            color: #CC0000;
        }
        </style>



         <style type="text/css">
      
      table.grid tbody tr:hover {background-color:#e5ecf9;}
.GridHeaderStyle{color:#FEF7F7;background-color: #877d7d;font-weight: bold;}
.GridItemStyle{background-color:#eeeeee;color: Black;}
.GridAlternatingStyle{background-color:#dddddd;color: black;}
.GridSelectedStyle{background-color:#d6e6f6;color: black;}


.GridStyle
{
	border-bottom: white 2px ridge; 
	border-left: white 2px ridge; 
	background-color: white; 
	width: 100%; 
	border-top: white 2px ridge; 
	border-right: white 2px ridge; 
}
.ItemStyle {
	BACKGROUND-COLOR: #eeeeee; 
	COLOR: black;
	padding-bottom: 5px;
	padding-right: 3px;
	padding-top: 5px;
	padding-left: 3px;
	height: 25px
}

.ItemStyle td{
	BACKGROUND-COLOR: #eeeeee; 
	COLOR: black;
	padding-bottom: 5px;
	padding-right: 3px;
	padding-top: 5px;
	padding-left: 3px;
	height: 25px
}
.FixedHeaderStyle {
	BACKGROUND-COLOR:  #7591b1; 
	COLOR: #FFFFFF; 
	FONT-WEIGHT: bold;
	position:relative ;   
	top:expression(this.offsetParent.scrollTop);  
	z-index: 10;  
}
.Caption_1_Customer
{
	background-color:#beccda;
	color: #000000;
	width: 30%;
	height: 20px;
}

      
          </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<br />
<br />
<br />
<center>
<h3 class="style9"> Modification niveau de langues : Français</h3>
<br />
<table>
<tr>
<td><asp:TextBox ID="txtidet" runat="server" Visible="false"></asp:TextBox></td>

</tr>
<tr>
<td>
Niveau d'étude:
<asp:DropDownList ID="ddlniv" runat="server" AppendDataBoundItems="true"  Width="150px"
   Height="30px"   AutoPostBack="true" 
        onselectedindexchanged="ddlniv_SelectedIndexChanged" >
<asp:ListItem Value="0">Veuillez choisir</asp:ListItem>

</asp:DropDownList>
</td>
<td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
<td>
    liste des clases:
<asp:DropDownList ID="ddclasse" runat="server"  Width="150px"
   Height="30px"
    AutoPostBack="true" onselectedindexchanged="ddclasse_SelectedIndexChanged"  >

</asp:DropDownList>

</td>
<td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
<td><asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>
    Nom de l&#39;étudiant:
<telerik:RadComboBox ID="ddlnomENS" runat="server" AutoPostBack="True" 
                                                            
   Filter="Contains"  EnableLoadOnDemand="True" 
                                                            
     EmptyMessage="Tapez le Nom du l'étudiant" 
        Width="279px" Height="120px" onselectedindexchanged="ddlnomENS_SelectedIndexChanged" 
       >
        </telerik:RadComboBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlnomENS"
                ErrorMessage="Value Required!" ></asp:RequiredFieldValidator>
      
</td>
</tr>
</table>
<br />
<br />
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
<ContentTemplate>

<asp:GridView runat="server" ID="Gridstudent" AutoGenerateColumns="False" AllowPaging="True" 
  Style="border-bottom: white 2px ridge; border-left: white 2px ridge; background-color: white; width: 100%; border-top: white 2px ridge; border-right: white 2px ridge;"
  BorderWidth="0px" 
        BorderColor="White" CellSpacing="1" CellPadding="3" CssClass="grid"
        
                                                        
        RowStyle-CssClass="ItemStyle" HeaderStyle-CssClass="FixedHeaderStyle" Width="100%"
                                                        GridLines="None" 
        EmptyDataRowStyle-CssClass="ItemStyle"  DataKeyNames="id_et" 
                                                        onrowediting="GrdEmpData_RowEditing"
                                                     OnRowCancelingEdit="GridView1_RowCancelingEdit"
                                                      
        onrowupdating ="GrdEmpData_RowUpdating"  
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
                                                            
                                                            <asp:TemplateField HeaderStyle-Width="20px" ControlStyle-Width="20px" FooterStyle-Width="20px" HeaderText="Modifier">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton runat="server" ID="imgEdit" ImageUrl="~/EnseignantsCUP/Styles/edit.png" 
                                                                        Style="cursor: hand;" ImageAlign="Middle"  Enabled="true"  Text="Edit"   CommandName="Edit"  ToolTip="Edit"/>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                          <asp:TemplateField HeaderStyle-Width="20px" ControlStyle-Width="20px" FooterStyle-Width="20px">
                                                             
                                                            <EditItemTemplate>   
                                <asp:ImageButton ID="btnUpdate" runat="server" Text="Update"  CausesValidation="false"  CommandName="Update" ImageUrl="~/EnseignantsCUP/Styles/save.png" 
                                 ToolTip="Update"
                                 OnClientClick = "return confirm('Ëtes-vous sûr de vouloir modifier cet étudiant?')"></asp:ImageButton>

                                  <asp:ImageButton runat="server"  Text="Cancel" CommandName="Cancel" ToolTip="Cancel" 
                          ID="BtnCancelUpdateCrewSalaryPayment" ImageAlign="Middle"  width="200px" Height="20px"
                          CausesValidation="false" ImageUrl="~/EnseignantsCUP/Styles/redo2.png"  />
                                                            
                                                           </EditItemTemplate>    
                                                       </asp:TemplateField>

            <asp:TemplateField HeaderText="Identifiant" ItemStyle-HorizontalAlign  ="Left"  ItemStyle-Width ="10%">
                        <ItemTemplate>
                            <asp:Label ID="lblId" runat="server" Text='<% # Eval("ID_ET") %>'></asp:Label>
                        </ItemTemplate>
                     </asp:TemplateField>  
                                                            
<asp:TemplateField HeaderText="Nom et prenom de l'étudiant">
                <ItemTemplate>
                    <asp:Label ID="lblname" runat="server" Text='<%# Eval("NOM") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="lblnames2" runat="server" Text='<%# Eval("NOM") %>'></asp:Label>
                </EditItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="Niveau acquis français">
                <ItemTemplate>
                    <asp:Label ID="lablNature" runat="server" Text='<%# Eval("NIV_ACQUIS_FRANCAIS") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList runat="server" ID="ddlniveau_etud" DataTextField="NIV_ACQUIS_FRANCAIS" DataValueField="NIV_ACQUIS_FRANCAIS">
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>

<asp:TemplateField   HeaderText = "Niveau acquis anglais">
    <ItemTemplate>
        <asp:Label ID="lblPreNom" runat="server"
                Text='<%# Eval("NIV_ACQUIS_ANGLAIS")%>'></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:Label ID="lblPreNom2" runat="server"
                Text='<%# Eval("NIV_ACQUIS_ANGLAIS")%>'></asp:Label>
    </EditItemTemplate> 
    <FooterTemplate>
        <asp:TextBox ID="txtSurnameNames" runat="server"></asp:TextBox>
   </FooterTemplate>
</asp:TemplateField>


                                                        </Columns>
                                                        <HeaderStyle CssClass="GridHeaderStyle" />
                                                        <RowStyle CssClass="GridItemStyle" />
                                                        <SelectedRowStyle CssClass="GridSelectedStyle" />
                                                    </asp:GridView>

</ContentTemplate>
</asp:UpdatePanel>

</center>

</asp:Content>
