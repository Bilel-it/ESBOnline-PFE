﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="ESPOnline.Etudiants.WebForm2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="TextBox1" runat="server">11-3MT-772</asp:TextBox>
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="ObjectDataSource2">
            <Columns>
                <asp:BoundField DataField="CODE_MODULE" HeaderText="CODE_MODULE" 
                    SortExpression="CODE_MODULE" />
                <asp:BoundField DataField="DESIGNATION" HeaderText="DESIGNATION" 
                    SortExpression="DESIGNATION" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
            SelectMethod="GetListEval" TypeName="ESPSuiviEncadrement.Modules">
            <SelectParameters>
                <asp:ControlParameter ControlID="TextBox1" Name="id" PropertyName="Text" 
                    Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
