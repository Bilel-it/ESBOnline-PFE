<%@ Page Title="" Language="C#" MasterPageFile="~/EnseignantsCUP/Cup.Master" AutoEventWireup="true" CodeBehind="Affect.aspx.cs" Inherits="ESPOnline.EnseignantsCUP.Affect" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Contents/Css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />
     <link type="text/css" rel="stylesheet" href="Styles/Site.css" />
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style7
        {
            width: 381px;
        }
        .style8
        {
            width: 642px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container">
    
        <table class="style1">
            <tr>
                <td>
                    &nbsp;</td>
                <td >
                    <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
                    </telerik:RadScriptManager>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <table class="style1">
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <table class="style1">
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            <table class="style1">
                                                <tr>
                                                    <td class="style7">
                                                        &nbsp;</td>
                                                    <td class="style8">
                                                        <asp:Label ID="Labelnomens" runat="server" 
                                                            style="font-size: x-large; font-weight: 700; color: #000000" Text="Label" 
                                                            CssClass="collapse"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:Label ID="Labelup" runat="server" 
                                                            style="font-size: x-large; color: #000000; font-weight: 700" Text="Label" 
                                                            CssClass="collapse"></asp:Label>
                                                    </td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            <table class="style1">
                                                <tr>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        Choisir 
                                                        Module:&nbsp;
                                                           
                                                        <telerik:RadComboBox ID="RadComboBox2" Runat="server" DataSourceID="SqlDataSource2" DataTextField="DESIGNATION" 
                                                            DataValueField="CODE_MODULE" EmptyMessage="Tappez le Nom du Module "  
                                                            Filter="Contains" >
                                                        </telerik:RadComboBox>
                                                        &nbsp;
                                                        <asp:CheckBox ID="CBmodules" runat="server" AutoPostBack="True" 
                                                            Text="Filtrer" oncheckedchanged="CBmodules_CheckedChanged" />
                                                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                                                            ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
                                                            ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" 
                                                            
                                                            SelectCommand="SELECT &quot;CODE_MODULE&quot;, &quot;DESIGNATION&quot; FROM &quot;ESP_MODULE&quot;">
                                                        </asp:SqlDataSource>
                                                    </td>
                                                    <td rowspan="2">
                                                        &nbsp;</td>
                                                    <td>
                                                        Choisir Enseignants:&nbsp; 
                                                        <telerik:RadComboBox ID="RadComboBox1" Runat="server" 
                                                            DataSourceID="SqlDataSource1" DataTextField="NOM_ENS" 
                                                            DataValueField="ID_ENS" EmptyMessage="Tappez le Nom "  Filter="Contains" >
                                                        </telerik:RadComboBox>
                                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                                            ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
                                                            ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" 
                                                            
                                                            
                                                            SelectCommand="SELECT ID_ENS, NOM_ENS FROM ESP_ENSEIGNANT WHERE (ETAT = 'A') order by nom_ens">
                                                        </asp:SqlDataSource>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        Niveau :<asp:RadioButtonList 
                                                            ID="RadioButtonList2" runat="server" 
                                                            RepeatDirection="Horizontal" AutoPostBack="True" 
                                                            onselectedindexchanged="RadioButtonList2_SelectedIndexChanged">
                                                             <asp:ListItem Value="">All </asp:ListItem>
                                                            <asp:ListItem Value="1">1ere année </asp:ListItem>
                                                            <asp:ListItem Value="2">2ème année</asp:ListItem>
                                                            <asp:ListItem Value="3">3ème année</asp:ListItem>
                                                            <asp:ListItem Value="4">4ème année</asp:ListItem>
                                                            <asp:ListItem Value="5">5ème année</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                    <td>
                                                        Type Enseignant:&nbsp; 
                                                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                                                            RepeatDirection="Horizontal">
                                                           
                                                            <asp:ListItem Value="1">1er </asp:ListItem>
                                                            <asp:ListItem Value="2">2ème</asp:ListItem>
                                                            <asp:ListItem Value="3">3ème</asp:ListItem>
                                                            <asp:ListItem Value="4">4ème</asp:ListItem>
                                                            <asp:ListItem Value="5">5ème</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    &nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                                            <asp:Button ID="Button1" CssClass="btn-lg btn-default" runat="server" Font-Bold="True" 
                                                onclick="Button1_Click" Text="Valider" Height="40px" Width="98px" />
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                              <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                                                  GridLines="None"  
    CssClass="mGrid"  
    PagerStyle-CssClass="pgr"  
    AlternatingRowStyle-CssClass="alt" Height="39px" Width="100%" 
                                    onselectedindexchanged="GridView1_SelectedIndexChanged">  
                                                <AlternatingRowStyle CssClass="alt" />



    
            <Columns>
                
             <asp:TemplateField>
                 <HeaderTemplate>
                    
                 </HeaderTemplate>
                 <ItemTemplate>
                  <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="False" />
                 </ItemTemplate>
        </asp:TemplateField>

                <asp:BoundField DataField="CODE_MODULE" HeaderText="CODE_MODULE" 
                    SortExpression="CODE_MODULE" />
                <asp:BoundField DataField="DESIGNATION" HeaderText="DESIGNATION" 
                    ReadOnly="True" SortExpression="DESIGNATION" />
                <asp:BoundField DataField="CODE_CL" HeaderText="CODE_CL" 
                    SortExpression="CODE_CL" />
              
              <asp:BoundField DataField="NB_HEURES" HeaderText="NB HEURES" 
                    SortExpression="NB_HEURES" />
                     <asp:TemplateField HeaderText="ENS1" ItemStyle-Width = "150">
            <ItemTemplate>
                <%--<asp:DropDownList ID="ddlCountries2" runat="server" Visible = "false" 
                    >--%>
                    <%--<telerik:radcombobox ID="ddlCountries2" runat="server" Visible = "False" 
                    DataTextField="NOM_ENS" DataValueField="ID_ENS" EmptyMessage="Tappez le Nom"  
                    Filter="Contains">
                    </telerik:RadComboBox>--%>
                   <%-- <asp:ListItem Text = "--Select City--" Value = ""></asp:ListItem>--%>
               <%-- </asp:DropDownList>--%>
             <%--  <telerik:RadComboBox ID="ddlCountries2" runat="server" Visible = "False" 
                    DataTextField="NOM_ENS" DataValueField="ID_ENS" EmptyMessage="Tappez le Nom"  
                    Filter="Contains">
                </telerik:RadComboBox>--%>
                
                 
                
                <table class="style1">
                    <tr>
                        <td colspan="2">
                         <asp:Label ID="lblCountry2" runat="server" Text='<%# Eval("DD") %>'></asp:Label>
                           
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>&nbsp;P1</strong><asp:TextBox ID="TBEnsP1" runat="server" Text='<%# Eval("CHARGE_ENS1_P1") %>'  
                                Font-Size="Medium" Height="25px" 
                                                                
                                style="text-align: center; font-family: 'Arial Black'" Width="32px"></asp:TextBox>
                        
                        </td>
                        <td>
                            <strong>P2</strong><asp:TextBox ID="TBEnsP2" runat="server" Text='<%# Eval("CHARGE_ENS1_P2") %>' Font-Size="Medium" Height="25px" 
                                                                
                                style="text-align: center; font-family: 'Arial Black'" Width="32px"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" 
                                                                runat="server" Enabled="True" FilterType="Custom, numbers" ValidChars=",."  TargetControlID="TBEnsP2">
                                                            </asp:FilteredTextBoxExtender>
                        </td>
                    </tr>
                </table>
                
            </ItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
        </asp:TemplateField>
               
                    <asp:TemplateField HeaderText="ENS2" ItemStyle-Width = "150">
            <ItemTemplate>
                

                     <table class="style1">
                    <tr>
                        <td colspan="2">
                        <asp:Label ID = "lblCountry" runat="server" Text='<%# Eval("DD2") %>'></asp:Label>
                           
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>P1</strong><asp:TextBox ID="TBEns2P1" runat="server" Text='<%# Eval("CHARGE_ENS2_P1") %>'  
                                Font-Size="Medium" Height="25px" 
                                                                
                                style="text-align: center; font-family: 'Arial Black'" Width="32px"></asp:TextBox>
                        
                        </td>
                        <td>
                            <strong>P2</strong><asp:TextBox ID="TBEns2P2" runat="server" Text='<%# Eval("CHARGE_ENS2_P2") %>' Font-Size="Medium" Height="25px" 
                                                                
                                style="text-align: center; font-family: 'Arial Black'" Width="32px"></asp:TextBox>
                            </td>
                    </tr>
                </table>
                 <%--<telerik:radcombobox ID="ddlCountries" runat="server" Visible = "False" 
                     DataTextField="NOM_ENS" DataValueField="ID_ENS" 
                    EmptyMessage="Tappez le Nom "  Filter="Contains" >
                    </telerik:RadComboBox>--%>
         
               
            </ItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
        </asp:TemplateField>
          <asp:TemplateField HeaderText="ENS3" ItemStyle-Width = "150">
            <ItemTemplate>
                <asp:Label ID = "lblCountry3" runat="server" Text='<%# Eval("dd3") %>'></asp:Label>
                <%--<asp:DropDownList ID="ddlCountries2" runat="server" Visible = "false" 
                    >--%>
                    <%--<telerik:radcombobox ID="ddlCountries2" runat="server" Visible = "False" 
                    DataTextField="NOM_ENS" DataValueField="ID_ENS" EmptyMessage="Tappez le Nom"  
                    Filter="Contains">
                    </telerik:RadComboBox>--%>
                   <%-- <asp:ListItem Text = "--Select City--" Value = ""></asp:ListItem>--%>
               <%-- </asp:DropDownList>--%>
             <%--  <telerik:RadComboBox ID="ddlCountries2" runat="server" Visible = "False" 
                    DataTextField="NOM_ENS" DataValueField="ID_ENS" EmptyMessage="Tappez le Nom"  
                    Filter="Contains">
                </telerik:RadComboBox>--%>
                
            </ItemTemplate>


<ItemStyle Width="150px"></ItemStyle>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="ENS4" ItemStyle-Width = "150">
            <ItemTemplate>
                <asp:Label ID = "lblCountry4" runat="server" Text='<%# Eval("DD4") %>'></asp:Label>
                <%--<asp:DropDownList ID="ddlCountries2" runat="server" Visible = "false" 
                    >--%>
                    <%--<telerik:radcombobox ID="ddlCountries2" runat="server" Visible = "False" 
                    DataTextField="NOM_ENS" DataValueField="ID_ENS" EmptyMessage="Tappez le Nom"  
                    Filter="Contains">
                    </telerik:RadComboBox>--%>
                   <%-- <asp:ListItem Text = "--Select City--" Value = ""></asp:ListItem>--%>
               <%-- </asp:DropDownList>--%>
             <%--  <telerik:RadComboBox ID="ddlCountries2" runat="server" Visible = "False" 
                    DataTextField="NOM_ENS" DataValueField="ID_ENS" EmptyMessage="Tappez le Nom"  
                    Filter="Contains">
                </telerik:RadComboBox>--%>
                
            </ItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
        </asp:TemplateField>
          <asp:TemplateField HeaderText="ENS5" ItemStyle-Width = "150">
            <ItemTemplate>
                <asp:Label ID = "lblCountry5" runat="server" Text='<%# Eval("DD5") %>'></asp:Label>
                <%--<asp:DropDownList ID="ddlCountries2" runat="server" Visible = "false" 
                    >--%>
                    <%--<telerik:radcombobox ID="ddlCountries2" runat="server" Visible = "False" 
                    DataTextField="NOM_ENS" DataValueField="ID_ENS" EmptyMessage="Tappez le Nom"  
                    Filter="Contains">
                    </telerik:RadComboBox>--%>
                   <%-- <asp:ListItem Text = "--Select City--" Value = ""></asp:ListItem>--%>
               <%-- </asp:DropDownList>--%>
             <%--  <telerik:RadComboBox ID="ddlCountries2" runat="server" Visible = "False" 
                    DataTextField="NOM_ENS" DataValueField="ID_ENS" EmptyMessage="Tappez le Nom"  
                    Filter="Contains">
                </telerik:RadComboBox>--%>
                
            </ItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
        </asp:TemplateField>
            </Columns>
            <PagerStyle CssClass="pgr" />
        </asp:GridView>  
                            
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
   

</asp:Content>