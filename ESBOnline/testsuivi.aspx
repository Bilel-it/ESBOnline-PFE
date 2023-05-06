<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testsuivi.aspx.cs" Inherits="ESPOnline.testsuivi" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
            DataSourceID="SqlDataSource1" DataTextField="ID_PROJET" 
            DataValueField="ID_PROJET">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" 
            SelectCommand="SELECT &quot;ID_PROJET&quot; FROM &quot;ESP_ENCADREMENT_GROUPE&quot;">
        </asp:SqlDataSource>
        <br />
        <br />
        <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" 
            DataSourceID="SqlDataSource2" DataTextField="TYPE_PROJET" 
            DataValueField="TYPE_PROJET">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" 
            SelectCommand="SELECT &quot;TYPE_PROJET&quot; FROM &quot;ESP_ENCADREMENT_GROUPE&quot;">
        </asp:SqlDataSource>
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" DataSourceID="ObjectDataSource1" 
            AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="ID_PROJET" HeaderText="ID_PROJET" 
                    SortExpression="ID_PROJET" />
                <asp:BoundField DataField="ANNEE_DEB" HeaderText="ANNEE_DEB" 
                    SortExpression="ANNEE_DEB" />
                <asp:BoundField DataField="TYPE_PROJET" HeaderText="TYPE_PROJET" 
                    SortExpression="TYPE_PROJET" />
                <asp:BoundField DataField="ID_ET" HeaderText="ID_ET" SortExpression="ID_ET" />
                <asp:BoundField DataField="ID_GROUPE_PROJET" HeaderText="ID_GROUPE_PROJET" 
                    SortExpression="ID_GROUPE_PROJET" />
                <asp:BoundField DataField="ID_ENS" HeaderText="ID_ENS" 
                    SortExpression="ID_ENS" />
                <asp:BoundField DataField="CODE_CL" HeaderText="CODE_CL" 
                    SortExpression="CODE_CL" />
                <asp:BoundField DataField="NOTE_GROUPE" HeaderText="NOTE_GROUPE" 
                    SortExpression="NOTE_GROUPE" />
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
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="GetProjEtudiant_Groupe" 
            TypeName="ESPSuiviEncadrement.ESP_ENCADREMENT_GROUPE">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="id" 
                    PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="DropDownList2" Name="typep" 
                    PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" />
    
    </div>
    </form>
</body>
</html>
