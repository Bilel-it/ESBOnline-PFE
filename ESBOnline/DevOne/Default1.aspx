<%@ Page Title="Home Page" Language="C#"  MasterPageFile="~/DevOne/Site.Master" AutoEventWireup="true"

 CodeBehind="Default1.aspx.cs" Inherits="DevOne._Default" %>

<%@ Register Src="MessageBox.ascx" TagName="MessageBox" TagPrefix="uc1" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="head">
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
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="Main">
    <h2>
        Welcome to ASP.NET!
    </h2>
    <p>
        To learn more about ASP.NET visit <a href="http://www.asp.net" title="ASP.NET Website">www.asp.net</a>.
    </p>
    <p>
        You can also find <a href="http://go.microsoft.com/fwlink/?LinkID=152368&amp;clcid=0x409" title="MSDN ASP.NET Docs">documentation on ASP.NET at MSDN</a>.
    </p>
    <h1>
        Client Side Message(s)</h1>
    <input type="button" value="Show Success in 1" onclick="ShowSuccess('Client Side Success');" />
    <input type="button" value="Show Error in 2" onclick="ShowError('Client Side Error');" />
    <h1>
        Server Side Message(s)</h1>
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
