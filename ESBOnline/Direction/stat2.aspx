<%@ Page Title="" Language="C#" MasterPageFile="~/Direction/administration.Master" AutoEventWireup="true" CodeBehind="stat2.aspx.cs" Inherits="ESPOnline.Direction.Stat.stat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<center><br /><asp:Button ID="Button1" runat="server" OnClick="DownloadFile2"
        Text="Télécharger Statistique Effectif" CssClass="style5" 
        ForeColor="#FF0066" /><br /><br /><br /><asp:Button ID="Button3" runat="server" OnClick="DownloadFile"
        Text="Télécharger Statistique admission" CssClass="style5" 
        ForeColor="#FF0066" /><br />
 </center>
</asp:Content>
