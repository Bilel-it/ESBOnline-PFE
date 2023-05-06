<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="acceuill.aspx.cs" Inherits="ESPOnline.acceuill" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        <table class="style1">
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <table class="style1">
                        <tr>
                            <td>
                                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
                                <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Button" />
                                <asp:Button ID="Button3" runat="server" onclick="Button3_Click" Text="Button" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TBconf" runat="server" TextMode="MultiLine" Width="966px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TBchaine" runat="server" TextMode="MultiLine" Width="966px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TBreq" runat="server" Height="68px" TextMode="MultiLine" 
                                    Width="966px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
                                    GridLines="None">
                                    <AlternatingRowStyle BackColor="White" />
                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
