<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Generation_Emp_temps.aspx.cs" Inherits="ESPOnline.EmploiEsp.Generation_Emp_temps" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="DayPilot" Namespace="DayPilot.Web.Ui" TagPrefix="DayPilot" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            color: #FFFFFF;
        }
        .style4
        {
            color: #FFFFFF;
        }
        .style5
        {
            color: #333333;
        }
        .style6
        {
            font-family: "Times New Roman", Times, serif;
            font-size: large;
        }
        .style7
        {
            font-weight: bold;
            font-size: large;
        }
    </style>

    <link rel="stylesheet" type="text/css" href="../Stylesmaha/style.css" />
</head>
<body bgcolor="#CCCCCC">



    <form id="form1" runat="server">
    <center>
 
    <h1 class="style5">Enregistrer un emploi du temps</h1>
    <br /><hr />
        
    <h1 class="style5">Annee Universitaire :  <asp:Label ID="lblanneedeb" runat="server" CssClass="style7"></asp:Label>/<asp:Label 
            ID="lblanneefin" runat="server" CssClass="style7"></asp:Label></h1>
            <span class="style6"><strong>Semestre : <asp:Label ID="lblsemestre" runat="server"></asp:Label>
        </strong></span>
   
<%--</center>--%>
    <div>
   <%-- <center style="background-color: #333333">--%>
    <table style="background-color: #800000" width="200px" >

      <%--<tr>
            <td class="style4">
                <asp:Label ID="Label4" Text="Code:" runat="server" CssClass="style3"> </asp:Label>
                * 
            </td>
            <td>
               <asp:TextBox runat="server" ID="txtcode" >
                    </asp:TextBox>
            </td>
        </tr>--%>

        <tr>
        <td class="style5">
       <asp:Label ID="lblClasse" Text="Classe" runat="server" CssClass="style3" 
                width="100px" style="color: #CCCCCC"></asp:Label>
                 <span class="style4">*</span></td>
                 <td>
                  <asp:DropDownList runat="server" ID="ddlcodclasse" 
                          AutoPostBack="true"
                        AppendDataBoundItems="True" 
                         onselectedindexchanged="ddlcodclasse_SelectedIndexChanged">
                      <asp:ListItem>--Veuillez choisir la classe-- </asp:ListItem>
                    </asp:DropDownList>
                 </td>
                 </tr>
                 <tr>
            <td class="style4">
                <asp:Label ID="lblEns" runat="server" Text="Enseignant" 
                    CssClass="style3" style="color: #CCCCCC"></asp:Label>
                &nbsp;(*)</td>
            <td>
                <asp:DropDownList runat="server" ID="ddlnomenseig" Height="30px" Width="170px"
                    AutoPostBack="true" onselectedindexchanged="ddlnomenseig_SelectedIndexChanged"
                    >
                    </asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td class="style4">
                <asp:Label ID="lblMatiere" Text="Matiere:" runat="server" CssClass="style3" 
                    style="color: #FFFFFF"> </asp:Label>
                <span class="style1">* 
            </span> 
            </td>
            <td>
               <asp:DropDownList runat="server" ID="ddlmodule" Height="30px" Width="170px"
                   AutoPostBack="true" onselectedindexchanged="ddlmodule_SelectedIndexChanged"
                    >
                    </asp:DropDownList>
            </td>
        </tr>

         <tr>
            <td class="style4">
                <asp:Label ID="lblSalle" runat="server" Text="Salle" 
                    CssClass="style3" style="color: #FFFFFF"></asp:Label>
                     <span class="style1">*</span></td>
            <td>
                <asp:DropDownList ID="ddlSalle" runat="server" Height="30px" Width="170px" 
                   AutoPostBack="True">
                </asp:DropDownList>
            </td>
        </tr>



         <tr>
            <td class="style4">
                <asp:Label ID="Label3" runat="server" Text="Jours" 
                    CssClass="style3" style="color: #FFFFFF"></asp:Label>
                <span class="style1">*</span></td>
            <%--<td>--%>
                <%--<asp:DropDownList runat="server" ID="ddljours" 
                    AutoPostBack="true"
                    >
                    <asp:ListItem>Veuillez choisir le jours de la séance</asp:ListItem>
                    <asp:ListItem>Lundi</asp:ListItem>
                     <asp:ListItem>Mardi</asp:ListItem>
                      <asp:ListItem>Mercredi</asp:ListItem>
                       <asp:ListItem>Jeudi</asp:ListItem>
                        <asp:ListItem>vendredi</asp:ListItem>
                         <asp:ListItem>Samedi</asp:ListItem>
                    </asp:DropDownList>--%>
           <%-- </td>--%>

           <td>
           
                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>
                <br class="style1" />
                <asp:TextBox ID="txtdebutDate" runat="server" Height="25px" Width="165px" placeholder="jour "
              ></asp:TextBox>

                <asp:PopupControlExtender ID="txtdebutDate_PopupControlExtender1" runat="server"
                    Enabled="true" TargetControlID="txtdebutDate" DynamicServicePath="" PopupControlID="Panel1"
                    Position="Bottom">
                </asp:PopupControlExtender>
                <br class="style1" />
                <asp:Panel ID="Panel1" runat="server" Width="200px" CssClass="style1">
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="White"
                                Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" Width="350px"
                                BorderWidth="1px" NextPrevFormat="FullMonth" 
                                onselectionchanged="Calendar1_SelectionChanged1" >
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
        </tr>

        <tr>
            <td class="style4">
                <asp:Label ID="Label4" runat="server" Text="NB Heure" 
                    CssClass="style3" style="color: #FFFFFF"></asp:Label>
                <span class="style1">*</span></td>
            <td>
              <asp:TextBox  ID="txtbnheures"  runat="server" Height="30px" Width="170px"></asp:TextBox> 
                   
            </td>
        </tr>





        <%--<tr>
            <td class="style5">
                <asp:Label ID="lbldatesoin" Text="Jours" runat="server" CssClass="style2" 
                    ></asp:Label>
                     &nbsp;<span
                    class="style6">(<span class="style9">*</span>)</span>
            </td>
            <td class="style10">
                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>
                <br class="style1" />
                <asp:TextBox ID="txtdatesoin" runat="server" Height="30px" Width="170px" placeholder="Date de soin"
                    ></asp:TextBox>

                <asp:PopupControlExtender ID="txtdebutDate_PopupControlExtender1" runat="server"
                    Enabled="true" TargetControlID="txtdatesoin" DynamicServicePath="" PopupControlID="Panel1"
                    Position="Bottom">
                </asp:PopupControlExtender>
                <br class="style1" />
                <asp:Panel ID="Panel1" runat="server" Width="200px" CssClass="style1">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="White"
                                Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" Width="350px"
                                BorderWidth="1px" NextPrevFormat="FullMonth" OnSelectionChanged="Calendar1_SelectionChanged">
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
        </tr>--%>

         <tr>
            <td class="style1">
                <strong class="text-primary">De:</strong></td>
            <td class="style9">
                <asp:DropDownList ID="DdlNumSeance1" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="DdlNumSeance1_SelectedIndexChanged" Height="30px" Width="170px"
                    CssClass="form-control">
                    <asp:ListItem Value="0">Choisir une séance</asp:ListItem>
                    <asp:ListItem Value="9">1: 9h:00 à 10h:30</asp:ListItem>
                    <asp:ListItem Value="12">2: 10h:45 à 12h:15</asp:ListItem>
                    <asp:ListItem Value="14">3: 14h:00 à 15h:30</asp:ListItem>
                    <asp:ListItem Value="17">4: 15h:45 à 17h:15</asp:ListItem>
                </asp:DropDownList>
            </td>
             <td class="style10" colspan="2">
               <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
            </td>
            <td>
            <td class="style13">
                &nbsp;</td>
            <td class="style11">
                &nbsp;&nbsp;
                &nbsp;</td>
            <td>
                &nbsp;</td>

        </tr>

        <tr>
            <td class="style1">
                <strong class="text-primary">À:</strong></td>
            <td class="style9">
                <asp:DropDownList ID="DdlNumSeance2" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="DdlNumSeance2_SelectedIndexChanged" Height="30px" Width="170px"
                    CssClass="form-control">
                    <asp:ListItem Value="0">Choisir une séance</asp:ListItem>
                    <asp:ListItem Value="9">1: 9h:00 à 10h:30</asp:ListItem>
                    <asp:ListItem Value="12">2: 10h:45 à 12h:15</asp:ListItem>
                    <asp:ListItem Value="14">3: 14h:00 à 15h:30</asp:ListItem>
                    <asp:ListItem Value="17">4: 15h:45 à 17h:15</asp:ListItem>
                </asp:DropDownList>
            </td>
             <td class="style10" colspan="2">
               <asp:Label ID="Label2" runat="server" Text="Label" Visible="false"></asp:Label>
            </td>
            <td>
            <td class="style13">
                &nbsp;</td>
            <td class="style11">
                &nbsp;&nbsp;
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>

    </table>
    <%--</center>--%>
    <br /><br />
  <%--<center>--%>
        <asp:Button  runat="server"  ID="btnaddEMP" Text="Enregistrer" BackColor="Maroon" 
                ForeColor="#CCCCCC" Height="40px" Width="150px" 
            onclick="btnaddEMP_Click" style="font-weight: 700; color: #FFFFFF"/>
  <%--</center>--%>
    </div>
    <div> <br /></div>
    <div >
    <h2> indisponibilité enseignant</h2>
    <asp:Label ID="lblnomens" runat="server"  Visible="false"></asp:Label>
    <asp:GridView runat="server" ID="Gridbord" AutoGenerateColumns="False" 
                                                        AllowPaging="True" OnPageIndexChanging="gridView_PageIndexChanging"
                                                        PageSize="10" Style="border-bottom: white 2px ridge; border-left: white 2px ridge;
                                                        background-color: white; width: 100%; border-top: white 2px ridge; border-right: white 2px ridge;"
                                                        BorderWidth="0px" BorderColor="Red" CellSpacing="1" CellPadding="3" CssClass="grid"
                                                        RowStyle-CssClass="ItemStyle" HeaderStyle-CssClass="FixedHeaderStyle" Width="100%"
                                                        GridLines="Both" EmptyDataRowStyle-CssClass="ItemStyle"  DataKeyNames="CODE_EMPLOI" BackColor="#0099CC"

                                                       >
                                                        <EmptyDataTemplate>
                                                            Enseignant non affecté.
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
    </div>
    </center>
    </form>
</body>
</html>
