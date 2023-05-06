<%@ Page Title="" Language="C#" MasterPageFile="~/Direction/Site2.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ESPOnline.Direction.WebForm1" %>

 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"/>
        <center><asp:Label ID="Label2" runat="server" 
            Text="Répartition des candidats entretenus" 
            style="font-weight: 700; color: #CC0000; font-size: x-large"></asp:Label></center><br />
        <asp:DropDownList ID="DropDownList1" runat="server"  AutoPostBack="true">
        <asp:ListItem Value="1">NIVEAU 1</asp:ListItem>
        <asp:ListItem Value="2">NIVEAU 2</asp:ListItem>
        <asp:ListItem Value="3">NIVEAU 3</asp:ListItem>
        </asp:DropDownList><br /><br />
<cc1:LineChart ID="LineChart1" runat="server" ChartHeight="500" ChartWidth="2000"
        ChartType="Basic" ChartTitleColor="#0E426C" Visible="false" CategoryAxisLineColor="#D08AD9"
        ValueAxisLineColor="#D08AD9" BaseLineColor="#A156AB">
    </cc1:LineChart>
    <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>  
</asp:Content>
