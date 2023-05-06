<%@ Page Title="" Language="C#" MasterPageFile="~/Direction/Site2.Master" AutoEventWireup="true" CodeBehind="RapportRedouble.aspx.cs" Inherits="ESPOnline.Direction.RapportRedouble" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="585px" 
        Width="814px" Font-Names="Verdana" Font-Size="8pt" 
    InteractiveDeviceInfos="(Collection)" ProcessingMode="Remote" 
    WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" >
        <ServerReport ReportPath="/Report Project test2/Redoublants" 
            ReportServerUrl="http://41.226.11.244/ReportESPRIT" />
</rsweb:ReportViewer>
</asp:Content>
