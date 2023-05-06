<%@ Page Title="" Language="C#" MasterPageFile="~/EnseignantsCUP/Cup.Master" AutoEventWireup="true" CodeBehind="EncadrementProf.aspx.cs" Inherits="ESPOnline.EnseignantsCUP.EncadrementProf" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="../Contents/jquery.js" type="text/javascript"></script>

    <link href="../Contents/Css/datetimepicker.css" rel="stylesheet" type="text/css" />

    <link href="../Contents/animate.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <script src="../Contents/bootstrap.js" type="text/javascript"></script>
    <script src="../Contents/bootstrap.min.js" type="text/javascript"></script>

    
    <script src="../Contents/Scripts/bootstrap-datetimepicker.min.js" type="text/javascript"></script>
    <script src="../Contents/Scripts/bootstrap-datetimepicker.js" type="text/javascript"></script>
    <script src="../Contents/jquery.js" type="text/javascript"></script>

    <link href="../Contents/Css/datetimepicker.css" rel="stylesheet" type="text/css" />

    <link href="../Contents/animate.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <script src="../Contents/bootstrap.js" type="text/javascript"></script>
    <script src="../Contents/bootstrap.min.js" type="text/javascript"></script>

    
    <script src="../Contents/Scripts/bootstrap-datetimepicker.min.js" type="text/javascript"></script>
    <script src="../Contents/Scripts/bootstrap-datetimepicker.js" type="text/javascript"></script>

<style type="text/css">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    .style1
    {
        color: #999999;
        text-align: center;
        font-size: large;
    }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>


<div class="row">
<div class="col-xs-2">
                
            
</div>
            <div class="col-xs-8">
            <br />
           
            <div class="row">
                    <%--Classe--%>
                    <div class="form-group">
                        <asp:Label ID="Label2" runat="server" Text="Encadrement: " CssClass="text-style1 h4"></asp:Label>
                                </div>
                            <div class="form-group pull-right">
                             <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
                                    CssClass="radio-inline" 
                                    onselectedindexchanged="RadioButtonList1_SelectedIndexChanged">
                                 <asp:ListItem Value="0" Selected="True">Individuel</asp:ListItem>
                                 <asp:ListItem Value="1">Groupe</asp:ListItem>
                                </asp:RadioButtonList>
                                
                            </div>
                         </div>
                     </div>
                     <div class="col-xs-2">
                
                </div>
                 </div>

          














<div class="row">
<div class="col-xs-2">
                
            
</div>
            <div class="col-xs-8">
            <br />
           
            <div class="row">
                    <%--Classe--%>
                    <div class="form-group">
                        <div class="form-inline">
                            
                            <div class="form-group">
                                <asp:Label ID="Label1" runat="server" Text="Liste des Enseignants : " CssClass="text-style1 h4"></asp:Label>
                                </div>
                            <div class="form-group pull-right">
                                
                             <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" 
                                    AutoPostBack="True" 
                                    onselectedindexchanged="DropDownList11_SelectedIndexChanged">
                                    </asp:DropDownList> 
                                <asp:ListSearchExtender ID="DropDownList1_ListSearchExtender" runat="server" 
                                    Enabled="True" TargetControlID="DropDownList1">
                                </asp:ListSearchExtender>
                            </div>
                            
                            
                         </div>
                        
                     

                </div>
        </div>
        </div>
                
                <div class="col-xs-2">
                
                </div>
</div>


<%--//encadrement individuel\\--%>
<asp:Panel ID="Panel1" runat="server" Visible="false">
                    <center>
                    <div class="row">
<div class="col-xs-1">
                
            
</div>
            <div class="col-xs-10">
             <asp:Panel ID="Panel31" runat="server" CssClass="pre-scrollable">
                     <center>
                     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                            DataSourceID="ObjectDataSource1" BackColor="White" 
                         BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3"
                         Caption='<table class="h4 text-success"><tr><td><center>Encadrement Individuel</center></td></tr></table>'>
                         <Columns>
                             <asp:BoundField DataField="NOM_PROJET" HeaderText="NOM_PROJET" 
                                 SortExpression="NOM_PROJET" />
                             <asp:BoundField DataField="ANNEE_DEB" HeaderText="ANNEE_DEB" 
                                 SortExpression="ANNEE_DEB" />
                             <asp:BoundField DataField="TYPE_PROJET" HeaderText="TYPE_PROJET" 
                                 SortExpression="TYPE_PROJET" />
                             <asp:BoundField DataField="ID_ET" HeaderText="ID_ET" SortExpression="ID_ET" />
                             <asp:BoundField DataField="CODE_CL" HeaderText="CODE_CL" 
                                 SortExpression="CODE_CL" />
                             <asp:BoundField DataField="DATE_ENC" HeaderText="DATE_ENC" 
                                 SortExpression="DATE_ENC" />
                             <asp:BoundField DataField="AV_TECH" HeaderText="AV_TECH" 
                                 SortExpression="AV_TECH" />
                             <asp:BoundField DataField="AV_ANG" HeaderText="AV_ANG" 
                                 SortExpression="AV_ANG" />
                             <asp:BoundField DataField="AV_FR" HeaderText="AV_FR" SortExpression="AV_FR" />
                             <asp:BoundField DataField="AV_RAPPORT" HeaderText="AV_RAPPORT" 
                                 SortExpression="AV_RAPPORT" />
                             <asp:BoundField DataField="AV_CC" HeaderText="AV_CC" SortExpression="AV_CC" />
                             <asp:BoundField DataField="COMPORTEMENT" HeaderText="COMPORTEMENT" 
                                 SortExpression="COMPORTEMENT" />
                             <asp:BoundField DataField="REMARQUE_OBS" HeaderText="REMARQUE_OBS" 
                                 SortExpression="REMARQUE_OBS" />
                             <asp:BoundField DataField="TRAVAUX_DEMANDE" HeaderText="TRAVAUX_DEMANDE" 
                                 SortExpression="TRAVAUX_DEMANDE" />
                         </Columns>
                         <FooterStyle BackColor="White" ForeColor="#000066" />
                         <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                         <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                         <RowStyle ForeColor="#000066" />
                         <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                         <SortedAscendingCellStyle BackColor="#F1F1F1" />
                         <SortedAscendingHeaderStyle BackColor="#007DBB" />
                         <SortedDescendingCellStyle BackColor="#CAC9C9" />
                         <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:GridView>
                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                            SelectMethod="GetProjetPROF" TypeName="ESPSuiviEncadrement.ESP_ENCADDREMENT">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="DropDownList1" Name="ID_ENS" 
                                    PropertyName="SelectedValue" Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        </center>
            </asp:Panel>
                        
                        </div></div>
                    </center>  
</asp:Panel>
<%--//fin encadrement individuel\\--%>

<%--///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////--%>

<%--//encadrement groupe\\--%>
<asp:Panel ID="Panel2" runat="server" Visible="false">
<div class="row">
            <div class="col-xs-1">
           
            </div>
            <div class="col-xs-10">
            <asp:Panel ID="Panel12" runat="server" CssClass="pre-scrollable">
            <center>
                     <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                            DataSourceID="ObjectDataSource2" BackColor="White" 
                         BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3"
                         Caption='<table class="h4 text-success"><tr><td><center>Encadrement des Groupes</center></td></tr></table>'>

                       


                         <Columns>
                             <asp:BoundField DataField="NOM_GROUPE" HeaderText="Nom du Groupe" 
                                 SortExpression="NOM_GROUPE" />
                                 <asp:BoundField DataField="NOTE_GROUPE" HeaderText="Note" 
                                 SortExpression="NOTE_GROUPE" />
                             <asp:BoundField DataField="CODE_CL" HeaderText="Classe" 
                                 SortExpression="CODE_CL" />
                                 <asp:BoundField DataField="TYPE_PROJET" HeaderText="Type" 
                                 SortExpression="TYPE_PROJET" />
                             <asp:BoundField DataField="DATE_ENC" HeaderText="Date encadrement" 
                                 SortExpression="DATE_ENC" />
                             <asp:BoundField DataField="AV_TECH" HeaderText="AV technique" 
                                 SortExpression="AV_TECH" />
                             <asp:BoundField DataField="AV_ANG" HeaderText="AV anglais" 
                                 SortExpression="AV_ANG" />
                             <asp:BoundField DataField="AV_FR" HeaderText="AV français" SortExpression="AV_FR" />
                             <asp:BoundField DataField="AV_RAPPORT" HeaderText="AV rapport" 
                                 SortExpression="AV_RAPPORT" />
                             <asp:BoundField DataField="AV_CC" HeaderText="AV compte rendu" SortExpression="AV_CC" />
                             <asp:BoundField DataField="COMPORTEMENT" HeaderText="Comportement" 
                                 SortExpression="COMPORTEMENT" />
                             <asp:BoundField DataField="REMARQUE_OBS" HeaderText="Remarque" 
                                 SortExpression="REMARQUE_OBS" />
                             <asp:BoundField DataField="TRAVAUX_DEMANDE" HeaderText="Traveaux demander" 
                                 SortExpression="TRAVAUX_DEMANDE" />
                             
                             
                               
                         </Columns>
                         <FooterStyle BackColor="White" ForeColor="#000066" />
                         <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                         <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                         <RowStyle ForeColor="#000066" />
                         <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                         <SortedAscendingCellStyle BackColor="#F1F1F1" />
                         <SortedAscendingHeaderStyle BackColor="#007DBB" />
                         <SortedDescendingCellStyle BackColor="#CAC9C9" />
                         <SortedDescendingHeaderStyle BackColor="#00547E" />
                         
                        </asp:GridView>
                        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
                            SelectMethod="profProjetEval" TypeName="ESPSuiviEncadrement.ESP_ENCADREMENT_GP">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="DropDownList1" Name="id_ens" 
                                    PropertyName="SelectedValue" Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        </center>
            </asp:Panel>
            </div>
            <div class="col-xs-1">
            </div>           
            
</div>
<div class="row">
            <div class="col-xs-2">
            </div>
            <div class="col-xs-8">
            <hr /><hr "/>
            </div>
            <div class="col-xs-2">
            </div>
</div>
<div class="row">
            <div class="col-xs-2">
            </div>
            <div class="col-xs-8">
            <asp:Panel ID="Panel13" runat="server" CssClass="pre-scrollable navbar-fixed">
            <center>
                     <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
                            DataSourceID="ObjectDataSource3" BackColor="White" 
                         BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3"
                         
                         Caption='<table class="h4 text-success"><tr><td><center>Encadrement des Etudiants</center></td></tr></table>'>

                       


                         <Columns>
                             <asp:BoundField DataField="ID_ET" HeaderText="ID_ET" SortExpression="Etudiant" />
                             <asp:BoundField DataField="NOTE_ET" HeaderText="Note" 
                                 SortExpression="NOTE_ET" />
                             
                             <asp:BoundField DataField="REMARQUE" HeaderText="Remarque" 
                                 SortExpression="REMARQUE" />
                             <asp:BoundField DataField="ABS_ET" HeaderText="Absence" 
                                 SortExpression="ABS_ET" />
                             <asp:BoundField DataField="DATE_EVAL" HeaderText="Date Evaluation" 
                                 SortExpression="DATE_EVAL" />
                         </Columns>
                         <FooterStyle BackColor="White" ForeColor="#000066" />
                         <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                         <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                         <RowStyle ForeColor="#000066" />
                         <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                         <SortedAscendingCellStyle BackColor="#F1F1F1" />
                         <SortedAscendingHeaderStyle BackColor="#007DBB" />
                         <SortedDescendingCellStyle BackColor="#CAC9C9" />
                         <SortedDescendingHeaderStyle BackColor="#00547E" />
                         
                         <SortedAscendingCellStyle BackColor="#F1F1F1" />
                         <SortedAscendingHeaderStyle BackColor="#007DBB" />
                         <SortedDescendingCellStyle BackColor="#CAC9C9" />
                         <SortedDescendingHeaderStyle BackColor="#00547E" />
                         
                        </asp:GridView>
                        

                        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" 
                         SelectMethod="GetResultatSuiviEnseignantParGroupe" 
                         TypeName="ESPSuiviEncadrement.recherche">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="DropDownList1" Name="id_ens" 
                                    PropertyName="SelectedValue" Type="String" />
                            </SelectParameters>
                     </asp:ObjectDataSource>
                        
                        </center>
            </asp:Panel>
            </div>
            <div class="col-xs-2">
            </div>           
</div>           
                    
                    </asp:Panel>
<%--//fin encadrement groupe\\--%>

















</asp:Content>
