<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ESPOnline.Maha.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="home">
     <div id="Div" runat="server" style="width: 810px; height: 500px;">
   <div id="sidebar">
                 <asp:Button ID="Button_GetCheckBox" runat="server" Text="Button" />
                 <asp:Label id="Label1" runat="server" />
             </div>
       
             <asp:Panel ID="Panel1" runat="server">
      <div id="content">
          <h3><font face="Verdana">add checkbox to calendar</font></h3>
          <asp:Calendar id="Calendar1" runat="server"
                    ondayrender="Calendar1_DayRender"
                    ShowGridLines="true"
                    BorderWidth="1"
                    Font-Names="Verdana"
                    Font-Size="9px"
                    Width="500px"
                    VisibleDate="01/01/2011"
                    TitleStyle-BackColor="Red"
                    TitleStyle-Font-Size="12px"
                    TitleStyle-Font-Bold="true"
                     DayStyle-VerticalAlign="Top"
                    DayStyle-Height="50px"
                    DayStyle-Width="14%"
                    SelectedDate="1/1/0001"
                    SelectedDayStyle-BackColor="Red" />
                </asp:Panel>
  </div>
  </div>
    </form>
</body>
</html>
