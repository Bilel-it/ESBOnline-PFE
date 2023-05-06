<%@ Page Title="" Language="C#" MasterPageFile="~/Parents/Par.Master" AutoEventWireup="true" CodeBehind="absencepar.aspx.cs" Inherits="ESPOnline.Parents.absencepar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Contents/Css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />
    <script src="../Contents/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="../Contents/Scripts/bootstrap.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<br />
<h3 class="text-center text-info"><strong>Absence</strong></h3>
<br /><br />
 
   <center>
    <asp:Label ID="Label6" runat="server" CssClass="h4 text-success"></asp:Label>
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4"
        DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" Width="80%">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="DATE_SEANCE" HeaderText="Date Seance" SortExpression="DATE_SEANCE"
                DataFormatString="{0:d MMMM yyyy}" />
            <asp:BoundField DataField="NUM_SEANCE" HeaderText="N° Seance" SortExpression="NUM_SEANCE" />
            <asp:BoundField DataField="CODE_MODULE" HeaderText="Module" SortExpression="CODE_MODULE" />
         <asp:BoundField DataField="Justification" HeaderText="Observation" SortExpression="Justification" />
            
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT DATE_SEANCE, NUM_SEANCE,(case  when Justification='O' then 'Absence justifiée' else 'Absence injustifiée' end) Justification, (select DESIGNATION from ESP_MODULE where code_module=t1.CODE_MODULE)AS CODE_MODULE FROM ESP_ABSENCE_NEW t1, societe t2  WHERE (t1.ID_ET = :argidetud) AND t1.ANNEE_DEB=t2.annee_deb ORDER BY DATE_SEANCE DESC">
        <SelectParameters>
            <asp:ControlParameter ControlID="HiddenField1" Name="argidetud" />
        </SelectParameters>
    </asp:SqlDataSource>
    </center>
</asp:Content>
