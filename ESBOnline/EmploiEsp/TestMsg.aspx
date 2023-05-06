<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestMsg.aspx.cs" Inherits="ESPOnline.EmploiEsp.TestMsg" %>

<%@ Register assembly="ProudMonkey.Common.Controls"
             namespace="ProudMonkey.Common.Controls" tagprefix="cc1" %>
<%@ Register assembly="AjaxControlToolkit" 
             namespace="AjaxControlToolkit" tagprefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <cc1:MessageBox ID="MessageBox1" runat="server" />
    </div>
    </form>
</body>
</html>
