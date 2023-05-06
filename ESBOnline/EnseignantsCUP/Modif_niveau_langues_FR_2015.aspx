<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modif_niveau_langues_FR_2015.aspx.cs" 
Inherits="ESPOnline.EnseignantsCUP.Modif_niveau_langues_FR_2015" 

 MasterPageFile="~/EnseignantsCUP/Cup.Master" %>
 <%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<%--script of coloring niv sup--%>


<script language="javascript" type="text/javascript">

function drpSetColors(duty, Color, StyleType, indicesForSplit, SeparatorSplit) 
{
  if (document.getElementById(duty) != null) {
      var indices = indicesForSplit.split(SeparatorSplit);
    if (indices[0] == "")
        return;
    for (j = 0; j < indices.length; j++) {
     if (StyleType.toUpperCase() == "COLOR")
      document.getElementById(duty).options[indices[j]].style.color = Color;
     else if (StyleType.toUpperCase() == "BACKGROUND-COLOR")
     document.getElementById(duty).options[indices[j]].style.backgroundColor = Color;
    }
  }
}
</script>




      <script src="../Contents/jquery.js" type="text/javascript"></script>
               <script src="../Contents/CSS3/js/bootstrap.min.js" type="text/javascript"></script>
        <link href="../Contents/Css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
        <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />
          <link href="../Contents/Css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
        <link href="../Contents/Css/bootstrap.min.css" rel="stylesheet" type="text/css" />

        <style type="text/css">
        .style9
        {
            color: #CC0000;
        }
        .margin-bottom: 1px;
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
	BACKGROUND-COLOR:  #d9534f; 
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

      
             .style1
             {
                 color: #CC0000;
             }

      
             .style2
             {
                 font-family: Arial, Helvetica, sans-serif;
             }

      
          </style>

          <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
  <%--  <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>--%>
<script src="../Contents/Scripts/ScrollableGridPlugin_ASP.NetAJAX_2.0.js" type="text/javascript"></script>
     <script type="text/javascript">
    $(document).ready(function () {
        $('#<%=gvCustomers.ClientID %>').Scrollable({
            ScrollHeight: 300,
        });
    });
    </script>

<%--check all--%>

<%--<script type = "text/javascript">
    function checkAll(objRef) {
        var GridView = objRef.parentNode.parentNode.parentNode;
        var inputList = GridView.getElementsByTagName("input");
        for (var i = 0; i < inputList.length; i++) {
            //Get the Cell To find out ColumnIndex
            var row = inputList[i].parentNode.parentNode;
            if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                if (objRef.checked) {
                    //If the header checkbox is checked
                    //check all checkboxes
                    //and highlight all rows
                    row.style.backgroundColor = "aqua";
                    inputList[i].checked = true;
                }
                else {
                    //If the header checkbox is checked
                    //uncheck all checkboxes
                    //and change rowcolor back to original
                    if (row.rowIndex % 2 == 0) {
                        //Alternating Row Color
                        row.style.backgroundColor = "#C2D69B";
                    }
                    else {
                        row.style.backgroundColor = "white";
                    }
                    inputList[i].checked = false;
                }
            }
        }
    }
</script>

<script type = "text/javascript">
    function Check_Click(objRef) {
        //Get the Row based on checkbox
        var row = objRef.parentNode.parentNode;
        if (objRef.checked) {
            //If checked change color to Aqua
            row.style.backgroundColor = "aqua";
        }
        else {
            //If not checked change back to original color
            if (row.rowIndex % 2 == 0) {
                //Alternating Row Color
                row.style.backgroundColor = "#C2D69B";
            }
            else {
                row.style.backgroundColor = "white";
            }
        }

        //Get the reference of GridView
        var GridView = row.parentNode;

        //Get all input elements in Gridview
        var inputList = GridView.getElementsByTagName("input");

        for (var i = 0; i < inputList.length; i++) {
            //The First element is the Header Checkbox
            var headerCheckBox = inputList[0];

            //Based on all or none checkboxes
            //are checked check/uncheck Header Checkbox
            var checked = true;
            if (inputList[i].type == "checkbox" && inputList[i] != headerCheckBox) {
                if (!inputList[i].checked) {
                    checked = false;
                    break;
                }
            }
        }
        headerCheckBox.checked = checked;

    }
</script>

<script type = "text/javascript">
    function MouseEvents(objRef, evt) {
        var checkbox = objRef.getElementsByTagName("input")[0];
        if (evt.type == "mouseover") {
            objRef.style.backgroundColor = "orange";
        }
        else {
            if (checkbox.checked) {
                objRef.style.backgroundColor = "aqua";
            }
            else if (evt.type == "mouseout") {
                if (objRef.rowIndex % 2 == 0) {
                    //Alternating Row Color
                    objRef.style.backgroundColor = "#C2D69B";
                }
                else {
                    objRef.style.backgroundColor = "white";
                }
            }
        }
    }
</script>--%>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
<br />
<br />


<center>

<h3 class="style1">Saisie niveau de Langue : Français et Anglais</h3>
<table>
<tr>
<td>
<h4> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Veuillez choisir la langue à modifier: &nbsp;</h4>
</td>
<td>&nbsp;
<asp:RadioButtonList ID="rblangue" runat="server"  AutoPostBack="true"
            Width="220px" RepeatDirection="Vertical" 
        onselectedindexchanged="rblangue_SelectedIndexChanged" >
                 <asp:ListItem Value="FR">Français</asp:ListItem>
                 <asp:ListItem Value="AN">Anglais </asp:ListItem>
            </asp:RadioButtonList></td>
</tr>

</table>
<asp:Panel ID="plchoix" runat="server">
<table>
<tr>
<td>
<h4> Veuillez choisir soit par liste des étudiants ou bien par classe: &nbsp;</h4>
</td>
<td>&nbsp;
<asp:RadioButtonList ID="rbchoix" runat="server"  AutoPostBack="true"
            Width="220px" RepeatDirection="Vertical" 
        onselectedindexchanged="RadioButtonList1_SelectedIndexChanged" >
                 <asp:ListItem Value="I">Choix par classe</asp:ListItem>
                 <asp:ListItem Value="C">Choix par Etudiant </asp:ListItem>
            </asp:RadioButtonList></td>

</tr>
</table>
</asp:Panel>
<asp:Label ID="lblid" runat="server" Visible="false" ></asp:Label>

<br />
<br />
<asp:Panel ID="plclasse" runat="server" Visible="false">
<br />
<table>
<tr>
<td>
<asp:Label ID="Label1" runat="server">Choisissez l'année:&nbsp</asp:Label>
<asp:DropDownList ID="ddlannee_debM" runat="server" AppendDataBoundItems="true"  Width="150px"
   Height="30px"   AutoPostBack="true" onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
       >
<asp:ListItem Value="0">Veuillez choisir</asp:ListItem>
<asp:ListItem >2014</asp:ListItem>
<asp:ListItem >2015</asp:ListItem>
</asp:DropDownList>

</td>

<td>&nbsp;&nbsp;&nbsp;&nbsp;</td>

<td>
    liste des clases:
<asp:DropDownList ID="ddclasse2" runat="server"  Width="150px"
   Height="30px"
    AutoPostBack="true" onselectedindexchanged="DropDownList2_SelectedIndexChanged1" 
         >

</asp:DropDownList>

</td>
<td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
</tr>
</table>
</asp:Panel>
<br />
<br />
<table>
<tr>
<td><asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
<ContentTemplate>
<asp:GridView ID="gvCustomers" runat="server" AutoGenerateColumns="false" OnRowDataBound = "OnRowDataBoundS" DataKeyNames = "id_et"
 Style="border-bottom: white 2px ridge; border-left: white 2px ridge; background-color: white; 
     border-top: white 2px ridge; border-right: white 2px ridge;"
  BorderWidth="0px" 
        BorderColor="White" CellSpacing="1" CellPadding="3" CssClass="grid"
        Visible="false"
                                                        
        RowStyle-CssClass="ItemStyle" HeaderStyle-CssClass="FixedHeaderStyle" 
                                                        GridLines="None" 
        EmptyDataRowStyle-CssClass="ItemStyle"  >
    <Columns>
       <%-- <asp:TemplateField>
            <HeaderTemplate>
                <asp:CheckBox ID = "chkAll" runat="server" AutoPostBack="true" OnCheckedChanged="OnCheckedChanged" Visible="true"/>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true" OnCheckedChanged="OnCheckedChanged" />
            </ItemTemplate>
        </asp:TemplateField>--%>
      

<asp:TemplateField ItemStyle-Width="20px">
 <%--<HeaderTemplate >
      <asp:CheckBox ID="checkAll" runat="server" onclick = "checkAll(this);"  AutoPostBack="true"/>
    </HeaderTemplate>--%>
     <HeaderTemplate>
                <asp:CheckBox ID = "chkAll" runat="server" AutoPostBack="true" OnCheckedChanged="OnCheckedChangedDDD"  Visible="false"/>
            </HeaderTemplate>
    
           <ItemTemplate>
           
              <asp:CheckBox ID="CheckBox1"  runat="server" AutoPostBack="true" OnCheckedChanged="OnCheckedChanged" />
           </ItemTemplate>
        </asp:TemplateField>





        <asp:BoundField DataField="ID_ET" HeaderText="ID Etudiant" SortExpression="ID_ET"
            ItemStyle-Width="25px" />
<asp:BoundField DataField="NOM" HeaderText="NOM et PRENOM" SortExpression="NOM" />
        <%-- <asp:TemplateField HeaderText="Identifiant" ItemStyle-HorizontalAlign  ="Left"  ItemStyle-Width ="10%">
                        <ItemTemplate>
                            <asp:Label ID="lblId" runat="server" Text='<% # Eval("ID_ET") %>'></asp:Label>
                        </ItemTemplate>
                     </asp:TemplateField>  
                                                            
<asp:TemplateField HeaderText="Nom et prenom de l'étudiant">
                <ItemTemplate>
                    <asp:Label ID="lblname" runat="server" Text='<%# Eval("NOM") %>'></asp:Label>
                </ItemTemplate>
              
            </asp:TemplateField>--%>

        <asp:TemplateField HeaderText="Niveau Français">
                
                <ItemTemplate>
                <asp:Label ID="lblCountry" runat="server" Text='<%# Eval("niveau_courant_fr") %>'></asp:Label>
               <asp:DropDownList ID="ddlCountries" runat="server" Visible = "false"  
              AutoPostBack="true"  AppendDataBoundItems="true">
               </asp:DropDownList>
            </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Niveau Anglais">

             <ItemTemplate>
                <asp:Label ID = "lblCountry2" runat="server" Text='<%# Eval("niveau_courant_ang") %>'></asp:Label>
                <asp:DropDownList ID="ddlCountries2" runat="server" Visible = "false"  
               AutoPostBack="true" AppendDataBoundItems="true">
                </asp:DropDownList>
            </ItemTemplate>
                <%--<ItemTemplate>
                    <asp:Label ID="labang" runat="server" Text='<%# Eval("niveau_courant_ang") %>'></asp:Label>
                </ItemTemplate>--%>

               <%-- <EditItemTemplate>
                    <asp:DropDownList runat="server" ID="ddlniveau_ang" DataTextField="niveau_courant_ang" DataValueField="niveau_courant_ang "  Visible="false">
                    </asp:DropDownList>
                </EditItemTemplate>--%>
            </asp:TemplateField>
    </Columns>
</asp:GridView>
</ContentTemplate>
</asp:UpdatePanel>
</td>
<td><asp:Label ID="lbl08" runat="server"></asp:Label></td>
<td align="center">

<asp:Button ID="btnUpdate" runat="server" Text="Modifier" OnClick = "Update" 
        Visible="false" Height="44px" />

</td>
</tr>
</table>

<br />


<asp:Panel ID="plindiv" runat="server">
<table>
<tr>
<td>
<asp:Label ID="lbiannee" runat="server">choisir l'année:&nbsp</asp:Label>
<asp:DropDownList ID="ddlannee_deb" runat="server" AppendDataBoundItems="true"  Width="150px"
   Height="30px"   AutoPostBack="true" 
        onselectedindexchanged="ddlannee_deb_SelectedIndexChanged" >
<asp:ListItem Value="0">Veuillez choisir</asp:ListItem>
<asp:ListItem >2014</asp:ListItem>
<asp:ListItem >2015</asp:ListItem>
</asp:DropDownList>

</td>

<td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
<%--<td>
Niveau d'étude:
<asp:DropDownList ID="ddlniv" runat="server" AppendDataBoundItems="true"  Width="150px"
   Height="30px"   AutoPostBack="true" onselectedindexchanged="ddlniv_SelectedIndexChanged" 
         >
<asp:ListItem Value="0">Veuillez choisir</asp:ListItem>

</asp:DropDownList>
</td>
<td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
--%>
<td>
    liste des clases:
<asp:DropDownList ID="ddclasse" runat="server"  Width="150px"
   Height="30px"
    AutoPostBack="true" onselectedindexchanged="ddclasse_SelectedIndexChanged"  >

</asp:DropDownList>

</td>
<td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
<td> </td>
<td>
    Nom de l&#39;étudiant:
<telerik:RadComboBox ID="RadComboBox1" runat="server" AutoPostBack="True" 
                                                            
   Filter="Contains"  EnableLoadOnDemand="True" 
                                                            
     EmptyMessage="Tapez le Nom du l'étudiant" 
        Width="279px" Height="120px" onselectedindexchanged="RadComboBox1_SelectedIndexChanged" 
       >
        </telerik:RadComboBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="RadComboBox1"
                ErrorMessage="Valeur Requise!"  ValidationGroup="requ2"></asp:RequiredFieldValidator>

</td>
</tr>
</table>
</asp:Panel>
<br />
<br /> 

<%--<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
<ContentTemplate>--%>
<%--<h2> L'ancien niveau de cet etudiant est:<asp:Label ID="lbl_enc_niv" runat="server"></asp:Label></h2>--%>
<br />
<asp:GridView runat="server" ID="Gridstudent" AutoGenerateColumns="False" AllowPaging="True" Visible="false"
  Style="border-bottom: white 2px ridge; border-left: white 2px ridge; background-color: white; 
     border-top: white 2px ridge; border-right: white 2px ridge;"
  BorderWidth="0px" 
        BorderColor="White" CellSpacing="1" CellPadding="3" CssClass="grid"
        
                                                        
        RowStyle-CssClass="ItemStyle" HeaderStyle-CssClass="FixedHeaderStyle" 
                                                        GridLines="None" 
        EmptyDataRowStyle-CssClass="ItemStyle"  
        DataKeyNames="id_et" 
        onrowediting="GrdEmpData_RowEditing"  OnRowCancelingEdit="GridView1_RowCancelingEdit"
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
                                <asp:ImageButton ID="btnUpdate" runat="server" Text="Update"  CausesValidation="false"  CommandName="Update" 
                                ImageUrl="~/EnseignantsCUP/Styles/save.png" 
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


            <asp:TemplateField HeaderText="Niveau Français">
                <ItemTemplate>
                    <asp:Label ID="lablNature" runat="server" Text='<%# Eval("niveau_courant_fr") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList runat="server" ID="ddlniveau_fr" DataTextField="niveau_courant_fr" DataValueField="niveau_courant_fr" 
                  AutoPostBack="true" AppendDataBoundItems="true">
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Niveau Anglais">
                <ItemTemplate>
                    <asp:Label ID="labang" runat="server" Text='<%# Eval("niveau_courant_ang") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList runat="server" ID="ddlniveau_ang" DataTextField="niveau_courant_ang" DataValueField="niveau_courant_ang"
                   AutoPostBack="true" AppendDataBoundItems="true">
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>



                                                        </Columns>
                                                        <HeaderStyle CssClass="GridHeaderStyle" />
                                                        <RowStyle CssClass="GridItemStyle" />
                                                        <SelectedRowStyle CssClass="GridSelectedStyle" />
                                                    </asp:GridView>

<%--</ContentTemplate>
</asp:UpdatePanel>--%>
<asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
</center>
<br />
<br />
</asp:Content>
