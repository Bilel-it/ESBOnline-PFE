<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DefaultMBOX.aspx.cs" Inherits="ESPOnline.EmploiEsp.DefaultMBOX" 
MasterPageFile="~/Etudiants/Eol.Master"%>

<%@ Register Src="~/EmploiEsp/MessageBox.ascx" TagName="MessageBox" TagPrefix="uc1" %>

<asp:Content ID="content1" runat="server" ContentPlaceHolderID="head">
<link href="../DevOne/Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="../DevOne/Styles/MessageBox.css" rel="stylesheet" type="text/css" />
    <script src="../DevOne/Scripts/jquery-1.6.1.js" type="text/javascript"></script>
<script type="text/javascript">
    function ShowSuccess(message) {
        $alert = $('#MBWrapper1');

        $alert.removeClass().addClass('MessageBoxInterface');
        $alert.children('p').remove();
        $alert.append('<p>' + message + '</p>').addClass('successMsg').show().delay(8000).slideUp(300);
    }

    function ShowError(message) {
        $alert = $('#MBWrapper2');

        $alert.removeClass().addClass('MessageBoxInterface');
        $alert.children('p').remove();
        $alert.append('<p>' + message + '</p>').addClass('errorMsg').show().delay(8000).slideUp(300);
    }
    </script>
</asp:Content>

<asp:Content ID="content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

<h1>
        <asp:Button ID="Success" runat="server" Text="Show Success in 1" OnClick="Success_Click" />
        <asp:Button ID="Error" runat="server" Text="Show Error in 2" OnClick="Error_Click" />
        <asp:Button ID="Warning" runat="server" Text="Show Warning in 1" OnClick="Warning_Click" />
        <asp:Button ID="Information" runat="server" Text="Show Information in 2" OnClick="Information_Click" />
    </h1>
    <!-- Message Box User Control 1 -->
    <h1>
        Message Box 1</h1>
    <uc1:MessageBox ID="MessageBox1" WrapperElementID="MBWrapper1" runat="server"  />

    <!-- Message Box User Control 2 -->
    <h1>
        Message Box 2</h1>
    <uc1:MessageBox ID="MessageBox2" WrapperElementID="MBWrapper2" runat="server" />

</asp:Content>