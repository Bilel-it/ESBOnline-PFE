<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestDeleting.aspx.cs" Inherits="ESPOnline.EmploiEsp.TestDeleting" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Calendar runat="server" ID="Calendar1" Width="800px" Height="700px" BackColor="White"
    BorderColor="Black" DayNameFormat="Shortest" Font-Names="Times New Roman" Font-Size="10pt"
    ForeColor="Black" NextPrevFormat="FullMonth" TitleFormat="Month" ShowGridLines="true" >
    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" ForeColor="#333333"
        Height="10pt" />
    <DayStyle Width="14%" />
    <NextPrevStyle Font-Size="8pt" ForeColor="White" />
    <OtherMonthDayStyle ForeColor="#999999" />
    <SelectedDayStyle BackColor="#CC3333" ForeColor="White" />
    <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
        ForeColor="#333333" Width="1%" />
    <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White"
        Height="14pt" />
    <TodayDayStyle BackColor="#CCCC99" />
</asp:Calendar>
<asp:PlaceHolder runat="server" ID="PlaceHolder1"></asp:PlaceHolder>
    </div>
    </form>
</body>
</html>
