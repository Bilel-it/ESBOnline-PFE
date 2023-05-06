<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Justification_absences.aspx.cs" 
Inherits="ESPOnline.Enseignants.Justification_absences" 
EnableEventValidation="false"
MasterPageFile="~/Administration/Administration.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
        table.grid tbody tr:hover
        {
            background-color: #39ccd8;
        }
        .GridHeaderStyle
        {
            color: #FEF7F7;
            background-color: #877d7d;
            font-weight: bold;
        }
        .GridItemStyle
        {
            background-color: #eeeeee;
            color: Black;
        }
        .GridAlternatingStyle
        {
            background-color: #dddddd;
            color: black;
        }
        .GridSelectedStyle
        {
            background-color: #d6e6f6;
            color: black;
        }
        
        
        .GridStyle
        {
            border-bottom: white 2px ridge;
            border-left: white 2px ridge;
            background-color: white;
            width: 100%;
            border-top: white 2px ridge;
            border-right: white 2px ridge;
        }
        .ItemStyle
        {
            background-color: #eeeeee;
            color: black;
            padding-bottom: 5px;
            padding-right: 3px;
            padding-top: 5px;
            padding-left: 3px;
            height: 25px;
        }
        
        .ItemStyle td
        {
            background-color: #eeeeee;
            color: black;
            padding-bottom: 5px;
            padding-right: 3px;
            padding-top: 5px;
            padding-left: 3px;
            height: 25px;
        }
        .FixedHeaderStyle
        {
            background-color: #7591b1;
            color: #FFFFFF;
            font-weight: bold;
            position: relative;
            top: expression(this.offsetParent.scrollTop);
            z-index: 10;
        }
        .Caption_1_Customer
        {
            background-color: #beccda;
            color: #000000;
            width: 30%;
            height: 20px;
        }
        #hurfDurf table .Gridstudent
        {
            margin-right: 80px;
        }
    </style>
     <script src="../Contents/jquery.js" type="text/javascript"></script>
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
    <script type="text/javascript">
        function openModal() {
            $('#myModal').modal('show');
        }
    </script>
    <style type="text/css">
        .style1
        {
            font-family: "Times New Roman" , Times, serif;
            color: #CC0000;
        }
        .style3
        {
            font-family: "Times New Roman" , Times, serif;
        }
        .style4
        {
            font-family: "Times New Roman" , Times, serif;
            width: 88px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<br />
<br />
<br />

<br />
<br />
<br />
<br />
<br />

<center>
        <%--<h3 class="style1">
            Séance d&#39;encadrement:Ajouter et modifier séance</h3>--%>
    </center>
    <center>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager2" runat="server">
        </asp:ToolkitScriptManager>
        <asp:Panel ID="Panel2" runat="server" Width="70%">
            <center>
                <asp:Panel ID="plseance" runat="server" Width="100%" Height="400px" CssClass="panel-default">
                    <div class="panel panel-default" width="70%">
                        <div class="panel-body" width="70%">
                            <center>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always" ChildrenAsTriggers="true">
                                    <ContentTemplate>
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <h3 class="style1">
                                                    JUSTIFICATION DES ABSENCES</h3>
                                            </div>
                                            <table class="table table-responsive  table-striped table-hover">
                                                <tr>
                                                    <td class="style4"><strong>
                                                        Etudiant</strong><span class="style3"><strong>:</strong></span>
                                                    </td>
                                                    <td class="style3">
                                                        <telerik:RadComboBox ID="RadComboBox1" runat="server" AutoPostBack="True" CausesValidation="false"
                                                             DataTextField="NOM" DataValueField="ID_ET"
                                                            EmptyMessage="Tappez l'identifiant de l'étudiant" EnableLoadOnDemand="True" Filter="Contains"
                                                            Height="120px" OnSelectedIndexChanged="RadComboBox1_SelectedIndexChanged" Width="290px">
                                                        </telerik:RadComboBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="choisir un projet valide"
                                                            ControlToValidate="RadComboBox1" Display="Dynamic" ValidationGroup="typeprojet"
                                                            ForeColor="#CC0000"></asp:RequiredFieldValidator>
                                                            &nbsp;
                                                            <asp:TextBox ID="txtstudentt" runat="server" AutoPostBack="True" CausesValidation="false"
                                                             EmptyMessage="Nom de l'étudiant"
                                                            EnableLoadOnDemand="True" Filter="Contains"  OnSelectedIndexChanged="ddlprojet_SelectedIndexChanged"
                                                            Width="250px">
                                                        </asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="choisir un etudiant valide"
                                                            ControlToValidate="txtstudentt" Display="Dynamic" ValidationGroup="typeprojet"
                                                            ForeColor="#CC0000"></asp:RequiredFieldValidator>
                                                            &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                                                                                                 <asp:Button runat="server" ID="Button1" 
                                                            
    Text="Enregistrer" Width="100px" onclick="Button1_Click"/>
                                                    </td>
                                                    
                                                   
                                                    
                                                </tr>

                                                <tr>
                                                
                                                <td class="style4"><strong>
                                                        Module</strong><span class="style3"><strong>:</strong></span>
                                                    </td>
                                                    <td class="style3">
                                                        <telerik:RadComboBox ID="RadComboBox2" runat="server" AutoPostBack="True" CausesValidation="false"
                                                           
                                                            EmptyMessage="Tappez le code de module" EnableLoadOnDemand="True" Filter="Contains"
                                                            Height="120px"  Width="290px" 
                                                            onselectedindexchanged="RadComboBox2_SelectedIndexChanged">
                                                        </telerik:RadComboBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="choisir un projet valide"
                                                            ControlToValidate="RadComboBox2" Display="Dynamic" ValidationGroup="typeprojet"
                                                            ForeColor="#CC0000"></asp:RequiredFieldValidator>&nbsp;

                                                            <asp:TextBox ID="txtboBox3" runat="server" 
                                                            EmptyMessage="Libellé du module" ReadOnly="true"
                                                              Width="350px">
                                                        </asp:TextBox>

                                                          &nbsp;
                                                             <asp:Button runat="server" ID="Button2" 
                                                            
    Text=" Annuler " Width="100px" onclick="Button2_Click"/>
                                                    </td>
                                                    
                                                  
                                                   
                                                
                                                </tr>


                                                <tr>
                                                    <td class="style4">
                                                        <span class="style3"><strong>Date séance:</strong></span>
                                                    </td>
                                                    <td class="style3">
                                                        <asp:TextBox ID="TBdateseance" runat="server" AutoPostBack="true" 
                                                             Width="150px">
                                                        </asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator102" runat="server" ErrorMessage="*"
                                                            ForeColor="#CC0000" ControlToValidate="TBdateseance" Display="Dynamic" ValidationGroup="typeprojet"></asp:RequiredFieldValidator>
                                                        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                     <asp:Button runat="server" ID="btnx"  Text="Liste des absences non justifiées par étudiant" 
                                                     onclick="btnx_Click" BackColor="#b8cbf4" BorderColor="#1f60ee" />
                                                        &nbsp;<asp:Button runat="server" ID="Button3"  Text="Liste des absences non justifiées par module" 
                                                     BackColor="#cec4c4" BorderColor="#1f60ee" Visible="false" 
                                                            onclick="Button3_Click"/>
                                                    </td>
                                                    <td>
                                                    </td>
                                                   <%-- <td class="style3">
                                                        <span class="style3"><strong>H. deb d&#39;encadrement:</strong></span>
                                                    </td>--%>
                                                   <%-- <td class="style3">
                                                        <span class="style3">
                                                            <asp:TextBox ID="Picker1" runat="server" TextMode="Time"></asp:TextBox>
                                                        </span>
                                                    </td>--%>
                                                   
                                                </tr>
                                                <tr>
                                                    <td class="style4">
                                                        <span class="style3"><strong>Classe:</strong></span>
                                                    </td>
                                                    <td class="style3">
                                                        <asp:TextBox ID="TextBox11" runat="server" AutoPostBack="true" 
                                                            Width="150px">
                       
                                                        </asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                                                            ForeColor="#CC0000" ControlToValidate="TBdateseance" Display="Dynamic" ValidationGroup="typeprojet"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td class="style3">
                                                        
                                                    </td>
                                                    <td class="style3">
                                                        
                                                    </td>
                                                    <td class="style3">
                                                       
                                                    </td>
                                                </tr>


                                                <caption>
                                                   
                                                   

                                                    <tr>
                                                    
                                                    
                                                <td class="style4"><strong>
                                                     Justification</strong><span class="style3"><strong>:</strong></span>
                                                    </td>
                                                    <td class="style3">
                                                        <telerik:RadComboBox ID="RadComboBox4" runat="server" AutoPostBack="True" CausesValidation="false"
                                                            DataTextField="LIB" DataValueField="LIB"
                                                            EmptyMessage="Code de justification" EnableLoadOnDemand="True" Filter="Contains"
                                                            Height="120px"  Width="290px" onselectedindexchanged="RadComboBox4_SelectedIndexChanged2"  
                                                            >
                                                        </telerik:RadComboBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="choisir un projet valide"
                                                            ControlToValidate="RadComboBox4" Display="Dynamic" ValidationGroup="typeprojet"
                                                            ForeColor="#CC0000"></asp:RequiredFieldValidator>
                                                            &nbsp;
                                                            <asp:TextBox ID="txtComboBox5" runat="server" AutoPostBack="True" CausesValidation="false"
                                                            EmptyMessage="Justification"
                                                            EnableLoadOnDemand="True" Filter="Contains"  
                                                            Width="290px">
                                                        </asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="choisir un etudiant valide"
                                                            ControlToValidate="RadComboBox4" Display="Dynamic" ValidationGroup="typeprojet"
                                                            ForeColor="#CC0000"></asp:RequiredFieldValidator>
                                                    </td>
                                                    
                                                   
                                                    <td class="style3">
                                                        &nbsp;
                                                    </td>
                                                    
                                                    </tr>
                                                    
                                                </caption>
                                            </table>
                                            <br />
                                            <table>
                                            <tr>
                                                    
                                                    <td>
                                                    <asp:GridView runat="server" ID="GridView1" Visible="false"
                                                     AutoGenerateColumns="False" Style="border-bottom: white 2px ridge;
            border-left: white 2px ridge; background-color: white; border-top: white 2px ridge;
            border-right: white 2px ridge;" BorderWidth="0px" BorderColor="Red" CellSpacing="1"
            CellPadding="3" CssClass="grid" RowStyle-CssClass="ItemStyle" HeaderStyle-CssClass="FixedHeaderStyle"
            GridLines="Both" EmptyDataRowStyle-CssClass="ItemStyle" BackColor="#0099CC" DataKeyNames="ID_ET"
            OnSelectedIndexChanged="OnSelectedIndexChanged"
            OnRowDataBound="OnRowDataBound"
            >
            <EmptyDataTemplate>
                Il n'ya pas d'absence!
            </EmptyDataTemplate>
            <HeaderStyle HorizontalAlign="Center" Height="20px" Width="100px" BackColor="#788083" />
            <RowStyle HorizontalAlign="Center" CssClass="ItemStyle"></RowStyle>
            <FooterStyle CssClass="ItemStyle" />
            <EmptyDataRowStyle CssClass="ItemStyle"></EmptyDataRowStyle>
            <RowStyle CssClass="GridItemStyle" />
            <AlternatingRowStyle CssClass="GridAlternatingStyle" />
            <HeaderStyle CssClass="GridHeaderStyle" />
            <SelectedRowStyle CssClass="GridSelectedStyle" />
            <Columns>
            <asp:BoundField DataField="CODE_MODULE" HeaderText="Code module" ReadOnly="True" SortExpression="CODE_MODULE"  />
                
                <asp:BoundField DataField="DESIGNATION" HeaderText="Module" ReadOnly="True" SortExpression="DESIGNATION"
                    ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="250px" />
                <asp:BoundField DataField="NOM_ENS" HeaderText="Enseignant" ReadOnly="True" SortExpression="NOM_ENS"
                    ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="150px" />
                <asp:BoundField DataField="NUM_SEANCE" HeaderText="Seance" ReadOnly="True" SortExpression="NUM_SEANCE" />
                <asp:BoundField DataField="DATE_SEANCE" HeaderText="Date séance " ReadOnly="True"
                    SortExpression="DATE_SEANCE" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="150px" dataformatstring="{0:d/MM/yy}" />
                  
                 <asp:BoundField DataField="DATE_SAISIE" HeaderText="Date saisie " ReadOnly="True"
                    SortExpression="DATE_SAISIE" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="150px" dataformatstring="{0:d/MM/yy}" />
                
                 <asp:BoundField DataField="CODE_CL" HeaderText="Classe" ReadOnly="True" SortExpression="CODE_CL"  />
                 <asp:BoundField DataField="ID_ET" HeaderText="Identifiant" ReadOnly="True" SortExpression="ID_ET"  />
                
               
            </Columns>
            <HeaderStyle CssClass="GridHeaderStyle" />
            <RowStyle ForeColor="#000000" />
            <SelectedRowStyle CssClass="GridSelectedStyle" />
        </asp:GridView>
                                                    </td>
                                                    
                                                    </tr>
                                            </table>
                                        </div>
                                        
                                        
                                       
                                        
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </center>
                        </div>
                    </div>
                </asp:Panel>
            </center>
        </asp:Panel>
    </center>

</asp:Content>