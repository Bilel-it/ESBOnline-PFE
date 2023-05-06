<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnsDispo.aspx.cs" Inherits="ESPOnline.EmploiEsp.EnsDispo" MasterPageFile="~/Direction/Site2.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="DayPilot" Namespace="DayPilot.Web.Ui" TagPrefix="DayPilot" %>

<asp:Content ID="content1" runat="server" ContentPlaceHolderID="head">

<style type="text/css">
    

table.grid tbody tr:hover {background-color:#e5ecf9;}
.GridHeaderStyle{color:#FEF7F7;background-color: #E80707;font-weight: bold;}
.GridItemStyle{background-color:#eeeeee;color: black;}
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

     
         .style1
         {
             font-size: large;
         }
         .style2
         {
             font-family: "Times New Roman", Times, serif;
         }

     
     </style>

</asp:Content>

<asp:Content ID="content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<h1 style="color: #000000"><span class="style13">ANNEE UNIVERSITAIIRE </span><span class="style12">:  <asp:Label ID="lblanneedeb" runat="server" CssClass="style7"></asp:Label>/<asp:Label 
            ID="lblanneefin" runat="server" CssClass="style7"></asp:Label></span></h1>

             <h1>
                <strong style="color: #CC0000">
            <span class="style16">SEMESTRE : </span>
            <span class="style8"> <asp:Label ID="lblsemestre" runat="server" 
                    style="font-size: large"></asp:Label>
                </span></h1>
    <div >
        <table style="background-color: #CC0000" align="center" height="250px" width="450px">
        
        <tr align="center"><td colspan="4"> <asp:Label ID="lbl" runat="server" 
                
                
                style="color: #000000; font-size: large; font-weight: 700; font-family: 'Adobe Caslon Pro';"></asp:Label>
            <br />
            <br />
            <br />
            <br />
            </td></tr>
        
                   <tr>
              <td class="style4">
                    <asp:Label ID="Label4" runat="server" Text="Nom Enseignant" CssClass="style3" height="50px"
                        style="color: #FFFFFF; font-weight: 700;"></asp:Label>

                &nbsp;<span class="style1">(</span><span class="style2">*</span><span 
                        class="style1">)</span></td>
                <td class="style4">
                    <asp:Label ID="Label3" runat="server" Text="Jour" CssClass="style3" height="50px"
                        style="color: #FFFFFF; font-weight: 700;"></asp:Label>
                &nbsp;<span class="style1">(</span><span class="style2">*</span><span 
                        class="style1">)</span></td>
                <td class="style4">
                    <asp:Label ID="Label1" runat="server" Text="Heure Debut" CssClass="style3" height="50px"
                        style="color: #FFFFFF; font-weight: 700;" ForeColor="White"></asp:Label>
                &nbsp;<span class="style1">(</span><span class="style2">*</span><span 
                        class="style1">)</span></td>
                <td class="style4">
                    <asp:Label ID="Label2" runat="server" Text="Heure Fin" CssClass="style3" height="50px"
                        style="color: #FFFFFF; font-weight: 700;" ForeColor="White"></asp:Label>
                &nbsp;<span class="style1">(</span><span class="style2">*</span><span 
                        class="style1">)</span></td>
                
                
            </tr>
            <tr>
            <td>
                    <%--<asp:TextBox ID="Textcdde" runat="server" Height="30px" Width="170px"> </asp:TextBox>--%> 
                    <telerik:RadComboBox ID="ddlnomenseig" runat="server" AutoPostBack="True" EnableLoadOnDemand="True"  
                 
                                                            
     EmptyMessage="Veuillez taper le nom de l'enseignant"
                                                            Filter="Contains" 
        Width="279px" Height="120px">
        </telerik:RadComboBox>
                </td>
               <td>
                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>
                <br class="style1" />
                <asp:TextBox ID="txtdebutDate" runat="server" Height="30px" Width="170px" placeholder="Date de debut"
                    CssClass="style1"></asp:TextBox>
                <asp:PopupControlExtender ID="txtdebutDate_PopupControlExtender1" runat="server"
                    Enabled="true" TargetControlID="txtdebutDate" DynamicServicePath="" PopupControlID="Panel1"
                    Position="Bottom">
                </asp:PopupControlExtender>
                <br class="style1" />
                <asp:Panel ID="Panel1" runat="server" Width="200px" CssClass="style1">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="White"
                                Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" Width="350px"
                                BorderWidth="1px" NextPrevFormat="FullMonth" OnSelectionChanged="Calendar1_SelectionChanged"

                                >
                                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                                <NextPrevStyle VerticalAlign="Bottom" Font-Bold="True" Font-Size="8pt" ForeColor="#333333" />
                                <OtherMonthDayStyle ForeColor="#999999" />
                                <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                                <TitleStyle BackColor="White" Font-Bold="True" BorderColor="Black" BorderWidth="4px"
                                    Font-Size="12pt" ForeColor="#333399" />
                                <TodayDayStyle BackColor="#CCCCCC" />
                            </asp:Calendar>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
                <br />
                <br />
            </td>
                 
                <td>
                     <asp:DropDownList ID="DdlNumSeance1" runat="server" AutoPostBack="true" Height="30px" Width="170px" AppendDataBoundItems="true">
             <asp:ListItem>Choisir une séance</asp:ListItem>
             </asp:DropDownList>
                </td>
                <td>
                     <asp:DropDownList ID="DdlNumSeance2" runat="server" AutoPostBack="true" Height="30px" Width="170px" AppendDataBoundItems="true">
             <asp:ListItem>Choisir une séance</asp:ListItem>
             </asp:DropDownList>
                </td>
                
                
            </tr>
            <tr>
                <td colspan="4" align="center">
                <asp:Button runat="server"  ID="add" Text="valider"  onclick="add_Click" Height="39px" 
                        Width="75px" 
                        style="color: #000000; font-weight: 700; background-color: #CCCCCC"/>
                </td>
            </tr>
        </table>
        <table align="center">
        <tr><td><br /></td></tr>
        <tr><td></td></tr>
        <tr> 
        <td align="center">
        <asp:Button  ID="btngrid" runat="server" 
                Text="Afficher liste enseignants indisponible" Height="45px" 
                onclick="btngrid_Click" 
                style="font-weight: 700; background-color: #CCCCCC"/>
        </td>
        </tr>

        </table>
        <br />
        <br />
        <br />
        <asp:Panel ID="panelgrid" runat="server">
      
     
         <asp:HiddenField runat="server" ID="hdnIDEntity" Value=""  />
    <table cellpadding="0" cellspacing="0" width="100%" align="left">
        <tbody>
            <tr>
                <td valign="top">
                    <table width="100%" border="1" cellspacing="0" cellpadding="2">
                        <tbody>
                       <%-- <tr> <td>--%>
                 <%-- <asp:DropDownList runat="server" ID="DropDownList1" 
         
         onselectedindexchanged="ddlnomenseig_SelectedIndexChanged" AutoPostBack="true"  AppendDataBoundItems="True">
          <asp:ListItem>--Veuillez choisir un module-- </asp:ListItem>
                    </asp:DropDownList>--%>
                           
            <%--</td></tr>--%>
                            <tr>
                                <td colspan="2" class="style5" height="20px">
                                    <br />
                                    <span class="style6"><strong>Affichage indisponibilité des enseignants<br />
                                    </strong></span></td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <table width="100%" height="100%" align="left">
                                        <tbody>
                                            <tr>
                                                <td align="left">
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
                                                              <asp:Label ID="lblcode" Visible="false" runat="server" Text='<%# Eval("ID_DISPO") %>'></asp:Label>
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
                </td>
            </tr>
        </tbody>
    </table>
       
        </asp:Panel>
    </div>

   </asp:Content>
