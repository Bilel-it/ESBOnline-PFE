<%@ Control Language="VB" AutoEventWireup="false" CodeFile="MessageBox.ascx.vb" Inherits="MessageBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<style type="text/css">
    .Modal_trans
    {
        opacity: 0.8;
        filter: alpha(opacity=60);
        background: black;
    }
</style>
<asp:Panel ID="PopPanel" runat="server" BackColor="White" BorderStyle="Solid" BorderWidth="2px"
    ForeColor="White" Width="350px" DefaultButton="ok" Style="border-radius: 9px;
    overflow: hidden; display: none;" BorderColor="#FFFFCC">
    <table width="100%" style="border-collapse: collapse; border:0px;">
        <tr id="boxheader" runat="server" style="cursor: move;">
            <td style="background-color: #666666; padding-left: 10px; padding-top: 3px; padding-bottom: 3px;"
                colspan="2">
                <asp:Label ID="lblTitle" runat="server" Font-Size="12px" ForeColor="#d0dae1" Text="ToolTrak Message"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" id="icon" runat="server" 
                style="width: 50px; padding-left: 10px; padding-top: 5px; padding-bottom: 5px;">
                <asp:Image ID="image" runat="server" ImageUrl="~/imgs/info.png" />
            </td>
            <td style="padding: 10px; width: 220px;">
                <asp:Label ID="lblMsg" runat="server" ForeColor="#333333"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right: 20px; padding-top: 7px; padding-bottom: 7px;
                background-color: #666666; border-top-style: solid; border-top-width: 2px; border-top-color: #999999;"
                colspan="2">
                <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                <asp:Button ID="ok" runat="server" Text="Ok" Width="80px" />
                <asp:Button ID="no" runat="server" Text="No / Cancel" Width="80px" Visible="False" />
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:ModalPopupExtender ID="PopUp" runat="server" DynamicServicePath="" Enabled="True"
    PopupControlID="PopPanel" TargetControlID="LinkButton1" BackgroundCssClass="Modal_trans"
    OkControlID="ok" PopupDragHandleControlID="boxheader">
</asp:ModalPopupExtender>
