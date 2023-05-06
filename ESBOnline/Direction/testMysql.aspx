<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testMysql.aspx.cs" Inherits="ESPOnline.Direction.testMysql" MasterPageFile="~/Direction/Site112.Master" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Contents/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="../Contents/Scripts/bootstrap.js" type="text/javascript"></script>
    <script type="text/javascript" src="../Contents/Scripts/JScript1.js"></script>
    <style type="text/css">
        .RadComboBox
        {
            height: 50px !important;
        }
        .style1
        {
            width: 100%;
            margin-right: 0px;
        }
        .style2
        {
            text-align: center;
        }
        .style3
        {
            width: 176px;
        }
        .style4
        {
            height: 70px;
        }
        .style5
        {
            color: #CC0000;
        }
    .auto-style1 {
        background-color: #00CCFF;
    }
    </style>
    <script language="javascript" type="text/javascript">
        function confirmSubmit() {
            var msg = "Etes-vous sûr que vous voulez sauvegarder les données?";
            if (confirm(msg)) {
                hide.value = "OUI";
            }
            else { hide.value = "Non"; }
        } 
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br /><br /><br />
     <asp:GridView ID="gridmoodle" runat="server" AutoGenerateColumns="true">
                                        </asp:GridView><br />
                            
                            <asp:Button ID="Button1"
                                runat="server" Text="updatemoodle" OnClick="Button1_Click" /><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

      
       
                  
</asp:Content>
