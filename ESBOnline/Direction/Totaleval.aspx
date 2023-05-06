<%@ Page Title="" Language="C#" MasterPageFile="~/Direction/administration.Master" AutoEventWireup="true" CodeBehind="Totaleval.aspx.cs" Inherits="ESPOnline.Direction.Totaleval" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .text-info
        {}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<center>
<script type="text/javascript">
    $(document).ready(function () {
        $('#<%=GridView1.ClientID %>').Scrollable({
            ScrollHeight: 300,
         
        });
    });
    </script> 
  <asp:Label ID="Label2" runat="server" style="font-weight: 700; color: #666666">Nombre Total:</asp:Label>  <asp:Label ID="Label1" runat="server" style="font-weight: 700; color: #FF0000"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" BackColor="#CCCCCC" 
        CssClass="text-info" ForeColor="Black" Height="27px" onclick="BuTT2_Click" 
        Text="Exporter en excel" />
<br />
    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" OnRowDataBound="GridView1_test"
        AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="CODE_CL" HeaderText="CLASSE" 
                SortExpression="CODE_CL" />
            <asp:BoundField DataField="CODE_MODULE" HeaderText="CODE_MODULE" 
                SortExpression="CODE_MODULE" />
            <asp:BoundField DataField="DESIGNATION" HeaderText="DESIGNATION" 
                SortExpression="DESIGNATION" />
            <asp:BoundField DataField="COUNT(*)" HeaderText="NOMBRE" ReadOnly="True" 
                SortExpression="COUNT(*)" />
        </Columns>
        
    </asp:GridView></center>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
        ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" SelectCommand="select code_cl,t1.code_module,t2.DESIGNATION,count(*) from ESP_EVALUATION t1, esp_module t2
where ANNEE_DEB=2017 and t1.code_module =t2.code_module group by t1.CODE_MODULE,code_cl,t2.DESIGNATION

order by code_cl
"></asp:SqlDataSource>
  <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
        ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" SelectCommand=" 
SELECT count(*) from ESP_EVALUATION where annee_deb=2017
"></asp:SqlDataSource>
</asp:Content>