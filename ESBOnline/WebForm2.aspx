<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="ESPOnline.WebForm2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server">
        </asp:ObjectDataSource>
        <asp:DetailsView ID="DetailsView1" runat="server" 
            DataSourceID="ObjectDataSource1" Height="50px" Width="125px">
        </asp:DetailsView>
    
    </div>
    </form>
</body>
</html>
