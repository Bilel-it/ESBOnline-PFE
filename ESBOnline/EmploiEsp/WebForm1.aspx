<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ESPOnline.EmploiEsp.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Yearly Calendar</title>
    <style type="text/css">
        table td { padding:0; margin:0; border:1px solid #dadada; }
        table th { width:25px; text-align:center; }
        table td { text-align:center; }
        table td span { color:#dadada; }
        table td a { color:#000000; text-decoration:none; }
        table td a:hover { text-decoration:underline; }
        table td a.hasEvents { color:#ff0000; }
        table td a.selected { color:#0000ff; font-weight:bold; }
        table td.month { background-color:#999999; }
        table td.weekend { background-color:#D0D0D0; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0">
            <thead>
                <tr>
                    <th>
                        <asp:Literal ID="litSelectedYear" runat="server" />
                    </th>
                    <% for (int iWeek = 1; iWeek <= 6; iWeek++) {
                        for (int iDay = 1; iDay <= 7; iDay++) { if (iWeek == 6 && iDay > 2) break; %>
                        <th>
                            <%=GetDayName(iDay) %>
                        </th>
                    <% } } %>
                </tr>
            </thead>
            <asp:Repeater ID="repMonths" runat="server" OnInit="repMonths_OnInit" OnItemDataBound="repMonths_OnItemDataBound">
                <ItemTemplate>                  
                    <tr>
                        <td class="month">
                            <asp:HyperLink ID="hylMonth" runat="server" />
                        </td>
                        <asp:Repeater ID="repDays" runat="server" OnItemDataBound="repDays_OnItemDataBound">
                            <ItemTemplate>
                                <td id="tdDay" runat="server">
                                    <asp:Literal ID="litDay" runat="server" />
                                </td>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    </form>
</body>
</html>
