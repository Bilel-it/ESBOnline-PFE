<%@ Page Title="" Language="C#" MasterPageFile="~/Enseignants/Ens.Master" AutoEventWireup="true" CodeBehind="SuiviAbsEns.aspx.cs" Inherits="ESPOnline.Enseignants.SuiviAbsEns" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <link href="../Contents/Css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />
    <script src="../Contents/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="../Contents/Scripts/bootstrap.js" type="text/javascript"></script>
        <script type="text/javascript" src="../Contents/Scripts/JScript1.js"></script>
<style type="text/css">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
<asp:Panel ID="Panel1" runat="server">
                        
    <h3 class="text-center text-info"><strong>Charge Horaire Des Enseignants</strong></h3>
</asp:Panel>
<br/>
<asp:Panel ID="Panel7" CssClass="tab-pane" runat="server" style="text-align: left">
                                                    
<br/>
        </asp:Panel>
<br/>
<asp:Panel ID="Panel2" CssClass="container-fluid" runat="server" 
                        style="text-align: left;" GroupingText="Charge en tant que Enseignant 1 :">
                        <br />
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                            DataSourceID="SqlDataSource1">
                            <Columns>
                                <asp:BoundField DataField="DATE_SEANCE" HeaderText="DATE_SEANCE" 
                                    DataFormatString="{0:d MMMM yyyy}" SortExpression="DATE_SEANCE" />
                                <asp:BoundField DataField="CODE_CL" HeaderText="CODE_CL" 
                                    SortExpression="CODE_CL" />
                                <asp:BoundField DataField="CODE_MODULE" HeaderText="CODE_MODULE" 
                                    ReadOnly="True" SortExpression="CODE_MODULE" />
                                <asp:BoundField DataField="NUM_SEANCE" HeaderText="NUM_SEANCE" 
                                    SortExpression="NUM_SEANCE" />
                                <asp:BoundField DataField="NBR_ABSENCE" HeaderText="NBR_ABSENCE" 
                                    ReadOnly="True" SortExpression="NBR_ABSENCE" />
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
                            ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" SelectCommand="SELECT  date_seance,CODE_CL, (select DESIGNATION from ESP_MODULE where code_module=ESP_ABSENCE_NEW.code_module) As CODE_MODULE, NUM_SEANCE, COUNT(CODE_CL) AS NBR_ABSENCE FROM ESP_ABSENCE_NEW WHERE ID_ENS='P-415-11' GROUP BY CODE_CL , date_seance,CODE_MODULE,NUM_SEANCE ORDER BY date_seance



"></asp:SqlDataSource>
                        <div class="input-large" style="width:auto; text-align:right;">
                        
                        </div>
                    </asp:Panel>

<asp:Panel ID="Panel8" CssClass="container-fluid" GroupingText="Total " runat="server" >
<div class="modal-body" style="text-align:right" >
    <br /><br />
    <br /><br />
    <asp:Label ID="Label43" runat="server" Text="Total des Absences : " 
        CssClass="style10"></asp:Label>
    <asp:Label ID="Label46" runat="server" Text="" CssClass="style9"></asp:Label>
    </div>
</asp:Panel>
<div class="btn-danger pull-right">
</div>
</div>
</asp:Content>
