<%@ Control AutoEventWireup="true" CodeBehind="MessageBox.ascx.cs" Inherits="MessageBox" Language="C#" %>
    <div id="<%= WrapperElementID %>" class="MessageBoxWrapper">
        <asp:Panel ID="MessageBoxInterface" runat="server" CssClass="MessageBoxInterface" Visible="false" EnableViewState="false">
            <script type="text/javascript">
                $(document).ready(function() {
                    if(<%= AutoCloseTimeout %> > 0)
                        $('#<%= MessageBoxInterface.ClientID %>').delay(<%= AutoCloseTimeout %>).slideUp(300);
                });
            </script>
            <asp:HyperLink ID="CloseButton" runat="server" Visible="false">
                <asp:Image ID="CloseImage" Visible="false" runat="server" AlternateText="Hide Alert Message" ImageUrl="~/Images/MessageBox_close.png" />
            </asp:HyperLink>
            <p>
                <asp:Literal ID="AlertMessage" runat="server"></asp:Literal>
            </p>
        </asp:Panel>
    </div>
