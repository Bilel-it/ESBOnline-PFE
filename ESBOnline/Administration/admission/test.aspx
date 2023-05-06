<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs"  Inherits="ESPOnline.Administration.admission.test" MasterPageFile="~/Administration/admission/ad.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <asp:GridView ID="gridmoodle" runat="server" AutoGenerateColumns="true">
                                        </asp:GridView><br />
                            
                            <asp:Button ID="Button1"
                                runat="server" Text="updatemoodle" OnClick="Button1_Click" /><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</asp:Content>

